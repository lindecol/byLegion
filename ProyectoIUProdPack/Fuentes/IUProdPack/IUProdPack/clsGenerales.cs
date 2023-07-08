using System;
using System.Data;
using System.Web.UI.WebControls;
using IUProdPack.WsPraxair;

namespace IUProdPack
{
    public class clsGenerales
    {
        public clsGenerales()
        {
        }

        public void cargarCombos(DataSet _dts, DropDownList _obj, string CampoMostrar, string campoValor, string valorPorDefecto)
        {
            _obj.DataSource = _dts.Tables[0];
            _obj.DataValueField = campoValor;
            _obj.DataTextField = CampoMostrar;
            if (!valorPorDefecto.Equals(""))
            {
                _obj.SelectedValue = valorPorDefecto;
            }
            _obj.DataBind();
        }

        public string tienePermiso(string _usrid, string _strFuncion)
        {
            return (new ServiceSoapClient()).usuarioFuncion(Convert.ToInt32(_usrid), _strFuncion);
        }
    }
}