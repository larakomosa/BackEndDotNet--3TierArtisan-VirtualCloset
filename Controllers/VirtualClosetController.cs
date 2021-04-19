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
using VirtualClosetAPI.Common;
using VirtualClosetAPI.Biz.Models;

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

        [HttpPost]
        public async Task<ActionResult> PostClosetItem([FromBody] CreateVirtualClosetItemMessage request)
        {

            var info = new CreateVirtualClosetItemInfo(request.Name, request.Category, request.Favorite);

            await _manager.Create(info);

            return new OkObjectResult(info);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClosetItem([FromRoute] long id, [FromBody] UpdateVirtualClosetItemMessage request)
        {
            var info = new UpdateVirtualClosetItemInfo(request.Name, request.Category, request.Favorite);

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