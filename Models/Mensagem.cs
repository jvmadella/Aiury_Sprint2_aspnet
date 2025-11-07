using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiury.Models
{
    public class Mensagem
    {
        [Key]
        public int IdMensagem { get; set; }

        public string Origem { get; set; }

        public string Texto { get; set; }

        public DateTime DataHora { get; set; }

        public int IdChat { get; set; }
        [ForeignKey("IdChat")]
        public virtual Chat Chat { get; set; }
    }
}
