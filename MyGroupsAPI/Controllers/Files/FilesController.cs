using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGroupsAPI.Models.Files;
using MyGroupsAPI.Services.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroupsAPI.Controllers.Files
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService fileService;

        public FilesController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFiles()
        {
            var files = await fileService.GetFiles();

            return Ok(files);
        }

        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetFiles([FromRoute] Guid fileId)
        {
            var files = await fileService.GetFile(fileId);

            return Ok(files);
        }

        [HttpPost]
        public async Task<IActionResult> GetFiles(CreateFileModel createFileModel)
        {
            await fileService.CreateFile(createFileModel);

            return Ok();
        }

        [HttpDelete("{fileId}")]
        public async Task<IActionResult> DeleteFile([FromRoute] Guid fileId)
        {
            await fileService.DeleteFile(fileId);

            return Ok();
        }
    }
}
