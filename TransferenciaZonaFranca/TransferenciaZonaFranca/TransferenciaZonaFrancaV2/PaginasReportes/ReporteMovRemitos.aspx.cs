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


namespace TransferenciaZonaFrancaV2.PaginasReportes
{
    public partial class ReporteMovRemitos : System.Web.UI.Page
    {
        private static string Conectar_a;

        static ReporteMovRemitos()
        {
            ReporteMovRemitos.Conectar_a = "ConexionOracle";
        }

        public ReporteMovRemitos()
        {
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            Empresa empresa = new Empresa();
            ReporteMovRemitos.Conectar_a = empresa.ConsultarConexion(this.lblEmpresa.Text.Trim());
            Empresa empresa1 = new Empresa();
            Sucursal sucursal = new Sucursal();
            List<Documento> documentos = new List<Documento>();
            Documento documento = new Documento();
            string str = empresa1.ConsultarEmpresaPorId(this.lblEmpresa.Text, ReporteMovRemitos.Conectar_a);
            string str1 = sucursal.ConsultarSucursalPorId(this.lblEmpresa.Text.ToString(), this.lblAgencia.Text, ReporteMovRemitos.Conectar_a);
            Pallet pallet = new Pallet();
            DataSet dataSet = new DataSet();
            dataSet = pallet.MovimientosInterCompañia(this.txtFecha1.Text, this.txtFecha2.Text, this.lblAgencia.Text, this.lblUsuario.Text, ReporteMovRemitos.Conectar_a);
            ReportDataSource reportDataSource = new ReportDataSource()
            {
                Name = "DataSet1",
                Value = dataSet.Tables[0]
            };
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.ReportViewer1.LocalReport.ReportPath = "Reportes\\Rpttransferencias_ZF.rdlc";
            this.ReportViewer1.LocalReport.Refresh();
            ReportParameter[] reportParameter = new ReportParameter[] { new ReportParameter("P_FECHA1", this.txtFecha1.Text), new ReportParameter("P_FECHA2", this.txtFecha2.Text), new ReportParameter("P_EMPRESAORIGEN", str), new ReportParameter("P_AGENCIAORIGEN", str1) };
            this.ReportViewer1.LocalReport.SetParameters(reportParameter);
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