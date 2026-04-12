using CarRental_Api.Data;
using CarRental_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasVeiculoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasVeiculoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoriasVeiculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaVeiculo>>> GetCategorias()
        {
            return await _context.CategoriasVeiculo.ToListAsync();
        }

        // GET: api/CategoriasVeiculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaVeiculo>> GetCategoria(int id)
        {
            var categoria = await _context.CategoriasVeiculo.FindAsync(id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            return categoria;
        }

        // POST: api/CategoriasVeiculo
        [HttpPost]
        public async Task<ActionResult<CategoriaVeiculo>> PostCategoria(CategoriaVeiculo categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CategoriasVeiculo.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.IdCategoria }, categoria);
        }

        // PUT: api/CategoriasVeiculo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, CategoriaVeiculo categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return BadRequest("ID da rota diferente do ID da categoria.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound("Categoria não encontrada.");
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/CategoriasVeiculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.CategoriasVeiculo.FindAsync(id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            _context.CategoriasVeiculo.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.CategoriasVeiculo.Any(e => e.IdCategoria == id);
        }
    }
}