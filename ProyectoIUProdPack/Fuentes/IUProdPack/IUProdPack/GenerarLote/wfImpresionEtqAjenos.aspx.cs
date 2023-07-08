using AjaxControlToolkit;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using IUProdPack.WsProdPack;
using Image = iTextSharp.text.Image;

namespace IUProdPack.GenerarLote
{
    public partial class wfImpresionEtqAjenos : System.Web.UI.Page
    {
        public static int Empresa;

        public static int Agencia;

        public static int Grupo;

        public static string CodLegajo;

        public static int Length;

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

        public static int _Length
        {
            get
            {
                return Length;
            }
            set
            {
                Length = value;
            }
        }

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public wfImpresionEtqAjenos()
        {
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

        public bool EsPar(int numero)
        {
            if (numero % 2 == 0)
            {
                return true;
            }
            return false;
        }

        private bool ExisteCilindro()
        {
            bool flag;
            bool flag1 = false;
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                if (serviceSoapClient.ConsExisteCx(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text, this.txtNumCx.Text).Tables[0].DefaultView.Count > 0)
                {
                    flag1 = true;
                }
                flag = flag1;
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
                    this.Imprimir();
                }
                else
                {
                    this.lblerrLegajo.Text = "Usuario no habilitado para esta aplicación";
                }
            }
            catch (Exception exception)
            {
                this.lblerrLegajo.Text = clsConstantes.ManejoExcepciones(exception);
            }
        }

