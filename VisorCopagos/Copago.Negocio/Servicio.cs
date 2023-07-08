using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copago.Negocio
{
    public class Servicio
    {
        public static List<Objetos.Copago> ListarCopagos(DateTime fI, DateTime fF, string cliente, bool estado) {
            Dalc.Copago pago = new Dalc.Copago();
            return pago.ObtenerCopagos(fI, fF, cliente, estado);
        }

        public static bool ActualizarCopago(string documento, string empresa, string cliente, int estado, double copago)
        {
            Dalc.Copago pago = new Dalc.Copago();
            return pago.AdicionarCopago(documento, empresa, cliente, estado, copago);
        }            
    }
}
