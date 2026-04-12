using CarRental_Api.Data;
using CarRental_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FabricantesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Fabricantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fabricante>>> GetFabricantes()
        {
            return await _context.Fabricantes.ToListAsync();
        }

        // GET: api/Fabricantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fabricante>> GetFabricante(int id)
        {
            var fabricante = await _context.Fabricantes.FindAsync(id);

            if (fabricante == null)
            {
                return NotFound("Fabricante não encontrado.");
            }

            return fabricante;
        }

        // POST: api/Fabricantes
        [HttpPost]
        public async Task<ActionResult<Fabricante>> PostFabricante(Fabricante fabricante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Fabricantes.Add(fabricante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFabricante), new { id = fabricante.IdFabricante }, fabricante);
        }

        // PUT: api/Fabricantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFabricante(int id, Fabricante fabricante)
        {
            if (id != fabricante.IdFabricante)
            {
                return BadRequest("O ID informado na rota é diferente do ID do fabricante.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(fabricante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FabricanteExists(id))
                {
                    return NotFound("Fabricante não encontrado.");
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Fabricantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFabricante(int id)
        {
            var fabricante = await _context.Fabricantes.FindAsync(id);

            if (fabricante == null)
            {
                return NotFound("Fabricante não encontrado.");
            }

            _context.Fabricantes.Remove(fabricante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FabricanteExists(int id)
        {
            return _context.Fabricantes.Any(e => e.IdFabricante == id);
        }
    }
}