using MyGroups.Domain.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Domain.Models.Grades
{
    public class GradesTasks
    {
        public Guid Id { get; set; }
        public Grade Grade { get; set; }
        public CompletedTask ComletedTask { get; set; }
    }
}
