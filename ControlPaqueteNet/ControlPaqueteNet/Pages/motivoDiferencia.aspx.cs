using AjaxControlToolkit;
using ControlPaqueteNet.WsPackage;
using ControlPaqueteNet.WsPraxair;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
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
    public partial class motivoDiferencia : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private void CargarDatos(string Codigo, string Descripcion, string Estado)
        {
            try
            {
                this.lblError.Visible = false;
                this.txtDescripcion.Text = Descripcion;
                this.chkActivo.Visible = true;
                if (Operators.CompareString(Estado, "Activo", false) != 0)
                {
                    this.chkActivo.Checked = false;
                }
                else
                {
                    this.chkActivo.Checked = true;
                }
                this.Session["Codigo"] = Codigo;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        public void CrearGrilla()
        {
            try
            {
                this.lblError.Visible = false;
                DataSet CrearMotivoDiferencia = this.wsData.CrearMotivoDiferencia(Conversions.ToString(this.Session["Conexion"]));
                if (CrearMotivoDiferencia.Tables[0].Rows.Count > 0)
                {
                    this.grDiferencia.DataSource = CrearMotivoDiferencia.Tables[0];
                    this.grDiferencia.DataBind();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void grDiferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow item = this.grDiferencia.Rows[this.grDiferencia.SelectedIndex];
            if (Operators.CompareString(item.Cells[2].Text, "Activo", false) != 0)
            {
                this.LimpiarControles();
            }
            else
            {
                this.CargarDatos(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text);
            }
            item = null;
        }

        public void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            this.SincronizarRegistro();
        }

        private void LimpiarControles()
        {
            this.txtDescripcion.Text = "";
            this.chkActivo.Checked = false;
            this.chkActivo.Visible = false;
            this.Session["Codigo"] = "";
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
            //if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
            if (!Operators.ConditionalCompareObjectNotEqual(this.Session[7], "", false))
            {
                this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
            }
            //else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PARMDI"), "1", false) != 0)
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session[2]), "CP_PARMDI"), "1", false) != 0)
            {
                this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
            }
            else if (!this.Page.IsPostBack)
            {
                this.CrearGrilla();
            }
        }

        private void SincronizarRegistro()
        {
            try
            {
                this.lblError.Visible = false;
                string text = this.txtDescripcion.Text;
                char[] chrArray = new char[] { ' ' };
                if (Operators.CompareString(text.TrimEnd(chrArray), "", false) != 0)
                {
                    string SincronizarMotivoDiferencia = "";
                    if (!Operators.ConditionalCompareObjectEqual(this.Session["Codigo"], "", false))
                    {
                        string Estado = "";
                        Estado = (!this.chkActivo.Checked ? "I" : "A");
                        SincronizarMotivoDiferencia = this.wsData.ActualizarMotivoDiferencia(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Codigo"]), this.txtDescripcion.Text, Estado, Conversions.ToString(this.Session["UsuarioRegistro"]));
                    }
                    else
                    {
                        SincronizarMotivoDiferencia = this.wsData.InsertarMotivoDiferencia(Conversions.ToString(this.Session["Conexion"]), this.txtDescripcion.Text, Conversions.ToString(this.Session["UsuarioRegistro"]));
                    }
                    if (Operators.CompareString(SincronizarMotivoDiferencia, "", false) == 0)
                    {
                        this.CrearGrilla();
                    }
                    else
                    {
                        this.MensajeError(SincronizarMotivoDiferencia);
                    }
                    this.LimpiarControles();
                }
                else
                {
                    this.MensajeError("Debe digitar una descripción");
                    this.txtDescripcion.Focus();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }
    }
}