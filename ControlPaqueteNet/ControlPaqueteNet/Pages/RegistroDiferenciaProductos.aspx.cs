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
    public partial class RegistroDiferenciaProductos : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private Utilidades oFactory = new Utilidades();

        private void ActualizarGrillaProducto(int CodigoProducto, string Diferencia)
        {
            this.lblError.Visible = false;
            try
            {
                this.Session["Productos"] = this.oFactory.ActualizarGrillaActivosDiferencia((DataTable)this.Session["Productos"], CodigoProducto, Diferencia);
                this.grProductos.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Productos"]);
                this.grProductos.DataBind();
                this.cmbDiferencia.SelectedIndex = -1;
                this.lblCodigo.Visible = false;
                this.txtCodigo.Visible = false;
                this.lblDiferencia.Visible = false;
                this.cmbDiferencia.Visible = false;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void ActualizarGrillaProductoPart(int CodigoProducto, string Diferencia)
        {
            this.lblError.Visible = false;
            try
            {
                this.Session["ProductosPart"] = this.oFactory.ActualizarGrillaActivosDiferencia((DataTable)this.Session["ProductosPart"], CodigoProducto, Diferencia);
                this.grProductosPart.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ProductosPart"]);
                this.grProductosPart.DataBind();
                this.cmbDiferenciaPart.SelectedIndex = -1;
                this.lblCodigoPart.Visible = false;
                this.txtCodigoPart.Visible = false;
                this.lblDiferenciaPart.Visible = false;
                this.cmbDiferenciaPart.Visible = false;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void CargarDiferencias()
        {
            this.lblError.Visible = false;
            try
            {
                DataSet ConsultarDiferencias = this.wsData.CargarMotivosDiferencias(Conversions.ToString(this.Session["Conexion"]));
                if (ConsultarDiferencias.Tables[0].Rows.Count > 0)
                {
                    this.cmbDiferencia.DataSource = ConsultarDiferencias.Tables[0];
                    this.cmbDiferencia.DataBind();
                    this.cmbDiferenciaPart.DataSource = ConsultarDiferencias.Tables[0];
                    this.cmbDiferenciaPart.DataBind();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void CerrarConteo(int Codigo)
        {
            this.lblError.Visible = false;
            try
            {
                string CerrarConteo = this.wsData.CerrarConteo(Conversions.ToString(this.Session["Conexion"]), Codigo, Conversions.ToString(this.Session["UsuarioRegistro"]));
                if (Operators.CompareString(CerrarConteo, "", false) != 0)
                {
                    this.MensajeError(CerrarConteo);
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        public void cmbDiferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDiferencia.Items[this.cmbDiferencia.SelectedIndex].Text.Length <= 11)
            {
                this.ActualizarGrillaProducto(Conversions.ToInteger(this.txtCodigo.Text), this.cmbDiferencia.Items[this.cmbDiferencia.SelectedIndex].Text);
            }
            else
            {
                this.ActualizarGrillaProducto(Conversions.ToInteger(this.txtCodigo.Text), this.cmbDiferencia.Items[this.cmbDiferencia.SelectedIndex].Text.Substring(0, 12));
            }
        }

        protected void cmbDiferenciaPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDiferenciaPart.Items[this.cmbDiferenciaPart.SelectedIndex].Text.Length <= 11)
            {
                this.ActualizarGrillaProductoPart(Conversions.ToInteger(this.txtCodigoPart.Text), this.cmbDiferenciaPart.Items[this.cmbDiferenciaPart.SelectedIndex].Text);
            }
            else
            {
                this.ActualizarGrillaProductoPart(Conversions.ToInteger(this.txtCodigoPart.Text), this.cmbDiferenciaPart.Items[this.cmbDiferenciaPart.SelectedIndex].Text.Substring(0, 12));
            }
        }

        private void Configuracion()
        {
            this.lblError.Visible = false;
            try
            {
                DataTable dt = new DataTable("Productos");
                this.crearTabla(dt);
                DataTable dtP = new DataTable("ProductosPart");
                this.crearTabla(dtP);
                this.lblSubtitulo.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]), " --- Tipo: "), this.Session["TipoConteo"]), " --- Fecha: "), this.Session["FechaInicio"]));
                this.CargarDiferencias();
                this.Session["Productos"] = dt;
                this.Session["ProductosPart"] = dtP;
                this.CrearGrillaProductos();
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        public void CrearGrillaProductos()
        {
            this.lblError.Visible = false;
            try
            {
                DataSet CrearProductos = this.wsData.ConsultarDiferencias(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToString(this.Session["UsuarioRegistro"]), "P", "P");
                if (CrearProductos.Tables[0].Rows.Count > 0)
                {
                    this.grProductos.DataSource = CrearProductos.Tables[0];
                    this.grProductos.DataBind();
                }
                this.Session["Productos"] = CrearProductos.Tables[0];
                DataSet CrearProductosPart = this.wsData.ConsultarDiferencias(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToString(this.Session["UsuarioRegistro"]), "P", "A");
                if (CrearProductosPart.Tables[0].Rows.Count > 0)
                {
                    this.grProductosPart.DataSource = CrearProductosPart.Tables[0];
                    this.grProductosPart.DataBind();
                }
                this.Session["ProductosPart"] = CrearProductosPart.Tables[0];
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        public void crearTabla(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("CODIGO_CONTEO", typeof(int)));
            dt.Columns.Add(new DataColumn("FECHA_CONTEO", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("ID_ACTIVO_PRODUCTO", typeof(int)));
            dt.Columns.Add(new DataColumn("TIPO_ARTICULO", typeof(string)));
            dt.Columns.Add(new DataColumn("NOMBRE_ARTICULO", typeof(string)));
            dt.Columns.Add(new DataColumn("CANTIDAD_CONTEO", typeof(int)));
            dt.Columns.Add(new DataColumn("CAPACIDAD_CONTEO", typeof(double)));
            dt.Columns.Add(new DataColumn("PROPIEDAD_CONTEO", typeof(string)));
            dt.Columns.Add(new DataColumn("CANTIDAD_SISTEMA", typeof(int)));
            dt.Columns.Add(new DataColumn("CAPACIDAD_SISTEMA", typeof(double)));
            dt.Columns.Add(new DataColumn("DIFERENCIA_ACTIVO", typeof(double)));
            dt.Columns.Add(new DataColumn("DIFERENCIA_PRODUCTO", typeof(double)));
            dt.Columns.Add(new DataColumn("CODIGO_MOTIVO_DIFERENCIA", typeof(int)));
        }

        protected void grProductos_DataBound(object sender, EventArgs e)
        {
            DataSet ConsultarDiferencias = this.wsData.CargarMotivosDiferencias(Conversions.ToString(this.Session["Conexion"]));
            int count = checked(this.grProductos.Rows.Count - 1);
            for (int index = 0; index <= count; index = checked(index + 1))
            {
                DropDownList objCombo = (DropDownList)this.grProductos.Rows[index].FindControl("cmbDiferenciaProdProp");
                objCombo.DataSource = ConsultarDiferencias.Tables[0];
                objCombo.DataBind();
            }
        }

        private void grProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            try
            {
                this.lblCodigo.Visible = true;
                this.txtCodigo.Visible = true;
                this.lblDiferencia.Visible = true;
                this.cmbDiferencia.Visible = true;
                GridViewRow item = this.grProductos.Rows[this.grProductos.SelectedIndex];
                this.txtCodigo.Text = item.Cells[0].Text;
                item = null;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        protected void grProductosPart_DataBound(object sender, EventArgs e)
        {
            DataSet ConsultarDiferencias = this.wsData.CargarMotivosDiferencias(Conversions.ToString(this.Session["Conexion"]));
            int count = checked(this.grProductosPart.Rows.Count - 1);
            for (int index = 0; index <= count; index = checked(index + 1))
            {
                DropDownList objCombo = (DropDownList)this.grProductosPart.Rows[index].FindControl("cmbDiferenciaProdAje");
                objCombo.DataSource = ConsultarDiferencias.Tables[0];
                objCombo.DataBind();
            }
        }

        protected void grProductosPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            try
            {
                this.lblCodigoPart.Visible = true;
                this.txtCodigoPart.Visible = true;
                this.lblDiferenciaPart.Visible = true;
                this.cmbDiferenciaPart.Visible = true;
                GridViewRow item = this.grProductosPart.Rows[this.grProductosPart.SelectedIndex];
                this.txtCodigoPart.Text = item.Cells[0].Text;
                item = null;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void GuardarActivos()
        {
            DropDownList objCombo;
            this.lblError.Visible = false;
            try
            {
                DataTable dtProductos = new DataTable("Productos");
                DataTable dtProductosPart = new DataTable("ProductosPart");
                dtProductos = ((DataTable)this.Session["Productos"]).Copy();
                dtProductosPart = ((DataTable)this.Session["ProductosPart"]).Copy();
                if (!(dtProductos.Rows.Count > 0 | dtProductosPart.Rows.Count > 0))
                {
                    this.CerrarConteo(Conversions.ToInteger(this.Session["Conteo"]));
                    this.Response.Redirect("ConteosDiferencia.aspx");
                }
                else
                {
                    int count = checked(this.grProductos.Rows.Count - 1);
                    for (int index = 0; index <= count; index = checked(index + 1))
                    {
                        objCombo = (DropDownList)this.grProductos.Rows[index].FindControl("cmbDiferenciaProdProp");
                        dtProductos = this.oFactory.ActualizarGrillaActivosDiferencia(dtProductos, Conversions.ToInteger(this.grProductos.Rows[index].Cells[0].Text), objCombo.SelectedItem.Text);
                    }
                    int num = checked(dtProductos.Rows.Count - 1);
                    int i = 0;
                    while (i <= num)
                    {
                        if (!Operators.ConditionalCompareObjectEqual(dtProductos.Rows[i][12], " ", false))
                        {
                            i = checked(i + 1);
                        }
                        else
                        {
                            this.MensajeError("Existen diferencias por justificar");
                            return;
                        }
                    }
                    int count1 = checked(this.grProductosPart.Rows.Count - 1);
                    for (int index = 0; index <= count1; index = checked(index + 1))
                    {
                        objCombo = (DropDownList)this.grProductosPart.Rows[index].FindControl("cmbDiferenciaProdAje");
                        dtProductosPart = this.oFactory.ActualizarGrillaActivosDiferencia(dtProductosPart, Conversions.ToInteger(this.grProductosPart.Rows[index].Cells[0].Text), objCombo.SelectedItem.Text);
                    }
                    int num1 = checked(dtProductosPart.Rows.Count - 1);
                    //int i = 0;
                    while (i <= num1)
                    {
                        if (!Operators.ConditionalCompareObjectEqual(dtProductosPart.Rows[i][12], " ", false))
                        {
                            i = checked(i + 1);
                        }
                        else
                        {
                            this.MensajeError("Existen diferencias por justificar");
                            return;
                        }
                    }
                    dtProductos.TableName = "Productos";
                    dtProductosPart.TableName = "ProductosPart";
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dtProductos);
                    ds.Tables.Add(dtProductosPart);
                    string Registro = this.wsData.InsertarDiferenciaProductos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToString(this.Session["UsuarioRegistro"]), ds);
                    if (Operators.CompareString(Registro, "", false) == 0)
                    {
                        this.CerrarConteo(Conversions.ToInteger(this.Session["Conteo"]));
                        this.Response.Redirect("ConteosDiferencia.aspx");
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
            this.GuardarActivos();
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
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEJUS"), "1", false) != 0)
            {
                this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Configuracion();
            }
        }
    }
}