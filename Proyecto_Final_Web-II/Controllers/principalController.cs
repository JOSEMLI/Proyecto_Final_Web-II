using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Proyecto_Final_Web_II.Filters;

namespace Proyecto_Final_Web_II.Controllers
{
    [Autenticado]
    public class principalController : Controller
    {
        // GET: principal
        public ActionResult Index()
        {
            return View();
        }
    }
}