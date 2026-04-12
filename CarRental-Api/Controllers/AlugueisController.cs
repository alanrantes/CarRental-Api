using CarRental_Api.Data;
using CarRental_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlugueisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Alugueis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluguel>>> GetAlugueis()
        {
            return await _context.Alugueis
                .Include(a => a.Cliente)
                .Include(a => a.Veiculo)
                .ToListAsync();
        }

        // GET: api/Alugueis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluguel>> GetAluguel(int id)
        {
            var aluguel = await _context.Alugueis
                .Include(a => a.Cliente)
                .Include(a => a.Veiculo)
                .FirstOrDefaultAsync(a => a.IdAluguel == id);

            if (aluguel == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            return aluguel;
        }

        // POST: api/Alugueis
        [HttpPost]
        public async Task<ActionResult<Aluguel>> PostAluguel(Aluguel aluguel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteExiste = await _context.Clientes.AnyAsync(c => c.IdCliente == aluguel.IdCliente);
            if (!clienteExiste)
            {
                return BadRequest("Cliente informado não existe.");
            }

            var veiculo = await _context.Veiculos.FindAsync(aluguel.IdVeiculo);
            if (veiculo == null)
            {
                return BadRequest("Veículo informado não existe.");
            }

            if (!veiculo.Disponivel)
            {
                return BadRequest("O veículo informado não está disponível para aluguel.");
            }

            _context.Alugueis.Add(aluguel);

            veiculo.Disponivel = false;
            _context.Veiculos.Update(veiculo);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAluguel), new { id = aluguel.IdAluguel }, aluguel);
        }

        // PUT: api/Alugueis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluguel(int id, Aluguel aluguel)
        {
            if (id != aluguel.IdAluguel)
            {
                return BadRequest("ID da rota diferente do ID do aluguel.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteExiste = await _context.Clientes.AnyAsync(c => c.IdCliente == aluguel.IdCliente);
            if (!clienteExiste)
            {
                return BadRequest("Cliente informado não existe.");
            }

            var veiculoExiste = await _context.Veiculos.AnyAsync(v => v.IdVeiculo == aluguel.IdVeiculo);
            if (!veiculoExiste)
            {
                return BadRequest("Veículo informado não existe.");
            }

            _context.Entry(aluguel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AluguelExists(id))
                {
                    return NotFound("Aluguel não encontrado.");
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Alugueis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluguel(int id)
        {
            var aluguel = await _context.Alugueis.FindAsync(id);

            if (aluguel == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            var veiculo = await _context.Veiculos.FindAsync(aluguel.IdVeiculo);
            if (veiculo != null)
            {
                veiculo.Disponivel = true;
                _context.Veiculos.Update(veiculo);
            }

            _context.Alugueis.Remove(aluguel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AluguelExists(int id)
        {
            return _context.Alugueis.Any(e => e.IdAluguel == id);
        }
    }
}