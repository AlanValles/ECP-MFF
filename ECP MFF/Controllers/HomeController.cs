using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECP_MFF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Evaluacion()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Machote()
        {
            ViewBag.Message = "Seccion para revisar machotes, por favor escane o digite manualmente el numero que aparece en el codigo de barras";

            return View();
        }
    }
}