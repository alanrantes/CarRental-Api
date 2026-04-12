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

        // GET: api/Alugueis/por-cliente/1
        [HttpGet("por-cliente/{idCliente}")]
        public async Task<ActionResult<IEnumerable<object>>> GetAlugueisPorCliente(int idCliente)
        {
            var alugueis = await (
                from a in _context.Alugueis
                join c in _context.Clientes on a.IdCliente equals c.IdCliente
                join v in _context.Veiculos on a.IdVeiculo equals v.IdVeiculo
                where a.IdCliente == idCliente
                select new
                {
                    a.IdAluguel,
                    Cliente = c.Nome,
                    c.Cpf,
                    Veiculo = v.Modelo,
                    v.Placa,
                    a.DataRetirada,
                    a.DataPrevistaDevolucao,
                    a.DataDevolucao,
                    a.ValorDiaria,
                    a.ValorTotal,
                    a.Status
                }
            ).ToListAsync();

            return Ok(alugueis);
        }

        // GET: api/Alugueis/por-veiculo/1
        [HttpGet("por-veiculo/{idVeiculo}")]
        public async Task<ActionResult<IEnumerable<object>>> GetAlugueisPorVeiculo(int idVeiculo)
        {
            var alugueis = await (
                from a in _context.Alugueis
                join v in _context.Veiculos on a.IdVeiculo equals v.IdVeiculo
                join c in _context.Clientes on a.IdCliente equals c.IdCliente
                where a.IdVeiculo == idVeiculo
                select new
                {
                    a.IdAluguel,
                    Veiculo = v.Modelo,
                    v.Placa,
                    Cliente = c.Nome,
                    c.Email,
                    a.DataRetirada,
                    a.DataPrevistaDevolucao,
                    a.DataDevolucao,
                    a.Status,
                    a.ValorTotal
                }
            ).ToListAsync();

            return Ok(alugueis);
        }

        // GET: api/Alugueis/em-aberto
        [HttpGet("em-aberto")]
        public async Task<ActionResult<IEnumerable<object>>> GetAlugueisEmAberto()
        {
            var alugueis = await (
                from a in _context.Alugueis
                join c in _context.Clientes on a.IdCliente equals c.IdCliente
                join v in _context.Veiculos on a.IdVeiculo equals v.IdVeiculo
                where a.DataDevolucao == null
                select new
                {
                    a.IdAluguel,
                    Cliente = c.Nome,
                    Veiculo = v.Modelo,
                    v.Placa,
                    a.DataRetirada,
                    a.DataPrevistaDevolucao,
                    a.Status,
                    a.ValorDiaria
                }
            ).ToListAsync();

            return Ok(alugueis);
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