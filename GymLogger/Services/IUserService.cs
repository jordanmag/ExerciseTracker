using GymLogger.DataAccess.Models;
using GymLogger.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymLogger.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers();

        Task<ServiceResponse<GetUserDTO>> GetUserById(int id);

        Task<ServiceResponse<List<GetUserDTO>>> AddUser(AddUserDTO newUser);

        Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updatedUser);

        Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id);
    }
}
