using System.Collections.Generic;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TodoItem/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TodoItem
        [HttpPost]
        public void Post(TodoItem todoItem)
        {
            _context.TodoItem.Add(todoItem);
            _context.SaveChanges();
        }

        // PUT: api/TodoItem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
