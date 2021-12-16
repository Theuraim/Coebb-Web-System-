using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sistema_COEBB.Models
{
    [Table("EQUIPE")]
    public class Equipe
    {
        [Key]
        [Display(Name = "ID EQUIPE")]
        public int IDEQUIPE { get; set; }

        [Display(Name = "Nome")]
        [StringLength(200, ErrorMessage = "Tamanho Máximo de 200 caracteres!")]
        [Required(ErrorMessage = "Campo Requerido!")]
        public string NOME { get; set; }

        [Display(Name = "Descrição Cargo")]
        [StringLength(200, ErrorMessage = "Tamanho Máximo de 200 caracteres!")]
        [Required(ErrorMessage = "Campo Requerido!")]
        public string DESCRICAOCARGO { get; set; }

        [Display(Name = "Descrição Afinidade")]
        [StringLength(200, ErrorMessage = "Tamanho Máximo de 200 caracteres!")]
        [Required(ErrorMessage = "Campo Requerido!")]
        public string DESCRICAOAFINIDADE { get; set; }


        public virtual List<Foto> Fotos { get; set; }
    }
}