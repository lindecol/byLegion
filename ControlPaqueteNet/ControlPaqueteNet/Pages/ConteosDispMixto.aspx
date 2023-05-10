<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConteosDispMixto.aspx.cs" Inherits="ControlPaqueteNet.Pages.ConteosDispMixto" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Conteo Mixto</title>
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
       <asp:TextBox ID="txtSerial" runat="server" Width="90%" AutoPostBack="True" /><br />
    <asp:Panel ID="Panel1" runat="server" Width="100%">

            <table style="width:100%">
                <tr>
                    <td valign="top" align="center" style="width: 100%">
                        <%--Caja de Texto donde encontraremos el serial--%>
                        &nbsp;<br />
                        <%--Error--%>
                        <asp:Label ID="lblConteo" runat="server" Font-Size="Smaller" Text="" Font-Bold="True"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <%--Error--%>
                        <asp:Label ID="lblError" runat="server" Font-Size="Smaller" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <asp:Label ID="lblAnular" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Teal"
                            Text="Anular?" Visible="false"></asp:Label>
                        <asp:RadioButton ID="rbSiAnula" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="Si" GroupName="Anular" Checked="true" Visible="false" />
                        <asp:RadioButton ID="rbNoAnula" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="No" GroupName="Anular" Visible="false" />
                    </td>                       
                </tr>
                <tr>
                    <td style="width: 100%">
                        <%--Propiedad--%>
                        <asp:Label ID="lblPropiedad" runat="server" Font-Size="Smaller" Text="Propiedad:" ForeColor="Teal" Visible="true" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:DropDownList ID="cmbPropiedad" runat="server" AutoPostBack="true" ForeColor="Black" Visible="true">
                            <asp:ListItem Value="P">Propios</asp:ListItem>
                            <asp:ListItem Value="A">Ajenos</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <%--Producto o Activo--%>
                        <asp:Label ID="lblTipo" runat="server" Font-Size="Smaller" Text="Tipo:" ForeColor="Teal" Visible="true" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:DropDownList ID="cmbTipo" runat="server" AutoPostBack="true" ForeColor="Black" Visible="true">
                            <asp:ListItem Value="P">Producto</asp:ListItem>
                            <asp:ListItem Value="A">Activo</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <%--Código--%>
                        <asp:Label ID="lblCodigo" runat="server" Font-Size="Smaller" Text="Código:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtCodigo" runat="server" Width="60%" MaxLength="10" AutoPostBack="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <%--Cantidad--%>
                        <asp:Label ID="lblCantidad" runat="server" Font-Size="Smaller" Text="Cantidad:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtCantidad" runat="server" MaxLength="6" Width="30%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <%--Capacidad--%>
                        <asp:Label ID="lblCapacidad" runat="server" Font-Size="Smaller" Text="Capacidad:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <asp:DropDownList ID="cmbCapacidadProducto" runat="server" AutoPostBack="false" ForeColor="Black" Visible="false" DataTextField="capacidad" DataValueField="capacidad" AppendDataBoundItems="true" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left" style="width: 100%">
                        <br />
                        <%--Botón para ir atrás--%>
                        <asp:ImageButton ID="ibAtras" runat="server" ImageUrl="~/Images/Atras.GIF" Width="16px" Height="16px" ToolTip="Atrás" TabIndex="2" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="16px" Height="16px" ToolTip="Enviar" TabIndex="3" />
                    </td>
                </tr>
            </table>
    </asp:Panel>        
        <img src="../Images/floor_bg.JPG" width="200" />
        </div>
    </form>
</body>
</html>
