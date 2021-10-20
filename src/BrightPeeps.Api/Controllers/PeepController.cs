using System.Threading.Tasks;
using BrightPeeps.Api.Commands.Peeps;
using BrightPeeps.Api.Queries;
using BrightPeeps.Api.Queries.Peeps;
using BrightPeeps.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vas.Api.Controllers
{
    /*
    TODO: verify I did this right
    */
    [Route("peep")]
    public partial class PeepController : Controller
    {
        private readonly IMediator Mediator;

        public PeepController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeeps()
        {
            var result = await Mediator.Send(new GetAllPeeps.Request()));
            if (result.Successful) {
                return Ok(result);
            } else {
                return NotFound(result);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            await Task.Delay(10);
            return Ok(new
            {
                Message = $"This should return all peeps containing '{query}' in its data."
            });
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetPeepById(string Name)
        {
            await Task.Delay(10);
            return Ok(new
            {
                Message = $"This should return the full peep object of {Name}"
            });
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPeepById(string Id)
        {
            await Task.Delay(10);
            return Ok(new
            {
                Message = $"This should return the full peep object of {Id}"
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonProfile person)
        {
            await Task.Delay(10);
            return Ok(new
            {
                Message = $"This should return the status of the update request for person named {person.FullName}."
            });
        }

        [HttpPost]
        public async Task<IActionResult> InsertPeep([FromBody] PersonProfile person)
        {
            return Ok(await Mediator.Send(new AddPerson.Request()));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string personId)
        {
            await Task.Delay(10);
            return Ok(new
            {
                Message = $"This should return the status of the delete request for person with id {personId}."
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] DeletePeepRequest request) 
        {
            return Ok(await Mediator.Send(new RemovePeepById.Request { Id = request.Id}));
        }
    }
}