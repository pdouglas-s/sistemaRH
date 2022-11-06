using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace sistemaRH.Models
{
    [Table("Atividades")]
    public class Atividade
    {
        [Key]
        public int IdAtividade { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Obrigatório informar a descrição da atividade")]
        public string? Descricao { get; set; }

        [Display(Name = "Nível dificuldade")]
        [Required(ErrorMessage = "Obrigatório informar nível de dificuldade")]
        public NivelDificuldade Nivel { get; set; }

        [Display(Name = "Valor atividade")]
        [Required(ErrorMessage = "Obrigatório informar o valor da atividade")]
        public int? IdValorHora { get; set; }
        [ForeignKey("IdValorHora")]

        [Display(Name = "Valor atividade")]
        public ValorHora? ValorHora { get; set; }

        public ICollection<Trabalho>? Trabalho { get; set; }

    }

    public enum NivelDificuldade
    {
        Fácil,
        Médio,
        Díficil
    }

}