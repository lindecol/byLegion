using AjaxControlToolkit;
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

namespace ControlPaqueteNet.Pages
{
    public partial class RegistroManualMixtos : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private Utilidades oFactory = new Utilidades();

        private void ActualizarGrillaActivoAjeno(string CodigoActivo, string Cantidad)
        {
            TextBox Texto;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                if (Operators.CompareString(CodigoActivo, "", false) == 0)
                {
                    this.MensajeError("Debe digitar un código de activo");
                    return;
                }
                else if (Operators.CompareString(Cantidad, "", false) == 0)
                {
                    this.MensajeError("Debe digitar una cantidad");
                    return;
                }
                else if (!this.oFactory.SoloNumeros(Cantidad))
                {
                    this.MensajeError("La cantidad debe ser un número");
                }
                else if (Conversions.ToInteger(Cantidad) < 0)
                {
                    this.MensajeError("La cantidad debe ser mayor o igual que 0");
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)this.Session["ActivosAjenos"];
                    int count = checked(this.grActivoAjeno.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
                        dt.Rows[i][4] = Texto.Text;
                    }
                    bool band = false;
                    int num = checked(this.grActivoAjeno.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        if (Operators.CompareString(this.grActivoAjeno.Rows[i].Cells[0].Text, CodigoActivo, false) == 0)
                        {
                            Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
                            Texto.Text = Cantidad;
                            dt.Rows[i][4] = Texto.Text;
                            band = true;
                        }
                    }
                    if (!band)
                    {
                        DataRow dr = dt.NewRow();
                        string[] vector = this.wsData.NombreActivo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(CodigoActivo), "A").Split(new char[] { '-' });
                        if (Conversions.ToDouble(vector[0]) != 0)
                        {
                            this.MensajeError(string.Concat(vector[0], "-", vector[1]));
                        }
                        else
                        {
                            dr[0] = CodigoActivo;
                            dr[1] = vector[2];
                            dr[2] = 0;
                            dr[3] = 1;
                            dr[4] = Cantidad;
                            dt.Rows.Add(dr);
                            this.Session["ActivosAjenos"] = dt;
                            this.grActivoAjeno.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ActivosAjenos"]);
                            this.grActivoAjeno.DataBind();
                            TextBox x = (TextBox)this.grActivoAjeno.Rows[checked(this.grActivoAjeno.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrilaAjeno");
                            x.Text = Cantidad;
                        }
                    }
                    int count1 = checked(this.grActivoAjeno.Rows.Count - 1);
                    for (int i = 0; i <= count1; i = checked(i + 1))
                    {
                        Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
                        Texto.Text = Conversions.ToString(dt.Rows[i][4]);
                    }
                    this.txtFamAjeno.Text = "";
                    this.txtCantAjeno.Text = "";
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void ActualizarGrillaActivoPropio(string CodigoActivo, string Cantidad)
        {
            TextBox Texto;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                if (Operators.CompareString(CodigoActivo, "", false) == 0)
                {
                    this.MensajeError("Debe diitar un código de familia");
                    return;
                }
                else if (Operators.CompareString(Cantidad, "", false) == 0)
                {
                    this.MensajeError("Debe digitar una cantidad");
                    return;
                }
                else if (!this.oFactory.SoloNumeros(Cantidad))
                {
                    this.MensajeError("La cantidad debe ser un número");
                }
                else if (Conversions.ToInteger(Cantidad) < 0)
                {
                    this.MensajeError("La cantidad debe ser mayor o igual que 0");
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)this.Session["ActivosPropios"];
                    int count = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
                        dt.Rows[i][4] = Texto.Text;
                    }
                    bool band = false;
                    int num = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        if (Operators.CompareString(this.grActivoPropio.Rows[i].Cells[0].Text, CodigoActivo, false) == 0)
                        {
                            Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
                            Texto.Text = Cantidad;
                            dt.Rows[i][4] = Texto.Text;
                            band = true;
                        }
                    }
                    if (!band)
                    {
                        DataRow dr = dt.NewRow();
                        string[] vector = this.wsData.NombreActivo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(CodigoActivo), "P").Split(new char[] { '-' });
                        if (Conversions.ToDouble(vector[0]) != 0)
                        {
                            this.MensajeError(string.Concat(vector[0], "-", vector[1]));
                        }
                        else
                        {
                            dr[0] = CodigoActivo;
                            dr[1] = vector[2];
                            dr[2] = 0;
                            dr[3] = 1;
                            dr[4] = Cantidad;
                            dt.Rows.Add(dr);
                            this.Session["ActivosPropios"] = dt;
                            this.grActivoPropio.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ActivosPropios"]);
                            this.grActivoPropio.DataBind();
                            TextBox x = (TextBox)this.grActivoPropio.Rows[checked(this.grActivoPropio.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrilaPropio");
                            x.Text = Cantidad;
                        }
                    }
                    int count1 = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= count1; i = checked(i + 1))
                    {
                        Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
                        Texto.Text = Conversions.ToString(dt.Rows[i][4]);
                    }
                    this.txtFamilia.Text = "";
                    this.txtCantidadPropio.Text = "";
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void ActualizarGrillaProducto(string CodigoProducto, string Cantidad, string Capacidad, string Propiedad)
        {
            CheckBox Cmb;
            TextBox Text;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                if (Operators.CompareString(CodigoProducto, "", false) == 0)
                {
                    this.MensajeError("Debe digitar un código de producto");
                }
                else if (Operators.CompareString(Cantidad, "", false) == 0)
                {
                    this.MensajeError("Debe digitar una cantidad");
                }
                else if (Conversions.ToDouble(Cantidad) < 0)
                {
                    this.MensajeError("La capacidad debe ser mayor o igual que 0");
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)this.Session["Producto"];
                    int count = checked(this.grProducto.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        dt.Rows[i][2] = Text.Text;
                        Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
                        if (!Cmb.Checked)
                        {
                            dt.Rows[i][4] = "A";
                        }
                        else
                        {
                            dt.Rows[i][4] = "P";
                        }
                    }
                    bool band = false;
                    DataTable dtCapacidad = new DataTable();
                    bool EsPropio = false;
                    int num = checked(this.grProducto.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        EsPropio = (Operators.CompareString(Propiedad, "P", false) != 0 ? false : true);
                        Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
                        if (Conversions.ToInteger(this.grProducto.Rows[i].Cells[0].Text) == Conversions.ToInteger(CodigoProducto) & Operators.CompareString(this.grProducto.Rows[i].Cells[3].Text, Capacidad, false) == 0 & Cmb.Checked == EsPropio)
                        {
                            Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                            Text.Text = Cantidad;
                            dt.Rows[i][2] = Cantidad;
                            band = true;
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
                            dr[2] = Cantidad;
                            dr[3] = Capacidad;
                            dr[4] = Propiedad;
                            dt.Rows.Add(dr);
                            this.Session["Producto"] = dt;
                            this.grProducto.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Producto"]);
                            this.grProducto.DataBind();
                            Text = (TextBox)this.grProducto.Rows[checked(this.grProducto.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrilla");
                            Text.Text = Cantidad;
                            CheckBox c = (CheckBox)this.grProducto.Rows[checked(this.grProducto.Rows.Count - 1)].Cells[4].FindControl("cbEstado");
                            if (Operators.CompareString(Propiedad, "P", false) != 0)
                            {
                                c.Checked = false;
                            }
                            else
                            {
                                c.Checked = true;
                            }
                        }
                    }
                    int count1 = checked(this.grProducto.Rows.Count - 1);
                    for (int i = 0; i <= count1; i = checked(i + 1))
                    {
                        Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        Text.Text = Conversions.ToString(dt.Rows[i][2]);
                        Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
                        if (!Operators.ConditionalCompareObjectEqual(dt.Rows[i][4], "P", false))
                        {
                            Cmb.Checked = false;
                        }
                        else
                        {
                            Cmb.Checked = true;
                        }
                    }
                    this.txtCodigo.Text = "";
                    this.txtCantidad.Text = "";
                    this.cmbPropiedad.SelectedIndex = 0;
                    this.lblPropiedad.Visible = false;
                    this.cmbPropiedad.Visible = false;
                    this.lblCapacidad.Visible = false;
                    this.cmbCapacidadProducto.Visible = false;
                    this.lblCantidad.Visible = false;
                    this.txtCantidad.Visible = false;
                    this.ibProducto.Visible = false;
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void ActualizarGrillaProductoPart(string CodigoProducto, string Cantidad, string Capacidad, string Propiedad)
        {
            CheckBox Cmb;
            TextBox Text;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                if (Operators.CompareString(CodigoProducto, "", false) == 0)
                {
                    this.MensajeError("Debe digitar un código de producto");
                }
                else if (Operators.CompareString(Cantidad, "", false) == 0)
                {
                    this.MensajeError("Debe digitar una cantidad");
                }
                else if (Conversions.ToDouble(Cantidad) < 0)
                {
                    this.MensajeError("La capacidad debe ser mayor o igual que 0");
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)this.Session["ProductoParticulares"];
                    int count = checked(this.grdProductoAjenos.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        Text = (TextBox)this.grdProductoAjenos.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        dt.Rows[i][2] = Text.Text;
                        Cmb = (CheckBox)this.grdProductoAjenos.Rows[i].Cells[4].FindControl("cbEstado");
                        if (!Cmb.Checked)
                        {
                            dt.Rows[i][4] = "A";
                        }
                        else
                        {
                            dt.Rows[i][4] = "P";
                        }
                    }
                    bool band = false;
                    DataTable dtCapacidad = new DataTable();
                    bool EsPropio = false;
                    int num = checked(this.grdProductoAjenos.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        EsPropio = (Operators.CompareString(Propiedad, "P", false) != 0 ? false : true);
                        Cmb = (CheckBox)this.grdProductoAjenos.Rows[i].Cells[4].FindControl("cbEstado");
                        if (Conversions.ToInteger(this.grdProductoAjenos.Rows[i].Cells[0].Text) == Conversions.ToInteger(CodigoProducto) & Operators.CompareString(this.grdProductoAjenos.Rows[i].Cells[3].Text, Capacidad, false) == 0 & Cmb.Checked == EsPropio)
                        {
                            Text = (TextBox)this.grdProductoAjenos.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                            Text.Text = Cantidad;
                            dt.Rows[i][2] = Cantidad;
                            band = true;
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
                            dr[2] = Cantidad;
                            dr[3] = Capacidad;
                            dr[4] = Propiedad;
                            dt.Rows.Add(dr);
                            this.Session["ProductoParticulares"] = dt;
                            this.grdProductoAjenos.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ProductoParticulares"]);
                            this.grdProductoAjenos.DataBind();
                            Text = (TextBox)this.grdProductoAjenos.Rows[checked(this.grdProductoAjenos.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrilla");
                            Text.Text = Cantidad;
                            CheckBox c = (CheckBox)this.grdProductoAjenos.Rows[checked(this.grdProductoAjenos.Rows.Count - 1)].Cells[4].FindControl("cbEstado");
                            if (Operators.CompareString(Propiedad, "P", false) != 0)
                            {
                                c.Checked = false;
                            }
                            else
                            {
                                c.Checked = true;
                            }
                        }
                    }
                    int count1 = checked(this.grdProductoAjenos.Rows.Count - 1);
                    for (int i = 0; i <= count1; i = checked(i + 1))
                    {
                        Text = (TextBox)this.grdProductoAjenos.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        Text.Text = Conversions.ToString(dt.Rows[i][2]);
                        Cmb = (CheckBox)this.grdProductoAjenos.Rows[i].Cells[4].FindControl("cbEstado");
                        if (!Operators.ConditionalCompareObjectEqual(dt.Rows[i][4], "P", false))
                        {
                            Cmb.Checked = false;
                        }
                        else
                        {
                            Cmb.Checked = true;
                        }
                    }
                    this.txtCodigo.Text = "";
                    this.txtCantidad.Text = "";
                    this.cmbPropiedad.SelectedIndex = 0;
                    this.lblPropiedad.Visible = false;
                    this.cmbPropiedad.Visible = false;
                    this.lblCapacidad.Visible = false;
                    this.cmbCapacidadProducto.Visible = false;
                    this.lblCantidad.Visible = false;
                    this.txtCantidad.Visible = false;
                    this.ibProducto.Visible = false;
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void CargarActivosAjenos()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataSet ConsultarActivosAjenos = new DataSet();
                ConsultarActivosAjenos = this.wsData.CrearActivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "A");
                if (ConsultarActivosAjenos.Tables[0].Rows.Count > 0)
                {
                    this.cmbActivoAjeno.DataSource = ConsultarActivosAjenos.Tables[0];
                    this.cmbActivoAjeno.DataBind();
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void CargarActivosPropios()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataSet ConsultarActivosPropios = new DataSet();
                ConsultarActivosPropios = this.wsData.CrearActivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "P");
                if (ConsultarActivosPropios.Tables[0].Rows.Count > 0)
                {
                    this.cmbActivoPropio.DataSource = ConsultarActivosPropios.Tables[0];
                    this.cmbActivoPropio.DataBind();
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
            CheckBox Cmb;
            TextBox Text;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataTable dtCapacidad = new DataTable();
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
                        Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        Text.Attributes.Add("OnKeyPress", "return esInteger(event)");
                        Text.Text = Conversions.ToString(ConsultarProductos.Tables[0].Rows[i][2]);
                        Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
                        if (Operators.ConditionalCompareObjectEqual(ConsultarProductos.Tables[0].Rows[i][4], "P", false))
                        {
                            Cmb.Checked = true;
                        }
                    }
                    this.Session["Producto"] = ConsultarProductos.Tables[0];
                }
                if (ConsultarProductosParticulares.Tables[0].Rows.Count > 0)
                {
                    this.grdProductoAjenos.DataSource = ConsultarProductosParticulares.Tables[0];
                    this.grdProductoAjenos.DataBind();
                    int num = checked(this.grdProductoAjenos.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        Text = (TextBox)this.grdProductoAjenos.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                        Text.Attributes.Add("OnKeyPress", "return esInteger(event)");
                        Text.Text = Conversions.ToString(ConsultarProductosParticulares.Tables[0].Rows[i][2]);
                        Cmb = (CheckBox)this.grdProductoAjenos.Rows[i].Cells[4].FindControl("cbEstado");
                        if (Operators.ConditionalCompareObjectEqual(ConsultarProductosParticulares.Tables[0].Rows[i][4], "P", false))
                        {
                            Cmb.Checked = true;
                        }
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
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataSet ConsultarProductos = new DataSet();
                ConsultarProductos = this.wsData.CrearProductosCombo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]));
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

        public void cmbActivoAjeno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbActivoAjeno.SelectedIndex == 0)
            {
                this.lblFamAjeno.Visible = true;
                this.txtFamAjeno.Visible = true;
                this.lblCantAjeno.Visible = true;
                this.txtCantAjeno.Visible = true;
            }
            else
            {
                this.lblFamAjeno.Visible = false;
                this.txtFamAjeno.Visible = false;
                this.lblCantAjeno.Visible = false;
                this.txtCantAjeno.Visible = false;
            }
        }

        public void cmbActivoPropio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InsertarEnGrillaActivoPropio();
        }

        public void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                if (!(this.cmbProductos.SelectedIndex != 0 & this.cmbPropiedad.SelectedIndex == 0))
                {
                    this.lblCodigo.Visible = true;
                    this.txtCodigo.Visible = true;
                    this.lblPropiedad.Visible = false;
                    this.cmbPropiedad.Visible = false;
                    this.lblCapacidad.Visible = false;
                    this.cmbCapacidadProducto.Visible = false;
                    this.lblCantidad.Visible = false;
                    this.txtCantidad.Visible = false;
                    this.ibProducto.Visible = false;
                }
                else
                {
                    this.txtCodigo.Text = this.cmbProductos.SelectedValue;
                    this.lblCodigo.Visible = false;
                    this.txtCodigo.Visible = false;
                    this.lblPropiedad.Visible = true;
                    this.cmbPropiedad.Visible = true;
                    this.lblCapacidad.Visible = true;
                    this.cmbCapacidadProducto.Visible = true;
                    this.lblCantidad.Visible = true;
                    this.txtCantidad.Visible = true;
                    this.ibProducto.Visible = true;
                    DataSet dtCapacidad = new DataSet();
                    dtCapacidad = this.wsData.CapacidadesProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(this.cmbProductos.SelectedValue));
                    if (dtCapacidad.Tables[0].Rows.Count > 0)
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
                this.lblCodigo.Visible = true;
                this.txtCodigo.Visible = true;
                this.lblPropiedad.Visible = false;
                this.cmbPropiedad.Visible = false;
                this.lblCapacidad.Visible = false;
                this.cmbCapacidadProducto.Visible = false;
                this.lblCantidad.Visible = false;
                this.txtCantidad.Visible = false;
                this.ibProducto.Visible = false;
                ProjectData.ClearProjectError();
            }
        }

        private void Configuracion()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                this.lblSubtitulo.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]), " --- Tipo: "), this.Session["TipoConteo"]), " --- Fecha: "), this.Session["FechaInicio"]));
                this.CargarProductos();
                DataTable dtGrilla = new DataTable();
                dtGrilla.Columns.Add(new DataColumn("CODIGO_PRODUCTO", typeof(string)));
                dtGrilla.Columns.Add(new DataColumn("NOMBRE_PRODUCTO", typeof(string)));
                dtGrilla.Columns.Add(new DataColumn("CANTIDAD", typeof(int)));
                dtGrilla.Columns.Add(new DataColumn("CAPACIDAD", typeof(double)));
                dtGrilla.Columns.Add(new DataColumn("PROPIEDAD", typeof(string)));
                dtGrilla.Columns.Add(new DataColumn("INDICADOR_CUENTA_CORRIENTE", typeof(string)));
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

        private void ConfiguracionActivos()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                this.lblSubtitulo.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]), " --- Tipo: "), this.Session["TipoConteo"]), " --- Fecha: "), this.Session["FechaInicio"]));
                this.CargarActivosPropios();
                this.CargarActivosAjenos();
                dt = new DataTable();
                dt.Columns.Add(new DataColumn("CODIGO_ACTIVO", typeof(int)));
                dt.Columns.Add(new DataColumn("NOMBRE_ACTIVO", typeof(string)));
                dt.Columns.Add(new DataColumn("CAPACIDAD", typeof(double)));
                dt.Columns.Add(new DataColumn("PROPIEDAD", typeof(string)));
                dt.Columns.Add(new DataColumn("CANTIDAD", typeof(int)));
                this.Session["ActivosPropios"] = dt;
                this.Session["ActivosAjenos"] = dt;
                this.CrearGrillaActivosPropios();
                this.CrearGrillaActivosAjenos();
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        public void CrearGrillaActivosAjenos()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataSet CrearActivosAjenos = new DataSet();
                CrearActivosAjenos = this.wsData.CrearActivosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "A");
                if (CrearActivosAjenos.Tables[0].Rows.Count > 0)
                {
                    this.grActivoAjeno.DataSource = CrearActivosAjenos;
                    this.grActivoAjeno.DataBind();
                    int count = checked(this.grActivoAjeno.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        TextBox Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
                        Texto.Attributes.Add("OnKeyPress", "return esInteger(event)");
                        Texto.Text = Conversions.ToString(CrearActivosAjenos.Tables[0].Rows[i][4]);
                    }
                }
                this.Session["ActivosAjenos"] = CrearActivosAjenos.Tables[0];
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        public void CrearGrillaActivosPropios()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataSet CrearActivosPropios = new DataSet();
                CrearActivosPropios = this.wsData.CrearActivosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "P");
                if (CrearActivosPropios.Tables[0].Rows.Count > 0)
                {
                    this.grActivoPropio.DataSource = CrearActivosPropios.Tables[0];
                    this.grActivoPropio.DataBind();
                    int count = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        TextBox Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
                        Texto.Attributes.Add("OnKeyPress", "return esInteger(event)");
                        Texto.Text = Conversions.ToString(CrearActivosPropios.Tables[0].Rows[i][4]);
                    }
                }
                this.Session["ActivosPropios"] = CrearActivosPropios.Tables[0];
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void GuardarMixto()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                if (!(this.grProducto.Rows.Count > 0 | this.grdProductoAjenos.Rows.Count > 0 | this.grActivoAjeno.Rows.Count > 0 | this.grActivoPropio.Rows.Count > 0))
                {
                    this.MensajeError("No se han registrado ni productos ni activos");
                }
                else
                {
                    DataSet dsProducto = new DataSet();
                    DataSet dsProductoAjeno = new DataSet();
                    DataSet dsActivoAjeno = new DataSet();
                    DataSet dsActivoPropio = new DataSet();
                    DataTable dtProducto = new DataTable();
                    DataTable dtProductoAjeno = new DataTable();
                    DataTable dtActivoAjeno = new DataTable();
                    DataTable dtActivoPropio = new DataTable();
                    dtProducto.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                    dtProducto.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
                    dtProducto.Columns.Add(new DataColumn("CAPACIDAD", typeof(string)));
                    dtProducto.Columns.Add(new DataColumn("PROPIEDAD", typeof(string)));
                    dtProductoAjeno.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                    dtProductoAjeno.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
                    dtProductoAjeno.Columns.Add(new DataColumn("CAPACIDAD", typeof(string)));
                    dtProductoAjeno.Columns.Add(new DataColumn("PROPIEDAD", typeof(string)));
                    dtActivoAjeno.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                    dtActivoAjeno.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
                    dtActivoPropio.Columns.Add(new DataColumn("FAMILIA", typeof(string)));
                    dtActivoPropio.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
                    int count = checked(this.grProducto.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        DataRow dr = dtProducto.NewRow();
                        dr[0] = this.grProducto.Rows[i].Cells[0].Text;
                        TextBox Texto = (TextBox)this.grProducto.Rows[i].FindControl("txtCantidadGrilla");
                        dr[1] = Texto.Text;
                        dr[2] = this.grProducto.Rows[i].Cells[2].Text;
                        dr[3] = "P";
                        dtProducto.Rows.Add(dr);
                    }
                    dsProducto.Tables.Add(dtProducto);
                    int num = checked(this.grdProductoAjenos.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        DataRow dr = dtProductoAjeno.NewRow();
                        dr[0] = this.grdProductoAjenos.Rows[i].Cells[0].Text;
                        TextBox Texto = (TextBox)this.grdProductoAjenos.Rows[i].FindControl("txtCantidadGrilla");
                        dr[1] = Texto.Text;
                        dr[2] = this.grdProductoAjenos.Rows[i].Cells[2].Text;
                        dr[3] = "A";
                        dtProductoAjeno.Rows.Add(dr);
                    }
                    dsProductoAjeno.Tables.Add(dtProductoAjeno);
                    int count1 = checked(this.grActivoAjeno.Rows.Count - 1);
                    for (int i = 0; i <= count1; i = checked(i + 1))
                    {
                        DataRow dr = dtActivoAjeno.NewRow();
                        dr[0] = this.grActivoAjeno.Rows[i].Cells[0].Text;
                        TextBox Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
                        dr[1] = Texto.Text;
                        dtActivoAjeno.Rows.Add(dr);
                    }
                    dsActivoAjeno.Tables.Add(dtActivoAjeno);
                    int num1 = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= num1; i = checked(i + 1))
                    {
                        DataRow dr = dtActivoPropio.NewRow();
                        dr[0] = this.grActivoPropio.Rows[i].Cells[0].Text;
                        TextBox Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
                        dr[1] = Texto.Text;
                        dtActivoPropio.Rows.Add(dr);
                    }
                    dsActivoPropio.Tables.Add(dtActivoPropio);
                    string Registro = this.wsData.GuardarMixto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "N", "P", Conversions.ToString(this.Session["UsuarioRegistro"]), dsProducto, dsActivoAjeno, dsActivoPropio, dsProductoAjeno);
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

        public void ibActivoAjeno_Click(object sender, ImageClickEventArgs e)
        {
            if (this.cmbActivoAjeno.SelectedIndex == 0)
            {
                this.ActualizarGrillaActivoAjeno(this.txtFamAjeno.Text, this.txtCantAjeno.Text);
            }
            else
            {
                this.InsertarEnGrillaActivoAjeno();
            }
        }

        public void ibActivoPropio_Click(object sender, ImageClickEventArgs e)
        {
            if (Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
            {
                this.ActualizarGrillaActivoPropio(this.txtFamilia.Text, this.txtCantidadPropio.Text);
            }
        }

        public void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            this.GuardarMixto();
        }

        public void ibProducto_Click(object sender, ImageClickEventArgs e)
        {
            if (!this.cmbCapacidadProducto.Visible)
            {
                if (Operators.CompareString(this.cmbPropiedad.SelectedValue, "P", false) != 0)
                {
                    this.InsertarEnGrillaProductosPart();
                }
                else
                {
                    this.InsertarEnGrillaProductos();
                }
                this.lblCodigo.Visible = true;
                this.txtCodigo.Visible = true;
                this.lblPropiedad.Visible = false;
                this.cmbPropiedad.Visible = false;
                this.lblCapacidad.Visible = false;
                this.cmbCapacidadProducto.Visible = false;
                this.lblCantidad.Visible = false;
                this.txtCantidad.Visible = false;
                this.ibProducto.Visible = false;
            }
            else if (Operators.CompareString(this.cmbPropiedad.SelectedValue, "P", false) != 0)
            {
                this.ActualizarGrillaProductoPart(this.txtCodigo.Text, this.txtCantidad.Text, this.cmbCapacidadProducto.SelectedValue, this.cmbPropiedad.SelectedValue);
            }
            else
            {
                this.ActualizarGrillaProducto(this.txtCodigo.Text, this.txtCantidad.Text, this.cmbCapacidadProducto.SelectedValue, this.cmbPropiedad.SelectedValue);
            }
        }

        private void InsertarEnGrillaActivoAjeno()
        {
            TextBox Texto;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)this.Session["ActivosAjenos"];
                if (!this.oFactory.ExisteFilaEnGrillaActivos(dt, Conversions.ToInteger(this.cmbActivoAjeno.SelectedValue)))
                {
                    int count = checked(this.grActivoAjeno.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
                        dt.Rows[i][4] = Texto.Text;
                    }
                    DataRow dr = dt.NewRow();
                    dr[0] = this.cmbActivoAjeno.SelectedValue;
                    dr[1] = this.cmbActivoAjeno.Items[this.cmbActivoAjeno.SelectedIndex].Text;
                    dr[4] = 0;
                    dr[3] = 2;
                    dr[2] = 0;
                    dt.Rows.Add(dr);
                    this.Session["ActivosAjenos"] = dt;
                    this.grActivoAjeno.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ActivosAjenos"]);
                    this.grActivoAjeno.DataBind();
                    int num = checked(this.grActivoAjeno.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
                        Texto.Text = Conversions.ToString(dt.Rows[i][4]);
                    }
                }
                this.cmbActivoAjeno.SelectedIndex = -1;
                this.lblFamAjeno.Visible = true;
                this.txtFamAjeno.Visible = true;
                this.lblCantAjeno.Visible = true;
                this.txtCantAjeno.Visible = true;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void InsertarEnGrillaActivoPropio()
        {
            TextBox Texto;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)this.Session["ActivosPropios"];
                if (!this.oFactory.ExisteFilaEnGrillaActivos(dt, Conversions.ToInteger(this.cmbActivoPropio.SelectedValue)))
                {
                    int count = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
                        dt.Rows[i][2] = Texto.Text;
                    }
                    DataRow dr = dt.NewRow();
                    dr[0] = this.cmbActivoPropio.SelectedValue;
                    dr[1] = this.cmbActivoPropio.Items[this.cmbActivoPropio.SelectedIndex].Text;
                    if (Operators.CompareString(this.oFactory.ObtenerFormatoDecimal(), ".", false) != 0)
                    {
                        dr[4] = "0,00";
                    }
                    else
                    {
                        dr[4] = "0.00";
                    }
                    dr[3] = 1;
                    dr[2] = 0;
                    dt.Rows.Add(dr);
                    this.Session["ActivosPropios"] = dt;
                    this.grActivoPropio.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ActivosPropios"]);
                    this.grActivoPropio.DataBind();
                    int num = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
                        Texto.Text = Conversions.ToString(dt.Rows[i][2]);
                    }
                }
                this.cmbActivoPropio.SelectedIndex = -1;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void InsertarEnGrillaProductos()
        {
            CheckBox Cmb;
            TextBox Text;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)this.Session["Producto"];
                int count = checked(this.grProducto.Rows.Count - 1);
                for (int i = 0; i <= count; i = checked(i + 1))
                {
                    Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                    dt.Rows[i][2] = Text.Text;
                    Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
                    if (!Cmb.Checked)
                    {
                        dt.Rows[i][4] = "A";
                    }
                    else
                    {
                        dt.Rows[i][4] = "P";
                    }
                }
                DataRow dr = dt.NewRow();
                dr[0] = this.cmbProductos.SelectedValue;
                dr[1] = this.cmbProductos.Items[this.cmbProductos.SelectedIndex].Text;
                dr[2] = 0;
                dr[3] = this.cmbCapacidadProducto.SelectedValue;
                dr[4] = "A";
                dt.Rows.Add(dr);
                this.Session["Producto"] = dt;
                this.grProducto.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Producto"]);
                this.grProducto.DataBind();
                int num = checked(this.grProducto.Rows.Count - 1);
                for (int i = 0; i <= num; i = checked(i + 1))
                {
                    Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                    Text.Text = Conversions.ToString(dt.Rows[i][2]);
                    Cmb = (CheckBox)this.grProducto.Rows[i].Cells[3].FindControl("cbEstado");
                    if (!Operators.ConditionalCompareObjectEqual(dt.Rows[i][4], "P", false))
                    {
                        Cmb.Checked = false;
                    }
                    else
                    {
                        Cmb.Checked = true;
                    }
                }
                this.cmbProductos.SelectedIndex = -1;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void InsertarEnGrillaProductosPart()
        {
            CheckBox Cmb;
            TextBox Text;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)this.Session["ProductoParticulares"];
                int count = checked(this.grProducto.Rows.Count - 1);
                for (int i = 0; i <= count; i = checked(i + 1))
                {
                    Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                    dt.Rows[i][2] = Text.Text;
                    Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
                    if (!Cmb.Checked)
                    {
                        dt.Rows[i][4] = "A";
                    }
                    else
                    {
                        dt.Rows[i][4] = "P";
                    }
                }
                DataRow dr = dt.NewRow();
                dr[0] = this.cmbProductos.SelectedValue;
                dr[1] = this.cmbProductos.Items[this.cmbProductos.SelectedIndex].Text;
                dr[2] = 0;
                dr[3] = this.cmbCapacidadProducto.SelectedValue;
                dr[4] = "A";
                dt.Rows.Add(dr);
                this.Session["ProductoParticulares"] = dt;
                this.grdProductoAjenos.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ProductoParticulares"]);
                this.grdProductoAjenos.DataBind();
                int num = checked(this.grdProductoAjenos.Rows.Count - 1);
                for (int i = 0; i <= num; i = checked(i + 1))
                {
                    Text = (TextBox)this.grdProductoAjenos.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
                    Text.Text = Conversions.ToString(dt.Rows[i][2]);
                    Cmb = (CheckBox)this.grdProductoAjenos.Rows[i].Cells[3].FindControl("cbEstado");
                    if (!Operators.ConditionalCompareObjectEqual(dt.Rows[i][4], "P", false))
                    {
                        Cmb.Checked = false;
                    }
                    else
                    {
                        Cmb.Checked = true;
                    }
                }
                this.cmbProductos.SelectedIndex = -1;
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
            this.lblError1.Visible = true;
            this.lblError2.Visible = true;
            this.lblError3.Visible = true;
            this.lblError.Text = mensaje;
            this.lblError1.Text = mensaje;
            this.lblError2.Text = mensaje;
            this.lblError3.Text = mensaje;
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
                this.ConfiguracionActivos();
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            this.lblError3.Visible = false;
            try
            {
                if (Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
                {
                    this.MensajeError("Debe digitar un código de producto");
                }
                else
                {
                    string[] indicador = this.wsData.IndicadorCuentaCorriente(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.txtCodigo.Text)).Split(new char[] { '-' });
                    if (Conversions.ToDouble(indicador[0]) == 0)
                    {
                        if (Operators.CompareString(indicador[2], "S", false) == 0)
                        {
                            this.lblPropiedad.Visible = true;
                            this.cmbPropiedad.Visible = true;
                        }
                        this.lblCapacidad.Visible = true;
                        this.cmbCapacidadProducto.Visible = true;
                        this.lblCantidad.Visible = true;
                        this.txtCantidad.Visible = true;
                        this.ibProducto.Visible = true;
                        DataSet dtCapacidad = new DataSet();
                        dtCapacidad = this.wsData.CapacidadesProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(this.txtCodigo.Text));
                        if (dtCapacidad.Tables[0].Rows.Count <= 0)
                        {
                            this.lblPropiedad.Visible = false;
                            this.cmbPropiedad.Visible = false;
                            this.lblCapacidad.Visible = false;
                            this.cmbCapacidadProducto.Visible = false;
                            this.lblCantidad.Visible = false;
                            this.txtCantidad.Visible = false;
                            this.ibProducto.Visible = false;
                        }
                        else
                        {
                            this.cmbCapacidadProducto.DataSource = dtCapacidad.Tables[0];
                            this.cmbCapacidadProducto.DataBind();
                        }
                    }
                    else
                    {
                        this.MensajeError(string.Concat(indicador[0], "-", indicador[1]));
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                this.lblPropiedad.Visible = false;
                this.cmbPropiedad.Visible = false;
                this.lblCapacidad.Visible = false;
                this.cmbCapacidadProducto.Visible = false;
                this.lblCantidad.Visible = false;
                this.txtCantidad.Visible = false;
                this.ibProducto.Visible = false;
                ProjectData.ClearProjectError();
            }
        }
    }
}