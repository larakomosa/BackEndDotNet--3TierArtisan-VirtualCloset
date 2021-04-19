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

        // GET: api/VirtualCloset/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VirtualCloset>> GetClosetItem(long id)
        {
            var closetItem = await _manager.Get(new long[] { id });

            if (closetItem == null)
            {
                return NotFound();
            }

            return Ok(closetItem);
        }

        // GET: api/VirtualCloset
        [HttpGet]
        public async Task<ActionResult<VirtualCloset>> GetClosetItems()
        {
            var closetItems = await _manager.Get();

            if (closetItems == null)
            {
                return NotFound();
            }

            return Ok(closetItems);
        }
    }
}