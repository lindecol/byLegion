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

namespace IUProdPack.Llenado
{
    public partial class wfRacks : System.Web.UI.Page
    {
        public wfRacks()
        {
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
                dataSet = serviceSoapClient.GET_SUCURSALES(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.Session["empresa"].ToString()));
                clsGenerales clsGenerale = new clsGenerales();
                clsGenerale.cargarCombos(dataSet, this.Sucursal, "DESCRIPCION", "CODIGO", "");
                dataSet = serviceSoapClient.GET_ESTADO_RACK(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString());
                clsGenerale.cargarCombos(dataSet, this.Estado, "DESCRIPCION", "CODIGO", "");
                this.upCrear.Update();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void CargarGrillaResumen()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_RACKS(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.Session["empresa"].ToString()));
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

        protected void GrabaRack_Click(object sender, ImageClickEventArgs e)
        {
            this.snInserta.Value = "S";
            this.lblCrear.Text = "Agregar Rack";
            this.Estado.SelectedValue = "...";
            DropDownList sucursal = this.Sucursal;
            int num = Convert.ToInt32(this.Session["agencia"].ToString());
            sucursal.SelectedValue = num.ToString();
            this.upCrear.Update();
            this.PopUpDocDig.Show();
        }

        protected void grdResumen_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualiza")
            {
                this.snInserta.Value = "N";
                int num = Convert.ToInt32(e.CommandArgument);
                this.N_NUMRACK.Value = this.grdResumen.DataKeys[num].Values["N_NUMRACK"].ToString();
                this.lblCrear.Text = string.Concat("Modificar Rack número: ", this.N_NUMRACK.Value);
                this.Estado.SelectedValue = this.grdResumen.DataKeys[num].Values["N_ESTADO"].ToString();
                DropDownList sucursal = this.Sucursal;
                int num1 = Convert.ToInt32(this.grdResumen.DataKeys[num].Values["C_AGENCI"].ToString());
                sucursal.SelectedValue = num1.ToString();
                this.upCrear.Update();
                this.PopUpDocDig.Show();
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
                    serviceSoapClient.UPDATE_RACKS(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.Estado.SelectedValue), Convert.ToInt32(this.N_NUMRACK.Value));
                }
                else
                {
                    serviceSoapClient.INSERT_RACKS(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.Estado.SelectedValue), this.Session["agencia"].ToString());
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
            if (!base.IsPostBack)
            {
                this.CargarGrillaResumen();
                this.CargarCombos();
            }
        }

        protected string ValidaCreacion()
        {
            string str = "";
            if (this.Estado.SelectedValue == "...")
            {
                str = string.Concat(str, "Estado no seleccionado.", Environment.NewLine);
            }
            if (this.Sucursal.SelectedValue == "...")
            {
                str = string.Concat(str, "Sucursal no seleccionada.", Environment.NewLine);
            }
            return str;
        }
    }
}