using AjaxControlToolkit;
using Microsoft.Reporting.WebForms;
using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;


namespace TransferenciaZonaFrancaV2.PaginasReportes
{
    public partial class ReportesPedidos : System.Web.UI.Page
    {
        private static string Conectar_a;

        static ReportesPedidos()
        {
            ReportesPedidos.Conectar_a = "ConexionOracleCOOX";
        }

        public ReportesPedidos()
        {
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            if (this.txtSucursal.Text.Length == 0)
            {
                this.txtSucursal.Text = " ";
            }
            Empresa empresa = new Empresa();
            ReportesPedidos.Conectar_a = empresa.ConsultarConexion(this.lblEmpresa.Text.Trim());
            string selectedValue = this.cmbEstado.SelectedValue;
            if (this.chkTodos.Checked)
            {
                if (this.cmbBuscarPor.SelectedValue != "G")
                {
                    this.ObjectDataSource1.TypeName = "TransferenciasZF.DsPedidosTableAdapters.PedidoGralTableAdapter";
                }
                else
                {
                    this.ObjectDataSource1.TypeName = " TransferenciasZF.DsPedidosTableAdapters.PedPorFechaGenTableAdapter";
                }
            }
            else if (this.cmbBuscarPor.SelectedValue != "E")
            {
                this.ObjectDataSource1.TypeName = " TransferenciasZF.DsPedidosTableAdapters.PedGralxSucursalTableAdapter";
            }
            else
            {
                this.ObjectDataSource1.TypeName = " TransferenciasZF.DsPedidosTableAdapters.PedPorFechaGen_SucTableAdapter";
            }
            ReportParameter[] reportParameter = new ReportParameter[] { new ReportParameter("P_FECHA1", this.txtFecha1.Text), new ReportParameter("P_FECHA2", this.txtFecha2.Text), new ReportParameter("P_BUSCAR", this.cmbBuscarPor.SelectedValue), new ReportParameter("P_ESTADO", this.cmbEstado.SelectedValue) };
            this.ReportViewer1.LocalReport.SetParameters(reportParameter);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.ReportViewer1.Visible = false;
                this.lblEmpresa.Text = this.Session["SESSION_EMPRESA"].ToString();
                this.lblSubdeposito.Text = "";
                this.lblAgencia.Text = this.Session["SESSION_AGENCIA"].ToString();
                this.lblUsuario.Text = this.Session["SESSION_USUARIO"].ToString();
            }
        }
    }
}