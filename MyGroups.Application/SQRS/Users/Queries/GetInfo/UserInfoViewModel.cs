using AutoMapper;
using MyGroups.Application.Common.Mappings;
using MyGroups.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Users.Queries.GetInfo
{
    public class UserInfoViewModel : IMapWith<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserInfoViewModel>()
                .ForMember(viewModel => viewModel.Name,
                    opt => opt.MapFrom(user => user.Name))
                .ForMember(viewModel => viewModel.Surname,
                    opt => opt.MapFrom(user => user.Surname))
                .ForMember(viewModel => viewModel.Email,
                    opt => opt.MapFrom(user => user.Email));
        }

    }
}
