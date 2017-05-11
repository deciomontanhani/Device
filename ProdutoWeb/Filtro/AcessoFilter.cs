using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdutoWeb.Filtro
{
    public class AcessoFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.Session.Contents["UsuarioLogado"] == null)
            {
                filterContext.Controller.TempData.Add("Mensagem", "Sessão Expirada! Efetue o login novamente.");
                Controller controller = filterContext.Controller as Controller;
                controller.HttpContext.Response.Redirect("/Admin");
            }
            base.OnActionExecuting(filterContext);
        }

    }
}