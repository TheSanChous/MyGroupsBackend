using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyGroupsAPI.Services.Authorization
{
    public interface IAuthorizationService
    {
        public User CurrentUser { get; set; }
        public User Authorize(ClaimsPrincipal user);
    }
}
