using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Data;
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
    public partial class wfImpresionEtiquetaLote : System.Web.UI.Page
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

        public wfImpresionEtiquetaLote()
        {
        }

        private PdfPCell crearCelda(string texto, Font fontTexto, int Alig)
        {
            PdfPCell pdfPCell = new PdfPCell(new Phrase(Convert.ToString(texto), fontTexto))
            {
                HorizontalAlignment = Alig,
                Border = 0,
                VerticalAlignment = Alig,
                PaddingLeft = 0f,
                PaddingTop = 0f
            };
            return pdfPCell;
        }

        private PdfPCell crearCelda(PdfPTable _table)
        {
            PdfPCell pdfPCell = new PdfPCell(_table)
            {
                Border = 0,
                HorizontalAlignment = 0,
                VerticalAlignment = 1,
                PaddingLeft = 0f,
                PaddingTop = 0f
            };
            return pdfPCell;
        }

        private PdfPCell crearCelda(System.Drawing.Image imagen, int Alig)
        {

            //Legion - conversion de System.Drawing.Image a iTextSharp.text.Image
            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(imagen, System.Drawing.Imaging.ImageFormat.Jpeg);

            //PdfPCell pdfPCell = new PdfPCell(new Phrase(new Chunk(imagen, 0f, 0f)))
            PdfPCell pdfPCell = new PdfPCell(png)
            {
                HorizontalAlignment = Alig,
                Border = 0,
                VerticalAlignment = Alig,
                PaddingLeft = 0f,
                PaddingTop = 0f
            };
            return pdfPCell;
        }

        /// <summary>
        /// Legion - Se crear método para facilitar el uso de iTextSharp.text.Image como parámetro
        /// </summary>
        /// <param name="imagen"></param>
        /// <param name="Alig"></param>
        /// <param name="extra"></param>
        /// <returns></returns>
        private PdfPCell crearCelda(iTextSharp.text.Image imagen, int Alig)
        {

            //Legion - conversion de System.Drawing.Image a iTextSharp.text.Image
            //iTextSharp.text.Image png = imagen;

            PdfPCell pdfPCell = new PdfPCell(new Phrase(new Chunk(imagen, 0f, 0f)))
            //PdfPCell pdfPCell = new PdfPCell(png)
            {
                HorizontalAlignment = Alig,
                Border = 0,
                VerticalAlignment = Alig,
                PaddingLeft = 0f,
                PaddingTop = 0f
            };
            return pdfPCell;
        }

        private PdfPTable crearTablas(int numColumnas, float[] tam, float porc)
        {
            PdfPTable pdfPTable = new PdfPTable(tam);
            pdfPTable.DefaultCell.Border = 0;
            pdfPTable.HorizontalAlignment = 0;
            if (!porc.Equals(0f))
            {
                pdfPTable.WidthPercentage = porc;
            }
            return pdfPTable;
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
                flag = flag1;
            }
            return flag;
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
                                return;
                            }
                        }
                        else
                        {
                            this.lblmensaje.Text = "Debe ingresar un Nº de Cilindro.";
                            return;
                        }
                    }
                    this.Imprimir();
                }
                else
                {
                    this.lblmensaje.Text = "Por favor digite el No. de Lote";
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
            }
        }

        private void Imprimir()
        {
            PdfPTable pdfPTable;
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
                    dataSet = serviceSoapClient.ConsEtiquetaLoteCx(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text, this.txtNumCx.Text);
                    str = string.Concat("EtiquetasLoteCx", Convert.ToString(this.txtNumCx.Text));
                }
                else
                {
                    dataSet = serviceSoapClient.ConsEtiquetasLote(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text);
                    str = string.Concat("EtiquetasLote", text);
                }
                if (dataSet.Tables[0].DefaultView.Count <= 0)
                {
                    this.lblmensaje.Text = "No se encontraron Datos";
                }
                else
                {
                    count = dataSet.Tables[0].DefaultView.Count;
                    float single = 360f;
                    float single1 = single / 2f;
                    Rectangle rectangle = new Rectangle(single, 128f);
                    Document document = new Document(rectangle, 0f, 0f, 0f, 0f);
                    PdfWriter instance = PdfWriter.GetInstance(document, new FileStream(base.Server.MapPath(string.Concat("\\IUProdPack\\Etiquetas\\", str, ".pdf")), FileMode.OpenOrCreate));
                    document.Open();
                    PdfContentByte directContent = instance.DirectContent;
                    Barcode128 barcode128 = new Barcode128()
                    {
                        CodeType = 10
                    };
                    int num = 0;
                    Font font = new Font(Font.FontFamily.HELVETICA, 8f, 1);
                    Font font1 = new Font(Font.FontFamily.HELVETICA, 7f, 1);
                    Font font2 = new Font(Font.FontFamily.HELVETICA, 6f, 0);
                    Font font3 = new Font(Font.FontFamily.HELVETICA, 6f, 1);
                    Font font4 = new Font(Font.FontFamily.HELVETICA, 4f, 1);
                    int num1 = 0;
                    float[] singleArray = new float[] { single1 };
                    PdfPTable pdfPTable1 = this.crearTablas(1, singleArray, 0f);
                    float[] singleArray1 = new float[] { single1 };
                    PdfPTable pdfPTable2 = this.crearTablas(1, singleArray1, 0f);
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        num = 0;
                        num1++;
                        if (count - num1 != 0 || num != 1)
                        {
                            float[] singleArray2 = new float[] { single1 - 40f, 40f };
                            pdfPTable = this.crearTablas(2, singleArray2, 0f);
                        }
                        else
                        {
                            float[] singleArray3 = new float[] { single1 - 40f, 40f };
                            pdfPTable = this.crearTablas(2, singleArray3, 45f);
                        }
                        pdfPTable.AddCell(this.crearCelda(row["TITULO"].ToString(), font, 0));
                        pdfPTable.AddCell(this.crearCelda(row["FECHALOTE"].ToString(), font2, 0));
                        PdfPCell pdfPCell = this.crearCelda(row["PRODUCTO"].ToString(), font1, 1);
                        PdfPTable pdfPTable3 = this.crearTablas(4, new float[] { 28f, 28f, 39f, 25f }, 0f);
                        pdfPTable3.AddCell(this.crearCelda(row["CAPTITULO"].ToString(), font2, 1));
                        pdfPTable3.AddCell(this.crearCelda(row["PROPTITULO"].ToString(), font2, 0));
                        pdfPTable3.AddCell(this.crearCelda(row["LOTETITULO"].ToString(), font2, 0));
                        pdfPTable3.AddCell(this.crearCelda(row["ETIQUETAVENCETIT"].ToString(), font2, 0));
                        PdfPTable pdfPTable4 = this.crearTablas(4, new float[] { 28f, 28f, 39f, 25f }, 0f);
                        pdfPTable4.AddCell(this.crearCelda(string.Concat(row["CAPACIDAD"].ToString(), " ", Convert.ToString(row["UNIDADMED"])), font2, 1));
                        pdfPTable4.AddCell(this.crearCelda(row["PROPIETARIO"].ToString(), font2, 0));
                        pdfPTable4.AddCell(this.crearCelda(row["LOTE"].ToString(), font2, 0));
                        pdfPTable4.AddCell(this.crearCelda(row["FECHAVENCIMIENTO"].ToString(), font2, 0));
                        PdfPCell[] pdfPCellArray = new PdfPCell[] { new PdfPCell(this.crearCelda(pdfPTable)) };
                        PdfPRow pdfPRow = new PdfPRow(pdfPCellArray);
                        PdfPCell[] pdfPCell1 = new PdfPCell[] { new PdfPCell(pdfPCell) };
                        PdfPRow pdfPRow1 = new PdfPRow(pdfPCell1);
                        PdfPCell[] pdfPCellArray1 = new PdfPCell[] { new PdfPCell(this.crearCelda(pdfPTable3)) };
                        PdfPRow pdfPRow2 = new PdfPRow(pdfPCellArray1);
                        PdfPCell[] pdfPCell2 = new PdfPCell[] { new PdfPCell(this.crearCelda(pdfPTable4)) };
                        PdfPRow pdfPRow3 = new PdfPRow(pdfPCell2);
                        PdfPCell[] pdfPCellArray2 = new PdfPCell[] { new PdfPCell(this.crearCelda("", font4, 1)) };
                        PdfPRow pdfPRow4 = new PdfPRow(pdfPCellArray2);
                        barcode128.Code = Convert.ToString(row["CODIGO_BARRAS"]);
                        Image image = barcode128.CreateImageWithBarcode(directContent, null, null);
                        image.ScaleToFit(single1, 30f);


                        PdfPCell[] pdfPCell3 = new PdfPCell[] { new PdfPCell(this.crearCelda(image, 1)) };
                        PdfPRow pdfPRow5 = new PdfPRow(pdfPCell3);
                        PdfPCell[] pdfPCellArray3 = new PdfPCell[] { new PdfPCell(this.crearCelda(row["LEYENDA"].ToString(), font4, 1)) };
                        PdfPRow pdfPRow6 = new PdfPRow(pdfPCellArray3);
                        if (this.EsPar(num1))
                        {
                            num = 0;
                            pdfPTable1.Rows.Clear();
                            pdfPTable1.Rows.Add(pdfPRow);
                            pdfPTable1.Rows.Add(pdfPRow1);
                            pdfPTable1.Rows.Add(pdfPRow2);
                            pdfPTable1.Rows.Add(pdfPRow3);
                            pdfPTable1.Rows.Add(pdfPRow4);
                            pdfPTable1.Rows.Add(pdfPRow5);
                            pdfPTable1.Rows.Add(pdfPRow6);
                        }
                        else
                        {
                            num = 1;
                            pdfPTable2.Rows.Clear();
                            pdfPTable2.Rows.Add(pdfPRow);
                            pdfPTable2.Rows.Add(pdfPRow1);
                            pdfPTable2.Rows.Add(pdfPRow2);
                            pdfPTable2.Rows.Add(pdfPRow3);
                            pdfPTable2.Rows.Add(pdfPRow4);
                            pdfPTable2.Rows.Add(pdfPRow5);
                            pdfPTable2.Rows.Add(pdfPRow6);
                        }
                        if (num == 0)
                        {
                            float[] singleArray4 = new float[] { single1 + 10f, single1 };
                            PdfPTable pdfPTable5 = this.crearTablas(2, singleArray4, 0f);
                            pdfPTable5.AddCell(pdfPTable2);
                            pdfPTable5.AddCell(pdfPTable1);
                            document.Add(pdfPTable5);
                            document.NewPage();
                            float[] singleArray5 = new float[] { single1 };
                            pdfPTable1 = this.crearTablas(1, singleArray5, 0f);
                            float[] singleArray6 = new float[] { single1 };
                            pdfPTable2 = this.crearTablas(1, singleArray6, 0f);
                        }
                        if (count - num1 != 0 || num != 1)
                        {
                            continue;
                        }
                        float[] singleArray7 = new float[] { single1 };
                        PdfPTable pdfPTable6 = this.crearTablas(2, singleArray7, 45f);
                        pdfPTable6.AddCell(pdfPTable2);
                        document.Add(pdfPTable6);
                        document.NewPage();
                    }
                    document.Close();
                    base.Response.Clear();
                    base.Response.ContentType = "application/octet-stream";
                    base.Response.AddHeader("Content-Disposition", "attachment; filename=archivo.pdf");
                    base.Response.Flush();
                    base.Response.WriteFile(base.Server.MapPath(string.Concat("\\IUProdPack\\Etiquetas\\", str, ".pdf")));
                    base.Response.End();
                    File.Delete(base.Server.MapPath(string.Concat("\\IUProdPack\\Etiquetas\\", str, ".pdf")));
                    this.txtLote.Text = "";
                    this.rdbTodas.Checked = true;
                    this.txtNumCx.Enabled = false;
                    this.txtNumCx.Visible = false;
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
            }
        }

        private void ImprimirAnt()
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
                    dataSet = serviceSoapClient.ConsEtiquetaLoteCx(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text, this.txtNumCx.Text);
                    str = string.Concat("EtiquetasLoteCx", Convert.ToString(this.txtNumCx.Text));
                }
                else
                {
                    dataSet = serviceSoapClient.ConsEtiquetasLote(this.Session["usuario"].ToString(), this.Session["password"].ToString(), this.Session["conexion"].ToString(), this.txtLote.Text);
                    str = string.Concat("EtiquetasLote", text);
                }
                if (dataSet.Tables[0].DefaultView.Count <= 0)
                {
                    this.lblmensaje.Text = "No se encontraron Datos";
                }
                else
                {
                    count = dataSet.Tables[0].DefaultView.Count;
                    Rectangle rectangle = new Rectangle(400f, 80f);
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
                    float[] singleArray = new float[1];
                    pdfPTable.SetWidths(singleArray);
                    singleArray = new float[] { 200f };
                    pdfPTable.SetTotalWidth(singleArray);
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
                    singleArray = new float[1];
                    pdfPTable1.SetWidths(singleArray);
                    singleArray = new float[] { 200f };
                    pdfPTable1.SetTotalWidth(singleArray);
                    PdfPCell pdfPCell1 = new PdfPCell(pdfPTable1)
                    {
                        Border = 0,
                        VerticalAlignment = 0,
                        PaddingLeft = 0f,
                        PaddingTop = 0f,
                        PaddingRight = 0f
                    };
                    Font font = new Font(Font.FontFamily.HELVETICA, 8f, 1);
                    Font font1 = new Font(Font.FontFamily.HELVETICA, 3f, 1);
                    Font font2 = new Font(Font.FontFamily.HELVETICA, 4f, 0);
                    Font font3 = new Font(Font.FontFamily.HELVETICA, 5f, 0);
                    Font font4 = new Font(Font.FontFamily.HELVETICA, 3f, 1);
                    Font font5 = new Font(Font.FontFamily.HELVETICA, 4f, 0);
                    int num1 = 0;
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        num = 0;
                        num1++;
                        PdfPTable pdfPTable2 = new PdfPTable(2);
                        pdfPTable2.DefaultCell.Border = 0;
                        pdfPTable2.HorizontalAlignment = 0;
                        pdfPTable2.WidthPercentage = 10f;
                        singleArray = new float[] { 6f, 4f };
                        pdfPTable2.SetWidths(singleArray);
                        PdfPCell pdfPCell2 = new PdfPCell(new Phrase(Convert.ToString(row["TITULO"]), font))
                        {
                            HorizontalAlignment = 1,
                            Border = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        pdfPTable2.AddCell(pdfPCell2);
                        Font font6 = new Font(Font.FontFamily.HELVETICA, 6f, 0);
                        PdfPCell pdfPCell3 = new PdfPCell(new Phrase(Convert.ToString(row["FECHALOTE"]), font6))
                        {
                            HorizontalAlignment = 0,
                            Border = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        pdfPTable2.AddCell(pdfPCell3);
                        PdfPCell pdfPCell4 = new PdfPCell(pdfPTable2)
                        {
                            Border = 0,
                            HorizontalAlignment = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        PdfPCell pdfPCell5 = new PdfPCell(new Phrase(Convert.ToString(row["PRODUCTO"]), font1))
                        {
                            HorizontalAlignment = 0,
                            NoWrap = true,
                            Border = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        PdfPCell[] pdfPCellArray = new PdfPCell[] { new PdfPCell(pdfPCell5) };
                        PdfPRow pdfPRow = new PdfPRow(pdfPCellArray);
                        PdfPTable pdfPTable3 = new PdfPTable(3);
                        pdfPTable3.DefaultCell.Border = 0;
                        pdfPTable3.HorizontalAlignment = 0;
                        pdfPTable3.WidthPercentage = 100f;
                        pdfPTable3.SetWidths(new float[] { 50f, 50f, 90f });
                        PdfPCell pdfPCell6 = new PdfPCell(new Phrase(Convert.ToString(row["CAPTITULO"]), font3))
                        {
                            HorizontalAlignment = 0,
                            Border = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        pdfPTable3.AddCell(pdfPCell6);
                        PdfPCell pdfPCell7 = new PdfPCell(new Phrase(Convert.ToString(row["PROPTITULO"]), font3))
                        {
                            HorizontalAlignment = 0,
                            Border = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        pdfPTable3.AddCell(pdfPCell7);
                        PdfPCell pdfPCell8 = new PdfPCell(new Phrase(string.Concat(Convert.ToString(row["ETIQUETAVENCETIT"]), " ", Convert.ToString(row["FECHAVENCIMIENTO"])), font2))
                        {
                            HorizontalAlignment = 0,
                            Border = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        pdfPTable3.AddCell(pdfPCell8);
                        PdfPCell pdfPCell9 = new PdfPCell(new Phrase(string.Concat(Convert.ToString(row["CAPACIDAD"]), " ", Convert.ToString(row["UNIDADMED"])), font4))
                        {
                            HorizontalAlignment = 0,
                            Border = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        PdfPCell pdfPCell10 = new PdfPCell(new Phrase(Convert.ToString(row["PROPIETARIO"]), font4))
                        {
                            HorizontalAlignment = 0,
                            Border = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        PdfPCell pdfPCell11 = new PdfPCell(new Phrase(string.Concat(Convert.ToString(row["LOTETITULO"]), " ", Convert.ToString(row["LOTE"])), font4))
                        {
                            HorizontalAlignment = 0,
                            Border = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        pdfPCellArray = new PdfPCell[] { new PdfPCell(pdfPCell9), new PdfPCell(pdfPCell10) };
                        PdfPRow pdfPRow1 = new PdfPRow(pdfPCellArray);
                        pdfPTable3.Rows.Add(pdfPRow1);
                        PdfPCell pdfPCell12 = new PdfPCell(pdfPTable3)
                        {
                            Border = 0,
                            HorizontalAlignment = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        pdfPCellArray = new PdfPCell[] { new PdfPCell(pdfPCell12) };
                        PdfPRow pdfPRow2 = new PdfPRow(pdfPCellArray);
                        barcode128.Code = Convert.ToString(row["CODIGO_BARRAS"]);
                        Image image = barcode128.CreateImageWithBarcode(directContent, null, null);
                        image.ScaleToFit(80f, 100f);
                        PdfPCell pdfPCell13 = new PdfPCell(new Phrase(new Chunk(image, 0f, 0f)))
                        {
                            HorizontalAlignment = 0,
                            Border = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        pdfPCellArray = new PdfPCell[] { new PdfPCell(pdfPCell13) };
                        PdfPRow pdfPRow3 = new PdfPRow(pdfPCellArray);
                        PdfPCell pdfPCell14 = new PdfPCell(new Phrase(Convert.ToString(row["LEYENDA"]), font5))
                        {
                            HorizontalAlignment = 0,
                            Border = 0,
                            VerticalAlignment = 0,
                            PaddingLeft = 0f,
                            PaddingTop = 0f
                        };
                        pdfPCellArray = new PdfPCell[] { new PdfPCell(pdfPCell14) };
                        PdfPRow pdfPRow4 = new PdfPRow(pdfPCellArray);
                        PdfPCell pdfPCell15 = new PdfPCell(new Phrase("", font5))
                        {
                            Border = 0
                        };
                        pdfPCellArray = new PdfPCell[] { new PdfPCell(pdfPCell15) };
                        PdfPRow pdfPRow5 = new PdfPRow(pdfPCellArray);
                        if (this.EsPar(num1))
                        {
                            pdfPTable1.Rows.Clear();
                            pdfPTable1.AddCell(pdfPCell4);
                            pdfPTable1.Rows.Add(pdfPRow5);
                            pdfPTable1.Rows.Add(pdfPRow);
                            pdfPTable1.Rows.Add(pdfPRow5);
                            pdfPTable1.Rows.Add(pdfPRow2);
                            pdfPTable1.Rows.Add(pdfPRow5);
                            pdfPTable1.Rows.Add(pdfPRow3);
                            pdfPTable1.Rows.Add(pdfPRow5);
                            pdfPTable1.Rows.Add(pdfPRow4);
                        }
                        else
                        {
                            num = 1;
                            pdfPTable.Rows.Clear();
                            pdfPTable.AddCell(pdfPCell4);
                            pdfPTable.Rows.Add(pdfPRow5);
                            pdfPTable.Rows.Add(pdfPRow);
                            pdfPTable.Rows.Add(pdfPRow5);
                            pdfPTable.Rows.Add(pdfPRow2);
                            pdfPTable.Rows.Add(pdfPRow5);
                            pdfPTable.Rows.Add(pdfPRow3);
                            pdfPTable.Rows.Add(pdfPRow5);
                            pdfPTable.Rows.Add(pdfPRow4);
                        }
                        if (num == 0)
                        {
                            pdfPCell1.PaddingLeft = 195f;
                            pdfPCell.PaddingLeft = 0f;
                            PdfPTable pdfPTable4 = new PdfPTable(2);
                            pdfPTable4.DefaultCell.Border = 0;
                            pdfPTable4.HorizontalAlignment = 0;
                            singleArray = new float[] { 200f, 400f };
                            pdfPTable4.SetWidths(singleArray);
                            singleArray = new float[] { 200f, 400f };
                            pdfPTable4.SetTotalWidth(singleArray);
                            pdfPTable4.AddCell(pdfPCell);
                            pdfPTable4.AddCell(pdfPCell1);
                            document.Add(pdfPTable4);
                            document.NewPage();
                        }
                        if (count - num1 != 0 || num != 1)
                        {
                            continue;
                        }
                        pdfPCell.PaddingLeft = 0f;
                        singleArray = new float[] { 200f };
                        pdfPTable.SetWidths(singleArray);
                        singleArray = new float[] { 200f };
                        pdfPTable.SetTotalWidth(singleArray);
                        singleArray = new float[] { 5f, 5f };
                        pdfPTable2.SetWidths(singleArray);
                        pdfPTable2.WidthPercentage = 50f;
                        pdfPTable3.SetWidths(new float[] { 5f, 5f, 10f });
                        pdfPTable3.WidthPercentage = 50f;
                        PdfPTable pdfPTable5 = new PdfPTable(1);
                        pdfPTable5.DefaultCell.Border = 0;
                        pdfPTable5.HorizontalAlignment = 0;
                        singleArray = new float[] { 200f };
                        pdfPTable5.SetWidths(singleArray);
                        singleArray = new float[] { 200f };
                        pdfPTable5.SetTotalWidth(singleArray);
                        pdfPTable5.AddCell(pdfPCell);
                        document.Add(pdfPTable5);
                        document.NewPage();
                    }
                    document.Close();
                    this.txtLote.Text = "";
                    this.rdbTodas.Checked = true;
                    this.txtNumCx.Enabled = false;
                    this.txtNumCx.Visible = false;
                }
            }
            catch (Exception exception)
            {
                this.lblmensaje.Text = clsConstantes.ManejoExcepciones(exception);
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
            }
        }
    }
}