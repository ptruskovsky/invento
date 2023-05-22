using Invento.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;


namespace Invento.Api.Controllers
{
    [ApiController]
    [Route("Project")]
    [InventoAuth]
    public class ProjectController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Project");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
