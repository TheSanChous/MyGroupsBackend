using Data;
using Data.Models;
using MyGroupsAPI.Exceptions;
using MyGroupsAPI.Models.Files;
using MyGroupsAPI.Services.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroupsAPI.Services.Files
{
    public class FileService : IFileService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IAuthorizationService authorizationService;

        public FileService(DatabaseContext databaseContext,
            IAuthorizationService authorizationService)
        {
            this.databaseContext = databaseContext;
            this.authorizationService = authorizationService;
        }

        public async System.Threading.Tasks.Task CreateFile(CreateFileModel createFileModel)
        {
            User user = authorizationService.CurrentUser;

            File file = new File
            {
                Data = createFileModel.Data,
                Type = createFileModel.Type,
                Owner = user
            };

            await databaseContext.Files.AddAsync(file);
            await databaseContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteFile(Guid fileId)
        {
            var file = await GetFile(fileId);

            databaseContext.Files.Remove(file);

            await databaseContext.SaveChangesAsync();
        }

        public async Task<File> GetFile(Guid fileId)
        {
            User user = authorizationService.CurrentUser;

            var file = databaseContext.Files
                .Where(file => file.Owner == user)
                .SingleOrDefault(file => file.Id == fileId);

            if (file is null)
            {
                throw new ServiceException("File not found");
            }

            return file;
        }

        public async Task<IEnumerable<File>> GetFiles()
        {
            User user = authorizationService.CurrentUser;

            var files = databaseContext.Files
                .Where(file => file.Owner == user);

            return files;
        }
    }
}
