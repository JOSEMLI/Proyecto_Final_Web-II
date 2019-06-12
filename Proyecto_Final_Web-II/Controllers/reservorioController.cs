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
    public class reservorioController : Controller
    {
        private Reservorio objreservorio = new Reservorio();

        // GET: reservorio
        public ActionResult Index()
        {
            return View(objreservorio.listar());
        }




        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objreservorio.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            //ViewBag.persona = objservo.listar();
            return View(
                id == 0 ? new Reservorio() //agrega un nuevo objeto
                : objreservorio.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Reservorio objreservorio)
        {

            if (ModelState.IsValid)
            {
                objreservorio.guardar();
                return Redirect("~/reservorio");
            }
            else
            {
                return View("~/Views/reservorio/agregareditar.cshtml", objreservorio);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objreservorio.reservorio_id = id;
            objreservorio.eliminar();
            return Redirect("~/reservorio");
        }



    }
}