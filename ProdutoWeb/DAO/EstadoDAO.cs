using ProdutoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdutoWeb.DAO
{
    public class EstadoDAO
    {

        public IList<Estado> ListarTodosOsEstadosDoPais(int idPais)
        {
            /*
            IList<Estado> estados = new List<Estado>
            {
                new Estado {EstadoId = 1, Nome = "AC - Acre" },
                new Estado {EstadoId = 2, Nome = "AM - Amazonas" },
                new Estado {EstadoId = 3, Nome = "SP - São Paulo" }

            };

            return estados;*/
             
            return new DataBaseContext().Estado.Where(p => p.id_pais == idPais).ToList<Estado>();
        }

        public Estado ConsultarPorId(int Id)
        {


            return new DataBaseContext().Estado.Find(Id);
        }

        public void Inserir(Estado C)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Estado.Add(C);
            DBContext.SaveChanges();
        }

        public void Editar(Estado C)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Entry(C).State = System.Data.Entity.EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            DataBaseContext DBContext = new DataBaseContext();
            Estado Estado = ConsultarPorId(Id);
            DBContext.Entry(Estado).State = System.Data.Entity.EntityState.Deleted;
            DBContext.SaveChanges();
        }


        public Estado ConsultarPorNome(String Nome)
        {
            Estado Estado = new Estado();

            try
            {
                DataBaseContext DBContext = new DataBaseContext();
                Estado = DBContext.Estado.Where(p => p.Nome == Nome).SingleOrDefault<Estado>();
            }
            catch (Exception ex)
            {
                Estado = new Estado();
            }

            return Estado;
        }
    }
}