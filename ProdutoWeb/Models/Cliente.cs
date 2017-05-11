using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ProdutoWeb.Models
{
    [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("ID_CLIENTE")]
        public int ClienteId { get; set; }

        [Column("NOME")]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }

        [Column("SOBRENOME")]
        [Required(ErrorMessage = "Sobrenome é obrigatório.")]
        public string Sobrenome { get; set; }

        [Column("EMAIL")]
        [EmailAddress(ErrorMessage = "Formato de E-mail inválido.")]
        [Required(ErrorMessage = "Email é Obrigatório.")]
        public string Email { get; set; }

        [Column("CPF")]
        [Required(ErrorMessage = "CPF é obrigatório.")]
        public string CPF { get; set; }

        [Column("TELEFONE")]
        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Column("CIDADE_ID_CIDADE")]
        public int CidadeId { get; set; }

        [Column("GENERO")]
        public int Genero { get; set; }

        [Column("MENSAGEM")]
        public string Mensagem { get; set; }

        [ScriptIgnore]
        public virtual Cidade Cidade { get; set; }
    }
}