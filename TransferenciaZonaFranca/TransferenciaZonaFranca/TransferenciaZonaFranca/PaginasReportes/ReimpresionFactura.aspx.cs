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
    public partial class ReimpresionFactura : System.Web.UI.Page
    {
        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            TransferenciasZF.Data.Documento Documento = new TransferenciasZF.Data.Documento();
            string Conectar_a = "ConexionOracle";
            Empresa Emp = new Empresa();
            Conectar_a = Emp.ConsultarConexion(this.Session["SESSION_EMPRESA"].ToString().Trim());
            List<TransferenciasZF.Data.Documento> lista = new List<TransferenciasZF.Data.Documento>();
            lista = Documento.ConsultarRutaConductorProcesoFact(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), this.TextBox1.Text.Trim(), Conectar_a);
            if (lista.Count <= 0)
            {
                this.ReportViewer1.Visible = false;
                this.lblmsj.Text = "Factura No encontrada";
                return;
            }
            TransferenciasZF.Data.Documento pal = new TransferenciasZF.Data.Documento();
            DataSet DsCilindros = new DataSet();
            DsCilindros = pal.ImpresionFacturaZF(this.TextBox1.Text.Trim(), Conectar_a);
            ReportDataSource rds = new ReportDataSource()
            {
                Name = "DataSet1",
                Value = DsCilindros.Tables[0]
            };
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            this.ReportViewer1.LocalReport.ReportPath = "Reportes\\ReporteFactura.rdlc";
            this.ReportViewer1.LocalReport.Refresh();
            ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("USUARIO", this.Session["SESSION_USUARIO"].ToString()), new ReportParameter("RUTA", lista[0].CodigoRuta), new ReportParameter("PLACA", lista[0].Vehiculo) };
            this.ReportViewer1.LocalReport.SetParameters(parametros);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.ReportViewer1.Visible = false;
            }
        }
    }
}