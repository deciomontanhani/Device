using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdutoWeb.Models
{
    [Table("PAIS")]
    public class Pais
    {
        [Key]
        [Column("ID_PAIS")]
        public int id_pais { get; set; }

        [Column("NOME_PAIS")]
        public string nome { get; set; }

        [Column("SIGLA")]
        public string sigla { get; set; }

        public virtual ICollection<Estado> estados { get; set; }
    }
}