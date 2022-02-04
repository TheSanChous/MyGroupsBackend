using FluentValidation;

namespace MyGroups.Application.SQRS.Tasks.Queries.GetGroupTasks
{
    public class GetGroupTasksQueryValidator : AbstractValidator<GetGroupTasksQuery>
    {
        public GetGroupTasksQueryValidator()
        {
            RuleFor(query => query.GroupId)
                .NotNull()
                .NotEmpty();
        }
    }
}