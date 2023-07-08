using SoftManagement.Comunes;
using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using TransferenciasZF.Data;


namespace TransferenciaZonaFrancaV2
{
    public partial class PruebaDocumentoTransferencia : System.Web.UI.Page
    {
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<IEntity> SucursalesPorEmpresa(int IdEmpresa)
        {
            Sucursal sucursal = new Sucursal()
            {
                SucursalId = 21
            };
            List<IEntity> lista = new List<IEntity>();
            return sucursal.Consultar();
        }
    }
}