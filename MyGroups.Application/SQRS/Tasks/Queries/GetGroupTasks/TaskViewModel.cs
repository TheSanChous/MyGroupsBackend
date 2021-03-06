using AutoMapper;
using MyGroups.Application.Common.Mappings;
using MyGroups.Application.SQRS.Groups.Queries.GetGroup;
using MyGroups.Domain.Models.Tasks;
using System;

namespace MyGroups.Application.SQRS.Tasks.Queries.GetGroupTasks
{
    public class TaskViewModel: IMapWith<Task>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public GroupViewModel Group { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task, TaskViewModel>()
                .ForMember(taskViewModel => taskViewModel.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(taskViewModel => taskViewModel.Title,
                    opt => opt.MapFrom(task => task.Title))
                .ForMember(taskViewModel => taskViewModel.Description,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(taskViewModel => taskViewModel.Group,
                        opt => opt.MapFrom(task => task.Group));        }
    }
}