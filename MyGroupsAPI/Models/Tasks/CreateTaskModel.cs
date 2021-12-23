using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroupsAPI.Models.Tasks
{
    public class CreateTaskModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid GroupId { get; set; } 
        public Guid FileId { get; set; }
    }
}
