using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ProdutoWeb.Models
{
    [Table("NOTICIA")]
    public class Noticia
    {
        [Key]
        [Column("ID_NOTICIA")]
        public int NoticiaId { get; set; }

        [Column("TITULO")]
        [Required(ErrorMessage = "Título é obrigatório.")]
        public string Titulo { get; set; }


        [Column("NOTICIA")]
        [Required(ErrorMessage = "A notícia é obrigatória.")]
        public string noticia { get; set; }

        [Column("DATA_HORA")]
        public DateTime data_hora { get; set; }

        [Column("ID_USUARIO")]
        public int Id_Usuario { get; set; }

        [ScriptIgnore]
        public virtual Usuario Usuario { get; set; }


    }
}