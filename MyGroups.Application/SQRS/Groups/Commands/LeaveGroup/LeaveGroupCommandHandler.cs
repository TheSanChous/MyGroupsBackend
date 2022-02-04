using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Application.SQRS.Groups.Queries.GetGroup;
using MyGroups.Domain.Models.Groups;
using MyGroups.Domain.Models.Users;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Groups.Commands.LeaveGroup
{
    public class LeaveGroupCommandHandler : IRequestHandler<LeaveGroupCommand, Unit>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IAuthorizationService authorizationService;
        private readonly IMediator mediator;

        public LeaveGroupCommandHandler(
            IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IMediator mediator)
        {
            this.databaseContext = databaseContext;
            this.authorizationService = authorizationService;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(LeaveGroupCommand request, CancellationToken cancellationToken)
        {
            var user = authorizationService.CurrentUser;

            var group = await databaseContext.Groups
                .SingleOrDefaultAsync(group => group.Id == request.GroupId);

            if (group is null)
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            var userGroup = await databaseContext.UsersGroups
                .Where(ug => ug.User == user)
                .SingleOrDefaultAsync(ug => ug.Group == group, cancellationToken);

            if (userGroup is null)
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            databaseContext.UsersGroups.Remove(userGroup);

            await databaseContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
