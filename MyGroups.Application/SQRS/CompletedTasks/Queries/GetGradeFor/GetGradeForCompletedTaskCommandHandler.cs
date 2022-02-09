using AutoMapper;
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

namespace MyGroups.Application.SQRS.CompletedTasks.Queries.GetGradeFor
{
    public class GetGradeForCompletedTaskCommandHandler : IRequestHandler<GetGradeForCompletedTaskCommand, GradeViewModel>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IMapper mapper;

        public GetGradeForCompletedTaskCommandHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;
        }

        public async Task<GradeViewModel> Handle(GetGradeForCompletedTaskCommand request, CancellationToken cancellationToken)
        {
            var grade = await databaseContext.Grades
                .FirstOrDefaultAsync(grade => grade.CompletedTask.Id == request.CompletedTaskId, cancellationToken);

            if (grade == null)
            {
                throw new NotFoundException(nameof(Grade), request.CompletedTaskId);
            }

            return mapper.Map<GradeViewModel>(grade);
        }
    }
}
