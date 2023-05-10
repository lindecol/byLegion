<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Anulacion.aspx.cs" Inherits="ControlPaqueteNet.Pages.Anulacion" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <table style="width:100%">
        <tr>
            <td valign="top" align="center">
                <%--Mostramos el título de la página--%>
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                    Text="Anulación"></asp:Label>
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
                        <%--Longitud de la etiqueta--%>
                        <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Programación:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtConteo" runat="server" MaxLength="3" Width="24px" ReadOnly="true" Enabled="false"></asp:TextBox>
                        <%--Tipo de Etiqueta--%>
                        <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Motivo Anulación:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:DropDownList ID="cmbMotivo" runat="server" AutoPostBack="False" ForeColor="Black" Width="200px" DataTextField="descripcion_anulacion" DataValueField="codigo_anulacion" AppendDataBoundItems="True">
                        </asp:DropDownList>
                        <%--Botón para guardar--%>
                        <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="ibGuardar_Click" />
                        <p>
                        </p>
                        <%--Error--%>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <br />
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grAnulacion" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px">
                            <Columns>
                                <asp:BoundField DataField="colProgramacion" HeaderText="Programaci&#243;n" >
                                    <ControlStyle Width="210px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="colFechaIni" HeaderText="Fecha Inicio" >
                                    <ControlStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tipo_conteo" HeaderText="Tipo Conteo">
                                    <ControlStyle Width="210px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Anular">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbEstado" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True">
                                    <ControlStyle Width="80px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <%--Cada vez que hagamos clic en el botón vamos a utilizar la grilla--%>
                        <asp:AsyncPostBackTrigger ControlID="ibGuardar" EventName="Click" />
                    </Triggers>
                 </asp:UpdatePanel>
                </center>
            </td>
        </tr>
    </table>
</asp:content>