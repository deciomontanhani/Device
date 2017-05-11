using ProdutoWeb.DAO;
using ProdutoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdutoWeb.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Usuario UsuarioLogin)
        {

            // Chamada do DAO


            Usuario UsuarioLogado = new UsuarioDAO().Login(UsuarioLogin);

            if (UsuarioLogado != null)
            {
                // Usuario Encontrado e Login efetuado com sucesso.

                // Adicionando o usuário na Sessão
                Session["UsuarioLogado"] = UsuarioLogado;

                // Exibindo a Tela com Login
                return RedirectToAction("Index", "Noticia");
            }

            // Falha no Login
            else
            {
                TempData["Mensagem"] = "Usuário ou Senha inválida.";
                return View("Index", UsuarioLogin);
            }

        }



        public ActionResult Logoff()
        {
            Session.Clear();

            return View("Index");
        }

    }
}