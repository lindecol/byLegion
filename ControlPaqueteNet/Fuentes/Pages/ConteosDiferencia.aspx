<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConteosDiferencia.aspx.vb" Inherits="ControlPaquete.ConteosDiferencia" MasterPageFile="~/Pages/MasterPage.Master" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <table style="width:100%">
        <tr>
            <td valign="top" align="center">
                <%--Mostramos el título de la página--%>
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                    Text="Justificar Diferencias"></asp:Label>
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
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grDiferencia" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px">
                            <Columns>
                                <asp:BoundField DataField="CodigoConteo" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ClaseConteo" HeaderText="Tipo Conteo" >
                                    <ControlStyle Width="148px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaInicio" HeaderText="Fecha" >
                                    <ControlStyle Width="148px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio">
                                    <ControlStyle Width="148px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin">
                                    <ControlStyle Width="148px" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True" SelectText="Registrar">
                                    <ControlStyle Width="80px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                        <%--Error--%>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <br />
                    </ContentTemplate>
                 </asp:UpdatePanel>
                </center>
            </td>
        </tr>
    </table>
</asp:content>