namespace InfoContactoClientes
{
    partial class FrmContactoUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTIpoContacto = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.dtpFechaCumpleaños = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCumpleaños = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblInfoAdicional = new System.Windows.Forms.Label();
            this.txtInfoAdicional = new System.Windows.Forms.TextBox();
            this.oldtxtTelefono_ = new System.Windows.Forms.NumericUpDown();
            this.chkHabeasData = new System.Windows.Forms.CheckBox();
            this.lblNombreContacto = new System.Windows.Forms.Label();
            this.txtNombreContacto = new System.Windows.Forms.TextBox();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.lblTipoIdentificacion = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.cmbTipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.tIpoIdentificacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CboParentezco = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnDireccion = new System.Windows.Forms.Button();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CboLocalidad = new System.Windows.Forms.ComboBox();
            this.LblLocalidad = new System.Windows.Forms.Label();
            this.CboCiudad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.oldtxtTelefono_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIpoIdentificacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo registro";
            // 
            // cmbTIpoContacto
            // 
            this.cmbTIpoContacto.Enabled = false;
            this.cmbTIpoContacto.FormattingEnabled = true;
            this.cmbTIpoContacto.Location = new System.Drawing.Point(123, 30);
            this.cmbTIpoContacto.Name = "cmbTIpoContacto";
            this.cmbTIpoContacto.Size = new System.Drawing.Size(315, 21);
            this.cmbTIpoContacto.TabIndex = 0;
            this.cmbTIpoContacto.SelectedIndexChanged += new System.EventHandler(this.cmbTIpoContacto_SelectedIndexChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(27, 87);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 13);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "E-Mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(123, 84);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(315, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(27, 113);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Telefono";
            // 
            // dtpFechaCumpleaños
            // 
            this.dtpFechaCumpleaños.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCumpleaños.Location = new System.Drawing.Point(146, 187);
            this.dtpFechaCumpleaños.Name = "dtpFechaCumpleaños";
            this.dtpFechaCumpleaños.Size = new System.Drawing.Size(292, 20);
            this.dtpFechaCumpleaños.TabIndex = 6;
            // 
            // lblFechaCumpleaños
            // 
            this.lblFechaCumpleaños.AutoSize = true;
            this.lblFechaCumpleaños.Location = new System.Drawing.Point(30, 190);
            this.lblFechaCumpleaños.Name = "lblFechaCumpleaños";
            this.lblFechaCumpleaños.Size = new System.Drawing.Size(98, 13);
            this.lblFechaCumpleaños.TabIndex = 9;
            this.lblFechaCumpleaños.Text = "Fecha Cumpleaños";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(412, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblInfoAdicional
            // 
            this.lblInfoAdicional.AutoSize = true;
            this.lblInfoAdicional.Location = new System.Drawing.Point(27, 141);
            this.lblInfoAdicional.Name = "lblInfoAdicional";
            this.lblInfoAdicional.Size = new System.Drawing.Size(80, 13);
            this.lblInfoAdicional.TabIndex = 14;
            this.lblInfoAdicional.Text = "Ext, Menu, Etc.";
            // 
            // txtInfoAdicional
            // 
            this.txtInfoAdicional.Location = new System.Drawing.Point(123, 138);
            this.txtInfoAdicional.Name = "txtInfoAdicional";
            this.txtInfoAdicional.Size = new System.Drawing.Size(232, 20);
            this.txtInfoAdicional.TabIndex = 6;
            // 
            // oldtxtTelefono_
            // 
            this.oldtxtTelefono_.Location = new System.Drawing.Point(122, 4);
            this.oldtxtTelefono_.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.oldtxtTelefono_.Name = "oldtxtTelefono_";
            this.oldtxtTelefono_.Size = new System.Drawing.Size(315, 20);
            this.oldtxtTelefono_.TabIndex = 3;
            this.oldtxtTelefono_.Visible = false;
            // 
            // chkHabeasData
            // 
            this.chkHabeasData.AutoSize = true;
            this.chkHabeasData.Location = new System.Drawing.Point(29, 164);
            this.chkHabeasData.Name = "chkHabeasData";
            this.chkHabeasData.Size = new System.Drawing.Size(192, 17);
            this.chkHabeasData.TabIndex = 2;
            this.chkHabeasData.Text = "Acepta Tratamiento de Informacion";
            this.chkHabeasData.UseVisualStyleBackColor = true;
            this.chkHabeasData.Visible = false;
            // 
            // lblNombreContacto
            // 
            this.lblNombreContacto.AutoSize = true;
            this.lblNombreContacto.Location = new System.Drawing.Point(27, 61);
            this.lblNombreContacto.Name = "lblNombreContacto";
            this.lblNombreContacto.Size = new System.Drawing.Size(90, 13);
            this.lblNombreContacto.TabIndex = 2;
            this.lblNombreContacto.Text = "Nombre Contacto";
            // 
            // txtNombreContacto
            // 
            this.txtNombreContacto.Location = new System.Drawing.Point(190, 58);
            this.txtNombreContacto.Name = "txtNombreContacto";
            this.txtNombreContacto.Size = new System.Drawing.Size(248, 20);
            this.txtNombreContacto.TabIndex = 1;
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.AutoSize = true;
            this.lblIdentificacion.Location = new System.Drawing.Point(219, 141);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(70, 13);
            this.lblIdentificacion.TabIndex = 21;
            this.lblIdentificacion.Text = "Identificacion";
            this.lblIdentificacion.Visible = false;
            // 
            // lblTipoIdentificacion
            // 
            this.lblTipoIdentificacion.AutoSize = true;
            this.lblTipoIdentificacion.Location = new System.Drawing.Point(26, 140);
            this.lblTipoIdentificacion.Name = "lblTipoIdentificacion";
            this.lblTipoIdentificacion.Size = new System.Drawing.Size(94, 13);
            this.lblTipoIdentificacion.TabIndex = 8;
            this.lblTipoIdentificacion.Text = "Tipo Identificacion";
            this.lblTipoIdentificacion.Visible = false;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(295, 138);
            this.txtIdentificacion.MaxLength = 15;
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(143, 20);
            this.txtIdentificacion.TabIndex = 5;
            this.txtIdentificacion.Visible = false;
            this.txtIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacion_KeyPress);
            // 
            // cmbTipoIdentificacion
            // 
            this.cmbTipoIdentificacion.DataSource = this.tIpoIdentificacionBindingSource;
            this.cmbTipoIdentificacion.DisplayMember = "Descripcion";
            this.cmbTipoIdentificacion.FormattingEnabled = true;
            this.cmbTipoIdentificacion.Location = new System.Drawing.Point(126, 137);
            this.cmbTipoIdentificacion.Name = "cmbTipoIdentificacion";
            this.cmbTipoIdentificacion.Size = new System.Drawing.Size(85, 21);
            this.cmbTipoIdentificacion.TabIndex = 4;
            this.cmbTipoIdentificacion.ValueMember = "Tipo";
            // 
            // tIpoIdentificacionBindingSource
            // 
            this.tIpoIdentificacionBindingSource.DataSource = typeof(InfoContactoClientes.TIpoIdentificacion);
            // 
            // CboParentezco
            // 
            this.CboParentezco.DisplayMember = "Tipo";
            this.CboParentezco.FormattingEnabled = true;
            this.CboParentezco.Location = new System.Drawing.Point(120, 300);
            this.CboParentezco.Name = "CboParentezco";
            this.CboParentezco.Size = new System.Drawing.Size(317, 21);
            this.CboParentezco.TabIndex = 29;
            this.CboParentezco.ValueMember = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Parentezco";
            // 
            // BtnDireccion
            // 
            this.BtnDireccion.Location = new System.Drawing.Point(408, 271);
            this.BtnDireccion.Name = "BtnDireccion";
            this.BtnDireccion.Size = new System.Drawing.Size(29, 23);
            this.BtnDireccion.TabIndex = 33;
            this.BtnDireccion.Text = "...";
            this.BtnDireccion.UseVisualStyleBackColor = true;
            this.BtnDireccion.Click += new System.EventHandler(this.BtnDireccion_Click);
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Location = new System.Drawing.Point(120, 271);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(289, 20);
            this.TxtDireccion.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Dirección";
            // 
            // CboLocalidad
            // 
            this.CboLocalidad.DisplayMember = "Tipo";
            this.CboLocalidad.FormattingEnabled = true;
            this.CboLocalidad.Location = new System.Drawing.Point(120, 242);
            this.CboLocalidad.Name = "CboLocalidad";
            this.CboLocalidad.Size = new System.Drawing.Size(317, 21);
            this.CboLocalidad.TabIndex = 27;
            this.CboLocalidad.ValueMember = "Tipo";
            // 
            // LblLocalidad
            // 
            this.LblLocalidad.AutoSize = true;
            this.LblLocalidad.Location = new System.Drawing.Point(30, 242);
            this.LblLocalidad.Name = "LblLocalidad";
            this.LblLocalidad.Size = new System.Drawing.Size(34, 13);
            this.LblLocalidad.TabIndex = 31;
            this.LblLocalidad.Text = "Barrio";
            // 
            // CboCiudad
            // 
            this.CboCiudad.DataSource = this.tIpoIdentificacionBindingSource;
            this.CboCiudad.DisplayMember = "Descripcion";
            this.CboCiudad.FormattingEnabled = true;
            this.CboCiudad.Location = new System.Drawing.Point(120, 213);
            this.CboCiudad.Name = "CboCiudad";
            this.CboCiudad.Size = new System.Drawing.Size(317, 21);
            this.CboCiudad.TabIndex = 26;
            this.CboCiudad.ValueMember = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Ciudad";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(123, 110);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(315, 20);
            this.txtTelefono.TabIndex = 3;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // FrmContactoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 399);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.CboParentezco);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnDireccion);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CboLocalidad);
            this.Controls.Add(this.LblLocalidad);
            this.Controls.Add(this.CboCiudad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTipoIdentificacion);
            this.Controls.Add(this.lblIdentificacion);
            this.Controls.Add(this.lblTipoIdentificacion);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.lblNombreContacto);
            this.Controls.Add(this.txtNombreContacto);
            this.Controls.Add(this.chkHabeasData);
            this.Controls.Add(this.oldtxtTelefono_);
            this.Controls.Add(this.lblInfoAdicional);
            this.Controls.Add(this.txtInfoAdicional);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblFechaCumpleaños);
            this.Controls.Add(this.dtpFechaCumpleaños);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cmbTIpoContacto);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmContactoUpdate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actualizar Contacto";
            this.Load += new System.EventHandler(this.FrmContacto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oldtxtTelefono_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIpoIdentificacionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTIpoContacto;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.DateTimePicker dtpFechaCumpleaños;
        private System.Windows.Forms.Label lblFechaCumpleaños;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblInfoAdicional;
        private System.Windows.Forms.TextBox txtInfoAdicional;
        private System.Windows.Forms.NumericUpDown oldtxtTelefono_;
        private System.Windows.Forms.CheckBox chkHabeasData;
        private System.Windows.Forms.Label lblNombreContacto;
        private System.Windows.Forms.TextBox txtNombreContacto;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.Label lblTipoIdentificacion;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.ComboBox cmbTipoIdentificacion;
        private System.Windows.Forms.BindingSource tIpoIdentificacionBindingSource;
        private System.Windows.Forms.ComboBox CboParentezco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnDireccion;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CboLocalidad;
        private System.Windows.Forms.Label LblLocalidad;
        private System.Windows.Forms.ComboBox CboCiudad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTelefono;
    }
}