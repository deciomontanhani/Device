using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace ProdutoWeb.Models
{
    [Table("INVESTIDOR")]
    public class Investidor
    {

        [Key]
        [Column("ID_INVESTIDOR")]
        public int InvestidorId { get; set; }

        [Column("NOME")]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }

        [Column("EMAIL")]
        [EmailAddress(ErrorMessage = "Formato de E-mail inválido.")]
        [Required(ErrorMessage = "Email é Obrigatório.")]
        public string Email { get; set; }

        [Column("EMPRESA")]
        [DisplayName("Nome da Empresa")]
        public string NomeEmpresa { get; set; }

        [Column("CNPJ")]
        public string CNPJ { get; set; }

        [Column("TELEFONE")]
        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Column("GENERO")]
        public int Genero { get; set; }

        [Column("CIDADE_ID_CIDADE")]
        public int CidadeId { get; set; }

        [Column("MENSAGEM")]
        public string Mensagem { get; set; }
        public virtual Cidade Cidade { get; set; }
   }
}