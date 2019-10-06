using System.Collections.Generic;
using System.Linq;
using DB;
using DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly MyContext _context;
        public TodoItemController(MyContext context)
        {
            _context = context;
        }

        // GET: api/TodoItem
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _context.TodoItem.ToList();
        }

        // GET: api/TodoItem/5
        [HttpGet("{id}", Name = "Get")]
        public TodoItem Get(int id)
        {
            return _context.TodoItem.FirstOrDefault(m => m.Id == id);
        }

        // POST: api/TodoItem
        [HttpPost]
        public void Post(TodoItem todoItem)
        {
            _context.TodoItem.Add(todoItem);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            _context.TodoItem.Update(todoItem);
            _context.SaveChanges();
            return Ok("ok");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TodoItem todoItem = _context.TodoItem.Find(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            _context.TodoItem.Remove(todoItem);
            _context.SaveChanges();
            return Ok("ok");
        }
    }
}
