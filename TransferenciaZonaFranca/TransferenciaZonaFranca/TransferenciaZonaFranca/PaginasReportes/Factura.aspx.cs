using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFranca.PaginasReportes
{
    public partial class Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                TransferenciasZF.Data.Documento Documento = new TransferenciasZF.Data.Documento();
                string Comprobante = base.Request.QueryString["C"];
                this.TextBox1.Text = Comprobante;
                List<TransferenciasZF.Data.Documento> lista = new List<TransferenciasZF.Data.Documento>();
                lista = Documento.ConsultarRutaConductorProcesoFact(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), Comprobante, this.Session["CONECTAR_A"].ToString());
                if (lista.Count > 0)
                {
                    TransferenciasZF.Data.Documento pal = new TransferenciasZF.Data.Documento();
                    DataSet DsCilindros = new DataSet();
                    DsCilindros = pal.ImpresionFacturaZF(this.TextBox1.Text.Trim(), this.Session["CONECTAR_A"].ToString());
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
            }
        }
    }
}