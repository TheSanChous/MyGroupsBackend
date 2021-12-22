using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGroupsAPI.Models.Authentication;
using MyGroupsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroupsAPI.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var token = await authenticationService.LoginAsync(loginModel);

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationModel registrationModel)
        {
            await authenticationService.RegisterAsync(registrationModel);

            return Ok();
        }
    }
}
