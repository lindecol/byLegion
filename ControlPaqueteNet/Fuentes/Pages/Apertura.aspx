<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Apertura.aspx.vb" Inherits="ControlPaquete.Apertura" MasterPageFile="~/Pages/MasterPage.Master" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <table style="width:100%">
        <tr>
            <td valign="top" align="center">
                <%--Mostramos el título de la página--%>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                    Text="Apertura de Conteos"></asp:Label>
                <br />
                <hr style="width:100%" />
            </td>
        </tr>
        <tr>
            <td valign="top" align="left">
                <center>
                <%--Colocamos el UpdatePanel para nuestros asuntos en AJAX--%>
                        <asp:GridView ID="grApertura" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px" OnDataBound="grApertura_DataBound" >
                            <Columns>
                                <asp:BoundField DataField="colProgramacion" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="117px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tipo_conteo" HeaderText="Tipo Conteo" >
                                    <ControlStyle Width="185px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="colFechaIni" HeaderText="Fecha" >
                                    <ControlStyle Width="185px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="estado_conteo">
                                    <ControlStyle Width="153px" />
                                    <ItemStyle Width="10px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="estado_conteo_desc" HeaderText="Estado" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgCerrarpapeleria" runat="server" CommandName="CerrarPapeleria"
                                            Height="33px" ImageUrl="~/Images/Papeleria.jpg" ToolTip="Cerrar Papeleria" Width="28px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgAbrirConteo" runat="server" CommandName="AbrirConteo" Height="28px"
                                            ImageUrl="~/Images/contar.jpg" OnClick="imgAbrirConteo_Click" ToolTip="Abrir Conteo"
                                            Width="28px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField EditText="Detalle" ShowEditButton="True" />
                            </Columns>
                            <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="False"></asp:Label></center>
            </td>
        </tr>
    </table>
</asp:content>