using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFrancaV2
{
    public partial class AdministracionPalletsCerrados : System.Web.UI.Page
    {
        private static int iEmpresaId;

        private static string Conectar_a;


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Producto> ConsultarProductoPalletCerrados(string CodigoPallet)
        {
            List<Producto> lista = new List<Producto>();
            return (
                from o in (new Producto()).ConsultarProductoPalletsCerrados(CodigoPallet, AdministracionPalletsCerrados.Conectar_a)
                select new Producto()
                {
                    Secuencia = o.Secuencia,
                    Tubo = o.Tubo,
                    Codigo = o.Codigo,
                    Descripcion = o.Descripcion,
                    Capacidad = o.Capacidad,
                    Volumen = o.Volumen
                }).ToList<Producto>();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void EliminarProductoPallet(string Codigo, string Pallet)
        {
            (new Producto()).EliminarProductoPallet(Codigo, Pallet, AdministracionPalletsCerrados.Conectar_a);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AdministracionPalletsCerrados.iEmpresaId = Convert.ToInt32(this.Session["SESSION_EMPRESA"]);
            Empresa Emp = new Empresa();
            AdministracionPalletsCerrados.Conectar_a = Emp.ConsultarConexion(this.Session["SESSION_EMPRESA"].ToString().Trim());
        }
    }
}