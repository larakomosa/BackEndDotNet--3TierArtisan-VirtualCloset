using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualClosetAPI.Models;

namespace VirtualClosetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirtualClosetController : ControllerBase
    {
        private readonly IVirtualClosetManager _manager;

        public VirtualClosetController(IVirtualClosetManager manager)
        {
            _manager = manager;
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VirtualCloset>> GetTodoItem(long id)
        {
            var todoItem = await _manager.Get(new long[] { id });

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }
    }
}