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
        public string Descricao { get; set; }

        [Display(Name = "Nível dificuldade")]
        [Required(ErrorMessage = "Obrigatório informar nível de dificuldade")]
        public NivelDificuldade Nivel { get; set; }

        public string cpf_usuario { get; set; }
        [ForeignKey("cpf_usuario")]
        public Usuario? Usuario { get; set; }

        public int IdValorHora { get; set; }
        [ForeignKey("IdValorHora")]
        public ValorHora? ValorHora { get; set; }

        public ICollection<Trabalho>? Trabalho { get; set; }

    }

    public enum NivelDificuldade { 
        Fácil,
        Médio,
        Díficil
    }

}
