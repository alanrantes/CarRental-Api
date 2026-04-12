using System.ComponentModel.DataAnnotations;

namespace CarRental_Api.Models
{
    public class Fabricante
    {
        [Key]
        public int IdFabricante { get; set; }

        [Required]
        public string Nome { get; set; }

        public string? PaisOrigem { get; set; }

    }
}
