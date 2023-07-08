using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InfoContactoClientes
{
    public partial class FrmContactoUpdate : Form
    {
        private Contacto fila;

        public FrmContactoUpdate()
        {
            InitializeComponent();
        }

        public FrmContactoUpdate(Contacto fila)
        {
            this.fila = fila;
            InitializeComponent();
        }

        private void FrmContacto_Load(object sender, EventArgs e)
        {

            List<TIpoIdentificacion> ds = ContactoDao.ConsultarTipoIdentificacion();

            tIpoIdentificacionBindingSource.DataSource = ds;

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


            cargarCliente();

        }

        private void cargarCliente()
        {
            this.txtEmail.Text  = fila.Email;
            this.txtNombreContacto.Text  = fila.NombreContacto;
            this.txtTelefono.Text = fila.Telefono;
            this.cmbTIpoContacto.SelectedValue = fila.IdTipoContacto;
            this.dtpFechaCumpleaños.Value = fila.FechaCumpleanos;
            this.txtInfoAdicional.Text = fila.Telefono_info_adicional;
            this.chkHabeasData.Checked = fila.HabeasData == "S" ? true : false;
            this.cmbTipoIdentificacion.SelectedValue = fila.TipoIdentificacion;
            this.txtIdentificacion.Text = fila.NumeroIdentificacion;

            this.CboCiudad.SelectedValue = fila.Ciudad;
            this.CboLocalidad.SelectedValue = fila.Localidad;
            this.CboParentezco.SelectedValue = fila.Parentezco;
            this.TxtDireccion.Text = fila.Direccion;
        }

        private void cmbTIpoContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tipoContacto = ((TipoContacto)this.cmbTIpoContacto.SelectedItem).IdTipoContacto;

            //SI EL TIPO DE CONTACTO ES DATOS PACIENTE

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
            lblNombreContacto.Text = "Datos que acepta";

            lblInfoAdicional.Visible = false;
            txtInfoAdicional.Visible = false;

            lblFechaCumpleaños.Visible = false;
            dtpFechaCumpleaños.Visible = false;

            lblInfoAdicional.Visible = false;
            txtInfoAdicional.Visible = false;


            if (tipoContacto == 1 ||
                tipoContacto == 2 ||
                tipoContacto == 3 ||
                tipoContacto == 4 ||
                tipoContacto == 5 ||
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
            if (tipoContacto == 10 || tipoContacto == 12)
            {
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

            if (tipoContacto == 8 || tipoContacto == 9)
            {
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

            if (tipoContacto == 9)
            {
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


        private void button1_Click(object sender, EventArgs e)
        {
            int ciud = -1;
            int loca = -1;
            int pare = -1;
            try
            {
                Util.Log.EscribirLog("button1_Click", "Inicio del método del boton");
                if (!ParametrosIniciales.ValidarCorreo(this.txtEmail.Text) && this.txtEmail.Visible)
                {
                    MessageBox.Show("Formato de correo electronico invalido");
                    return;
                }


                if ((txtTelefono.Text.ToString().Length < 7 || txtTelefono.Text.ToString().Length > 10) && txtTelefono.Visible)
                {
                    MessageBox.Show("Formato de Telefono Invalido");
                    return;
                }

                if (txtIdentificacion.Text.Length == 0 && txtIdentificacion.Visible)
                {
                    MessageBox.Show("Debe ingresar el numero de identificacion de la persona que autoriza");
                    return;
                }

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
                    if (tipoContacto == 10 || tipoContacto == 12)
                    {
                        if (txtTelefono.Text.ToString().Length != 10)
                        {
                            MessageBox.Show("En Habes data, el teléfono de contacto debe tener 10 dígitos");
                            return;
                        }
                    }
                }


                Util.Log.EscribirLog("button1_Click", "Valores");


                Util.Log.EscribirLog("button1_Click", "Email = " + txtEmail.Text);
                Util.Log.EscribirLog("button1_Click", "FechaCumpleanos = " + dtpFechaCumpleaños.Value);
                Util.Log.EscribirLog("button1_Click", "IdTipoContacto = " + ((TipoContacto)cmbTIpoContacto.SelectedItem).IdTipoContacto);
                Util.Log.EscribirLog("button1_Click", "codi_cli = " + ParametrosIniciales.CodigoCliente);
                Util.Log.EscribirLog("button1_Click", "NombreContacto = " + txtNombreContacto.Text);
                Util.Log.EscribirLog("button1_Click", "Telefono = " + telefonoCompleto);
                Util.Log.EscribirLog("button1_Click", "Id = " + fila.Id);
                Util.Log.EscribirLog("button1_Click", "Telefono_info_adicional = " + txtInfoAdicional.Text);
                Util.Log.EscribirLog("button1_Click", "HabeasData = " + (chkHabeasData.Checked == true ? "S" : "N"));
                Util.Log.EscribirLog("button1_Click", "NumeroIdentificacion = " + txtIdentificacion.Text);
                Util.Log.EscribirLog("button1_Click", "TipoIdentificacion = " + ((TIpoIdentificacion)cmbTipoIdentificacion.SelectedItem) == null ? "01" : ((TIpoIdentificacion)cmbTipoIdentificacion.SelectedItem).Tipo);

                if (CboCiudad.SelectedValue != null) {
                    ciud = int.Parse(CboCiudad.SelectedValue.ToString());
                    Util.Log.EscribirLog("button1_Click", "Ciudad = " + int.Parse(CboCiudad.SelectedValue.ToString()));
                }

                if (CboLocalidad.SelectedValue != null)
                {
                    loca = int.Parse(CboLocalidad.SelectedValue.ToString());
                    Util.Log.EscribirLog("button1_Click", "Localidad = " + int.Parse(CboLocalidad.SelectedValue.ToString()));
                }

                if (CboParentezco.SelectedValue != null)
                {
                    pare = int.Parse(CboParentezco.SelectedValue.ToString());
                    Util.Log.EscribirLog("button1_Click", "Parentezco = " + int.Parse(CboParentezco.SelectedValue.ToString()));
                }


                Util.Log.EscribirLog("button1_Click", "Direccion = " + TxtDireccion.Text);
                Util.Log.EscribirLog("button1_Click", "Parentezco = " + int.Parse(CboParentezco.SelectedValue.ToString()));

                if (ParametrosIniciales.TIpoCliente == "I")
                {
                    ContactoDao.ActualizarContacto(new InfoContactoClientes.Contacto
                    {
                        Email = txtEmail.Text,
                        FechaCumpleanos = dtpFechaCumpleaños.Value,
                        IdTipoContacto = ((TipoContacto)cmbTIpoContacto.SelectedItem).IdTipoContacto,
                        codi_cli = ParametrosIniciales.CodigoCliente,
                        NombreContacto = txtNombreContacto.Text,
                        Telefono = telefonoCompleto,
                        Id = fila.Id,
                        Telefono_info_adicional = txtInfoAdicional.Text,
                        HabeasData = chkHabeasData.Checked == true ? "S" : "N",
                        NumeroIdentificacion = txtIdentificacion.Text,
                        TipoIdentificacion = ((TIpoIdentificacion)cmbTipoIdentificacion.SelectedItem) == null ? "01" : ((TIpoIdentificacion)cmbTipoIdentificacion.SelectedItem).Tipo,
                        Localidad = loca,
                        Direccion = TxtDireccion.Text,
                        Parentezco = pare,
                        Ciudad = ciud
                    });
                }
                else {
                    ContactoDao.ActualizarContacto(new InfoContactoClientes.Contacto
                    {
                        Email = txtEmail.Text,
                        FechaCumpleanos = dtpFechaCumpleaños.Value,
                        IdTipoContacto = ((TipoContacto)cmbTIpoContacto.SelectedItem).IdTipoContacto,
                        codi_cli = ParametrosIniciales.CodigoCliente,
                        NombreContacto = txtNombreContacto.Text,
                        Telefono = telefonoCompleto,
                        Id = fila.Id,
                        Telefono_info_adicional = txtInfoAdicional.Text,
                        HabeasData = chkHabeasData.Checked == true ? "S" : "N",
                        NumeroIdentificacion = txtIdentificacion.Text,
                        TipoIdentificacion = ((TIpoIdentificacion)cmbTipoIdentificacion.SelectedItem) == null ? "01" : ((TIpoIdentificacion)cmbTipoIdentificacion.SelectedItem).Tipo,
                        Localidad = loca,
                        Direccion = TxtDireccion.Text,
                        Parentezco = pare,
                        Ciudad = ciud
                    });
                }

                

                MessageBox.Show("contacto Actualizado");
                this.Close();
            }
            catch (Exception ex)
            {
                Util.Log.EscribirLog(ex.Source + " - Error", ex.ToString());
            }
        }

        private void BtnDireccion_Click(object sender, EventArgs e)
        {
            FrmDireccion f = new FrmDireccion();
            f.Owner = this;
            f.ShowDialog(this);
            TxtDireccion.Text = f.Direccion;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
