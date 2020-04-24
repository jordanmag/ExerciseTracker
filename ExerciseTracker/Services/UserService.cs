using AutoMapper;
using ExerciseTracker.DataAccess.Database;
using ExerciseTracker.DataAccess.Models;
using ExerciseTracker.DTO.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTracker.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ExerciseTrackerContext _context;

        public UserService(IMapper mapper, ExerciseTrackerContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> AddUser(AddUserDTO newUser)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();
            var user = _mapper.Map<User>(newUser);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            serviceResponse.Data = (_context.Users.Select(u => _mapper.Map<GetUserDTO>(u))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();

            var dbUsers = await _context.Users.ToListAsync();
            serviceResponse.Data = dbUsers.Select(u => _mapper.Map<GetUserDTO>(u)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();

            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            serviceResponse.Data = _mapper.Map<GetUserDTO>(dbUser);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
                user.Username = updatedUser.Username;
                //user.Password = updatedUser.Password; to be replaced with the hashed password

                _context.Users.Update(user);
                await _context.SaveChangesAsync(); 

                serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();

            try
            {
                var user = await _context.Users.FirstAsync(u => u.Id == id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Users.Select(u => _mapper.Map<GetUserDTO>(u))).ToList();
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
