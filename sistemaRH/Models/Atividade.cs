using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaRH.Models
{
    [Table("Atividades")]
    public class Atividade
    {
        [Key]
        public int IdAtividade { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Obrigatório informar a descrição da atividade")]
        public string Descricao { get; set; } = default!;

        [Display(Name = "Nível dificuldade")]
        [Required(ErrorMessage = "Obrigatório informar nível de dificuldade")]
        public NivelDificuldade Nivel { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Obrigatório informar usuário")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; } = default!;

        [Display(Name = "Valor hora")]
        [Required(ErrorMessage = "Obrigatório informar valor hora")]
        public int ValorHoraId { get; set; } = default!;

        [ForeignKey("ValorHoraId")]
        public ValorHora ValorHoras { get; set; } = default!;

    }

    public enum NivelDificuldade { 
        Fácil,
        Médio,
        Díficil
    }

}
