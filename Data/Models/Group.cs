using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Group : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Schelude Schelude { get; set; }
        public ICollection<UserGroup> Users { get; set; }
        public ICollection<Publication> Publications { get; set; }
    }
}
