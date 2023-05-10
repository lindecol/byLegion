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
    public partial class ConteosDispActivos : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private Utilidades oFactory = new Utilidades();
        private void cmbPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbPropiedad.SelectedIndex != 1)
            {
                this.lblFamilia.Text = "Familia";
            }
            else
            {
                this.lblFamilia.Text = "Código";
            }
        }

        private void ibActivoPropio_Click(object sender, ImageClickEventArgs e)
        {
            char[] chrArray;
            this.lblError.Visible = false;
            try
            {
                if (this.lblAnular.Visible)
                {
                    if (!this.rbSiAnula.Checked)
                    {
                        this.MensajeError("Operación exitósa");
                    }
                    else
                    {
                        string RegistrarConteo = this.wsData.ConsultarConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), this.txtSerial.Text, "B", Conversions.ToString(this.Session["UsuarioRegistro"]));
                        chrArray = new char[] { '-' };
                        string[] Vector = RegistrarConteo.Split(chrArray);
                        if (Conversions.ToDouble(Vector[0]) == 0)
                        {
                            this.MensajeError(Vector[1]);
                        }
                        else
                        {
                            this.MensajeError(Vector[1]);
                        }
                    }
                    this.cmbPropiedad.SelectedIndex = 0;
                    this.txtSerial.Text = "";
                    this.txtFamilia.Text = "";
                    this.txtCantidad.Text = "";
                    this.lblAnular.Visible = false;
                    this.rbSiAnula.Visible = false;
                    this.rbNoAnula.Visible = false;
                }
                else if (Operators.CompareString(this.txtFamilia.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar un código de activo");
                }
                else if (Operators.CompareString(this.txtCantidad.Text, "", false) == 0)
                {
                    this.MensajeError("La cantidad no puede ser vacío");
                }
                else if (Conversions.ToInteger(this.txtCantidad.Text) >= 0)
                {
                    string str = this.wsData.NombreActivo(Conversions.ToString(this.Session["Conexion"]), checked((int)Conversions.ToLong(this.txtFamilia.Text)), this.cmbPropiedad.SelectedValue);
                    chrArray = new char[] { '-' };
                    string[] vector = str.Split(chrArray);
                    if (Conversions.ToDouble(vector[0]) != 0)
                    {
                        this.MensajeError(string.Concat(vector[0], "-", vector[1]));
                    }
                    else
                    {
                        string str1 = this.wsData.GuardarActivosPocket(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "N", "AP", Conversions.ToString(this.Session["UsuarioRegistro"]), Conversions.ToLong(this.txtFamilia.Text), Conversions.ToInteger(this.txtCantidad.Text), this.cmbPropiedad.SelectedValue);
                        chrArray = new char[] { '-' };
                        string[] Registro = str1.Split(chrArray);
                        if (Conversions.ToDouble(Registro[0]) == 0)
                        {
                            this.cmbPropiedad.SelectedIndex = 0;
                            this.txtFamilia.Text = "";
                            this.txtCantidad.Text = "";
                            this.MensajeError(Registro[1]);
                        }
                        else
                        {
                            this.MensajeError(Registro[1]);
                        }
                    }
                }
                else
                {
                    this.MensajeError("La cantidad debe ser mayor que 0");
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
            this.txtSerial.Focus();
        }

        private void ibAtras_Click(object sender, ImageClickEventArgs e)
        {
            this.Response.Redirect("ConsultaConteos.aspx");
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
            if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Conteo"], "", false))
            {
                this.Response.Redirect("ErrorDispositivo.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
            }
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEREG"), "1", false) != 0)
            {
                this.Response.Redirect("ErrorDispositivo.aspx?mensaje=No está autorizado el ingreso");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    this.lblConteo.Text = Conversions.ToString(Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]));
                }
                this.txtCantidad.Attributes.Add("OnKeyPress", "return esInteger(event)");
                this.txtFamilia.Attributes.Add("OnKeyPress", "return esInteger(event)");
                this.txtSerial.Focus();
            }
        }

        private void txtSerial_TextChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            this.txtSerial.Enabled = false;
            try
            {
                string RegistrarConteo = this.wsData.ConsultarConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), this.txtSerial.Text, "C", Conversions.ToString(this.Session["UsuarioRegistro"]));
                string[] Vector = RegistrarConteo.Split(new char[] { '-' });
                if (Operators.CompareString(Vector[2], "S", false) != 0)
                {
                    if (Conversions.ToDouble(Vector[0]) == 0)
                    {
                        this.MensajeError(Vector[1]);
                    }
                    else
                    {
                        this.MensajeError(Vector[1]);
                    }
                    this.txtSerial.Text = "";
                }
                else
                {
                    this.lblAnular.Visible = true;
                    this.rbSiAnula.Visible = true;
                    this.rbNoAnula.Visible = true;
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
            this.txtSerial.Enabled = true;
            this.txtSerial.Focus();
        }
    }
}