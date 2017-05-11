using ProdutoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdutoWeb.DAO
{

    public class ClienteDAO
    {

        public IList<Cliente> ListarTodos()
        {
            return new DataBaseContext().Cliente.ToList<Cliente>();
        }

        public Cliente ConsultarPorId(int Id)
        {
            return new DataBaseContext().Cliente.Find(Id);
        }

        public void Inserir(Cliente C)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Cliente.Add(C);
            DBContext.SaveChanges();
        }

        public void Editar(Cliente C)
        {
            DataBaseContext DBContext = new DataBaseContext();
            DBContext.Entry(C).State = System.Data.Entity.EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            DataBaseContext DBContext = new DataBaseContext();
            Cliente Cliente = ConsultarPorId(Id);
            DBContext.Entry(Cliente).State = System.Data.Entity.EntityState.Deleted;
            DBContext.SaveChanges();
        }


        public Cliente ConsultarPorNome(String Nome)
        {
            Cliente Cliente = new Cliente();

            try
            {
                DataBaseContext DBContext = new DataBaseContext();
                Cliente = DBContext.Cliente.Where(p => p.Nome == Nome).SingleOrDefault<Cliente>();
            }
            catch (Exception ex)
            {
                Cliente = new Cliente();
            }

            return Cliente;
        }

        public List<Cliente> ConsultarDinamico(String Nome, String Email, String Sobrenome, String CPF, String Telefone, String NomeCidade)
        {
            var ListaRetorno = new DataBaseContext()
                    .Cliente
                    .Include("Cidade")
                    .Where
                    (
                        p =>
                        (string.IsNullOrEmpty(Nome) || p.Nome.Contains(Nome)) &&
                        (string.IsNullOrEmpty(Email) || p.Email.Contains(Email)) &&
                        (string.IsNullOrEmpty(Sobrenome) || p.Sobrenome.Contains(Sobrenome)) &&
                        (string.IsNullOrEmpty(CPF) || p.CPF.Contains(CPF)) &&
                        (string.IsNullOrEmpty(Telefone) || p.Telefone.Contains(Telefone)) &&
                        (string.IsNullOrEmpty(NomeCidade) || p.Cidade.Nome.Contains(NomeCidade))

                    ).ToList<Cliente>();


            return ListaRetorno;
        }

    }
}