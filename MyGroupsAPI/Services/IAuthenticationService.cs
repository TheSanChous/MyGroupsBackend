using MyGroupsAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroupsAPI.Services
{
    public interface IAuthenticationService
    {
        public Task RegisterAsync(RegistrationModel registrationModel);
        public Task<string> LoginAsync(LoginModel loginModel);
    }
}
