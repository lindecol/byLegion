using AjaxControlToolkit;
using Microsoft.Reporting.WebForms;
using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFranca.PaginasReportes
{
    public partial class RecoleccionesAsignaciones : System.Web.UI.Page
    {
        private static string Conectar_a;

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            Documento doc = new Documento();
            this.Pro.Visible = true;
            doc.ProcesarRecolecciones_Asignaciones(this.txtFecha1.Text, this.txtFecha2.Text, this.Session["SESSION_AGENCIA"].ToString(), this.Session["CONECTAR_A"].ToString());
            this.Pro.Visible = false;
            Empresa Emp = new Empresa();
            RecoleccionesAsignaciones.Conectar_a = Emp.ConsultarConexion(this.lblEmpresa.Text.Trim());
            ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("P_FECHA1", this.txtFecha1.Text), new ReportParameter("P_FECHA2", this.txtFecha2.Text) };
            this.ReportViewer1.LocalReport.SetParameters(parametros);
            this.ReportViewer1.Dispose();
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