using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaRH.Models
{
    [Table("Logins")]

    public class Login
    {
        [Key]
        public int Id { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório informar usuário!")]
        public string Usuario { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório informar senha!")]
        public string Senha { get; set; } = default!;
    }
}
