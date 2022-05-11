using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLPBService.DataAccess.Context;
using QLPBService.Domain.Entities;

namespace QLPBService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoiPhongBansController : ControllerBase
    {
        private readonly QLPBContext _context;

        public KhoiPhongBansController(QLPBContext context)
        {
            _context = context;
        }

        // GET: api/KhoiPhongBans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhoiPhongBan>>> GetKhoiPhongBans()
        {
            return await _context.KhoiPhongBans.ToListAsync();
        }

        // GET: api/KhoiPhongBans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhoiPhongBan>> GetKhoiPhongBan(int id)
        {
            var khoiPhongBan = await _context.KhoiPhongBans.FindAsync(id);

            if (khoiPhongBan == null)
            {
                return NotFound();
            }

            return khoiPhongBan;
        }

        // PUT: api/KhoiPhongBans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhoiPhongBan(int id, KhoiPhongBan khoiPhongBan)
        {
            if (id != khoiPhongBan.Id)
            {
                return BadRequest();
            }

            _context.Entry(khoiPhongBan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoiPhongBanExists(id))
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

        // POST: api/KhoiPhongBans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KhoiPhongBan>> PostKhoiPhongBan(KhoiPhongBan khoiPhongBan)
        {
            _context.KhoiPhongBans.Add(khoiPhongBan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKhoiPhongBan", new { id = khoiPhongBan.Id }, khoiPhongBan);
        }

        // DELETE: api/KhoiPhongBans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoiPhongBan(int id)
        {
            var khoiPhongBan = await _context.KhoiPhongBans.FindAsync(id);
            if (khoiPhongBan == null)
            {
                return NotFound();
            }

            _context.KhoiPhongBans.Remove(khoiPhongBan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoiPhongBanExists(int id)
        {
            return _context.KhoiPhongBans.Any(e => e.Id == id);
        }
    }
}
