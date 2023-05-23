using Invento.Api.DI.Services;
using Invento.Api.Infrastructure;
using Invento.Api.Models;
using Microsoft.AspNetCore.Mvc;

/*
 TO BE ABLE TO CALL THESE API METHODS
 NOT UNDER PROJECTS-MANAGE-ALL ROLE
 YOU NEED TO BE UNDER PROJECT-.... ROLE
 LIKE FOR TASKS
 */


namespace Invento.Api.Controllers
{
    [ApiController]
    [Route("Project")]
    [InventoAuth]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProjectController(IProjectService projectService, IHttpContextAccessor contextAccessor) { 
            _projectService = projectService;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? skip, int? take)
        {
            // todo: move to helper
            var owner = _contextAccessor.HttpContext?.Items["owner"]?.ToString();
            // GetAll is used insted of Get(id) and can be changed as well
            return Ok(await _projectService.GetAllAsync(skip, take, owner));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectModel model)
        {
            model.Owner = User.Identity!.Name!;
            await _projectService.SaveAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProjectModel model)
        {
            // should we restrict access to allow only owned records to update for the "manage-all" member?
            await _projectService.SaveAsync(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            // todo: move to helper
            var owner = _contextAccessor.HttpContext?.Items["owner"]?.ToString();
            await _projectService.DeleteAsync(id, owner);
            return Ok();
        }
    }
}
