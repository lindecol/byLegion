namespace InfoContactoClientes
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.grvContactosMedicinales = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarContactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inactivarContactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbHabeasData = new System.Windows.Forms.TabControl();
            this.tbpMedicinal = new System.Windows.Forms.TabPage();
            this.tbPIndustrial = new System.Windows.Forms.TabPage();
            this.grvContactosIndustriales = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grvHabeasData = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoContactoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCumpleanosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tipoContactoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habeasDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactoBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tipoContactoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono_info_adicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreLocalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parentezco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreParentezco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvContactosMedicinales)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tbHabeasData.SuspendLayout();
            this.tbpMedicinal.SuspendLayout();
            this.tbPIndustrial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvContactosIndustriales)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvHabeasData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactoBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1110, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(122, 22);
            this.toolStripButton1.Text = "Agregar Registro";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // grvContactosMedicinales
            // 
            this.grvContactosMedicinales.AllowUserToAddRows = false;
            this.grvContactosMedicinales.AllowUserToDeleteRows = false;
            this.grvContactosMedicinales.AutoGenerateColumns = false;
            this.grvContactosMedicinales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvContactosMedicinales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoContactoDataGridViewTextBoxColumn,
            this.NombreContacto,
            this.emailDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.Telefono_info_adicional,
            this.ciudadDataGridViewTextBoxColumn,
            this.NombreCiudad,
            this.Localidad,
            this.NombreLocalidad,
            this.Direccion,
            this.Parentezco,
            this.NombreParentezco,
            this.FechaModificacion});
            this.grvContactosMedicinales.ContextMenuStrip = this.contextMenuStrip1;
            this.grvContactosMedicinales.DataSource = this.contactoBindingSource;
            this.grvContactosMedicinales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvContactosMedicinales.Location = new System.Drawing.Point(3, 3);
            this.grvContactosMedicinales.Name = "grvContactosMedicinales";
            this.grvContactosMedicinales.ReadOnly = true;
            this.grvContactosMedicinales.Size = new System.Drawing.Size(1096, 181);
            this.grvContactosMedicinales.TabIndex = 1;
            this.grvContactosMedicinales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvContactosMedicinales_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarContactoToolStripMenuItem,
            this.inactivarContactoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // modificarContactoToolStripMenuItem
            // 
            this.modificarContactoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.modificarContactoToolStripMenuItem.Image = global::InfoContactoClientes.Properties.Resources.if_system_software_update_24350;
            this.modificarContactoToolStripMenuItem.Name = "modificarContactoToolStripMenuItem";
            this.modificarContactoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modificarContactoToolStripMenuItem.Text = "Modificar Contacto";
            this.modificarContactoToolStripMenuItem.Click += new System.EventHandler(this.modificarContactoToolStripMenuItem_Click);
            // 
            // inactivarContactoToolStripMenuItem
            // 
            this.inactivarContactoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.inactivarContactoToolStripMenuItem.Image = global::InfoContactoClientes.Properties.Resources.if_minus_1645995;
            this.inactivarContactoToolStripMenuItem.Name = "inactivarContactoToolStripMenuItem";
            this.inactivarContactoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inactivarContactoToolStripMenuItem.Text = "Inactivar Contacto";
            this.inactivarContactoToolStripMenuItem.Click += new System.EventHandler(this.inactivarContactoToolStripMenuItem_Click);
            // 
            // tbHabeasData
            // 
            this.tbHabeasData.Controls.Add(this.tbpMedicinal);
            this.tbHabeasData.Controls.Add(this.tbPIndustrial);
            this.tbHabeasData.Controls.Add(this.tabPage1);
            this.tbHabeasData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbHabeasData.Location = new System.Drawing.Point(0, 25);
            this.tbHabeasData.Name = "tbHabeasData";
            this.tbHabeasData.SelectedIndex = 0;
            this.tbHabeasData.Size = new System.Drawing.Size(1110, 213);
            this.tbHabeasData.TabIndex = 2;
            // 
            // tbpMedicinal
            // 
            this.tbpMedicinal.Controls.Add(this.grvContactosMedicinales);
            this.tbpMedicinal.Location = new System.Drawing.Point(4, 22);
            this.tbpMedicinal.Name = "tbpMedicinal";
            this.tbpMedicinal.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMedicinal.Size = new System.Drawing.Size(1102, 187);
            this.tbpMedicinal.TabIndex = 0;
            this.tbpMedicinal.Text = "Contactos Medicinales";
            this.tbpMedicinal.UseVisualStyleBackColor = true;
            // 
            // tbPIndustrial
            // 
            this.tbPIndustrial.Controls.Add(this.grvContactosIndustriales);
            this.tbPIndustrial.Location = new System.Drawing.Point(4, 22);
            this.tbPIndustrial.Name = "tbPIndustrial";
            this.tbPIndustrial.Padding = new System.Windows.Forms.Padding(3);
            this.tbPIndustrial.Size = new System.Drawing.Size(1102, 187);
            this.tbPIndustrial.TabIndex = 1;
            this.tbPIndustrial.Text = "Contactos Industriales";
            this.tbPIndustrial.UseVisualStyleBackColor = true;
            // 
            // grvContactosIndustriales
            // 
            this.grvContactosIndustriales.AllowUserToAddRows = false;
            this.grvContactosIndustriales.AutoGenerateColumns = false;
            this.grvContactosIndustriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvContactosIndustriales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoContactoDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.emailDataGridViewTextBoxColumn1,
            this.fechaCumpleanosDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.grvContactosIndustriales.ContextMenuStrip = this.contextMenuStrip1;
            this.grvContactosIndustriales.DataSource = this.contactoBindingSource1;
            this.grvContactosIndustriales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvContactosIndustriales.Location = new System.Drawing.Point(3, 3);
            this.grvContactosIndustriales.Name = "grvContactosIndustriales";
            this.grvContactosIndustriales.ReadOnly = true;
            this.grvContactosIndustriales.Size = new System.Drawing.Size(1096, 181);
            this.grvContactosIndustriales.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NombreContacto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre Contacto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Telefono_info_adicional";
            this.dataGridViewTextBoxColumn2.HeaderText = "Telefono info adicional";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grvHabeasData);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1102, 187);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Habeas Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grvHabeasData
            // 
            this.grvHabeasData.AllowUserToAddRows = false;
            this.grvHabeasData.AllowUserToDeleteRows = false;
            this.grvHabeasData.AutoGenerateColumns = false;
            this.grvHabeasData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvHabeasData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoContactoDataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.NumeroIdentificacion,
            this.habeasDataDataGridViewTextBoxColumn});
            this.grvHabeasData.ContextMenuStrip = this.contextMenuStrip1;
            this.grvHabeasData.DataSource = this.contactoBindingSource2;
            this.grvHabeasData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvHabeasData.Location = new System.Drawing.Point(3, 3);
            this.grvHabeasData.Name = "grvHabeasData";
            this.grvHabeasData.ReadOnly = true;
            this.grvHabeasData.Size = new System.Drawing.Size(1096, 181);
            this.grvHabeasData.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NombreContacto";
            this.dataGridViewTextBoxColumn3.HeaderText = "Persona que acepta tratamiento de informacion";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // NumeroIdentificacion
            // 
            this.NumeroIdentificacion.DataPropertyName = "NumeroIdentificacion";
            this.NumeroIdentificacion.HeaderText = "Numero Identificacion";
            this.NumeroIdentificacion.Name = "NumeroIdentificacion";
            this.NumeroIdentificacion.ReadOnly = true;
            this.NumeroIdentificacion.Width = 150;
            // 
            // contactoBindingSource
            // 
            this.contactoBindingSource.DataSource = typeof(InfoContactoClientes.Contacto);
            this.contactoBindingSource.CurrentChanged += new System.EventHandler(this.contactoBindingSource_CurrentChanged);
            // 
            // tipoContactoDataGridViewTextBoxColumn1
            // 
            this.tipoContactoDataGridViewTextBoxColumn1.DataPropertyName = "TipoContacto";
            this.tipoContactoDataGridViewTextBoxColumn1.HeaderText = "TipoContacto";
            this.tipoContactoDataGridViewTextBoxColumn1.Name = "tipoContactoDataGridViewTextBoxColumn1";
            this.tipoContactoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.tipoContactoDataGridViewTextBoxColumn1.Width = 200;
            // 
            // emailDataGridViewTextBoxColumn1
            // 
            this.emailDataGridViewTextBoxColumn1.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn1.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn1.Name = "emailDataGridViewTextBoxColumn1";
            this.emailDataGridViewTextBoxColumn1.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn1.Width = 150;
            // 
            // fechaCumpleanosDataGridViewTextBoxColumn
            // 
            this.fechaCumpleanosDataGridViewTextBoxColumn.DataPropertyName = "FechaCumpleanos";
            dataGridViewCellStyle1.Format = "M";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaCumpleanosDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaCumpleanosDataGridViewTextBoxColumn.HeaderText = "FechaCumpleanos";
            this.fechaCumpleanosDataGridViewTextBoxColumn.Name = "fechaCumpleanosDataGridViewTextBoxColumn";
            this.fechaCumpleanosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoDataGridViewTextBoxColumn1
            // 
            this.telefonoDataGridViewTextBoxColumn1.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn1.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn1.Name = "telefonoDataGridViewTextBoxColumn1";
            this.telefonoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.telefonoDataGridViewTextBoxColumn1.Width = 150;
            // 
            // contactoBindingSource1
            // 
            this.contactoBindingSource1.DataSource = typeof(InfoContactoClientes.Contacto);
            // 
            // tipoContactoDataGridViewTextBoxColumn2
            // 
            this.tipoContactoDataGridViewTextBoxColumn2.DataPropertyName = "TipoContacto";
            this.tipoContactoDataGridViewTextBoxColumn2.HeaderText = "TipoContacto";
            this.tipoContactoDataGridViewTextBoxColumn2.Name = "tipoContactoDataGridViewTextBoxColumn2";
            this.tipoContactoDataGridViewTextBoxColumn2.ReadOnly = true;
            this.tipoContactoDataGridViewTextBoxColumn2.Width = 250;
            // 
            // habeasDataDataGridViewTextBoxColumn
            // 
            this.habeasDataDataGridViewTextBoxColumn.DataPropertyName = "HabeasData";
            this.habeasDataDataGridViewTextBoxColumn.HeaderText = "Acepta";
            this.habeasDataDataGridViewTextBoxColumn.Name = "habeasDataDataGridViewTextBoxColumn";
            this.habeasDataDataGridViewTextBoxColumn.ReadOnly = true;
            this.habeasDataDataGridViewTextBoxColumn.Width = 80;
            // 
            // contactoBindingSource2
            // 
            this.contactoBindingSource2.DataSource = typeof(InfoContactoClientes.Contacto);
            // 
            // tipoContactoDataGridViewTextBoxColumn
            // 
            this.tipoContactoDataGridViewTextBoxColumn.DataPropertyName = "TipoContacto";
            this.tipoContactoDataGridViewTextBoxColumn.HeaderText = "TipoContacto";
            this.tipoContactoDataGridViewTextBoxColumn.Name = "tipoContactoDataGridViewTextBoxColumn";
            this.tipoContactoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoContactoDataGridViewTextBoxColumn.Width = 200;
            // 
            // NombreContacto
            // 
            this.NombreContacto.DataPropertyName = "NombreContacto";
            this.NombreContacto.HeaderText = "Nombre Contacto";
            this.NombreContacto.Name = "NombreContacto";
            this.NombreContacto.ReadOnly = true;
            this.NombreContacto.Width = 300;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 150;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            this.telefonoDataGridViewTextBoxColumn.Width = 150;
            // 
            // Telefono_info_adicional
            // 
            this.Telefono_info_adicional.DataPropertyName = "Telefono_info_adicional";
            this.Telefono_info_adicional.HeaderText = "Telefono info ad";
            this.Telefono_info_adicional.Name = "Telefono_info_adicional";
            this.Telefono_info_adicional.ReadOnly = true;
            this.Telefono_info_adicional.Visible = false;
            // 
            // ciudadDataGridViewTextBoxColumn
            // 
            this.ciudadDataGridViewTextBoxColumn.DataPropertyName = "Ciudad";
            this.ciudadDataGridViewTextBoxColumn.HeaderText = "Ciudad";
            this.ciudadDataGridViewTextBoxColumn.Name = "ciudadDataGridViewTextBoxColumn";
            this.ciudadDataGridViewTextBoxColumn.ReadOnly = true;
            this.ciudadDataGridViewTextBoxColumn.Visible = false;
            // 
            // NombreCiudad
            // 
            this.NombreCiudad.DataPropertyName = "NombreCiudad";
            this.NombreCiudad.HeaderText = "Nombre Ciudad";
            this.NombreCiudad.Name = "NombreCiudad";
            this.NombreCiudad.ReadOnly = true;
            // 
            // Localidad
            // 
            this.Localidad.DataPropertyName = "Localidad";
            this.Localidad.HeaderText = "Barrio";
            this.Localidad.Name = "Localidad";
            this.Localidad.ReadOnly = true;
            this.Localidad.Visible = false;
            // 
            // NombreLocalidad
            // 
            this.NombreLocalidad.DataPropertyName = "NombreLocalidad";
            this.NombreLocalidad.HeaderText = "Nombre Barrio";
            this.NombreLocalidad.Name = "NombreLocalidad";
            this.NombreLocalidad.ReadOnly = true;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "Direccion";
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            // 
            // Parentezco
            // 
            this.Parentezco.DataPropertyName = "Parentezco";
            this.Parentezco.HeaderText = "Parentezco";
            this.Parentezco.Name = "Parentezco";
            this.Parentezco.ReadOnly = true;
            this.Parentezco.Visible = false;
            // 
            // NombreParentezco
            // 
            this.NombreParentezco.DataPropertyName = "NombreParentezco";
            this.NombreParentezco.HeaderText = "Nombre Parentezco";
            this.NombreParentezco.Name = "NombreParentezco";
            this.NombreParentezco.ReadOnly = true;
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "FechaModificacion";
            this.FechaModificacion.HeaderText = "FechaModificacion";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 238);
            this.Controls.Add(this.tbHabeasData);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Informacion de contacto";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvContactosMedicinales)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tbHabeasData.ResumeLayout(false);
            this.tbpMedicinal.ResumeLayout(false);
            this.tbPIndustrial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvContactosIndustriales)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvHabeasData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactoBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView grvContactosMedicinales;
        private System.Windows.Forms.TabControl tbHabeasData;
        private System.Windows.Forms.TabPage tbpMedicinal;
        private System.Windows.Forms.TabPage tbPIndustrial;
        private System.Windows.Forms.DataGridView grvContactosIndustriales;
        private System.Windows.Forms.BindingSource contactoBindingSource;
        private System.Windows.Forms.BindingSource contactoBindingSource1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modificarContactoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inactivarContactoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoContactoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCumpleanosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grvHabeasData;
        private System.Windows.Forms.BindingSource contactoBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoContactoDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn habeasDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoContactoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono_info_adicional;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreLocalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parentezco;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreParentezco;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
    }
}

