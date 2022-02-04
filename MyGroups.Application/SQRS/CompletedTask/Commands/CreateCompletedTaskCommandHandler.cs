using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Files;
using MyGroups.Domain.Models.Groups;
using MyGroups.Infrastructure.Abstractions;
using Task = MyGroups.Domain.Models.Tasks.Task;

namespace MyGroups.Application.SQRS.CompletedTask.Commands
{
    public class CreateCompletedTaskCommandHandler : IRequestHandler<CreateCompletedTaskCommand, Guid>
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IAuthorizationService _authorizationService;
        private readonly IStorageService _storageService;

        public CreateCompletedTaskCommandHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IStorageService storageService)
        {
            _databaseContext = databaseContext;
            _authorizationService = authorizationService;
            _storageService = storageService;
        }

        public async Task<Guid> Handle(CreateCompletedTaskCommand request, CancellationToken cancellationToken)
        {
            var user = _authorizationService.CurrentUser;

            var task = await _databaseContext.Tasks.Include(task => task.Group)
                .FirstOrDefaultAsync(task => task.Id == request.TaskId, cancellationToken);

            if (task is null)
            {
                throw new NotFoundException(nameof(Task), request.TaskId);
            }
            
            var userGroup = await _databaseContext.UsersGroups
                .Include(userGroup => userGroup.Group)
                .Include(userGroup => userGroup.User)
                .FirstOrDefaultAsync(userGroup => userGroup.Group == task.Group && userGroup.User == user,
                    cancellationToken);

            if (userGroup is null)
            {
                throw new NotFoundException(nameof(Group), task.Group.Id);
            }
            
            if (userGroup.Role != UserRolesInGroup.Member)
            {
                throw new UserAccessDeniedException();
            }

            var newCompletedTask = new Domain.Models.Tasks.CompletedTask
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Creator = user,
                Task = task,
                UploadedAt = DateTime.Now.ToUniversalTime()
            };

            if (request.File != null)
            {
                var fileInfo = await _storageService.SaveFileAsync(request.File.FileName, request.File.OpenReadStream(),
                    cancellationToken);

                var file = new File
                {
                    Name = fileInfo.FileName,
                    BlobName = fileInfo.BlobName,
                    Url = fileInfo.Url
                };

                newCompletedTask.File = file;

                await _databaseContext.Files.AddAsync(file, cancellationToken);
            }

            await _databaseContext.CompletedTasks.AddAsync(newCompletedTask, cancellationToken);
            await _databaseContext.SaveChangesAsync(cancellationToken);

            return newCompletedTask.Id;
        }
    }
}