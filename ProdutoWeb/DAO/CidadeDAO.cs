using ProdutoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdutoWeb.DAO
{
    public class CidadeDAO
    {

        public IList<Cidade> ListarTodasAsCidadesDoEstado(int idEstado)
        {
            if (idEstado == 99)
            {
                IList<Cidade> cidades = new List<Cidade>
                {
                new Cidade {CidadeId = 10000, Nome = "Selecione um Estado", EstadoId = 99  }
                };

                return cidades;
            }

            IList<Cidade> lista = new DataBaseContext().Cidade.Where(p => p.EstadoId == idEstado).ToList<Cidade>();

            return lista;
            
           
        }

        public Cidade ConsultarPorId(int Id)
        {
            return new DataBaseContext().Cidade.Find(Id);
        }

        public void Inserir(Cidade C)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Cidade.Add(C);
            DBContext.SaveChanges();
        }

        public void Editar(Cidade C)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Entry(C).State = System.Data.Entity.EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            DataBaseContext DBContext = new DataBaseContext();
            Cidade Cidade = ConsultarPorId(Id);
            DBContext.Entry(Cidade).State = System.Data.Entity.EntityState.Deleted;
            DBContext.SaveChanges();
        }


        public Cidade ConsultarPorNome(String Nome)
        {
            Cidade Cidade = new Cidade();

            try
            {
                DataBaseContext DBContext = new DataBaseContext();
                Cidade = DBContext.Cidade.Where(p => p.Nome == Nome).SingleOrDefault<Cidade>();
            }
            catch (Exception ex)
            {
                Cidade = new Cidade();
            }

            return Cidade;
        }

    }
}