<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Bloqueo.aspx.cs" Inherits="ControlPaqueteNet.Pages.Bloqueo" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <table style="width:100%">
        <tr>
            <td valign="top" align="center">
                <%--Mostramos el título de la página--%>
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                    Text="Bloqueo de Conteos"></asp:Label>
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
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <img src="../Images/clock.gif" />
                                Cargando información...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:GridView ID="grCierre" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px">
                            <Columns>
                                <asp:BoundField DataField="colProgramacion" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tipo_conteo" HeaderText="Tipo Conteo" >
                                    <ControlStyle Width="280px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="colFechaIni" HeaderText="Fecha" >
                                    <ControlStyle Width="280px" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True" SelectText="Bloquear Conteo">
                                    <ControlStyle Width="110px" />
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