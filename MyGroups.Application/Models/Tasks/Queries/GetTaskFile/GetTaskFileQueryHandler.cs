using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Interfaces;
using MyGroups.Application.Models.Groups.Queries.GetGroupUsers;
using File = MyGroups.Domain.Models.Files.File;

namespace MyGroups.Application.Models.Tasks.Queries.GetTaskFile
{
    public class GetTaskFileQueryHandler : IRequestHandler<GetTaskFileQuery, FileViewModel>
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        public GetTaskFileQueryHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IMapper mapper)
        {
            _databaseContext = databaseContext;
            _authorizationService = authorizationService;
            _mapper = mapper;
        }

        public async Task<FileViewModel> Handle(GetTaskFileQuery request, CancellationToken cancellationToken)
        {
            var user = _authorizationService.CurrentUser;

            var task = await _databaseContext.Tasks
                .Include(task => task.File)
                .FirstOrDefaultAsync(task => task.Id == request.TaskId, cancellationToken);

            var file = await _databaseContext.Files.FirstOrDefaultAsync(file => file == task.File, cancellationToken);

            return _mapper.Map<FileViewModel>(file);
        }
    }
}