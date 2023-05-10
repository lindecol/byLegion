using ControlPaqueteNet.WsPackage;
using ControlPaqueteNet.WsPraxair;
using Factory;
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
    public partial class Bloqueo : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private Utilidades oFactory = new Utilidades();

        private void BloquearConteo(int Codigo)
        {
            this.lblError.Visible = false;
            try
            {
                string BloquearConteo = this.wsData.BloquearRegistroConteo(Conversions.ToString(this.Session["Conexion"]), Codigo, Conversions.ToString(this.Session["UsuarioRegistro"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["Agencia"]), "B");
                if (Operators.CompareString(BloquearConteo, "", false) == 0)
                {
                    this.CrearGrilla();
                }
                else
                {
                    this.MensajeError(BloquearConteo);
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void CrearGrilla()
        {
            this.lblError.Visible = false;
            try
            {
                DataSet CrearCierre = this.wsData.CrearCierre(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.Session["Usuario"]), "A", "P", Conversions.ToString(this.Session["Agencia"]));
                if (CrearCierre.Tables[0].Rows.Count <= 0)
                {
                    this.grCierre.DataSource = null;
                    this.grCierre.DataBind();
                }
                else
                {
                    this.grCierre.DataSource = CrearCierre.Tables[0];
                    this.grCierre.DataBind();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void grCierre_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            try
            {
                GridViewRow item = this.grCierre.Rows[this.grCierre.SelectedIndex];
                this.BloquearConteo(Conversions.ToInteger(item.Cells[0].Text));
                item = null;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void MensajeError(string mensaje)
        {
            this.lblError.Visible = true;
            this.lblError.Text = mensaje;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.wsData.Credentials = CredentialCache.DefaultCredentials;
            //this.objSeg.Credentials = CredentialCache.DefaultCredentials;
            if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
            {
                this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
            }
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEBLO"), "1", false) != 0)
            {
                this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
            }
            else if (!this.Page.IsPostBack)
            {
                this.CrearGrilla();
            }
        }
    }
}