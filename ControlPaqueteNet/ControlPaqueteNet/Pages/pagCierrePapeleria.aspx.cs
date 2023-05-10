using AjaxControlToolkit;
using ControlPaqueteNet.WsPackage;
using ControlPaqueteNet.WsPraxair;
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
    public partial class pagCierrePapeleria : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient objSeg = new WsPraxair.ServiceSoapClient();
        /// <summary>
        /// Proceso para grabar el cierre de papeleria
        /// </summary>
        /// <remarks></remarks>
        private void grabar()
        {
            DataRow drfila;
            TextBox txtJustificacion = new TextBox();
            DataTable dtRutas = new DataTable("Rutas");
            DataTable dtPapeleria = new DataTable("Papeleria");
            try
            {
                this.lblError.Visible = false;
                this.lblError.Text = "";
                int idCierre = Convert.ToInt32(this.lblIdconteo.Text);
                dtRutas.Columns.Add("ID_CONSECUTIVO");
                dtRutas.Columns.Add("P_JUSTIFICACION");
                int count = checked(this.grRutasPendientes.Rows.Count - 1);
                for (int fila = 0; fila <= count; fila = checked(fila + 1))
                {
                    txtJustificacion = (TextBox)this.grRutasPendientes.Rows[fila].FindControl("txtJustificacion");
                    drfila = dtRutas.NewRow();
                    drfila["ID_CONSECUTIVO"] = this.grRutasPendientes.Rows[fila].Cells[0].Text;
                    drfila["P_JUSTIFICACION"] = txtJustificacion.Text;
                    dtRutas.Rows.Add(drfila);
                }
                dtPapeleria.Columns.Add("ID_CONSECUTIVO");
                dtPapeleria.Columns.Add("P_DOC");
                dtPapeleria.Columns.Add("P_JUSTIFICACION");
                int num = checked(this.grRutasPendientes.Rows.Count - 1);
                for (int fila = 0; fila <= num; fila = checked(fila + 1))
                {
                    txtJustificacion = (TextBox)this.grRutasPendientes.Rows[fila].FindControl("txtJustificacion");
                    drfila = dtPapeleria.NewRow();
                    drfila["ID_CONSECUTIVO"] = this.grRutasPendientes.Rows[fila].Cells[0].Text;
                    drfila["P_DOC"] = this.grRutasPendientes.Rows[fila].Cells[5].Text;
                    drfila["P_JUSTIFICACION"] = txtJustificacion.Text;
                    dtPapeleria.Rows.Add(drfila);
                }
                this.wsData.CerrarPapeleria(Conversions.ToString(this.Session["Conexion"]), idCierre, Conversions.ToString(this.Session["UsuarioRegistro"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["Agencia"]), dtRutas, dtPapeleria);
                this.Response.Redirect("Apertura.aspx");
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                Exception ex = exception;
                this.lblError.Visible = true;
                this.lblError.Text = ex.Message;
                ProjectData.ClearProjectError();
            }
        }

        protected void ibAtras_Click(object sender, ImageClickEventArgs e)
        {
            this.Response.Redirect("./Apertura.aspx");
        }

        protected void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.validar())
            {
                this.grabar();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.wsData.Credentials = CredentialCache.DefaultCredentials;
            //this.objSeg.Credentials = CredentialCache.DefaultCredentials;
            if (this.Request.QueryString.Count != 0)
            {
                this.lblIdconteo.Text = this.Request.QueryString["id_cierre"];
                if (this.lblIdconteo.Text.Equals("0"))
                {
                    this.Response.Redirect("Error.aspx?mensaje=No ha seleccionado cierre");
                }
                if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
                {
                    this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
                }
                else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEAPE"), "1", false) != 0)
                {
                    this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
                }
                else if (!this.IsPostBack)
                {
                    this.ProcesosCierre();
                }
            }
            else
            {
                this.Response.Redirect("Error.aspx?mensaje=No ha seleccionado cierre");
            }
        }

        public void PapeleriaNoDigitada(int idCierre)
        {
            this.gdPapeleriaNoDigitada.DataSource = this.wsData.PapeleriaNoDigitada(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["Agencia"]), idCierre).Tables[0];
            this.gdPapeleriaNoDigitada.DataBind();
        }

        public void ProcesosCierre()
        {
            int idCierre = Convert.ToInt32(this.lblIdconteo.Text);
            this.rutasNoRendidas(idCierre);
            this.PapeleriaNoDigitada(idCierre);
        }

        public void rutasNoRendidas(int idCierre)
        {
            this.grRutasPendientes.DataSource = this.wsData.RutasNoRendidas(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["Agencia"]), idCierre).Tables[0];
            this.grRutasPendientes.DataBind();
        }

        private bool validar()
        {
            bool validar;
            TextBox txtJustificacion = new TextBox();
            this.lblError.Text = "";
            this.lblError1.Text = "";
            this.lblError.Visible = false;
            this.lblError1.Visible = false;
            int count = checked(this.grRutasPendientes.Rows.Count - 1);
            int fila = 0;
            while (true)
            {
                if (fila > count)
                {
                    int num = checked(this.gdPapeleriaNoDigitada.Rows.Count - 1);
                    fila = 0;
                    while (fila <= num)
                    {
                        if (!((TextBox)this.gdPapeleriaNoDigitada.Rows[fila].FindControl("txtJustificacion")).Text.Trim().Length.Equals(0))
                        {
                            fila = checked(fila + 1);
                        }
                        else
                        {
                            this.lblError1.Text = "Debe justificar toda la papeleria!!!";
                            this.lblError1.Visible = true;
                            validar = false;
                            return validar;
                        }
                    }
                    validar = true;
                    break;
                }
                else if (!((TextBox)this.grRutasPendientes.Rows[fila].FindControl("txtJustificacion")).Text.Trim().Length.Equals(0))
                {
                    fila = checked(fila + 1);
                }
                else
                {
                    this.lblError.Text = "Debe justificar toda las rutas!!!";
                    this.lblError.Visible = true;
                    validar = false;
                    break;
                }
            }
            return validar;
        }

        protected void ibAtras_Click1(object sender, ImageClickEventArgs e)
        {
            ibAtras_Click(sender, e);
        }
    }
}