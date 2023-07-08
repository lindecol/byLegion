using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;
using SoftManagement.Comunes;
using System.Web.Script.Services;
using System.Web.Services;

namespace TransferenciaZonaFrancaV2
{
    public partial class AdministracionPallets : System.Web.UI.Page
    {

        private static int iEmpresaId;

        private static string Conectar_a;

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