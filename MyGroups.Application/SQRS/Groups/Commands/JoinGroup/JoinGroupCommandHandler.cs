using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Groups;
using MyGroups.Domain.Models.Users;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Groups.Commands.JoinGroup
{
    public class JoinGroupCommandHandler : IRequestHandler<JoinGroupCommand, Unit>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IAuthorizationService authorizationService;

        public JoinGroupCommandHandler(IDatabaseContext databaseContext, IAuthorizationService authorizationService)
        {
            this.databaseContext = databaseContext;
            this.authorizationService = authorizationService;
        }

        public async Task<Unit> Handle(JoinGroupCommand request, CancellationToken cancellationToken)
        {
            var user = authorizationService.CurrentUser;

            var group = await databaseContext.Groups
                .SingleOrDefaultAsync(group => group.Identifier == request.GroupIdentifier, cancellationToken);

            if(group is null)
            {
                throw new NotFoundException(nameof(Group), request.GroupIdentifier);
            }

            if (await IsUserInGroup(user, group, cancellationToken))
            {
                throw new CommandException("You already in group");
            }

            var userGroup = new UserGroup
            {
                User = user,
                Group = group,
                Role = UserRolesInGroup.Member
            };

            await databaseContext.UsersGroups.AddAsync(userGroup, cancellationToken);

            await databaseContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }

        private async Task<bool> IsUserInGroup(User user, Group group, CancellationToken cancellationToken)
        {
            return await databaseContext.UsersGroups
                .Where(ug => ug.User == user)
                .AnyAsync(ug => ug.Group == group, cancellationToken);
        }
    }
}
