using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copago.Negocio.Objetos
{
    public class Copago
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Documento { get; set; }
        public int Estado { get; set; }
        public int Empresa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Monto { get; set; }
        public double ValorCopago { get; set; }

        public string FechaRegistroTexto { get {
                return FechaRegistro.ToShortDateString();
            }
        }
    }
}
