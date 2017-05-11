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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {

            IList<Usuario> n = new UsuarioDAO().ListarTodos();


            return View(n);
        }        

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Usuario u)
        {
            new UsuarioDAO().Inserir(u);


            return Content("<script language='javascript' type='text/javascript'>alert('Usuário cadastrado com Sucesso!'); location.href='/Usuario/Index';</script>");
        }

        [HttpGet]
        public ActionResult Consultar(int id)
        {

            Usuario u = new UsuarioDAO().ConsultarPorId(id);

            return View(u);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Usuario n = new UsuarioDAO().ConsultarPorId(id);

            return View(n);
        }

        [HttpPost]
        public ActionResult Editar(Usuario n)
        {
            
            new UsuarioDAO().Editar(n);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Excluir(int id)
        {
            new UsuarioDAO().Excluir(id);

            return RedirectToAction("Index");
        }
    }
}