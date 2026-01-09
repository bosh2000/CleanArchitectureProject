using CleanArchitectureProject.Application.UseCases.CompleteTask;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(int id, [FromServices] CompleteTaskUseCase userCase)
        {
            try
            {
                await userCase.ExecuteAsync(new CompleteTaskCommand { TaskId = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}