using AjaxControlToolkit;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using IUProdPack.WsProdPack;

namespace IUProdPack.GenerarLote
{
    public partial class wfTransferenciaLote : System.Web.UI.Page
    {
        public wfTransferenciaLote()
        {
        }

        protected void btnokmensaje_Click(object sender, EventArgs e)
        {
            try
            {
                this.mpemensaje.Hide();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        private void cargarFecha()
        {
            this.txtfecha.Text = string.Format("{0:dd'/'MM'/'yyyy}", (DateTime)this.Session["fecha"]);
            this.txtFechaIni.Text = string.Format("{0:dd'/'MM'/'yyyy}", (DateTime)this.Session["fecha"]);
        }

        protected void imbBuscarLotes_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CultureInfo cultureInfo = new CultureInfo("es-co");
                DateTime dateTime = DateTime.ParseExact(this.txtFechaIni.Text.Trim(), "dd/MM/yyyy", cultureInfo);
                DateTime dateTime1 = DateTime.ParseExact(this.txtfecha.Text.Trim(), "dd/MM/yyyy", cultureInfo);
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = (this.txtLote.Text != "" ? serviceSoapClient.ConsLotesaTransferirLote(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text, this.Session["agencia"].ToString()) : serviceSoapClient.ConsLotesaTransferirFecha(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), dateTime, dateTime1, this.Session["agencia"].ToString()));
                this.grdLotes.DataSource = dataSet;
                this.grdLotes.DataBind();
                this.imbTransferir.Visible = true;
                this.imbCancelar.Visible = true;
                if (dataSet.Tables[0].DefaultView.Count == 0)
                {
                    this.lblmensaje.Text = "No se Encontro Información";
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                    this.imbTransferir.Visible = false;
                    this.imbCancelar.Visible = false;
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void imbCancelar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.Limpiar();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void imbTransferir_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int num = 0;
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                foreach (GridViewRow row in this.grdLotes.Rows)
                {
                    if (!((CheckBox)row.FindControl("chkSelecLote")).Checked)
                    {
                        continue;
                    }
                    num = 1;
                    serviceSoapClient.TransferirLote(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.grdLotes.DataKeys[row.RowIndex].Values["COD_LOTE"].ToString(), Convert.ToInt32(this.Session["empresa"].ToString()), Convert.ToInt32(this.Session["grupo"].ToString()), this.Session["agencia"].ToString());
                }
                if (num != 0)
                {
                    this.lblmensaje.Text = "Se realizó la transferencia de los lotes seleccionados correctamente.";
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                    this.Limpiar();
                }
                else
                {
                    this.lblmensaje.Text = "No seleccionó ningun LOTE de la lista";
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        private void Limpiar()
        {
            try
            {
                this.txtfecha.Text = string.Format("{0:dd'/'MM'/'yyyy}", (DateTime)this.Session["fecha"]);
                this.txtFechaIni.Text = string.Format("{0:dd'/'MM'/'yyyy}", (DateTime)this.Session["fecha"]);
                this.imbTransferir.Visible = false;
                this.imbCancelar.Visible = false;
                this.txtLote.Text = "";
                this.grdLotes.DataSource = "";
                this.grdLotes.DataBind();
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
            if (!this.Page.IsPostBack)
            {
                try
                {
                    this.Session["fecha"] = DateTime.Now;
                    this.cargarFecha();
                }
                catch (Exception exception)
                {
                    this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                }
            }
        }
    }
}