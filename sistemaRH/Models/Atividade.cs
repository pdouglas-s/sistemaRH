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

    }
}
