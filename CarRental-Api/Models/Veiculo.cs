using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental_Api.Models
{
    public class Veiculo
    {
        [Key]
        public int IdVeiculo { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public int AnoFabricacao { get; set; }

        [Required]
        public int Quilometragem { get; set; }

        [Required]
        public string Placa { get; set; }

        public string? Cor { get; set; }

        [Required]
        public bool Disponivel { get; set; }

        // FK Fabricante
        public int IdFabricante { get; set; }

        [ForeignKey("IdFabricante")]
        public Fabricante Fabricante { get; set; }

        // FK Categoria
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public CategoriaVeiculo CategoriaVeiculo { get; set; }
    }
}
