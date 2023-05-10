using ControlPaqueteNet.WsPackage;
using ControlPaqueteNet.WsPraxair;
using Factory;
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

namespace ControlPaqueteNet
{
    public partial class Etiquetas : System.Web.UI.Page
    {

        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            //wsData.ClientCredentials = CredentialCache.DefaultCredentials;
            //objSeg.ClientCredentials = CredentialCache.DefaultCredentials;
            if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
            {
                this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
            }
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PARETI"), "1", false) != 0)
            {
                this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
            }
            else if (!this.Page.IsPostBack)
            {
                this.CrearGrilla();
            }
        }


        private void CargarDatos(string Longitud, string TipoEtiqueta, string Descripcion, string Estado)
        {
            try
            {
                this.lblError.Visible = false;
                this.txtLongitud.Text = Longitud;
                this.cmbTipo.Text = TipoEtiqueta;
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
                this.txtLongitud.Enabled = false;
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
            try
            {
                this.lblError.Visible = false;
                DataSet CrearEtiqueta = this.wsData.CrearEtiqueta(Conversions.ToString(this.Session["Conexion"]));
                if (CrearEtiqueta.Tables[0].Rows.Count > 0)
                {
                    this.grEtiqueta.DataSource = CrearEtiqueta.Tables[0];
                    this.grEtiqueta.DataBind();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                Exception ex = exception;
                this.MensajeError(Conversions.ToString(Operators.ConcatenateObject(string.Concat(ex.Message, " Conexión: "), this.Session["Conexion"])));
                ProjectData.ClearProjectError();
            }
        }

        private void grEtiqueta_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow item = this.grEtiqueta.Rows[this.grEtiqueta.SelectedIndex];
            if (Operators.CompareString(item.Cells[3].Text, "Activo", false) != 0)
            {
                this.LimpiarControles();
            }
            else
            {
                this.CargarDatos(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text, item.Cells[3].Text);
            }
            item = null;
        }

        public void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            this.SincronizarRegistro();
        }

        private void LimpiarControles()
        {
            this.txtLongitud.Text = "";
            this.cmbTipo.SelectedValue = "A";
            this.txtDescripcion.Text = "";
            this.chkActivo.Checked = false;
            this.chkActivo.Visible = false;
        }

        private void MensajeError(string mensaje)
        {
            this.lblError.Visible = true;
            this.lblError.Text = mensaje;
        }

        private void SincronizarRegistro()
        {
            try
            {
                this.lblError.Visible = false;
                if (Operators.CompareString(this.txtDescripcion.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar una descripción");
                    this.txtDescripcion.Focus();
                }
                else if (Operators.CompareString(this.txtLongitud.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar la longitud de la etiqueta");
                    this.txtLongitud.Focus();
                }
                else if (Conversions.ToInteger(this.txtLongitud.Text) > 0)
                {
                    string SincronizarEtiqueta = "";
                    if (!this.txtLongitud.Enabled)
                    {
                        string Estado = "";
                        Estado = (!this.chkActivo.Checked ? "I" : "A");
                        SincronizarEtiqueta = this.wsData.ActualizarEtiqueta(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.txtLongitud.Text), this.cmbTipo.SelectedValue, this.txtDescripcion.Text, Estado, Conversions.ToString(this.Session["UsuarioRegistro"]));
                    }
                    else
                    {
                        SincronizarEtiqueta = this.wsData.InsertarEtiqueta(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.txtLongitud.Text), this.cmbTipo.SelectedValue, this.txtDescripcion.Text, Conversions.ToString(this.Session["UsuarioRegistro"]));
                    }
                    if (Operators.CompareString(SincronizarEtiqueta, "", false) == 0)
                    {
                        this.CrearGrilla();
                    }
                    else
                    {
                        this.MensajeError(SincronizarEtiqueta);
                    }
                    this.txtLongitud.Enabled = true;
                    this.LimpiarControles();
                }
                else
                {
                    this.MensajeError("La longitud de la etiqueta debe ser mayor que 0");
                    this.txtLongitud.Focus();
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