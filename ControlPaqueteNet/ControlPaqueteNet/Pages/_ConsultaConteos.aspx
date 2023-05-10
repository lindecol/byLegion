<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConsultaConteos.aspx.vb" Inherits="ControlPaquete.ConsultaConteos" MasterPageFile="~/Pages/Dispositivo.Master" %>

<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder2" runat="server">
    <table style="width:100%">
    <tr>
        <td valign="top" align="center">
            <%--Grilla donde mostraremos los datos--%>
            <asp:GridView ID="grConteos" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="CodigoConteo" HeaderText="Conteo" >
                        <ControlStyle Width="30%" />
                        <HeaderStyle Font-Size="X-Small" />
                        <ItemStyle Font-Size="X-Small" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ClaseConteo" HeaderText="Tipo" >
                        <ControlStyle Width="40%" />
                        <HeaderStyle Font-Size="X-Small" />
                        <ItemStyle Font-Size="X-Small" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Sel">
                        <ControlStyle Width="30%" />
                        <HeaderStyle Font-Size="X-Small" />
                        <ItemStyle Font-Size="X-Small" />
                    </asp:CommandField>
                </Columns>
                <SelectedRowStyle BackColor="Teal" ForeColor="White" Font-Size="Smaller" />
                <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
            </asp:GridView>
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
        <td valign="top" align="left">
            <br />
            <%--Botón para guardar el activo en la grilla--%>
            <asp:ImageButton ID="ibSalir" runat="server" ImageUrl="~/Images/Eliminar.JPG" Width="16px" Height="16px" ToolTip="Salir" />
        </td>
    </tr>
    </table>
</asp:content>