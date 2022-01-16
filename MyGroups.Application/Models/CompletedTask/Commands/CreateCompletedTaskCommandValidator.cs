using FluentValidation;

namespace MyGroups.Application.Models.CompletedTask.Commands
{
    public class CreateCompletedTaskCommandValidator : AbstractValidator<CreateCompletedTaskCommand>
    {
        public CreateCompletedTaskCommandValidator()
        {
            RuleFor(command => command.Title)
                .NotEmpty()
                .NotNull();
            
            RuleFor(command => command.TaskId)
                .NotEmpty()
                .NotNull();
        }
    }
}