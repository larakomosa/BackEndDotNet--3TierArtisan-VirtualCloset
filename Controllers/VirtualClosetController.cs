using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly VirtualClosetContext _context;

        public VirtualClosetController(VirtualClosetContext context)
        {
            _context = context;
        }

        // GET: api/VirtualCloset
        [HttpGet]
        public IEnumerable<VirtualCloset> GetVirtualClosetItems()
        {
            return _context.VirtualClosetItems;
        }

        // GET: api/VirtualCloset/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVirtualCloset([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var virtualCloset = await _context.VirtualClosetItems.FindAsync(id);

            if (virtualCloset == null)
            {
                return NotFound();
            }

            return Ok(virtualCloset);
        }

        // PUT: api/VirtualCloset/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVirtualCloset([FromRoute] long id, [FromBody] VirtualCloset virtualCloset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != virtualCloset.Id)
            {
                return BadRequest();
            }

            _context.Entry(virtualCloset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VirtualClosetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VirtualCloset
        [HttpPost]
        public async Task<IActionResult> PostVirtualCloset([FromBody] VirtualCloset virtualCloset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VirtualClosetItems.Add(virtualCloset);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVirtualCloset), new { id = virtualCloset.Id }, virtualCloset);
        }

        // DELETE: api/VirtualCloset/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVirtualCloset([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var virtualCloset = await _context.VirtualClosetItems.FindAsync(id);
            if (virtualCloset == null)
            {
                return NotFound();
            }

            _context.VirtualClosetItems.Remove(virtualCloset);
            await _context.SaveChangesAsync();

            return Ok(virtualCloset);
        }

        private bool VirtualClosetExists(long id)
        {
            return _context.VirtualClosetItems.Any(e => e.Id == id);
        }
    }
}