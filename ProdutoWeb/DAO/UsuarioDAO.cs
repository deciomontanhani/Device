using ProdutoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdutoWeb.DAO
{
    public class UsuarioDAO
    {

        public IList<Usuario> ListarTodos()
        {
            return new DataBaseContext().Usuario.ToList<Usuario>();
        }

        public Usuario ConsultarPorId(int Id)
        {
            return new DataBaseContext().Usuario.Find(Id);
        }

        public void Inserir(Usuario U)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Usuario.Add(U);
            DBContext.SaveChanges();
        }

        public Usuario Login(Usuario usuarioLogin)
        {

            Usuario usuario = ConsultarPorEmail(usuarioLogin.Email);

            if(usuario != null)
            {
                if (usuario.Senha.Equals(usuarioLogin.Senha))
                {
                    return usuario;
                }
                else
                {
                    usuario = null;
                }
                       
            }

            
            return usuario;
        }

        public void Editar(Usuario U)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Entry(U).State = System.Data.Entity.EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            DataBaseContext DBContext = new DataBaseContext();
            Usuario Usuario = ConsultarPorId(Id);

            ExcluirNoticias(Usuario.ID_USUARIO);

            DBContext.Entry(Usuario).State = System.Data.Entity.EntityState.Deleted;
            DBContext.SaveChanges();
        }


        public void ExcluirNoticias(int Id)
        {
            DataBaseContext DBContext = new DataBaseContext();
            var result = from r in DBContext.Noticia where r.Id_Usuario == Id select r;

            if (result.Count() > 0)
            {
                Noticia noticia = result.First();
                DBContext.Noticia.Remove(noticia);
                DBContext.SaveChanges();
            }

        }



        public Usuario ConsultarPorEmail(String Email)
        {
            Usuario Usuario = new Usuario();

            try
            {
                DataBaseContext DBContext = new DataBaseContext();
                Usuario = DBContext.Usuario.Where(p => p.Email == Email).SingleOrDefault<Usuario>();
            }
            catch (Exception ex)
            {
                Usuario = new Usuario();
            }

            return Usuario;
        }

        public List<Noticia> ConsultarParteNomeDinamico(String ParteEmail, String ParteNome)
        {
            var ListaRetorno = new DataBaseContext()
                    .Noticia
                    .Where
                    (
                        p =>
                        (string.IsNullOrEmpty(ParteEmail) || p.Titulo.Contains(ParteEmail)) &&
                        (string.IsNullOrEmpty(ParteNome) || p.noticia.Contains(ParteNome))

                    ).ToList<Noticia>();


            return ListaRetorno;
        }



    }
}