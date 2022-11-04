using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaRH.Models
{
    [Table("ValorHoras")]
    public class ValorHora
    {
        [Key]
        public int IdValorHora { get; set; } 

        [Column(TypeName ="decimal(18,2)")]
        [Required(ErrorMessage = "Obrigatório informar o valor!")]
        public decimal Valor { get; set; }

        public ICollection<Atividade>? Atividade { get; set; }

    }

}
