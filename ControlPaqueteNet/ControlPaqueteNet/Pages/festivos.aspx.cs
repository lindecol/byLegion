using ControlPaqueteNet.WsPackage;
using ControlPaqueteNet.WsPraxair;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    public partial class festivos : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();


        private void CargarSucursales()
        {
            try
            {
                this.lblError.Visible = false;
                //DataSet ConsultarSucursales = this.wsData.ConsultarSucursales(Conversions.ToString(this.Session["Conexion"]), -777, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
                DataSet ConsultarSucursales = this.wsData.ConsultarSucursales(Conversions.ToString(this.Session[7]), -777, Conversions.ToInteger(this.Session[3]), Conversions.ToInteger(this.Session[4]));
                if (ConsultarSucursales.Tables[0].Rows.Count > 0)
                {
                    this.cmbSucursal.DataSource = ConsultarSucursales.Tables[0];
                    this.cmbSucursal.DataBind();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        public void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chkSabado.Checked = false;
            this.chkDomingo.Checked = false;
            this.LimpiarCalendario();
            this.ConsultarCalendario();
        }

        private void Configuracion()
        {
            this.CargarSucursales();
            List<DateTime> lstFechas = new List<DateTime>();
            this.Session["Calendario"] = lstFechas;
            List<DateTime> lstFechasEnviar = new List<DateTime>();
            this.Session["CalendarioEnviar"] = lstFechasEnviar;
        }

        private void ConsultarCalendario()
        {
            try
            {
                this.LimpiarCalendario();
                DataSet Consulta = this.wsData.ConsultarFestivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
                List<DateTime> lstFechas = new List<DateTime>();
                this.Session["esFestivoSabado"] = false;
                this.Session["esFestivoDomingo"] = false;
                if (Consulta.Tables[0].Rows.Count <= 0)
                {
                    this.LimpiarCalendario();
                    this.MensajeError("La sucursal no tiene días festivos");
                }
                else
                {
                    int count = checked(Consulta.Tables[0].Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        this.MiCalendario.SelectedDates.Add(Conversions.ToDate(Consulta.Tables[0].Rows[i][0]));
                        lstFechas.Add(Conversions.ToDate(Consulta.Tables[0].Rows[i][0]));
                        if (i == 0)
                        {
                            if (!Operators.ConditionalCompareObjectEqual(Consulta.Tables[0].Rows[i][1], "S", false))
                            {
                                this.Session["esFestivoSabado"] = false;
                            }
                            else
                            {
                                this.Session["esFestivoSabado"] = true;
                            }
                            if (!Operators.ConditionalCompareObjectEqual(Consulta.Tables[0].Rows[i][2], "S", false))
                            {
                                this.Session["esFestivoDomingo"] = false;
                            }
                            else
                            {
                                this.Session["esFestivoDomingo"] = true;
                            }
                        }
                    }
                    this.Session["Calendario"] = lstFechas;
                    this.chkSabado.Checked = Conversions.ToBoolean(this.Session["esFestivoSabado"]);
                    this.chkDomingo.Checked = Conversions.ToBoolean(this.Session["esFestivoDomingo"]);
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void GuardarFestivos()
        {
            try
            {
                this.lblError.Visible = false;
                if (this.cmbSucursal.SelectedIndex != 0)
                {
                    this.lblError.Visible = true;
                    List<DateTime> lstFechas = new List<DateTime>();
                    lstFechas = (List<DateTime>)this.Session["CalendarioEnviar"];
                    this.MensajeError(this.Session["esFestivoSabado"].ToString());
                    string GenerarFestivos = this.wsData.GenerarFestivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToBoolean(this.Session["esFestivoSabado"]), this.chkSabado.Checked, Conversions.ToBoolean(this.Session["esFestivoDomingo"]), this.chkDomingo.Checked, Conversions.ToInteger(this.cmbSucursal.SelectedValue), Conversions.ToString(this.Session["UsuarioRegistro"]), lstFechas.ToArray(), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
                    if (Operators.CompareString(GenerarFestivos, "", false) != 0)
                    {
                        this.MensajeError(GenerarFestivos);
                    }
                }
                else
                {
                    this.MensajeError("Debe escoger una sucursal");
                    return;
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
            this.ConsultarCalendario();
        }

        private void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            this.GuardarFestivos();
        }

        private void LimpiarCalendario()
        {
            List<DateTime> lstFechas = new List<DateTime>();
            lstFechas = (List<DateTime>)this.Session["Calendario"];
            lstFechas.Clear();
            this.Session["Calendario"] = lstFechas;
            this.MiCalendario.SelectedDates.Clear();
            List<DateTime> lstFechasEnviar = new List<DateTime>();
            this.Session["CalendarioEnviar"] = lstFechasEnviar;
        }

        private void MensajeError(string mensaje)
        {
            this.lblError.Visible = true;
            this.lblError.Text = mensaje;
        }

        private void MiCalendario_SelectionChanged(object sender, EventArgs e)
        {
            List<DateTime> lstFechas = new List<DateTime>();
            lstFechas = (List<DateTime>)this.Session["Calendario"];
            List<DateTime> lstFechasEnviar = new List<DateTime>();
            lstFechasEnviar = (List<DateTime>)this.Session["CalendarioEnviar"];
            if (!lstFechas.Contains(this.MiCalendario.SelectedDate))
            {
                int year = this.MiCalendario.SelectedDate.Year;
                DateTime now = DateAndTime.Now;
                if (DateTime.Compare(this.MiCalendario.SelectedDate, DateAndTime.Now) >= 0 & year == now.Year)
                {
                    lstFechas.Add(this.MiCalendario.SelectedDate);
                    lstFechasEnviar.Add(this.MiCalendario.SelectedDate);
                }
            }
            else
            {
                lstFechas.Remove(this.MiCalendario.SelectedDate);
                lstFechasEnviar.Remove(this.MiCalendario.SelectedDate);
            }
            this.MiCalendario.SelectedDates.Clear();
            this.MiCalendario.SelectedDate = Conversions.ToDate("01/01/1950");
            int count = checked(lstFechas.Count - 1);
            for (int i = 0; i <= count; i = checked(i + 1))
            {
                this.MiCalendario.SelectedDates.Add(lstFechas[i]);
            }
            this.Session["Calendario"] = lstFechas;
            this.Session["CalendarioEnviar"] = lstFechasEnviar;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.wsData.Credentials = CredentialCache.DefaultCredentials;
            //this.objSeg.Credentials = CredentialCache.DefaultCredentials;

            //if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
            if (!Operators.ConditionalCompareObjectNotEqual(this.Session[7], "", false))
            {
                this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
            }
            //else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PARFES"), "1", false) != 0)
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session[2]), "CP_PARFES"), "1", false) != 0)
            {
                this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Configuracion();
            }
        }
    }
}