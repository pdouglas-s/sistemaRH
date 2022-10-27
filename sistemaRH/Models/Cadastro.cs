using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaRH.Models
{

    [Table("Cadastros")]
   
    public class Cadastro
    {
        [Key]
        public int IdCadastro { get; set; } = default!;
        
        [Required(ErrorMessage = "Obrigatório informar nome!")]
        public string Nome { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório informar email!")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório informar senha!")]
        public string Senha { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório confirmar senha!")]
        public string ConfirmaSenha { get; set; } = default!;

    }
}
