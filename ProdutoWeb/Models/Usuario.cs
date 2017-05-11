using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ProdutoWeb.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        public Usuario()
        {

        }

        public Usuario(string Email, string Senha)
        {
            this.Email = Email;
            this.Senha = Senha;
        }

        [Column("ID_USUARIO")]
        [Key]
        public int ID_USUARIO { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("SOBRENOME")]
        public string Sobrenome { get; set; }

        [Column("EMAIL")]
        [EmailAddress]
        [Required(ErrorMessage = "Email é Obrigatório")]
        public string Email { get; set; }

        [Column("SENHA")]
        [Required(ErrorMessage = "Senha é Obrigatório")]
        public string Senha { get; set; }

        [Column("SITUACAO")]
        public string Situacao { get; set; }

        [ScriptIgnore]
        public virtual ICollection<Noticia> Noticias { get; set; }

    }
}