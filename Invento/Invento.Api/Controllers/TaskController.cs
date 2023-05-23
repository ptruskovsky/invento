using Invento.Api.DI.Services;
using Invento.Api.Infrastructure;
using Invento.Api.Models;
using Microsoft.AspNetCore.Mvc;


namespace Invento.Api.Controllers
{
    [ApiController]
    [Route("Task")]
    [InventoAuth]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IHttpContextAccessor _contextAccessor;

        public TaskController(ITaskService taskService, IHttpContextAccessor contextAccessor) {
            _taskService = taskService;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? skip, int? take) {
            // todo: move to helper
            var owner = _contextAccessor.HttpContext?.Items["owner"]?.ToString();
            // GetAll is used insted of Get(id) and can be changed as well
            return Ok(await _taskService.GetAllAsync(skip, take, owner));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskModel model) {
            model.Owner = User.Identity!.Name!;
            await _taskService.SaveAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TaskModel model) {
            // should we restrict access to allow only owned records to update for the "manage-all" member?
            await _taskService.SaveAsync(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id) {
            // todo: move to helper
            var owner = _contextAccessor.HttpContext?.Items["owner"]?.ToString();
            await _taskService.DeleteAsync(id, owner);
            return Ok();
        }
    }
}
