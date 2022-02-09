using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Interfaces;
using MyGroups.Infrastructure.Abstractions;

namespace MyGroups.Application.SQRS.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler : IRequestHandler<GetTaskDetailsQuery, TaskDetailsViewModel>
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        public GetTaskDetailsQueryHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService, 
            IMapper mapper)
        {
            _databaseContext = databaseContext;
            _authorizationService = authorizationService;
            _mapper = mapper;
        }
        
        public async Task<TaskDetailsViewModel> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = _authorizationService.CurrentUser;

            var task = await _databaseContext.Tasks
                .Include(task => task.Group)
                .FirstOrDefaultAsync(task => task.Id == request.TaskId, cancellationToken);

            return _mapper.Map<TaskDetailsViewModel>(task);
        }
    }
}