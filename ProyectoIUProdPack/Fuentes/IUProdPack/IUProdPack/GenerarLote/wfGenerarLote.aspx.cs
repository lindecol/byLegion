using AjaxControlToolkit;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.ServiceModel;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using IUProdPack.WsProdPack;

namespace IUProdPack.GenerarLote
{
    public partial class wfGenerarLote : System.Web.UI.Page
    {

        public static string _TipProducto;

        public static int Empresa;

        public static int LimpiarTodo;

        public static int Agencia;

        public static int Grupo;

        public static string _ProdLastro;

        public static DataSet _dtsTermos;

        public static string CodLegajo;

        public static string IDUsuario;

        public static int _Agencia
        {
            get
            {
                return Agencia;
            }
            set
            {
                Agencia = value;
            }
        }

        public static string _CodLegajo
        {
            get
            {
                return CodLegajo;
            }
            set
            {
                CodLegajo = value;
            }
        }

        public static int _Empresa
        {
            get
            {
                return Empresa;
            }
            set
            {
                Empresa = value;
            }
        }

        public static int _Grupo
        {
            get
            {
                return Grupo;
            }
            set
            {
                Grupo = value;
            }
        }

        public static string _IDUsuario
        {
            get
            {
                return IDUsuario;
            }
            set
            {
                IDUsuario = value;
            }
        }

        public static int _LimpiarTodo
        {
            get
            {
                return LimpiarTodo;
            }
            set
            {
                LimpiarTodo = value;
            }
        }

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        public static string ProdLastro
        {
            get
            {
                return _ProdLastro;
            }
            set
            {
                _ProdLastro = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public static DataSet Termos
        {
            get
            {
                return _dtsTermos;
            }
            set
            {
                _dtsTermos = value;
            }
        }

        public static string TipoProducto
        {
            get
            {
                return _TipProducto;
            }
            set
            {
                _TipProducto = value;
            }
        }

        private bool blnUsuarioHabilitado(string aplicacion, string usuario)
        {
            bool flag;
            bool flag1 = false;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaUsuHab(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), aplicacion, usuario);
                if (dataSet.Tables[0].DefaultView.Count > 0)
                {
                    flag1 = (Convert.ToInt16(dataSet.Tables[0].Rows[0][0].ToString()) > 0 ? true : false);
                }
                flag = flag1;
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
                flag = flag1;
            }
            return flag;
        }

        protected void btnAnalisisGM_Click(object sender, EventArgs e)
        {
        }

