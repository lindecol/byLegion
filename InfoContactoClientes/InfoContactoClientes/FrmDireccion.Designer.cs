
namespace InfoContactoClientes
{
    partial class FrmDireccion
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
            this.GpoDireccion = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.CboNotacion = new System.Windows.Forms.ComboBox();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSalida = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.GpoDireccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // GpoDireccion
            // 
            this.GpoDireccion.Controls.Add(this.TxtValor);
            this.GpoDireccion.Controls.Add(this.CboNotacion);
            this.GpoDireccion.Controls.Add(this.BtnEliminar);
            this.GpoDireccion.Controls.Add(this.BtnAceptar);
            this.GpoDireccion.Controls.Add(this.label2);
            this.GpoDireccion.Controls.Add(this.label1);
            this.GpoDireccion.Location = new System.Drawing.Point(12, 12);
            this.GpoDireccion.Name = "GpoDireccion";
            this.GpoDireccion.Size = new System.Drawing.Size(324, 115);
            this.GpoDireccion.TabIndex = 0;
            this.GpoDireccion.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Notación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor:";
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(28, 79);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(112, 23);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "&Adicionar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(180, 79);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(112, 23);
            this.BtnEliminar.TabIndex = 3;
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // CboNotacion
            // 
            this.CboNotacion.FormattingEnabled = true;
            this.CboNotacion.Location = new System.Drawing.Point(75, 20);
            this.CboNotacion.Name = "CboNotacion";
            this.CboNotacion.Size = new System.Drawing.Size(231, 21);
            this.CboNotacion.TabIndex = 4;
            // 
            // TxtValor
            // 
            this.TxtValor.Location = new System.Drawing.Point(75, 48);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(231, 20);
            this.TxtValor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dirección:";
            // 
            // TxtSalida
            // 
            this.TxtSalida.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.TxtSalida.Location = new System.Drawing.Point(89, 130);
            this.TxtSalida.Name = "TxtSalida";
            this.TxtSalida.Size = new System.Drawing.Size(231, 20);
            this.TxtSalida.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(324, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "&Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmDireccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 198);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtSalida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GpoDireccion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDireccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Direccion";
            this.GpoDireccion.ResumeLayout(false);
            this.GpoDireccion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GpoDireccion;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.ComboBox CboNotacion;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtSalida;
        private System.Windows.Forms.Button button1;
    }
}