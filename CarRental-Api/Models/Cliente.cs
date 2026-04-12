using System.ComponentModel.DataAnnotations;

namespace CarRental_Api.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? Telefone { get; set; }
    }
}
