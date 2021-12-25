using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.Models.Groups.Queries.GetGroupList
{
    public class GetGroupsListQueryHandler : IRequestHandler<GetGroupListQuery, GroupListViewModel>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IMapper mapper;

        public GetGroupsListQueryHandler(IDatabaseContext databaseContext,
            IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;
        }

        public async Task<GroupListViewModel> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
        {
            var groupsQuery = await databaseContext.Groups
                .ProjectTo<GroupViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new GroupListViewModel
            {
                Groups = groupsQuery
            };
        }
    }
}
