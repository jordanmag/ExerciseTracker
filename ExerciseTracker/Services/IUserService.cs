using ExerciseTracker.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseTracker.Services
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
