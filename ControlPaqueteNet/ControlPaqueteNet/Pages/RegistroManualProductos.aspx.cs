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
    public partial class RegistroManualProductos : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private Utilidades oFactory = new Utilidades();

        private void ActualizarGrillaProducto(string CodigoProducto, string Capacidad, string Cantidad)
        {
            TextBox Text;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            try
            {
                int i = 0;
                if (!this.txtCodigo.Visible)
                {
                    CodigoProducto = this.cmbProductos.SelectedValue;
                }
                else if (Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar un código de producto");
                    return;
                }
                if (Operators.CompareString(this.txtCantidad.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar una cantidad");
                }
                else if (Conversions.ToDouble(Cantidad) < 0)
                {
                    this.MensajeError("La cantidad debe ser mayor que 0");
                }
                else if (!(Operators.CompareString(this.oFactory.ObtenerFormatoDecimal(), ".", false) == 0 & this.oFactory.SoloNumerosyPunto(Capacidad) | Operators.CompareString(this.oFactory.ObtenerFormatoDecimal(), ",", false) == 0 & this.oFactory.SoloNumerosyComa(Capacidad)))
                {
                    this.MensajeError("La capacidad debe ser un número");
                }
                else if (Conversions.ToDouble(Capacidad) < 0)
                {
                    this.MensajeError("La capacidad debe ser mayor o igual que 0");
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)this.Session["Producto"];
                    int count = checked(this.grProducto.Rows.Count - 1);
                    for (i = 0; i <= count; i = checked(i + 1))
                    {
                        Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        dt.Rows[i][2] = Text.Text;
                    }
                    bool band = false;
                    DataTable dtCapacidad = new DataTable();
                    int num = checked(this.grProducto.Rows.Count - 1);
                    while (i <= num)
                    {
                        if (!(Operators.CompareString(this.grProducto.Rows[i].Cells[0].Text, CodigoProducto, false) == 0 & Operators.CompareString(this.grProducto.Rows[i].Cells[3].Text, Capacidad, false) == 0))
                        {
                            i = checked(i + 1);
                        }
                        else
                        {
                            Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                            Text.Text = Cantidad;
                            dt.Rows[i][2] = Cantidad;
                            band = true;
                            break;
                        }
                    }
                    if (!band)
                    {
                        DataRow dr = dt.NewRow();
                        string[] vector = this.wsData.NombreProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(CodigoProducto)).Split(new char[] { '-' });
                        if (Conversions.ToDouble(vector[0]) != 0)
                        {
                            this.MensajeError(string.Concat(vector[0], "-", vector[1]));
                        }
                        else
                        {
                            dr[0] = CodigoProducto;
                            dr[1] = vector[2];
                            dr[2] = this.txtCantidad.Text;
                            dr[3] = Capacidad;
                            dr[4] = "A";
                            dt.Rows.Add(dr);
                            this.Session["Producto"] = dt;
                            this.grProducto.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Producto"]);
                            this.grProducto.DataBind();
                            Text = (TextBox)this.grProducto.Rows[checked(this.grProducto.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrilla");
                            Text.Text = Cantidad;
                        }
                    }
                    int count1 = checked(this.grProducto.Rows.Count - 1);
                    for (i = 0; i <= count1; i = checked(i + 1))
                    {
                        Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        Text.Text = Conversions.ToString(dt.Rows[i][2]);
                    }
                    this.txtCodigo.Text = "";
                    this.txtCantidad.Text = "";
                    this.cmbProductos.SelectedIndex = 0;
                    this.cmbCapacidadProducto.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void ActualizarGrillaProductoPart(string CodigoProducto, string Capacidad, string Cantidad)
        {
            TextBox Text;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            try
            {
                int i = 0;
                if (!this.txtCodigo.Visible)
                {
                    CodigoProducto = this.cmbProductos.SelectedValue;
                }
                else if (Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar un código de producto");
                    return;
                }
                if (Operators.CompareString(this.txtCantidad.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar una cantidad");
                }
                else if (Conversions.ToDouble(Cantidad) < 0)
                {
                    this.MensajeError("La cantidad debe ser mayor que 0");
                }
                else if (!(Operators.CompareString(this.oFactory.ObtenerFormatoDecimal(), ".", false) == 0 & this.oFactory.SoloNumerosyPunto(Capacidad) | Operators.CompareString(this.oFactory.ObtenerFormatoDecimal(), ",", false) == 0 & this.oFactory.SoloNumerosyComa(Capacidad)))
                {
                    this.MensajeError("La capacidad debe ser un número");
                }
                else if (Conversions.ToDouble(Capacidad) < 0)
                {
                    this.MensajeError("La capacidad debe ser mayor o igual que 0");
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)this.Session["ProductoParticulares"];
                    int count = checked(this.grProductoParticular.Rows.Count - 1);
                    for (i = 0; i <= count; i = checked(i + 1))
                    {
                        Text = (TextBox)this.grProductoParticular.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        dt.Rows[i][2] = Text.Text;
                    }
                    bool band = false;
                    DataTable dtCapacidad = new DataTable();
                    int num = checked(this.grProducto.Rows.Count - 1);
                    
                    while (i <= num)
                    {
                        if (!(Operators.CompareString(this.grProductoParticular.Rows[i].Cells[0].Text, CodigoProducto, false) == 0 & Operators.CompareString(this.grProductoParticular.Rows[i].Cells[3].Text, Capacidad, false) == 0))
                        {
                            i = checked(i + 1);
                        }
                        else
                        {
                            Text = (TextBox)this.grProductoParticular.Rows[i].FindControl("txtCantidadGrilla");
                            Text.Text = Cantidad;
                            dt.Rows[i][2] = Cantidad;
                            band = true;
                            break;
                        }
                    }
                    if (!band)
                    {
                        DataRow dr = dt.NewRow();
                        string[] vector = this.wsData.NombreProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(CodigoProducto)).Split(new char[] { '-' });
                        if (Conversions.ToDouble(vector[0]) != 0)
                        {
                            this.MensajeError(string.Concat(vector[0], "-", vector[1]));
                        }
                        else
                        {
                            dr[0] = CodigoProducto;
                            dr[1] = vector[2];
                            dr[2] = this.txtCantidad.Text;
                            dr[3] = Capacidad;
                            dr[4] = "A";
                            dt.Rows.Add(dr);
                            this.Session["ProductoParticulares"] = dt;
                            this.grProductoParticular.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ProductoParticulares"]);
                            this.grProductoParticular.DataBind();
                            Text = (TextBox)this.grProductoParticular.Rows[checked(this.grProductoParticular.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrilla");
                            Text.Text = Cantidad;
                        }
                    }
                    int count1 = checked(this.grProductoParticular.Rows.Count - 1);
                    for (i = 0; i <= count1; i = checked(i + 1))
                    {
                        Text = (TextBox)this.grProductoParticular.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        Text.Text = Conversions.ToString(dt.Rows[i][2]);
                    }
                    this.txtCodigo.Text = "";
                    this.txtCantidad.Text = "";
                    this.cmbProductos.SelectedIndex = 0;
                    this.cmbCapacidadProducto.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void CargarGrilla()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            try
            {
                DataSet ConsultarProductos = new DataSet();
                DataSet ConsultarProductosParticulares = new DataSet();
                ConsultarProductos = this.wsData.CrearProductosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "P");
                ConsultarProductosParticulares = this.wsData.CrearProductosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "A");
                if (ConsultarProductos.Tables[0].Rows.Count > 0)
                {
                    this.grProducto.DataSource = ConsultarProductos.Tables[0];
                    this.grProducto.DataBind();
                    int count = checked(this.grProducto.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        TextBox Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        Text.Attributes.Add("OnKeyPress", "return esInteger(event)");
                        Text.Text = Conversions.ToString(ConsultarProductos.Tables[0].Rows[i][2]);
                    }
                    this.Session["Producto"] = ConsultarProductos.Tables[0];
                }
                if (ConsultarProductosParticulares.Tables[0].Rows.Count > 0)
                {
                    this.grProductoParticular.DataSource = ConsultarProductosParticulares.Tables[0];
                    this.grProductoParticular.DataBind();
                    int num = checked(this.grProductoParticular.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        TextBox Text = (TextBox)this.grProductoParticular.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        Text.Attributes.Add("OnKeyPress", "return esInteger(event)");
                        Text.Text = Conversions.ToString(ConsultarProductosParticulares.Tables[0].Rows[i][2]);
                    }
                    this.Session["ProductoParticulares"] = ConsultarProductosParticulares.Tables[0];
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void CargarProductos()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            try
            {
                DataSet ConsultarProductos = this.wsData.CrearProductosCombo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]));
                if (ConsultarProductos.Tables[0].Rows.Count > 0)
                {
                    this.cmbProductos.DataSource = ConsultarProductos.Tables[0];
                    this.cmbProductos.DataBind();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        public void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblCapacidad.Visible = true;
            this.lblCantidad.Visible = true;
            this.txtCantidad.Visible = true;
            DataSet dtCapacidad = new DataSet();
            dtCapacidad = this.wsData.CapacidadesProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(this.cmbProductos.SelectedValue));
            this.txtCodigo.Text = this.cmbProductos.SelectedValue;
            if (dtCapacidad.Tables[0].Rows.Count > 0)
            {
                this.cmbCapacidadProducto.DataSource = dtCapacidad.Tables[0];
                this.cmbCapacidadProducto.DataBind();
            }
        }

        private void Configuracion()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                this.lblSubtitulo.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]), " --- Tipo: "), this.Session["TipoConteo"]), " --- Fecha: "), this.Session["FechaInicio"]));
                this.CargarProductos();
                DataTable dtGrilla = new DataTable();
                dtGrilla.Columns.Add(new DataColumn("CODIGO_PRODUCTO", typeof(int)));
                dtGrilla.Columns.Add(new DataColumn("NOMBRE_PRODUCTO", typeof(string)));
                dtGrilla.Columns.Add(new DataColumn("CANTIDAD", typeof(int)));
                dtGrilla.Columns.Add(new DataColumn("CAPACIDAD", typeof(double)));
                dtGrilla.Columns.Add(new DataColumn("PROPIEDAD", typeof(string)));
                this.Session["Producto"] = dtGrilla;
                this.Session["ProductoParticulares"] = dtGrilla;
                this.CargarGrilla();
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void GuardarProductos()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            try
            {
                if (!(this.grProducto.Rows.Count > 0 | this.grProductoParticular.Rows.Count > 0))
                {
                    this.MensajeError("No se han registrado productos");
                }
                else
                {
                    DataSet dsProducto = new DataSet();
                    DataSet dsProductoPart = new DataSet();
                    DataTable dtProducto = new DataTable();
                    DataTable dtProductoPart = new DataTable();
                    dtProducto.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                    dtProducto.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
                    dtProducto.Columns.Add(new DataColumn("CAPACIDAD", typeof(string)));
                    dtProductoPart.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                    dtProductoPart.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
                    dtProductoPart.Columns.Add(new DataColumn("CAPACIDAD", typeof(string)));
                    int count = checked(this.grProducto.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        DataRow dr = dtProducto.NewRow();
                        dr[0] = this.grProducto.Rows[i].Cells[0].Text;
                        TextBox Texto = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        dr[1] = Texto.Text;
                        dr[2] = this.grProducto.Rows[i].Cells[2].Text;
                        dtProducto.Rows.Add(dr);
                    }
                    dsProducto.Tables.Add(dtProducto);
                    int num = checked(this.grProductoParticular.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        DataRow dr = dtProductoPart.NewRow();
                        dr[0] = this.grProductoParticular.Rows[i].Cells[0].Text;
                        TextBox Texto = (TextBox)this.grProductoParticular.Rows[i].FindControl("txtCantidadGrilla");
                        dr[1] = Texto.Text;
                        dr[2] = this.grProductoParticular.Rows[i].Cells[2].Text;
                        dtProductoPart.Rows.Add(dr);
                    }
                    dsProductoPart.Tables.Add(dtProductoPart);
                    string Registro = this.wsData.GuardarProductos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "N", "P", Conversions.ToString(this.Session["UsuarioRegistro"]), dsProducto, dsProductoPart);
                    if (Operators.CompareString(Registro, "", false) == 0)
                    {
                        this.Response.Redirect("ConteosRegistro.aspx");
                    }
                    else
                    {
                        this.MensajeError(Registro);
                    }
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        public void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            this.GuardarProductos();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Operators.CompareString(this.cmbPropiedad.SelectedValue, "P", false) != 0)
            {
                this.ActualizarGrillaProductoPart(this.txtCodigo.Text, this.cmbCapacidadProducto.SelectedValue, this.txtCantidad.Text);
            }
            else
            {
                this.ActualizarGrillaProducto(this.txtCodigo.Text, this.cmbCapacidadProducto.SelectedValue, this.txtCantidad.Text);
            }
        }

        private void MensajeError(string mensaje)
        {
            this.lblError.Visible = true;
            this.lblError1.Visible = true;
            this.lblError.Text = mensaje;
            this.lblError1.Text = mensaje;
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
                this.Configuracion();
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            try
            {
                if (Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar un código de producto");
                }
                else
                {
                    this.lblCapacidad.Visible = true;
                    this.cmbCapacidadProducto.Visible = true;
                    this.lblCantidad.Visible = true;
                    this.txtCantidad.Visible = true;
                    DataSet dtCapacidad = new DataSet();
                    dtCapacidad = this.wsData.CapacidadesProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(this.txtCodigo.Text));
                    if (dtCapacidad.Tables[0].Rows.Count <= 0)
                    {
                        this.MensajeError("Debe digitar un código válido de producto");
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
                ProjectData.ClearProjectError();
            }
        }
    }
}