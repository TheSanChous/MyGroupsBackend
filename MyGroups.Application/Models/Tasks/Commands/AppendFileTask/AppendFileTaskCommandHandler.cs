using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Files;
using MyGroups.Domain.Models.Groups;

namespace MyGroups.Application.Models.Tasks.Commands.AppendFileTask
{
    public class AppendFileTaskCommandHandler : IRequestHandler<AppendFileTaskCommand, Unit>
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IStorageService _storageService;
        private readonly IAuthorizationService _authorizationService;

        public AppendFileTaskCommandHandler(IDatabaseContext databaseContext,
            IStorageService storageService,
            IAuthorizationService authorizationService)
        {
            _databaseContext = databaseContext;
            _storageService = storageService;
            _authorizationService = authorizationService;
        }

        public async Task<Unit> Handle(AppendFileTaskCommand request, CancellationToken cancellationToken)
        {
            var user = _authorizationService.CurrentUser;

            var task = await _databaseContext.Tasks
                .FirstOrDefaultAsync(task => task.Creator == user && task.Id == request.TaskId, cancellationToken);

            if(task is null)
            {
                throw new NotFoundException("Task", request.TaskId);
            }

            var fileInfo = await _storageService.SaveFileAsync(request.File.FileName, request.File.OpenReadStream(), cancellationToken);
            
            var file = new File
            {
                Id = Guid.NewGuid(),
                Name = request.File.FileName,
                BlobName = fileInfo.BlobName,
                Url = fileInfo.Url
            };

            await _databaseContext.Files.AddAsync(file, cancellationToken);

            task.File = file;

            await _databaseContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}