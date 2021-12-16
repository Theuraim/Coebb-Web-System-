using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sistema_COEBB.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = "Campo Requerido!")]
        [Display(Name = "ID USUARIO")]
        public int IDUSUARIO { get; set; }

        [Required(ErrorMessage = "Campo Requerido!")]
        [StringLength(200, ErrorMessage = "Tamanho Máximo de 200 caracteres!")]
        [Display(Name = "NOME USUARIO")]
        public string NOMEUSUARIO { get; set; }
    }
}