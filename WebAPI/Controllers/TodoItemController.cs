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

        /// <summary>
        /// TodoItem获取所有
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IEnumerable<TodoItem> Get()
        {
            return _context.TodoItem.ToList();
        }

        /// <summary>
        /// TodoItem根据Id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public TodoItem Get(int id)
        {
            return _context.TodoItem.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// TodoItem更新
        /// </summary>
        /// <param name="todoItem"></param>
        [HttpPost]
        public void Post(TodoItem todoItem)
        {
            _context.TodoItem.Add(todoItem);
            _context.SaveChanges();
        }

        /// <summary>
        /// TodoItem根据Id修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todoItem"></param>
        /// <returns></returns>
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

        /// <summary>
        /// TodoItem根据ID删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
