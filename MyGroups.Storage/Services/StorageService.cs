using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using MyGroups.Infrastructure.Abstractions;

namespace MyGroups.Storage.Services
{
    public class StorageService : IStorageService
    {
        private readonly BlobContainerClient _blobContainerClient;
        
        public StorageService(IConfiguration configuration)
        {
            _blobContainerClient =
                new BlobContainerClient(configuration.GetConnectionString("StorageConnectionString"), "main");
            _blobContainerClient.CreateIfNotExists();
        }

        public async Task<BlobFileInfo> SaveFileAsync(string fileName, Stream fileStream,
            CancellationToken cancellationToken = default)
        {
            var blobName = $"{Guid.NewGuid().ToString()}_{fileName}";
            
            var blobClient = _blobContainerClient.GetBlobClient(blobName);

            await blobClient.UploadAsync(fileStream, cancellationToken);

            return new BlobFileInfo
            {
                FileName = fileName,
                BlobName = blobName,
                Url = blobClient.Uri.AbsoluteUri
            };
        }

        public async Task DeleteFileAsync(string blobName, CancellationToken cancellationToken = default)
        {
            await _blobContainerClient.DeleteBlobAsync(blobName, cancellationToken: cancellationToken);
        }
    }
}