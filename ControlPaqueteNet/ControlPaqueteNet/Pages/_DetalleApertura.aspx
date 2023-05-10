<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DetalleApertura.aspx.vb" Inherits="ControlPaquete.DetalleApertura" MasterPageFile="~/Pages/MasterPage.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <%--Colocamos el UpdatePanel para nuestros asuntos en AJAX--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table style="width:100%">
                <tr>
                    <td valign="top" align="center">
                        <%--Mostramos el t�tulo y el subtitulo de la p�gina--%>
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                            Text="Detalle Apertura"></asp:Label>
                        <p></p>
                        <asp:Label ID="lblSubtitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                            Text=""></asp:Label>
                        <hr style="width:100%" />
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        <%--Grilla donde mostramos los subdep�sitos asociados al conteo--%>
                        <asp:GridView ID="grConteo" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="705px">
                            <Columns>
                                <asp:BoundField DataField="NOMBRE_SUCURSAL" HeaderText="Sucursal" >
                                    <ControlStyle Width="233px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_SECTOR" HeaderText="Sector" >
                                    <ControlStyle Width="233px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_SUBDEPOSITO" HeaderText="Subdep�sito" >
                                    <ControlStyle Width="233px" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="teal" ForeColor="white" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <%--Bot�n para ir atr�s--%>
                        <asp:ImageButton ID="ibAtras" runat="server" ImageUrl="~/Images/Atras.GIF" Width="24px" ToolTip="Atr�s" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <%--Error--%>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            
        </Triggers>
    </asp:UpdatePanel>
</asp:content>