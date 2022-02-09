using FluentValidation;

namespace MyGroups.Application.SQRS.CompletedTasks.Commands.CreateComplatedTask
{
    public class CreateCompletedTaskCommandValidator : AbstractValidator<CreateCompletedTaskCommand>
    {
        public CreateCompletedTaskCommandValidator()
        {            
            RuleFor(command => command.TaskId)
                .NotEmpty()
                .NotNull();
        }
    }
}