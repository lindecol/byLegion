<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConteosDispProductos.aspx.vb" Inherits="ControlPaquete.ConteosDispProductos1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
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
                        <%--Código--%>
                        <asp:Label ID="lblCodigo" runat="server" Font-Size="Smaller" Text="Código:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtCodigo" runat="server" Width="50px" MaxLength="10" AutoPostBack="True"></asp:TextBox>
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
                    <td>
                        <%--Capacidad--%>
                        <asp:Label ID="lblCapacidad" runat="server" Font-Size="Smaller" Text="Capacidad:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <asp:DropDownList ID="cmbCapacidadProducto" runat="server" AutoPostBack="false" ForeColor="Black" Visible="false" DataTextField="capacidad" DataValueField="capacidad" AppendDataBoundItems="true" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <br />
                        <%--Botón para ir atrás--%>
                        <asp:ImageButton ID="ibAtras" runat="server" ImageUrl="~/Images/Atras.GIF" Width="16px" Height="16px" ToolTip="Atrás" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ibProducto" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="16px" Height="16px" ToolTip="Enviar" />
                    </td>
                </tr>
            </table>
    <img src="../Images/floor_bg.JPG" width="200" />
       </div>
    </form>
</body>
</html>
