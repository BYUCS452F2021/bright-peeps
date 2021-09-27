using System.Threading.Tasks;
using BrightPeeps.Api.Commands.Persons;
using BrightPeeps.Api.Queries;
using BrightPeeps.Api.Queries.Persons;
using BrightPeeps.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vas.Api.Controllers
{
    [Route("person")]
    public partial class PersonController : Controller
    {
        private readonly IMediator Mediator;

        public PersonController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPersons.Request()));
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            await Task.Delay(10);
            return Ok(new
            {
                Message = $"This should return all persons containing '{query}' in its data."
            });
        }

        [HttpGet("{personId}")]
        public async Task<IActionResult> GetById(string personId)
        {
            await Task.Delay(10);
            return Ok(new
            {
                Message = $"This should return the full person object of {personId}"
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
        public async Task<IActionResult> Insert([FromBody] PersonProfile person)
        {
            return Ok(await Mediator.Send(new InsertPerson.Request()));
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

        [HttpGet("test")]
        public async Task<IActionResult> TestDatabaseConnection()
        {
            return Ok(await Mediator.Send(new TestDatabaseConnection.Request()));
        }
    }
}