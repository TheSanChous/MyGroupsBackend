using MediatR;
using MyGroups.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyGroups.Domain.Models.Tasks;
using MyGroups.Domain.Models.Groups;
using MyGroups.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Infrastructure.Abstractions;

namespace MyGroups.Application.SQRS.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IAuthorizationService _authorizationService;

        public CreateTaskCommandHandler(IDatabaseContext databaseContext,
                                        IAuthorizationService authorizationService)
        {
            this._databaseContext = databaseContext;
            this._authorizationService = authorizationService;
        }
        
        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var user = _authorizationService.CurrentUser;

            var group = await FindGroupAsync(request.GroupId, cancellationToken);

            await TryUserCanCreateTaskInGroupAsync(user, group, cancellationToken);

            var newTask = new Domain.Models.Tasks.Task
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                UploadedAt = DateTime.Now.ToUniversalTime(),
                Deadline = request.Deadline,
                PublishedAt = DateTime.Now.ToUniversalTime(),
                Creator = user,
                Group = group
            };

            await _databaseContext.Tasks.AddAsync(newTask, cancellationToken);

            await _databaseContext.SaveChangesAsync(cancellationToken);

            return newTask.Id;
        }

        public async Task<Group> FindGroupAsync(Guid groupId, CancellationToken cancellationToken) 
        {
            var group = await _databaseContext.Groups
                .FirstOrDefaultAsync(group => group.Id == groupId, cancellationToken);

            if(group is null)
            {
                throw new NotFoundException(nameof(Group), groupId);
            }

            return group;
        }

        public async System.Threading.Tasks.Task TryUserCanCreateTaskInGroupAsync(User user, Group group, CancellationToken cancellationToken)
        {
            var userGroup = await _databaseContext.UsersGroups
                .FirstOrDefaultAsync(userGroup => userGroup.User == user && userGroup.Group == group, cancellationToken);

            if(userGroup is null)
            {
                throw new NotFoundException(nameof(Group), group);
            }

            if(userGroup.Role == UserRolesInGroup.Member)
            {
                throw new UserAccessDeniedException();
            }
        }
    }
}
