using System.Threading.Tasks;
using BrightPeeps.Api.Commands.Peeps;
using BrightPeeps.Api.Queries;
using BrightPeeps.Api.Queries.Peeps;
using BrightPeeps.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vas.Api.Controllers
{
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
            var result = await Mediator.Send(new GetAllPeeps.Request());
            if (result.Successful)
            {
                return Ok(result);
            }
            else
            {
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

        // From Rogerio: Commenting this out because we can use the search feature to find peeps by name

        // [HttpGet("{Name}")]
        // public async Task<IActionResult> GetPeepById(string Name)
        // {
        //     await Task.Delay(10);
        //     return Ok(new
        //     {
        //         Message = $"This should return the full peep object of {Name}"
        //     });
        // }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPeepById(string Id)
        {
            return Ok(await Mediator.Send(new GetPeepById.Request { Id = Id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonData person)
        {
            return Ok(await Mediator.Send(UpdatePeep.Request.FromPersonData(person)));
        }

        [HttpPost]
        public async Task<IActionResult> InsertNewPeep([FromBody] PersonData person)
        {
            return Ok(await Mediator.Send(InsertPeep.Request.FromPersonData(person)));
        }

        [HttpDelete("{personId}")]
        public async Task<IActionResult> Delete(string personId)
        {
            return Ok(await Mediator.Send(new RemovePeepById.Request { Id = int.Parse(personId) }));
        }
    }
}