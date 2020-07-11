using AutoMapper;
using ExerciseTracker.DataAccess.Database;
using ExerciseTracker.DataAccess.Models;
using ExerciseTracker.DTO.Exercise;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExerciseTracker.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IMapper _mapper;
        private readonly ExerciseTrackerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExerciseService(IMapper mapper, ExerciseTrackerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetExerciseDto>>> AddExercise(AddExerciseDto newExercise)
        {
            var serviceResponse = new ServiceResponse<List<GetExerciseDto>>();
            
            var exercise = _mapper.Map<Exercise>(newExercise);

            exercise.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            exercise.Created = DateTime.Now;
            exercise.LastModified = DateTime.Now;

            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();

            serviceResponse.Data = (_context.Exercises.Where(e => e.User.Id == GetUserId())
                .Select(e => _mapper.Map<GetExerciseDto>(e))).ToList();
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetExerciseDto>>> GetAllExercises()
        {
            var serviceResponse = new ServiceResponse<List<GetExerciseDto>>();

            var dbExercises = await _context.Exercises.Where(e => e.User.Id == GetUserId()).ToListAsync();
            
            serviceResponse.Data = dbExercises.Select(e => _mapper.Map<GetExerciseDto>(e)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetExerciseDto>>> GetExercisesByUser()
        {
            var serviceResponse = new ServiceResponse<List<GetExerciseDto>>();

            var dbExercises = await _context.Exercises.Where(e => e.User.Id == GetUserId()).ToListAsync();

            serviceResponse.Data = dbExercises.Select(e => _mapper.Map<GetExerciseDto>(e)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetExerciseDto>> GetExerciseById(int id)
        {
            var serviceResponse = new ServiceResponse<GetExerciseDto>();

            var dbExercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);
            serviceResponse.Data = _mapper.Map<GetExerciseDto>(dbExercise);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetExerciseDto>> UpdateExercise(UpdateExerciseDto updatedExercise)
        {
            var serviceResponse = new ServiceResponse<GetExerciseDto>();

            try
            {
                var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == updatedExercise.Id);
                //exercise.Exercisename = updatedExercise.Exercisename;

                _context.Exercises.Update(exercise);
                await _context.SaveChangesAsync(); 

                serviceResponse.Data = _mapper.Map<GetExerciseDto>(exercise);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetExerciseDto>>> DeleteExercise(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetExerciseDto>>();

            try
            {
                var Exercise = await _context.Exercises.FirstAsync(e => e.Id == id);
                _context.Exercises.Remove(Exercise);
                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Exercises.Select(e => _mapper.Map<GetExerciseDto>(e))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
