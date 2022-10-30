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

    }

    public enum NivelDificuldade { 
        Fácil,
        Médio,
        Díficil
    }

}
