using AutoMapper;
using GymLogger.DataAccess.Models;
using GymLogger.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymLogger.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<User> users = new List<User>
        {
            new User() { Id = 0, Username = "jordan", Password = "xxxx"},
            new User() { Id = 1, Username = "jayden", Password = "xxxx"}
        };

        public async Task<ServiceResponse<List<GetUserDTO>>> AddUser(AddUserDTO newUser)
        {
            ServiceResponse<List<GetUserDTO>> serviceResponse = new ServiceResponse<List<GetUserDTO>>();

            User user = _mapper.Map<User>(newUser);
            user.Id = users.Max(u => u.Id) + 1;

            users.Add(user);
            serviceResponse.Data = (users.Select(u => _mapper.Map<GetUserDTO>(u))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers()
        {
            ServiceResponse<List<GetUserDTO>> serviceResponse = new ServiceResponse<List<GetUserDTO>>();
            serviceResponse.Data = (users.Select(u => _mapper.Map<GetUserDTO>(u))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserById(int id)
        {
            ServiceResponse<GetUserDTO> serviceResponse = new ServiceResponse<GetUserDTO>();
            serviceResponse.Data = _mapper.Map<GetUserDTO>(users.FirstOrDefault(u => u.Id == id));

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updatedUser)
        {
            ServiceResponse<GetUserDTO> serviceResponse = new ServiceResponse<GetUserDTO>();

            try
            {
                User user = users.FirstOrDefault(u => u.Id == updatedUser.Id);

                user.Username = updatedUser.Username;
                user.Password = updatedUser.Password;

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
            ServiceResponse<List<GetUserDTO>> serviceResponse = new ServiceResponse<List<GetUserDTO>>();

            try
            {
                User user = users.First(u => u.Id == id);
                users.Remove(user);

                serviceResponse.Data = (users.Select(u => _mapper.Map<GetUserDTO>(u))).ToList();
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
