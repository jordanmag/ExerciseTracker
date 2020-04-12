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
        private static List<User> users = new List<User>
        {
            new User() { Id = 0, Username = "jordan", Password = "xxxx"},
            new User() { Id = 1, Username = "jayden", Password = "xxxx"}
        };

        public async Task<ServiceResponse<List<GetUserDTO>>> AddUser(AddUserDTO newUser)
        {
            ServiceResponse<List<GetUserDTO>> serviceResponse = new ServiceResponse<List<GetUserDTO>>();

            users.Add(newUser);
            serviceResponse.Data = users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers()
        {
            ServiceResponse<List<GetUserDTO>> serviceResponse = new ServiceResponse<List<GetUserDTO>>();
            serviceResponse.Data = users;

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserById(int id)
        {
            ServiceResponse<GetUserDTO> serviceResponse = new ServiceResponse<GetUserDTO>();
            serviceResponse.Data = users.FirstOrDefault(u => u.Id == id);

            return serviceResponse;
        }
    }
}
