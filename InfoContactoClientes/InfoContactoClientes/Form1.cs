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
    public partial class Form1 : Form
    {
        bool _cargaInicio = true;
        public Form1()
        {
            InitializeComponent();
        }

       public List<Contacto> lista;

        private void Form1_Load(object sender, EventArgs e)
        {
            _cargaInicio = true;

            if (ParametrosIniciales.TIpoCliente == "") {
                MessageBox.Show("Por favor valide el cliente, No existe en la maestra", "Error cliente", MessageBoxButtons.OK);
                this.toolStripButton1.Enabled = false;
                tbHabeasData.Enabled = false;
                return;
            }
            else if (ParametrosIniciales.TIpoCliente == "M")
            {
                tbHabeasData.TabPages.Remove(tbPIndustrial);
            }
            else
            {
                tbHabeasData.TabPages.Remove(tbpMedicinal);
            }

            ParametrosIniciales.CargarTipoContactos();
            RefrescarContactos();

            foreach (TabPage t in this.tbHabeasData.TabPages) {
                if (t.Name == "tabPage1")
                    this.tbHabeasData.TabPages.Remove(t);
                    //t. Hide();
            }
            //this.tbHab .Hide();
            //tbHabeasData.TabPages. [2].Hide(); //Legion

        }

        private void RefrescarContactos()
        {
            lista = ContactoDao.ConsultarContactos(ParametrosIniciales.CodigoCliente);
            //this.contactoBindingSource.DataSource = lista.Where(p => p.IdTipoContacto != 12).ToList();                            //Medicinales
            //this.contactoBindingSource1.DataSource = lista.Where(p => p.IdTipoContacto == 10 || p.IdTipoContacto == 12 || p.IdTipoContacto == 1).ToList(); //Industriales
            //this.contactoBindingSource2.DataSource = lista.Where(p => p.IdTipoContacto == 10 || p.IdTipoContacto == 12).ToList(); //Habeas
            this.contactoBindingSource.DataSource = lista.ToList();  //Medicinales
            this.contactoBindingSource1.DataSource = lista.ToList(); //Industriales
            this.contactoBindingSource2.DataSource = lista.ToList(); //Habeas

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmContacto FRM = new InfoContactoClientes.FrmContacto(lista);
            FRM.ShowDialog(this);
            RefrescarContactos();

        }

        private void inactivarContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea inactivar el contacto", "Inactivar Contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

            {

                if (this.grvContactosMedicinales.SelectedRows.Count > 0)
                {
                    DataGridViewRow fila = this.grvContactosMedicinales.SelectedRows[0];
                    Contacto linea = (Contacto)fila.DataBoundItem;

                    try
                    {

                        ContactoDao.InactivarContacto(linea);
                        MessageBox.Show("Contacto eliminado");
                        RefrescarContactos();

                    }
                    catch (Exception ex)
                    {


                    }


                }
                else if (this.grvContactosIndustriales.SelectedRows.Count > 0)
                {

                    DataGridViewRow fila = this.grvContactosIndustriales.SelectedRows[0];
                    Contacto linea = (Contacto)fila.DataBoundItem;

                    try
                    {


                        ContactoDao.InactivarContacto(linea);
                        MessageBox.Show("Contacto eliminado");
                        RefrescarContactos();


                    }
                    catch (Exception ex)
                    {


                    }

                }
                else if (this.grvHabeasData.SelectedRows.Count > 0)
                {

                    DataGridViewRow fila = this.grvHabeasData.SelectedRows[0];
                    Contacto linea = (Contacto)fila.DataBoundItem;

                    try
                    {


                        ContactoDao.InactivarContacto(linea);
                        MessageBox.Show("Registro de habeas data eliminado");
                        RefrescarContactos();


                    }
                    catch (Exception ex)
                    {


                    }

                }
            }


        }

        private void modificarContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.grvContactosMedicinales.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = this.grvContactosMedicinales.SelectedRows[0];
                Contacto linea = (Contacto)fila.DataBoundItem;

                try
                {

                    FrmContactoUpdate frm = new FrmContactoUpdate(linea);
                    frm.ShowDialog(this);
                    RefrescarContactos();
                    //foreach (var item in historialRutas.Where(p => p.P_PEDIDONRO == linea.P_PEDIDONRO))
                    //{
                    //    item.P_DEMORA_CLP_ID = linea.P_DEMORA_CLP_ID;
                    //    item.P_DEMORA_DIST_ID = linea.P_DEMORA_DIST_ID;
                    //    item.P_EST_PEDIDOCLP_ID = linea.P_EST_PEDIDOCLP_ID;
                    //    plantilla.ActualizarERP(item);
                    //    item.EstadoRegistro = false;
                    //}               



                }
                catch (Exception ex)
                {


                }


            }
            else if (this.grvContactosIndustriales.SelectedRows.Count > 0)
            {

                DataGridViewRow fila = this.grvContactosIndustriales.SelectedRows[0];
                Contacto linea = (Contacto)fila.DataBoundItem;

                try
                {

                    FrmContactoUpdate frm = new FrmContactoUpdate(linea);
                    frm.ShowDialog(this);
                    RefrescarContactos();
                    //foreach (var item in historialRutas.Where(p => p.P_PEDIDONRO == linea.P_PEDIDONRO))
                    //{
                    //    item.P_DEMORA_CLP_ID = linea.P_DEMORA_CLP_ID;
                    //    item.P_DEMORA_DIST_ID = linea.P_DEMORA_DIST_ID;
                    //    item.P_EST_PEDIDOCLP_ID = linea.P_EST_PEDIDOCLP_ID;
                    //    plantilla.ActualizarERP(item);
                    //    item.EstadoRegistro = false;
                    //}               



                }
                catch (Exception ex)
                {


                }

            }
            else if (this.grvHabeasData.SelectedRows.Count > 0)
            {

                DataGridViewRow fila = this.grvHabeasData.SelectedRows[0];
                Contacto linea = (Contacto)fila.DataBoundItem;

                try
                {

                    FrmContactoUpdate frm = new FrmContactoUpdate(linea);
                    frm.ShowDialog(this);
                    RefrescarContactos();
                    //foreach (var item in historialRutas.Where(p => p.P_PEDIDONRO == linea.P_PEDIDONRO))
                    //{
                    //    item.P_DEMORA_CLP_ID = linea.P_DEMORA_CLP_ID;
                    //    item.P_DEMORA_DIST_ID = linea.P_DEMORA_DIST_ID;
                    //    item.P_EST_PEDIDOCLP_ID = linea.P_EST_PEDIDOCLP_ID;
                    //    plantilla.ActualizarERP(item);
                    //    item.EstadoRegistro = false;
                    //}               



                }
                catch (Exception ex)
                {


                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool cerrar = true;
            string cadena = "";

            if (ParametrosIniciales.TIpoCliente == ""){
                cerrar = true;
                cadena = "Sin información de cliente";
            }
            else {
                if (lista.Where(p => p.IdTipoContacto == 10 || p.IdTipoContacto == 6).Count() != 2)
                {
                    cerrar = false;
                    cadena = "Datos del Paciente";

                }

                //if (lista.Where(p => p.IdTipoContacto != 10 && p.IdTipoContacto != 8).Count() == 0)
                //{
                //    cerrar = false;
                //    cadena = "Contactos del Cliente;";

                //}

                if (lista.Where(p => p.IdTipoContacto == 10 || p.IdTipoContacto == 12).Count() == 0)
                {
                    cerrar = false;
                    cadena += "\nPolitica de Habeas Data";
                }

                if (!cerrar)
                {

                    if (ParametrosIniciales.Modulo == "CLIENTES" && ParametrosIniciales.TIpoCliente == "M")
                    {
                        MessageBox.Show("Debe registrar la siguiente informacion: " + cadena);
                        e.Cancel = true;
                        return;
                    }

                    if (lista.Count == 0 && ParametrosIniciales.TIpoCliente == "M")
                    {
                        if (MessageBox.Show("No ha registrado la siguiente información: " + cadena + " Desea continuar sin ingresar esta informacion ", " Informacion contacto", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            e.Cancel = false;
                        }
                    }
                }
            }



            
        }

        private void grvContactosMedicinales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contactoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
