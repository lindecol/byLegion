<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConteosReprogramacion.aspx.vb" Inherits="ControlPaquete.ConteosReprogramacion" MasterPageFile="~/Pages/MasterPage.Master" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <table style="width:100%">
        <tr>
            <td valign="top" align="center">
                <%--Mostramos el título de la página--%>
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                    Text="Reprogramar Conteos"></asp:Label>
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
                        <%--Error--%>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <br />
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grReprogramacion" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px" AllowPaging="False">
                            <Columns>
                                <asp:BoundField DataField="CodigoConteo" HeaderText="Código" >
                                    <ControlStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ClaseConteo" HeaderText="Tipo Conteo" >
                                    <ControlStyle Width="147px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaInicio" HeaderText="Fecha" >
                                    <ControlStyle Width="147px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio">
                                    <ControlStyle Width="147px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin">
                                    <ControlStyle Width="147px" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True">
                                    <ControlStyle Width="80px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="teal" ForeColor="white" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                 </asp:UpdatePanel>
                </center>
            </td>
        </tr>
    </table>
</asp:content>