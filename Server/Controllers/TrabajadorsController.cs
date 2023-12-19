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
    public class TrabajadorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TrabajadorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Trabajadors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trabajador>>> GetTrabajadores()
        {
            if (_context.Trabajadores == null)
            {
                return NotFound();
            }
            return await _context.Trabajadores.ToListAsync();
        }

        // GET: api/Trabajadors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trabajador>> GetTrabajador(int id)
        {
            if (_context.Trabajadores == null)
            {
                return NotFound();
            }
            var trabajador = await _context.Trabajadores.FindAsync(id);

            if (trabajador == null)
            {
                return NotFound();
            }

            return trabajador;
        }

        // GET: api/Trabajadors/AdminDetails
        [HttpGet("AdminDetails")]
        public async Task<ActionResult<IEnumerable<object>>> GetAdminDetails()
        {
            if (_context.Trabajadores == null)
            {
                return NotFound();
            }
            return await _context.Trabajadores
                .Select(t => new { t.Name, t.Password, Role = (bool)t.Admin ? "Administrador" : "Trabajador", t.Branch })
                .ToListAsync();
        }



        // PUT: api/Trabajadors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajador(int id, Trabajador trabajador)
        {
            if (id != trabajador.Id)
            {
                return BadRequest();
            }

            _context.Entry(trabajador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajadorExists(id))
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

        // POST: api/Trabajadors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trabajador>> PostTrabajador(Trabajador trabajador)
        {
            if (_context.Trabajadores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trabajadores'  is null.");
            }
            _context.Trabajadores.Add(trabajador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrabajador", new { id = trabajador.Id }, trabajador);
        }

        // DELETE: api/Trabajadors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajador(int id)
        {
            if (_context.Trabajadores == null)
            {
                return NotFound();
            }
            var trabajador = await _context.Trabajadores.FindAsync(id);
            if (trabajador == null)
            {
                return NotFound();
            }

            _context.Trabajadores.Remove(trabajador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrabajadorExists(int id)
        {
            return (_context.Trabajadores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
