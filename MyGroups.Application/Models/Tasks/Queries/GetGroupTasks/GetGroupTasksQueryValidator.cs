using FluentValidation;

namespace MyGroups.Application.Models.Tasks.Queries.GetGroupTasks
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