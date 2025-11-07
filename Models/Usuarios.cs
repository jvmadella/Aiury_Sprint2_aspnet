using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiury.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome deve ter até 100 caracteres")]
        [Display(Name = "Nome Completo")]
        public string NomeReal { get; set; }

        public string NomeAnonimo { get; set; }

        [Required]
        public string SenhaHash { get; set; }

        [Required(ErrorMessage = "A data de nascimento")]
        [DataType(DataType.Date)]
        [Display(Name ="Data de Nascimento")]
        public DateTime DatasNascimento { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Phone(ErrorMessage = "Formato Inválido")]
        [Display(Name = "Telefone Celular")]
        public string TelefoneCelular { get; set; }

        public DateTime DataCadastro { get; set; }

        public int IdCidade { get; set; }
        [ForeignKey("IdCidade")]
        public virtual Cidades Cidades { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }
    }
}
