using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Infrastructure.Abstractions
{
    public class BlobFileInfo
    {
        public string FileName { get; set; }
        public string BlobName { get; set; }
        public string Url { get; set; }
    }

    public interface IStorageService
    {
        public Task<BlobFileInfo> SaveFileAsync(string fileName, Stream fileStream, CancellationToken cancellationToken);
        public Task DeleteFileAsync(string blobName, CancellationToken cancellationToken);
    }
}