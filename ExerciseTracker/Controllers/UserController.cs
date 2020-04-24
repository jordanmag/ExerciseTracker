using ExerciseTracker.DataAccess.Models;
using ExerciseTracker.DTO.User;
using ExerciseTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDTO newUser)
        {
            return Ok(await _userService.AddUser(newUser));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO updatedUser)
        {
            var response = await _userService.UpdateUser(updatedUser);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _userService.DeleteUser(id);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
