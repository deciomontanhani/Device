using ProdutoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdutoWeb.DAO
{
    public class InvestidorDAO
    {

        public IList<Investidor> ListarTodos()
        {
            return new DataBaseContext().Investidor.ToList<Investidor>();
        }

        public Investidor ConsultarPorId(int Id)
        {
            return new DataBaseContext().Investidor.Find(Id);
        }

        public void Inserir(Investidor I)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Investidor.Add(I);
            DBContext.SaveChanges();
        }

        public void Editar(Investidor I)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Entry(I).State = System.Data.Entity.EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            DataBaseContext DBContext = new DataBaseContext();
            Investidor Investidor = ConsultarPorId(Id);
            DBContext.Entry(Investidor).State = System.Data.Entity.EntityState.Deleted;
            DBContext.SaveChanges();
        }


        public Investidor ConsultarPorNome(String Nome)
        {
            Investidor Investidor = new Investidor();

            try
            {
                DataBaseContext DBContext = new DataBaseContext();
                Investidor = DBContext.Investidor.Where(p => p.Nome == Nome).SingleOrDefault<Investidor>();
            }
            catch (Exception ex)
            {
                Investidor = new Investidor();
            }

            return Investidor;
        }

        public List<Investidor> ConsultarDinamico(String Nome, String Email, String Empresa, String CNPJ, String Telefone, String NomeCidade)
        {
            var ListaRetorno = new DataBaseContext()
                    .Investidor
                    .Include("Cidade")
                    .Where
                    (
                        p =>
                        (string.IsNullOrEmpty(Nome) || p.Nome.Contains(Nome)) &&
                        (string.IsNullOrEmpty(Email) || p.Email.Contains(Email)) &&
                        (string.IsNullOrEmpty(Empresa) || p.NomeEmpresa.Contains(Empresa)) &&
                        (string.IsNullOrEmpty(CNPJ) || p.CNPJ.Contains(CNPJ)) &&
                        (string.IsNullOrEmpty(Telefone) || p.Telefone.Contains(Telefone)) &&
                        (string.IsNullOrEmpty(NomeCidade) || p.Cidade.Nome.Contains(NomeCidade))

                    ).ToList<Investidor>();


            return ListaRetorno;
        }
    }
}