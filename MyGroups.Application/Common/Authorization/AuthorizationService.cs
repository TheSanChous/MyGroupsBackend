using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Users;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyGroups.Application.Common.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IDatabaseContext databaseContext;

        public User CurrentUser { get; set; }

        public AuthorizationService(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task AuthorizeAsync(ClaimsPrincipal userClaims)
        {
            Claim identifier = userClaims.FindFirst(ClaimTypes.NameIdentifier);

            if (identifier is null)
            {
                throw new AuthorizationException("Authentication required");
            }

            Guid id = Guid.Parse(identifier.Value);

            User user = await databaseContext.Users
                .SingleOrDefaultAsync(user => user.Id == id);

            if (user is null)
            {
                throw new AuthorizationException("User not found");
            }

            CurrentUser = user;
        }
    }
}
