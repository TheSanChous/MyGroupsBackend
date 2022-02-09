using MyGroups.Domain.Models.Tasks;
using MyGroups.Domain.Models.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGroups.Domain.Models.Grades
{
    public class Grade : ModelBase
    {
        [ForeignKey("CompletedTask")]
        public new Guid Id { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public User Evaluator { get; set; }
        public CompletedTask CompletedTask { get; set; }
    }
}