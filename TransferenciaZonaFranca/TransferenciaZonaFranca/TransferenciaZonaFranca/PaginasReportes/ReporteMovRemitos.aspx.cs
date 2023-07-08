using AjaxControlToolkit;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFranca.PaginasReportes
{
    public partial class ReporteMovRemitos : System.Web.UI.Page
    {
        private static string Conectar_a;
        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            Empresa Emp = new Empresa();
            ReporteMovRemitos.Conectar_a = Emp.ConsultarConexion(this.lblEmpresa.Text.Trim());
            Empresa empresa = new Empresa();
            Sucursal sucursal = new Sucursal();
            List<Documento> documentos = new List<Documento>();
            Documento documento = new Documento();
            string strNombreEmpresa = empresa.ConsultarEmpresaPorId(this.lblEmpresa.Text, ReporteMovRemitos.Conectar_a);
            string strNombreSucursal = sucursal.ConsultarSucursalPorId(this.lblEmpresa.Text.ToString(), this.lblAgencia.Text, ReporteMovRemitos.Conectar_a);
            Pallet pal = new Pallet();
            DataSet DsCilindros = new DataSet();
            DsCilindros = pal.MovimientosInterCompañia(this.txtFecha1.Text, this.txtFecha2.Text, this.lblAgencia.Text, this.lblUsuario.Text, ReporteMovRemitos.Conectar_a);
            ReportDataSource rds = new ReportDataSource()
            {
                Name = "DataSet1",
                Value = DsCilindros.Tables[0]
            };
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            this.ReportViewer1.LocalReport.ReportPath = "Reportes\\Rpttransferencias_ZF.rdlc";
            this.ReportViewer1.LocalReport.Refresh();
            ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("P_FECHA1", this.txtFecha1.Text), new ReportParameter("P_FECHA2", this.txtFecha2.Text), new ReportParameter("P_EMPRESAORIGEN", strNombreEmpresa), new ReportParameter("P_AGENCIAORIGEN", strNombreSucursal) };
            this.ReportViewer1.LocalReport.SetParameters(parametros);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.ReportViewer1.Visible = false;
            }
            this.lblEmpresa.Text = this.Session["SESSION_EMPRESA"].ToString();
            this.lblSubdeposito.Text = "";
            this.lblAgencia.Text = this.Session["SESSION_AGENCIA"].ToString();
            this.lblUsuario.Text = this.Session["SESSION_USUARIO"].ToString();
        }
    }
}