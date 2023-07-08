using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VisorCopagos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarCopagos(int empresa, DateTime fI, DateTime fF)
        {
            var salida = Copago.Negocio.Servicio.ListarCopagos(empresa, fI, fF);
            return base.Json(salida, JsonRequestBehavior.AllowGet);
        }
    }
}