using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class UserGroup : ModelBase
    {
        public User User { get; set; }
        public Group Group { get; set; }
        public RoleUserInGroup RoleInGroup { get; set; }
    }
}
