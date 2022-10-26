using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaRH.Models
{
    [Table("Logins")]

    public class Login
    {
        [Key]
        [Required(ErrorMessage = "Obrigatório informar usuário!")]
        public string? Usuario { get; set; }

        [Required(ErrorMessage = "Obrigatório informar senha!")]
        public string? Senha { get; set; }
    }
}
