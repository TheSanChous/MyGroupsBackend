namespace MyGroups.Domain.Models.Files
{
    public class File : ModelBase
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string BlobName { get; set; }
    }
}