using MyGroups.Domain.Models.Users;

namespace MyGroups.Domain.Models.Grades
{
    public class Grade : ModelBase
    {
        public int Value { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public User Evaluator { get; set; }
    }
}