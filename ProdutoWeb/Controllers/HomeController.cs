using ProdutoWeb.DAO;
using ProdutoWeb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdutoWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<Noticia> noticias;
            noticias = new DAO.NoticiaDAO().ListarTodos();

            IEnumerable<Estado> estados;
            estados = new DAO.EstadoDAO().ListarTodosOsEstadosDoPais(1);

            IEnumerable<Cidade> cidades;
            cidades = new DAO.CidadeDAO().ListarTodasAsCidadesDoEstado(99);

            ViewModel v = new ViewModel();
            v.noticia = noticias;
            v.estado = estados;
            v.cidade = cidades;

            return View(v);
        }

        [HttpPost]
        public ActionResult CadastrarCliente(Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                try
                {
                    new ClienteDAO().Inserir(cliente);
                }
                catch (Exception e)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Erro ao Inserir Cliente!'); location.href='/Home/Index';</script>");
                }
                   return Content("<script language='javascript' type='text/javascript'>alert('Cadastro Efetuado com Sucesso!'); location.href='/Home/Index';</script>");
            } else
            {
                return View("Index", cliente);
            }
        }

        [HttpPost]
        public ActionResult CadastrarInvestidor(Investidor investidor)
        {

            try
            {
                new InvestidorDAO().Inserir(investidor);
            }
            catch (Exception e)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Erro ao Inserir Investidor!'); location.href='/Home/Index';</script>");
            }



            return Content("<script language='javascript' type='text/javascript'>alert('Cadastro Efetuado com Sucesso!'); location.href='/Home/Index';</script>");
        }
    }
}