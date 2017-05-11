using ProdutoWeb.DAO;
using ProdutoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdutoWeb.Controllers
{
    public class CidadeController : Controller
    {
        // GET: Cidade
        public JsonResult Index(int IdEstado)
        {

            IList <Cidade> lista = new CidadeDAO().ListarTodasAsCidadesDoEstado(IdEstado);
            return Json(lista , JsonRequestBehavior.AllowGet);
        }
    }
}