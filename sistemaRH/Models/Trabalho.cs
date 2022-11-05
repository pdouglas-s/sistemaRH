using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace sistemaRH.Models
{
    [Table("Trabalhos")]
    public class Trabalho
    {
        [Key]
        public int IdTrabalho { get; set; }

        public string DescTrabalho { get; set; }
        public string cpf_usuario { get; set; }
        [ForeignKey("cpf_usuario")]
        public Usuario? Usuario { get; set; }

    }
}