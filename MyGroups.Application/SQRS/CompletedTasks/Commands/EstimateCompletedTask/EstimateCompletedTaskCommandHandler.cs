using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Grades;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.CompletedTasks.Commands.EstimateCompletedTask
{
    public class EstimateCompletedTaskCommandHandler : IRequestHandler<EstimateCompletedTaskCommand, Unit>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IAuthorizationService authorizationService;

        public EstimateCompletedTaskCommandHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService)
        {
            this.databaseContext = databaseContext;
            this.authorizationService = authorizationService;
        }

        public async Task<Unit> Handle(EstimateCompletedTaskCommand request, CancellationToken cancellationToken)
        {
            var user = authorizationService.CurrentUser;

            var userGroup = await databaseContext.UsersGroups
                .FirstOrDefaultAsync(ug => ug.User == user, cancellationToken);

            if(userGroup.Role == Domain.Models.Groups.UserRolesInGroup.Member)
            {
                throw new UserAccessDeniedException();
            }

            var completedTask = await databaseContext.CompletedTasks
                .FirstOrDefaultAsync(ct => ct.Id == request.CompletedTaskId);

            var grade = new Grade
            {
                CompletedTask = completedTask,
                Evaluator = user,
                Description = request.Description,
                Value = request.Value
            };

            await databaseContext.Grades.AddAsync(grade, cancellationToken);

            await databaseContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
