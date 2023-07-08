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


namespace TransferenciaZonaFrancaV2.PaginasReportes
{
    public partial class Factura : System.Web.UI.Page
    {
        public Factura()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                Documento documento = new Documento();
                string item = base.Request.QueryString["C"];
                this.TextBox1.Text = item;
                List<Documento> documentos = new List<Documento>();
                documentos = documento.ConsultarRutaConductorProcesoFact(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), item, this.Session["CONECTAR_A"].ToString());
                if (documentos.Count > 0)
                {
                    Documento documento1 = new Documento();
                    DataSet dataSet = new DataSet();
                    dataSet = documento1.ImpresionFacturaZF(this.TextBox1.Text.Trim(), this.Session["CONECTAR_A"].ToString());
                    ReportDataSource reportDataSource = new ReportDataSource()
                    {
                        Name = "DataSet1",
                        Value = dataSet.Tables[0]
                    };
                    this.ReportViewer1.LocalReport.DataSources.Clear();
                    this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                    this.ReportViewer1.LocalReport.ReportPath = "Reportes\\ReporteFactura.rdlc";
                    this.ReportViewer1.LocalReport.Refresh();
                    ReportParameter[] reportParameter = new ReportParameter[] { new ReportParameter("USUARIO", this.Session["SESSION_USUARIO"].ToString()), new ReportParameter("RUTA", documentos[0].CodigoRuta), new ReportParameter("PLACA", documentos[0].Vehiculo) };
                    this.ReportViewer1.LocalReport.SetParameters(reportParameter);
                }
            }
        }
    }
}