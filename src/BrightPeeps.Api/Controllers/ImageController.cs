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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await Mediator.Send(new GetImageById.Request { Id = id }));
        }

        [HttpGet("peep/{peepId}")]
        public async Task<IActionResult> GetByPeepId(string peepId)
        {
            return Ok(await Mediator.Send(new GetImagesByPeepId.Request { PeepId = peepId }));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ImageData image)
        {
            return Ok(await Mediator.Send(new UpdateImage.Request { Model = image }));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ImageData image)
        {
            return Ok(await Mediator.Send(InsertImage.Request.FromImageData(image)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await Mediator.Send(new RemoveImageById.Request { Id = int.Parse(id) }));
        }

        [HttpDelete("peep/{peepId}")]
        public async Task<IActionResult> DeleteImagesByPeepId(string peepId)
        {
            return Ok(await Mediator.Send(new RemoveImagesByPeepId.Request { PeepId = peepId }));
        }
    }
}