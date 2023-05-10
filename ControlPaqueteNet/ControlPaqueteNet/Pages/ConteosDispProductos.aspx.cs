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
    public partial class ConteosDispProductos : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private Utilidades oFactory = new Utilidades();
        private int Count = 0;
        private void ibAtras_Click(object sender, ImageClickEventArgs e)
        {
            if (Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
            {
                this.Response.Redirect("ConsultaConteos.aspx");
            }
        }

        private void ibProducto_Click(object sender, ImageClickEventArgs e)
        {
            char[] chrArray;
            this.lblError.Visible = false;
            try
            {
                if (this.lblAnular.Visible)
                {
                    if (this.rbSiAnula.Checked)
                    {
                        string RegistrarConteo = this.wsData.ConsultarConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), this.txtSerial.Text, "B", Conversions.ToString(this.Session["UsuarioRegistro"]));
                        chrArray = new char[] { '-' };
                        string[] Vector = RegistrarConteo.Split(chrArray);
                        if (Conversions.ToDouble(Vector[0]) != 0)
                        {
                            this.MensajeError(Vector[1]);
                        }
                    }
                    this.txtSerial.Text = "";
                    this.txtCodigo.Text = "";
                    this.txtCantidad.Text = "";
                    this.lblCapacidad.Visible = false;
                    this.cmbCapacidadProducto.Visible = false;
                    this.lblAnular.Visible = false;
                    this.rbSiAnula.Visible = false;
                    this.rbNoAnula.Visible = false;
                    this.MensajeError("Operación exitósa");
                }
                else if (Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar un código de producto");
                }
                else if (Operators.CompareString(this.txtCantidad.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar una cantidad");
                }
                else if (Conversions.ToInteger(this.txtCantidad.Text) < 0)
                {
                    this.MensajeError("La cantidad debe ser mayor que 0");
                }
                else if (this.Count != 1)
                {
                    string str = this.wsData.NombreProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), checked((int)Conversions.ToLong(this.txtCodigo.Text)));
                    chrArray = new char[] { '-' };
                    string[] vector = str.Split(chrArray);
                    if (Conversions.ToDouble(vector[0]) != 0)
                    {
                        this.MensajeError(string.Concat(vector[0], "-", vector[1]));
                    }
                    else
                    {
                        string str1 = this.wsData.GuardarProductosPocket(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "N", "PP", Conversions.ToLong(this.txtCodigo.Text), Conversions.ToInteger(this.txtCantidad.Text), Conversions.ToDouble(this.cmbCapacidadProducto.SelectedValue), Conversions.ToString(this.Session["UsuarioRegistro"]), "A");
                        chrArray = new char[] { '-' };
                        string[] Registro = str1.Split(chrArray);
                        if (Conversions.ToDouble(Registro[0]) == 0)
                        {
                            this.txtCodigo.Text = "";
                            this.txtCantidad.Text = "";
                            this.lblCapacidad.Visible = false;
                            this.cmbCapacidadProducto.Visible = false;
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
                    this.MensajeError("Debe escoger una capacidad");
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
                this.txtCodigo.Attributes.Add("OnKeyPress", "return esInteger(event)");
                this.txtSerial.Focus();
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            try
            {
                if (Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar un código de producto");
                }
                else
                {
                    this.Count = checked(this.Count + 1);
                    this.lblCapacidad.Visible = true;
                    this.cmbCapacidadProducto.Visible = true;
                    DataSet dtCapacidad = new DataSet();
                    dtCapacidad = this.wsData.CapacidadesProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(this.txtCodigo.Text));
                    this.cmbCapacidadProducto.Items.Clear();
                    this.cmbCapacidadProducto.DataSource = null;
                    this.cmbCapacidadProducto.DataBind();
                    if (dtCapacidad.Tables[0].Rows.Count <= 0)
                    {
                        this.MensajeError("Debe digitar un código válido de producto");
                        this.lblCapacidad.Visible = false;
                        this.cmbCapacidadProducto.Visible = false;
                    }
                    else
                    {
                        this.cmbCapacidadProducto.DataSource = dtCapacidad.Tables[0];
                        this.cmbCapacidadProducto.DataBind();
                    }
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                this.lblCapacidad.Visible = false;
                this.cmbCapacidadProducto.Visible = false;
                ProjectData.ClearProjectError();
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