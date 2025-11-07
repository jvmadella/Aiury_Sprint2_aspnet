using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiury.Models
{
    public class Cidades
    {
        [Key]
        public int IdCidade { get; set; }

        public string NomeCidade { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public virtual Estados Estados { get; set; }
    }
}
