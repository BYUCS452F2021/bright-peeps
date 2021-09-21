using System.Threading.Tasks;
using BrightPeeps.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Vas.Api.Controllers
{
    [Route("person")]
    public partial class PersonController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.Delay(10);
            return Ok(new
            {
                Message = "This should return all persons."
            });
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
        public async Task<IActionResult> Update([FromBody] Person person)
        {
            await Task.Delay(10);
            return Ok(new
            {
                Message = $"This should return the status of the update request for person named {person.FullName}."
            });
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Person person)
        {
            await Task.Delay(10);
            return Ok(new
            {
                Message = $"This should return the status of the insert request for person named {person.FullName}."
            });
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
    }
}