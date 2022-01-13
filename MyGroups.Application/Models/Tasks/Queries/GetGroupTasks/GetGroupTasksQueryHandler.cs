using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Groups;
using MyGroups.Domain.Models.Users;


namespace MyGroups.Application.Models.Tasks.Queries.GetGroupTasks
{
    public class GetGroupTasksQueryHandler : IRequestHandler<GetGroupTasksQuery, ICollection<TaskViewModel>>
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        public GetGroupTasksQueryHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IMapper mapper)
        {
            _databaseContext = databaseContext;
            _authorizationService = authorizationService;
            _mapper = mapper;
        }
        
        public async Task<ICollection<TaskViewModel>> Handle(GetGroupTasksQuery request, CancellationToken cancellationToken)
        {
            var user = _authorizationService.CurrentUser;

            var userGroup = await _databaseContext.UsersGroups
                .Include(userGroup => userGroup.Group)
                .Include(userGroup => userGroup.User)
                .FirstOrDefaultAsync(userGroup => userGroup.User == user && userGroup.Group.Id == request.GroupId,
                    cancellationToken);

            if (userGroup is null)
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            var groupTasks = _databaseContext.Tasks
                .Where(task => task.Group == userGroup.Group);

            return _mapper.ProjectTo<TaskViewModel>(groupTasks).ToList();
        }
    }
}