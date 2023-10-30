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



        [HttpPost]
        public IActionResult CreateOneThread([FromBody] Models.Thread thread)
        {
            try
            {
                if (thread is null)
                {
                    return BadRequest();
                }

                ApplicationContext.Threads.Add(thread);
                return StatusCode(201, thread);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id:int}")]
        public IActionResult UpdateOneThread([FromRoute(Name = "id")] int id, [FromBody] Models.Thread thread)
        {
            var entity = ApplicationContext.Threads.Find(b => b.Id.Equals(id));
            if (entity is null)
            {
                return NotFound();
            }

            if (id != thread.Id)
            {
                return BadRequest("Given id and the thread id does not match!");
            }

            ApplicationContext.Threads.Remove(entity);

            thread.Id = entity.Id;
            ApplicationContext.Threads.Add(thread);

            return Ok(thread);
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneThread([FromRoute] int id)
        {
            var thread = ApplicationContext.Threads.Find(b => b.Id.Equals(id));
            if (thread is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    message = $"Book with the {id} could not found"
                });
            }

            ApplicationContext.Threads.Remove(thread);

            return StatusCode(201, "Succesfully Removed");
        }




    }
}
