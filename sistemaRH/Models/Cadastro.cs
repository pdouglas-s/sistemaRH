﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaRH.Models
{

    [Table("Cadastros")]
   
    public class Cadastro
    {
        [Required(ErrorMessage = "Obrigatório informar tipo inscrição!")]
        public int IdTpInsc { get; set; } = default!;

        [Key]
        [Required(ErrorMessage = "Obrigatório informar CPF!")]
        public int CpfCnpj { get; set; } = default!;

        [Required(ErrorMessage = "Obrigatório informar nome ou razão social!")]
        public string NomeRazSoc { get; set; } = default!;


    }
}
