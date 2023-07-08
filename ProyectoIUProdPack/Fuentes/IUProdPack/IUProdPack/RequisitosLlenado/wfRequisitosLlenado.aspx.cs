using AjaxControlToolkit;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using IUProdPack.WsProdPack;

namespace IUProdPack.RequisitosLlenado
{
    public partial class wfRequisitosLlenado : System.Web.UI.Page
    {
        public wfRequisitosLlenado()
        {
        }

        protected void AdicionarRespuesta_Click(object sender, ImageClickEventArgs e)
        {
            this.gIdRespuesta.Value = "";
            this.lblCrear3.Text = "Opciones de respuesta";
            this.upPaso2.Update();
            this.PopUpPaso2.Hide();
            string selectedValue = this.TipoRespuestaDet.SelectedValue;
            string str = selectedValue;
            if (selectedValue != null)
            {
                if (str == "1")
                {
                    this.pnlCheck.Visible = true;
                    this.pnlCombo.Visible = false;
                    this.pnlTexo.Visible = false;
                    goto Label0;
                }
                else if (str == "2")
                {
                    this.pnlCheck.Visible = false;
                    this.pnlCombo.Visible = true;
                    this.pnlTexo.Visible = false;
                    goto Label0;
                }
                else
                {
                    if (str != "3")
                    {
                        goto Label4;
                    }
                    this.pnlCheck.Visible = false;
                    this.pnlCombo.Visible = false;
                    this.pnlTexo.Visible = true;
                    goto Label0;
                }
            }
        Label4:
            this.pnlCheck.Visible = true;
            this.pnlCombo.Visible = false;
            this.pnlTexo.Visible = false;
        Label0:
            if (this.gIdRespuesta.Value == "")
            {
                this.CheckDefecto.Checked = false;
                this.ComboValores.Text = "";
                this.ComboDefecto.Text = "";
                this.CheckMinimo.Text = "";
                this.CheckMaximo.Text = "";
            }
            else
            {
                string selectedValue1 = this.TipoRespuestaDet.SelectedValue;
                string str1 = selectedValue1;
                if (selectedValue1 != null)
                {
                    if (str1 == "1")
                    {
                        this.pnlCheck.Enabled = false;
                        if (this.gDefectoRespuesta.Value == "1")
                        {
                            this.CheckDefecto.Checked = true;
                            this.upPaso3.Update();
                            this.PopUpPaso3.Show();
                            return;
                        }
                        else
                        {
                            this.upPaso3.Update();
                            this.PopUpPaso3.Show();
                            return;
                        }
                    }
                    else if (str1 == "2")
                    {
                        this.pnlCombo.Enabled = false;
                        this.ComboValores.Text = this.gValoresRespuesta.Value;
                        this.ComboDefecto.Text = this.gDefectoRespuesta.Value;
                        this.upPaso3.Update();
                        this.PopUpPaso3.Show();
                        return;
                    }
                    else
                    {
                        if (str1 != "3")
                        {
                            goto Label5;
                        }
                        this.pnlTexo.Enabled = false;
                        this.CheckMinimo.Text = this.gValoresRespuesta.Value.Substring(0, 1);
                        this.CheckMaximo.Text = this.gValoresRespuesta.Value.Substring(2);
                        this.upPaso3.Update();
                        this.PopUpPaso3.Show();
                        return;
                    }
                }
            Label5:
                this.pnlCheck.Enabled = false;
            }
            this.upPaso3.Update();
            this.PopUpPaso3.Show();
        }

        protected void btnFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            int num = Convert.ToInt16(this.cmbActivo.SelectedValue);
            int num1 = Convert.ToInt16(this.cmbTipo.SelectedValue);
            this.CargarGrillaRequisitos(num, num1, this.txtDescripcion.Text);
        }

        protected void btnokmensaje_Click(object sender, ImageClickEventArgs e)
        {
            this.mpemensaje.Hide();
        }

