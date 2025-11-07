using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiury.Models
{
    public class Ajudantes
    {
        [Key]
        public int IdAjudante { get; set; }

        public string NomeReal { get; set; }

        public string SenhaHash { get; set; }

        public DateTime DataNascimento { get; set; }

        public string TelefoneCelular { get; set; }

        public string AreaAtuacao { get; set; }

        public string Motivacao { get; set; }

        public DateTime DataCadastro { get; set; }

        public int IdCidade { get; set; }
        [ForeignKey("IdCidade")]
        public virtual Cidades Cidades { get; set; }

        public virtual ICollection<Chat> ChatsAtendidos { get; set; }
    }
}
