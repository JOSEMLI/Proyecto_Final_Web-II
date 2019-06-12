using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Proyecto_Final_Web_II.Models;
using Proyecto_Final_Web_II.Filters;

namespace Proyecto_Final_Web_II.Controllers
{
    public class loginController : Controller
    {

        private Usuario usuario = new Usuario();
        // GET: login
        [NoLogin]
        // index
        public ActionResult Index()
        {
            return View();
        }



        public JsonResult validar(string usuarios, string password)
        {
            var rm = usuario.validarlogin(usuarios, password);

            if (rm.response)
            {
                rm.href = Url.Content("/principal");
            }
            return Json(rm);
        }

        public ActionResult logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/login");
        }


    }
}