using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Files;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.CompletedTasks.Commands.AppendFile
{
    public class CompletedTaskAppendFileCommandHandler : IRequestHandler<CompletedTaskAppendFileCommand>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IAuthorizationService authorizationService;
        private readonly IStorageService storageService;

        public CompletedTaskAppendFileCommandHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IStorageService storageService)
        {
            this.databaseContext = databaseContext;
            this.authorizationService = authorizationService;
            this.storageService = storageService;
        }

        public async Task<Unit> Handle(CompletedTaskAppendFileCommand request, CancellationToken cancellationToken)
        {
            var User = authorizationService.CurrentUser;

            var task = await databaseContext.CompletedTasks
                .FirstOrDefaultAsync(task => task.Id == request.ComplatedTaskId);

            if( task == null)
            {
                throw new NotFoundException(nameof(CompletedTasks), request.ComplatedTaskId);
            }

            var fileInfo = await storageService.SaveFileAsync(request.FormFile.FileName, request.FormFile.OpenReadStream(), cancellationToken);

            var file = new File
            {
                Name = fileInfo.FileName,
                BlobName = fileInfo.BlobName,
                Url = fileInfo.Url
            };

            await databaseContext.Files.AddAsync(file, cancellationToken);

            task.File = file;

            await databaseContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
