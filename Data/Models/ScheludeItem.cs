using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ScheludeItem : ModelBase
    {
        public Schelude Schelude { get; set; }
        public DateTime DateTime { get; set; }
        public string Titile { get; set; }
        public string Description { get; set; }
    }
}
