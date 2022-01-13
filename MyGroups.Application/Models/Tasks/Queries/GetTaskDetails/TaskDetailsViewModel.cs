using System;
using AutoMapper;
using MyGroups.Application.Common.Mappings;
using MyGroups.Application.Models.Tasks.Queries.GetGroupTasks;
using MyGroups.Domain.Models.Tasks;

namespace MyGroups.Application.Models.Tasks.Queries.GetTaskDetails
{
    public class TaskDetailsViewModel : IMapWith<Task>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime PublishedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task, TaskDetailsViewModel>()
                .ForMember(taskViewModel => taskViewModel.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(taskViewModel => taskViewModel.Title,
                    opt => opt.MapFrom(task => task.Title))
                .ForMember(taskViewModel => taskViewModel.Description,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(taskViewModel => taskViewModel.Deadline,
                opt => opt.MapFrom(task => task.Deadline))
                .ForMember(taskViewModel => taskViewModel.PublishedAt,
                    opt => opt.MapFrom(task => task.PublishedAt));
        }
    }
}