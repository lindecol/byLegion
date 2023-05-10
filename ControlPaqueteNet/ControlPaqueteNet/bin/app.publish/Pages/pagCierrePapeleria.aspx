<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="pagCierrePapeleria.aspx.cs" Inherits="ControlPaqueteNet.Pages.pagCierrePapeleria" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">

  <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <br />
    <table style="width: 347px">
        <tr>
            <td align="center">
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                    Text="Cierre papeleria"></asp:Label>
                <asp:Label ID="lblIdconteo" runat="server" Text="lblIdconteo" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td align="center">
            <table width="60%">
                <tr>
                    <td align="left"><asp:ImageButton ID="ibAtras" runat="server" ImageUrl="~/Images/Atras.GIF" ToolTip="Atrás" Width="24px" OnClick="ibAtras_Click1" /></td>
                    <td><asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" OnClick="ibGuardar_Click"
                    ToolTip="Cerrar papeleria" Width="24px" /></td>
                </tr>
            </table>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                    Text="Papeleria NO Rendida"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grRutasPendientes" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%" >
                    <Columns>
                        <asp:BoundField DataField="CONS" HeaderText="ID">
                            <ItemStyle Font-Size="X-Small" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FECHA_CARGA" HeaderText="Fecha Carga" >
                            <ControlStyle Width="80px" />
                            <ItemStyle Font-Size="X-Small" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CODI_RUTA" HeaderText="Ruta" >
                            <ControlStyle Width="515px" />
                            <ItemStyle Font-Size="X-Small" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VEHICU" HeaderText="Vehiculo">
                            <ItemStyle Font-Size="X-Small" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GUIA" HeaderText="N&#176; Guia">
                            <ItemStyle Font-Size="X-Small" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MOTIVO" HeaderText="Motivo">
                            <ItemStyle Font-Size="X-Small" Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Justificacion">
                            <ItemTemplate>
                                <asp:TextBox ID="txtJustificacion" runat="server" Width="214px" MaxLength="50" />
                            </ItemTemplate>
                            <ItemStyle Font-Size="X-Small" />
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                    <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                </asp:GridView>
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Text="lblError:" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                    Text="Papeleria Rendida Pendiente por digitar:"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gdPapeleriaNoDigitada" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="CONS" HeaderText="Cons">
                            <ItemStyle Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FECHA_CARGA" HeaderText="Fecha Carga" >
                            <ControlStyle Width="80px" />
                            <ItemStyle Font-Size="X-Small" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CODI_RUTA" HeaderText="Ruta" >
                            <ControlStyle Width="515px" />
                            <ItemStyle Font-Size="X-Small" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VEHICU" HeaderText="Vehiculo">
                            <ItemStyle Font-Size="X-Small" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TIPO_DOC" HeaderText="Tipo Doc">
                            <ItemStyle Font-Size="X-Small" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="COMPROBANTE" HeaderText="N&#176; Documento">
                            <ItemStyle Font-Size="X-Small" Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Justificacion">
                            <ItemTemplate>
                                <asp:TextBox ID="txtJustificacion" runat="server" Width="214px" MaxLength="50" />
                            </ItemTemplate>
                            <ItemStyle Font-Size="X-Small" />
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                    <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                </asp:GridView>
                <asp:Label ID="lblError1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Text="lblError:" Visible="False"></asp:Label></td>
        </tr>
    </table>
    <br />
</asp:content>