using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.Models.Groups.Queries.GetRoleInGroup
{
    public class GetRoleInGroupHandler : IRequestHandler<GetRoleInGroupQuery, UserRolesInGroup>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IAuthorizationService authorizationService;

        public GetRoleInGroupHandler(IDatabaseContext databaseContext, 
            IAuthorizationService authorizationService)
        {
            this.databaseContext = databaseContext;
            this.authorizationService = authorizationService;
        }

        public async Task<UserRolesInGroup> Handle(GetRoleInGroupQuery request, CancellationToken cancellationToken)
        {
            var user = authorizationService.CurrentUser;

            var userGroup = await databaseContext.UsersGroups
                .FirstOrDefaultAsync(userGroup => userGroup.User == user && userGroup.Group.Id == request.GroupId, cancellationToken);

            if(userGroup is null)
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            return userGroup.Role;
        }
    }
}
