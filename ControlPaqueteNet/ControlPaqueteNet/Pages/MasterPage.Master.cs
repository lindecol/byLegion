using ControlPaqueteNet.WsPraxair;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ControlPaqueteNet
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.Response.Redirect("salir.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblPais.Text = "Colombia";
                //object objSeg = new Service();
                var objSeg = new WsPraxair.ServiceSoapClient();
                //string strPais = Conversions.ToString(NewLateBinding.LateGet(objSeg, null, "PAIS", new object[0], null, null, null));
                string strPais = objSeg.Pais();
                Label str = this.lblPais;
                object[] objectValue = new object[] { strPais, null, null };
                HttpSessionState session = this.Session;
                string str1 = "Empresa";
                objectValue[1] = RuntimeHelpers.GetObjectValue(session[str1]);
                objectValue[2] = "NOM_PAIS";
                object[] num = objectValue;
                bool[] flagArray = new bool[] { true, true, false };
                object obj = NewLateBinding.LateGet(objSeg, null, "valorcache", num, null, null, flagArray);
                if (flagArray[0])
                {
                    strPais = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(num[0]), typeof(string));
                }
                if (flagArray[1])
                {
                    session[str1] = RuntimeHelpers.GetObjectValue(num[1]);
                }
                str.Text = Conversions.ToString(obj);
                Label label2 = this.Label2;
                num = new object[] { this.Session["UsuarioRegistro"].ToString(), 6 };
                label2.Text = Conversions.ToString(Operators.AddObject("Usuario: ", NewLateBinding.LateGet(objSeg, null, "datosUsuario", num, null, null, null)));
                if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Grupo"], null, false))
                {
                    this.lblGrupo.Visible = false;
                }
                else
                {
                    Label label = this.lblGrupo;
                    string str2 = string.Concat(string.Concat("Grupo: ", this.Session["Grupo"].ToString()), "- ");
                    num = new object[] { Convert.ToInt32(this.Session["Grupo"].ToString()) };
                    label.Text = Conversions.ToString(Operators.AddObject(str2, NewLateBinding.LateGet(objSeg, null, "descripcionGrupo", num, null, null, null)));
                    this.lblGrupo.Visible = true;
                }
                if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Empresa"], null, false))
                {
                    this.lblEmpresa.Visible = false;
                }
                else
                {
                    Label label1 = this.lblEmpresa;
                    string str3 = string.Concat(string.Concat("Empresa: ", this.Session["Empresa"].ToString()), "- ");
                    num = new object[] { Convert.ToInt32(this.Session["Empresa"].ToString()), Convert.ToInt32(this.Session["Grupo"].ToString()) };
                    label1.Text = Conversions.ToString(Operators.AddObject(str3, NewLateBinding.LateGet(objSeg, null, "descripcionEmpresa", num, null, null, null)));
                    this.lblEmpresa.Visible = true;
                }
                if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Agencia"], null, false))
                {
                    this.lblAgencia.Visible = false;
                }
                else
                {
                    Label label3 = this.lblAgencia;
                    string str4 = string.Concat(string.Concat("Agencia: ", this.Session["Agencia"].ToString()), "- ");
                    num = new object[] { Convert.ToInt32(this.Session["Empresa"].ToString()), Convert.ToInt32(this.Session["Grupo"].ToString()), this.Session["Agencia"].ToString() };
                    label3.Text = Conversions.ToString(Operators.AddObject(str4, NewLateBinding.LateGet(objSeg, null, "descripcionAgencia", num, null, null, null)));
                    this.lblAgencia.Visible = true;
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
                ProjectData.ClearProjectError();
            }
        }
    }
}