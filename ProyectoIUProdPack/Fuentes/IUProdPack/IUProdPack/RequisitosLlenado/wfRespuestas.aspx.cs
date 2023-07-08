using AjaxControlToolkit;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using IUProdPack.WsProdPack;


namespace IUProdPack.RequisitosLlenado
{
    public partial class wfRespuestas : System.Web.UI.Page
    {
        public wfRespuestas()
        {
        }

        protected void AdicionarRespuesta_Click(object sender, ImageClickEventArgs e)
        {
            if (this.TipoRespuestaDet.SelectedValue == "...")
            {
                this.lblmensaje.Text = "Seleccione un tipo de respuesta para continuar.";
                this.upmensaje.Update();
                this.mpemensaje.Show();
                return;
            }
            this.snInserta.Value = "S";
            string selectedValue = this.TipoRespuestaDet.SelectedValue;
            string str = selectedValue;
            if (selectedValue != null)
            {
                if (str == "1")
                {
                    this.pnlCheck.Visible = true;
                    this.pnlCombo.Visible = false;
                    this.pnlTexo.Visible = false;
                    this.upPaso3.Update();
                    this.PopUpPaso3.Show();
                    return;
                }
                else if (str == "2")
                {
                    this.pnlCheck.Visible = false;
                    this.pnlCombo.Visible = true;
                    this.pnlTexo.Visible = false;
                    this.upPaso3.Update();
                    this.PopUpPaso3.Show();
                    return;
                }
                else
                {
                    if (str != "3")
                    {
                        this.pnlCheck.Visible = true;
                        this.pnlCombo.Visible = false;
                        this.pnlTexo.Visible = false;
                        this.upPaso3.Update();
                        this.PopUpPaso3.Show();
                        return;
                    }
                    this.pnlCheck.Visible = false;
                    this.pnlCombo.Visible = false;
                    this.pnlTexo.Visible = true;
                    this.upPaso3.Update();
                    this.PopUpPaso3.Show();
                    return;
                }
            }
            this.pnlCheck.Visible = true;
            this.pnlCombo.Visible = false;
            this.pnlTexo.Visible = false;
            this.upPaso3.Update();
            this.PopUpPaso3.Show();
        }

        protected void btnCancelarConfirma_Click(object sender, ImageClickEventArgs e)
        {
            this.mpeConfirmacion.Hide();
        }

        protected void btnOKCOnfirma_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                serviceSoapClient.DELETE_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.ID_RESPUESTA.Value));
                this.CargarGrillaRespuestas();
                this.lblmensaje.Text = "Grabación exitosa.";
                this.upmensaje.Update();
                this.mpemensaje.Show();
                this.mpeConfirmacion.Hide();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.mpeConfirmacion.Hide();
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void btnokmensaje_Click(object sender, ImageClickEventArgs e)
        {
            this.mpemensaje.Hide();
        }

        protected void CargarCombos()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                clsGenerales clsGenerale = new clsGenerales();
                dataSet = serviceSoapClient.GET_TIPO_RESPUESTAS(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString());
                clsGenerale.cargarCombos(dataSet, this.TipoRespuestaDet, "DESCRIPCION", "CODIGO", "");
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void CargarGrillaRespuestas()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString());
                this.grdRespuestas.DataSource = dataSet.Tables[0];
                this.grdRespuestas.DataBind();
                this.upResumen.Update();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void grdRepuestas_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Elimina")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                this.ID_RESPUESTA.Value = this.grdRespuestas.DataKeys[num].Values["ID_RESPUESTA"].ToString();
                this.upPaso3.Update();
                this.mpeConfirmacion.Show();
            }
        }

        protected void imbCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopUpPaso3.Hide();
        }

        protected void imbGuardar_Click(object sender, ImageClickEventArgs e)
        {
            string str = this.ValidaCreacion();
            if (str != "")
            {
                this.lblmensaje.Text = str;
                this.upmensaje.Update();
                this.mpemensaje.Show();
                return;
            }
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                if (this.snInserta.Value == "S")
                {
                    string selectedValue = this.TipoRespuestaDet.SelectedValue;
                    string str1 = selectedValue;
                    if (selectedValue != null)
                    {
                        if (str1 == "1")
                        {
                            string str2 = "0";
                            if (this.CheckDefecto.Checked)
                            {
                                str2 = "1";
                            }
                            serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 1, "", str2);
                        }
                        else if (str1 == "2")
                        {
                            serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 2, this.ComboValores.Text, this.ComboDefecto.Text);
                        }
                        else if (str1 == "3")
                        {
                            serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 3, string.Concat(this.CheckMinimo.Text, ",", this.CheckMaximo.Text), "");
                        }
                    }
                }
                this.lblmensaje.Text = "Grabación exitosa.";
                this.upmensaje.Update();
                this.mpemensaje.Show();
                this.PopUpPaso3.Hide();
                this.CargarGrillaRespuestas();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((new ClsGeneral()).tienePermiso(this.Session["idusuario"].ToString(), "PP_RESPUESTAS").Equals("0"))
            {
                base.Response.Redirect("../inicio/default.aspx");
            }
            if (!base.IsPostBack)
            {
                this.CargarGrillaRespuestas();
                this.CargarCombos();
            }
        }

        protected void TipoRespuestaDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_RES_LLEN_BYTIPO(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.TipoRespuestaDet.SelectedValue));
                this.grdRespuestas.DataSource = dataSet.Tables[0];
                this.grdRespuestas.DataBind();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected string ValidaCreacion()
        {
            string str = "";
            string selectedValue = this.TipoRespuestaDet.SelectedValue;
            string str1 = selectedValue;
            if (selectedValue != null)
            {
                if (str1 == "2")
                {
                    if (this.ComboValores.Text == "" || this.ComboDefecto.Text == "")
                    {
                        str = string.Concat(str, "Ingrese los valores permitidos.\n", Environment.NewLine);
                    }
                    if (!this.ComboValores.Text.Contains(this.ComboDefecto.Text))
                    {
                        str = string.Concat(str, "El valor por defecto debe estar incluido en los valores.\n", Environment.NewLine);
                    }
                }
                else if (str1 == "3")
                {
                    if (this.CheckMinimo.Text == "" || this.CheckMaximo.Text == "")
                    {
                        str = string.Concat(str, "Ingrese los rangos o coloque cero.\n", Environment.NewLine);
                    }
                }
            }
            return str;
        }
    }
}