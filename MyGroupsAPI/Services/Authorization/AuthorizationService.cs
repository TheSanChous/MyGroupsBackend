using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using MyGroupsAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyGroupsAPI.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly DatabaseContext databaseContext;
        public User CurrentUser { get; set; }

        public AuthorizationService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public User Authorize(ClaimsPrincipal userClaims)
        {
            Claim identifier = userClaims.FindFirst(ClaimTypes.NameIdentifier);

            if (identifier is null)
            {
                throw new ServiceException("User not authorized");
            }

            Guid id = Guid.Parse(identifier.Value);

            User user = databaseContext.Users
                .SingleOrDefault(user => user.Id == id);                

            if (user is null)
            {
                throw new ServiceException("User not found");
            }

            return user;            
        }
    }
}
