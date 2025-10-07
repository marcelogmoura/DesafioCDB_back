using System.ComponentModel.DataAnnotations;

namespace DesafioCDB.Domain.Dtos.Requests
{
    public class CdbRequest
    {
        [Required(ErrorMessage = "O valor inicial é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor inicial deve ser um valor monetário positivo.")]
        public decimal ValorInicial { get; set; } // O Valor Inicial (VI)

        [Required(ErrorMessage = "O prazo em meses é obrigatório.")]
        [Range(2, int.MaxValue, ErrorMessage = "O prazo em meses deve ser maior que 1.")]
        public int PrazoEmMeses { get; set; }  
    }
}