using Application.Activities.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetHello()
        {
            return Ok("Hello, World!");
        }

        [HttpGet("/activities")]
        public async Task<IActionResult> GetActivities()
        {
            var result = await _mediator.Send(new GetActivityList.Query());

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
    }
}