        protected void btnCancelarConfirma_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.mpeConfirmacion.Hide();
                this.mpepopupAnalisisGM.Hide();
                this.grvAnalisisGm.DataSource = "";
                this.grvAnalisisGm.DataBind();
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
            }
        }

        protected void btnCancelLegajo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.mpepopupLegajo.Hide();
            }
            catch (Exception exception)
            {
                this.lblerrLegajo.Text = clsConstantes.ManejoExcepciones(exception);
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                this.mpeAlerta.Hide();
                if (this.txtNroCilindro.Text == "")
                {
                    this.txtNroCilindro.Text = "0";
                }
                this.mpepopupAnalisisGM.Hide();
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
            }
        }

        protected void btnNoGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                this.mpeAlerta.Hide();
                this.mpepopupAnalisisGM.Hide();
                this.grvAnalisisGm.DataSource = "";
                this.grvAnalisisGm.DataBind();
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
            }
        }

        protected void btnOKCOnfirma_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.mpeConfirmacion.Hide();
                this.SetearSiLoteCumple();
                if (this.rdbNoCumple.Checked)
                {
                    this.upAlerta.Update();
                    this.mpeAlerta.Show();
                }
                if (this.rdbCumple.Checked)
                {
                    this.mpepopupAnalisisGM.Hide();
                }
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
            }
        }

        protected void btnokmensaje_Click(object sender, EventArgs e)
        {
            this.mpemensaje.Hide();
            if (_LimpiarTodo.Equals(1))
            {
                _LimpiarTodo = 0;
                base.Response.Redirect("../inicio/default.aspx");
            }
        }

        private string BuscaLegajoxNMB(string _IdUsuario)
        {
            string str;
            string str1 = "";
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaLegajo(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _IdUsuario);
                str1 = (dataSet.Tables[0].DefaultView.Count <= 0 ? "" : dataSet.Tables[0].Rows[0][0].ToString());
                str = str1;
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
                str = str1;
            }
            return str;
        }

        private string BuscarARTID(int _Empresa, string _Codproducto)
        {
            string str;
            string str1 = "0";
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultarCodPrd(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Codproducto);
                if (dataSet.Tables[0].DefaultView.Count > 0)
                {
                    str1 = Convert.ToString(dataSet.Tables[0].Rows[0][0].ToString());
                }
                str = str1;
            }
            catch (Exception exception)
            {
                this.lblErrorComposicion.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupComposicion.Update();
                this.mpepopupComposicion.Show();
                str = str1;
            }
            return str;
        }

        private string BuscarARTIDNUM(int _Empresa, string _Codproducto)
        {
            string str;
            string str1 = "0";
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultarArtIdNum(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Codproducto);
                if (dataSet.Tables[0].DefaultView.Count > 0)
                {
                    str1 = Convert.ToString(dataSet.Tables[0].Rows[0][0].ToString());
                }
                str = str1;
            }
            catch (Exception exception)
            {
                this.lblErrorComposicion.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupComposicion.Update();
                this.mpepopupComposicion.Show();
                str = str1;
            }
            return str;
        }

        private string BuscarDscArticulo(int empresa, string Producto)
        {
            string str;
            string str1 = "";
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaNombreArticulo(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), empresa, Producto);
                str1 = (dataSet.Tables[0].DefaultView.Count <= 0 ? "" : dataSet.Tables[0].Rows[0][0].ToString());
                str = str1;
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
                str = str1;
            }
            return str;
        }

        private string BuscarNmbUsuarioXLegajo(string _codLeg)
        {
            string str;
            string str1 = "";
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaNombreLegajo(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _codLeg);
                if (dataSet.Tables[0].DefaultView.Count > 0)
                {
                    str1 = dataSet.Tables[0].Rows[0][0].ToString();
                }
                str = str1;
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
                str = str1;
            }
            return str;
        }

        private string BuscarNombreUsuario(string _IdUsuario)
        {
            string str;
            string str1 = "";
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaNombreUsuario(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _IdUsuario);
                str1 = (dataSet.Tables[0].DefaultView.Count <= 0 ? "" : dataSet.Tables[0].Rows[0][0].ToString());
                str = str1;
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
                str = str1;
            }
            return str;
        }

        private void Campos(bool estado)
        {
            try
            {
                this.PnLote.Enabled = estado;
                this.pnCx.Enabled = estado;
                this.txtPrecintos.Enabled = estado;
                this.txtEtiquetas.Enabled = estado;
                this.imbGuardarLote.Enabled = estado;
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                if (Convert.ToString(this.cboGas.SelectedItem) != "--Seleccione--")
                {
                    string str = Convert.ToString(this.cboGas.SelectedItem.Value);
                    dataSet = serviceSoapClient.ConsUnidadMed(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, str);
                    if (dataSet.Tables[0].DefaultView.Count > 0)
                    {
                        string str1 = dataSet.Tables[0].Rows[0][0].ToString();
                        this.chkControlBasc.Checked = false;
                        if (estado)
                        {
                            this.chkControlBasc.Checked = false;
                        }
                        else if (str1 == "KGS" || str1 == "TN")
                        {
                            this.chkControlBasc.Checked = true;
                        }
                        this.chkControlBasc.Enabled = estado;
                    }
                }
                else
                {
                    this.chkControlBasc.Checked = false;
                    this.chkControlBasc.Enabled = estado;
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        private bool CamposValidos()
        {
            int num;
            bool flag;
            bool flag1 = false;
            try
            {
                this.lblmensaje.Text = "";
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                foreach (GridViewRow row in this.grdCompTanque.Rows)
                {
                    if (!serviceSoapClient.NivelesAbiertos(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Agencia.ToString(), this.grdCompTanque.Rows[row.RowIndex].Cells[5].Text, this.lblNumTurno.Text).Equals(0))
                    {
                        continue;
                    }
                    this.lblmensaje.Text = string.Concat("El tanque ", this.grdCompTanque.Rows[row.RowIndex].Cells[5].Text, " NO tiene cargado el nivel inicial. \n");
                }
                if (!this.lblmensaje.Text.Equals(""))
                {
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                    flag = flag1;
                }
                else if (Convert.ToString(this.cboGas.SelectedItem) != "--Seleccione--")
                {
                    string str = Convert.ToString(this.cboSubdeposito.SelectedItem);
                    if (str != "--Seleccione--")
                    {
                        str = Convert.ToString(this.cboClasificador.SelectedItem);
                        if (str == "--Seleccione--")
                        {
                            this.lblmensaje.Text = "Debe seleccionar el operario Clasificador.";
                            this.upmensaje.Update();
                            this.mpemensaje.Show();
                            flag = flag1;
                        }
                        else if (this.txtfecha.Text != "")
                        {
                            if (this.imbAnalisisGM.Enabled)
                            {
                                num = 0;
                                foreach (GridViewRow gridViewRow in this.grvAnalisisGm.Rows)
                                {
                                    CheckBox checkBox = (CheckBox)gridViewRow.FindControl("chkPosee");
                                    TextBox textBox = (TextBox)gridViewRow.FindControl("txtValNum");
                                    double num1 = Convert.ToDouble(textBox.Text);
                                    if (!checkBox.Checked || num1 != 0)
                                    {
                                        num = 1;
                                    }
                                    else
                                    {
                                        this.lblmensaje.Text = "En el análisis de gases medicinales, No ha colocado Valor en el item chequeado. ";
                                        this.upmensaje.Update();
                                        this.mpemensaje.Show();
                                        flag = flag1;
                                        return flag;
                                    }
                                }
                                if (num == 0)
                                {
                                    this.lblmensaje.Text = "En el análisis de gases medicinales, No ha chequeado Ningún Item. ";
                                    this.upmensaje.Update();
                                    this.mpemensaje.Show();
                                    flag = flag1;
                                    return flag;
                                }
                            }
                            int num2 = 0;
                            num2 = Convert.ToInt16(this.lblSumCilPart.Text);
                            if (num2 > 0)
                            {
                                num = 0;
                                foreach (GridViewRow row1 in this.grvSecPart.Rows)
                                {
                                    TextBox textBox1 = (TextBox)row1.FindControl("txtSecPart");
                                    if (!(this.grvSecPart.Rows[row1.RowIndex].Cells[1].Text != "") || !(this.grvSecPart.Rows[row1.RowIndex].Cells[2].Text != "") || !(textBox1.Text != ""))
                                    {
                                        continue;
                                    }
                                    num++;
                                }
                                if (num != num2)
                                {
                                    this.lblmensaje.Text = "La cantidad de secuencias cargadas no es igual a la cantidad de tubos.";
                                    this.upmensaje.Update();
                                    this.mpemensaje.Show();
                                    flag = flag1;
                                    return flag;
                                }
                            }
                            if (this.cboTipGas.SelectedValue.Equals("RI") || this.grdCompTanque.Rows.Count != 0 || this.grdInsumos.Rows.Count != 0)
                            {
                                bool @checked = !this.chkControlBasc.Checked;
                                bool flag2 = @checked;
                                this.chkControlBasc.Enabled = @checked;
                                if (flag2)
                                {
                                    this.lblmensaje.Text = "Debe realizar el Control de Bascula para este producto.";
                                    this.upmensaje.Update();
                                    this.mpemensaje.Show();
                                    flag = flag1;
                                }
                                else if (this.txtPrecintos.Text == "" || this.txtEtiquetas.Text == "")
                                {
                                    this.lblmensaje.Text = "Debe colocar el Número de Etiquetas rotas y Precintos Rotos";
                                    this.upmensaje.Update();
                                    this.mpemensaje.Show();
                                    flag = flag1;
                                }
                                else
                                {
                                    str = Convert.ToString(this.cboRack.SelectedItem);
                                    if (str == "--Seleccione--")
                                    {
                                        this.lblmensaje.Text = "Por favor seleccione el Rack.";
                                        this.upmensaje.Update();
                                        this.mpemensaje.Show();
                                        flag = flag1;
                                    }
                                    else if (this.txthoraIni.Text == "" || this.txtHoraFin.Text == "" || this.txtPresion.Text == "" || this.txtTemp.Text == "")
                                    {
                                        this.lblmensaje.Text = "Por favor complete la información del detalle del lote(Hora Inicio, Final, Presión y Temperatura).";
                                        this.upmensaje.Update();
                                        this.mpemensaje.Show();
                                        flag = flag1;
                                    }
                                    else if (this.lblSumTotalCx.Text == "" || this.lblSumTotalCx.Text == "0")
                                    {
                                        this.lblmensaje.Text = "No se han ingresado cilindros para procesar.";
                                        this.upmensaje.Update();
                                        this.mpemensaje.Show();
                                        flag = flag1;
                                    }
                                    else if (this.rdbCumple.Checked || this.rdbNoCumple.Checked)
                                    {
                                        int num3 = Convert.ToInt16(this.lblSumTotalCx.Text);
                                        int num4 = Convert.ToInt16(this.txtPrecintos.Text);
                                        int num5 = Convert.ToInt16(this.txtEtiquetas.Text);
                                        if (num4 > num3)
                                        {
                                            this.lblmensaje.Text = "Se han ingresado más precintos rotos que la cantidad de cilindros procesados.";
                                            this.upmensaje.Update();
                                            this.mpemensaje.Show();
                                            flag = flag1;
                                        }
                                        else if (num5 <= num3)
                                        {
                                            str = Convert.ToString(this.cboTipGas.SelectedItem);
                                            if (str != "--Seleccione--")
                                            {
                                                if (str != "MR")
                                                {
                                                    DataSet dataSet = new DataSet();
                                                }
                                                flag = true;
                                            }
                                            else
                                            {
                                                this.lblmensaje.Text = "Se debe seleccionar el tipo de gas.";
                                                this.upmensaje.Update();
                                                this.mpemensaje.Show();
                                                flag = flag1;
                                            }
                                        }
                                        else
                                        {
                                            this.lblmensaje.Text = "Se han ingresado más etiquetas rotas que la cantidad de cilindros procesados.";
                                            this.upmensaje.Update();
                                            this.mpemensaje.Show();
                                            flag = flag1;
                                        }
                                    }
                                    else
                                    {
                                        this.lblmensaje.Text = "Debe indicar si el lote Cumple o No con las especificaciones.";
                                        this.upmensaje.Update();
                                        this.mpemensaje.Show();
                                        flag = flag1;
                                    }
                                }
                            }
                            else
                            {
                                this.lblmensaje.Text = "NO se ha cargado la composición del producto!";
                                this.upmensaje.Update();
                                this.mpemensaje.Show();
                                flag = flag1;
                            }
                        }
                        else
                        {
                            this.lblmensaje.Text = "Debe seleccionar la fecha de clasificación.";
                            this.upmensaje.Update();
                            this.mpemensaje.Show();
                            flag = flag1;
                        }
                    }
                    else
                    {
                        this.lblmensaje.Text = "Se debe seleccionar un Subdeposito valido.";
                        this.upmensaje.Update();
                        this.mpemensaje.Show();
                        flag = flag1;
                    }
                }
                else
                {
                    this.lblmensaje.Text = "Se debe seleccionar el Producto.";
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                    flag = flag1;
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
                flag = flag1;
            }
            return flag;
        }

        private void CargaGrillaAnalisis(string _Producto)
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaAnalisisGM(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Grupo, _Producto);
                if (dataSet.Tables[0].DefaultView.Count <= 0)
                {
                    this.mpepopupAnalisisGM.Hide();
                    this.lblmensaje.Text = "No se encontraron datos para consulta en Análisis GM. El producto seleccionado no tiene asociado ningún parámetro. Por favor, controlar estos datos.";
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                }
                else
                {
                    this.grvAnalisisGm.DataSource = dataSet;
                    this.grvAnalisisGm.DataBind();
                    foreach (GridViewRow row in this.grvAnalisisGm.Rows)
                    {
                        CheckBox checkBox = (CheckBox)row.FindControl("chkPosee");
                        ((TextBox)row.FindControl("txtValNum")).Visible = true;
                        this.grvAnalisisGm.Rows[row.RowIndex].Cells[0].Text = string.Concat(this.grvAnalisisGm.DataKeys[row.RowIndex].Values["ID_TIPO"].ToString(), " - ", this.grvAnalisisGm.DataKeys[row.RowIndex].Values["DESCRIPCION_TIPO"].ToString());
                        this.grvAnalisisGm.Rows[row.RowIndex].Cells[1].Text = string.Concat(this.grvAnalisisGm.DataKeys[row.RowIndex].Values["ID_ESTADO"].ToString(), " - ", this.grvAnalisisGm.DataKeys[row.RowIndex].Values["DESCRIPCION_ESTADO"].ToString());
                        if (dataSet.Tables[0].DefaultView.Count > 10)
                        {
                            checkBox.Checked = (this.grvAnalisisGm.DataKeys[row.RowIndex].Values["ID_ESTADO"].ToString() == "N" ? false : true);
                        }
                        else
                        {
                            checkBox.Checked = false;
                        }
                        if (this.grvAnalisisGm.DataKeys[row.RowIndex].Values["UNIDAD_MEDIDA"].ToString().Length != 0)
                        {
                            this.grvAnalisisGm.Rows[row.RowIndex].Cells[6].Text = this.grvAnalisisGm.DataKeys[row.RowIndex].Values["VALOR_DESDE"].ToString();
                            this.grvAnalisisGm.Rows[row.RowIndex].Cells[7].Text = this.grvAnalisisGm.DataKeys[row.RowIndex].Values["VALOR_HASTA"].ToString();
                        }
                        else if (this.grvAnalisisGm.DataKeys[row.RowIndex].Values["ID_TIPO"].ToString() == "3")
                        {
                            this.grvAnalisisGm.Rows[row.RowIndex].Cells[6].Text = "Detecta";
                            this.grvAnalisisGm.Rows[row.RowIndex].Cells[7].Text = "No Detecta";
                        }
                        else
                        {
                            this.grvAnalisisGm.Rows[row.RowIndex].Cells[6].Text = "Cumple";
                            this.grvAnalisisGm.Rows[row.RowIndex].Cells[7].Text = "No Cumple";
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
            }
        }

        private void CargarCombos()
        {
            clsGenerales clsGenerale;
            ServiceSoapClient serviceSoapClient;
            try
            {
                try
                {
                    clsGenerale = new clsGenerales();
                    serviceSoapClient = new ServiceSoapClient();
                    DataSet dataSet = new DataSet();
                    string str = "P";
                    int num = Convert.ToInt32(this.Session["idusuario"].ToString());
                    dataSet = serviceSoapClient.ConsSubdeposito(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Grupo, _Agencia, str, num);
                    clsGenerale.cargarCombos(dataSet, this.cboSubdeposito, "nombre", "codigo", "");
                    if (dataSet.Tables[0].DefaultView.Count > 1)
                    {
                        this.cboSubdeposito.Items.Insert(0, "--Seleccione--");
                    }
                    if (dataSet.Tables[0].DefaultView.Count != 0)
                    {
                        this.cboGas.Items.Insert(0, "--Seleccione--");
                        dataSet = serviceSoapClient.ConsClasificador(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString());
                        clsGenerale.cargarCombos(dataSet, this.cboClasificador, "nombre", "nombre", "");
                        if (dataSet.Tables[0].DefaultView.Count != 0)
                        {
                            this.cboClasificador.Items.Insert(0, "--Seleccione--");
                            this.txtfecha.Text = string.Format("{0:dd'/'MM'/'yyyy}", (DateTime)this.Session["fecha"]);
                            dataSet = serviceSoapClient.ConsRacks(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Grupo, _Agencia);
                            clsGenerale.cargarCombos(dataSet, this.cboRack, "nombre", "nombre", "");
                            this.cboRack.Items.Insert(0, "--Seleccione--");
                            this.cboTipGas.Items.Insert(0, "--Seleccione--");
                        }
                        else
                        {
                            this.lblmensaje.Text = " No existen Clasificadores cargados, No se podrán generar Lotes";
                            this.upmensaje.Update();
                            this.mpemensaje.Show();
                            this.imbAnalisisGM.Enabled = false;
                            this.imbLastroInsumos.Enabled = false;
                            this.imbParticulares.Enabled = false;
                            this.imbGuardarLote.Enabled = false;
                            return;
                        }
                    }
                    else
                    {
                        this.lblmensaje.Text = "Usted No posee ningun Subdeposito de Producción asignado en la sucursal, No podra realizar Ninguna Operación en el Modulo";
                        this.upmensaje.Update();
                        this.mpemensaje.Show();
                        this.imbAnalisisGM.Enabled = false;
                        this.imbLastroInsumos.Enabled = false;
                        this.imbParticulares.Enabled = false;
                        this.imbGuardarLote.Enabled = false;
                        return;
                    }
                }
                catch (Exception exception)
                {
                    this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                }
            }
            finally
            {
                clsGenerale = null;
                serviceSoapClient = null;
            }
        }

        private void CargarComposicion(string _Codproducto, bool sustitutos)
        {
            try
            {
                string str = Convert.ToString(this.cboSubdeposito.SelectedItem.Value);
                bool flag = false;
                int num = (sustitutos ? 1 : 0);
                bool flag1 = false;
                bool flag2 = false;
                double num1 = 0;
                double num2 = (double)Convert.ToInt16(this.lblSumTotalCx.Text);
                double num3 = Convert.ToDouble(this.lblSumTotalVol.Text);
                double num4 = 0;
                flag = this.ProductoUsaTanque(_Codproducto);
                this.lblNousa.Visible = flag;
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultarInsumosPrd(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Agencia, _Codproducto, num);
                this.grdInsumos.DataSource = dataSet;
                this.grdInsumos.DataBind();
                foreach (GridViewRow row in this.grdInsumos.Rows)
                {
                    flag1 = (this.grdInsumos.DataKeys[row.RowIndex].Values["ESETIQUETA"].ToString() == "S" ? true : false);
                    flag2 = (this.grdInsumos.DataKeys[row.RowIndex].Values["ESGAS"].ToString() == "S" ? true : false);
                    num4 = Convert.ToDouble(this.grdInsumos.DataKeys[row.RowIndex].Values["PORCENTAJE"].ToString());
                    ((CheckBox)row.FindControl("chkEtiqueta")).Checked = flag1;
                    ((CheckBox)row.FindControl("chkGas")).Checked = flag2;
                    string str1 = this.grdInsumos.DataKeys[row.RowIndex].Values["ARTIDNUM"].ToString();
                    this.grdInsumos.Rows[row.RowIndex].Cells[9].Text = this.StockActualEnSucursal(_Grupo, _Empresa, str, str1, "0");
                    if (num2 > 0)
                    {
                        if (!flag2)
                        {
                            num1 = Convert.ToDouble(this.grdInsumos.DataKeys[row.RowIndex].Values["CANT_COMP"].ToString()) * num2;
                        }
                        else
                        {
                            num1 = num4 * num3;
                            num1 /= Convert.ToDouble(this.grdInsumos.DataKeys[row.RowIndex].Values["FACTOR_CONVERSION"].ToString());
                        }
                    }
                    this.grdInsumos.Rows[row.RowIndex].Cells[6].Text = Convert.ToString(num1);
                    this.grdInsumos.Rows[row.RowIndex].Cells[8].Text = Convert.ToString(num1);
                    TextBox textBox = (TextBox)row.FindControl("txtCantExtra");
                    textBox.Text = "0";
                    if (num1 <= 0)
                    {
                        textBox.Enabled = false;
                    }
                    else
                    {
                        textBox.Enabled = true;
                    }
                }
            }
            catch (Exception exception)
            {
                this.lblErrorComposicion.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupComposicion.Update();
                this.mpepopupComposicion.Show();
            }
        }

        private void CargarGases()
        {
            try
            {
                clsGenerales clsGenerale = new clsGenerales();
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                if (!this.rdbStockeables.Checked)
                {
                    dataSet = serviceSoapClient.ConsGases(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Agencia, 1);
                }
                else
                {
                    Convert.ToInt32(ConfigurationManager.AppSettings["TIME_OUT"].ToString());
                    dataSet = serviceSoapClient.ConsStockeables(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, 1);
                }
                clsGenerale.cargarCombos(dataSet, this.cboGas, "nombre", "codigo", "");
                this.cboGas.Items.Insert(0, "--Seleccione--");
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        private void CargarGrillaCx(string capacidad, int numero, string Producto)
        {
            try
            {
                this.grdDetCx.DataSource = "";
                this.grdDetCx.DataBind();
                this.lblSumCilPraxair.Text = "0";
                this.lbSumVolPrax.Text = "0";
                this.lblSumCilPart.Text = "0";
                this.lblSumVolPar.Text = "0";
                this.lblSumCilSellos.Text = "0";
                this.lblSumVolSellos.Text = "0";
                this.lblSumCilRechaz.Text = "0";
                this.lblSumVolRechaz.Text = "0";
                this.lblSumTotalCx.Text = "0";
                this.lblSumTotalVol.Text = "0";
                DataSet dataSet = new DataSet();
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                if (numero == 0 || numero == 1)
                {
                    dataSet = serviceSoapClient.ConsultarCapacidades(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), capacidad);
                    this.grdDetCx.DataSource = dataSet;
                    this.grdDetCx.DataBind();
                }
                else
                {
                    dataSet = serviceSoapClient.ConsultarCapacidadesPrd(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Grupo, Producto);
                    if (dataSet.Tables[0].DefaultView.Count <= 0)
                    {
                        this.lblmensaje.Text = "Este producto no dispone de capacidades para cargar.";
                        this.upmensaje.Update();
                        this.mpemensaje.Show();
                    }
                    else
                    {
                        this.grdDetCx.DataSource = dataSet;
                        this.grdDetCx.DataBind();
                    }
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        private void CargarGrillaLastro()
        {
            try
            {
                string str = Convert.ToString(this.cboGas.SelectedItem.Value);
                string str1 = Convert.ToString(this.cboSubdeposito.SelectedItem.Value);
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaLastroInsumos(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, str1, _Agencia, str, _Grupo);
                if (dataSet.Tables[0].DefaultView.Count <= 0)
                {
                    this.lblNoexisteInf.Visible = true;
                }
                else
                {
                    this.grvLastroIns.DataSource = dataSet;
                    this.grvLastroIns.DataBind();
                    this.lblNoexisteInf.Visible = false;
                }
            }
            catch (Exception exception)
            {
                this.lblerrorlastro.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupLastro.Update();
                this.mpepopupLastro.Show();
            }
        }

        private void CargarGrillaSecuencias()
        {
            try
            {
                DataTable dataTable = new DataTable("Secuencias");
                dataTable.Columns.Add("Capacidad", typeof(string));
                foreach (GridViewRow row in this.grdDetCx.Rows)
                {
                    TextBox textBox = (TextBox)row.Cells[2].FindControl("txtcilpraxair");
                    TextBox textBox1 = (TextBox)row.Cells[2].FindControl("txtcilpart");
                    TextBox textBox2 = (TextBox)row.Cells[2].FindControl("txtcilsellos");
                    TextBox textBox3 = (TextBox)row.Cells[2].FindControl("txtcilrechazo");
                    int num = Convert.ToInt16(textBox1.Text);
                    if (num <= 0)
                    {
                        continue;
                    }
                    for (int i = 1; i <= num; i++)
                    {
                        DataRow str = dataTable.NewRow();
                        str[0] = row.Cells[0].Text.ToString();
                        dataTable.Rows.Add(str);
                    }
                }
                this.grvSecPart.DataSource = dataTable;
                this.grvSecPart.DataBind();
            }
            catch (Exception exception)
            {
                this.lblErrorPart.Text = clsConstantes.ManejoExcepciones(exception);
            }
        }

        private void CargarTanque(int _Empresa, int _Agencia, string _Gas, bool usaSustitutos)
        {
            try
            {
                this.lblErrorComposicion.Text = "";
                int num = (usaSustitutos ? 1 : 0);
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaTanque(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Agencia, _Gas, num);
                this.grdCompTanque.DataSource = dataSet;
                this.grdCompTanque.DataBind();
                foreach (GridViewRow row in this.grdCompTanque.Rows)
                {
                    if (serviceSoapClient.NivelesAbiertos(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Agencia.ToString(), this.grdCompTanque.DataKeys[row.RowIndex].Values["codTanque"].ToString(), this.lblNumTurno.Text).Equals(0))
                    {
                        this.lblErrorComposicion.Text = string.Concat("El tanque ", this.grdCompTanque.DataKeys[row.RowIndex].Values["codTanque"].ToString(), " NO tiene cargado el nivel inicial. \n");
                    }
                    if (this.lCantidadTanquesDisponibles(_Empresa, _Agencia, _Gas, this.grdCompTanque.DataKeys[row.RowIndex].Values["codProducto"].ToString()) > 1)
                    {
                        Label label = this.lblErrorComposicion;
                        string[] str = new string[] { "Existe mas de un Tanque para lotear el producto: ", this.grdCompTanque.DataKeys[row.RowIndex].Values["codProducto"].ToString(), "-", this.grdCompTanque.DataKeys[row.RowIndex].Values["PRODUCTO"].ToString(), " Debera seleccionar el que corresponda." };
                        label.Text = string.Concat(str);
                        CheckBox checkBox = (CheckBox)row.FindControl("chkCompTanque");
                        checkBox.Enabled = true;
                        checkBox.Checked = false;
                    }
                    if (!this.fActivos_STOCKEABLES(_Empresa, this.grdCompTanque.DataKeys[row.RowIndex].Values["codProducto"].ToString()))
                    {
                        this.grdCompTanque.Rows[row.RowIndex].Cells[7].Text = this.StockActualEnSucursal(_Grupo, _Empresa, this.grdCompTanque.DataKeys[row.RowIndex].Values["Subdeposito"].ToString(), this.BuscarARTIDNUM(_Empresa, this.grdCompTanque.DataKeys[row.RowIndex].Values["codProducto"].ToString()), this.grdCompTanque.DataKeys[row.RowIndex].Values["codTanque"].ToString());
                    }
                    else
                    {
                        this.grdCompTanque.Rows[row.RowIndex].Cells[7].Text = this.StockActualEnSucursal(_Grupo, _Empresa, this.grdCompTanque.DataKeys[row.RowIndex].Values["Subdeposito"].ToString(), this.BuscarARTIDNUM(_Empresa, this.grdCompTanque.DataKeys[row.RowIndex].Values["codProducto"].ToString()), "0");
                    }
                }
                this.CargarComposicion(_Gas, false);
            }
            catch (Exception exception)
            {
                this.lblErrorComposicion.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupComposicion.Update();
                this.mpepopupComposicion.Show();
            }
        }

        private void CargarTermos()
        {
            try
            {
                clsGenerales clsGenerale = new clsGenerales();
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = (!this.rdbPx.Checked ? serviceSoapClient.ConsultaTermoPart(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString()) : serviceSoapClient.ConsultaTermoPrax(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString()));
                clsGenerale.cargarCombos(dataSet, this.cboTermo, "nombre", "codigo", "");
                this.cboTermo.Items.Insert(0, "--Seleccione--");
                if (dataSet.Tables[0].DefaultView.Count == 0)
                {
                    if (!this.rdbPx.Checked)
                    {
                        this.lblmensaje.Text = "No se han definido Termos Particulares para el cliente seleccionado.";
                    }
                    else
                    {
                        this.lblmensaje.Text = "No se han definido Termos propiedad de Praxair.";
                    }
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

        private void CargarTipoProducto(string Producto)
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                DataSet dataSet1 = new DataSet();
                DataTable dataTable = dataSet1.Tables.Add();
                dataTable.Columns.Add("codigo", typeof(string));
                dataTable.Columns.Add("nombre", typeof(string));
                dataSet = serviceSoapClient.ConsTipPrdMedicinal(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Grupo, Producto);
                if (dataSet.Tables[0].DefaultView.Count != 0)
                {
                    TipoProducto = (dataSet.Tables[0].Rows[0][0].ToString() == "S" ? "M" : "");
                }
                else
                {
                    TipoProducto = "";
                }
                if (this.rdbStockeables.Checked)
                {
                    DataRow dataRow = dataSet1.Tables[0].NewRow();
                    dataRow[0] = "MS";
                    dataRow[1] = "MS";
                    dataSet1.Tables[0].Rows.Add(dataRow);
                }
                else if (TipoProducto == "M" || TipoProducto == "H")
                {
                    DataRow dataRow1 = dataSet1.Tables[0].NewRow();
                    dataRow1[0] = "GM";
                    dataRow1[1] = "GM";
                    dataSet1.Tables[0].Rows.Add(dataRow1);
                }
                else
                {
                    DataRow dataRow2 = dataSet1.Tables[0].NewRow();
                    dataRow2[0] = "GI";
                    dataRow2[1] = "GI";
                    dataSet1.Tables[0].Rows.Add(dataRow2);
                    dataRow2 = dataSet1.Tables[0].NewRow();
                    dataRow2[0] = "GE";
                    dataRow2[1] = "GE";
                    dataSet1.Tables[0].Rows.Add(dataRow2);
                    dataRow2 = dataSet1.Tables[0].NewRow();
                    dataRow2[0] = "MR";
                    dataRow2[1] = "MR";
                    dataSet1.Tables[0].Rows.Add(dataRow2);
                }
                (new clsGenerales()).cargarCombos(dataSet1, this.cboTipGas, "nombre", "codigo", "");
                this.cboTipGas.Items.Insert(0, "--Seleccione--");
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void cboGas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            try
            {
                string str1 = Convert.ToString(this.cboGas.SelectedItem);
                DataSet dataSet = new DataSet();
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet1 = new DataSet();
                if (str1 != "--Seleccione--")
                {
                    this.CargarGrillaCx("0", 0, "0");
                    string str2 = Convert.ToString(this.cboGas.SelectedItem.Value);
                    if (str2.Length == 7)
                    {
                        this.CargarTipoProducto(str2);
                        if (!this.rdbStockeables.Checked)
                        {
                            this.Campos(true);
                            this.rdbCumple.Checked = false;
                            this.rdbCumple.Enabled = true;
                            this.rdbNoCumple.Checked = false;
                            this.rdbNoCumple.Enabled = true;
                            dataSet1 = serviceSoapClient.ConsPrimerVacio(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Grupo, _Agencia, str2);
                            str = (dataSet1.Tables[0].DefaultView.Count <= 0 ? "0" : dataSet1.Tables[0].Rows[0][0].ToString());
                            this.txtVacio.Text = str;
                            dataSet1 = serviceSoapClient.ConsProductInsumLastro(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Agencia, str2);
                            ProdLastro = dataSet1.Tables[0].Rows[0][0].ToString();
                            this.imbLastroInsumos.Enabled = (ProdLastro.Length == 0 ? false : true);
                            if (this.rdbCilindro.Checked)
                            {
                                string str3 = Convert.ToString(this.cboGas.SelectedItem.Value);
                                this.CargarGrillaCx("0", 2, str3);
                            }
                        }
                        else
                        {
                            this.rdbCumple.Checked = false;
                            this.rdbCumple.Enabled = false;
                            this.rdbNoCumple.Checked = false;
                            this.rdbNoCumple.Enabled = false;
                            dataSet = serviceSoapClient.ConsUnidadMed(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, str2);
                            this.lblUnidad.Text = (dataSet.Tables[0].DefaultView.Count > 0 ? dataSet.Tables[0].Rows[0][0].ToString() : "");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void cboTermo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = Convert.ToString(this.cboTermo.SelectedItem);
                string str1 = "0";
                if (str != "--Seleccione--")
                {
                    string str2 = Convert.ToString(this.cboTermo.SelectedItem.Value);
                    this.cboGas.SelectedItem.Value = str2;
                    this.CargarTipoProducto(str2);
                    foreach (DataRow row in Termos.Tables[0].Rows)
                    {
                        if (Convert.ToString(row["PRODUCTO"]) != str2)
                        {
                            continue;
                        }
                        str1 = Convert.ToString(row["CAPACIDAD"]);
                    }
                    this.CargarGrillaCx(str1, 1, "0");
                    this.rdbCumple.Checked = true;
                    this.txtEtiquetas.Text = "0";
                    this.txtPrecintos.Text = "0";
                    this.PnLote.Enabled = true;
                    this.pnCx.Enabled = true;
                    this.imbGuardarLote.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void cboTipGas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = Convert.ToString(this.cboTipGas.SelectedItem);
                string str1 = Convert.ToString(this.cboGas.SelectedItem);
                if (str != "--Seleccione--")
                {
                    if (str == "GM" || str == "LM" || TipoProducto == "M" || TipoProducto == "H" && str1 != "--Seleccione--")
                    {
                        this.imbAnalisisGM.Enabled = true;
                    }
                    else
                    {
                        this.imbAnalisisGM.Enabled = false;
                    }
                    this.chkNoDescuenta.Enabled = (str == "MR" ? true : false);
                    if (str == "MR")
                    {
                        this.PnLote.Enabled = false;
                        this.rdbTermo.Enabled = false;
                        this.rdbCilindro.Checked = true;
                        this.cboTermo.Enabled = false;
                    }
                    else if (str != "MS")
                    {
                        this.cboTermo.Enabled = true;
                    }
                    else
                    {
                        this.PnLote.Enabled = false;
                        this.imbGuardarLote.Enabled = true;
                    }
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void chkNoDescuenta_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void chkPosee_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow parent = (GridViewRow)((DataControlFieldCell)((CheckBox)sender).Parent).Parent;
                CheckBox checkBox = (CheckBox)parent.FindControl("chkPosee");
                TextBox textBox = (TextBox)parent.FindControl("txtValNum");
                if (this.grvAnalisisGm.Rows[parent.RowIndex].Cells[6].Text.ToUpper() == "DETECTA")
                {
                    if (checkBox.Checked)
                    {
                        this.grvAnalisisGm.Rows[parent.RowIndex].Cells[3].Text = "No Detecta";
                        textBox.Visible = false;
                        textBox.Text = "0";
                    }
                    else
                    {
                        this.grvAnalisisGm.Rows[parent.RowIndex].Cells[3].Text = "Detecta";
                        textBox.Visible = false;
                        textBox.Text = "0";
                    }
                }
                else if (this.grvAnalisisGm.Rows[parent.RowIndex].Cells[6].Text.ToUpper() == "CUMPLE")
                {
                    if (checkBox.Checked)
                    {
                        this.grvAnalisisGm.Rows[parent.RowIndex].Cells[3].Text = "Cumple";
                        textBox.Visible = false;
                        textBox.Text = "0";
                    }
                    else
                    {
                        this.grvAnalisisGm.Rows[parent.RowIndex].Cells[3].Text = "No Cumple";
                        textBox.Visible = false;
                        textBox.Text = "0";
                    }
                }
                if (!checkBox.Checked && this.grvAnalisisGm.Rows[parent.RowIndex].Cells[2].Text == "" && (this.grvAnalisisGm.Rows[parent.RowIndex].Cells[3].Text.ToUpper() == "CUMPLE" || this.grvAnalisisGm.Rows[parent.RowIndex].Cells[3].Text.ToUpper() == "NO DETECTA"))
                {
                    checkBox.Checked = true;
                }
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
            }
        }

        protected void chkReemplazo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool @checked = this.chkReemplazo.Checked;
                this.CargarTanque(_Empresa, _Agencia, Convert.ToString(this.cboGas.SelectedItem.Value), @checked);
                this.CargarComposicion(Convert.ToString(this.cboGas.SelectedItem.Value), @checked);
            }
            catch (Exception exception)
            {
                this.lblErrorComposicion.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupComposicion.Update();
                this.mpepopupComposicion.Show();
            }
        }

        private bool fActivos_STOCKEABLES(int _Empresa, string _codproducto)
        {
            bool flag;
            bool flag1 = false;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaStockDisp(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _codproducto);
                if (dataSet.Tables[0].DefaultView.Count > 0)
                {
                    flag1 = (Convert.ToDouble(dataSet.Tables[0].Rows[0][0].ToString()) == 0 ? false : true);
                }
                flag = flag1;
            }
            catch (Exception exception)
            {
                this.lblErrorComposicion.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupComposicion.Update();
                this.mpepopupComposicion.Show();
                flag = flag1;
            }
            return flag;
        }

        private bool fValidaProductoEnCuarentena(string _Producto)
        {
            bool flag;
            bool flag1 = false;
            try
            {
                int num = 0;
                int num1 = 0;
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ValidaProductoEnCuarentena(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Producto);
                if (!dataSet.Tables[0].DefaultView.Count.Equals(0))
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        if (Convert.ToInt16(row["EnCuarentena"]) == 0 || Convert.ToInt16(row["NoCuarentena"]) != 0)
                        {
                            if (Convert.ToInt16(row["EnCuarentena"]) != 0 || Convert.ToInt16(row["NoCuarentena"]) == 0)
                            {
                                continue;
                            }
                            num1 = Convert.ToInt16(row["NoCuarentena"]);
                        }
                        else
                        {
                            num = Convert.ToInt16(row["EnCuarentena"]);
                        }
                    }
                    flag1 = (num > num1 ? true : false);
                }
                else
                {
                    flag1 = false;
                    this.lblErrorAnalisis.Text = string.Concat("No existe este producto : ", _Producto, " en la tabla de Relaciones. Revise los datos existentes y vuelva a intentar");
                }
                flag = flag1;
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
                flag = flag1;
            }
            return flag;
        }

        protected void generarLote()
        {
            double num;
            ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
            int num1 = Convert.ToInt32(this.Session["ID_TRANSACCION"].ToString());
            string str = Convert.ToString(this.cboGas.SelectedItem.Value);
            int num2 = Convert.ToInt32(this.cboSubdeposito.SelectedValue);
            serviceSoapClient.DEL_DATOS_TMP_LOTE(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), num1);
            foreach (GridViewRow row in this.grdDetCx.Rows)
            {
                TextBox textBox = (TextBox)row.FindControl("txtcilpraxair");
                TextBox textBox1 = (TextBox)row.FindControl("txtcilpart");
                TextBox textBox2 = (TextBox)row.FindControl("txtcilsellos");
                TextBox textBox3 = (TextBox)row.FindControl("txtcilrechazo");
                double num3 = Convert.ToDouble(this.grdDetCx.DataKeys[row.RowIndex].Values["CAPACIDAD"].ToString().Replace(".", ","));
                textBox.Text = (textBox.Text == "" ? "0" : textBox.Text);
                textBox1.Text = (textBox1.Text == "" ? "0" : textBox1.Text);
                textBox2.Text = (textBox2.Text == "" ? "0" : textBox2.Text);
                textBox3.Text = (textBox3.Text == "" ? "0" : textBox3.Text);
                if (Convert.ToInt16(textBox.Text) > 0)
                {
                    serviceSoapClient.DETALLE_LOTE_INS(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), num1, str, num3, 1, Convert.ToInt16(textBox.Text));
                }
                if (Convert.ToInt16(textBox1.Text) <= 0)
                {
                    continue;
                }
                serviceSoapClient.DETALLE_LOTE_INS(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), num1, str, num3, 2, Convert.ToInt16(textBox1.Text));
            }
            foreach (GridViewRow gridViewRow in this.grdCompTanque.Rows)
            {
                if (!((CheckBox)gridViewRow.FindControl("chkCompTanque")).Checked)
                {
                    continue;
                }
                num = Convert.ToDouble(this.lblSumTotalVol.Text);
                string str1 = this.grdCompTanque.DataKeys[gridViewRow.RowIndex].Values["codProducto"].ToString();
                int num4 = Convert.ToInt32(this.grdCompTanque.DataKeys[gridViewRow.RowIndex].Values["Subdeposito"].ToString());
                serviceSoapClient.DETALLE_LOTE_COMPOS_INS(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), num1, str1, 1, 1, num, num4, this.grdCompTanque.Rows[gridViewRow.RowIndex].Cells[5].Text);
            }
            foreach (GridViewRow row1 in this.grdInsumos.Rows)
            {
                num = Convert.ToDouble(this.grdInsumos.Rows[row1.RowIndex].Cells[8].Text);
                string str2 = this.grdInsumos.DataKeys[row1.RowIndex].Values["ARTID"].ToString();
                serviceSoapClient.DETALLE_LOTE_COMPOS_INS(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), num1, str2, 1, 1, num, num2, "");
            }
            int num5 = Convert.ToInt16(this.Session["grupo"].ToString());
            int num6 = Convert.ToInt16(this.Session["empresa"].ToString());
            string str3 = this.Session["agencia"].ToString();
            DateTime dateTime = Convert.ToDateTime(this.Session["fecha"]);
            string selectedValue = this.cboTipGas.SelectedValue;
            double num7 = Convert.ToDouble(this.txtVacio.Text);
            double num8 = 0;
            double num9 = 0;
            string text = this.txthoraIni.Text;
            string text1 = this.txtHoraFin.Text;
            string selectedValue1 = this.cboRack.SelectedValue;
            double num10 = Convert.ToDouble(this.txtPresion.Text);
            double num11 = Convert.ToDouble(this.txtTemp.Text);
            string str4 = "N";
            double num12 = Convert.ToDouble((this.txtPureza.Text == "" ? "0" : this.txtPureza.Text));
            int num13 = Convert.ToInt32((this.txtCo.Text == "" ? "0" : this.txtCo.Text));
            int num14 = Convert.ToInt32((this.txtCO2.Text == "" ? "0" : this.txtCO2.Text));
            string str5 = "N";
            string selectedValue2 = this.cboClasificador.SelectedValue;
            DateTime now = DateTime.Now;
            int num15 = 0;
            if (this.rdbCumple.Checked)
            {
                str5 = "S";
            }
            if (this.chkTest.Checked)
            {
                str4 = "S";
            }
            string str6 = serviceSoapClient.GenerarLote(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), num5, num6, str3, dateTime, selectedValue, num2, str, num7, num8, num9, text, text1, selectedValue1, num10, num11, str4, num12, this.Session["usuario"].ToString(), num13, num14, str5, _CodLegajo, selectedValue2, now, num15, num1);
            _LimpiarTodo = 1;
            this.lblmensaje.Text = string.Concat("Se genero el lote : ", str6);
            this.upmensaje.Update();
            this.mpemensaje.Show();
        }

        protected void grdDetCx_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void grdDetCx_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void imbAcepConfPart_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.mpepopupPart.Hide();
                this.mpeConfPart.Hide();
            }
            catch (Exception exception)
            {
                this.lblErrorPart.Text = clsConstantes.ManejoExcepciones(exception);
            }
        }

        protected void imbAcepLegajo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.lblerrLegajo.Text = "";
                if (this.txtLegajo.Text == "")
                {
                    this.lblerrLegajo.Text = "Debe ingresar un legajo válido.";
                }
                else if (this.txtContraseña.Text == "")
                {
                    this.lblerrLegajo.Text = "Debe ingresar una contraseña válida.";
                }
                else if (this.UsuarioValido())
                {
                    this.mpepopupLegajo.Hide();
                    _CodLegajo = this.txtLegajo.Text;
                    this.generarLote();
                }
                else
                {
                    this.lblerrLegajo.Text = "Usuario no habilitado para esta aplicación";
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void imbAceptarComp_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                bool flag = false;
                string str = "";
                foreach (GridViewRow row in this.grdCompTanque.Rows)
                {
                    if (!((CheckBox)row.FindControl("chkCompTanque")).Checked)
                    {
                        continue;
                    }
                    flag = true;
                    if (!this.grdCompTanque.DataKeys[row.RowIndex].Values["codProducto"].ToString().Equals(str))
                    {
                        str = this.grdCompTanque.DataKeys[row.RowIndex].Values["codProducto"].ToString();
                    }
                    else
                    {
                        this.lblErrorComposicion.Text = "No puede seleccionar dos tanques del mismo producto!!!";
                        return;
                    }
                }
                if (flag || this.grdCompTanque.Rows.Count <= 0)
                {
                    foreach (GridViewRow gridViewRow in this.grdInsumos.Rows)
                    {
                        TextBox textBox = (TextBox)gridViewRow.FindControl("txtCantExtra");
                        if (textBox.Text.Length <= 0 || Convert.ToDouble(textBox.Text) <= Convert.ToDouble(this.grdInsumos.Rows[gridViewRow.RowIndex].Cells[6].Text))
                        {
                            continue;
                        }
                        this.lblErrorComposicion.Text = "Por Favor verifique la Cantidad Extra.";
                        textBox.Text = "0";
                        this.grdInsumos.Rows[gridViewRow.RowIndex].Cells[8].Text = Convert.ToString(this.grdInsumos.Rows[gridViewRow.RowIndex].Cells[6].Text);
                        return;
                    }
                    this.mpepopupComposicion.Hide();
                }
                else
                {
                    this.lblErrorComposicion.Text = "Debe seleccionar un tanque por lo menos!!!";
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void imbAceptarPart_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string str = "";
                int num = 0;
                int num1 = Convert.ToInt32(this.lblSumCilPart.Text);
                this.lblErrorPart.Text = "";
                foreach (GridViewRow row in this.grvSecPart.Rows)
                {
                    string text = ((TextBox)row.FindControl("txtSecPart")).Text;
                    text = text.Replace("_", "");
                    if (!(text != "") || !(this.grvSecPart.Rows[row.RowIndex].Cells[1].Text != "") || !(this.grvSecPart.Rows[row.RowIndex].Cells[2].Text != ""))
                    {
                        continue;
                    }
                    str = (str != "" ? string.Concat(str, ",", text) : text);
                    num++;
                }
                if (num != num1)
                {
                    this.lblSecCargadas.Text = Convert.ToString(num);
                    this.lblSecPart.Text = Convert.ToString(num1);
                    this.upConfPart.Update();
                    this.mpeConfPart.Show();
                    Label label = this.lblMenConfPart;
                    object[] objArray = new object[] { "La cantidad de tubos particulares identificados por secuencias: ", num, " es menor que la ingresada en el Parte: ", num1, ". ¿Está seguro que desea salir?" };
                    label.Text = string.Concat(objArray);
                }
                else if (this.ProcesoParticulares())
                {
                    this.mpepopupPart.Hide();
                    this.lblmensaje.Text = "Se modificaron las capacidades correctamente";
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                }
            }
            catch (Exception exception)
            {
                this.lblErrorPart.Text = clsConstantes.ManejoExcepciones(exception);
            }
        }

        protected void imbAgregarCap_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (this.txtcapacidad.Text != "")
                {
                    DataTable dataTable = new DataTable("Capacidades");
                    dataTable.Columns.Add("Capacidad", typeof(string));
                    dataTable.Columns.Add("CilPrax", typeof(string));
                    dataTable.Columns.Add("CilPart", typeof(string));
                    dataTable.Columns.Add("CilPerdS", typeof(string));
                    dataTable.Columns.Add("CilRechz", typeof(string));
                    foreach (GridViewRow row in this.grdDetCx.Rows)
                    {
                        TextBox textBox = (TextBox)row.Cells[2].FindControl("txtcilpraxair");
                        TextBox textBox1 = (TextBox)row.Cells[2].FindControl("txtcilpart");
                        TextBox textBox2 = (TextBox)row.Cells[2].FindControl("txtcilsellos");
                        TextBox textBox3 = (TextBox)row.Cells[2].FindControl("txtcilrechazo");
                        DataRow str = dataTable.NewRow();
                        str[0] = row.Cells[0].Text.ToString();
                        str[1] = textBox.Text;
                        str[2] = textBox1.Text;
                        str[3] = textBox2.Text;
                        str[4] = textBox3.Text;
                        dataTable.Rows.Add(str);
                    }
                    DataRow num = dataTable.NewRow();
                    num[0] = Convert.ToDouble(this.txtcapacidad.Text);
                    num[1] = 0;
                    num[2] = 0;
                    num[3] = 0;
                    num[4] = 0;
                    dataTable.Rows.Add(num);
                    this.grdDetCx.DataSource = dataTable;
                    this.grdDetCx.DataBind();
                    this.txtcapacidad.Text = "";
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void imbAnalisisGM_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.lblErrorAnalisis.Text = "";
                if (Convert.ToString(this.cboGas.SelectedItem) != "--Seleccione--")
                {
                    this.imbDesmarcar.Visible = false;
                    this.imbMarcarTodo.Visible = true;
                    this.upopupAnalisisGM.Update();
                    this.mpepopupAnalisisGM.Show();
                    this.grvAnalisisGm.DataSource = "";
                    this.grvAnalisisGm.DataBind();
                    if (_CodLegajo == "0")
                    {
                        _CodLegajo = this.BuscaLegajoxNMB(this.BuscarNombreUsuario(_IDUsuario));
                    }
                    string str = Convert.ToString(this.cboGas.SelectedItem.Value);
                    this.lblProductoLoteado.Text = string.Concat(str, " - ", this.BuscarDscArticulo(_Empresa, str));
                    this.txtRespTecnico.Text = this.sBuscarDirectorTecnico(_Agencia);
                    if (!this.blnUsuarioHabilitado("CTRLCALID", this.BuscarNmbUsuarioXLegajo(_CodLegajo)))
                    {
                        this.txtNroCilindro.Enabled = true;
                        this.txtNroAnalisis.Enabled = false;
                    }
                    else
                    {
                        this.txtNroCilindro.Enabled = true;
                        this.txtNroAnalisis.Enabled = true;
                        this.txtNroAnalisis.Enabled = this.fValidaProductoEnCuarentena(str);
                    }
                    this.CargaGrillaAnalisis(str);
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void imbCalcular_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                double num4 = 0;
                double num5 = 0;
                double num6 = 0;
                double num7 = 0;
                double num8 = 0;
                foreach (GridViewRow row in this.grdDetCx.Rows)
                {
                    TextBox textBox = (TextBox)row.FindControl("txtcilpraxair");
                    TextBox textBox1 = (TextBox)row.FindControl("txtcilpart");
                    TextBox textBox2 = (TextBox)row.FindControl("txtcilsellos");
                    TextBox textBox3 = (TextBox)row.FindControl("txtcilrechazo");
                    num8 = Convert.ToDouble(this.grdDetCx.DataKeys[row.RowIndex].Values["CAPACIDAD"].ToString().Replace(".", ","));
                    textBox.Text = (textBox.Text == "" ? "0" : textBox.Text);
                    textBox1.Text = (textBox1.Text == "" ? "0" : textBox1.Text);
                    textBox2.Text = (textBox2.Text == "" ? "0" : textBox2.Text);
                    textBox3.Text = (textBox3.Text == "" ? "0" : textBox3.Text);
                    num += Convert.ToInt16(textBox.Text);
                    num1 += Convert.ToInt16(textBox1.Text);
                    num2 += Convert.ToInt16(textBox2.Text);
                    num3 += Convert.ToInt16(textBox3.Text);
                    num4 = num4 + Convert.ToDouble(textBox.Text) * num8;
                    num5 = num5 + Convert.ToDouble(textBox1.Text) * num8;
                    num6 = num6 + (double)Convert.ToInt16(textBox2.Text) * num8;
                    num7 = num7 + (double)Convert.ToInt16(textBox3.Text) * num8;
                }
                this.lblSumCilPraxair.Text = Convert.ToString(num);
                this.lblSumCilPart.Text = Convert.ToString(num1);
                this.lblSumCilSellos.Text = Convert.ToString(num2);
                this.lblSumCilRechaz.Text = Convert.ToString(num3);
                this.lbSumVolPrax.Text = Convert.ToString(num4);
                this.lblSumVolPar.Text = Convert.ToString(num5);
                this.lblSumVolSellos.Text = Convert.ToString(num6);
                this.lblSumVolRechaz.Text = Convert.ToString(num7);
                int num9 = num + num1 + num2 + num3;
                double num10 = num4 + num5 + num6 + num7;
                this.lblSumTotalCx.Text = Convert.ToString(num9);
                this.lblSumTotalVol.Text = Convert.ToString(num10);
                if (num1 <= 0)
                {
                    this.imbParticulares.Enabled = false;
                    this.lblCantTubos.Text = "0";
                }
                else
                {
                    this.imbParticulares.Enabled = true;
                    this.lblCantTubos.Text = Convert.ToString(num1);
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void imbCancelPart_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.mpepopupPart.Hide();
            }
            catch (Exception exception)
            {
                this.lblErrorPart.Text = clsConstantes.ManejoExcepciones(exception);
            }
        }

        protected void imbCanConfPart_Click(object sender, ImageClickEventArgs e)
        {
            int num;
            try
            {
                this.mpeConfPart.Hide();
                int num1 = Convert.ToInt16(this.lblSecCargadas.Text);
                int num2 = Convert.ToInt16(this.lblSecPart.Text);
                if (num1 > num2)
                {
                    num = num1 - num2;
                    this.lblErrorPart.Text = string.Concat("Elimine la/s ", Convert.ToString(num), " secuencia/s sobrante/s.");
                }
                if (num1 < num2)
                {
                    num = num2 - num1;
                    this.lblErrorPart.Text = string.Concat("Agregue la/s ", Convert.ToString(num), " secuencia/s sobrante/s.");
                }
                this.upopupPart.Update();
            }
            catch (Exception exception)
            {
                this.lblErrorPart.Text = clsConstantes.ManejoExcepciones(exception);
            }
        }

        protected void imbCerrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.upConfirmacion.Update();
                this.mpeConfirmacion.Show();
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
            }
        }

        protected void imbCerrarLastro_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.mpepopupLastro.Hide();
            }
            catch (Exception exception)
            {
                this.lblerrorlastro.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupLastro.Update();
                this.mpepopupLastro.Show();
            }
        }

        protected void imbComposicion_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.lblErrorComposicion.Text = "";
                string str = Convert.ToString(this.cboGas.SelectedItem);
                string str1 = Convert.ToString(this.cboSubdeposito.SelectedItem);
                if (str != "--Seleccione--" && !this.rdbStockeables.Checked)
                {
                    if (str1 != "--Seleccione--")
                    {
                        this.upopupComposicion.Update();
                        this.mpepopupComposicion.Show();
                        this.lblProducto.Text = this.cboGas.SelectedItem.Text;
                        this.CargarTanque(_Empresa, _Agencia, Convert.ToString(this.cboGas.SelectedItem.Value), false);
                    }
                    else
                    {
                        this.lblmensaje.Text = "No seleccionó ningun Subdepósito de Producción";
                        this.upmensaje.Update();
                        this.mpemensaje.Show();
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void imbDesmarcar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.imbDesmarcar.Visible = false;
                this.imbMarcarTodo.Visible = true;
                foreach (GridViewRow row in this.grvAnalisisGm.Rows)
                {
                    ((CheckBox)row.FindControl("chkPosee")).Checked = false;
                    TextBox textBox = (TextBox)row.FindControl("txtValNum");
                    if (this.grvAnalisisGm.DataKeys[row.RowIndex].Values["ID_TIPO"].ToString() != "3")
                    {
                        if (this.grvAnalisisGm.Rows[row.RowIndex].Cells[2].Text == "")
                        {
                            this.grvAnalisisGm.Rows[row.RowIndex].Cells[3].Text = "No cumple";
                            textBox.Visible = false;
                            textBox.Text = "0";
                        }
                        else
                        {
                            this.grvAnalisisGm.Rows[row.RowIndex].Cells[3].Text = "";
                        }
                    }
                    else if (this.grvAnalisisGm.Rows[row.RowIndex].Cells[6].Text.ToUpper() != "DETECTA")
                    {
                        textBox.Text = "0";
                    }
                    else
                    {
                        this.grvAnalisisGm.Rows[row.RowIndex].Cells[3].Text = "Detecta";
                        textBox.Visible = false;
                        textBox.Text = "0";
                    }
                }
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
            }
        }

        protected void imbGuardarLote_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (this.CamposValidos())
                {
                    CultureInfo cultureInfo = new CultureInfo("es-co");
                    this.Session["fecha"] = DateTime.ParseExact(this.txtfecha.Text.Trim(), "dd/MM/yyyy", cultureInfo);
                    this.txtLegajo.Text = "";
                    this.txtContraseña.Text = "";
                    this.txtContraseña.Enabled = false;
                    this.lblNomUsu.Text = "";
                    this.upopupLegajo.Update();
                    this.mpepopupLegajo.Show();
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void imbLastroInsumos_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.lblerrorlastro.Text = "";
                this.upopupLastro.Update();
                this.mpepopupLastro.Show();
                this.CargarGrillaLastro();
            }
            catch (Exception exception)
            {
                this.lblerrorlastro.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupLastro.Update();
                this.mpepopupLastro.Show();
            }
        }

        protected void imbMarcarTodo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.imbDesmarcar.Visible = true;
                this.imbMarcarTodo.Visible = false;
                foreach (GridViewRow row in this.grvAnalisisGm.Rows)
                {
                    ((CheckBox)row.FindControl("chkPosee")).Checked = true;
                    TextBox textBox = (TextBox)row.FindControl("txtValNum");
                    if (this.grvAnalisisGm.DataKeys[row.RowIndex].Values["ID_TIPO"].ToString() != "3")
                    {
                        if (this.grvAnalisisGm.Rows[row.RowIndex].Cells[2].Text != "")
                        {
                            continue;
                        }
                        this.grvAnalisisGm.Rows[row.RowIndex].Cells[3].Text = "Cumple";
                        textBox.Visible = false;
                        textBox.Text = "0";
                    }
                    else
                    {
                        if (this.grvAnalisisGm.Rows[row.RowIndex].Cells[6].Text.ToUpper() != "DETECTA")
                        {
                            continue;
                        }
                        this.grvAnalisisGm.Rows[row.RowIndex].Cells[3].Text = "No Detecta";
                        textBox.Visible = false;
                        textBox.Text = "0";
                    }
                }
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
            }
        }

        protected void imbParticulares_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.lblErrorPart.Text = "";
                if (Convert.ToString(this.cboGas.SelectedItem) != "--Seleccione--")
                {
                    this.upopupPart.Update();
                    this.mpepopupPart.Show();
                    this.CargarGrillaSecuencias();
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        private double lCantidadTanquesDisponibles(int _Empresa, int _Agencia, string _Producto, string _codproducto)
        {
            double num;
            double num1 = 0;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaTanqueDisp(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Agencia, _Producto, _codproducto);
                if (dataSet.Tables[0].DefaultView.Count > 0)
                {
                    num1 = Convert.ToDouble(dataSet.Tables[0].Rows[0][0].ToString());
                }
                num = num1;
            }
            catch (Exception exception)
            {
                this.lblErrorComposicion.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupComposicion.Update();
                this.mpepopupComposicion.Show();
                num = num1;
            }
            return num;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ClsGeneral clsGeneral;
            if (!this.Page.IsPostBack)
            {
                try
                {
                    if ((new ClsGeneral()).tienePermiso(this.Session["idusuario"].ToString(), "GENERACION_LOTE").Equals("0"))
                    {
                        clsGeneral = null;
                        base.Response.Redirect("../inicio/default.aspx");
                    }
                    clsGeneral = null;
                    this.Session["fecha"] = DateTime.Now;
                    _Empresa = Convert.ToInt32(this.Session["empresa"].ToString());
                    _Grupo = Convert.ToInt32(this.Session["grupo"].ToString());
                    _Agencia = Convert.ToInt32(this.Session["agencia"].ToString());
                    this.SetearTurno();
                    this.CargarCombos();
                    this.CargarGrillaCx("0", 0, "0");
                    this.Campos(false);
                    this.SetearCamposCilindro();
                    _CodLegajo = "0";
                    _IDUsuario = Convert.ToString(this.Session["idusuario"].ToString());
                    ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                    this.Session.Add("ID_TRANSACCION", serviceSoapClient.id_Transaccion(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString()));
                    serviceSoapClient.Close();
                    serviceSoapClient = null;
                }
                catch (Exception exception)
                {
                    this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                }
            }
        }

        private bool ProcesoParticulares()
        {
            bool flag;
            bool flag1 = false;
            try
            {
                string str = "0";
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultarComprobante(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Grupo, _Agencia);
                if (dataSet.Tables[0].DefaultView.Count > 0)
                {
                    str = dataSet.Tables[0].Rows[0][0].ToString();
                    if (str != "0")
                    {
                        str = str.PadLeft(8, '0');
                        string str1 = Convert.ToString(this.cboGas.SelectedItem.Value);
                        DataTable dataTable = new DataTable("Particulares");
                        dataTable.Columns.Add(new DataColumn("producto", typeof(string)));
                        dataTable.Columns.Add(new DataColumn("NUME_TSP", typeof(string)));
                        dataTable.Columns.Add(new DataColumn("AGEN_CAPA", typeof(string)));
                        dataTable.Columns.Add(new DataColumn("capacidad", typeof(string)));
                        dataTable.Columns.Add(new DataColumn("Secuencia", typeof(string)));
                        DataRow text = null;
                        foreach (GridViewRow row in this.grvSecPart.Rows)
                        {
                            TextBox textBox = (TextBox)row.FindControl("txtSecPart");
                            string str2 = textBox.Text.Replace("_", "");
                            text = dataTable.NewRow();
                            text["producto"] = str1;
                            text["NUME_TSP"] = this.grvSecPart.Rows[row.RowIndex].Cells[2].Text;
                            text["AGEN_CAPA"] = this.grvSecPart.Rows[row.RowIndex].Cells[4].Text;
                            text["capacidad"] = this.grvSecPart.Rows[row.RowIndex].Cells[3].Text;
                            text["Secuencia"] = str2;
                            dataTable.Rows.Add(text);
                        }
                        flag1 = serviceSoapClient.GrabarSecuencias(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Grupo, _Agencia, str, dataTable);
                    }
                    else
                    {
                        dataSet = serviceSoapClient.ConsultarNoComprobante(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Grupo, _Agencia);
                        if (dataSet.Tables[0].DefaultView.Count <= 0)
                        {
                            flag1 = false;
                        }
                        else
                        {
                            this.lblErrorPart.Text = dataSet.Tables[0].Rows[0][0].ToString();
                            flag1 = false;
                        }
                    }
                }
                flag = flag1;
            }
            catch (Exception exception)
            {
                this.lblErrorPart.Text = clsConstantes.ManejoExcepciones(exception);
                flag = flag1;
            }
            return flag;
        }

        private bool ProductoUsaTanque(string _codproducto)
        {
            bool flag;
            bool flag1 = false;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaUsaTanque(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Grupo, _codproducto);
                if (dataSet.Tables[0].DefaultView.Count > 0)
                {
                    flag1 = (dataSet.Tables[0].Rows[0][0].ToString() == "S" ? true : false);
                }
                flag = flag1;
            }
            catch (Exception exception)
            {
                this.lblErrorComposicion.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupComposicion.Update();
                this.mpepopupComposicion.Show();
                flag = flag1;
            }
            return flag;
        }

        protected void rdbCilindro_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.SetearCamposCilindro();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void rdbCumple_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.imbParticulares.Enabled = false;
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void rdbPart_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.cboTermo.DataSource = "";
                this.cboTermo.DataBind();
                this.cboTermo.Items.Insert(0, "--Seleccione--");
                if (this.rdbPart.Checked)
                {
                    this.CargarTermos();
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void rdbPx_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.cboTermo.DataSource = "";
                this.cboTermo.DataBind();
                this.cboTermo.Items.Insert(0, "--Seleccione--");
                if (this.rdbPx.Checked)
                {
                    this.CargarTermos();
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void rdbStockeables_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.SetearCamposStockeables();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void rdbTermo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.SetearCamposTermo();
                this.txtCargaIni.Enabled = this.rdbTermo.Checked;
                this.CargarTermos();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        private string sBuscarDirectorTecnico(int agencia)
        {
            string str;
            string str1 = "";
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.ConsultaNombreDirTecnico(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), agencia);
                str1 = (dataSet.Tables[0].DefaultView.Count <= 0 ? "MARTIN LEDESMA" : dataSet.Tables[0].Rows[0][0].ToString());
                str = str1;
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
                str = str1;
            }
            return str;
        }

        private void SetearCamposCilindro()
        {
            try
            {
                this.rdbCilindro.Checked = true;
                this.rdbPart.Checked = false;
                this.rdbPart.Enabled = false;
                this.cboTermo.Enabled = false;
                this.cboTermo.Text = "--Seleccione--";
                this.txtCargaIni.Text = "0";
                this.txtCargaIni.Enabled = false;
                this.pnStockeable.Visible = false;
                this.PnLote.Enabled = false;
                this.pnCx.Enabled = false;
                this.CargarGrillaCx("0", 0, "0");
                this.rdbCumple.Checked = false;
                this.rdbCumple.Enabled = false;
                this.rdbNoCumple.Checked = false;
                this.rdbNoCumple.Enabled = false;
                this.imbAnalisisGM.Enabled = false;
                this.imbLastroInsumos.Enabled = false;
                this.imbParticulares.Enabled = false;
                this.imbGuardarLote.Enabled = false;
                this.CargarGases();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        private void SetearCamposStockeables()
        {
            try
            {
                this.PnLote.Enabled = false;
                this.pnCx.Enabled = false;
                this.pnStockeable.Visible = true;
                this.cboTipGas.DataSource = "";
                this.cboTipGas.DataBind();
                this.cboTipGas.Items.Insert(0, "--Seleccione--");
                this.imbComposicion.Enabled = false;
                this.cboClasificador.Enabled = false;
                this.txtfecha.Enabled = false;
                this.cboGas.Enabled = true;
                this.cboTermo.Enabled = false;
                this.rdbPx.Enabled = false;
                this.rdbPart.Enabled = false;
                this.rdbPx.Checked = false;
                this.rdbPart.Checked = false;
                this.txtCargaIni.Enabled = false;
                this.txtCargaIni.Text = "0";
                this.txtPrecintos.Text = "0";
                this.txtEtiquetas.Text = "0";
                this.txtPrecintos.Enabled = false;
                this.txtEtiquetas.Enabled = false;
                this.CargarGases();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        private void SetearCamposTermo()
        {
            try
            {
                this.PnLote.Enabled = true;
                this.pnCx.Enabled = true;
                this.pnStockeable.Enabled = false;
                this.cboTipGas.DataSource = "";
                this.cboTipGas.DataBind();
                this.cboTipGas.Items.Insert(0, "--Seleccione--");
                this.imbComposicion.Enabled = true;
                this.cboClasificador.Enabled = true;
                this.txtfecha.Enabled = true;
                this.cboTermo.Enabled = true;
                this.cboGas.Enabled = false;
                this.rdbPx.Enabled = true;
                this.rdbPart.Enabled = true;
                this.rdbPx.Checked = true;
                this.rdbPart.Checked = false;
                this.txtPrecintos.Text = "0";
                this.txtEtiquetas.Text = "0";
                this.txtPrecintos.Enabled = false;
                this.txtEtiquetas.Enabled = false;
                this.txtCargaIni.Enabled = false;
                this.txtCargaIni.Text = "0";
                this.CargarGases();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        private void SetearSiLoteCumple()
        {
            try
            {
                bool flag = true;
                foreach (GridViewRow row in this.grvAnalisisGm.Rows)
                {
                    CheckBox checkBox = (CheckBox)row.FindControl("chkPosee");
                    if (this.grvAnalisisGm.Rows[row.RowIndex].Cells[4].Text == "S" && !checkBox.Checked)
                    {
                        if (this.grvAnalisisGm.DataKeys[row.RowIndex].Values["ID_TIPO"].ToString() != "3")
                        {
                            flag = false;
                            break;
                        }
                        else if (this.blnUsuarioHabilitado("CTRLCALID", this.BuscarNmbUsuarioXLegajo(_CodLegajo)))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (this.grvAnalisisGm.Rows[row.RowIndex].Cells[2].Text == "")
                    {
                        if (!(this.grvAnalisisGm.Rows[row.RowIndex].Cells[2].Text == "") || !(this.grvAnalisisGm.DataKeys[row.RowIndex].Values["ID_TIPO"].ToString() == "3") || !(this.grvAnalisisGm.Rows[row.RowIndex].Cells[6].Text.ToUpper() == "DETECTA"))
                        {
                            continue;
                        }
                        flag = false;
                        break;
                    }
                    else
                    {
                        if (!((TextBox)row.FindControl("txtValNum")).Text.Equals(""))
                        {
                            continue;
                        }
                        flag = false;
                        break;
                    }
                }
                if (this.txtNroAnalisis.Text == "")
                {
                    this.txtNroAnalisis.Text = "0";
                }
                if (this.txtNroCilindro.Text == "")
                {
                    flag = false;
                }
                if (!flag)
                {
                    this.rdbNoCumple.Checked = true;
                    this.rdbCumple.Enabled = false;
                }
                else
                {
                    this.rdbCumple.Checked = true;
                    this.rdbCumple.Enabled = true;
                    this.rdbNoCumple.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                this.lblErrorAnalisis.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupAnalisisGM.Update();
                this.mpepopupAnalisisGM.Show();
            }
        }

        private void SetearTurno()
        {
            ServiceSoapClient serviceSoapClient;
            try
            {
                try
                {
                    serviceSoapClient = new ServiceSoapClient();
                    DataSet dataSet = new DataSet();
                    dataSet = serviceSoapClient.BuscarTurno(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Empresa, _Agencia);
                    if (dataSet.Tables[0].DefaultView.Count != 0)
                    {
                        this.lblNumTurno.Text = dataSet.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        this.lblmensaje.Text = "No se ha definido un Turno, No podra realizar Ninguna Operación en el Modulo";
                        this.upmensaje.Update();
                        this.mpemensaje.Show();
                        this.imbAnalisisGM.Enabled = false;
                        this.imbLastroInsumos.Enabled = false;
                        this.imbParticulares.Enabled = false;
                        this.imbGuardarLote.Enabled = false;
                        return;
                    }
                }
                catch (Exception exception)
                {
                    this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                }
            }
            finally
            {
                serviceSoapClient = null;
            }
        }

        private string StockActualEnSucursal(int _Grupo, int _Empresa, string _CodSubdeposito, string idnumarticulo, string _tanque)
        {
            string str;
            string str1 = "0";
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = (!this.fActivos_STOCKEABLES(_Empresa, this.BuscarARTID(_Empresa, idnumarticulo)) ? serviceSoapClient.ConsultarStockTanque(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _tanque) : serviceSoapClient.ConsultarStockSucursal(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Grupo, _Empresa, _CodSubdeposito, idnumarticulo));
                if (dataSet.Tables[0].DefaultView.Count <= 0)
                {
                    str1 = "0";
                }
                else
                {
                    str1 = (dataSet.Tables[0].Rows[0][0].ToString() == "0" ? "-1" : dataSet.Tables[0].Rows[0][0].ToString());
                }
                str = str1;
            }
            catch (Exception exception)
            {
                this.lblErrorComposicion.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupComposicion.Update();
                this.mpepopupComposicion.Show();
                str = str1;
            }
            return str;
        }

        protected void txtCantExtra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow parent = (GridViewRow)((DataControlFieldCell)((TextBox)sender).Parent).Parent;
                TextBox textBox = (TextBox)parent.FindControl("txtCantExtra");
                string text = textBox.Text;
                text = text.Replace("_", "");
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                if (text != "")
                {
                    num = Convert.ToInt32(text);
                    num1 = Convert.ToInt32(this.grdInsumos.Rows[parent.RowIndex].Cells[6].Text);
                    if (num != 0 && num1 > 0)
                    {
                        num2 = num + num1;
                        if (num2 >= 0)
                        {
                            this.grdInsumos.Rows[parent.RowIndex].Cells[8].Text = Convert.ToString(num2);
                        }
                        else
                        {
                            this.lblErrorPart.Text = "La cantidad extra no puede ser menor a la consumida!";
                            textBox.Text = "0";
                            this.grdInsumos.Rows[parent.RowIndex].Cells[8].Text = num1.ToString();
                            return;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.lblErrorComposicion.Text = clsConstantes.ManejoExcepciones(exception);
                this.upopupComposicion.Update();
                this.mpepopupComposicion.Show();
            }
        }

        protected void txtcilpart_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                double num4 = 0;
                double num5 = 0;
                double num6 = 0;
                double num7 = 0;
                double num8 = 0;
                foreach (GridViewRow row in this.grdDetCx.Rows)
                {
                    TextBox textBox = (TextBox)row.FindControl("txtcilpart");
                    num8 = Convert.ToDouble(this.grdDetCx.DataKeys[row.RowIndex].Values["CAPACIDAD"].ToString().Replace(".", ","));
                    textBox.Text = (textBox.Text == "" ? "0" : textBox.Text);
                    string text = textBox.Text;
                    text = text.Replace("_", "");
                    text = (text == "" ? "0" : text);
                    num1 += Convert.ToInt16(text);
                    num5 = num5 + (double)Convert.ToInt16(text) * num8;
                }
                this.lblSumCilPart.Text = Convert.ToString(num1);
                this.lblSumVolPar.Text = Convert.ToString(num5);
                num = Convert.ToInt16(this.lblSumCilPraxair.Text);
                num2 = Convert.ToInt16(this.lblSumCilSellos.Text);
                num3 = Convert.ToInt16(this.lblSumCilRechaz.Text);
                num4 = Convert.ToDouble(this.lbSumVolPrax.Text);
                num6 = Convert.ToDouble(this.lblSumVolSellos.Text);
                num7 = Convert.ToDouble(this.lblSumVolRechaz.Text);
                int num9 = num + num1 + num2 + num3;
                double num10 = num4 + num5 + num6 + num7;
                this.lblSumTotalCx.Text = Convert.ToString(num9);
                this.lblSumTotalVol.Text = Convert.ToString(num10);
                if (num1 <= 0)
                {
                    this.imbParticulares.Enabled = false;
                    this.lblCantTubos.Text = "0";
                }
                else
                {
                    this.imbParticulares.Enabled = true;
                    this.lblCantTubos.Text = Convert.ToString(num1);
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void txtcilpraxair_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                double num4 = 0;
                double num5 = 0;
                double num6 = 0;
                double num7 = 0;
                double num8 = 0;
                foreach (GridViewRow row in this.grdDetCx.Rows)
                {
                    TextBox textBox = (TextBox)row.FindControl("txtcilpraxair");
                    num8 = Convert.ToDouble(this.grdDetCx.DataKeys[row.RowIndex].Values["CAPACIDAD"].ToString().Replace(".", ","));
                    textBox.Text = (textBox.Text == "" ? "0" : textBox.Text);
                    string text = textBox.Text;
                    text = text.Replace("_", "");
                    text = (text == "" ? "0" : text);
                    num += Convert.ToInt16(text);
                    num4 = num4 + Convert.ToDouble(text) * num8;
                }
                this.lblSumCilPraxair.Text = Convert.ToString(num);
                this.lbSumVolPrax.Text = Convert.ToString(num4);
                num1 = Convert.ToInt16(this.lblSumCilPart.Text);
                num2 = Convert.ToInt16(this.lblSumCilSellos.Text);
                num3 = Convert.ToInt16(this.lblSumCilRechaz.Text);
                num5 = Convert.ToDouble(this.lblSumVolPar.Text);
                num6 = Convert.ToDouble(this.lblSumVolSellos.Text);
                num7 = Convert.ToDouble(this.lblSumVolRechaz.Text);
                int num9 = num + num1 + num2 + num3;
                double num10 = num4 + num5 + num6 + num7;
                this.lblSumTotalCx.Text = Convert.ToString(num9);
                this.lblSumTotalVol.Text = Convert.ToString(num10);
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void txtcilrechazo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                double num4 = 0;
                double num5 = 0;
                double num6 = 0;
                double num7 = 0;
                double num8 = 0;
                foreach (GridViewRow row in this.grdDetCx.Rows)
                {
                    TextBox textBox = (TextBox)row.FindControl("txtcilrechazo");
                    num8 = Convert.ToDouble(this.grdDetCx.DataKeys[row.RowIndex].Values["CAPACIDAD"].ToString().Replace(".", ","));
                    textBox.Text = (textBox.Text == "" ? "0" : textBox.Text);
                    string text = textBox.Text;
                    text = text.Replace("_", "");
                    text = (text == "" ? "0" : text);
                    num3 += Convert.ToInt16(text);
                    num7 = num7 + (double)Convert.ToInt16(text) * num8;
                }
                this.lblSumCilRechaz.Text = Convert.ToString(num3);
                this.lblSumVolRechaz.Text = Convert.ToString(num7);
                num = Convert.ToInt16(this.lblSumCilPraxair.Text);
                num1 = Convert.ToInt16(this.lblSumCilPart.Text);
                num2 = Convert.ToInt16(this.lblSumCilSellos.Text);
                num4 = Convert.ToDouble(this.lbSumVolPrax.Text);
                num5 = Convert.ToDouble(this.lblSumVolPar.Text);
                num6 = Convert.ToDouble(this.lblSumVolSellos.Text);
                int num9 = num + num1 + num2 + num3;
                double num10 = num4 + num5 + num6 + num7;
                this.lblSumTotalCx.Text = Convert.ToString(num9);
                this.lblSumTotalVol.Text = Convert.ToString(num10);
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void txtcilsellos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                double num4 = 0;
                double num5 = 0;
                double num6 = 0;
                double num7 = 0;
                double num8 = 0;
                foreach (GridViewRow row in this.grdDetCx.Rows)
                {
                    TextBox textBox = (TextBox)row.FindControl("txtcilsellos");
                    num8 = Convert.ToDouble(this.grdDetCx.DataKeys[row.RowIndex].Values["CAPACIDAD"].ToString().Replace(".", ","));
                    textBox.Text = (textBox.Text == "" ? "0" : textBox.Text);
                    string text = textBox.Text;
                    text = text.Replace("_", "");
                    text = (text == "" ? "0" : text);
                    num2 += Convert.ToInt16(text);
                    num6 = num6 + (double)Convert.ToInt16(text) * num8;
                }
                this.lblSumCilSellos.Text = Convert.ToString(num2);
                this.lblSumVolSellos.Text = Convert.ToString(num6);
                num = Convert.ToInt16(this.lblSumCilPraxair.Text);
                num1 = Convert.ToInt16(this.lblSumCilPart.Text);
                num3 = Convert.ToInt16(this.lblSumCilRechaz.Text);
                num4 = Convert.ToDouble(this.lbSumVolPrax.Text);
                num5 = Convert.ToDouble(this.lblSumVolPar.Text);
                num7 = Convert.ToDouble(this.lblSumVolRechaz.Text);
                int num9 = num + num1 + num2 + num3;
                double num10 = num4 + num5 + num6 + num7;
                this.lblSumTotalCx.Text = Convert.ToString(num9);
                this.lblSumTotalVol.Text = Convert.ToString(num10);
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void txtLegajo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtLegajo.Text != "")
                {
                    string text = this.txtLegajo.Text;
                    this.txtLegajo.Text = text.PadLeft(4, '0');
                    ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                    DataSet dataSet = new DataSet();
                    dataSet = serviceSoapClient.ConsNombreLegajo(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLegajo.Text);
                    if (dataSet.Tables[0].DefaultView.Count <= 0)
                    {
                        this.lblNomUsu.Text = "";
                    }
                    else
                    {
                        this.lblNomUsu.Text = dataSet.Tables[0].Rows[0][0].ToString();
                        this.txtContraseña.Enabled = true;
                    }
                }
            }
            catch (Exception exception)
            {
                this.lblerrLegajo.Text = clsConstantes.ManejoExcepciones(exception);
            }
        }

        protected void txtSecPart_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow parent = (GridViewRow)((DataControlFieldCell)((TextBox)sender).Parent).Parent;
                TextBox textBox = (TextBox)parent.FindControl("txtSecPart");
                string text = textBox.Text;
                text = text.Replace("_", "");
                int num = Convert.ToInt32(text);
                string str = Convert.ToString(this.cboGas.SelectedItem.Value);
                if (num > 0)
                {
                    if (this.ValidarSecuencia(text, parent.RowIndex))
                    {
                        ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                        DataSet dataSet = new DataSet();
                        dataSet = serviceSoapClient.ConsultaSecuencia(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), text);
                        if (dataSet.Tables[0].DefaultView.Count == 0)
                        {
                            this.lblErrorPart.Text = "El Nº de Secuencia ingresado no existe.";
                            textBox.Text = "";
                            return;
                        }
                        else if (str == dataSet.Tables[0].Rows[0][0].ToString())
                        {
                            dataSet = serviceSoapClient.ConsultaDatSecuencia(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), text, str);
                            if (dataSet.Tables[0].DefaultView.Count == 0)
                            {
                                this.lblErrorPart.Text = "El Nº de Secuencia ingresado no está disponible para carga.";
                                textBox.Text = "";
                                return;
                            }
                            else if (dataSet.Tables[0].Rows[0][2].ToString() == "B")
                            {
                                this.lblErrorPart.Text = "El Nº de Secuencia ingresado ha sido dado de baja.";
                                textBox.Text = "";
                                return;
                            }
                            else if (dataSet.Tables[0].Rows[0][3].ToString() != "L")
                            {
                                this.lblErrorPart.Text = "";
                                this.grvSecPart.Rows[parent.RowIndex].Cells[1].Text = dataSet.Tables[0].Rows[0][1].ToString();
                                this.grvSecPart.Rows[parent.RowIndex].Cells[2].Text = dataSet.Tables[0].Rows[0][2].ToString();
                                this.grvSecPart.Rows[parent.RowIndex].Cells[4].Text = dataSet.Tables[0].Rows[0][6].ToString();
                            }
                            else
                            {
                                this.lblErrorPart.Text = "El Nº de Secuencia corresponde a un cilindro lleno.";
                                textBox.Text = "";
                                return;
                            }
                        }
                        else
                        {
                            this.lblErrorPart.Text = "Este secuencia no corresponde al producto que trata de llenar";
                            textBox.Text = "";
                            return;
                        }
                    }
                    else
                    {
                        textBox.Text = "";
                    }
                }
            }
            catch (Exception exception)
            {
                this.lblErrorPart.Text = clsConstantes.ManejoExcepciones(exception);
            }
        }

        private bool UsuarioValido()
        {
            bool flag;
            bool flag1 = false;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.LegajoValido(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), "CARGA_PD", this.txtLegajo.Text, this.txtContraseña.Text);
                if (dataSet.Tables[0].DefaultView.Count > 0 && Convert.ToInt16(dataSet.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    flag1 = true;
                }
                flag = flag1;
            }
            catch (Exception exception)
            {
                this.lblerrLegajo.Text = clsConstantes.ManejoExcepciones(exception);
                flag = flag1;
            }
            return flag;
        }

        private bool ValidarSecuencia(string Secuencia, int fila)
        {
            bool flag;
            bool flag1 = true;
            try
            {
                foreach (GridViewRow row in this.grvSecPart.Rows)
                {
                    if (!(Secuencia == ((TextBox)row.FindControl("txtSecPart")).Text.Replace("_", "")) || row.RowIndex == fila)
                    {
                        continue;
                    }
                    this.lblErrorPart.Text = "La secuencia ya se encuentra registrada en la tabla.";
                    flag1 = false;
                    break;
                }
                flag = flag1;
            }
            catch (Exception exception)
            {
                this.lblErrorPart.Text = clsConstantes.ManejoExcepciones(exception);
                flag = flag1;
            }
            return flag;
        }
    }
}