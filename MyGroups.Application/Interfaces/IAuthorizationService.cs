using MyGroups.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.Interfaces
{
    public interface IAuthorizationService
    {
        User CurrentUser { get; set; }
        public Task AuthorizeAsync(ClaimsPrincipal userClaims);
    }
}
