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
    public class usuarioController : Controller
    {
        private Usuario objusuario = new Usuario();
        private Persona objpersona = new Persona();


        // GET: usuario
        public ActionResult Index()
        {
            return View(objusuario.listar());
        }


        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objusuario.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            ViewBag.persona = objpersona.listar();
            return View(
                id == 0 ? new Usuario() //agrega un nuevo objeto
                : objusuario.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Usuario objusuario)
        {

            if (ModelState.IsValid)
            {
                objusuario.guardar();
                return Redirect("~/usuario");
            }
            else
            {
                return View("~/Views/usuario/agregareditar.cshtml", objusuario);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objusuario.usuario_id = id;
            objusuario.eliminar();
            return Redirect("~/usuario");
        }


    }
}