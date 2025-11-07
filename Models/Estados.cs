using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aiury.Models
{

    public class Estados
    {
        [Key]
        public int IdEstado { get; set; }

        public string NomeEstado { get; set; }

        public string Uf { get; set; }

        public virtual ICollection<Cidades> Cidades { get; set; }
    }
}

