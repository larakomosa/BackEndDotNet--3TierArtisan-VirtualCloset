using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Models;

namespace ToDoApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly VirtualClosetContext _context;

        public CategoryController(VirtualClosetContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetTodoItems()
        {
            return await _context.Categories.ToListAsync();
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTodoItems), new { id = category.Id
    }, category);
}



     
    }
}