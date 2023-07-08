using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TransferenciaZonaFrancaV2
{
    public partial class SesionMultiple : System.Web.UI.Page
    {
        private static string Conectar_a;

        static SesionMultiple()
        {
            SesionMultiple.Conectar_a = "ConexionOracle";
        }

        public SesionMultiple()
        {
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}