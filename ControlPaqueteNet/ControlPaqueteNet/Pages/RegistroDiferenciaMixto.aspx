<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroDiferenciaMixto.aspx.cs" Inherits="ControlPaqueteNet.Pages.RegistroDiferenciaMixto" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <%--Colocamos el UpdatePanel para nuestros asuntos en AJAX--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table style="width:100%">
                <tr>
                    <td valign="top" align="center">
                        <%--Mostramos el título y el subtitulo de la página--%>
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                            Text="Registro Diferencia Mixto"></asp:Label>
                        <p></p>
                        <asp:Label ID="lblSubtitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                            Text=""></asp:Label>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <img src="../Images/clock.gif" />
                                Cargando información...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <hr style="width:100%" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <%--Mostramos los activos propios que pertenecen a otra sucursal--%>
                        <asp:Label ID="Label9" runat="server" Font-Size="Small" Text="Productos Propios:" ForeColor="Teal" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left" style="height: 26px">
                        <%--Familia--%>
                        <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="Código:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label><asp:TextBox ID="txtCodigo" runat="server" Width="80px" enabled="false" Visible="false"></asp:TextBox><%--Justificación de Diferencia--%><asp:Label ID="lblDiferencia" runat="server" Font-Size="Small" Text="Justificación:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label><asp:DropDownList ID="cmbDiferencia" runat="server" AutoPostBack="True" ForeColor="Black" Width="400px" DataTextField="colNombre" DataValueField="codigo_diferencia" AppendDataBoundItems="True" Visible="false" OnSelectedIndexChanged="cmbDiferencia_SelectedIndexChanged" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td valign="top" align="center">
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grProductos" runat="server" AutoGenerateColumns="False" Width="100%" OnDataBound="grProductos_DataBound" OnSelectedIndexChanged="grProductos_SelectedIndexChanged" >
                            <Columns>
                                <asp:BoundField DataField="ID_ACTIVO_PRODUCTO" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="70px" />
                                    <HeaderStyle Wrap="False" />                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_ARTICULO" HeaderText="Producto" >
                                    <ControlStyle Width="220px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VOLUMEN" HeaderText="Volumen" >
                                    <ControlStyle Width="80px" />                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="CAPACIDAD_SISTEMA" HeaderText="Vol Sist" >
                                    <ControlStyle Width="100px" />                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="DIFERENCIA_PRODUCTO" HeaderText="Diferencia" >
                                    <ControlStyle Width="80px" />                                   
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
                                <asp:CommandField ShowSelectButton="True" Visible="False">
                                    <ControlStyle Width="0px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                            Text="Productos Particulares:"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <asp:Label ID="lblCodigopart" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                            Text="Código:" Visible="False"></asp:Label><asp:TextBox ID="txtCodigoPart" runat="server"
                                Enabled="false" Visible="false" Width="80px"></asp:TextBox><asp:Label ID="lblDiferenciaPart"
                                    runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="Justificación:"
                                    Visible="False"></asp:Label><asp:DropDownList ID="cmbDiferenciaPart" runat="server" AutoPostBack="True" ForeColor="Black" Width="400px" DataTextField="colNombre" DataValueField="codigo_diferencia" AppendDataBoundItems="True" Visible="false" OnSelectedIndexChanged="cmbDiferenciaPart_SelectedIndexChanged" >
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        <asp:GridView ID="grProductosParticulares" runat="server" AutoGenerateColumns="False" Width="750px" OnSelectedIndexChanged="grProductosParticulares_SelectedIndexChanged" OnDataBound="grProductosParticulares_DataBound">
                            <Columns>
                                <asp:BoundField DataField="ID_ACTIVO_PRODUCTO" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_ARTICULO" HeaderText="Producto" >
                                    <ControlStyle Width="220px" />
                                    <ItemStyle HorizontalAlign="Left" />
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
                                        <asp:DropDownList ID="cmbDiferenciaPart" runat="server" Width="100%" DataTextField="colNombre" DataValueField="codigo_diferencia">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True"  Visible="False">
                                    <ControlStyle Width="80px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
            <table style="width:100%">
                <tr>
                    <td valign="top" align="left">
                        <%--Mostramos los activos propios que pertenecen a otra sucursal--%>
                        <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Activos Propios:" ForeColor="Teal" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <%--Familia--%>
                        <asp:Label ID="lblFamilia" runat="server" Font-Size="Small" Text="Familia:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label><asp:TextBox ID="txtFamilia" runat="server" Width="100px" enabled="false" Visible="false"></asp:TextBox><%--Justificación de Diferencia--%><asp:Label ID="lblDifPropio" runat="server" Font-Size="Small" Text="Justificación:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label><asp:DropDownList ID="cmbDifPropio" runat="server" AutoPostBack="True" ForeColor="Black" Width="400px" DataTextField="colNombre" DataValueField="codigo_diferencia" AppendDataBoundItems="True" Visible="false" OnSelectedIndexChanged="cmbDifPropio_SelectedIndexChanged" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td valign="top" align="center">
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grActivoPropio" runat="server" AutoGenerateColumns="False" Width="750px" OnDataBound="grActivoPropio_DataBound" OnSelectedIndexChanged="grActivoPropio_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="ID_ACTIVO_PRODUCTO" HeaderText="Familia" >
                                    <ControlStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_ARTICULO" HeaderText="Activo Propio" >
                                    <ControlStyle Width="320px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CANTIDAD_CONTEO" HeaderText="Cantidad" >
                                    <ControlStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CANTIDAD_SISTEMA" HeaderText="Sistema" >
                                    <ControlStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DIFERENCIA_ACTIVO" HeaderText="Diferencia" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Justificaci&#243;n">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CODIGO_MOTIVO_DIFERENCIA") %>'
                                            Visible="False"></asp:Label>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CODIGO_MOTIVO_DIFERENCIA") %>' Width="100%"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbDiferenciaActPro" runat="server" Width="100%" DataTextField="colNombre" DataValueField="codigo_diferencia">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True"  Visible="False">
                                    <ControlStyle Width="80px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <br />
                        <%--Mostramos los activos propios que pertenecen a otra sucursal--%>
                        <asp:Label ID="Label5" runat="server" Font-Size="Small" Text="Activos Ajenos:" ForeColor="Teal" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <%--Familia--%>
                        <asp:Label ID="lblFamAjeno" runat="server" Font-Size="Small" Text="Código:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label><asp:TextBox ID="txtFamAjeno" runat="server" Width="80px" enabled="false" Visible="false"></asp:TextBox><%--Justificación de Diferencia--%><asp:Label ID="lblDifAjeno" runat="server" Font-Size="Small" Text="Justificación:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label><asp:DropDownList ID="cmbDifAjeno" runat="server" AutoPostBack="True" ForeColor="Black" Width="400px" DataTextField="colNombre" DataValueField="codigo_diferencia" AppendDataBoundItems="True" Visible="false" OnSelectedIndexChanged="cmbDifAjeno_SelectedIndexChanged" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td valign="top" align="center">
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grActivoAjeno" runat="server" AutoGenerateColumns="False" Width="750px" OnDataBound="grActivoAjeno_DataBound" OnSelectedIndexChanged="grActivoAjeno_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="ID_ACTIVO_PRODUCTO" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_ARTICULO" HeaderText="Activo Ajeno" >
                                    <ControlStyle Width="320px" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CANTIDAD_CONTEO" HeaderText="Cantidad" >
                                    <ControlStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CANTIDAD_SISTEMA" HeaderText="Cant Sist" >
                                    <ControlStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DIFERENCIA_ACTIVO" HeaderText="Diferencia" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Justificaci&#243;n">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CODIGO_MOTIVO_DIFERENCIA") %>'
                                            Visible="False"></asp:Label>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CODIGO_MOTIVO_DIFERENCIA") %>' Width="100%"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbDiferenciaActAjeno" runat="server" Width="100%" DataTextField="colNombre" DataValueField="codigo_diferencia">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True"  Visible="False">
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
                        <%--Error--%>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <br />
                        <%--Botón para guardar el activo en la grilla--%>
                        <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="ibGuardar_Click" ToolTip="Registrar Diferencias" />
                        <br />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cmbDifPropio" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbDifAjeno" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbDiferencia" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ibGuardar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:content>