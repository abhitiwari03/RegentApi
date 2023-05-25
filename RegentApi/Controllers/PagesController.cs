using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegentApi.DTO;
using RegentApi.Services.Command;
using RegentApi.Services.Query;

namespace RegentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly IMediator m_mediator;

        public PagesController(IMediator mediator)
        {
            m_mediator = mediator;
        }
        [HttpPost("v2/users/{user_id}/comments/{comment_id}/note")]
        public async Task<ActionResult<JobProfileVM[]>> GetUsers(
            [FromRoute(Name = "user_id")] int userId, 
            [FromRoute(Name = "comment_id")] long commentId,
            [FromBody] JobProfileVM payload)
        {
            return await m_mediator.Send(new JobProfileQuery()
            {
                CommentId = commentId,
                UserId = userId,
                Model = payload
            });
        }
    }
}
