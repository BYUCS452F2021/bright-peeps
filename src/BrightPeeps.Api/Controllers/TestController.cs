using System.Threading.Tasks;
using BrightPeeps.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vas.Api.Controllers
{
    [Route("test")]
    public partial class TestController : Controller
    {
        private readonly IMediator Mediator;

        public TestController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet("database")]
        public async Task<IActionResult> TestDatabaseConnection()
        {
            return Ok(await Mediator.Send(new TestDatabaseConnection.Request()));
        }
    }
}