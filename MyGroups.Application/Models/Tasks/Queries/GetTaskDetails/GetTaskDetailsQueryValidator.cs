using FluentValidation;

namespace MyGroups.Application.Models.Tasks.Queries.GetTaskDetails
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