using AzuriteWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace AzuriteWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlobController : ControllerBase
    {
        private readonly BlobService _blobService;

        public BlobController(BlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadBlob([FromQuery] string containerName, [FromQuery] string blobName, IFormFile file)
        {
            using var stream = file.OpenReadStream();
            await _blobService.UploadBlobAsync(containerName, blobName, stream);
            return Ok();
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadBlob([FromQuery] string containerName, [FromQuery] string blobName)
        {
            var stream = await _blobService.GetBlobAsync(containerName, blobName);
            return File(stream, "application/octet-stream");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBlob([FromQuery] string containerName, [FromQuery] string blobName)
        {
            await _blobService.DeleteBlobAsync(containerName, blobName);
            return NoContent();
        }
    }
}
