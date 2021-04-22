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

        // GET: api/Category
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

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetClosetItem(long id)
        {
            var categoryItem = await _manager.Get(new long[] { id });

            if (categoryItem == null)
            {
                return NotFound();
            }

            return Ok(categoryItem);
        }

        [HttpPost]
        public async Task<ActionResult> PostClosetItem([FromBody] CreateCategoryItemMessage request)
        {

            var info = new CreateCategoryItemInfo(request.Name);

            await _manager.Create(info);

            return new OkObjectResult(info);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClosetItem([FromRoute] long id, [FromBody] UpdateCategoryItemMessage request)
        {
            var info = new UpdateCategoryItemInfo(request.Name);

            await _manager.Update(id, info);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] long id)
        {
            await _manager.Delete(id);

            //    return new OkResult();
            //}
            return new OkResult();
        }


    }
}