        protected void btnTodos_Click(object sender, ImageClickEventArgs e)
        {
            this.CargarGrillaRequisitos(0, 0, "");
            this.CargarCombos();
            this.txtDescripcion.Text = "";
        }

        protected void CargarCombos()
        {
            ServiceSoapClient serviceSoapClient;
            clsGenerales clsGenerale;
            try
            {
                try
                {
                    serviceSoapClient = new ServiceSoapClient();
                    clsGenerale = new clsGenerales();
                    DataSet dataSet = new DataSet();
                    dataSet = serviceSoapClient.GET_TIPO_REQ(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString());
                    clsGenerale.cargarCombos(dataSet, this.Tipo, "DESCRIPCION", "CODIGO", "");
                    clsGenerale.cargarCombos(dataSet, this.cmbTipo, "DESCRIPCION", "CODIGO", "");
                    dataSet = serviceSoapClient.GET_TIPO_ACTIVO(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString());
                    clsGenerale.cargarCombos(dataSet, this.Activo, "DESCRIPCION", "ID_TIPO", "");
                    clsGenerale.cargarCombos(dataSet, this.cmbActivo, "DESCRIPCION", "ID_TIPO", "");
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
            finally
            {
                clsGenerale = null;
                serviceSoapClient = null;
            }
        }

        protected void CargarComboValidacion(int idRequisito)
        {
            try
            {
                this.Validaciones.Items.Clear();
                ListItem listItem = new ListItem()
                {
                    Text = "...",
                    Value = "..."
                };
                this.Validaciones.Items.Add(listItem);
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_DET_REQ_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), idRequisito);
                (new clsGenerales()).cargarCombos(dataSet, this.Validaciones, "DESCRIPCION", "ID_DETALLE", "");
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void CargarGrillaRequisitos(int p_Tipo_Activo, int p_Tipo_Requisito, string p_Descripcion)
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_REQ_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), p_Tipo_Activo, p_Tipo_Requisito, p_Descripcion);
                this.grdResumen.DataSource = dataSet.Tables[0];
                this.grdResumen.DataBind();
                this.upResumen.Update();
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
            if (e.CommandName == "Actualiza")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                this.gIdRespuesta.Value = this.grdRespuestas.DataKeys[num].Values["ID_RESPUESTA"].ToString();
                this.gValoresRespuesta.Value = this.grdRespuestas.DataKeys[num].Values["VALORES"].ToString();
                this.gDefectoRespuesta.Value = this.grdRespuestas.DataKeys[num].Values["VALOR_DEFECTO"].ToString();
                this.gTipoRespuesta.Value = this.grdRespuestas.DataKeys[num].Values["TIPO_RESPUESTA"].ToString();
                this.TipoRespuestaDet.SelectedValue = this.gTipoRespuesta.Value;
                this.snNuevaRespuesta.Value = "N";
                this.upPaso2.Update();
                this.PopUpPasoRespuestas.Hide();
                this.PopUpPaso2.Show();
            }
        }

        protected void grdResumen_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualiza")
            {
                this.snInserta.Value = "N";
                int num = Convert.ToInt32(e.CommandArgument);
                this.ID_REQUISITO.Value = this.grdResumen.DataKeys[num].Values["ID_REQUISITO"].ToString();
                this.lblCrear.Text = string.Concat("Modificar Requisito número: ", this.ID_REQUISITO.Value);
                this.Descripcion.Text = this.grdResumen.Rows[num].Cells[1].Text;
                this.Tipo.SelectedValue = this.grdResumen.DataKeys[num].Values["TIPO_REQUISITO"].ToString();
                this.Activo.SelectedValue = this.grdResumen.DataKeys[num].Values["TIPO_ACTIVO"].ToString();
                this.Estado.SelectedValue = this.grdResumen.DataKeys[num].Values["ESTADO"].ToString();
                this.Validaciones.Visible = true;
                this.lblValidaciones.Visible = true;
                this.CargarComboValidacion(Convert.ToInt32(this.ID_REQUISITO.Value));
                this.nuevaValidacion.Visible = true;
                this.upPaso1.Update();
                this.PopUpPaso1.Show();
            }
        }

        protected void imbCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.OcultarPantallas();
        }

        protected void imbCancelarRespuestas_Click(object sender, ImageClickEventArgs e)
        {
            this.gIdRespuesta.Value = "";
            this.upPaso2.Update();
            this.PopUpPasoRespuestas.Hide();
            this.PopUpPaso2.Show();
        }

        protected void imbConsultarRespuestas_Click(object sender, ImageClickEventArgs e)
        {
            this.CargarGrillaRespuestas();
            this.upRespuestas.Update();
            this.upPaso2.Update();
            this.PopUpPasoRespuestas.Show();
            this.PopUpPaso2.Hide();
        }

        protected void imbGuardar_Click(object sender, ImageClickEventArgs e)
        {
            string selectedValue;
            string value;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                string str = "0";
                if (this.snInserta.Value != "S")
                {
                    value = this.ID_REQUISITO.Value;
                    serviceSoapClient.UPDATE_REQ_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.Descripcion.Text, Convert.ToInt32(this.Tipo.SelectedValue), Convert.ToInt32(this.Activo.SelectedValue), Convert.ToInt32(this.Estado.SelectedValue), Convert.ToInt32(this.PreguntasHoja.Text), Convert.ToInt32(this.ID_REQUISITO.Value));
                    if (this.snNuevaValidacion.Value != "S")
                    {
                        selectedValue = this.Validaciones.SelectedValue;
                        str = "0";
                        if (this.gIdRespuesta.Value != "")
                        {
                            str = this.gIdRespuesta.Value;
                        }
                        else
                        {
                            string selectedValue1 = this.TipoRespuestaDet.SelectedValue;
                            string str1 = selectedValue1;
                            if (selectedValue1 != null)
                            {
                                if (str1 == "1")
                                {
                                    string str2 = "0";
                                    if (this.CheckDefecto.Checked)
                                    {
                                        str2 = "1";
                                    }
                                    str = serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 1, "", str2);
                                }
                                else if (str1 == "2")
                                {
                                    str = serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 2, this.ComboValores.Text, this.ComboDefecto.Text);
                                }
                                else if (str1 == "3")
                                {
                                    str = serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 3, string.Concat(this.CheckMinimo.Text, ",", this.CheckMaximo.Text), "");
                                }
                            }
                        }
                        serviceSoapClient.UPDATE_DET_REQ_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(value), this.DescripcionDet.Text, Convert.ToInt32(this.ObligatoriaDet.SelectedValue), Convert.ToInt32(str), Convert.ToInt32(this.OrdenDet.Text), Convert.ToInt32(this.EstadoDet.Text), Convert.ToInt32(selectedValue));
                    }
                    else
                    {
                        str = "0";
                        if (this.gIdRespuesta.Value != "")
                        {
                            str = this.gIdRespuesta.Value;
                        }
                        else
                        {
                            string selectedValue2 = this.TipoRespuestaDet.SelectedValue;
                            string str3 = selectedValue2;
                            if (selectedValue2 != null)
                            {
                                if (str3 == "1")
                                {
                                    string str4 = "0";
                                    if (this.CheckDefecto.Checked)
                                    {
                                        str4 = "1";
                                    }
                                    str = serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 1, "", str4);
                                }
                                else if (str3 == "2")
                                {
                                    str = serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 2, this.ComboValores.Text, this.ComboDefecto.Text);
                                }
                                else if (str3 == "3")
                                {
                                    str = serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 3, string.Concat(this.CheckMinimo.Text, ",", this.CheckMaximo.Text), "");
                                }
                            }
                        }
                        selectedValue = serviceSoapClient.INSERT_DET_REQ_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(value), this.DescripcionDet.Text, Convert.ToInt32(this.ObligatoriaDet.SelectedValue), Convert.ToInt32(str), Convert.ToInt32(this.OrdenDet.Text), Convert.ToInt32(this.EstadoDet.Text));
                    }
                }
                else
                {
                    value = serviceSoapClient.INSERT_REQ_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.Descripcion.Text, Convert.ToInt32(this.Tipo.SelectedValue), Convert.ToInt32(this.Activo.SelectedValue), Convert.ToInt32(this.Estado.SelectedValue), Convert.ToInt32(this.PreguntasHoja.Text));
                    if (this.gIdRespuesta.Value != "")
                    {
                        str = this.gIdRespuesta.Value;
                    }
                    else
                    {
                        string selectedValue3 = this.TipoRespuestaDet.SelectedValue;
                        string str5 = selectedValue3;
                        if (selectedValue3 != null)
                        {
                            if (str5 == "1")
                            {
                                string str6 = "0";
                                if (this.CheckDefecto.Checked)
                                {
                                    str6 = "1";
                                }
                                str = serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 1, "", str6);
                            }
                            else if (str5 == "2")
                            {
                                str = serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 2, this.ComboValores.Text, this.ComboDefecto.Text);
                            }
                            else if (str5 == "3")
                            {
                                str = serviceSoapClient.INSERT_RES_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), 3, string.Concat(this.CheckMinimo.Text, ",", this.CheckMaximo.Text), "");
                            }
                        }
                    }
                    selectedValue = serviceSoapClient.INSERT_DET_REQ_LLEN(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(value), this.DescripcionDet.Text, Convert.ToInt32(this.ObligatoriaDet.SelectedValue), Convert.ToInt32(str), Convert.ToInt32(this.OrdenDet.Text), Convert.ToInt32(this.EstadoDet.Text));
                }
                this.lblmensaje.Text = "Grabación exitosa.";
                this.upmensaje.Update();
                this.mpemensaje.Show();
                this.OcultarPantallas();
                this.CargarGrillaRequisitos(0, 0, "");
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void IniciaGrabacion_Click(object sender, ImageClickEventArgs e)
        {
            this.snInserta.Value = "S";
            this.snNuevaValidacion.Value = "S";
            this.snNuevaRespuesta.Value = "S";
            this.lblCrear.Text = "1.Datos del requisito";
            this.Validaciones.Visible = false;
            this.lblValidaciones.Visible = false;
            this.Validaciones.SelectedValue = "...";
            this.nuevaValidacion.Visible = false;
            this.nuevaRespuesta.Visible = false;
            this.Descripcion.Text = "";
            this.Tipo.SelectedValue = "...";
            this.Activo.SelectedValue = "...";
            this.Estado.SelectedValue = "...";
            this.PreguntasHoja.Text = "";
            this.DescripcionDet.Text = "";
            this.ObligatoriaDet.SelectedValue = "...";
            this.OrdenDet.Text = "";
            this.EstadoDet.SelectedValue = "...";
            this.TipoRespuestaDet.SelectedValue = "...";
            this.upResumen.Update();
            this.upPaso1.Update();
            this.PopUpPaso1.Show();
        }

        protected void InicializarRespuesta()
        {
            this.pnlCheck.Enabled = true;
            this.pnlCombo.Enabled = true;
            this.pnlTexo.Enabled = true;
            this.ComboValores.Text = "";
            this.ComboDefecto.Text = "";
            this.CheckMinimo.Text = "";
            this.CheckMaximo.Text = "";
        }

        protected void IniciaValidacion()
        {
            try
            {
                this.DescripcionDet.Text = "";
                this.ObligatoriaDet.SelectedValue = "...";
                this.OrdenDet.Text = "";
                this.EstadoDet.SelectedValue = "...";
                this.gIdRespuesta.Value = "";
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void irPaso2_Click(object sender, ImageClickEventArgs e)
        {
            string str = this.ValidaPaso1();
            if (str != "")
            {
                this.lblmensaje.Text = str;
                this.upmensaje.Update();
                this.mpemensaje.Show();
                return;
            }
            this.lblCrear2.Text = "2.Datos de la validación";
            if (!this.Validaciones.Visible)
            {
                this.snNuevaValidacion.Value = "S";
                this.gIdRespuesta.Value = "";
                this.IniciaValidacion();
                this.nuevaRespuesta.Visible = false;
                this.imbConsultarRespuestas.Visible = true;
            }
            else
            {
                if (this.Validaciones.SelectedValue == "...")
                {
                    this.lblmensaje.Text = "Por favor seleccione la validacion del requisito para continuar.";
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                    return;
                }
                this.snNuevaValidacion.Value = "N";
                this.RecuperaValidacion();
                this.gIdRespuesta.Value = "";
                this.nuevaRespuesta.Visible = true;
                this.imbConsultarRespuestas.Visible = true;
            }
            this.upPaso1.Update();
            this.upPaso2.Update();
            this.PopUpPaso1.Hide();
            this.PopUpPaso2.Show();
        }

        protected void irPaso3_Click(object sender, ImageClickEventArgs e)
        {
            string str = this.ValidaPaso2();
            if (str != "")
            {
                this.lblmensaje.Text = str;
                this.upmensaje.Update();
                this.mpemensaje.Show();
                return;
            }
            this.lblCrear3.Text = "Opciones de respuesta";
            this.upPaso2.Update();
            this.PopUpPaso2.Hide();
            string selectedValue = this.TipoRespuestaDet.SelectedValue;
            string str1 = selectedValue;
            if (selectedValue != null)
            {
                if (str1 == "1")
                {
                    this.pnlCheck.Visible = true;
                    this.pnlCombo.Visible = false;
                    this.pnlTexo.Visible = false;
                    goto Label0;
                }
                else if (str1 == "2")
                {
                    this.pnlCheck.Visible = false;
                    this.pnlCombo.Visible = true;
                    this.pnlTexo.Visible = false;
                    goto Label0;
                }
                else
                {
                    if (str1 != "3")
                    {
                        goto Label4;
                    }
                    this.pnlCheck.Visible = false;
                    this.pnlCombo.Visible = false;
                    this.pnlTexo.Visible = true;
                    goto Label0;
                }
            }
        Label4:
            this.pnlCheck.Visible = true;
            this.pnlCombo.Visible = false;
            this.pnlTexo.Visible = false;
        Label0:
            if (this.gIdRespuesta.Value == "")
            {
                this.snNuevaRespuesta.Value = "S";
                this.CheckDefecto.Checked = false;
                this.ComboValores.Text = "";
                this.ComboDefecto.Text = "";
                this.CheckMinimo.Text = "";
                this.CheckMaximo.Text = "";
            }
            else
            {
                this.snNuevaRespuesta.Value = "N";
                string selectedValue1 = this.TipoRespuestaDet.SelectedValue;
                string str2 = selectedValue1;
                if (selectedValue1 != null)
                {
                    if (str2 == "1")
                    {
                        this.pnlCheck.Enabled = false;
                        if (this.gDefectoRespuesta.Value == "1")
                        {
                            this.CheckDefecto.Checked = true;
                            this.upPaso3.Update();
                            this.PopUpPaso3.Show();
                            return;
                        }
                        else
                        {
                            this.upPaso3.Update();
                            this.PopUpPaso3.Show();
                            return;
                        }
                    }
                    else if (str2 == "2")
                    {
                        this.pnlCombo.Enabled = false;
                        this.ComboValores.Text = this.gValoresRespuesta.Value;
                        this.ComboDefecto.Text = this.gDefectoRespuesta.Value;
                        this.upPaso3.Update();
                        this.PopUpPaso3.Show();
                        return;
                    }
                    else
                    {
                        if (str2 != "3")
                        {
                            goto Label5;
                        }
                        this.pnlTexo.Enabled = false;
                        this.CheckMinimo.Text = this.gValoresRespuesta.Value.Substring(0, 1);
                        this.CheckMaximo.Text = this.gValoresRespuesta.Value.Substring(2);
                        this.upPaso3.Update();
                        this.PopUpPaso3.Show();
                        return;
                    }
                }
            Label5:
                this.pnlCheck.Enabled = false;
            }
            this.upPaso3.Update();
            this.PopUpPaso3.Show();
        }

        protected void irPaso4_Click(object sender, ImageClickEventArgs e)
        {
            string str = this.ValidaPaso3();
            if (str != "")
            {
                this.lblmensaje.Text = str;
                this.upmensaje.Update();
                this.mpemensaje.Show();
                return;
            }
            this.upPaso3.Update();
            this.ResumenFinal.Text = this.RecuperaResumen();
            this.upPaso4.Update();
            this.PopUpPaso3.Hide();
            this.PopUpPaso4.Show();
        }

        protected void nuevaPregunta_Click(object sender, ImageClickEventArgs e)
        {
            if (this.TipoRespuestaDet.SelectedValue == "...")
            {
                this.lblmensaje.Text = "Por favor seleccione el tipo de respuesta para realizar la creación.";
                this.upmensaje.Update();
                this.mpemensaje.Show();
                return;
            }
            this.gIdRespuesta.Value = "";
            this.lblCrear3.Text = "Opciones de respuesta";
            this.snNuevaRespuesta.Value = "S";
            this.InicializarRespuesta();
            this.upPaso2.Update();
            this.PopUpPaso2.Hide();
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

        protected void nuevaValidacion_Click(object sender, ImageClickEventArgs e)
        {
            string str = this.ValidaPaso1();
            if (str != "")
            {
                this.lblmensaje.Text = str;
                this.upmensaje.Update();
                this.mpemensaje.Show();
                return;
            }
            this.lblCrear2.Text = "2.Datos de la validación";
            this.snNuevaValidacion.Value = "S";
            this.snNuevaRespuesta.Value = "S";
            this.gIdRespuesta.Value = "";
            this.DescripcionDet.Text = "";
            this.ObligatoriaDet.SelectedValue = "...";
            this.OrdenDet.Text = "";
            this.EstadoDet.SelectedValue = "...";
            this.TipoRespuestaDet.SelectedValue = "...";
            this.nuevaRespuesta.Visible = false;
            this.pnlCheck.Enabled = true;
            this.pnlCombo.Enabled = true;
            this.pnlTexo.Enabled = true;
            this.upPaso1.Update();
            this.upPaso2.Update();
            this.PopUpPaso1.Hide();
            this.PopUpPaso2.Show();
        }

        protected void OcultarPantallas()
        {
            this.PopUpPaso1.Hide();
            this.PopUpPaso2.Hide();
            this.PopUpPaso3.Hide();
            this.PopUpPaso4.Hide();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((new ClsGeneral()).tienePermiso(this.Session["idusuario"].ToString(), "PP_REQUISITOS").Equals("0"))
            {
                base.Response.Redirect("../inicio/default.aspx");
            }
            if (!base.IsPostBack)
            {
                this.CargarGrillaRequisitos(0, 0, "");
                this.CargarCombos();
            }
        }

        protected void RecuperaRespuesta()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_RES_LLEN_BYID(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.gIdRespuesta.Value));
                DataRow item = dataSet.Tables[0].Rows[0];
                this.TipoRespuestaDet.SelectedValue = item.ItemArray[1].ToString();
                string value = this.gIdRespuesta.Value;
                string str = value;
                if (value == null)
                {
                    this.pnlCheck.Enabled = false;
                    return;
                }
                else if (str == "1")
                {
                    this.pnlCheck.Enabled = false;
                    if (item.ItemArray[3].ToString() == "1")
                    {
                        this.CheckDefecto.Checked = true;
                    }
                }
                else if (str == "2")
                {
                    this.pnlCombo.Enabled = false;
                    this.ComboValores.Text = item.ItemArray[2].ToString();
                    this.ComboDefecto.Text = item.ItemArray[3].ToString();
                }
                else
                {
                    if (str != "3")
                    {
                        this.pnlCheck.Enabled = false;
                        return;
                    }
                    this.pnlTexo.Enabled = false;
                    char[] chrArray = new char[] { ',' };
                    string[] strArrays = item.ItemArray[2].ToString().Split(chrArray);
                    this.CheckMinimo.Text = strArrays[0];
                    this.CheckMaximo.Text = strArrays[1];
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected string RecuperaResumen()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("*** INFORMARCION DEL REQUISITO ***");
            stringBuilder.AppendLine(string.Concat("Requisito: ", this.Descripcion.Text));
            stringBuilder.AppendLine(string.Concat("Tipo de requisito: ", this.Tipo.SelectedItem.Text));
            stringBuilder.AppendLine(string.Concat("Tipo de activo: ", this.Activo.SelectedItem.Text));
            stringBuilder.AppendLine(string.Concat("Estado: ", this.Estado.SelectedItem.Text));
            stringBuilder.AppendLine(string.Concat("Preguntas por pantalla: ", this.PreguntasHoja.Text));
            stringBuilder.AppendLine("*** INFORMACION DE LA VALIDACION ***");
            stringBuilder.AppendLine(string.Concat("Validación: ", this.DescripcionDet.Text));
            stringBuilder.AppendLine(string.Concat("Obligatoria: ", this.ObligatoriaDet.SelectedItem.Text));
            stringBuilder.AppendLine(string.Concat("Orden: ", this.OrdenDet.Text));
            stringBuilder.AppendLine(string.Concat("Estado: ", this.EstadoDet.SelectedItem.Text));
            stringBuilder.AppendLine("*** INFORMARCION DE LA RESPUESTA ***");
            stringBuilder.AppendLine(string.Concat("Tipo de respuesta: ", this.TipoRespuestaDet.SelectedItem.Text));
            string selectedValue = this.TipoRespuestaDet.SelectedValue;
            string str = selectedValue;
            if (selectedValue != null)
            {
                if (str == "1")
                {
                    if (!this.CheckDefecto.Checked)
                    {
                        stringBuilder.AppendLine("Valor por defecto: Desmarcado");
                    }
                    else
                    {
                        stringBuilder.AppendLine("Valor por defecto: Marcado");
                    }
                }
                else if (str == "2")
                {
                    stringBuilder.AppendLine(string.Concat("Listado de valores: ", this.ComboValores.Text));
                    stringBuilder.AppendLine(string.Concat("Valor por defecto: ", this.ComboDefecto.Text));
                }
                else if (str == "3")
                {
                    stringBuilder.AppendLine(string.Concat("Valor mínimo: ", this.CheckMinimo.Text));
                    stringBuilder.AppendLine(string.Concat("Valor máximo: ", this.CheckMaximo.Text));
                }
            }
            return stringBuilder.ToString();
        }

        protected void RecuperaValidacion()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                dataSet = serviceSoapClient.GET_DET_REQ_LLEN_BYID(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.Validaciones.SelectedValue));
                DataRow item = dataSet.Tables[0].Rows[0];
                this.DescripcionDet.Text = item.ItemArray[2].ToString();
                this.ObligatoriaDet.SelectedValue = item.ItemArray[3].ToString();
                this.OrdenDet.Text = item.ItemArray[5].ToString();
                this.EstadoDet.SelectedValue = item.ItemArray[6].ToString();
                this.gIdRespuesta.Value = item.ItemArray[4].ToString();
                this.RecuperaRespuesta();
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Activo.Items.Clear();
            ListItem listItem = new ListItem()
            {
                Text = "...",
                Value = "..."
            };
            this.Activo.Items.Add(listItem);
            ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
            DataSet dataSet = new DataSet();
            clsGenerales clsGenerale = new clsGenerales();
            dataSet = serviceSoapClient.GET_TIPO_ACTIVO_HAB(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), Convert.ToInt32(this.Tipo.SelectedValue));
            clsGenerale.cargarCombos(dataSet, this.Activo, "DESCRIPCION", "ID_TIPO", "");
        }

        protected string ValidaPaso1()
        {
            string str = "";
            if (this.Descripcion.Text == "")
            {
                str = string.Concat(str, "Descripción no ingresada.<br />", Environment.NewLine);
            }
            if (this.Tipo.SelectedValue == "...")
            {
                str = string.Concat(str, "Tipo de requisito no ingresado.", Environment.NewLine);
            }
            if (this.Activo.SelectedValue == "...")
            {
                str = string.Concat(str, "Tipo de activo no ingresado.", Environment.NewLine);
            }
            if (this.Estado.SelectedValue == "...")
            {
                str = string.Concat(str, "Estado no ingresado.", Environment.NewLine);
            }
            if (this.PreguntasHoja.Text == "")
            {
                str = string.Concat(str, "Preguntas por hoja no ingresado.", Environment.NewLine);
            }
            return str;
        }

        protected string ValidaPaso2()
        {
            string str = "";
            if (this.DescripcionDet.Text == "")
            {
                str = string.Concat(str, "Descripción no ingresada.\n", Environment.NewLine);
            }
            if (this.ObligatoriaDet.SelectedValue == "...")
            {
                str = string.Concat(str, "Obligatoriedad no ingresada.", Environment.NewLine);
            }
            if (this.OrdenDet.Text == "")
            {
                str = string.Concat(str, "Orden no ingresado.", Environment.NewLine);
            }
            if (this.EstadoDet.SelectedValue == "...")
            {
                str = string.Concat(str, "Estado no ingresado.", Environment.NewLine);
            }
            if (this.TipoRespuestaDet.SelectedValue == "..." && this.gIdRespuesta.Value == "")
            {
                str = string.Concat(str, "Tipo de respuesta no ingresada.", Environment.NewLine);
            }
            if (this.TipoRespuestaDet.SelectedValue != this.gTipoRespuesta.Value && this.gIdRespuesta.Value != "")
            {
                str = string.Concat(str, "Tipo de respuesta debe ser igual a la seleccionada en la consulta de respuestas.", Environment.NewLine);
            }
            return str;
        }

        protected string ValidaPaso3()
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
                    else
                    {
                        if (Convert.ToInt32(this.CheckMinimo.Text) > Convert.ToInt32(this.CheckMaximo.Text))
                        {
                            str = string.Concat(str, "El valor minimo no puede superar al máximo.\n", Environment.NewLine);
                        }
                        if (Convert.ToInt32(this.CheckMaximo.Text) > 100)
                        {
                            str = string.Concat(str, "El valor máximo no puede superar 100 caracteres.\n", Environment.NewLine);
                        }
                    }
                }
            }
            return str;
        }

        protected void volverPaso1_Click(object sender, ImageClickEventArgs e)
        {
            this.upPaso2.Update();
            this.PopUpPaso1.Show();
            this.PopUpPaso2.Hide();
        }

        protected void volverPaso2_Click(object sender, ImageClickEventArgs e)
        {
            this.upPaso3.Update();
            this.PopUpPaso2.Show();
            this.PopUpPaso3.Hide();
        }

        protected void volverPaso3_Click(object sender, ImageClickEventArgs e)
        {
            this.PopUpPaso3.Show();
            this.PopUpPaso4.Hide();
        }
    }
}