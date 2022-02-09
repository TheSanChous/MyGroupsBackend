using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Interfaces;
using MyGroups.Application.SQRS.Tasks.Queries.GetGroupTasks;
using MyGroups.Application.SQRS.Tasks.Queries.GetTaskDetails;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Tasks.Queries.GetUserTasks
{
    public class GetUserTasksCommandHandler : IRequestHandler<GetUserTasksCommand, ICollection<TaskViewModel>>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IAuthorizationService authorizationService;
        private readonly IMapper mapper;

        public GetUserTasksCommandHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.authorizationService = authorizationService;
            this.mapper = mapper;
        }

        public async Task<ICollection<TaskViewModel>> Handle(GetUserTasksCommand request, CancellationToken cancellationToken)
        {
            var user = authorizationService.CurrentUser;

            var userGroups = databaseContext.UsersGroups
                .Include(ug => ug.Group)
                .Include(ug => ug.User)
                .Where(ug => ug.User == user)
                .Select(ug => ug.Group);

            var tasks = await databaseContext.Tasks
                .Where(task => userGroups.Any(group => group == task.Group))
                .ProjectTo<TaskViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);

            return tasks;
        }
    }
}
