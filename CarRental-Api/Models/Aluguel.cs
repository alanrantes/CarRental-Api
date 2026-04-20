using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental_Api.Models
{
    public class Aluguel
    {
        [Key]
        public int IdAluguel { get; set; }

        [Required]
        public DateTime DataRetirada { get; set; }

        [Required]
        public DateTime DataPrevistaDevolucao { get; set; }

        public DateTime? DataDevolucao { get; set; }

        [Required]
        public int QuilometragemInicial { get; set; }

        public int? QuilometragemFinal { get; set; }

        [Required]
        public decimal ValorDiaria { get; set; }

        [Required]
        public decimal ValorTotal { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }

        [Required]
        public int IdVeiculo { get; set; }

        [ForeignKey("IdVeiculo")]
        public Veiculo? Veiculo { get; set; }
    }
}