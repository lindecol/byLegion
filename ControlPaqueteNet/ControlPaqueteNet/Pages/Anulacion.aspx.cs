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
    public partial class Anulacion : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();

        private void CargarDatos(string Programacion)
        {
            this.lblError.Visible = false;
            try
            {
                this.txtConteo.Visible = true;
                this.cmbMotivo.Visible = true;
                this.ibGuardar.Visible = true;
                this.txtConteo.Text = Programacion;
                this.txtConteo.Enabled = false;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void CargarMotivos()
        {
            this.lblError.Visible = false;
            try
            {
                DataSet ConsultarMotivos = this.wsData.CargarMotivoAnulacion(Conversions.ToString(this.Session["Conexion"]));
                if (ConsultarMotivos.Tables[0].Rows.Count > 0)
                {
                    this.cmbMotivo.DataSource = ConsultarMotivos.Tables[0];
                    this.cmbMotivo.DataBind();
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
                DataSet CrearAnulacion = this.wsData.CrearCierre(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.Session["Usuario"]), "P", "P", Conversions.ToString(this.Session["Agencia"]));
                if (CrearAnulacion.Tables[0].Rows.Count <= 0)
                {
                    this.grAnulacion.DataSource = null;
                    this.grAnulacion.DataBind();
                }
                else
                {
                    this.grAnulacion.DataSource = CrearAnulacion.Tables[0];
                    this.grAnulacion.DataBind();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void grAnulacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)this.grAnulacion.Rows[0].Cells[0].FindControl("cbEstado");
            GridViewRow item = this.grAnulacion.Rows[this.grAnulacion.SelectedIndex];
            this.CargarDatos(item.Cells[0].Text);
            item = null;
        }

        public void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            this.SincronizarRegistro();
        }

        private void LimpiarControles()
        {
            this.txtConteo.Text = "";
            this.cmbMotivo.SelectedIndex = 0;
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
            //else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PROANU"), "1", false) != 0)
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session[2]), "CP_PROANU"), "1", false) != 0)
            {
                this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
            }
            else if (!this.Page.IsPostBack)
            {
                this.CrearGrilla();
                this.CargarMotivos();
            }
        }

        private void SincronizarRegistro()
        {
            this.lblError.Visible = false;
            try
            {
                List<int> lstAnula = new List<int>();
                string SincronizarAnulacion = "";
                int count = checked(this.grAnulacion.Rows.Count - 1);
                for (int i = 0; i <= count; i = checked(i + 1))
                {
                    if (((CheckBox)this.grAnulacion.Rows[i].Cells[0].FindControl("cbEstado")).Checked)
                    {
                        lstAnula.Add(Conversions.ToInteger(this.grAnulacion.Rows[i].Cells[0].Text));
                    }
                }
                if (lstAnula.Count > 0)
                {
                    int num = checked(lstAnula.Count - 1);
                    int i = 0;
                    while (i <= num)
                    {
                        SincronizarAnulacion = this.wsData.AnularConteo(Conversions.ToString(this.Session["Conexion"]), lstAnula[i], Conversions.ToInteger(this.cmbMotivo.SelectedValue), Conversions.ToString(this.Session["UsuarioRegistro"]));
                        if (Operators.CompareString(SincronizarAnulacion, "", false) == 0)
                        {
                            i = checked(i + 1);
                        }
                        else
                        {
                            this.MensajeError(SincronizarAnulacion);
                            break;
                        }
                    }
                    this.CrearGrilla();
                    this.LimpiarControles();
                }
                else if (Operators.CompareString(this.txtConteo.Text, "", false) == 0)
                {
                    this.MensajeError("Debe seleccionar un conteo a anular");
                }
                else
                {
                    SincronizarAnulacion = this.wsData.AnularConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.txtConteo.Text), Conversions.ToInteger(this.cmbMotivo.SelectedValue), Conversions.ToString(this.Session["UsuarioRegistro"]));
                    if (Operators.CompareString(SincronizarAnulacion, "", false) != 0)
                    {
                        this.MensajeError(SincronizarAnulacion);
                    }
                    this.CrearGrilla();
                    this.LimpiarControles();
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