using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Proyecto_Final_Web_II.Models;
using Proyecto_Final_Web_II.Filters;

namespace Proyecto_Final_Web_II.Controllers
{
    [Autenticado]
    public class perfilController : Controller
    {
        private Usuario usu = new Usuario();


        // GET: perfil
        public ActionResult Index()
        {
            return View(usu.obtener(SessionHelper.GetUser()));
        }



        public JsonResult actualizar(Usuario model, HttpPostedFileBase foto)
        {
            var rm = new ResponseModel();

            //retirar los campos que no se actualizan
            ModelState.Remove("usuario_id");
            ModelState.Remove("persona_id");
            ModelState.Remove("pas_usu");
            ModelState.Remove("nivel_usu");
            ModelState.Remove("estado_usu");


            if (ModelState.IsValid)
            {
                rm = model.guardarperfil(foto);
            }
            rm.href = Url.Content("~/principal");
            return Json(rm);
        }

    }
}