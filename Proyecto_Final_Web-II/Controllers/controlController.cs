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
    public class controlController : Controller
    {
        private Control objcontrol = new Control();

        // GET: control
        public ActionResult Index()
        {
            return View(objcontrol.listar());
        }



        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objcontrol.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            //ViewBag.persona = objservo.listar();
            return View(
                id == 0 ? new Control() //agrega un nuevo objeto
                : objcontrol.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Control objcontrol)
        {

            if (ModelState.IsValid)
            {
                objcontrol.guardar();
                return Redirect("~/control");
            }
            else
            {
                return View("~/Views/control/agregareditar.cshtml", objcontrol);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objcontrol.control_id = id;
            objcontrol.eliminar();
            return Redirect("~/control");
        }



    }
}