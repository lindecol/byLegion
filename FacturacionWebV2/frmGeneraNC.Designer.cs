
using FacturacionWebV2.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FacturacionNetV2
{
    partial class frmGeneraNC
    {


        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Evento_Picture(object sender, EventArgs e)
        {
            this.ExpandirGroup(sender);
        }

        private void ExpadirLayout(int p_Tamano)
        {
            if (this.flowLayoutPanel1.Height + p_Tamano <= base.Height - 100)
            {
                FlowLayoutPanel height = this.flowLayoutPanel1;
                height.Height = height.Height + p_Tamano;
            }
        }

        private void ExpandirGroup(object sender)
        {
            PictureBox expanderDown = sender as PictureBox;
            Panel parent = expanderDown.Parent as Panel;
            Panel size = parent.Parent as Panel;
            int num = Convert.ToInt16(expanderDown.Name.Substring(3, 1)) - 1;
            System.Drawing.Size item = this._arrSize[num];
            bool flag = Convert.ToBoolean(expanderDown.Tag.ToString());
            if (!flag)
            {
                expanderDown.Image = Resources.ExpanderDown;
                size.Size = parent.Size;
                FlowLayoutPanel height = this.flowLayoutPanel1;
                height.Height = height.Height - (item.Height - parent.Height);
            }
            else
            {
                expanderDown.Image = Resources.ExpanderUp;
                size.Size = item;
                FlowLayoutPanel flowLayoutPanel = this.flowLayoutPanel1;
                flowLayoutPanel.Height = flowLayoutPanel.Height + (item.Height - parent.Height);
            }
            expanderDown.Tag = (!flag).ToString();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void frmGeneraNC_Load(object sender, EventArgs e)
        {
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel2 = new FlowLayoutPanel();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.panel5 = new Panel();
            this.dtpFechaFin = new DateTimePicker();
            this.cmbAgencia = new ComboBox();
            this.label16 = new Label();
            this.label14 = new Label();
            this.dtpFehaIni = new DateTimePicker();
            this.label15 = new Label();
            this.panel2 = new Panel();
            this.mskCliH = new MaskedTextBox();
            this.expander2Panel = new Panel();
            this.pic1 = new PictureBox();
            this.expanderHeader = new Label();
            this.mskCliD = new MaskedTextBox();
            this.label1 = new Label();
            this.lblCliH = new Label();
            this.label2 = new Label();
            this.lblCliD = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.panel3 = new Panel();
            this.mskNroH = new MaskedTextBox();
            this.mskNroD = new MaskedTextBox();
            this.mskPreH = new MaskedTextBox();
            this.mskPreD = new MaskedTextBox();
            this.label9 = new Label();
            this.label10 = new Label();
            this.label11 = new Label();
            this.label12 = new Label();
            this.panel1 = new Panel();
            this.pic2 = new PictureBox();
            this.label13 = new Label();
            this.panel4 = new Panel();
            this.cmdConsultar = new Button();
            this.dataGridView1 = new DataGridView();
            this.flowLayoutPanel3 = new FlowLayoutPanel();
            this.panel6 = new Panel();
            this.mskObs3 = new TextBox();
            this.mskObs2 = new TextBox();
            this.label8 = new Label();
            this.cmbConcepto = new ComboBox();
            this.label7 = new Label();
            this.cmbMotivo = new ComboBox();
            this.label6 = new Label();
            this.cmbTipo = new ComboBox();
            this.label5 = new Label();
            this.panel7 = new Panel();
            this.cmdCancelar = new Button();
            this.cmdEjecutar = new Button();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.expander2Panel.SuspendLayout();
            ((ISupportInitialize)this.pic1).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((ISupportInitialize)this.pic2).BeginInit();
            this.panel4.SuspendLayout();
            ((ISupportInitialize)this.dataGridView1).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            base.SuspendLayout();
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.dataGridView1);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Location = new Point(12, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(997, 507);
            this.flowLayoutPanel2.TabIndex = 2;
            this.flowLayoutPanel2.Paint += new PaintEventHandler(this.flowLayoutPanel2_Paint);
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = SystemColors.GradientInactiveCaption;
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(390, 297);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            this.panel5.Controls.Add(this.dtpFechaFin);
            this.panel5.Controls.Add(this.cmbAgencia);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.dtpFehaIni);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Location = new Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(381, 66);
            this.panel5.TabIndex = 9;
            this.dtpFechaFin.Format = DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new Point(171, 38);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(87, 20);
            this.dtpFechaFin.TabIndex = 5;
            this.dtpFechaFin.Tag = "P03_FECHA_FIN";
            this.cmbAgencia.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAgencia.FormattingEnabled = true;
            this.cmbAgencia.Location = new Point(62, 11);
            this.cmbAgencia.Name = "cmbAgencia";
            this.cmbAgencia.Size = new System.Drawing.Size(310, 21);
            this.cmbAgencia.TabIndex = 1;
            this.cmbAgencia.Tag = "P01_AGENCIA";
            this.label16.AutoSize = true;
            this.label16.Location = new Point(155, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "-";
            this.label14.AutoSize = true;
            this.label14.Location = new Point(3, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Agencia";
            this.dtpFehaIni.Format = DateTimePickerFormat.Short;
            this.dtpFehaIni.Location = new Point(62, 38);
            this.dtpFehaIni.Name = "dtpFehaIni";
            this.dtpFehaIni.Size = new System.Drawing.Size(87, 20);
            this.dtpFehaIni.TabIndex = 3;
            this.dtpFehaIni.Tag = "P02_FECHA_INI";
            this.label15.AutoSize = true;
            this.label15.Location = new Point(3, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Fecha";
            this.panel2.Controls.Add(this.mskCliH);
            this.panel2.Controls.Add(this.expander2Panel);
            this.panel2.Controls.Add(this.mskCliD);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblCliH);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblCliD);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new Point(3, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 85);
            this.panel2.TabIndex = 6;
            this.mskCliH.InsertKeyMode = InsertKeyMode.Overwrite;
            this.mskCliH.Location = new Point(62, 57);
            this.mskCliH.Mask = "9999999";
            this.mskCliH.Name = "mskCliH";
            this.mskCliH.Size = new System.Drawing.Size(50, 20);
            this.mskCliH.TabIndex = 11;
            this.mskCliH.Tag = "P05_CLIENTE_FIN";
            this.mskCliH.TextAlign = HorizontalAlignment.Right;
            this.expander2Panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.expander2Panel.BackColor = Color.White;
            this.expander2Panel.Controls.Add(this.pic1);
            this.expander2Panel.Controls.Add(this.expanderHeader);
            this.expander2Panel.Location = new Point(0, 3);
            this.expander2Panel.Name = "expander2Panel";
            this.expander2Panel.Size = new System.Drawing.Size(375, 22);
            this.expander2Panel.TabIndex = 3;
            this.pic1.BackColor = Color.Transparent;
            this.pic1.Image = Resources.ExpanderUp;
            this.pic1.Location = new Point(0, 0);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(21, 21);
            this.pic1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pic1.TabIndex = 5;
            this.pic1.TabStop = false;
            this.pic1.Tag = "false";
            this.pic1.Click += new EventHandler(this.pic1_Click);
            this.expanderHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.expanderHeader.Location = new Point(21, 3);
            this.expanderHeader.Name = "expanderHeader";
            this.expanderHeader.Size = new System.Drawing.Size(244, 17);
            this.expanderHeader.TabIndex = 4;
            this.expanderHeader.Text = "¿Qué clientes fueron facturados?";
            this.mskCliD.InsertKeyMode = InsertKeyMode.Overwrite;
            this.mskCliD.Location = new Point(62, 34);
            this.mskCliD.Mask = "9999999";
            this.mskCliD.Name = "mskCliD";
            this.mskCliD.Size = new System.Drawing.Size(50, 20);
            this.mskCliD.TabIndex = 10;
            this.mskCliD.Tag = "P04_CLIENTE_INI";
            this.mskCliD.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde";
            this.lblCliH.BorderStyle = BorderStyle.Fixed3D;
            this.lblCliH.Location = new Point(134, 57);
            this.lblCliH.Name = "lblCliH";
            this.lblCliH.Size = new System.Drawing.Size(227, 20);
            this.lblCliH.TabIndex = 9;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            this.lblCliD.BorderStyle = BorderStyle.Fixed3D;
            this.lblCliD.Location = new Point(134, 34);
            this.lblCliD.Name = "lblCliD";
            this.lblCliD.Size = new System.Drawing.Size(227, 20);
            this.lblCliD.TabIndex = 8;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(118, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "-";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(118, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "-";
            this.panel3.Controls.Add(this.mskNroH);
            this.panel3.Controls.Add(this.mskNroD);
            this.panel3.Controls.Add(this.mskPreH);
            this.panel3.Controls.Add(this.mskPreD);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new Point(3, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(381, 86);
            this.panel3.TabIndex = 7;
            this.mskNroH.InsertKeyMode = InsertKeyMode.Overwrite;
            this.mskNroH.Location = new Point(134, 57);
            this.mskNroH.Mask = "99999999";
            this.mskNroH.Name = "mskNroH";
            this.mskNroH.Size = new System.Drawing.Size(105, 20);
            this.mskNroH.TabIndex = 23;
            this.mskNroH.Tag = "P08_NRO_FIN";
            this.mskNroH.TextAlign = HorizontalAlignment.Right;
            this.mskNroD.InsertKeyMode = InsertKeyMode.Overwrite;
            this.mskNroD.Location = new Point(134, 34);
            this.mskNroD.Mask = "99999999";
            this.mskNroD.Name = "mskNroD";
            this.mskNroD.Size = new System.Drawing.Size(105, 20);
            this.mskNroD.TabIndex = 22;
            this.mskNroD.Tag = "P07_NRO_INI";
            this.mskNroD.TextAlign = HorizontalAlignment.Right;
            this.mskPreH.Enabled = false;
            this.mskPreH.InsertKeyMode = InsertKeyMode.Overwrite;
            this.mskPreH.Location = new Point(62, 57);
            this.mskPreH.Mask = "99999";
            this.mskPreH.Name = "mskPreH";
            this.mskPreH.Size = new System.Drawing.Size(50, 20);
            this.mskPreH.TabIndex = 21;
            this.mskPreH.TextAlign = HorizontalAlignment.Right;
            this.mskPreD.InsertKeyMode = InsertKeyMode.Overwrite;
            this.mskPreD.Location = new Point(62, 34);
            this.mskPreD.Mask = "99999";
            this.mskPreD.Name = "mskPreD";
            this.mskPreD.Size = new System.Drawing.Size(50, 20);
            this.mskPreD.TabIndex = 20;
            this.mskPreD.Tag = "P06_PREFIJO_INI";
            this.mskPreD.TextAlign = HorizontalAlignment.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(118, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "-";
            this.label10.AutoSize = true;
            this.label10.Location = new Point(118, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "-";
            this.label11.AutoSize = true;
            this.label11.Location = new Point(18, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Hasta";
            this.label12.AutoSize = true;
            this.label12.Location = new Point(18, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Desde";
            this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.panel1.BackColor = Color.White;
            this.panel1.Controls.Add(this.pic2);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 22);
            this.panel1.TabIndex = 2;
            this.pic2.BackColor = Color.Transparent;
            this.pic2.Image = Resources.ExpanderUp;
            this.pic2.Location = new Point(0, 0);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(21, 21);
            this.pic2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pic2.TabIndex = 5;
            this.pic2.TabStop = false;
            this.pic2.Tag = "false";
            this.label13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.label13.Location = new Point(21, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(244, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = "¿Qué facturas fueron realizadas?";
            this.panel4.Controls.Add(this.cmdConsultar);
            this.panel4.Location = new Point(3, 258);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(381, 29);
            this.panel4.TabIndex = 8;
            this.cmdConsultar.Location = new Point(303, 3);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(75, 23);
            this.cmdConsultar.TabIndex = 0;
            this.cmdConsultar.Text = "Consultar >>";
            this.cmdConsultar.UseVisualStyleBackColor = true;
            this.cmdConsultar.Click += new EventHandler(this.cmdConsultar_Click);
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(399, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(585, 502);
            this.dataGridView1.TabIndex = 2;
            this.flowLayoutPanel3.BackColor = SystemColors.GradientInactiveCaption;
            this.flowLayoutPanel3.Controls.Add(this.panel6);
            this.flowLayoutPanel3.Controls.Add(this.panel7);
            this.flowLayoutPanel3.Location = new Point(3, 511);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(390, 241);
            this.flowLayoutPanel3.TabIndex = 3;
            this.flowLayoutPanel3.Visible = false;
            this.panel6.Controls.Add(this.mskObs3);
            this.panel6.Controls.Add(this.mskObs2);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.cmbConcepto);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.cmbMotivo);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.cmbTipo);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(381, 199);
            this.panel6.TabIndex = 9;
            this.mskObs3.Location = new Point(18, 159);
            this.mskObs3.MaxLength = 60;
            this.mskObs3.Name = "mskObs3";
            this.mskObs3.Size = new System.Drawing.Size(354, 20);
            this.mskObs3.TabIndex = 10;
            this.mskObs3.Tag = "P07_OBS3";
            this.mskObs2.Location = new Point(18, 133);
            this.mskObs2.MaxLength = 60;
            this.mskObs2.Name = "mskObs2";
            this.mskObs2.Size = new System.Drawing.Size(354, 20);
            this.mskObs2.TabIndex = 9;
            this.mskObs2.Tag = "P06_OBS2";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(3, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Observaciones Adicionales";
            this.cmbConcepto.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbConcepto.FormattingEnabled = true;
            this.cmbConcepto.Location = new Point(79, 73);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(296, 21);
            this.cmbConcepto.TabIndex = 7;
            this.cmbConcepto.Tag = "P05_CONCEPTO";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(6, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Concepto";
            this.cmbMotivo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMotivo.FormattingEnabled = true;
            this.cmbMotivo.Location = new Point(79, 41);
            this.cmbMotivo.Name = "cmbMotivo";
            this.cmbMotivo.Size = new System.Drawing.Size(296, 21);
            this.cmbMotivo.TabIndex = 5;
            this.cmbMotivo.Tag = "P04_MOTIVO";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(6, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Motivo";
            this.cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new Point(79, 10);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(296, 21);
            this.cmbTipo.TabIndex = 3;
            this.cmbTipo.Tag = "P03_TIPO";
            this.cmbTipo.SelectionChangeCommitted += new EventHandler(this.cmbTipo_SelectionChangeCommitted);
            this.cmbTipo.SelectedIndexChanged += new EventHandler(this.cmbTipo_SelectedIndexChanged);
            this.label5.AutoSize = true;
            this.label5.Location = new Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tipo";
            this.panel7.Controls.Add(this.cmdCancelar);
            this.panel7.Controls.Add(this.cmdEjecutar);
            this.panel7.Location = new Point(3, 208);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(381, 29);
            this.panel7.TabIndex = 10;
            this.cmdCancelar.Location = new Point(3, 3);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 1;
            this.cmdCancelar.Text = "<< Cancelar ";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new EventHandler(this.button2_Click);
            this.cmdEjecutar.Location = new Point(303, 3);
            this.cmdEjecutar.Name = "cmdEjecutar";
            this.cmdEjecutar.Size = new System.Drawing.Size(75, 23);
            this.cmdEjecutar.TabIndex = 0;
            this.cmdEjecutar.Text = "Ejecutar >>";
            this.cmdEjecutar.UseVisualStyleBackColor = true;
            this.cmdEjecutar.Click += new EventHandler(this.cmdEjecutar_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = SystemColors.Control;
            base.ClientSize = new System.Drawing.Size(1016, 529);
            base.Controls.Add(this.flowLayoutPanel2);
            base.Name = "frmGeneraNC";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Generar NC";
            base.Load += new EventHandler(this.frmGeneraNC_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.expander2Panel.ResumeLayout(false);
            this.expander2Panel.PerformLayout();
            ((ISupportInitialize)this.pic1).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((ISupportInitialize)this.pic2).EndInit();
            this.panel4.ResumeLayout(false);
            ((ISupportInitialize)this.dataGridView1).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            base.ResumeLayout(false);
        }



        #endregion
    }
}

