using System.ComponentModel.DataAnnotations;


namespace CarRental_Api.Models
{
    public class CategoriaVeiculo
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal ValorDiariaBase { get; set; }
    }
}