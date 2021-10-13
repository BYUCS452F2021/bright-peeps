using System.Threading.Tasks;
using BrightPeeps.Api.Commands.Images;
using BrightPeeps.Api.Queries;
using BrightPeeps.Api.Queries.Images;
using BrightPeeps.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vas.Api.Controllers
{
    [Route("image")]
    public partial class ImageController : Controller
    {
        private readonly IMediator Mediator;

        public ImageController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllImages.Request()));
        }

        // TODO: Decide whether users can search through images
        // [HttpGet("search")]
        // public async Task<IActionResult> Search(string query)
        // {
        //     return Ok(await Mediator.Send(new SearchImages.Request { Query = query }));
        // }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await Mediator.Send(new GetImageById.Request { Id = id }));
        }

        [HttpGet("peep/{peepId}")]
        public async Task<IActionResult> GetByPeepId(string peepId)
        {
            return Ok(await Mediator.Send(new GetImageByPeepId.Request { PeepId = peepId }));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ImageData image)
        {
            return Ok(await Mediator.Send(new UpdateImage.Request { Model = image }));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ImageData image)
        {
            return Ok(await Mediator.Send(new InsertImage.Request { Model = image }));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string id)
        {
            return Ok(await Mediator.Send(new DeleteImage.Request { Id = id }));
        }
    }
}