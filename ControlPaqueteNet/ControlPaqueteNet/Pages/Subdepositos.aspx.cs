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
    public partial class Subdepositos : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private void CargarSectores()
        {
            try
            {
                this.lblError.Visible = false;
                this.cmbSector.Items.Clear();
                this.cmbSector.DataSource = null;
                this.cmbSector.DataBind();
                this.cmbSector.Items.Add("");
                DataSet ConsultarSectores = this.wsData.CrearSectoresSubdepositos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
                if (ConsultarSectores.Tables[0].Rows.Count > 0)
                {
                    this.cmbSector.DataSource = ConsultarSectores.Tables[0];
                    this.cmbSector.DataBind();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void CargarSubdepositos()
        {
            try
            {
                this.lblError.Visible = false;
                this.cmbSubdeposito.Items.Clear();
                this.cmbSubdeposito.DataSource = null;
                this.cmbSubdeposito.DataBind();
                this.cmbSubdeposito.Items.Add("");
                DataSet ConsultarSubdepositos = this.wsData.ConsultarSubdepositos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue));
                if (ConsultarSubdepositos.Tables[0].Rows.Count > 0)
                {
                    this.cmbSubdeposito.DataSource = ConsultarSubdepositos.Tables[0];
                    this.cmbSubdeposito.DataBind();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void CargarSucursales()
        {
            try
            {
                this.lblError.Visible = false;
                DataSet ConsultarSucursales = this.wsData.ConsultarSucursales(Conversions.ToString(this.Session["Conexion"]), 0, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
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

        public void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarSubdepositos();
            this.CrearGrilla(Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.cmbSector.SelectedValue);
        }

        public void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarSectores();
            this.CargarSubdepositos();
            this.CrearGrilla(Conversions.ToInteger(this.cmbSucursal.SelectedValue), "");
        }

        public void CrearGrilla(int sucursal, string sector)
        {
            if (sucursal != -1)
            {
                try
                {
                    this.lblError.Visible = false;
                    DataSet CrearSubdepositos = this.wsData.CrearSubdepositoSector(Conversions.ToString(this.Session["Conexion"]), sucursal, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), sector);
                    this.grSubdeposito.DataSource = CrearSubdepositos.Tables[0];
                    this.grSubdeposito.DataBind();
                }
                catch (Exception exception)
                {
                    ProjectData.SetProjectError(exception);
                    this.MensajeError(exception.Message);
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void EliminarRegistro(int Sucursal, string Sector, int Secuencia)
        {
            try
            {
                this.lblError.Visible = false;
                string EliminarSubdeposito = this.wsData.EliminarSubdepositoSector(Conversions.ToString(this.Session["Conexion"]), Sucursal, Sector, Secuencia, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
                if (Operators.CompareString(EliminarSubdeposito, "", false) == 0)
                {
                    this.CrearGrilla(Sucursal, Sector);
                }
                else
                {
                    this.MensajeError(EliminarSubdeposito);
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void grSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EliminarRegistro(Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.cmbSector.SelectedValue, Conversions.ToInteger(this.grSubdeposito.Rows[this.grSubdeposito.SelectedIndex].Cells[0].Text));
        }

        public void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            this.InsertarRegistro();
        }

        private void InsertarRegistro()
        {
            this.lblError.Visible = false;
            if (Operators.CompareString(this.cmbSucursal.Text, "", false) == 0)
            {
                this.MensajeError("Debe seleccionar una sucursal");
            }
            else if (Operators.CompareString(this.cmbSector.Text, "", false) != 0)
            {
                try
                {
                    int ControlaPapeleria = Conversions.ToInteger(Interaction.IIf(this.chkCierraPapeleria.Checked, 1, 0));
                    string InsertarSubdeposito = this.wsData.InsertarSubdepositoSector(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.cmbSector.SelectedValue, Conversions.ToInteger(this.cmbSubdeposito.SelectedValue), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["UsuarioRegistro"]), ControlaPapeleria);
                    if (Operators.CompareString(InsertarSubdeposito, "", false) == 0)
                    {
                        this.CrearGrilla(Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.cmbSector.SelectedValue);
                    }
                    else
                    {
                        this.MensajeError(InsertarSubdeposito);
                    }
                }
                catch (Exception exception)
                {
                    ProjectData.SetProjectError(exception);
                    this.MensajeError(exception.Message);
                    ProjectData.ClearProjectError();
                }
            }
            else
            {
                this.MensajeError("Debe seleccionar un sector");
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
            //if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
            if (!Operators.ConditionalCompareObjectNotEqual(this.Session[7], "", false))
            {
                this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
            }
            //else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PARSUB"), "1", false) != 0)
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session[2]), "CP_PARSUB"), "1", false) != 0)
            {
                this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
            }
            else if (!this.Page.IsPostBack)
            {
                this.CargarSucursales();
                this.CrearGrilla(-1, "");
            }
        }
    }
}