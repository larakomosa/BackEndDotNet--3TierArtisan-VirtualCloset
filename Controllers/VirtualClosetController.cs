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
using VirtualClosetAPI.Controllers.Contracts;
using VirtualClosetAPI.Controllers.Web;
using VirtualClosetAPI.Biz.Impl;
using Artisan.Service.Core.Web;

namespace VirtualClosetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirtualClosetController : ControllerBase
    {
        private readonly IVirtualClosetManager _manager;
        private readonly IMessageFactory _factory;

        public VirtualClosetController(IVirtualClosetManager manager, IMessageFactory factory)
        {
            _manager = manager;
            _factory = factory;

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

        [HttpGet("search")]
        public async Task<SearchResponse<VirtualClosetResponse>> SearchTodoList([FromQuery] long id, [FromQuery] string name, [FromQuery] string category, [FromQuery] bool? favorite)

        {
            var info = new SearchVirtualClosetItemInfo(id, name, category, favorite);

            var results = await _manager.Search(info);

            var responses = await _factory.Create<VirtualCloset, VirtualClosetResponse>(results.Data);

            return new SearchResponse<VirtualClosetResponse>(responses, results.TotalCount);
        }


    }
}