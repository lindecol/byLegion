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
    public partial class ConteosRegistro : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private Utilidades oFactory = new Utilidades();

        public void CrearGrilla()
        {
            this.lblError.Visible = false;
            try
            {
                DataSet CrearProgramacion = this.wsData.CrearProgramacion(Conversions.ToString(this.Session["Conexion"]), "A", Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.Session["Usuario"]), Conversions.ToString(this.Session["Agencia"]));
                if (CrearProgramacion.Tables[0].Rows.Count > 0)
                {
                    this.grRegistro.DataSource = CrearProgramacion.Tables[0];
                    this.grRegistro.DataBind();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void grRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            try
            {
                GridViewRow item = this.grRegistro.Rows[this.grRegistro.SelectedIndex];
                this.Session["Conteo"] = item.Cells[0].Text;
                this.Session["TipoConteo"] = item.Cells[1].Text;
                this.Session["FechaInicio"] = item.Cells[2].Text;
                this.Session["HoraInicio"] = item.Cells[3].Text;
                this.Session["HoraFin"] = item.Cells[4].Text;
                this.Session["Encargado"] = item.Cells[5].Text;
                item = null;
                this.wsData.BloquearRegistroConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToString(this.Session["UsuarioRegistro"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["Agencia"]), "A");
                object obj = this.Session["TipoConteo"];
                if (Operators.ConditionalCompareObjectEqual(obj, "ACTIVOS", false))
                {
                    this.Response.Redirect("RegistroManualActivos.aspx");
                }
                else if (Operators.ConditionalCompareObjectEqual(obj, "PRODUCTO", false))
                {
                    this.Response.Redirect("RegistroManualProductos.aspx");
                }
                else if (Operators.ConditionalCompareObjectEqual(obj, "MIXTO", false))
                {
                    this.Response.Redirect("RegistroManualMixtos.aspx");
                }
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
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEREG"), "1", false) != 0)
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