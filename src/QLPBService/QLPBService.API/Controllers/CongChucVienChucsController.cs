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
    public class CongChucVienChucsController : ControllerBase
    {
        private readonly QLPBContext _context;

        public CongChucVienChucsController(QLPBContext context)
        {
            _context = context;
        }

        // GET: api/CongChucVienChucs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CongChucVienChuc>>> GetCongChucVienChucs()
        {
            return await _context.CongChucVienChucs.Include(c => c.ChucVu).Include(c => c.PhongBan).ToListAsync();
        }

        // GET: api/CongChucVienChucs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CongChucVienChuc>> GetCongChucVienChuc(int id)
        {
            var congChucVienChuc = await _context.CongChucVienChucs.FindAsync(id);

            if (congChucVienChuc == null)
            {
                return NotFound();
            }

            return congChucVienChuc;
        }

        // PUT: api/CongChucVienChucs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCongChucVienChuc(int id, CongChucVienChuc congChucVienChuc)
        {
            if (id != congChucVienChuc.Id)
            {
                return BadRequest();
            }

            _context.Entry(congChucVienChuc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongChucVienChucExists(id))
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

        // POST: api/CongChucVienChucs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CongChucVienChuc>> PostCongChucVienChuc(CongChucVienChuc congChucVienChuc)
        {
            _context.CongChucVienChucs.Add(congChucVienChuc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCongChucVienChuc", new { id = congChucVienChuc.Id }, congChucVienChuc);
        }

        // DELETE: api/CongChucVienChucs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCongChucVienChuc(int id)
        {
            var congChucVienChuc = await _context.CongChucVienChucs.FindAsync(id);
            if (congChucVienChuc == null)
            {
                return NotFound();
            }

            _context.CongChucVienChucs.Remove(congChucVienChuc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CongChucVienChucExists(int id)
        {
            return _context.CongChucVienChucs.Any(e => e.Id == id);
        }
    }
}
