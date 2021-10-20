using System.Threading.Tasks;
using BrightPeeps.Api.Commands.Followings;
using BrightPeeps.Api.Queries.Followings;
using BrightPeeps.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vas.Api.Controllers
{
    [Route("followings")]
    public partial class FollowingsController : Controller
    {
        private readonly IMediator Mediator;

        public FollowingsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet("followers/{followeeId}")]
        public async Task<IActionResult> GetAllFollowers(string followeeId)
        {
            return Ok(await Mediator.Send(new GetAllFollowersByFolloweeId.Request { FolloweeId = followeeId }));
        }

        [HttpGet("followees/{followerId}")]
        public async Task<IActionResult> GetAllFollowees(string followerId)
        {
            return Ok(await Mediator.Send(new GetAllFolloweesByFollowerId.Request { FollowerId = followerId }));
        }

        [HttpPost("newFollowing")]
        public async Task<IActionResult> AddNewFollowing([FromBody] FollowingRequest request)
        {
            return Ok(await Mediator.Send(new AddNewFollowing.Request
            {
                FolloweeId = request.FolloweeId,
                FollowerId = request.FollowerId,
            }));
        }

        [HttpPost("removeFollowing")]
        public async Task<IActionResult> RemoveFollowing([FromBody] FollowingRequest request)
        {
            return Ok(await Mediator.Send(new RemoveFollowing.Request
            {
                FolloweeId = request.FolloweeId,
                FollowerId = request.FollowerId,
            }));
        }
    }
}