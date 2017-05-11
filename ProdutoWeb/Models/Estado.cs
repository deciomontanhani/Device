using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ProdutoWeb.Models
{
    [Table("ESTADO")]
    public class Estado
    {
        [Key]
        [Column("ID_ESTADO")]
        public int EstadoId { get; set; }

        [Column("NOME_ESTADO")]
        public string Nome { get; set; }

        [Column("UF")]
        public string UF { get; set; }

        [Column("ID_PAIS")]
        public int id_pais { get; set; }

        [ScriptIgnore]
        public virtual Pais Pais { get; set; }

        [ScriptIgnore]
        public virtual ICollection<Cidade> Cidades { get; set; }

    }
}