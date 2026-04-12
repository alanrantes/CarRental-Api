using Microsoft.EntityFrameworkCore;
using CarRental_Api.Models;

namespace CarRental_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<CategoriaVeiculo> CategoriasVeiculo { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
    }
}