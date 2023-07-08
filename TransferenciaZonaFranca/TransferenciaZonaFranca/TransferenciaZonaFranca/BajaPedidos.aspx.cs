using System;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFranca
{
    public partial class BajaPedidos : System.Web.UI.Page
    {
        private static int iGrupoId;

        private static int iDocumentoID;

        public int bandera;
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static bool ExistePedido(string Pedidos, string Sucursal, string ConectarA)
        {
            return (new Documento()).ExistePedido(Pedidos, Sucursal, ConectarA);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (Convert.ToString(this.Session["contador"]) == string.Empty)
                {
                    if (this.Session["SESSION_EMPRESA"] == null)
                    {
                        base.Response.Redirect("Default.aspx");
                    }
                    this.Session.Add("contador", 1);
                    Label str = this.lblIdEmpresa;
                    int num = Convert.ToInt32(this.Session["SESSION_EMPRESA"]);
                    str.Text = num.ToString();
                    Convert.ToString(this.Session["SESSION_AGENCIA"]);
                    this.lblAgencia1.Text = Convert.ToString(this.Session["SESSION_AGENCIA"]);
                    this.lblNombreUsuario.Text = this.Session["SESSION_USUARIO"].ToString();
                    this.hdUsuario.Value = this.Session["SESSION_USUARIO"].ToString();
                    BajaPedidos.iGrupoId = 1;
                    BajaPedidos.iDocumentoID = 21;
                    Empresa Emp = new Empresa();
                    string Conectar_a = Emp.ConsultarConexion(this.lblIdEmpresa.Text.Trim());
                    this.Session.Add("CONECTAR_A", Conectar_a);
                    this.lblBd.Text = Conectar_a;
                    this.hdIdEmpresa.Value = this.lblIdEmpresa.Text.Trim();
                    this.hdIdSucursal.Value = this.lblAgencia1.Text.Trim();
                    return;
                }
                int TempContador = Convert.ToInt32(this.Session["contador"]) + 1;
                if (TempContador == 3)
                {
                    this.Session.Add("contador", "");
                    return;
                }
                this.Session.Add("contador", TempContador);
            }
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void ProcesarBajaPedido(string IdPedido, string Estado, string Observaciones, string Usuario, string ConectarA)
        {
            Mensaje mensaje = new Mensaje()
            {
                IdError = "01"
            };
            if (!(new Documento()).ProcesarBajaPedidos(IdPedido, Estado, Observaciones, Usuario, ConectarA))
            {
                mensaje.IdError = "02";
            }
        }
    }
}