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
    public partial class EliminarTransferenciasOBC : System.Web.UI.Page
    {
        private static int iEmpresaId;

        private static string iAgencia;

        private static string Conectar_a;


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<TransferenciaOBC> ConsultarTransferenciasOBC(string CodigoPallet)
        {
            List<TransferenciaOBC> lista = new List<TransferenciaOBC>();
            TransferenciaOBC Transfer = new TransferenciaOBC();
            lista = Transfer.ConsultarTransferenciasOBC(CodigoPallet, EliminarTransferenciasOBC.iEmpresaId.ToString(), EliminarTransferenciasOBC.iAgencia, EliminarTransferenciasOBC.Conectar_a);
            return (
                from o in lista
                select new TransferenciaOBC()
                {
                    Ruta = o.Ruta,
                    Pallet = o.Pallet,
                    Fecha = o.Fecha
                }).ToList<TransferenciaOBC>();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void EliminarProductoPallet(string Codigo, string Pallet)
        {
            (new Producto()).EliminarProductoPallet(Codigo, Pallet, EliminarTransferenciasOBC.Conectar_a);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void EliminarTransferencia(string Codigo)
        {
            TransferenciaOBC Producto_ = new TransferenciaOBC();
            Producto_.EliminarTransferencia(Codigo, EliminarTransferenciasOBC.iEmpresaId.ToString(), EliminarTransferenciasOBC.iAgencia, EliminarTransferenciasOBC.Conectar_a);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            EliminarTransferenciasOBC.iEmpresaId = Convert.ToInt32(this.Session["SESSION_EMPRESA"]);
            EliminarTransferenciasOBC.iAgencia = this.Session["SESSION_AGENCIA"].ToString();
            Empresa Emp = new Empresa();
            EliminarTransferenciasOBC.Conectar_a = Emp.ConsultarConexion(this.Session["SESSION_EMPRESA"].ToString().Trim());
        }
    }
}