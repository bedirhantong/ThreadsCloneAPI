using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreadsCloneAPI.Data;

namespace ThreadsCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllThreads()
        {
            var threads = ApplicationContext.Threads;
            return Ok(threads);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetOneThread([FromRoute(Name = "id")] int id)
        {
            var thread = ApplicationContext.Threads.Where(b
                => b.Id == id).FirstOrDefault();
            if (thread is null)
            {
                return NotFound();
            }
            return Ok(thread);
        }
    }
}
