using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sistema_COEBB.Models
{
    [Table("FOTO")]
    public class Foto
    {
        [Key]
        [Display(Name = "ID FOTO")]
        public int IDFOTO { get; set; }

        [Display(Name = "Caminho")]
        [StringLength(100, ErrorMessage = "Tamanho Máximo de 100 caracteres!")]
        public string CAMINHO { get; set; }

        [Display(Name = "Nome Foto")]
        [StringLength(100, ErrorMessage = "Tamanho Máximo de 100 caracteres!")]
        [Required(ErrorMessage = "Campo Requerido!")]
        public string NOMEFOTO { get; set; }

        [Display(Name = "ID NOTICIA")]
        public int? IDNOTICIA { get; set; }
        public virtual Noticia Noticia { get; set; }

        [Display(Name = "ID EQUIPE")]

        public int? IDEQUIPE { get; set; }
        public virtual Equipe Equipe { get; set; }
    }
}