using Microsoft.AspNetCore.Mvc;
using MyGroups.Application.Models.Users.Commands.Login;
using MyGroups.Application.Models.Users.Commands.Register;
using MyGroups.WebApi.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroups.WebApi.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegistrationModel registrationModel)
        {
            var command = new RegisterUserCommand
            {
                Email = registrationModel.Email,
                Name = registrationModel.Name,
                Surname = registrationModel.Surname,
                Password = registrationModel.Password
            };

            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {

            var command = new LoginUserCommand
            {
                Email = loginModel.Email,
                Password = loginModel.Password
            };

            var token = await Mediator.Send(command);

            return Ok(new
            {
                AccessToken = token
            });
        }
    }
}