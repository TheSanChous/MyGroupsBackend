using AutoMapper;
using MyGroups.Application.Common.Mappings;
using MyGroups.Domain.Models.Groups;
using System;

namespace MyGroups.Application.Models.Groups.Queries.GetGroup
{
    public class GroupViewModel : IMapWith<Group>
    {
        public Guid id { get; set; } 
        public string title { get; set; }
        public string identifier { get; set; }
        public string description { get; set; }
        public DateTime creationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupViewModel>()
                .ForMember(groupView => groupView.id,
                    opt => opt.MapFrom(group => group.Id))
                .ForMember(groupView => groupView.title,
                    opt => opt.MapFrom(group => group.Title))
                .ForMember(groupView => groupView.identifier,
                    opt => opt.MapFrom(group => group.Identifier))
                .ForMember(groupView => groupView.description,
                    opt => opt.MapFrom(group => group.Description))
                .ForMember(groupView => groupView.creationDate,
                    opt => opt.MapFrom(group => group.CreationDate));
        }
    }
} 