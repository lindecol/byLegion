<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroManualMixtos.aspx.vb" Inherits="ControlPaquete.RegistroManualMixtos" MasterPageFile="~/Pages/MasterPage.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">

<script type="text/javascript">
function esInteger(e){
var charCode
if (navigator.appName == "Netscape"){
charCode = e.which
}
else{
charCode = e.keyCode} 
if (charCode < 48 || charCode > 57){
return false
}
else{
return true}
}
</script>

    <%--Colocamos el UpdatePanel para nuestros asuntos en AJAX--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <%--Mostramos el título y el subtitulo de la página--%>
    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
        Text="Registro Manual Mixto"></asp:Label>
    <p></p>
    <asp:Label ID="lblSubtitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
        Text=""></asp:Label>
    <hr style="width:100%" />
    <br />
    <%--Mostramos los activos propios que pertenecen a otra sucursal--%>
    <asp:Label ID="Label9" runat="server" Font-Size="Small" Text="Productos:" ForeColor="Teal" Font-Bold="True"></asp:Label>
    <asp:DropDownList ID="cmbProductos" runat="server" AutoPostBack="True" ForeColor="Black" Width="60%" DataTextField="Nombre_Producto" DataValueField="Codigo_Producto" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbProductos_SelectedIndexChanged" Font-Size="X-Small">
        <asp:ListItem></asp:ListItem>
    </asp:DropDownList>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1" >
        <ContentTemplate>
            <table style="width:100%">
                <tr>
                    <td align="center" valign="top">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" >
                            <ProgressTemplate >
                                <img src="../Images/clock.gif" />
                                Cargando información...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="Código:" ForeColor="Teal" Font-Bold="True"></asp:Label><asp:TextBox ID="txtCodigo" runat="server" Width="80px" AutoPostBack="True" TabIndex="2"></asp:TextBox></td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <asp:Label ID="lblPropiedad" runat="server" Font-Size="Small" Text="Propiedad:" ForeColor="Teal" Visible="false" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:DropDownList ID="cmbPropiedad" runat="server" AutoPostBack="true" ForeColor="Black" Visible="false">
                            <asp:ListItem Value="P">Propios</asp:ListItem>
                            <asp:ListItem Value="A">Ajenos</asp:ListItem>
                        </asp:DropDownList>
                        <%--Capacidades del Productos--%>
                        <asp:Label ID="lblCapacidad" runat="server" Font-Size="Small" Text="Capacidad:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <asp:DropDownList ID="cmbCapacidadProducto" runat="server" AutoPostBack="false" ForeColor="Black" Visible="false" DataTextField="capacidad" DataValueField="capacidad" />
                        <%--Cantidad--%>
                        <asp:Label ID="lblCantidad" runat="server" Font-Size="Small" Text="Cantidad:" ForeColor="Teal" Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtCantidad" runat="server" MaxLength="6" Width="50px" Visible="false" TabIndex="1"></asp:TextBox>
                        <%--Botón para guardar el activo en la grilla--%>
                        <asp:ImageButton ID="ibProducto" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="ibProducto_Click" Visible="false" ToolTip="Adicionar registro" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Error--%>
                        <asp:Label ID="lblError1" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 18px">
                        <asp:Label ID="lblProductosPropios" runat="server" Font-Bold="True" Font-Size="Small"
                            ForeColor="Teal" Text="Productos Propios:"></asp:Label></td>
                </tr>
                <tr>
                    <td valign="top" align="center">
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grProducto" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="CODIGO_PRODUCTO" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="80px" />
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_PRODUCTO" HeaderText="Producto" >
                                    <ControlStyle Width="445px" />
                                    <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" >
                                    <ControlStyle Width="75px" />
                                    <ItemStyle Font-Size="Small" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCantidadGrilla" runat="server" Width="75px" Text="0" MaxLength="6" />
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Propio" Visible="False">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbEstado" runat="server" Enabled="false" />
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                            Text="Productos Particulares:"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        <asp:GridView ID="grdProductoAjenos" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="CODIGO_PRODUCTO" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="80px" />
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_PRODUCTO" HeaderText="Producto" >
                                    <ControlStyle Width="445px" />
                                    <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" >
                                    <ControlStyle Width="75px" />
                                    <ItemStyle Font-Size="Small" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCantidadGrilla" runat="server" Width="75px" Text="0" MaxLength="6" />
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Propio" Visible="False">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbEstado" runat="server" Enabled="false" />
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:TemplateField>
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
                        <asp:DropDownList ID="cmbActivoPropio" runat="server" AutoPostBack="True" ForeColor="Black" Width="60%" DataTextField="Nombre_Activo" DataValueField="Codigo_Activo" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbActivoPropio_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <br />
                        <%--Familia--%>
                        <asp:Label ID="lblFamilia" runat="server" Font-Size="Small" Text="Familia:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtFamilia" runat="server" Width="100px"></asp:TextBox>
                        <%--Cantidad--%>
                        <asp:Label ID="lblCantidadPropio" runat="server" Font-Size="Small" Text="Cantidad:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtCantidadPropio" runat="server" MaxLength="6" Width="50px"></asp:TextBox>
                        <%--Botón para guardar el activo en la grilla--%>
                        <asp:ImageButton ID="ibActivoPropio" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="ibActivoPropio_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Error--%>
                        <asp:Label ID="lblError2" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="center">
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grActivoPropio" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="CODIGO_ACTIVO" HeaderText="Familia" >
                                    <ControlStyle Width="80px" />
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_ACTIVO" HeaderText="Activo Propio" >
                                    <ControlStyle Width="515px" />
                                    <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCantidadGrilaPropio" runat="server" Width="75px" Text="0" MaxLength="6" />
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:TemplateField>
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
                        <asp:DropDownList ID="cmbActivoAjeno" runat="server" AutoPostBack="True" ForeColor="Black" Width="60%" DataTextField="Nombre_Activo" DataValueField="Codigo_Activo" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbActivoAjeno_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <br />
                        <%--Familia--%>
                        <asp:Label ID="lblFamAjeno" runat="server" Font-Size="Small" Text="Código:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtFamAjeno" runat="server" Width="80px"></asp:TextBox>
                        <%--Cantidad--%>
                        <asp:Label ID="lblCantAjeno" runat="server" Font-Size="Small" Text="Cantidad:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtCantAjeno" runat="server" MaxLength="6" Width="50px"></asp:TextBox>
                        <%--Botón para guardar el activo en la grilla--%>
                        <asp:ImageButton ID="ibActivoAjeno" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="ibActivoAjeno_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Error--%>
                        <asp:Label ID="lblError3" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="center">
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grActivoAjeno" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="CODIGO_ACTIVO" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="80px" />
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_ACTIVO" HeaderText="Activo Ajeno" >
                                    <ControlStyle Width="440px" />
                                    <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCantidadGrilaAjeno" runat="server" Width="75px" Text="0" MaxLength="6" />
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <br />
                        <%--Botón para guardar el activo en la grilla--%>
                        <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="ibGuardar_Click" ToolTip="Guardar registro" />
                    </td>
                </tr>
            </table>
            
            <ajaxToolkit:FilteredTextBoxExtender
                ID="FilteredTextBoxExtender1"
                runat="server"
                TargetControlID="txtCodigo"
                FilterType="Numbers" />
                
            <ajaxToolkit:FilteredTextBoxExtender
                ID="FilteredTextBoxExtender2"
                runat="server"
                TargetControlID="txtCantidad"
                FilterType="Numbers" />
                
            <ajaxToolkit:FilteredTextBoxExtender
                ID="FilteredTextBoxExtender3"
                runat="server"
                TargetControlID="txtFamilia"
                FilterType="Numbers" />
                
            <ajaxToolkit:FilteredTextBoxExtender
                ID="FilteredTextBoxExtender4"
                runat="server"
                TargetControlID="txtCantidadPropio"
                FilterType="Numbers" />
                
            <ajaxToolkit:FilteredTextBoxExtender
                ID="FilteredTextBoxExtender5"
                runat="server"
                TargetControlID="txtFamAjeno"
                FilterType="Numbers" />
                
            <ajaxToolkit:FilteredTextBoxExtender
                ID="FilteredTextBoxExtender6"
                runat="server"
                TargetControlID="txtCantAjeno"
                FilterType="Numbers" />
            
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cmbProductos" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ibProducto" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="cmbActivoPropio" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ibActivoPropio" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="cmbActivoAjeno" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ibActivoAjeno" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ibGuardar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:content>