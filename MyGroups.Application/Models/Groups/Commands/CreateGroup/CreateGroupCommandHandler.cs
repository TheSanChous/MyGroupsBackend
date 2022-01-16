using MediatR;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using shortid;

namespace MyGroups.Application.Models.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, string>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IAuthorizationService authorizationService;

        public CreateGroupCommandHandler(IDatabaseContext databaseContext, IAuthorizationService authorizationService)
        {
            this.databaseContext = databaseContext;
            this.authorizationService = authorizationService;
        }

        public async Task<string> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var user = authorizationService.CurrentUser;

            var group = new Group
            {
                Title = request.Title,
                Description = request.Description,
                Identifier = ShortId.Generate(true, false, 8),
                CreationDate = DateTime.Now
            };

            var userGroup = new UserGroup
            {
                User = user,
                Group = group,
                Role = UserRolesInGroup.Admin
            };

            await databaseContext.Groups.AddAsync(group, cancellationToken);
            await databaseContext.UsersGroups.AddAsync(userGroup, cancellationToken);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return group.Identifier;
        }
    }
}
