using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sistema_COEBB.Models
{
    [Table("NOTICIA")]
    public class Noticia
    {
        [Key]
        [Display(Name = "ID NOTICIA")]
        public int IDNOTICIA { get; set; }

        [Display(Name = "Titulo Noticia")]
        [StringLength(200, ErrorMessage = "Tamanho Máximo de 200 caracteres!")]
        [Required(ErrorMessage = "Campo Requerido!")]
        public string TITULO_NOTICIA { get; set; }

        [Display(Name = "Corpo Texto")]
        [StringLength(8000, ErrorMessage = "Tamanho Máximo de 8000 caracteres!")]
        [Required(ErrorMessage = "Campo Requerido!")]
        public string CORPO_TEXTO { get; set; }

        [Display(Name = "Data Noticia")]
        [Required(ErrorMessage = "Campo Requerido!")]
        public DateTime DATANOTICIA { get; set; }

        [Display(Name = "Tipo Noticia")]
        [StringLength(8000, ErrorMessage = "Tamanho Máximo de 8000 caracteres!")]
        [Required(ErrorMessage = "Campo Requerido!")]
        public string TIPO { get; set; }

        [Display(Name = "Tags")]
        [StringLength(500, ErrorMessage = "Tamanho Máximo de 500 caracteres!")]
        [Required(ErrorMessage = "Campo Requerido!")]
        public string TAGS { get; set; }

        public virtual List<Foto> Fotos { get; set; }

    }
}