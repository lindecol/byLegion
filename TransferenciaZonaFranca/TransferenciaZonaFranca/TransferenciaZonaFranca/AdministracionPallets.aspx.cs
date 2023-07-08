using SoftManagement.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFranca
{
    public partial class AdministracionPallets : System.Web.UI.Page
    {
        private static string Conectar_a;
        private static int iEmpresaId;

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static Mensaje ActualizarPallet(string Codigo, string Estado, string Observaciones)
        {
            Mensaje mensaje = new Mensaje();
            Pallet Prod = new Pallet();
            string msjProceso = Prod.ActualizarPallet(Codigo, Estado, Observaciones, AdministracionPallets.Conectar_a);
            if (msjProceso == "")
            {
                mensaje.IdError = "01";
                mensaje.MensajeError = "";
            }
            else
            {
                mensaje.IdError = "02";
                mensaje.MensajeError = msjProceso;
            }
            return mensaje;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Pallet> ConsultarPallets(string CodigoPallet)
        {
            List<Pallet> lista = new List<Pallet>();
            return (
                from o in (new Pallet()).ConsultarPallets(CodigoPallet, AdministracionPallets.Conectar_a)
                select new Pallet()
                {
                    IdPallet = o.IdPallet,
                    Estado = o.Estado,
                    Observaciones = o.Observaciones
                }).ToList<Pallet>();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<IEntity> ConsultarProducto(string Codigo)
        {
            Producto Producto_ = new Producto()
            {
                Codigo = Codigo,
                EmpresaId = AdministracionPallets.iEmpresaId,
                NombreBD = AdministracionPallets.Conectar_a
            };
            List<IEntity> lista = new List<IEntity>();
            return Producto_.Consultar();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void EliminarPallet(string Codigo)
        {
            (new Pallet()).EliminarPallet(Codigo, AdministracionPallets.Conectar_a);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void LiberarPallet(string Codigo)
        {
            (new Pallet()).LiberarPallet(Codigo, AdministracionPallets.Conectar_a);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static Mensaje NuevoPallet(string Codigo, string Estado, string Observaciones)
        {
            Mensaje mensaje = new Mensaje();
            Pallet Prod = new Pallet();
            string msjProceso = Prod.IngresarPallet(Codigo, Estado, Observaciones, AdministracionPallets.Conectar_a);
            if (msjProceso == "")
            {
                mensaje.IdError = "01";
                mensaje.MensajeError = "";
            }
            else
            {
                mensaje.IdError = "02";
                mensaje.MensajeError = msjProceso;
            }
            return mensaje;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AdministracionPallets.iEmpresaId = Convert.ToInt32(this.Session["SESSION_EMPRESA"]);
            this.lblemp.Text = this.Session["SESSION_EMPRESA"].ToString();
            Empresa Emp = new Empresa();
            AdministracionPallets.Conectar_a = Emp.ConsultarConexion(this.lblemp.Text.Trim());
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static int ValidarExistePallet(string Codigo)
        {
            return (new Pallet()).ValidarExistePallet(Codigo, AdministracionPallets.Conectar_a);
        }
    }
}