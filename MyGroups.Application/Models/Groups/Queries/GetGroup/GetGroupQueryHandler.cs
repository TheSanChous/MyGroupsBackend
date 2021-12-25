using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.Models.Groups.Queries.GetGroup
{
    public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, GroupViewModel>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IMapper mapper;

        public GetGroupQueryHandler(IDatabaseContext databaseContext,
            IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;
        }

        public async Task<GroupViewModel> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            var group = await databaseContext.Groups
                .FirstOrDefaultAsync(group => group.Id == request.Id, cancellationToken);

            if(group is null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }

            return mapper.Map<GroupViewModel>(group);
        }
    }
}
