using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Groups;
using MyGroups.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.Models.Groups.Commands.JoinGroup
{
    public class JoinGroupCommandValidator : AbstractValidator<JoinGroupCommand>
    {
        public JoinGroupCommandValidator()
        {
            RuleFor(command => command.GroupId)
                .NotNull()
                .NotEmpty();
        }
    }
}
