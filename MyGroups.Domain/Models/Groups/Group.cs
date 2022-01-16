using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Domain.Models.Groups
{
    public class Group : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
