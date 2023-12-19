using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueChulosPerros.Server.Data;
using QueChulosPerros.Shared.Model;

namespace QueChulosPerros.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MascotasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Mascotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascota>>> GetMascotas()
        {
            if (_context.Mascotas == null)
            {
                return NotFound();
            }
            return await _context.Mascotas.Include(m => m.Client).ToListAsync();
        }

        // GET: api/Mascotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mascota>> GetMascota(int id)
        {
            if (_context.Mascotas == null)
            {
                return NotFound();
            }
            var mascota = await _context.Mascotas.Include(m => m.Client).FirstOrDefaultAsync(m => m.Id == id);

            if (mascota == null)
            {
                return NotFound();
            }

            return mascota;
        }

        // PUT: api/Mascotas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascota(int id, Mascota mascota)
        {
            if (id != mascota.Id)
            {
                return BadRequest();
            }

            _context.Entry(mascota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotaExists(id))
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

        // POST: api/Mascotas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mascota>> PostMascota(Mascota mascota)
        {
            if (_context.Mascotas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mascotas'  is null.");
            }
            _context.Mascotas.Add(mascota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMascota", new { id = mascota.Id }, mascota);
        }

        // DELETE: api/Mascotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascota(int id)
        {
            if (_context.Mascotas == null)
            {
                return NotFound();
            }
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }

            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MascotaExists(int id)
        {
            return (_context.Mascotas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