        protected void imbCancelar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.txtLote.Text = "";
                this.rdbEtiquetaCx.Checked = false;
                this.rdbTodas.Checked = true;
                this.txtNumCx.Text = "";
                this.txtNumCx.Enabled = false;
                this.txtNumCx.Visible = false;
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void imbImprimir_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (this.txtLote.Text != "")
                {
                    if (this.rdbEtiquetaCx.Checked)
                    {
                        if (this.txtNumCx.Text != "")
                        {
                            string text = this.txtNumCx.Text;
                            this.txtNumCx.Text = text.PadLeft(_Length, '0');
                            if (!this.ExisteCilindro())
                            {
                                this.lblmensaje.Text = "El código de Cilindro no existe.";
                                this.upmensaje.Update();
                                this.mpemensaje.Show();
                                return;
                            }
                        }
                        else
                        {
                            this.lblmensaje.Text = "Debe ingresar un Nº de Cilindro.";
                            this.upmensaje.Update();
                            this.mpemensaje.Show();
                            return;
                        }
                    }
                    this.txtLegajo.Text = "";
                    this.txtContraseña.Text = "";
                    this.txtContraseña.Enabled = false;
                    this.lblNomUsu.Text = "";
                    this.upopupLegajo.Update();
                    this.mpepopupLegajo.Show();
                }
                else
                {
                    this.lblmensaje.Text = "Por favor digite el No. de Lote";
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

        private void Imprimir()
        {
            try
            {
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                DataSet dataSet = new DataSet();
                string text = this.txtLote.Text;
                text = text.Replace("/", "-");
                int count = 0;
                string str = "";
                if (!this.rdbTodas.Checked)
                {
                    dataSet = serviceSoapClient.ConsEtiquetaAjenoCx(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text, this.txtNumCx.Text);
                    str = string.Concat("EtiquetasCxAjeno", Convert.ToString(this.txtNumCx.Text));
                }
                else
                {
                    dataSet = serviceSoapClient.ConsEtiquetasAjenos(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text);
                    str = string.Concat("EtiquetasLoteAjeno", text);
                }
                if (dataSet.Tables[0].DefaultView.Count <= 0)
                {
                    this.lblmensaje.Text = "No se encontraron Datos";
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                }
                else
                {
                    count = dataSet.Tables[0].DefaultView.Count;
                    Rectangle rectangle = new Rectangle(1095f, 1100f);
                    Document document = new Document(rectangle, 3f, 2f, 1f, 2f);
                    PdfWriter instance = PdfWriter.GetInstance(document, new FileStream(base.Server.MapPath(string.Concat("\\IUProdPack\\Etiquetas\\", str, ".pdf")), FileMode.OpenOrCreate));
                    document.Open();
                    PdfContentByte directContent = instance.DirectContent;
                    Barcode128 barcode128 = new Barcode128()
                    {
                        CodeType = 10
                    };
                    int num = 0;
                    PdfPTable pdfPTable = new PdfPTable(1);
                    pdfPTable.DefaultCell.Border = 0;
                    pdfPTable.HorizontalAlignment = 0;
                    float[] singleArray = new float[] { 1522f };
                    pdfPTable.SetWidths(singleArray);
                    pdfPTable.SetTotalWidth(new float[] { 1522f });
                    PdfPCell pdfPCell = new PdfPCell(pdfPTable)
                    {
                        Border = 0,
                        HorizontalAlignment = 0,
                        VerticalAlignment = 0,
                        PaddingLeft = 0f,
                        PaddingTop = 0f
                    };
                    PdfPTable pdfPTable1 = new PdfPTable(1);
                    pdfPTable1.DefaultCell.Border = 0;
                    pdfPTable1.SetWidths(new float[] { 2400f });
                    pdfPTable1.SetTotalWidth(new float[] { 2400f });
                    PdfPCell pdfPCell1 = new PdfPCell(pdfPTable1)
                    {
                        Border = 0,
                        VerticalAlignment = 0,
                        PaddingLeft = 195f,
                        PaddingTop = 0f,
                        PaddingRight = 0f
                    };
                    int num1 = 0;
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        num = 0;
                        num1++;
                        Font font = new Font(Font.FontFamily.HELVETICA , 28f, 1);
                        Font font1 = new Font(Font.FontFamily.HELVETICA, 18f, 0);
                        PdfPCell pdfPCell2 = new PdfPCell(new Phrase(Convert.ToString(row["TITULO"]), font))
                        {
                            HorizontalAlignment = 1,
                            Border = 0,
                            VerticalAlignment = 0
                        };
                        PdfPCell pdfPCell3 = new PdfPCell(new Phrase(Convert.ToString(row["CLIENTE"]), font1))
                        {
                            HorizontalAlignment = 0,
                            NoWrap = true,
                            Border = 0,
                            VerticalAlignment = 0
                        };
                        PdfPCell[] pdfPCellArray = new PdfPCell[] { new PdfPCell(pdfPCell3) };
                        PdfPRow pdfPRow = new PdfPRow(pdfPCellArray);
                        PdfPCell pdfPCell4 = new PdfPCell(new Phrase(Convert.ToString(row["TUBO"]), font))
                        {
                            HorizontalAlignment = 1,
                            Border = 0,
                            VerticalAlignment = 0
                        };
                        PdfPCell[] pdfPCellArray1 = new PdfPCell[] { new PdfPCell(pdfPCell4) };
                        PdfPRow pdfPRow1 = new PdfPRow(pdfPCellArray1);
                        barcode128.Code = Convert.ToString(row["CODIGO_BARRAS"]);
                        Image image = barcode128.CreateImageWithBarcode(directContent, null, null);
                        image.ScaleToFit(470f, 650f);
                        PdfPCell pdfPCell5 = new PdfPCell(new Phrase(new Chunk(image, 0f, 0f)))
                        {
                            HorizontalAlignment = 1,
                            Border = 0,
                            VerticalAlignment = 0
                        };
                        PdfPCell[] pdfPCellArray2 = new PdfPCell[] { new PdfPCell(pdfPCell5) };
                        PdfPRow pdfPRow2 = new PdfPRow(pdfPCellArray2);
                        PdfPCell pdfPCell6 = new PdfPCell(new Phrase(Convert.ToString(row["FECHA"]), font))
                        {
                            HorizontalAlignment = 1,
                            Border = 0,
                            VerticalAlignment = 0
                        };
                        PdfPCell[] pdfPCellArray3 = new PdfPCell[] { new PdfPCell(pdfPCell6) };
                        PdfPRow pdfPRow3 = new PdfPRow(pdfPCellArray3);
                        PdfPCell pdfPCell7 = new PdfPCell(new Phrase("", font1))
                        {
                            Border = 0
                        };
                        PdfPCell[] pdfPCellArray4 = new PdfPCell[] { new PdfPCell(pdfPCell7) };
                        PdfPRow pdfPRow4 = new PdfPRow(pdfPCellArray4);
                        if (this.EsPar(num1))
                        {
                            pdfPTable1.Rows.Clear();
                            pdfPTable1.AddCell(pdfPCell2);
                            pdfPTable1.Rows.Add(pdfPRow4);
                            pdfPTable1.Rows.Add(pdfPRow);
                            pdfPTable1.Rows.Add(pdfPRow4);
                            pdfPTable1.Rows.Add(pdfPRow1);
                            pdfPTable1.Rows.Add(pdfPRow4);
                            pdfPTable1.Rows.Add(pdfPRow2);
                            pdfPTable1.Rows.Add(pdfPRow4);
                            pdfPTable1.Rows.Add(pdfPRow3);
                        }
                        else
                        {
                            num = 1;
                            pdfPTable.Rows.Clear();
                            pdfPTable.AddCell(pdfPCell2);
                            pdfPTable.Rows.Add(pdfPRow4);
                            pdfPTable.Rows.Add(pdfPRow);
                            pdfPTable.Rows.Add(pdfPRow4);
                            pdfPTable.Rows.Add(pdfPRow1);
                            pdfPTable.Rows.Add(pdfPRow4);
                            pdfPTable.Rows.Add(pdfPRow2);
                            pdfPTable.Rows.Add(pdfPRow4);
                            pdfPTable.Rows.Add(pdfPRow3);
                        }
                        if (num == 0)
                        {
                            pdfPCell1.PaddingLeft = 195f;
                            pdfPCell.PaddingLeft = 0f;
                            PdfPTable pdfPTable2 = new PdfPTable(2);
                            pdfPTable2.DefaultCell.Border = 0;
                            pdfPTable2.HorizontalAlignment = 0;
                            pdfPTable2.SetWidths(new float[] { 1522f, 2400f });
                            pdfPTable2.SetTotalWidth(new float[] { 1522f, 2400f });
                            pdfPTable2.AddCell(pdfPCell);
                            pdfPTable2.AddCell(pdfPCell1);
                            document.Add(pdfPTable2);
                            document.NewPage();
                        }
                        if (count - num1 != 0 || num != 1)
                        {
                            continue;
                        }
                        pdfPCell.PaddingLeft = 0f;
                        pdfPTable.SetWidths(new float[] { 20f });
                        pdfPTable.SetTotalWidth(new float[] { 20f });
                        PdfPTable pdfPTable3 = new PdfPTable(1);
                        pdfPTable3.DefaultCell.Border = 0;
                        pdfPTable3.HorizontalAlignment = 0;
                        pdfPTable3.SetWidths(new float[] { 20f });
                        singleArray = new float[] { 20f };
                        pdfPTable3.SetTotalWidth(singleArray);
                        pdfPTable3.AddCell(pdfPCell);
                        document.Add(pdfPTable3);
                        document.NewPage();
                    }
                    document.Close();
                    Process process = new Process();
                    process.StartInfo.FileName = base.Server.MapPath(string.Concat("\\IUProdPack\\Etiquetas\\", str, ".pdf"));
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.StartInfo.Verb = "print";
                    (new PrinterSettings()).DefaultPageSettings.Landscape = true;
                    process.Start();
                    serviceSoapClient.ActualizaAudStockEtq(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), _Agencia, this.txtLote.Text, _CodLegajo, count);
                    this.txtLote.Text = "";
                    this.rdbTodas.Checked = true;
                    this.txtNumCx.Enabled = false;
                    this.txtNumCx.Visible = false;
                }
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
                    _Empresa = Convert.ToInt32(this.Session["empresa"].ToString());
                    _Grupo = Convert.ToInt32(this.Session["grupo"].ToString());
                    _Agencia = Convert.ToInt32(this.Session["agencia"].ToString());
                    ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                    DataSet dataSet = new DataSet();
                    dataSet = serviceSoapClient.LongitudTubo(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString());
                    if (dataSet.Tables[0].DefaultView.Count > 0)
                    {
                        this.txtNumCx.MaxLength = Convert.ToInt16(dataSet.Tables[0].Rows[0][0].ToString());
                        _Length = this.txtNumCx.MaxLength;
                    }
                }
                catch (Exception exception)
                {
                    this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                    this.upmensaje.Update();
                    this.mpemensaje.Show();
                }
            }
        }

        protected void rdbEtiquetaCx_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtNumCx.Text = "";
                this.txtNumCx.Enabled = false;
                if (this.rdbEtiquetaCx.Checked)
                {
                    this.txtNumCx.Enabled = true;
                    this.txtNumCx.Visible = true;
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
            }
        }

        protected void rdbTodas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtNumCx.Text = "";
                this.txtNumCx.Enabled = false;
                if (this.rdbTodas.Checked)
                {
                    this.txtNumCx.Enabled = false;
                    this.txtNumCx.Visible = false;
                }
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

        protected void txtNumCx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNumCx.Text != "")
                {
                    string text = this.txtNumCx.Text;
                    this.txtNumCx.Text = text.PadLeft(_Length, '0');
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
                this.upmensaje.Update();
                this.mpemensaje.Show();
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
    }
}