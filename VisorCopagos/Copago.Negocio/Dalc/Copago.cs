using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copago.Negocio.Dalc
{
    public class Copago
    {
        OracleConnection cx;
        public Copago() {
        }

        public List<Objetos.Copago> ObtenerCopagos(DateTime fI, DateTime fF, string cliente, bool estado) {
            var salida = new List<Objetos.Copago>();
            int vEstado = 0;
            string sql = "";
            //sql = "SELECT PAG.IDENTIFICACION, PAG.DOCUMENTO, PAG.EMPID, PAG.FEC_EMI, PAG.VALOR, 0 FROM  SPV_CART_PAGOS_ONLINE PAG WHERE NOT EXISTS (SELECT 1 FROM PAH_PAGO PAGO1 WHERE PAGO1.EMPRESA = PAG.EMPID AND PAGO1.DOCUMENTO = PAG.DOCUMENTO) AND NOT EXISTS (SELECT 1 FROM PAH_PAGO_COPAGO PAGO2 WHERE PAGO2.EMPRESA = PAG.EMPID AND PAGO2.DOCUMENTO = PAG.DOCUMENTO) and PAG.EMPID = :P0 AND PAG.FEC_EMI >= :P1 AND PAG.FEC_EMI <= :P2 ";
            sql = "SELECT PAG.CLIENTE, PAG.DOCUMENTO, 0 AS EMPID, PAG.FECHA_DOCUMENTO, nvl(PAG.COPAGO, '-') AS VALOR, PAG.ESTADO FROM  PAH_PAGO_COPAGO PAG WHERE PAG.FECHA_DOCUMENTO >= :P1 AND PAG.FECHA_DOCUMENTO <= :P2 AND PAG.ESTADO = :P3";

            if (cliente.Length > 0)
                sql += " AND PAG.CLIENTE LIKE '%:P4%' ";
            if (estado)
                vEstado = 1;


            OracleConnection cx = new OracleConnection();
            cx = new BaseDeDatos.Conexion().ObtenerCx();

            try
            {
                using (OracleCommand cm = new OracleCommand(sql, cx))
                {
                    cm.Parameters.Add(new OracleParameter("P1", fI));
                    cm.Parameters.Add(new OracleParameter("P2", fF.AddDays(1)));
                    cm.Parameters.Add(new OracleParameter("P3", vEstado));


                    if (cliente.Length > 0)
                        cm.Parameters.Add(new OracleParameter("P4", cliente));


                    OracleDataReader lector = cm.ExecuteReader();

                    while (lector.Read())
                    {
                        salida.Add(new Objetos.Copago() { 
                            Identificacion = lector.GetString(0), 
                            Documento = lector.GetString(1), 
                            Empresa = int.Parse(lector[2].ToString()), 
                            FechaRegistro = lector.GetDateTime(3), 
                            Monto = lector.GetString(4), 
                            Estado = lector.GetInt32(5)
                        } );
                    }
                }
                return salida;
            }
            catch(Exception ex)
            {
                System.Console.Out.WriteLine("Error:" + ex.ToString());
                return salida;
            }
            finally
            {
                if (cx != null)
                    cx.Close();
                cx = null;
            }
        }

        public bool AdicionarCopago(string documento, string empresa, string cliente, int estado, double copago) {
            bool salida = false;
            string sql = "";
            sql = @"insert into PAH_PAGO_COPAGO(ID, ID_SESION, DOCUMENTO, EMPRESA, CLIENTE, MONTO, ESTADO, REPORTE_PAGO, FECHA_DOCUMENTO, ID_ENLACE, COPAGO) 
                    values(PAH_PAGO_COPAGO_SEQ.NEXTVAL, -1, :P0, :P1, :P2, -1, :P3, -1, SYSDATE,-1, :P4 ) ";

            OracleConnection cx = new OracleConnection();
            cx = new BaseDeDatos.Conexion().ObtenerCx();

            try
            {
                using (OracleCommand cm = new OracleCommand(sql, cx))
                {
                    cm.Parameters.Add(new OracleParameter("P0", documento));
                    cm.Parameters.Add(new OracleParameter("P1", empresa));
                    cm.Parameters.Add(new OracleParameter("P2", cliente));
                    cm.Parameters.Add(new OracleParameter("P3", estado));
                    cm.Parameters.Add(new OracleParameter("P4", copago));

                    int lector = cm.ExecuteNonQuery();

                    salida = lector > 0;
                }
                return salida;
            }
            catch
            {
                return salida;
            }
            finally
            {
                if (cx != null)
                {
                    cx.Close();
                    cx.Dispose();
                }
            }
        }
    }
}
