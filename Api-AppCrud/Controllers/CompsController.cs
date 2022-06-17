using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_AppCrud.Data;
using Api_AppCrud.Models;

namespace Api_AppCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompsController : ControllerBase
    {
        private readonly crudEmpleadoContext _context;

        public CompsController(crudEmpleadoContext context)
        {
            _context = context;
        }

        // GET: api/Comps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comps>>> GetComps()
        {
          if (_context.Comps == null)
          {
              return NotFound();
          }
            return await _context.Comps.ToListAsync();
        }

        // GET: api/Comps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comps>> GetComps(int id)
        {
          if (_context.Comps == null)
          {
              return NotFound();
          }
            var comps = await _context.Comps.FindAsync(id);

            if (comps == null)
            {
                return NotFound();
            }

            return comps;
        }

        // PUT: api/Comps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComps(int id, Comps comps)
        {
            if (id != comps.Idcomp)
            {
                return BadRequest();
            }

            _context.Entry(comps).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompsExists(id))
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

        // POST: api/Comps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comps>> PostComps(Comps comps)
        {
          if (_context.Comps == null)
          {
              return Problem("Entity set 'crudEmpleadoContext.Comps'  is null.");
          }
            _context.Comps.Add(comps);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComps", new { id = comps.Idcomp }, comps);
        }

        // DELETE: api/Comps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComps(int id)
        {
            if (_context.Comps == null)
            {
                return NotFound();
            }
            var comps = await _context.Comps.FindAsync(id);
            if (comps == null)
            {
                return NotFound();
            }

            _context.Comps.Remove(comps);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompsExists(int id)
        {
            return (_context.Comps?.Any(e => e.Idcomp == id)).GetValueOrDefault();
        }
    }
}
