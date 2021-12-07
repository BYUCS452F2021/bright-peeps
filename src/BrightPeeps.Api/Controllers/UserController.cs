using System.Threading.Tasks;
using BrightPeeps.Api.Commands.Users;
using BrightPeeps.Api.Queries.Users;
using BrightPeeps.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrightPeeps.Api.Controllers
{
    [Route("user")]
    public partial class UserController: Controller
    {
        private readonly IMediator Mediator;

        public UserController(IMediator mediator) {
            Mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateUserRequest request) {
            if (request.PeepID == null || request.PeepID == "") {
                return Ok(await Mediator.Send(InsertUserWithoutPeepID.Request.FromUserData(request)));
            } else {
                return Ok(await Mediator.Send(InsertUserWithPeepID.Request.FromUserData(request)));
            }
        }

        [HttpGet("peepId/{peepId}")]
        public async Task<IActionResult> GetUserByPeepId(string peepId) {
            return Ok(await Mediator.Send(new GetUserByPeepId.Request {PeepID = peepId}));
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username) {
            return Ok(await Mediator.Send(new GetUserByUsername.Request {Username = username}));
        }

        [HttpPut("password")]
        public async Task<IActionResult> ChangePassword([FromBody] UpdatePasswordData data) {
            return Ok(await Mediator.Send(new UpdatePassword.Request{Model = data}));
        }

        [HttpPut("peepId")]
        public async Task<IActionResult> ChangePeepID([FromBody] UpdateUserPeepIdData data) {
            return Ok(await Mediator.Send(new UpdatePeepId.Request{Model = data}));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request) {
            return Ok(await Mediator.Send(new RemoveUserByUsername.Request { Username = request.Username}));
        }
    }
    
}