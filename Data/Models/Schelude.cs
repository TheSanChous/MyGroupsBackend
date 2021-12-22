using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Schelude : ModelBase
    {
        public Group Group { get; set; }
        public Guid GroupId { get; set; }
        public ICollection<ScheludeItem> Items { get; set; }
    }
}
