using CarRental_Api.Data;
using CarRental_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Veiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculos
                .Include(v => v.Fabricante)
                .Include(v => v.CategoriaVeiculo)
                .ToListAsync();
        }

        // GET: api/Veiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(int id)
        {
            var veiculo = await _context.Veiculos
                .Include(v => v.Fabricante)
                .Include(v => v.CategoriaVeiculo)
                .FirstOrDefaultAsync(v => v.IdVeiculo == id);

            if (veiculo == null)
            {
                return NotFound("Veículo não encontrado.");
            }

            return veiculo;
        }

        // GET: api/Veiculos/com-detalhes
        [HttpGet("com-detalhes")]
        public async Task<ActionResult<IEnumerable<object>>> GetVeiculosComDetalhes()
        {
            var veiculos = await (
                from v in _context.Veiculos
                join f in _context.Fabricantes on v.IdFabricante equals f.IdFabricante
                join c in _context.CategoriasVeiculo on v.IdCategoria equals c.IdCategoria
                select new
                {
                    v.IdVeiculo,
                    v.Modelo,
                    v.AnoFabricacao,
                    v.Quilometragem,
                    v.Placa,
                    v.Cor,
                    v.Disponivel,
                    Fabricante = f.Nome,
                    Categoria = c.Nome,
                    c.ValorDiariaBase
                }
            ).ToListAsync();

            return Ok(veiculos);
        }

        // GET: api/Veiculos/disponiveis-por-categoria/1
        [HttpGet("disponiveis-por-categoria/{idCategoria}")]
        public async Task<ActionResult<IEnumerable<object>>> GetVeiculosDisponiveisPorCategoria(int idCategoria)
        {
            var veiculos = await (
                from v in _context.Veiculos
                join c in _context.CategoriasVeiculo on v.IdCategoria equals c.IdCategoria
                where v.Disponivel == true && v.IdCategoria == idCategoria
                select new
                {
                    v.IdVeiculo,
                    v.Modelo,
                    v.Placa,
                    v.Cor,
                    v.Quilometragem,
                    Categoria = c.Nome
                }
            ).ToListAsync();

            return Ok(veiculos);
        }

        // GET: api/Veiculos/com-historico-aluguel
        [HttpGet("com-historico-aluguel")]
        public async Task<ActionResult<IEnumerable<object>>> GetVeiculosComHistoricoAluguel()
        {
            var resultado = await (
                from v in _context.Veiculos
                join a in _context.Alugueis on v.IdVeiculo equals a.IdVeiculo into alugueisGroup
                from a in alugueisGroup.DefaultIfEmpty()
                select new
                {
                    v.IdVeiculo,
                    v.Modelo,
                    v.Placa,
                    IdAluguel = a != null ? a.IdAluguel : (int?)null,
                    DataRetirada = a != null ? a.DataRetirada : (DateTime?)null,
                    Status = a != null ? a.Status : "Sem histórico de aluguel"
                }
            ).ToListAsync();

            return Ok(resultado);
        }

        // POST: api/Veiculos
        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fabricanteExiste = await _context.Fabricantes.AnyAsync(f => f.IdFabricante == veiculo.IdFabricante);
            if (!fabricanteExiste)
            {
                return BadRequest("Fabricante informado não existe.");
            }

            var categoriaExiste = await _context.CategoriasVeiculo.AnyAsync(c => c.IdCategoria == veiculo.IdCategoria);
            if (!categoriaExiste)
            {
                return BadRequest("Categoria informada não existe.");
            }

            veiculo.Fabricante = null;
            veiculo.CategoriaVeiculo = null;

            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVeiculo), new { id = veiculo.IdVeiculo }, veiculo);
        }
        // PUT: api/Veiculos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo(int id, Veiculo veiculo)
        {
            if (id != veiculo.IdVeiculo)
            {
                return BadRequest("ID da rota diferente do ID do veículo.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fabricanteExiste = await _context.Fabricantes.AnyAsync(f => f.IdFabricante == veiculo.IdFabricante);
            if (!fabricanteExiste)
            {
                return BadRequest("Fabricante informado não existe.");
            }

            var categoriaExiste = await _context.CategoriasVeiculo.AnyAsync(c => c.IdCategoria == veiculo.IdCategoria);
            if (!categoriaExiste)
            {
                return BadRequest("Categoria informada não existe.");
            }

            _context.Entry(veiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
                {
                    return NotFound("Veículo não encontrado.");
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Veiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound("Veículo não encontrado.");
            }

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeiculoExists(int id)
        {
            return _context.Veiculos.Any(e => e.IdVeiculo == id);
        }
    }
}