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
    public partial class wfTipoActivo : System.Web.UI.Page
    {
        public wfTipoActivo()
        {
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
                serviceSoapClient.DELETE_TIPO_ACTIVO(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.ID_TIPO.Value));
                this.CargarGrillaResumen();
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

        protected void CargarGrillaResumen()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_TIPO_ACTIVO(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString());
                this.grdResumen.DataSource = dataSet.Tables[0];
                this.grdResumen.DataBind();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void GrabaActivo_Click(object sender, ImageClickEventArgs e)
        {
            this.snInserta.Value = "S";
            this.lblCrear.Text = "Agregar tipo de activo";
            this.Descripcion.Text = "";
            this.upCrear.Update();
            this.PopUpDocDig.Show();
        }

        protected void grdResumen_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualiza")
            {
                this.snInserta.Value = "N";
                int num = Convert.ToInt32(e.CommandArgument);
                this.ID_TIPO.Value = this.grdResumen.DataKeys[num].Values["ID_TIPO"].ToString();
                this.lblCrear.Text = string.Concat("Modificar tipo de activo número: ", this.ID_TIPO.Value);
                this.Descripcion.Text = this.grdResumen.Rows[num].Cells[2].Text;
                this.upCrear.Update();
                this.PopUpDocDig.Show();
            }
            if (e.CommandName == "Elimina")
            {
                int num1 = Convert.ToInt32(e.CommandArgument);
                this.ID_TIPO.Value = this.grdResumen.DataKeys[num1].Values["ID_TIPO"].ToString();
                this.upCrear.Update();
                this.mpeConfirmacion.Show();
            }
        }

        protected void imbCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopUpDocDig.Hide();
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
                if (this.snInserta.Value != "S")
                {
                    serviceSoapClient.UPDATE_TIPO_ACTIVO(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.Descripcion.Text, Convert.ToInt32(this.ID_TIPO.Value));
                }
                else
                {
                    serviceSoapClient.INSERT_TIPO_ACTIVO(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.Descripcion.Text);
                }
                this.lblmensaje.Text = "Grabación exitosa.";
                this.upmensaje.Update();
                this.mpemensaje.Show();
                this.PopUpDocDig.Hide();
                this.CargarGrillaResumen();
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
            if ((new ClsGeneral()).tienePermiso(this.Session["idusuario"].ToString(), "PP_TIPOSACTIVO").Equals("0"))
            {
                base.Response.Redirect("../inicio/default.aspx");
            }
            if (!base.IsPostBack)
            {
                this.CargarGrillaResumen();
            }
        }

        protected string ValidaCreacion()
        {
            string str = "";
            if (this.Descripcion.Text == "")
            {
                str = string.Concat(str, "Descripción no ingresada.", Environment.NewLine);
            }
            return str;
        }
    }
}