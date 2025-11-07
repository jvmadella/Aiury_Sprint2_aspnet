using System.ComponentModel.DataAnnotations;

namespace Aiury.ViewModels
{
    public class AjudanteViewModel
    {
        public int IdAjudante { get; set; }

        [Required, StringLength(120)]
        public string NomeReal { get; set; } = string.Empty;

        [Required, StringLength(120)]
        public string AreaAtuacao { get; set; } = string.Empty;

        [StringLength(400)]
        public string? Motivacao { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage="Selecione uma cidade válida")]
        public int IdCidade { get; set; }
    }
}
