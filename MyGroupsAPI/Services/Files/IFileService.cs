using Data.Models;
using MyGroupsAPI.Models.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroupsAPI.Services.Files
{
    public interface IFileService
    {
        public Task<File> GetFile(Guid fileId);
        public System.Threading.Tasks.Task CreateFile(CreateFileModel createFileModel);
        public System.Threading.Tasks.Task DeleteFile(Guid fileId);
        public Task<IEnumerable<File>> GetFiles();
    }
}
