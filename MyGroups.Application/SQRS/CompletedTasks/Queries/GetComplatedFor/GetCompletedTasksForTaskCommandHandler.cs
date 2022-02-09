using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Groups;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapper.QueryableExtensions.Impl;
using MyGroups.Domain.Models.Tasks;

namespace MyGroups.Application.SQRS.CompletedTasks.Queries.GetComplatedFor
{
    public class GetCompletedTasksForTaskCommandHandler : IRequestHandler<GetComplatedTasksForTaskCommand, ICollection<CompletedTaskViewModel>>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IAuthorizationService authorizationService;
        private readonly IMapper mapper;

        public GetCompletedTasksForTaskCommandHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.authorizationService = authorizationService;
            this.mapper = mapper;
        }

        public async Task<ICollection<CompletedTaskViewModel>> Handle(GetComplatedTasksForTaskCommand request, CancellationToken cancellationToken)
        {
            var user = authorizationService.CurrentUser;

            var userGroup = await databaseContext.UsersGroups
                .FirstOrDefaultAsync(ug => ug.User == user);

            IQueryable<CompletedTask> tasks = null;

            if (userGroup.Role == UserRolesInGroup.Member)
            {
                tasks = databaseContext.CompletedTasks
                    .Include(ct => ct.Creator)
                    .Include(ct => ct.Grade)
                    .Include(ct => ct.Task)
                    .Include(ct => ct.File)
                    .Where(ct => ct.Task.Id == request.TaskId)
                    .Where(ct => ct.Creator == user);
            }
            else
            {
                tasks = databaseContext.CompletedTasks
                    .Include(ct => ct.Creator)
                    .Include(ct => ct.Grade)
                    .Include(ct => ct.Task)
                    .Include(ct => ct.File)
                    .Where(ct => ct.Task.Id == request.TaskId);
            }

            var result = await tasks
                .ProjectTo<CompletedTaskViewModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
