using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IAuthorizationService authorizationService;
        private readonly IStorageService _storageService;

        public DeleteTaskCommandHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IStorageService storageService)
        {
            this.databaseContext = databaseContext;
            this.authorizationService = authorizationService;
            _storageService = storageService;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var user = authorizationService.CurrentUser;

            var task = await databaseContext.Tasks
                .Include(task => task.Creator)
                .Include(task => task.Group)
                .Include(task => task.File)
                .FirstOrDefaultAsync(task => task.Id == request.TaskId, cancellationToken);

            if(task is null)
            {
                throw new NotFoundException(nameof(task), request.TaskId);
            }

            if(task.Creator != user)
            {
                throw new UserAccessDeniedException();
            }
            
            databaseContext.Tasks.Remove(task);

            if (task.File != null)
            {
                databaseContext.Files.Remove(task.File);
                await _storageService.DeleteFileAsync(task.File.BlobName, cancellationToken);
            }

            await databaseContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
