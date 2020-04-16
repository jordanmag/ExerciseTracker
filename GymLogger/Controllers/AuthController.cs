using GymLogger.DataAccess.Models;
using GymLogger.DTO.User;
using GymLogger.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymLogger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            var user = new User() { Username = request.Username };

            var response = await _authService.Register(user, request.Password);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            var response = await _authService.Login(request.Username, request.Password);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
