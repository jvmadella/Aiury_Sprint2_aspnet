using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiury.Models
{
    public class Chat
    {
        [Key]
        public int IdChat { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public bool Ativo { get; set; }

        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuarios Usuarios { get; set; }

        public int? IdAjudante { get; set; }
        [ForeignKey("IdAjudante")]
        public virtual Ajudantes Ajudantes { get; set; }

        public virtual ICollection<Mensagem> Mensagens { get; set; }
    }
}
