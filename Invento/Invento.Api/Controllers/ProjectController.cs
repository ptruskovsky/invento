using Invento.Api.DI.Services;
using Invento.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;


namespace Invento.Api.Controllers
{
    [ApiController]
    [Route("Project")]
    [InventoAuth]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService) { 
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _projectService.GetAllAsync());
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
