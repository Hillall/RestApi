using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using todoApp.Models;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace todoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private AppDatabaseContext _ctx;

        public TodoController(AppDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        //GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTask>>> Get()
        {
            return await _ctx.TodoTasks.ToListAsync();
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTask>> Get(int id)
        {
            TodoTask todoItem = await _ctx.TodoTasks.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<TodoTask>> Post([FromBody] TodoTask task)
        {
            _ctx.TodoTasks.Add(task);
            await _ctx.SaveChangesAsync();
            var y = CreatedAtAction(nameof(Get), new { id = task.Id }, task);
            return y;
        }


        // PUT api/values/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id,[FromBody] TodoTask task)
        {

            if (id != task.Id)
            {
                BadRequest();
            }
            _ctx.Entry(task).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TodoTask task)
        {
            if (id != task.Id)
            {
                //BadRequest();
            }
            
            _ctx.Entry(task).State = EntityState.Modified;
            var a = task;
            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todoItem = await _ctx.TodoTasks.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            _ctx.TodoTasks.Remove(todoItem);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
    }
}
