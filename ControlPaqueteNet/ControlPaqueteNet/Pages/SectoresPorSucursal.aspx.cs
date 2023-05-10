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
    public partial class SectoresPorSucursal : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();

        public void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CrearGrilla(this.cmbSucursal.SelectedValue);
        }

        public void CrearGrilla(string sucursal)
        {
            if (Operators.CompareString(sucursal, "", false) != 0)
            {
                try
                {
                    this.lblError.Visible = false;
                    DataSet CrearSucursales = this.wsData.CrearSectorSucursal(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(sucursal), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
                    this.grSucursal.DataSource = CrearSucursales.Tables[0];
                    this.grSucursal.DataBind();
                }
                catch (Exception exception)
                {
                    ProjectData.SetProjectError(exception);
                    this.MensajeError(exception.Message);
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void EliminarRegistro(int Sucursal, string Sector)
        {
            try
            {
                this.lblError.Visible = false;
                string EliminarSucursal = this.wsData.EliminarSucursal(Conversions.ToString(this.Session["Conexion"]), Sucursal, Sector, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
                if (Operators.CompareString(EliminarSucursal, "", false) == 0)
                {
                    this.CrearGrilla(this.cmbSucursal.SelectedValue);
                }
                else
                {
                    this.MensajeError(EliminarSucursal);
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
            this.EliminarRegistro(Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.grSucursal.Rows[this.grSucursal.SelectedIndex].Cells[0].Text);
        }

        public void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            this.InsertarRegistro();
        }

        private void InsertarRegistro()
        {
            this.lblError.Visible = false;
            if (Operators.CompareString(this.cmbSucursal.Text, "", false) != 0)
            {
                try
                {
                    string InsertarSucursal = this.wsData.InsertarSucursal(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.cmbSector.SelectedValue, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["UsuarioRegistro"]));
                    if (Operators.CompareString(InsertarSucursal, "", false) == 0)
                    {
                        this.CrearGrilla(this.cmbSucursal.SelectedValue);
                    }
                    else
                    {
                        this.MensajeError(InsertarSucursal);
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
                this.MensajeError("Debe seleccionar una sucursal");
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
            //else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PARSESU"), "1", false) != 0)
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session[2]), "CP_PARSESU"), "1", false) != 0)
            {
                this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
            }
            else if (!this.Page.IsPostBack)
            {
                this.CargarSucursales();
                this.CargarSectores();
                this.CrearGrilla("");
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

        private void CargarSectores()
        {
            try
            {
                this.lblError.Visible = false;
                DataSet ConsultarSectores = this.wsData.CargarSectores(Conversions.ToString(this.Session["Conexion"]));
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
    }
}