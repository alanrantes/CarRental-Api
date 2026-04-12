using CarRental_Api.Data;
using CarRental_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return cliente;
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cpfExiste = await _context.Clientes.AnyAsync(c => c.Cpf == cliente.Cpf);
            if (cpfExiste)
            {
                return BadRequest("Já existe um cliente com este CPF.");
            }

            var emailExiste = await _context.Clientes.AnyAsync(c => c.Email == cliente.Email);
            if (emailExiste)
            {
                return BadRequest("Já existe um cliente com este e-mail.");
            }

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.IdCliente }, cliente);
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest("ID da rota diferente do ID do cliente.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cpfExiste = await _context.Clientes
                .AnyAsync(c => c.Cpf == cliente.Cpf && c.IdCliente != id);

            if (cpfExiste)
            {
                return BadRequest("Já existe outro cliente com este CPF.");
            }

            var emailExiste = await _context.Clientes
                .AnyAsync(c => c.Email == cliente.Email && c.IdCliente != id);

            if (emailExiste)
            {
                return BadRequest("Já existe outro cliente com este e-mail.");
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound("Cliente não encontrado.");
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}