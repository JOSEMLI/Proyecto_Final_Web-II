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
    public class personaController : Controller
    {
        private Persona objpersona = new Persona();
        private Usuario objusuario = new Usuario();

        // GET: persona
        public ActionResult Index()
        {
            return View(objpersona.listar());
        }


        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objpersona.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            //ViewBag.persona = objpersona.listar();
            return View(
                id == 0 ? new Persona() //agrega un nuevo objeto
                : objpersona.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Persona objpersona)
        {

            if (ModelState.IsValid)
            {
                objpersona.guardar();
                return Redirect("~/persona");
            }
            else
            {
                return View("~/Views/persona/agregareditar.cshtml", objpersona);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objpersona.persona_id = id;
            objpersona.eliminar();
            return Redirect("~/persona");
        }



    }
}