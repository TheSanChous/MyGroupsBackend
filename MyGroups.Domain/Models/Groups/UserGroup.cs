using MyGroups.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Domain.Models.Groups
{
    public enum UserRolesInGroup
    {
        Member,
        Manager,
        Admin,
    }

    public class UserGroup : ModelBase
    {
        public User User { get; set; }
        public Group Group { get; set; }
        public UserRolesInGroup Role {get; set;}
    }
}
