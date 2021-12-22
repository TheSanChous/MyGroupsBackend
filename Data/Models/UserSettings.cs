using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class UserSettings : ModelBase
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
