using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfoContactoClientes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            char separador = ';';

            ParametrosIniciales.CodigoCliente = args[0];

            try
            {
                ParametrosIniciales.Modulo= (args[2]);
            }
            catch (Exception ex)
            {

                ParametrosIniciales.Modulo = "CLIENTES";
            }


            //ParametrosIniciales.TIpoCliente = (args[0].Split(separador)[1]);
            ParametrosIniciales.Usuario= (args[1]);
            ParametrosIniciales.setTipoCliente();

            Application.Run(new Form1());
        }
    }
}
