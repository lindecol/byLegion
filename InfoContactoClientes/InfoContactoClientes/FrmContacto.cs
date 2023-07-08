using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace InfoContactoClientes
{
    public partial class FrmContacto : Form
    {
        bool _cargarForma = true;
        public FrmContacto(List<Contacto> lista)
        {
            InitializeComponent();
            _lista = lista;
            //MessageBox.Show(_cargarForma.ToString());
        }

     

        List<Contacto> _lista;

        private void FrmContacto_Load(object sender, EventArgs e)
        {
            List<TIpoIdentificacion> ds = ContactoDao.ConsultarTipoIdentificacion();

           tIpoIdentificacionBindingSource.DataSource = ds;
            //   this.cmbTIpoContacto.ValueMember = "Tipo";
            //    this.cmbTIpoContacto.DisplayMember = "Descripcion";

            this.cmbTIpoContacto.DataSource = ParametrosIniciales.TiposContactos;
            this.cmbTIpoContacto.ValueMember = "IdTipoContacto";
            this.cmbTIpoContacto.DisplayMember = "Descripcion";


            this.CboCiudad.DataSource = Ciudad.CargarCiudades();
            this.CboCiudad.ValueMember = "id";
            this.CboCiudad.DisplayMember = "nombreCiudad";

            this.CboLocalidad.DataSource = Localidad.CargarLocalidades();
            this.CboLocalidad.ValueMember = "id";
            this.CboLocalidad.DisplayMember = "nombreLocalidad";

            this.CboParentezco.DataSource = Parentezco.CargarParemtezco();
            this.CboParentezco.ValueMember = "id";
            this.CboParentezco.DisplayMember = "NombreParentezco";

            this.CboCiudad.SelectedValue = -1;
            this.CboLocalidad.SelectedValue = -1;
            this.CboParentezco.SelectedValue = -1;

            this.txtTelefono.Visible = false;

            if (_cargarForma == true)
            {
                _cargarForma = false;
                return;
            }


            /*
            if (ParametrosIniciales.TIpoCliente=="M")
            {
                dtpFechaCumpleaños.Visible = false;
                lblFechaCumpleaños.Visible = false;


            }
            else
            {
                dtpFechaCumpleaños.Visible = true;
                lblFechaCumpleaños.Visible = true;
            }*/
        }




        private void cmbTIpoContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargarForma == true)
            {
                lblNombreContacto.Visible = false;
                txtNombreContacto.Visible = false;
                lblEmail.Visible = false;
                txtEmail.Visible = false;
                lblTelefono.Visible = false;
                txtTelefono.Visible = false;
                lblTipoIdentificacion.Visible = false;
                cmbTipoIdentificacion.Visible = false;
                txtInfoAdicional.Visible = false;
                txtIdentificacion.Visible = false;
                lblIdentificacion.Visible = false;
                chkHabeasData.Visible = false;
                lblFechaCumpleaños.Visible = false;
                dtpFechaCumpleaños.Visible = false;
                label2.Visible = false;
                CboCiudad.Visible = false;
                LblLocalidad.Visible = false;
                CboLocalidad.Visible = false;
                label3.Visible = false;
                TxtDireccion.Visible = false;
                BtnDireccion.Visible = false;
                label4.Visible = false;
                CboParentezco.Visible = false;
                button1.Enabled = false;
                lblInfoAdicional.Visible = false;
                txtTelefono.Visible = false;
                return;
            }
            else
            {
                button1.Enabled = true;
            }
                

            var tipoContacto = ((TipoContacto)this.cmbTIpoContacto.SelectedItem).IdTipoContacto;

            //SI EL TIPO DE CONTACTO ES DATOS PACIENTE

            limpiarControles();




            label2.Visible = false;
            LblLocalidad.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            CboCiudad.Visible = false;
            CboLocalidad.Visible = false;
            TxtDireccion.Visible = false;
            BtnDireccion.Visible = false;
            CboParentezco.Visible = false;

            lblInfoAdicional.Visible = false;
            txtInfoAdicional.Visible = false;

            lblTelefono.Text = "Teléfono";
            lblNombreContacto.Text = "Nombres:";

            lblInfoAdicional.Visible = false;
            txtInfoAdicional.Visible = false;


            if (tipoContacto ==1 || 
                tipoContacto == 2 || 
                tipoContacto == 3 || 
                tipoContacto == 4 || 
                tipoContacto == 5||
                 tipoContacto == 11)
            {

                lblNombreContacto.Visible = true;
                txtNombreContacto.Visible = true;
                lblEmail.Visible = true;
                txtEmail.Visible = true;
                lblTelefono.Visible = true;
                txtTelefono.Visible = true;
                lblInfoAdicional.Visible = true;
                txtInfoAdicional.Visible = true;
                dtpFechaCumpleaños.Visible = true;
                lblFechaCumpleaños.Visible = true;

                chkHabeasData.Visible = false;
                lblTipoIdentificacion.Visible = false;
                cmbTipoIdentificacion.Visible = false;
                lblIdentificacion.Visible = false;
                txtIdentificacion.Visible = false;


            }
            if (tipoContacto == 6)
            {

                int contador = 0;
                try
                {
                    contador = _lista.Where(p => p.IdTipoContacto == 6).ToList().Count;
                }

                catch (Exception ex)
                {
                    throw;
                }
                if (contador > 0)
                {
                    MessageBox.Show("No puede agregar un nuevo registro de datos paciente, intente editar el registro ya existente", "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Dispose();
                    return;
                }

                lblTelefono.Visible = true;
                txtTelefono.Visible = true;
                txtNombreContacto.Visible = false;
                lblNombreContacto.Visible = false;
                chkHabeasData.Visible = false;

                lblTipoIdentificacion.Visible = false;
                cmbTipoIdentificacion.Visible = false;
                lblIdentificacion.Visible = false;
                txtIdentificacion.Visible = false;
                lblEmail.Visible = false;
                txtEmail.Visible = false;

                CboCiudad.Visible = false;
                label2.Visible = false;
                LblLocalidad.Visible = false;
                CboLocalidad.Visible = false;
                label3.Visible = false;
                TxtDireccion.Visible = false;
                BtnDireccion.Visible = false;

                label4.Visible = false;
                CboParentezco.Visible = false;
                chkHabeasData.Visible = false;

                lblNombreContacto.Text = "Nombres";
                lblEmail.Visible = false;
                txtEmail.Visible = false;
                lblInfoAdicional.Visible = false;
                txtInfoAdicional.Visible = false;


            }
            //si el tipo de contacto es habeas data
            if (tipoContacto==10|| tipoContacto == 12)
            {
                int contador = 0;
                try
                {
                 contador = _lista.Where(p => p.IdTipoContacto == 10 || p.IdTipoContacto == 12).ToList().Count;
                }

                catch (Exception ex)
                {
                    throw;
                }
                if (contador > 0)
                {
                    MessageBox.Show("No puede agregar un nuevo registro de habeas data, intente editar el registro ya existente", "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Dispose();
                }
                else
                {
                    chkHabeasData.Visible = true;

                    lblNombreContacto.Visible = true;
                    txtNombreContacto.Visible = true;

                    lblNombreContacto.Text = "Persona que acepta";

                    lblTipoIdentificacion.Visible = true;
                    cmbTipoIdentificacion.Visible = true;
                    lblIdentificacion.Visible = true;
                    txtIdentificacion.Visible = true;


                    lblTelefono.Visible = true;
                    lblTelefono.Text = "Teléfono Celular";
                    txtTelefono.Visible = true;

                    lblEmail.Visible = true;
                    txtEmail.Visible = true;

                    lblInfoAdicional.Visible = false;
                    txtInfoAdicional.Visible = false;
                    dtpFechaCumpleaños.Visible = false;
                    this.lblFechaCumpleaños.Visible = false;
                }
            }

            if (tipoContacto == 7)
            {
                int contador = 0;
                try
                {
                    contador = _lista.Where(p => p.IdTipoContacto == 7).ToList().Count;
                }

                catch (Exception ex)
                {
                    throw;
                }
                if (contador > 0)
                {
                    MessageBox.Show("No puede agregar un nuevo registro de datos responsable paciente, intente editar el registro ya existente", "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Dispose();
                    return;
                }

                chkHabeasData.Visible = false;
                lblTipoIdentificacion.Visible = false;
                cmbTipoIdentificacion.Visible = false;
                lblIdentificacion.Visible = false;
                txtIdentificacion.Visible = false;

                lblNombreContacto.Text = "Nombres y apellidos";
                lblNombreContacto.Visible = true;
                txtNombreContacto.Visible = true;
                lblEmail.Visible = false;
                txtEmail.Visible = false;
                lblTelefono.Visible = true;
                txtTelefono.Visible = true;

                dtpFechaCumpleaños.Visible = false;
                lblFechaCumpleaños.Visible = false;

                label1.Visible = true;
                label2.Visible = true;
                LblLocalidad.Visible = true;
                label3.Visible = true;
                label4.Visible = true;

                CboCiudad.Visible = true;
                CboLocalidad.Visible = true;
                TxtDireccion.Visible = true;
                BtnDireccion.Visible = true;
                CboParentezco.Visible = true;
            }

            if (tipoContacto == 8)
            {
                int contador = 0;
                try
                {
                    contador = _lista.Where(p => p.IdTipoContacto == 8).ToList().Count;
                }

                catch (Exception ex)
                {
                    throw;
                }
                if (contador > 0)
                {
                    MessageBox.Show("No puede agregar un nuevo registro de otro contacto paciente, intente editar el registro ya existente", "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Dispose();
                    return;
                }

                chkHabeasData.Visible = false;
                lblTipoIdentificacion.Visible = false;
                cmbTipoIdentificacion.Visible = false;
                lblIdentificacion.Visible = false;
                txtIdentificacion.Visible = false;

                lblNombreContacto.Visible = true;
                txtNombreContacto.Visible = true;
                lblEmail.Visible = false;
                txtEmail.Visible = false;
                lblTelefono.Visible = true;
                txtTelefono.Visible = true;
                lblInfoAdicional.Visible = false;
                txtInfoAdicional.Visible = false;

                dtpFechaCumpleaños.Visible = false;
                lblFechaCumpleaños.Visible = false;

                label2.Visible = true;
                LblLocalidad.Visible = false;
                label3.Visible = false;
                label4.Visible = false;

                CboCiudad.Visible = true;
                CboLocalidad.Visible = false;
                TxtDireccion.Visible = false;
                BtnDireccion.Visible = false;
                CboParentezco.Visible = false;
            }

            if (tipoContacto == 9)
            {
                int contador = 0;
                try
                {
                    contador = _lista.Where(p => p.IdTipoContacto == 8).ToList().Count;
                }

                catch (Exception ex)
                {
                    throw;
                }
                if (contador > 0)
                {
                    MessageBox.Show("No puede agregar un nuevo registro de contacto pagos en línea, intente editar el registro ya existente", "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Dispose();
                    return;
                }
                chkHabeasData.Visible = false;
                lblTipoIdentificacion.Visible = false;
                cmbTipoIdentificacion.Visible = false;
                lblIdentificacion.Visible = false;
                txtIdentificacion.Visible = false;

                lblNombreContacto.Visible = true;
                txtNombreContacto.Visible = true;
                lblEmail.Visible = true;
                txtEmail.Visible = true;
                lblTelefono.Visible = true;
                txtTelefono.Visible = true;
                lblInfoAdicional.Visible = true;
                txtInfoAdicional.Visible = true;

                dtpFechaCumpleaños.Visible = false;
                lblFechaCumpleaños.Visible = false;

                label2.Visible = true;
                LblLocalidad.Visible = false;
                label3.Visible = false;
                label4.Visible = false;

                CboCiudad.Visible = true;
                CboLocalidad.Visible = false;
                TxtDireccion.Visible = false;
                BtnDireccion.Visible = false;
                CboParentezco.Visible = false;
            }

        }

        private void limpiarControles()
        {
            txtEmail.Text = "";
            txtIdentificacion.Text = "";
            txtInfoAdicional.Text = "";
            txtNombreContacto.Text = "";
            txtTelefono.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!ParametrosIniciales.ValidarCorreo(this.txtEmail.Text) && this.txtEmail.Visible)
            {
                MessageBox.Show("Formato de correo electronico invalido");
                return;
            }


            if ((txtTelefono.Text.ToString().Length <7 || txtTelefono.Text.ToString().Length > 10) && txtTelefono.Visible)
            {
                MessageBox.Show("Formato de Telefono Invalido");
                return;
            }

            if (txtIdentificacion.Text.Length==0 && txtIdentificacion.Visible)
            {
                MessageBox.Show("Debe ingresar el numero de identificacion de la persona que acepta");
                return;

            }

            //Legion
            if (txtNombreContacto.Text.Length == 0 && txtNombreContacto.Visible)
            {
                MessageBox.Show("Debe ingresar el nombre del contacto");
                return;
            }

            if (cmbTipoIdentificacion.SelectedIndex == -1 && cmbTipoIdentificacion.Visible) {
                MessageBox.Show("Debe tipo de seleccionar tipo de identificación ");
                return;
            }

            //MessageBox.Show ("c->" + this.CboCiudad.SelectedIndex + "\nl->" + this.CboLocalidad.SelectedIndex + "\nd->" + this.TxtDireccion.Text + "\np->" + CboParentezco.SelectedIndex);
            var telefonoCompleto = "";
            if (ParametrosIniciales.TIpoCliente == "I")
            {
                if (!txtInfoAdicional.Text.Equals(string.Empty))
                {
                    telefonoCompleto = txtTelefono.Text.ToString() + " EXT " + txtInfoAdicional.Text;
                }
                else
                    telefonoCompleto = txtTelefono.Text.ToString();
            }
            else
            {
                telefonoCompleto = txtTelefono.Text.ToString();
                var tipoContacto = ((TipoContacto)this.cmbTIpoContacto.SelectedItem).IdTipoContacto;
                if (tipoContacto == 10 || tipoContacto == 12) {
                    if (txtTelefono.Text.ToString().Length != 10) {
                        MessageBox.Show("En Habes data, el teléfono de contacto debe tener 10 dígitos");
                        return;
                    }
                }
            }

                

                if (ParametrosIniciales.TIpoCliente == "I")
            {
                ContactoDao.InsertarContacto(new InfoContactoClientes.Contacto
                {
                    Email = txtEmail.Text,
                    FechaCumpleanos = dtpFechaCumpleaños.Value,
                    IdTipoContacto = ((TipoContacto)cmbTIpoContacto.SelectedItem).IdTipoContacto,
                    codi_cli = ParametrosIniciales.CodigoCliente,
                    NombreContacto = txtNombreContacto.Text,
                    Telefono = telefonoCompleto,
                    Telefono_info_adicional = txtInfoAdicional.Text,
                    HabeasData = chkHabeasData.Checked == true ? "S" : "N",
                    NumeroIdentificacion = this.txtIdentificacion.Text,
                    TipoIdentificacion = ((TIpoIdentificacion)this.cmbTipoIdentificacion.SelectedItem).Tipo,
                    Ciudad = int.Parse(this.CboCiudad.SelectedValue.ToString()),
                    Localidad = int.Parse(this.CboLocalidad.SelectedValue.ToString()),
                    Direccion = TxtDireccion.Text,
                    Parentezco = int.Parse(CboParentezco.SelectedValue.ToString())
                });
            }
            else
            {
                ContactoDao.InsertarContacto(new InfoContactoClientes.Contacto
                {
                    Email = txtEmail.Text,
                    FechaCumpleanos = dtpFechaCumpleaños.Value,
                    IdTipoContacto = ((TipoContacto)cmbTIpoContacto.SelectedItem).IdTipoContacto,
                    codi_cli = ParametrosIniciales.CodigoCliente,
                    NombreContacto = txtNombreContacto.Text,
                    Telefono = telefonoCompleto,
                    Telefono_info_adicional = txtInfoAdicional.Text,
                    HabeasData = chkHabeasData.Checked == true ? "S" : "N",
                    NumeroIdentificacion = this.txtIdentificacion.Text,
                    TipoIdentificacion = ((TIpoIdentificacion)this.cmbTipoIdentificacion.SelectedItem).Tipo,
                    Ciudad = int.Parse(this.CboCiudad.SelectedValue.ToString()),
                    Localidad = int.Parse(this.CboLocalidad.SelectedValue.ToString()),
                    Direccion = TxtDireccion.Text,
                    Parentezco = int.Parse(CboParentezco.SelectedValue.ToString())
                });
            }
             
            MessageBox.Show(ContactoDao.mensajeError);
            this.Close();
        }

        private void cmbTipoIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnDireccion_Click(object sender, EventArgs e)
        {
            FrmDireccion f = new FrmDireccion();
            f.Owner = this;
            f.ShowDialog(this);
            TxtDireccion.Text = f.Direccion;
        }

        private void chkHabeasData_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
