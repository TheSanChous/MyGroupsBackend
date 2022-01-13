using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyGroups.Application.Interfaces;
using Azure.Storage;
using Azure.Storage.Blobs;
using FileInfo = MyGroups.Application.Interfaces.FileInfo;

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

        public async Task<FileInfo> SaveFileAsync(string fileName, Stream fileStream,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var blobName = $"{Guid.NewGuid().ToString()}_{fileName}";
            
            var blobClient = _blobContainerClient.GetBlobClient(blobName);

            await blobClient.UploadAsync(fileStream, cancellationToken);

            return new FileInfo
            {
                FileName = fileName,
                BlobName = blobName,
                Url = blobClient.Uri.AbsoluteUri
            };
        }

        public async Task DeleteFileAsync(string blobName, CancellationToken cancellationToken)
        {
            await _blobContainerClient.DeleteBlobAsync(blobName, cancellationToken: cancellationToken);
        }
    }
}