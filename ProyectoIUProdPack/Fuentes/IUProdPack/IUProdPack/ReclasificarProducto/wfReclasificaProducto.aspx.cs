using AjaxControlToolkit;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using IUProdPack.WsProdPack;


namespace IUProdPack.ReclasificarProducto
{
    public partial class wfReclasificaProducto : System.Web.UI.Page {
        
        public wfReclasificaProducto()
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
                dataSet = serviceSoapClient.GET_PRODUCTOS_FILTRO(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString());
                (new clsGenerales()).cargarCombos(dataSet, this.Productos, "NOMBRE", "CODIGO", "");
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void CargarGrillaDetalle(int idEvaluacion)
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_DETALLE_EVA(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), idEvaluacion);
                this.grdDetalle.DataSource = dataSet.Tables[0];
                this.grdDetalle.DataBind();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void CargarProductosReclasificados()
        {
            try
            {
                this.ProductosReclasificar.Items.Clear();
                ListItem listItem = new ListItem()
                {
                    Text = "...",
                    Value = "..."
                };
                this.ProductosReclasificar.Items.Add(listItem);
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_PRODUCTOS_RECLA(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.Productos.SelectedValue);
                (new clsGenerales()).cargarCombos(dataSet, this.ProductosReclasificar, "NOMBRE", "CODIGO", "");
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void CargarSeriales()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_SERIALESEVALUADOSLOTE(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text, this.Productos.SelectedValue);
                this.grdSeriales.DataSource = dataSet.Tables[0];
                this.grdSeriales.DataBind();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void grdSeriales_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalle")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                this.CargarGrillaDetalle(Convert.ToInt32(this.grdSeriales.DataKeys[num].Values["ID_EVALUACION"].ToString()));
                this.upDetalle.Update();
                this.PopUpDetalle.Show();
            }
        }

        protected void grdSeriales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && this.grdSeriales.DataKeys[e.Row.RowIndex].Values["CUMPLIO"].ToString().Equals("SI"))
            {
                e.Row.Enabled = false;
                e.Row.BackColor = ColorTranslator.FromHtml("#66CD00");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.CargarProductosReclasificados();
            this.CargarSeriales();
            this.imbGuardar.Enabled = true;
        }

        protected void imbCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopUpDetalle.Hide();
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
            ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
            try
            {
                serviceSoapClient.RECLASIFICA_SERIAL_DEL(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text);
                foreach (GridViewRow row in this.grdSeriales.Rows)
                {
                    if (!row.Enabled)
                    {
                        continue;
                    }
                    CheckBox checkBox = (CheckBox)row.FindControl("chkReflasificar");
                    CheckBox checkBox1 = (CheckBox)row.FindControl("chkVentear");
                    int num = Convert.ToInt32(this.grdSeriales.DataKeys[row.RowIndex].Values["SERIAL"].ToString());
                    if (checkBox.Checked)
                    {
                        serviceSoapClient.RECLASIFICA_SERIAL_INS(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text, num, 1, 0);
                    }
                    if (!checkBox1.Checked)
                    {
                        continue;
                    }
                    serviceSoapClient.RECLASIFICA_SERIAL_INS(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text, num, 0, 1);
                }
                string str1 = serviceSoapClient.RECLASIFICA_SERIAL(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.ProductosReclasificar.SelectedValue, this.txtLote.Text);
                this.lblmensaje.Text = string.Concat("Se genero el lote : ", str1);
                this.upmensaje.Update();
                this.mpemensaje.Show();
                this.CargarSeriales();
                this.UpdatePanel1.Update();
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
            if ((new ClsGeneral()).tienePermiso(this.Session["idusuario"].ToString(), "PP_RECLASIFICACION").Equals("0"))
            {
                base.Response.Redirect("../inicio/default.aspx");
            }
            if (!base.IsPostBack)
            {
                this.CargarCombos();
            }
        }

        protected string ValidaCreacion()
        {
            string str = "";
            if (this.Productos.SelectedValue == "...")
            {
                str = string.Concat(str, "Seleccione un producto.</br>");
            }
            if (this.ProductosReclasificar.SelectedValue == "...")
            {
                str = string.Concat(str, "Seleccione un producto a reclasificar .</br>");
            }
            int num = 0;
            foreach (GridViewRow row in this.grdSeriales.Rows)
            {
                if (!row.Enabled)
                {
                    continue;
                }
                CheckBox checkBox = (CheckBox)row.FindControl("chkReflasificar");
                CheckBox checkBox1 = (CheckBox)row.FindControl("chkVentear");
                if (checkBox.Checked && checkBox1.Checked)
                {
                    str = string.Concat(str, "NO puede seleccionar Reclasificar y Ventear a la vez.</br>");
                }
                if (!checkBox.Checked && !checkBox1.Checked)
                {
                    str = string.Concat(str, "Debe seleccionar Reclasificar o Ventear.</br>");
                }
                num++;
            }
            if (num == 0)
            {
                str = string.Concat(str, "Debe seleccionar alguno de los seriales.</br>");
            }
            return str;
        }
    }
}