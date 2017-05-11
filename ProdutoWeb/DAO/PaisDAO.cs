using ProdutoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdutoWeb.DAO
{
    public class PaisDAO
    {
        public IList<Pais> ListarTodos()


        {
            return new DataBaseContext().Pais.Include("Estado").ToList<Pais>();
            //return new DataBaseContext().Pais.ToList<Pais>();
        }

        public Pais ConsultarPorId(int Id)
        {
            return new DataBaseContext().Pais.Find(Id);
        }

        public void Inserir(Pais C)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Pais.Add(C);
            DBContext.SaveChanges();
        }

        public void Editar(Pais C)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Entry(C).State = System.Data.Entity.EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            DataBaseContext DBContext = new DataBaseContext();
            Pais Pais = ConsultarPorId(Id);
            DBContext.Entry(Pais).State = System.Data.Entity.EntityState.Deleted;
            DBContext.SaveChanges();
        }


        public Pais ConsultarPorNome(String Nome)
        {
            Pais Pais = new Pais();

            try
            {
                DataBaseContext DBContext = new DataBaseContext();
                Pais = DBContext.Pais.Where(p => p.nome == Nome).SingleOrDefault<Pais>();
            }
            catch (Exception ex)
            {
                Pais = new Pais();
            }

            return Pais;
        }

    }
}