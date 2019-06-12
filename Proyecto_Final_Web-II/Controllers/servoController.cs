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
    public class servoController : Controller
    {
        private Servo objservo = new Servo();

        // GET: servo
        public ActionResult Index()
        {
            return View(objservo.listar());
        }



        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objservo.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            //ViewBag.persona = objservo.listar();
            return View(
                id == 0 ? new Servo() //agrega un nuevo objeto
                : objservo.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Servo objservo)
        {

            if (ModelState.IsValid)
            {
                objservo.guardar();
                return Redirect("~/servo");
            }
            else
            {
                return View("~/Views/servo/agregareditar.cshtml", objservo);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objservo.servo_id = id;
            objservo.eliminar();
            return Redirect("~/servo");
        }



    }
}