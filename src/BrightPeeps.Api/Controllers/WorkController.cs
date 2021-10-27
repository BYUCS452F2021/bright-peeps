using System.Threading.Tasks;
using BrightPeeps.Api.Commands.Works;
using BrightPeeps.Api.Queries.Works;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrightPeeps.Api.Controllers 
{
    [Route("work")]
    public partial class WorkController: Controller
    {
        private readonly IMediator Mediator;

        public WorkController(IMediator mediator)
        {
            Mediator = mediator;
        }

        //GET -

        [HttpGet]
        public async Task<IActionResult> GetAllWorks()
        {
            return Ok(await Mediator.Send(new GetAllWorks.Request()));

/*
            if (result.Successful) {
                return Ok(result);
            } else {
                return NotFound(result);
            }
            */
        }

        [HttpGet("/work/type/{type}")]
        public async Task<IActionResult> GetWorksByType(string type)
        {
            var result = await Mediator.Send(new GetWorksByType.Request(type));

            if (result.Successful) {
                return Ok(result);
            } else {
                return NotFound(result);
            }
        }

        [HttpGet("/work/id/{id}")]
        public async Task<IActionResult> GetWorkById(int id) {
            var result = await Mediator.Send(new GetWorkById.Request(id));

            if (result.Successful) {
                return Ok(result);
            } else {
                return NotFound(result);
            }
        }

        [HttpGet("/work/peepId/{peepId}")]
        public async Task<IActionResult> GetWorksByPeepId(int peepId) {
            var result = await Mediator.Send(new GetWorksByPeepId.Request(peepId));

            if (result.Successful) {
                return Ok(result);
            } else {
                return NotFound(result);
            }
        }

        //POST -

        [HttpPost]
        public async Task<IActionResult> InsertWork(int peepId, string workType, string workDesc, string workUrl, string workTitle) {
            var result = await Mediator.Send(new InsertWork.Request(peepId, workType, workDesc, workUrl, workTitle));

            if (result.Successful) {
                return Ok(result);
            } else {
                return NotFound(result);
            }
        }

        //PUT -

        [HttpPut]
        public async Task<IActionResult> UpdateWork(int id, int peepId, string workType, string workDesc, string workUrl, string workTitle) {
            var result = await Mediator.Send(new UpdateWork.Request(id, peepId, workType, workDesc, workUrl, workTitle));

            if (result.Successful) {
                return Ok(result);
            } else {
                return NotFound(result);
            }
        }

        //DELETE - RemoveWork(int id)

        [HttpDelete("/work/id/{id}")]
        public async Task<IActionResult> RemoveWorkById(int id) {
            var result = await Mediator.Send(new RemoveWorkById.Request(id));

            if (result.Successful) {
                return Ok(result);
            } else {
                return NotFound(result);
            }
        }

        [HttpDelete("/work/peepId/{peepId}")]
        public async Task<IActionResult> RemoveWorkByPeepId(int peepId) {
            var result = await Mediator.Send(new RemoveWorksByPeepId.Request(peepId));

            if (result.Successful) {
                return Ok(result);
            } else {
                return NotFound(result);
            }
        }

        [HttpDelete("/work/type/{type}")]
        public async Task<IActionResult> RemoveWorkByType(string type) {
            var result = await Mediator.Send(new RemoveWorksByType.Request(type));

            if (result.Successful) {
                return Ok(result);
            } else {
                return NotFound(result);
            }
        }
    }


}