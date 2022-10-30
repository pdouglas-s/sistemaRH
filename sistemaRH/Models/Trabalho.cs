using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaRH.Models
{
    [Table("Trabalhos")]
    public class Trabalho
    {
        [Key]
        public int IdTrabalho { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Obrigatório informar usuário")]
        public int CadastroId { get; set; } = default!;

        [ForeignKey("CadastroId")]
        public Usuario Usuario { get; set; } = default!;

        [Display(Name = "Atividade")]
        [Required(ErrorMessage = "Obrigatório informar atividade")]
        public int AtividadeId { get; set; } = default!;

        [ForeignKey("AtividadeId")]
        public Atividade Atividade { get; set; } = default!;

        [Display(Name = "Valor hora")]
        [Required(ErrorMessage = "Obrigatório informar atividade")]
        public int ValorHoraId { get; set; } = default!;

        [ForeignKey("ValorHoraId")]
        public ValorHora ValoHora { get; set; } = default!;
    }
}
