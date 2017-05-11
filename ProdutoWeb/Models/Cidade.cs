using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ProdutoWeb.Models
{
    [Table("CIDADE")]
    public class Cidade
    {
        [Key]
        [Column("ID_CIDADE")]
        public int CidadeId { get; set; }

        [Column("NOME_CIDADE")]
        public string Nome { get; set; }

        [Column("ID_ESTADO")]
        public int EstadoId { get; set; }

        [ScriptIgnore]
        public virtual Estado Estado { get; set; }

        [ScriptIgnore]
        public virtual ICollection<Cliente> Clientes { get; set; }
        [ScriptIgnore]
        public virtual ICollection<Investidor> Investidores { get; set; }

    }
}