using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaRH.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int IdCadastro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar nome!")]
        public string Nome { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório informar email!")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório informar senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório confirmar senha!")]
        [Display(Name ="Confirmar senha ")]
        [DataType(DataType.Password)]
        public string ConfirmaSenha { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório informar perfil!")]
        public Perfil Perfil { get; set; }
    }
    public enum Perfil{
        User}
}
