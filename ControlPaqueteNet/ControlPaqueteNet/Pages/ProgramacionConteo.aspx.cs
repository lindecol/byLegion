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
    public partial class ProgramacionConteo : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        private List<DateTime> lstFechas;
        private Factory.Utilidades oFactory;

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
                DataSet ConsultarSubdepositos = this.wsData.ConsultarSubdepositosConfigurados(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Sucursal);
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
            this.lblError.Visible = false;
            try
            {
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
            this.lblError.Visible = false;
            this.InsertarEnGrilla(string.Concat(this.cmbSucursal.SelectedValue, "-", this.cmbSucursal.Items[this.cmbSucursal.SelectedIndex].Text), string.Concat(this.cmbSector.SelectedValue, "-", this.cmbSector.Items[this.cmbSector.SelectedIndex].Text), "");
        }

        public void cmbSubdeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.lblError.Visible = false;
                string[] vector = this.wsData.ObtenerSectorSubdeposito(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue), Conversions.ToInteger(this.cmbSubdeposito.SelectedValue)).Split(new char[] { '|' });
                if (Conversions.ToDouble(vector[0]) != 0)
                {
                    this.MensajeError(string.Concat(vector[0], "-", vector[1]));
                }
                else
                {
                    this.InsertarEnGrilla(string.Concat(this.cmbSucursal.SelectedValue, "-", this.cmbSucursal.Items[this.cmbSucursal.SelectedIndex].Text), vector[2], string.Concat(this.cmbSubdeposito.SelectedValue, "-", this.cmbSubdeposito.Items[this.cmbSubdeposito.SelectedIndex].Text));
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        public void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarSectores(Conversions.ToInteger(this.cmbSucursal.SelectedValue));
            this.CargarSubdepositos(Conversions.ToInteger(this.cmbSucursal.SelectedValue));
        }

        public void cmbTipoProgramacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)this.Session["Grilla"];
            dt.Rows.Clear();
            this.grConteo.DataSource = dt;
            this.grConteo.DataBind();
            this.Session["Grilla"] = dt;
            string selectedValue = this.cmbTipoProgramacion.SelectedValue;
            if (Operators.CompareString(selectedValue, "A", false) == 0)
            {
                this.cmbSector.Enabled = true;
                this.cmbSubdeposito.Enabled = false;
            }
            else if (Operators.CompareString(selectedValue, "P", false) == 0)
            {
                this.cmbSector.Enabled = false;
                this.cmbSubdeposito.Enabled = true;
            }
            else if (Operators.CompareString(selectedValue, "M", false) != 0)
            {
                this.cmbSector.Enabled = false;
                this.cmbSubdeposito.Enabled = false;
            }
            else
            {
                this.cmbSector.Enabled = false;
                this.cmbSubdeposito.Enabled = true;
            }
        }

        private void Configuracion()
        {
            this.lblError.Visible = false;
            try
            {
                this.tbProgramacion.ActiveTabIndex = 0;
                this.CargarSucursales();
                this.CargarUsuarios();
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("NombreSucursal", typeof(string)));
                dt.Columns.Add(new DataColumn("NombreSector", typeof(string)));
                dt.Columns.Add(new DataColumn("NombreSubdeposito", typeof(string)));
                this.Session["Grilla"] = dt;
                DataTable dtFecha = new DataTable();
                dtFecha.Columns.Add(new DataColumn("Fecha", typeof(string)));
                this.Session["Fecha"] = dtFecha;
                List<DateTime> lstFechas = new List<DateTime>();
                this.Session["Calendario"] = lstFechas;
                this.Session["SucursalesConteo"] = lstFechas;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void Controles(bool Estado)
        {
            this.txtDate.Enabled = Estado;
            this.ibCalendario.Enabled = Estado;
            this.cmbHoraInicio.Enabled = Estado;
            this.cmbHoraAP.Enabled = Estado;
            this.cmbHoraFin.Enabled = Estado;
            this.cmbHora.Enabled = Estado;
            this.cmbTipoProgramacion.Enabled = Estado;
            this.cmbUsuario.Enabled = Estado;
            this.cmbSucursal.Enabled = Estado;
            if (Operators.CompareString(this.cmbTipoProgramacion.SelectedValue, "A", false) != 0)
            {
                this.cmbSubdeposito.Enabled = Estado;
            }
            else
            {
                this.cmbSector.Enabled = Estado;
            }
            this.grConteo.Enabled = Estado;
            this.tbProgramacion.Enabled = Estado;
            this.rbActual.Enabled = Estado;
            this.rbFecha.Enabled = Estado;
            this.txtFinaliza.Enabled = Estado;
            this.ibFinaliza.Enabled = Estado;
            this.MisFechas.Enabled = Estado;
            this.ibGuardar.Enabled = Estado;
        }

        private void EliminarGrillaRepetitiva(DateTime Fecha)
        {
            this.lblError.Visible = false;
            try
            {
                this.Session["Fecha"] = this.oFactory.EliminarFilaEnGrillaProgramacion((DataTable)this.Session["Fecha"], Conversions.ToString(Fecha));
                this.grRepetitiva.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Fecha"]);
                this.grRepetitiva.DataBind();
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

        private void grRepetitiva_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EliminarGrillaRepetitiva(Conversions.ToDate(this.grRepetitiva.Rows[this.grRepetitiva.SelectedIndex].Cells[0].Text));
        }

        public void ibConfirmar_Click(object sender, ImageClickEventArgs e)
        {
            DateTime fechaFin;
            IEnumerator enumerator = null;
            this.ibConfirmar.Visible = false;
            this.ibEliminar.Visible = false;
            this.grErrores.DataSource = null;
            this.grErrores.DataBind();
            this.Controles(true);
            if (!this.rbActual.Checked)
            {
                fechaFin = Conversions.ToDate(this.txtFinaliza.Text);
            }
            else
            {
                DateTime now = DateAndTime.Now;
                fechaFin = Conversions.ToDate(string.Concat("31/12/", Conversions.ToString(now.Year)));
            }
            switch (this.tbProgramacion.ActiveTabIndex)
            {
                case 0:
                    {
                        this.lstFechas.Add(Conversions.ToDate(this.txtDate.Text));
                        break;
                    }
                case 1:
                    {
                        this.lstFechas = this.oFactory.GenerarDiaria(Conversions.ToDate(this.txtDate.Text), fechaFin, this.rbDia1.Checked, Conversions.ToDouble(this.txtDia.Text));
                        break;
                    }
                case 2:
                    {
                        this.lstFechas = this.oFactory.GenerarSemanal(Conversions.ToDate(this.txtDate.Text), fechaFin, this.chkDomingo.Checked, this.chkLunes.Checked, this.chkMartes.Checked, this.chkMiercoles.Checked, this.chkJueves.Checked, this.chkViernes.Checked, this.chkSabado.Checked, Conversions.ToDouble(this.txtSemana.Text));
                        break;
                    }
                case 3:
                    {
                        this.lstFechas = this.oFactory.GenerarMensual(Conversions.ToDate(this.txtDate.Text), fechaFin, this.rbMes1.Checked, Conversions.ToInteger(this.txtDiaMes.Text), Conversions.ToDouble(this.txtMes.Text), Conversions.ToInteger(this.cmbDiaMensual.SelectedValue), Conversions.ToInteger(this.cmbTipo.SelectedValue));
                        break;
                    }
                case 4:
                    {
                        DataTable dtRepetitiva = new DataTable();
                        dtRepetitiva = (DataTable)this.Session["Fecha"];
                        try
                        {
                            enumerator = dtRepetitiva.Rows.GetEnumerator();
                            while (enumerator.MoveNext())
                            {
                                DataRow r = (DataRow)enumerator.Current;
                                if (DateTime.Compare(Conversions.ToDate(r[0]), Conversions.ToDate(this.txtDate.Text)) >= 0 & DateTime.Compare(Conversions.ToDate(r[0]), fechaFin) <= 0)
                                {
                                    this.lstFechas.Add(Conversions.ToDate(r[0]));
                                }
                            }
                            break;
                        }
                        finally
                        {
                            if (enumerator is IDisposable)
                            {
                                (enumerator as IDisposable).Dispose();
                            }
                        }
                        break;
                    }
            }
            this.InsertarRegistro(true);
        }

        public void ibEliminar_Click(object sender, ImageClickEventArgs e)
        {
            this.ibConfirmar.Visible = false;
            this.ibEliminar.Visible = false;
            this.grErrores.DataSource = null;
            this.grErrores.DataBind();
            this.Controles(true);
            this.Response.Redirect("ConteosReprogramacion.aspx");
        }

        public void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            DateTime fechaFin;
            IEnumerator enumerator = null;
            if (this.ValidarDatos())
            {
                this.lblError.Visible = false;
                try
                {
                    if (!this.rbActual.Checked)
                    {
                        fechaFin = Conversions.ToDate(this.txtFinaliza.Text);
                    }
                    else
                    {
                        DateTime now = DateAndTime.Now;
                        fechaFin = Conversions.ToDate(string.Concat("31/12/", Conversions.ToString(now.Year)));
                    }
                    switch (this.tbProgramacion.ActiveTabIndex)
                    {
                        case 0:
                            {
                                this.lstFechas.Add(Conversions.ToDate(this.txtDate.Text));
                                break;
                            }
                        case 1:
                            {
                                this.lstFechas = this.oFactory.GenerarDiaria(Conversions.ToDate(this.txtDate.Text), fechaFin, this.rbDia1.Checked, Conversions.ToDouble(this.txtDia.Text));
                                break;
                            }
                        case 2:
                            {
                                this.lstFechas = this.oFactory.GenerarSemanal(Conversions.ToDate(this.txtDate.Text), fechaFin, this.chkDomingo.Checked, this.chkLunes.Checked, this.chkMartes.Checked, this.chkMiercoles.Checked, this.chkJueves.Checked, this.chkViernes.Checked, this.chkSabado.Checked, Conversions.ToDouble(this.txtSemana.Text));
                                break;
                            }
                        case 3:
                            {
                                this.lstFechas = this.oFactory.GenerarMensual(Conversions.ToDate(this.txtDate.Text), fechaFin, this.rbMes1.Checked, Conversions.ToInteger(this.txtDiaMes.Text), Conversions.ToDouble(this.txtMes.Text), Conversions.ToInteger(this.cmbDiaMensual.SelectedValue), Conversions.ToInteger(this.cmbTipo.SelectedValue));
                                break;
                            }
                        case 4:
                            {
                                DataTable dtRepetitiva = new DataTable();
                                dtRepetitiva = (DataTable)this.Session["Fecha"];
                                try
                                {
                                    enumerator = dtRepetitiva.Rows.GetEnumerator();
                                    while (enumerator.MoveNext())
                                    {
                                        DataRow r = (DataRow)enumerator.Current;
                                        if (DateTime.Compare(Conversions.ToDate(r[0]), Conversions.ToDate(this.txtDate.Text)) >= 0 & DateTime.Compare(Conversions.ToDate(r[0]), fechaFin) <= 0)
                                        {
                                            this.lstFechas.Add(Conversions.ToDate(r[0]));
                                        }
                                    }
                                    break;
                                }
                                finally
                                {
                                    if (enumerator is IDisposable)
                                    {
                                        (enumerator as IDisposable).Dispose();
                                    }
                                }
                                break;
                            }
                    }
                    this.InsertarRegistro(false);
                }
                catch (Exception exception)
                {
                    ProjectData.SetProjectError(exception);
                    this.MensajeError(exception.Message);
                    ProjectData.ClearProjectError();
                }
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

        private void InsertarGrillaRepetitiva()
        {
            this.lblError.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)this.Session["Fecha"];
                if (!this.oFactory.ExisteFilaEnGrillaProgramacion(dt, Conversions.ToString(this.CalendarRepetitiva.SelectedDate)))
                {
                    int year = this.CalendarRepetitiva.SelectedDate.Year;
                    DateTime now = DateAndTime.Now;
                    if (DateTime.Compare(this.CalendarRepetitiva.SelectedDate, DateAndTime.Now) > 0 & year == now.Year)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = Strings.Format(this.CalendarRepetitiva.SelectedDate, "dd/MM/yyyy");
                        dt.Rows.Add(dr);
                        this.Session["Fecha"] = dt;
                        this.grRepetitiva.DataSource = dt;
                        this.grRepetitiva.DataBind();
                    }
                }
                this.CalendarRepetitiva.SelectedDates.Clear();
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void InsertarRegistro(bool Confirmacion)
        {
            IEnumerator enumerator = null;
            IEnumerator enumerator1 = null;
            IEnumerator enumerator2 = null;
            this.lblError.Visible = false;
            try
            {
                int UltimoConteo = this.wsData.UltimoConteo(Conversions.ToString(this.Session["Conexion"]));
                List<string> lstSucursales = new List<string>();
                DataTable dt = new DataTable();
                dt = ((DataTable)this.Session["Grilla"]).Copy();
                try
                {
                    enumerator = dt.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow dr = (DataRow)enumerator.Current;
                        if (!lstSucursales.Contains(Conversions.ToString(dr[0])))
                        {
                            lstSucursales.Add(Conversions.ToString(dr[0]));
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                string Programacion = this.wsData.ProgramarConteo(Conversions.ToString(this.Session["Conexion"]), this.lstFechas.ToArray(), string.Concat(this.cmbHoraInicio.Items[this.cmbHoraInicio.SelectedIndex].Text, " ", this.cmbHora.Items[this.cmbHora.SelectedIndex].Text), string.Concat(this.cmbHoraFin.Items[this.cmbHoraFin.SelectedIndex].Text, " ", this.cmbHoraAP.Items[this.cmbHoraAP.SelectedIndex].Text), this.cmbTipoProgramacion.SelectedValue, Conversions.ToInteger(this.cmbUsuario.SelectedValue), this.chkMail.Checked, false, Conversions.ToString(this.tbProgramacion.ActiveTabIndex), Conversions.ToString(this.Session["UsuarioRegistro"]), ds, lstSucursales.ToArray(), Confirmacion);
                if (Operators.CompareString(Programacion, "", false) == 0)
                {
                    DataSet dataS = new DataSet();
                    dataS = this.wsData.ObtenerConteos(Conversions.ToString(this.Session["Conexion"]), UltimoConteo);
                    List<DateTime> lstFechas = new List<DateTime>();
                    try
                    {
                        enumerator2 = dataS.Tables[0].Rows.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            DataRow dr = (DataRow)enumerator2.Current;
                            DateTime Fecha = Conversions.ToDate(dr[0]);
                            this.MisFechas.SelectedDates.Add(Fecha);
                            lstFechas.Add(Fecha);
                        }
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
                    this.Session["Calendario"] = lstFechas;
                }
                else if (Operators.CompareString(Programacion.Substring(0, 1), ".", false) == 0)
                {
                    string[] VectorErrores = Programacion.Split(new char[] { '|' });
                    dt = new DataTable();
                    dt.Columns.Add(new DataColumn("Error", typeof(string)));
                    int length = checked(checked((int)VectorErrores.Length) - 2);
                    for (int i = 0; i <= length; i = checked(i + 1))
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = VectorErrores[i];
                        dt.Rows.Add(dr);
                    }
                    this.grErrores.DataSource = dt;
                    this.grErrores.DataBind();
                    this.Controles(false);
                    this.ibConfirmar.Visible = true;
                    this.ibEliminar.Visible = true;
                    DataSet dataS = new DataSet();
                    dataS = this.wsData.ObtenerConteos(Conversions.ToString(this.Session["Conexion"]), UltimoConteo);
                    List<DateTime> lstFechas = new List<DateTime>();
                    try
                    {
                        enumerator1 = dataS.Tables[0].Rows.GetEnumerator();
                        while (enumerator1.MoveNext())
                        {
                            DataRow dr = (DataRow)enumerator1.Current;
                            DateTime Fecha = Conversions.ToDate(dr[0]);
                            this.MisFechas.SelectedDates.Add(Fecha);
                            lstFechas.Add(Fecha);
                        }
                    }
                    finally
                    {
                        if (enumerator1 is IDisposable)
                        {
                            (enumerator1 as IDisposable).Dispose();
                        }
                    }
                    this.Session["Calendario"] = lstFechas;
                }
                else
                {
                    this.MensajeError(Programacion);
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

        private void MisFechas_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            List<DateTime> lstFechas = new List<DateTime>();
            lstFechas = (List<DateTime>)this.Session["Calendario"];
            int count = checked(lstFechas.Count - 1);
            for (int i = 0; i <= count; i = checked(i + 1))
            {
                this.MisFechas.SelectedDates.Add(lstFechas[i]);
            }
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
            //else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PROPRO"), "1", false) != 0)
            else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session[2]), "CP_PROPRO"), "1", false) != 0)
            {
                this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    this.Configuracion();
                    this.MisFechas.SelectedDates.Clear();
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
                dt = (DataTable)this.Session["Grilla"];
                if (Operators.CompareString(this.txtDate.Text, "", false) == 0)
                {
                    this.MensajeError("Debe escoger una fecha de inicio");
                    this.txtDate.Focus();
                }
                else if (DateTime.Compare(Conversions.ToDate(this.txtDate.Text), DateAndTime.Now) <= 0)
                {
                    this.MensajeError("La fecha de inicio debe ser mayor que el día de hoy");
                    this.txtDate.Focus();
                }
                else if (!this.oFactory.ValidarHora(Conversions.ToInteger(this.cmbHoraInicio.SelectedValue), Conversions.ToInteger(this.cmbHoraFin.SelectedValue), Conversions.ToInteger(this.cmbHoraAP.SelectedValue)))
                {
                    this.MensajeError("La hora fin debe ser mayor que la hora inicio");
                    this.cmbHoraInicio.Focus();
                }
                else if (dt.Rows.Count < 1)
                {
                    this.MensajeError("Debe escoger al menos un subdepósito para el conteo");
                    this.cmbSucursal.Focus();
                }
                else if (!this.rbActual.Checked & !this.rbFecha.Checked)
                {
                    this.MensajeError("Debe seleccionar cuando terminará la programación del conteo");
                    this.rbActual.Focus();
                }
                else if (!(this.rbFecha.Checked & Operators.CompareString(this.txtFinaliza.Text, "", false) == 0))
                {
                    switch (this.tbProgramacion.ActiveTabIndex)
                    {
                        case 0:
                            {
                                this.lblError.Visible = false;
                                ValidarDatos = true;
                                return ValidarDatos;
                            }
                        case 1:
                            {
                                if (!(this.rbDia1.Checked | this.rbDia2.Checked))
                                {
                                    this.MensajeError("Debe escoger el tipo de programación para el día");
                                }
                                else if (!this.rbDia1.Checked)
                                {
                                    this.lblError.Visible = false;
                                    ValidarDatos = true;
                                    return ValidarDatos;
                                }
                                else if (Operators.CompareString(this.txtDia.Text, "", false) == 0)
                                {
                                    this.MensajeError("Debe escoger el intervalo de días");
                                }
                                else if (!this.oFactory.SoloNumeros(this.txtDia.Text))
                                {
                                    this.MensajeError("El intervalo de días debe ser numérico y en el rango de 1 a 31");
                                }
                                else if (!(Conversions.ToDouble(this.txtDia.Text) < 1 | Conversions.ToDouble(this.txtDia.Text) > 31))
                                {
                                    this.lblError.Visible = false;
                                    ValidarDatos = true;
                                    return ValidarDatos;
                                }
                                else
                                {
                                    this.MensajeError("El intervalo de días debe ser numérico y en el rango de 1 a 31");
                                }
                                break;
                            }
                        case 2:
                            {
                                if (!(this.chkDomingo.Checked | this.chkLunes.Checked | this.chkMartes.Checked | this.chkMiercoles.Checked | this.chkJueves.Checked | this.chkViernes.Checked | this.chkSabado.Checked))
                                {
                                    this.MensajeError("Debe escoger el intervalo de semanas");
                                }
                                else if (Operators.CompareString(this.txtSemana.Text, "", false) == 0)
                                {
                                    this.MensajeError("Debe escoger el intervalo de semanas");
                                }
                                else if (!this.oFactory.SoloNumeros(this.txtSemana.Text))
                                {
                                    this.MensajeError("El intervalo de semanas debe ser numérico y en el rango de 1 a 4");
                                }
                                else if (!(Conversions.ToInteger(this.txtSemana.Text) < 1 | Conversions.ToInteger(this.txtSemana.Text) > 4))
                                {
                                    this.lblError.Visible = false;
                                    ValidarDatos = true;
                                    return ValidarDatos;
                                }
                                else
                                {
                                    this.MensajeError("El intervalo de semanas debe ser numérico y en el rango de 1 a 4");
                                }
                                break;
                            }
                        case 3:
                            {
                                if (!(this.rbMes1.Checked | this.rbMes2.Checked))
                                {
                                    this.MensajeError("Debe escoger el tipo de programación para el mes");
                                }
                                else if (!this.rbMes1.Checked)
                                {
                                    if (Operators.CompareString(this.txtMesDia.Text, "", false) == 0)
                                    {
                                        this.MensajeError("Debe escoger el intervalo de meses");
                                    }
                                    else if (!this.oFactory.SoloNumeros(this.txtMesDia.Text))
                                    {
                                        this.MensajeError("El intervalo de meses debe ser numérico y en el rango de 1 a 12");
                                    }
                                    else if (!(Conversions.ToDouble(this.txtMesDia.Text) < 1 | Conversions.ToDouble(this.txtMesDia.Text) > 12))
                                    {
                                        this.lblError.Visible = false;
                                        ValidarDatos = true;
                                        return ValidarDatos;
                                    }
                                    else
                                    {
                                        this.MensajeError("El intervalo de meses debe ser numérico y en el rango de 1 a 12");
                                    }
                                }
                                else if (Operators.CompareString(this.txtDiaMes.Text, "", false) == 0)
                                {
                                    this.MensajeError("Debe escoger el intervalo de días");
                                }
                                else if (!this.oFactory.SoloNumeros(this.txtDiaMes.Text))
                                {
                                    this.MensajeError("El intervalo de días debe ser numérico y en el rango de 1 a 31");
                                }
                                else if (Conversions.ToDouble(this.txtDiaMes.Text) < 1 | Conversions.ToDouble(this.txtDiaMes.Text) > 31)
                                {
                                    this.MensajeError("El intervalo de días debe ser numérico y en el rango de 1 a 31");
                                }
                                else if (Operators.CompareString(this.txtMes.Text, "", false) == 0)
                                {
                                    this.MensajeError("Debe escoger el intervalo de meses");
                                }
                                else if (!this.oFactory.SoloNumeros(this.txtMes.Text))
                                {
                                    this.MensajeError("El intervalo de meses debe ser numérico y en el rango de 1 a 12");
                                }
                                else if (!(Conversions.ToDouble(this.txtMes.Text) < 1 | Conversions.ToDouble(this.txtMes.Text) > 12))
                                {
                                    this.lblError.Visible = false;
                                    ValidarDatos = true;
                                    return ValidarDatos;
                                }
                                else
                                {
                                    this.MensajeError("El intervalo de meses debe ser numérico y en el rango de 1 a 12");
                                }
                                break;
                            }
                        case 4:
                            {
                                DataTable dtRepetitiva = new DataTable();
                                if (((DataTable)this.Session["Fecha"]).Rows.Count >= 1)
                                {
                                    this.lblError.Visible = false;
                                    ValidarDatos = true;
                                    return ValidarDatos;
                                }
                                else
                                {
                                    this.MensajeError("Debe escoger al menos una fecha en la que se ejecutará la programación");
                                    break;
                                }
                            }
                    }
                }
                else
                {
                    this.MensajeError("Debe escoger la fecha en la cual finalizará el conteo");
                    this.txtFinaliza.Focus();
                }
                ValidarDatos = false;
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