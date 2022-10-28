using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaRH.Models
{
    [Table("Horas")]

    public class Hora
    {
        [Key]
        public int IdJornada { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório informar a data!")]
        public DateTime Data { get; set; } = default!;

        public DateTime Entrada1 { get; set; } = default!;

        public DateTime Saida1 { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório informar cadastro!")]
        [Display(Name = "Cadastro")]
        public int CadastroId { get; set; }

        [ForeignKey("CadastroId")]
        public Cadastro Cadastro { get; set; } = default!;
    }
}
