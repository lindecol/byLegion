using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VisorCopagosVPrint.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarCopagosOld(DateTime fI, DateTime fF, string cliente, bool estado)
        {
            var salida = Copago.Negocio.Servicio.ListarCopagos(fI, fF, cliente, estado);


            return base.Json(salida, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListarCopagos(string cliente, bool estado)
        {
            var salida = Copago.Negocio.Servicio.ListarCopagos(cliente, estado);


            return base.Json(salida, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AdicionarCopago(string documento, string empresa, string cliente, int estado, string copago)
        {
            var salida = Copago.Negocio.Servicio.ActualizarCopago(documento, empresa, cliente, estado, copago);
            return base.Json(salida, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AgendarCopago(string documento)
        {
            var salida = Copago.Negocio.Servicio.AgendarCopago(documento);
            return base.Json(salida, JsonRequestBehavior.AllowGet);
        }


    }
}