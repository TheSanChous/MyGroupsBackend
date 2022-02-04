using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(createUserCommand => createUserCommand.Title)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(createUserCommand => createUserCommand.Deadline)
                .GreaterThan(DateTime.Now.ToUniversalTime())
                .NotEmpty()
                .NotNull();
            
            RuleFor(createUserCommand => createUserCommand.GroupId)
                .NotEmpty();
        }
    }
}
