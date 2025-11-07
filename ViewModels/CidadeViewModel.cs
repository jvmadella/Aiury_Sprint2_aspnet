using System.ComponentModel.DataAnnotations;

namespace Aiury.ViewModels
{
    public class CidadeViewModel
    {
        public int IdCidade { get; set; }

        [Required, StringLength(120)]
        public string NomeCidade { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage="Selecione um estado válido")]
        public int IdEstado { get; set; }
    }
}
