<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SectoresPorSucursal.aspx.vb" Inherits="ControlPaquete.SectoresPorSucursal" MasterPageFile="~/Pages/MasterPage.Master" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <table style="width:100%">
        <tr>
            <td valign="top" align="center">
                <%--Mostramos el título de la página--%>
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                    Text="Sectores Por Sucursal"></asp:Label>
                <br />
                <hr style="width:100%" />
            </td>
        </tr>
        <tr>
            <td valign="top" align="left">
                <center>
                <%--Colocamos el UpdatePanel para nuestros asuntos en AJAX--%>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                        <%--Sucursal--%>
                        <%--Sector--%>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <img src="../Images/clock.gif" />
                                Cargando información...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <table style="width: 30%">
                            <tr>
                                <td align="left">
                        <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Sucursales:" ForeColor="Teal" Font-Bold="True"></asp:Label></td>
                                <td align="left">
                        <asp:DropDownList ID="cmbSucursal" runat="server" AutoPostBack="True" ForeColor="Black" Width="200px" DataTextField="nombre_sucursal" DataValueField="codigo_sucursal" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbSucursal_SelectedIndexChanged" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="left">
                        <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Sectores:" ForeColor="Teal" Font-Bold="True"></asp:Label></td>
                                <td align="left">
                        <asp:DropDownList ID="cmbSector" runat="server" AutoPostBack="False" ForeColor="Black" Width="200px" DataTextField="colNombre" DataValueField="colCodigo" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="right">
                                    &nbsp;<asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="ibGuardar_Click" /></td>
                            </tr>
                        </table>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <br />
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grSucursal" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px">
                            <Columns>
                                <asp:BoundField DataField="colCodigo" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="colNombre" HeaderText="Sector" >
                                    <ControlStyle Width="600px" />
                                </asp:BoundField>
                                <asp:CommandField SelectText="Eliminar" ShowSelectButton="True">
                                    <ControlStyle Width="80px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="teal" ForeColor="white" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <%--Cada vez que hagamos clic en el botón vamos a utilizar la grilla--%>
                        <asp:AsyncPostBackTrigger ControlID="ibGuardar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="cmbSucursal" EventName="SelectedIndexChanged" />
                    </Triggers>
                 </asp:UpdatePanel>
                </center>
            </td>
        </tr>
    </table>
</asp:content>