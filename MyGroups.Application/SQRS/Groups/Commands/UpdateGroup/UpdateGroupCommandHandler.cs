using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Domain.Models.Groups;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand>
    {
        private readonly IDatabaseContext databaseContext;

        public UpdateGroupCommandHandler(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await databaseContext.Groups
                .FirstOrDefaultAsync(group => group.Id == request.Id, cancellationToken);

            if (group is null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }
             
            group.Title = request.Title;
            group.Description = request.Description;

            await databaseContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
