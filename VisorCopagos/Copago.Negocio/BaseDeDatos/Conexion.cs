using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copago.Negocio.BaseDeDatos
{
    class Conexion
    {
        public class OracleConnectionSingleton
        {
            //private static readonly Lazy<OracleConnection> lazyConnection = new Lazy<OracleConnection>(() =>
            //{
            //    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Pago"].ConnectionString;

            //    OracleConnection connection = new OracleConnection(connectionString);
            //    connection.Open();

            //    return connection;
            //});

            //public static OracleConnection Instance { get { 
                    
            //        return lazyConnection.Value; 
            //    } 
            //}

            //private OracleConnectionSingleton()
            //{
            //    // Constructor privado para evitar instancias adicionales
            //}
        }
        public OracleConnection ObtenerCx()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Pago"].ConnectionString;
            try
            {
                OracleConnection connection = new OracleConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex) {
                //Console.WriteLine("Error:" + ex.ToString());
                System.Console.Out.WriteLine("Error:" + ex.ToString());
                return null;
            }
        }

    }
}
