using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TransferenciaZonaFranca.PaginasReportes
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string Comprobante = base.Request.QueryString["C"];
                string Ruta = base.Request.QueryString["R"];
                this.TextBox1.Text = Comprobante;
                string str = DateTime.Now.Hour.ToString();
                int minute = DateTime.Now.Minute;
                string Hour = string.Concat(str, ":", minute.ToString());
                ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("USUARIO", this.Session["SESSION_USUARIO"].ToString()), new ReportParameter("RUTA", Ruta), new ReportParameter("HORA", Hour) };
                this.ReportViewer1.LocalReport.SetParameters(parametros);
            }
        }
    }
}