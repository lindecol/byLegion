using AjaxControlToolkit;
using ControlPaqueteNet.WsPraxair;
using Microsoft.Reporting.WebForms;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlPaqueteNet.Pages
{
    public partial class ReporteEstadistica : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private AccesoDatos oData;

        public void btnScript_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.lblError.Visible = false;
                if (!(this.cmbTipoProgramacion.SelectedIndex == 0 & Operators.CompareString(this.txtFechaInicio.Text, "", false) == 0 & Operators.CompareString(this.txtFechaFin.Text, "", false) == 0))
                {
                    if (Operators.CompareString(this.txtFechaInicio.Text, "", false) != 0)
                    {
                        if (Operators.CompareString(this.txtFechaFin.Text, "", false) == 0)
                        {
                            this.MensajeError("Debe colocar la fecha inicio y la fecha fin");
                            return;
                        }
                        else if (DateTime.Compare(Conversions.ToDate(this.txtFechaFin.Text), Conversions.ToDate(this.txtFechaInicio.Text)) < 0)
                        {
                            this.MensajeError("La fecha de inicio debe ser menor que la fecha fin");
                            return;
                        }
                    }
                    if (Operators.CompareString(this.txtFechaFin.Text, "", false) != 0)
                    {
                        if (Operators.CompareString(this.txtFechaInicio.Text, "", false) == 0)
                        {
                            this.MensajeError("Debe colocar la fecha inicio y la fecha fin");
                            return;
                        }
                        else if (DateTime.Compare(Conversions.ToDate(this.txtFechaFin.Text), Conversions.ToDate(this.txtFechaInicio.Text)) < 0)
                        {
                            this.MensajeError("La fecha de inicio debe ser menor que la fecha fin");
                            return;
                        }
                    }
                    DataSet dsReporte = new DataSet();
                    dsReporte = this.oData.Consulta_tabla_estadisticas(this.txtFechaInicio.Text, this.txtFechaFin.Text, Conversions.ToString(this.Session["Conexion"]), "pck_ocpp_reportes.pr_lista_estadisticas", this.cmbTipoProgramacion.SelectedValue, "", Conversions.ToString(this.Session["Agencia"]), "");
                    this.rvReporte.LocalReport.DataSources.Clear();
                    if (dsReporte.Tables[0].Rows.Count <= 0)
                    {
                        this.rvReporte.Visible = false;
                    }
                    else
                    {
                        this.rvReporte.Visible = true;
                        ReportDataSource dataSource = new ReportDataSource("Reporte_Estadisticas_OCPP_REPORTE_ESTADISTICAS", dsReporte.Tables[0]);
                        this.rvReporte.LocalReport.DataSources.Add(dataSource);
                        this.rvReporte.LocalReport.Refresh();
                        this.txtFechaFin.Text = "";
                        this.txtFechaInicio.Text = "";
                        this.cmbTipoProgramacion.SelectedIndex = 0;
                    }
                    return;
                }
                else
                {
                    this.MensajeError("Debe escoger un tipo de búsqueda para el conteo");
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                this.rvReporte.LocalReport.DataSources.Clear();
                this.rvReporte.LocalReport.Refresh();
                this.rvReporte.Visible = false;
                this.txtFechaFin.Text = "";
                this.txtFechaInicio.Text = "";
                this.cmbTipoProgramacion.SelectedIndex = 0;
                ProjectData.ClearProjectError();
                return;
            }
        }

        private void MensajeError(string mensaje)
        {
            this.lblError.Visible = true;
            this.lblError.Text = mensaje;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.objSeg.Credentials = CredentialCache.DefaultCredentials;
            this.oData = new AccesoDatos();
            //if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
            if (!Operators.ConditionalCompareObjectNotEqual(this.Session[7], "", false))
            {
                this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
            }
            //else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_REPEST"), "0", false) == 0)
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session[2]), "CP_REPEST"), "0", false) == 0)
            {
                this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
            }
        }
    }
}
