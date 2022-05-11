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
    public class TrinhDoesController : ControllerBase
    {
        private readonly QLPBContext _context;

        public TrinhDoesController(QLPBContext context)
        {
            _context = context;
        }

        // GET: api/TrinhDoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrinhDo>>> GetTrinhDos()
        {
            return await _context.TrinhDos.ToListAsync();
        }

        // GET: api/TrinhDoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrinhDo>> GetTrinhDo(int id)
        {
            var trinhDo = await _context.TrinhDos.FindAsync(id);

            if (trinhDo == null)
            {
                return NotFound();
            }

            return trinhDo;
        }

        // PUT: api/TrinhDoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrinhDo(int id, TrinhDo trinhDo)
        {
            if (id != trinhDo.Id)
            {
                return BadRequest();
            }

            _context.Entry(trinhDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrinhDoExists(id))
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

        // POST: api/TrinhDoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrinhDo>> PostTrinhDo(TrinhDo trinhDo)
        {
            _context.TrinhDos.Add(trinhDo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrinhDo", new { id = trinhDo.Id }, trinhDo);
        }

        // DELETE: api/TrinhDoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrinhDo(int id)
        {
            var trinhDo = await _context.TrinhDos.FindAsync(id);
            if (trinhDo == null)
            {
                return NotFound();
            }

            _context.TrinhDos.Remove(trinhDo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrinhDoExists(int id)
        {
            return _context.TrinhDos.Any(e => e.Id == id);
        }
    }
}
