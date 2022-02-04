using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Groups.Commands.LeaveGroup
{
    public class LeaveGroupCommandValidator : AbstractValidator<LeaveGroupCommand>
    {
        public LeaveGroupCommandValidator()
        {
            RuleFor(command => command.GroupId)
                .NotEmpty()
                .NotNull();
        }
    }
}
