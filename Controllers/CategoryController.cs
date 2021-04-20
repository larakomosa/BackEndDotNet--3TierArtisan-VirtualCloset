using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualClosetAPI.Biz.Impl;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Models;

namespace ToDoApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _manager;

        public CategoryController(ICategoryManager manager)
        {
            _manager = manager;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<Category>> GetCategory()
        {
            var todoItem = await _manager.Get();

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }


     
    }
}