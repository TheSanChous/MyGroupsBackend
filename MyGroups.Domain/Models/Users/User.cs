namespace MyGroups.Domain.Models.Users
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public byte[] Salt { get; set; }
    }
}
