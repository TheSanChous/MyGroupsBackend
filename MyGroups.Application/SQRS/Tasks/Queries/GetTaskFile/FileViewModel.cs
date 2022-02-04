using AutoMapper;
using MyGroups.Application.Common.Mappings;
using MyGroups.Domain.Models.Files;

namespace MyGroups.Application.SQRS.Tasks.Queries.GetTaskFile
{
    public class FileViewModel: IMapWith<File>
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<File, FileViewModel>()
                .ForMember(fileViewModel => fileViewModel.Name,
                    opt => opt.MapFrom(file => file.Name))
                .ForMember(fileViewModel => fileViewModel.Url,
                    opt => opt.MapFrom(file => file.Url));
        }
    }
}