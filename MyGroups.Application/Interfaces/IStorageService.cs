using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.Interfaces
{
    public class FileInfo
    {
        public string FileName { get; set; }
        public string BlobName { get; set; }
        public string Url { get; set; }
    }
    public interface IStorageService
    {
        public Task<FileInfo> SaveFileAsync(string fileName, Stream fileStream, CancellationToken cancellationToken);
        public Task DeleteFileAsync(string blobName, CancellationToken cancellationToken);
    }
}