using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InfoContactoClientes
{
    public partial class FrmDireccion : Form
    {
        public string Direccion { get; set; }

        public FrmDireccion()
        {
            InitializeComponent();
            this.CboNotacion.DataSource = Notacion.CargarNotaciones();
            this.CboNotacion.ValueMember = "Id";
            this.CboNotacion.DisplayMember = "NombreNotacion";

            this.CboNotacion.SelectedValue = -1;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            int index = 0;
            string valor = "";
            string mensaje = "";
            string espacio = "";
            index = CboNotacion.SelectedIndex;
            valor = TxtValor.Text;


            if (index == 0)
                mensaje += "\nDebe seleccionar una notación para poder adicionar";
            if (valor.Equals(string.Empty))
                mensaje += "\nDebe seleccionar un valor para la notación para poder adicionar";

            if (!mensaje.Equals(string.Empty)){
                MessageBox.Show(mensaje, "Direcciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                if (TxtSalida.Text.Equals(string.Empty))
                    espacio = "";
                else
                    espacio = " ";
                TxtSalida.Text += espacio + CboNotacion.Text + " " + valor;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea borraqr la notación?", "Direccion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rta == DialogResult.Yes) {
                TxtSalida.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Direccion = TxtSalida.Text;
            this.Close();
        }
    }
}
