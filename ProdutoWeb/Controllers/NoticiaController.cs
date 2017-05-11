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
    public class NoticiaController : Controller
    {
        // GET: Noticia
        public ActionResult Index()
        {

            IList<Noticia> n = new NoticiaDAO().ListarTodos();


            return View(n);
        }

        public ActionResult Pesquisa()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Pesquisa(Noticia NoticiaDigitada)
        {

            ViewBag.ListaNoticiaPesquisados =
                new NoticiaDAO()
                    .ConsultarParteTituloDinamico(
                        NoticiaDigitada.Titulo,
                        NoticiaDigitada.noticia);

            return View();
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Noticia n)
        {
            new NoticiaDAO().Inserir(n);


            return Content("<script language='javascript' type='text/javascript'>alert('Noticia cadastrada com Sucesso!'); location.href='/Noticia/Index';</script>");
        }

        [HttpGet]
        public ActionResult Consultar(int id)
        {

            Noticia n = new NoticiaDAO().ConsultarPorId(id);

            return View(n);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Noticia n = new NoticiaDAO().ConsultarPorId(id);

            return View(n);
        }

        [HttpPost]
        public ActionResult Editar(Noticia n)
        {

            n.Id_Usuario = 1;
            new NoticiaDAO().Editar(n);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Excluir(int id)
        {
            new NoticiaDAO().Excluir(id);

            return RedirectToAction("Index");
        }
    }
}