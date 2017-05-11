using ProdutoWeb.DAO;
using ProdutoWeb.Filtro;
using ProdutoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdutoWeb.Controllers
{
    [AcessoFilter]
    public class ClienteInvestidorController : Controller
    {
        // GET: ClienteInvestidor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PesquisaInvestidor()
        {

            return View();
        }


        public ActionResult PesquisaCliente()
        {

            return View();
        }

        [HttpPost]
        public ActionResult PesquisaCliente(Cliente ClienteDigitado)
        {

            ViewBag.ListaClientePesquisados =
                 new ClienteDAO()
                     .ConsultarDinamico(
                         ClienteDigitado.Nome,
                         ClienteDigitado.Email,
                         ClienteDigitado.Sobrenome,
                         ClienteDigitado.CPF,
                         ClienteDigitado.Telefone,
                         ClienteDigitado.Cidade.Nome);

            return View();
        }

        [HttpPost]
        public ActionResult PesquisaInvestidor(Investidor InvestidorDigitado)
        {
            
            ViewBag.ListaInvestidorPesquisados =
                new InvestidorDAO()
                    .ConsultarDinamico(
                        InvestidorDigitado.Nome,
                        InvestidorDigitado.Email, 
                        InvestidorDigitado.NomeEmpresa,
                        InvestidorDigitado.CNPJ,
                        InvestidorDigitado.Telefone,
                        InvestidorDigitado.Cidade.Nome);
                        
            return View();
        }
    }
}