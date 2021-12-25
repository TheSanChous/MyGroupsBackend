using AutoMapper;
using MyGroups.Application.Common.Mappings;
using MyGroups.Domain.Models.Groups;
using System;

namespace MyGroups.Application.Models.Groups.Queries.GetGroup
{
    public class GroupViewModel : IMapWith<Group>
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupViewModel>()
                .ForMember(groupView => groupView.Id,
                    opt => opt.MapFrom(group => group.Id))
                .ForMember(groupView => groupView.Title,
                    opt => opt.MapFrom(group => group.Title))
                .ForMember(groupView => groupView.Description,
                    opt => opt.MapFrom(group => group.Description))
                .ForMember(groupView => groupView.CreationDate,
                    opt => opt.MapFrom(group => group.CreationDate));
        }
    }
} 