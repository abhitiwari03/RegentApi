using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegentApi.DTO;
using RegentApi.Services.Command;
using RegentApi.Services.Query;
using System.IO;

namespace RegentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IMediator m_mediator;
        public UrlController(IMediator mediator)
        {
            m_mediator = mediator;
        }
        [HttpGet("getUrl")]
        public async Task<ActionResult<bool>> GetUsers(JobProfileVM joburl)
        {
            return await m_mediator.Send(new GetUrlQuery());
        }

        [HttpPost("uploadcoverpicture")]
        public async Task<IActionResult> UploadCoverPicture([FromForm] UploadCoverPictureCommand command)
        {
            try
            {
                var result = await m_mediator.Send(command);
                if (result.UploadStatus == 4)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("crop")]
        public async Task<IActionResult> CropImage([FromBody] CropImageCammond request)
        {
            try
            {
                var result = await m_mediator.Send(request);
                return Ok(new { photoPath = result });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}





   
