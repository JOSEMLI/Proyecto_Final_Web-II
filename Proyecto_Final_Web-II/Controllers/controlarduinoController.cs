using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Proyecto_Final_Web_II.Models;
using Proyecto_Final_Web_II.Filters;

using System.IO.Ports;
using System.Threading;


namespace Proyecto_Final_Web_II.Controllers
{
    [Autenticado]
    public class controlarduinoController : Controller
    {
        // GET: controlarduino
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult manipulacion()
        {

            SerialPort port = new SerialPort("COM3");
            port.Open();
            port.WriteLine("ON");
            Thread.Sleep(100);
            String textport = port.ReadLine();
            Response.Write(textport);
            port.Close();

            return View();
        }



    }
}