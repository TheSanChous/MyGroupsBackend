namespace Data.Models
{
    public class File : ModelBase
    {
        public byte[] Data { get; set; }
        public string Type { get; set; }
        public User Owner { get; set; }
    }
}