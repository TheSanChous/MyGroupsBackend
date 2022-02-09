using AutoMapper;
using MyGroups.Application.Common.Mappings;
using MyGroups.Application.SQRS.Users.Queries.GetInfo;
using MyGroups.Domain.Models.Grades;
using MyGroups.Domain.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.CompletedTasks.Queries.GetComplatedFor
{
    public class CompletedTaskViewModel : IMapWith<CompletedTask>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UploadedAt { get; set; }
        public UserInfoViewModel Creator { get; set; }
        public Guid? TaskId { get; set; }
        public Grade Grade { get; set; }
        public string? FileUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CompletedTask, CompletedTaskViewModel>()
                .ForMember(vm => vm.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(vm => vm.Title,
                    opt => opt.MapFrom(task => task.Title))
                .ForMember(vm => vm.Description,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(vm => vm.UploadedAt,
                    opt => opt.MapFrom(task => task.UploadedAt))
                .ForMember(vm => vm.Title,
                    opt => opt.MapFrom(task => task.Title))
                .ForMember(vm => vm.Grade,
                    opt => opt.MapFrom(task => (task.Grade != null) ? task.Grade : null))
                .ForMember(vm => vm.FileUrl,
                    opt => opt.MapFrom(task => (task.File != null) ? task.File.Url : ""))
                .ForMember(vm => vm.Creator,
                    opt => opt.MapFrom(task => task.Creator))
                .ForAllMembers(opt => opt.AllowNull());
        }
    }
}
