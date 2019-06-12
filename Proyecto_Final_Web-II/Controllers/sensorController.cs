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
    public class sensorController : Controller
    {
        private Sensor objsensor = new Sensor();

        // GET: sensor
        public ActionResult Index()
        {
            return View(objsensor.listar());
        }



        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objsensor.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            //ViewBag.persona = objservo.listar();
            return View(
                id == 0 ? new Sensor() //agrega un nuevo objeto
                : objsensor.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Sensor objsensor)
        {

            if (ModelState.IsValid)
            {
                objsensor.guardar();
                return Redirect("~/sensor");
            }
            else
            {
                return View("~/Views/sensor/agregareditar.cshtml", objsensor);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objsensor.sensor_id = id;
            objsensor.eliminar();
            return Redirect("~/sensor");
        }



    }
}