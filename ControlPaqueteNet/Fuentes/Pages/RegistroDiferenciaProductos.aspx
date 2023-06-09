<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroDiferenciaProductos.aspx.vb" Inherits="ControlPaquete.RegistroDiferenciaProductos" MasterPageFile="~/Pages/MasterPage.Master" %>

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
                            Text="Registro Diferencia Productos"></asp:Label>
                        <p></p>
                        <asp:Label ID="lblSubtitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                            Text=""></asp:Label>
                        <hr style="width:100%" />
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <img src="../Images/clock.gif" />
                                Cargando informaci�n...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <%--Mostramos los activos propios que pertenecen a otra sucursal--%>
                        <asp:Label ID="Label9" runat="server" Font-Size="Small" Text="Productos Propios:" ForeColor="Teal" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <%--Familia--%>
                        <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="C�digo:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label><asp:TextBox ID="txtCodigo" runat="server" Width="80px" enabled="false" Visible="false"></asp:TextBox><%--Justificaci�n de Diferencia--%><asp:Label ID="lblDiferencia" runat="server" Font-Size="Small" Text="Justificaci�n:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label><asp:DropDownList ID="cmbDiferencia" runat="server" AutoPostBack="True" ForeColor="Black" Width="400px" DataTextField="colNombre" DataValueField="codigo_diferencia" AppendDataBoundItems="True" Visible="false" OnSelectedIndexChanged="cmbDiferencia_SelectedIndexChanged" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="center">
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grProductos" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px" OnDataBound="grProductos_DataBound">
                            <Columns>
                                <asp:BoundField DataField="ID_ACTIVO_PRODUCTO" HeaderText="C�digo" >
                                    <ControlStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_ARTICULO" HeaderText="Producto" >
                                    <ControlStyle Width="220px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VOLUMEN" HeaderText="Volumen" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CAPACIDAD_SISTEMA" HeaderText="Vol Sist" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DIFERENCIA_PRODUCTO" HeaderText="Diferencia" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Justificaci&#243;n">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CODIGO_MOTIVO_DIFERENCIA") %>'
                                            Visible="False"></asp:Label>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CODIGO_MOTIVO_DIFERENCIA") %>' Width="100%"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbDiferenciaProdProp" runat="server" Width="100%" DataTextField="colNombre" DataValueField="codigo_diferencia">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" Visible="false">
                                    <ControlStyle Width="80px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                            Text="Productos Particulares:"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblCodigoPart" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                            Text="C�digo:" Visible="False"></asp:Label><asp:TextBox ID="txtCodigoPart" runat="server"
                                Enabled="false" Visible="false" Width="80px"></asp:TextBox><asp:Label ID="lblDiferenciaPart"
                                    runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="Justificaci�n:"
                                    Visible="False"></asp:Label><asp:DropDownList ID="cmbDiferenciaPart" runat="server" AutoPostBack="True" ForeColor="Black" Width="400px" DataTextField="colNombre" DataValueField="codigo_diferencia" AppendDataBoundItems="True" Visible="false" OnSelectedIndexChanged="cmbDiferenciaPart_SelectedIndexChanged" >
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <%--Error--%><asp:GridView ID="grProductosPart" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px" OnSelectedIndexChanged="grProductosPart_SelectedIndexChanged" OnDataBound="grProductosPart_DataBound">
                            <Columns>
                                <asp:BoundField DataField="ID_ACTIVO_PRODUCTO" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_ARTICULO" HeaderText="Producto" >
                                    <ControlStyle Width="220px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VOLUMEN" HeaderText="Volumen" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CAPACIDAD_SISTEMA" HeaderText="Vol Sist" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DIFERENCIA_PRODUCTO" HeaderText="Diferencia" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Justificaci&#243;n">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CODIGO_MOTIVO_DIFERENCIA") %>'
                                            Visible="False"></asp:Label>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CODIGO_MOTIVO_DIFERENCIA") %>' Width="100%"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbDiferenciaProdProp" runat="server" Width="100%" DataTextField="colNombre" DataValueField="codigo_diferencia">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" Visible="false">
                                    <ControlStyle Width="80px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td valign="top">
                        <br />
                        <%--Bot�n para guardar el activo en la grilla--%>
                        <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="ibGuardar_Click" ToolTip="Registrar Diferencias" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cmbDiferencia" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ibGuardar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:content>