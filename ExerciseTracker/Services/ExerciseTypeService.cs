using AutoMapper;
using ExerciseTracker.DataAccess.Database;
using ExerciseTracker.DataAccess.Models;
using ExerciseTracker.DTO.ExerciseType;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTracker.Services
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly IMapper _mapper;
        private readonly ExerciseTrackerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExerciseTypeService(IMapper mapper, ExerciseTrackerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<GetExerciseTypeDto>>> AddExerciseType(AddExerciseTypeDto newExerciseType)
        {
            var serviceResponse = new ServiceResponse<List<GetExerciseTypeDto>>();
            var exerciseType = _mapper.Map<ExerciseType>(newExerciseType);

            await _context.ExerciseTypes.AddAsync(exerciseType);
            await _context.SaveChangesAsync();

            serviceResponse.Data = (_context.Users.Select(u => _mapper.Map<GetExerciseTypeDto>(u))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetExerciseTypeDto>>> DeleteExerciseType(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetExerciseTypeDto>>();

            try
            {
                var exerciseType = await _context.ExerciseTypes.FirstAsync(e => e.Id == id);
                _context.ExerciseTypes.Remove(exerciseType);
                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Users.Select(u => _mapper.Map<GetExerciseTypeDto>(u))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetExerciseTypeDto>>> GetAllExerciseTypes()
        {
            var serviceResponse = new ServiceResponse<List<GetExerciseTypeDto>>();

            var dbExerciseTypes = await _context.ExerciseTypes.ToListAsync();
            serviceResponse.Data = dbExerciseTypes.Select(u => _mapper.Map<GetExerciseTypeDto>(u)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetExerciseTypeDto>> GetExerciseTypeById(int id)
        {
            var serviceResponse = new ServiceResponse<GetExerciseTypeDto>();

            var dbExerciseType = await _context.ExerciseTypes.FirstOrDefaultAsync(u => u.Id == id);
            serviceResponse.Data = _mapper.Map<GetExerciseTypeDto>(dbExerciseType);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetExerciseTypeDto>> UpdateExerciseType(UpdateExerciseTypeDto updatedExerciseType)
        {
            var serviceResponse = new ServiceResponse<GetExerciseTypeDto>();

            try
            {
                var exerciseType = await _context.ExerciseTypes.FirstOrDefaultAsync(e => e.Id == updatedExerciseType.Id);
                exerciseType.Name = updatedExerciseType.Name;
                exerciseType.Category = updatedExerciseType.Category;
                exerciseType.Description = updatedExerciseType.Desription;


                _context.ExerciseTypes.Update(exerciseType);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetExerciseTypeDto>(exerciseType);
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
