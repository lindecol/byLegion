using System;
using IUProdPack.WsPraxair;

namespace IUProdPack
{
    public class ClsGeneral
    {
        public string tienePermiso(string _usrid, string _strFuncion)
        {
            return (new ServiceSoapClient()).usuarioFuncion(Convert.ToInt32(_usrid), _strFuncion);
        }
    }
}