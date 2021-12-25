using AutoMapper;
using MyGroups.Application.Common.Mappings;
using MyGroups.Domain.Models.Groups;
using System;

namespace MyGroups.Application.Models.Groups.Queries.GetGroupList
{
    public class GroupViewModel : IMapWith<Group>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupViewModel>()
                .ForMember(groupView => groupView.Id,
                    opt => opt.MapFrom(group => group.Id))
                .ForMember(groupView => groupView.Title,
                    opt => opt.MapFrom(group => group.Title));
        }
    }
}