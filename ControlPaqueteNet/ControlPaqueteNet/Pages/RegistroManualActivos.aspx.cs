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
    public partial class RegistroManualActivos : System.Web.UI.Page
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
            try
            {
                if (Operators.CompareString(CodigoActivo, "", false) == 0)
                {
                    this.MensajeError("Debe digitar un código de familia");
                    return;
                }
                else if (Operators.CompareString(Cantidad, "", false) == 0)
                {
                    this.MensajeError("Debe digitar una cantidad");
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
                        Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
                        dt.Rows[i][4] = Texto.Text;
                    }
                    bool band = false;
                    int num = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        if (Operators.CompareString(this.grActivoPropio.Rows[i].Cells[0].Text, CodigoActivo, false) == 0)
                        {
                            Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
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
                            TextBox x = (TextBox)this.grActivoPropio.Rows[checked(this.grActivoPropio.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrila");
                            x.Text = Cantidad;
                        }
                    }
                    int count1 = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= count1; i = checked(i + 1))
                    {
                        Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
                        Texto.Text = Conversions.ToString(dt.Rows[i][4]);
                    }
                    this.txtFamilia.Text = "";
                    this.txtCantidad.Text = "";
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        protected void AgregarAjenos_Click(object sender, EventArgs e)
        {
            this.ModalPopupExtender1.Hide();
            if (this.cmbActivoAjeno.SelectedIndex == 0)
            {
                this.ActualizarGrillaActivoAjeno(this.txtFamAjeno.Text, this.txtCantAjeno.Text);
            }
            else
            {
                this.InsertarEnGrillaActivoAjeno();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.ModalPopupExtender.Hide();
            if (Operators.CompareString(this.txtFamAjeno.Text, "", false) == 0)
            {
                this.ActualizarGrillaActivoPropio(this.txtFamilia.Text, this.txtCantidad.Text);
            }
        }

        private void CargarActivosAjenos()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            try
            {
                DataSet ConsultarActivosAjenos = this.wsData.CrearActivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "A");
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
            try
            {
                DataSet ConsultarActivosPropios = this.wsData.CrearActivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "P");
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

        private void Configuracion()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
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
            try
            {
                DataSet CrearActivosAjenos = this.wsData.CrearActivosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "A");
                if (CrearActivosAjenos.Tables[0].Rows.Count > 0)
                {
                    this.grActivoAjeno.DataSource = CrearActivosAjenos.Tables[0];
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
            try
            {
                DataSet CrearActivosPropios = this.wsData.CrearActivosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "P");
                if (CrearActivosPropios.Tables[0].Rows.Count > 0)
                {
                    this.grActivoPropio.DataSource = CrearActivosPropios.Tables[0];
                    this.grActivoPropio.DataBind();
                    int count = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        TextBox Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
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

        private void GuardarActivos()
        {
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
            try
            {
                if (!(this.grActivoAjeno.Rows.Count > 0 | this.grActivoPropio.Rows.Count > 0))
                {
                    this.MensajeError("No se han registrado activos");
                }
                else
                {
                    DataSet dsActivoAjeno = new DataSet();
                    DataSet dsActivoPropio = new DataSet();
                    DataTable dtActivoAjeno = new DataTable();
                    DataTable dtActivoPropio = new DataTable();
                    dtActivoAjeno.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                    dtActivoAjeno.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
                    dtActivoPropio.Columns.Add(new DataColumn("FAMILIA", typeof(string)));
                    dtActivoPropio.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
                    int count = checked(this.grActivoAjeno.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        DataRow dr = dtActivoAjeno.NewRow();
                        dr[0] = this.grActivoAjeno.Rows[i].Cells[0].Text;
                        TextBox Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
                        dr[1] = Texto.Text;
                        dtActivoAjeno.Rows.Add(dr);
                    }
                    dsActivoAjeno.Tables.Add(dtActivoAjeno);
                    int num = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        DataRow dr = dtActivoPropio.NewRow();
                        dr[0] = this.grActivoPropio.Rows[i].Cells[0].Text;
                        TextBox Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
                        dr[1] = Texto.Text;
                        dtActivoPropio.Rows.Add(dr);
                    }
                    dsActivoPropio.Tables.Add(dtActivoPropio);
                    string Registro = "";
                    Registro = this.wsData.GuardarActivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "N", "A", Conversions.ToString(this.Session["UsuarioRegistro"]), dsActivoAjeno, dsActivoPropio);
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

        public void ibActivoPropio_Click(object sender, ImageClickEventArgs e)
        {
            if (Operators.CompareString(this.txtFamAjeno.Text, "", false) == 0)
            {
                this.ActualizarGrillaActivoPropio(this.txtFamilia.Text, this.txtCantidad.Text);
            }
        }

        public void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            this.GuardarActivos();
        }

        private void InsertarEnGrillaActivoAjeno()
        {
            TextBox Texto;
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            this.lblError2.Visible = false;
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
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)this.Session["ActivosPropios"];
                if (!this.oFactory.ExisteFilaEnGrillaActivos(dt, Conversions.ToInteger(this.cmbActivoPropio.SelectedValue)))
                {
                    int count = checked(this.grActivoPropio.Rows.Count - 1);
                    for (int i = 0; i <= count; i = checked(i + 1))
                    {
                        Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
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
                        Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
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

        private void MensajeError(string mensaje)
        {
            this.lblError.Visible = true;
            this.lblError1.Visible = true;
            this.lblError2.Visible = true;
            this.lblError.Text = mensaje;
            this.lblError1.Text = mensaje;
            this.lblError2.Text = mensaje;
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
    }
}