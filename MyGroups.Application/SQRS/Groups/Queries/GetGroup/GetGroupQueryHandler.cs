using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Groups;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Groups.Queries.GetGroup
{
    public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, GroupViewModel>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper mapper;

        public GetGroupQueryHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IMapper mapper)
        {
            this.databaseContext = databaseContext;
            _authorizationService = authorizationService;
            this.mapper = mapper;
        }

        public async Task<GroupViewModel> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            var user = _authorizationService.CurrentUser;
            
            var group = await databaseContext.UsersGroups
                .Include(userGroup => userGroup.Group)
                .Include(userGroup => userGroup.User)
                .Where(userGroup => userGroup.User == user)
                .Select(userGroup => userGroup.Group)
                .SingleOrDefaultAsync(group => group.Id == request.Id, cancellationToken);
            
            if(group is null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }

            return mapper.Map<GroupViewModel>(group);
        }
    }
}
