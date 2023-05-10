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
    public partial class ReprogramacionConteo : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private Utilidades oFactory = new Utilidades();
        private List<DateTime> lstFechas = new List<DateTime>();

        private void CargarSectores(int sucursal)
        {
            this.lblError.Visible = false;
            try
            {
                this.cmbSector.Items.Clear();
                this.cmbSector.DataSource = null;
                this.cmbSector.DataBind();
                this.cmbSector.Items.Add("");
                DataSet ConsultarSectores = this.wsData.CrearSectores(Conversions.ToString(this.Session["Conexion"]), sucursal, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
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

        private void CargarSubdepositos(int Sucursal)
        {
            this.lblError.Visible = false;
            try
            {
                this.cmbSubdeposito.Items.Clear();
                this.cmbSubdeposito.DataSource = null;
                this.cmbSubdeposito.DataBind();
                this.cmbSubdeposito.Items.Add("");
                DataSet ConsultarSubdepositos = this.wsData.ConsultarSubdepositos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Sucursal);
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

        private void CargarUsuarios()
        {
            this.lblError.Visible = false;
            try
            {
                DataSet ConsultarUsuarios = this.wsData.ObtenerUsuarios(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
                if (ConsultarUsuarios.Tables[0].Rows.Count > 0)
                {
                    this.cmbUsuario.DataSource = ConsultarUsuarios.Tables[0];
                    this.cmbUsuario.DataBind();
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
            this.InsertarEnGrilla(Conversions.ToString(this.Session["SucursalConteo"]), string.Concat(this.cmbSector.SelectedValue, "-", this.cmbSector.Items[this.cmbSector.SelectedIndex].Text), "");
        }

        public void cmbSubdeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InsertarEnGrilla(Conversions.ToString(this.Session["SucursalConteo"]), "", string.Concat(this.cmbSubdeposito.SelectedValue, "-", this.cmbSubdeposito.Items[this.cmbSubdeposito.SelectedIndex].Text));
        }

        private void Configuracion()
        {
            object[] objArray;
            this.lblError.Visible = false;
            try
            {
                this.lblSubtitulo.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]), " --- Tipo: "), this.Session["TipoConteo"]), " --- Fecha: "), this.Session["FechaInicio"]));
                this.txtDate.Text = Strings.Format(Conversions.ToDate(this.Session["FechaInicio"]), "dddd, dd 'de' MMMM 'de' yyyy");
                this.cmbHoraInicio.SelectedIndex = this.oFactory.ObtenerIndicePorHora(Conversions.ToString(this.Session["HoraInicio"]).Substring(0, 5));
                this.cmbHora.SelectedIndex = this.oFactory.ObtenerIndiceAMPM(Conversions.ToString(this.Session["HoraInicio"]).Substring(6));
                this.cmbHoraFin.SelectedIndex = this.oFactory.ObtenerIndicePorHora(Conversions.ToString(this.Session["HoraFin"]).Substring(0, 5));
                this.cmbHoraAP.SelectedIndex = this.oFactory.ObtenerIndiceAMPM(Conversions.ToString(this.Session["HoraFin"]).Substring(6));
                DataSet dt = new DataSet();
                dt = this.wsData.ObtenerSubdepositosConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
                this.grConteo.DataSource = dt.Tables[0];
                this.grConteo.DataBind();
                this.Session["Grilla"] = dt.Tables[0];
                this.Session["SucursalConteo"] = this.grConteo.Rows[0].Cells[0].Text;
                DataSet ConsultarConteo = this.wsData.ObtenerDatosConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]));
                if (ConsultarConteo.Tables[0].Rows.Count > 0)
                {
                    this.cmbUsuario.SelectedValue = Conversions.ToString(ConsultarConteo.Tables[0].Rows[0][0]);
                    this.cmbTipoProgramacion.SelectedValue = Conversions.ToString(ConsultarConteo.Tables[0].Rows[0][1]);
                    if (!Operators.ConditionalCompareObjectEqual(ConsultarConteo.Tables[0].Rows[0][1], "A", false))
                    {
                        this.cmbSector.Enabled = false;
                        this.cmbSubdeposito.Enabled = true;
                        object item = this.Session["SucursalConteo"];
                        objArray = new object[] { 0, this.grConteo.Rows[0].Cells[0].Text.IndexOf("-") };
                        this.CargarSubdepositos(Conversions.ToInteger(NewLateBinding.LateGet(item, null, "Substring", objArray, null, null, null)));
                    }
                    else
                    {
                        this.cmbSector.Enabled = true;
                        this.cmbSubdeposito.Enabled = false;
                        object obj = this.Session["SucursalConteo"];
                        objArray = new object[] { 0, this.grConteo.Rows[0].Cells[0].Text.IndexOf("-") };
                        this.CargarSectores(Conversions.ToInteger(NewLateBinding.LateGet(obj, null, "Substring", objArray, null, null, null)));
                    }
                }
                this.CargarUsuarios();
                this.cmbTipoProgramacion.Enabled = false;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void EliminarRegistro(string Sucursal, string Sector, string Subdep)
        {
            this.lblError.Visible = false;
            try
            {
                if (Operators.CompareString(Subdep, "&nbsp;", false) == 0)
                {
                    Subdep = "";
                }
                else if (Operators.CompareString(Sector, "&nbsp;", false) == 0)
                {
                    Sector = "";
                }
                this.Session["Grilla"] = this.oFactory.EliminarFilaEnGrillaProgramacion((DataTable)this.Session["Grilla"], Sucursal, Sector, Subdep);
                this.grConteo.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Grilla"]);
                this.grConteo.DataBind();
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void grConteo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow item = this.grConteo.Rows[this.grConteo.SelectedIndex];
            this.EliminarRegistro(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text);
            item = null;
        }

        public void ibCalendario_Click(object sender, ImageClickEventArgs e)
        {
            if (!this.MiCalendario.Visible)
            {
                this.MiCalendario.Visible = true;
            }
            else
            {
                this.MiCalendario.Visible = false;
            }
        }

        public void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.ValidarDatos())
            {
                this.InsertarRegistro();
            }
        }

        private void InsertarEnGrilla(string Sucursal, string Sector, string Subdep)
        {
            this.lblError.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)this.Session["Grilla"];
                if (!this.oFactory.ExisteFilaEnGrillaProgramacion(dt, Sucursal, Sector, Subdep))
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = Sucursal;
                    dr[1] = Sector;
                    dr[2] = Subdep;
                    dt.Rows.Add(dr);
                    this.Session["Grilla"] = dt;
                    this.grConteo.DataSource = dt;
                    this.grConteo.DataBind();
                }
                this.cmbSubdeposito.Text = "";
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void InsertarRegistro()
        {
            this.lblError.Visible = false;
            try
            {
                if (DateTime.Compare(this.MiCalendario.SelectedDate, Conversions.ToDate("0:00:00")) == 0)
                {
                    this.MiCalendario.SelectedDate = Conversions.ToDate(this.Session["FechaInicio"]);
                }
                DataTable dt = new DataTable();
                dt = ((DataTable)this.Session["Grilla"]).Copy();
                DataSet dsRepro = new DataSet();
                dsRepro.Tables.Add(dt);
                string Reprogramacion = this.wsData.ReprogramarConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), this.MiCalendario.SelectedDate, string.Concat(this.cmbHoraInicio.Items[this.cmbHoraInicio.SelectedIndex].Text, " ", this.cmbHora.Items[this.cmbHora.SelectedIndex].Text), string.Concat(this.cmbHoraFin.Items[this.cmbHoraFin.SelectedIndex].Text, " ", this.cmbHoraAP.Items[this.cmbHoraAP.SelectedIndex].Text), this.cmbTipoProgramacion.SelectedValue, Conversions.ToInteger(this.cmbUsuario.SelectedValue), Conversions.ToString(this.Session["UsuarioRegistro"]), dsRepro);
                if (Operators.CompareString(Reprogramacion, "", false) == 0)
                {
                    this.Response.Redirect("ConteosReprogramacion.aspx");
                }
                else
                {
                    this.MensajeError(Reprogramacion);
                }
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
            this.lblError.Text = mensaje;
        }

        private void MiCalendario_SelectionChanged(object sender, EventArgs e)
        {
            int year = this.MiCalendario.SelectedDate.Year;
            DateTime now = DateAndTime.Now;
            if (DateTime.Compare(this.MiCalendario.SelectedDate, DateAndTime.Now) > 0 & year == now.Year)
            {
                this.txtDate.Text = Strings.Format(this.MiCalendario.SelectedDate, "dddd, dd 'de' MMMM 'de' yyyy");
                this.lblError.Visible = false;
                this.MiCalendario.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.wsData.Credentials = CredentialCache.DefaultCredentials;
            //this.objSeg.Credentials = CredentialCache.DefaultCredentials;
            if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
            {
                this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
            }
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PROREP"), "1", false) != 0)
            {
                this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    this.Configuracion();
                }
                this.lstFechas = new List<DateTime>();
            }
        }

        private bool ValidarDatos()
        {
            bool ValidarDatos;
            this.lblError.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                if (((DataTable)this.Session["Grilla"]).Rows.Count <= 0)
                {
                    this.MensajeError("Debe escoger al menos un subdepósito para el conteo");
                    ValidarDatos = false;
                }
                else if (!this.oFactory.ValidarHora(Conversions.ToInteger(this.cmbHoraInicio.SelectedValue), Conversions.ToInteger(this.cmbHoraFin.SelectedValue), Conversions.ToInteger(this.cmbHoraAP.SelectedValue)))
                {
                    this.MensajeError("La hora fin no puede ser mayor que la hora inicio");
                    ValidarDatos = false;
                }
                else
                {
                    ValidarDatos = true;
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ValidarDatos = false;
                ProjectData.ClearProjectError();
            }
            return ValidarDatos;
        }
    }
}