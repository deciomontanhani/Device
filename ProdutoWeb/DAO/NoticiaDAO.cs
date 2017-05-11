using ProdutoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdutoWeb.DAO
{
    public class NoticiaDAO
    {

        public IList<Noticia> ListarTodos()
        {

            return new DataBaseContext().Noticia.Include("Usuario").ToList<Noticia>();

            /*
            IList<Noticia> lista = new List<Noticia>();

            Noticia n1 = new Noticia();
            n1.NoticiaId = 1;
            n1.Titulo = "Noticia 1";
            n1.noticia = "NOTICIA COMPLETA 1";
            n1.data_hora = DateTime.Now;
            lista.Add(n1);

            Noticia n2 = new Noticia();
            n2.NoticiaId = 2;
            n2.Titulo = "Noticia 2";
            n2.noticia = "NOTICIA COMPLETA 2";
            n2.data_hora = DateTime.Now;
            lista.Add(n2);

            Noticia n3 = new Noticia();
            n3.NoticiaId = 3;
            n3.Titulo = "Noticia 3";
            n3.noticia = "NOTICIA COMPLETA 3";
            n3.data_hora = DateTime.Now;
            lista.Add(n3);

            Noticia n4 = new Noticia();
            n4.NoticiaId = 4;
            n4.Titulo = "Noticia 4";
            n4.noticia = "NOTICIA COMPLETA 4";
            n4.data_hora = DateTime.Now;
            lista.Add(n4);



            return (lista);
            */
        }

        public Noticia ConsultarPorId(int Id)
        {
            return new DataBaseContext().Noticia.Find(Id);
        }

        public void Inserir(Noticia Not)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Noticia.Add(Not);
            DBContext.SaveChanges();
        }

        public void Editar(Noticia Not)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Entry(Not).State = System.Data.Entity.EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            DataBaseContext DBContext = new DataBaseContext();
            Noticia Noticia = ConsultarPorId(Id);

            DBContext.Entry(Noticia).State = System.Data.Entity.EntityState.Deleted;
            DBContext.SaveChanges();
        }


        public Noticia ConsultarPorTitulo(String Titulo)
        {
            Noticia Noticia = new Noticia();


            try
            {
                DataBaseContext DBContext = new DataBaseContext();
                Noticia = DBContext.Noticia.Where(p => p.Titulo == Titulo).SingleOrDefault<Noticia>();
            }
            catch (Exception ex)
            {
                Noticia = new Noticia();
            }

            return Noticia;
        }


        public List<Noticia> ConsultarParteTitulo(String ParteTitulo)
        {
            var ListaRetorno = new DataBaseContext()
                    .Noticia
                    .Where(
                            p => p.Titulo.Contains(ParteTitulo)
                           )
                    .OrderBy(p => p.Titulo)
                    .ToList<Noticia>();

            return ListaRetorno;
        }


        public List<Noticia> ConsultarParteTituloDinamico(String ParteTitulo, String ParteNoticia)
        {
            var ListaRetorno = new DataBaseContext()
                    .Noticia
                    .Where
                    (
                        p =>
                        (string.IsNullOrEmpty(ParteTitulo) || p.Titulo.Contains(ParteTitulo)) &&
                        (string.IsNullOrEmpty(ParteNoticia) || p.noticia.Contains(ParteNoticia))

                    ).ToList<Noticia>();


            return ListaRetorno;
        }


    }
}