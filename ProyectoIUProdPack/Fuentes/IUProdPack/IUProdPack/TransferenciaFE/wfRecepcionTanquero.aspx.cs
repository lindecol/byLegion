using AjaxControlToolkit;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using IUProdPack.WsProdPack;

namespace IUProdPack.TransferenciaFE
{
    public partial class wfRecepcionTanquero : System.Web.UI.Page
    {

        protected void btnokmensaje_Click(object sender, ImageClickEventArgs e)
        {
            this.mpemensaje.Hide();
        }

        protected double CantidadSubdepositoOrigen()
        {
            double num;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_TANQUES_BYID(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.TanqueCarga.SelectedValue));
                num = Convert.ToDouble(dataSet.Tables[0].Rows[0].ItemArray[4].ToString());
            }
            catch
            {
                num = 0;
            }
            return num;
        }

        protected int CapacidadTanqueCarga()
        {
            int num;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_TANQUES_BYID(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.TanqueCarga.SelectedValue));
                num = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[2].ToString());
            }
            catch
            {
                num = 0;
            }
            return num;
        }

        protected int CapacidadTanqueDescarga()
        {
            int num;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_TANQUES_BYID(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.TanqueDescarga.SelectedValue));
                num = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[2].ToString());
            }
            catch
            {
                num = 0;
            }
            return num;
        }

        protected void CargarCombos()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                clsGenerales clsGenerale = new clsGenerales();
                dataSet = serviceSoapClient.GET_TIPO_TRANSAC(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.Session["empresa"].ToString()));
                clsGenerale.cargarCombos(dataSet, this.TipoTransac, "DESCRIPCION", "IDTIPO", "");
                dataSet = serviceSoapClient.GET_TNQ_FS(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.Session["agencia"].ToString()));
                clsGenerale.cargarCombos(dataSet, this.TanqueDescarga, "DESCRIPCION", "TANQUE_TNQ", "");
                dataSet = serviceSoapClient.GET_CONSTIPENTREGA(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString());
                clsGenerale.cargarCombos(dataSet, this.TipoEntrega, "NOMBRE", "CODIGO", "");
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void CargarTanqueros()
        {
            this.TanqueCarga.Items.Clear();
            ListItem listItem = new ListItem()
            {
                Text = "...",
                Value = "..."
            };
            this.TanqueCarga.Items.Add(listItem);
            ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
            DataSet dataSet = new DataSet();
            clsGenerales clsGenerale = new clsGenerales();
            dataSet = serviceSoapClient.GET_TNQ_DESCARGA(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.Session["agencia"].ToString()));
            clsGenerale.cargarCombos(dataSet, this.TanqueCarga, "DESCRIPCION", "TANQUE_TNQ", "");
        }

        protected double CoeficienteProducto()
        {
            double num;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                string str = this.ProductoTanque();
                dataSet = serviceSoapClient.GET_COEF_PROD(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), str);
                num = Convert.ToDouble(dataSet.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            catch
            {
                num = 0;
            }
            return num;
        }

        protected void imbGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string str = this.ValidaGrabacion();
                if (str == "")
                {
                    ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                    DataSet dataSet = new DataSet();
                    dataSet = serviceSoapClient.GRABA_TRANS_TNQ_DESCARGA(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.TanqueCarga.SelectedValue), Convert.ToInt32(this.TanqueDescarga.SelectedValue), Convert.ToInt32(this.TipoTransac.SelectedValue), this.Observaciones.Text, Convert.ToInt32(this.TipoEntrega.SelectedValue), Convert.ToDouble(this.PesadaInicial.Text), Convert.ToDouble(this.PesadaFinal.Text));
                    if (dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow item = dataSet.Tables[0].Rows[0];
                        this.CargarTanqueros();
                        this.PesadaInicial.Text = "";
                        this.PesadaFinal.Text = "";
                        this.Observaciones.Text = "";
                        this.TanqueCarga.SelectedValue = "...";
                        this.TanqueDescarga.SelectedValue = "...";
                        this.lblInfoTanqueCarga.Text = "";
                        this.lblInfoTanqueDescarga.Text = "";
                        this.TipoEntrega.SelectedValue = "...";
                        string str1 = string.Format("Movimiento {0} grabado correctamente.", item.ItemArray[0].ToString());
                        this.lblmensaje.Text = str1;
                        this.upmensaje.Update();
                        this.mpemensaje.Show();
                    }
                    else
                    {
                        this.lblmensaje.Text = "Error al grabar la transacción. Por favor contacte al administrador.";
                        this.upmensaje.Update();
                        this.mpemensaje.Show();
                    }
                }
                else
                {
                    this.lblmensaje.Text = str;
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

        protected void InfoCarga()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_TANQUES_BYID(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.TanqueCarga.SelectedValue));
                string str = dataSet.Tables[0].Rows[0].ItemArray[2].ToString();
                string str1 = dataSet.Tables[0].Rows[0].ItemArray[4].ToString();
                this.lblInfoTanqueCarga.Text = string.Format("Capacidad Tanque: {0}. Cantidad en subdepósito: {1}.", str, str1);
            }
            catch
            {
                this.lblInfoTanqueCarga.Text = "";
            }
        }

        protected void InfoDescarga()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_TANQUES_BYID(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.TanqueDescarga.SelectedValue));
                string str = dataSet.Tables[0].Rows[0].ItemArray[2].ToString();
                string str1 = dataSet.Tables[0].Rows[0].ItemArray[4].ToString();
                this.lblInfoTanqueDescarga.Text = string.Format("Capacidad Tanque: {0}. Cantidad en subdepósito: {1}.", str, str1);
            }
            catch
            {
                this.lblInfoTanqueDescarga.Text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((new ClsGeneral()).tienePermiso(this.Session["idusuario"].ToString(), "RECEPCION_TNQ").Equals("0"))
            {
                base.Response.Redirect("../inicio/default.aspx");
            }
            if (!base.IsPostBack)
            {
                this.CargarCombos();
                this.CargarTanqueros();
                this.SetTipoTransaccion();
            }
        }

        protected string ProductoTanque()
        {
            string str;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_TANQUES_BYID(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.TanqueCarga.SelectedValue));
                str = dataSet.Tables[0].Rows[0].ItemArray[3].ToString();
            }
            catch
            {
                str = "";
            }
            return str;
        }

        protected void SetTipoTransaccion()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                string tRANSAC = serviceSoapClient.GET_TRANSAC(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), "DESCARGA_TNQ");
                this.TipoTransac.SelectedValue = tRANSAC;
                this.TipoTransac.Enabled = false;
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void TanqueCarga_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InfoCarga();
        }

        protected void TanqueDescarga_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InfoDescarga();
        }

        protected string ValidaGrabacion()
        {
            string str = "";
            if (this.TipoTransac.Text == "...")
            {
                str = string.Concat(str, "Transacción no seleccionado.", Environment.NewLine);
            }
            if (this.TipoEntrega.Text == "...")
            {
                str = string.Concat(str, "Tipo de entrega no seleccionado.", Environment.NewLine);
            }
            if (this.TanqueCarga.Text == "..." || this.TanqueDescarga.Text == "...")
            {
                str = string.Concat(str, "Tanque no seleccionado.", Environment.NewLine);
            }
            else if (!(this.PesadaInicial.Text == "") || !(this.PesadaFinal.Text == ""))
            {
                double num = 0;
                double num1 = 0;
                double num2 = 0;
                try
                {
                    num2 = this.CoeficienteProducto();
                }
                catch
                {
                    num2 = 0;
                }
                num = Convert.ToDouble(this.PesadaInicial.Text) * num2;
                num1 = Convert.ToDouble(this.PesadaFinal.Text) * num2;
                if (num >= num1)
                {
                    str = string.Concat(str, "Pesada final debe ser mayor que la pesada inicial.", Environment.NewLine);
                }
                int num3 = this.CapacidadTanqueCarga();
                int num4 = this.CapacidadTanqueDescarga();
                if (num > (double)num3)
                {
                    str = string.Concat(str, "Nivel inicial no puede ser mayor a la capacidad del tanque origen.", Environment.NewLine);
                }
                if (num1 > (double)num3)
                {
                    str = string.Concat(str, "Nivel final no puede ser mayor a la capacidad del tanque origen.", Environment.NewLine);
                }
                if (num1 + num > (double)num3)
                {
                    str = string.Concat(str, "Niveles ingresados no pueden ser mayores a la capacidad del tanque origen.", Environment.NewLine);
                }
                if (num > (double)num4)
                {
                    str = string.Concat(str, "Nivel inicial no puede ser mayor a la capacidad del tanque destino.", Environment.NewLine);
                }
                if (num1 > (double)num4)
                {
                    str = string.Concat(str, "Nivel final no puede ser mayor a la capacidad del tanque destino.", Environment.NewLine);
                }
                if (num1 + num > (double)num4)
                {
                    str = string.Concat(str, "Niveles ingresados no pueden ser mayores a la capacidad del tanque destino.", Environment.NewLine);
                }
                if (num1 + num > this.CantidadSubdepositoOrigen())
                {
                    str = string.Concat(str, "Niveles ingresados no pueden ser mayores a la cantidad existente en el subdepósito del tanque.", Environment.NewLine);
                }
            }
            else
            {
                str = string.Concat(str, "Nivel inicial o final no ingresado.", Environment.NewLine);
            }
            return str;
        }
    }
}