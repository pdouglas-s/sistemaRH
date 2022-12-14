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

        public int? IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        public int? IdAtividade { get; set; }
        [ForeignKey("IdAtividade")]
        public Atividade? Atividade { get; set; }

    }
}