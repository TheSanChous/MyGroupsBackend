using FluentValidation;

namespace MyGroups.Application.SQRS.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryValidator : AbstractValidator<GetTaskDetailsQuery>
    {
        public GetTaskDetailsQueryValidator()
        {
            RuleFor(query => query.TaskId)
                .NotEmpty()
                .NotNull();
        }
    }
}