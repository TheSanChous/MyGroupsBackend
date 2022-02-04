using MediatR;
using MyGroups.Application.SQRS.Groups.Queries.GetGroup;

namespace MyGroups.Application.SQRS.Groups.Queries.GetGroupByIdentifier
{
    public class GetGroupByIdentifierQuery : IRequest<GroupViewModel>
    {
        public string GroupIdentifier { get; set; }
    }
}