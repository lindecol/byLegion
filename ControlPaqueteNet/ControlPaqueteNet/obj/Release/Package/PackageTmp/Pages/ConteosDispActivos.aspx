<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConteosDispActivos.aspx.cs" Inherits="ControlPaqueteNet.Pages.ConteosDispActivos" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Conteo Activos</title>
      <script type="text/javascript">
    function esInteger(e){
    var charCode
    if (navigator.appName == "Netscape"){
    charCode = e.which
    }
    else{
    charCode = e.keyCode} 
    if (charCode < 48 || charCode > 57){
    return false
    }
    else{
    return true}
    }
      </script>
</head>
<body onload="document.forms[0].txtSerial.focus()">
    <form id="form1" runat="server">
     <div>
     <img src="../Images/header_bg.jpg" width="200" /><br />
        <br />
            <table style="width:100%">
                <tr>
                    <td valign="top" align="center">
                        <%--Caja de Texto donde encontraremos el serial--%>
                        <asp:TextBox ID="txtSerial" runat="server" AutoPostBack="true" />
                        <br />
                        <%--Error--%>
                        <asp:Label ID="lblConteo" runat="server" Font-Size="Smaller" Text="" Font-Bold="True"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Error--%>
                        <asp:Label ID="lblError" runat="server" Font-Size="Smaller" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAnular" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Teal"
                            Text="Anular?" Visible="false"></asp:Label>
                        <asp:RadioButton ID="rbSiAnula" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="Si" GroupName="Anular" Checked="true" Visible="false" />
                        <asp:RadioButton ID="rbNoAnula" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="No" GroupName="Anular" Visible="false" />
                    </td>                       
                </tr>
                <tr>
                    <td>
                        <%--Propiedad--%>
                        <asp:Label ID="lblPropiedad" runat="server" Font-Size="Smaller" Text="Propiedad:" ForeColor="Teal" Visible="true" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:DropDownList ID="cmbPropiedad" runat="server" AutoPostBack="true" ForeColor="Black" Visible="true">
                            <asp:ListItem Value="P">Propios</asp:ListItem>
                            <asp:ListItem Value="A">Ajenos</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Familia--%>
                        <asp:Label ID="lblFamilia" runat="server" Font-Size="Smaller" Text="Familia:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtFamilia" runat="server" Width="50px" MaxLength="7"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Cantidad--%>
                        <asp:Label ID="lblCantidad" runat="server" Font-Size="Smaller" Text="Cantidad:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtCantidad" runat="server" MaxLength="6" Width="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <br />
                        <%--Botón para ir atrás--%>
                        <asp:ImageButton ID="ibAtras" runat="server" ImageUrl="~/Images/Atras.GIF" Width="16px" Height="16px" ToolTip="Atrás" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ibActivoPropio" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="16px" Height="16px" ToolTip="Enviar" />
                    </td>
                </tr>
            </table>
            <img src="../Images/floor_bg.JPG" width="200" />
       </div>
    </form>
</body>
</html>
