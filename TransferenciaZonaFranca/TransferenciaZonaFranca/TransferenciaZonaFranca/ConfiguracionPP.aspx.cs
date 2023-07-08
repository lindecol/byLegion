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
    public partial class ConfiguracionPP : System.Web.UI.Page
    {
        private static int iEmpresaId;

        private static string Conectar_a;
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static Mensaje ActualizarPP(string Codigo, double Peso, string CodigoFacturar, int Tipo)
        {
            Mensaje mensaje = new Mensaje();
            Producto Prod = new Producto();
            string msjProceso = Prod.ActualizarPP(Codigo, Peso, CodigoFacturar, Tipo, ConfiguracionPP.Conectar_a);
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
        public static List<ProductoS> ConsultarArticuloPP(string CodigoProducto, int Tipo)
        {
            List<Producto> lista = new List<Producto>();
            Producto Prod = new Producto();
            lista = Prod.ConsultarPropiaProduccion(ConfiguracionPP.iEmpresaId, CodigoProducto, Tipo, ConfiguracionPP.Conectar_a);
            return (
                from o in lista
                select new ProductoS()
                {
                    Codigo = o.Codigo,
                    Descripcion = o.Descripcion,
                    PesoPromedio = o.PesoPromedio,
                    CodigoFacturacion = o.CodigoFacturacion,
                    DesCodigoFacturacion = o.DesCodigoFacturacion,
                    Tipo = o.Tipo
                }).ToList<ProductoS>();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<IEntity> ConsultarProducto(string Codigo)
        {
            Producto Producto_ = new Producto()
            {
                Codigo = Codigo,
                EmpresaId = ConfiguracionPP.iEmpresaId,
                NombreBD = ConfiguracionPP.Conectar_a
            };
            List<IEntity> lista = new List<IEntity>();
            return Producto_.Consultar();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void EliminarProductoPP(string Codigo)
        {
            (new Producto()).EliminarProductoPP(Codigo, ConfiguracionPP.Conectar_a);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static Mensaje NuevoPP(string Codigo, double Peso, string CodigoFacturar, int Tipo)
        {
            Mensaje mensaje = new Mensaje();
            Producto Prod = new Producto();
            string msjProceso = Prod.IngresarArticuloPP(Codigo, Peso, CodigoFacturar, Tipo, ConfiguracionPP.Conectar_a);
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
            ConfiguracionPP.iEmpresaId = Convert.ToInt32(this.Session["SESSION_EMPRESA"]);
            Empresa Emp = new Empresa();
            ConfiguracionPP.Conectar_a = Emp.ConsultarConexion(this.Session["SESSION_EMPRESA"].ToString().Trim());
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static int ValidarExisteArticulo_PP(string Codigo)
        {
            return (new Producto()).ValidarExisteArticulo_PP(Codigo, ConfiguracionPP.Conectar_a);
        }
    }
}