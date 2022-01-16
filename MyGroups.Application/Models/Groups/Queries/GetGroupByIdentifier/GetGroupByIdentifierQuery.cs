using MediatR;
using MyGroups.Application.Models.Groups.Queries.GetGroup;

namespace MyGroups.Application.Models.Groups.Queries.GetGroupByIdentifier
{
    public class GetGroupByIdentifierQuery : IRequest<GroupViewModel>
    {
        public string GroupIdentifier { get; set; }
    }
}