using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateWay.Core.Models;
using PaymentGateWay.Core.Services;

namespace PaymentGateWay.Api.Controllers
{
    [Route("api/Attachment")]
    public class AttachmentController : Controller
    {
        private readonly IUserService _userService;
        public AttachmentController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("UploadBusinessCertification")]
        [Produces(typeof(AttachmentModel))]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken ct = default)
        {
            if (Request.Form?.Files == null || Request.Form.Files.Count == 0)
                return BadRequest();
            var input = Request.Form.Files[0];
            var result = await _userService.UploadBusinessCertificationAsync(_userService.GetUserId(User), input, ct);
            return Ok(result);
        }
    }
}