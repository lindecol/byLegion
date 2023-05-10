<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroManualProductos.aspx.vb" Inherits="ControlPaquete.RegistroManualProductos" MasterPageFile="~/Pages/MasterPage.Master" %>

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
        Text="Registro Manual Productos"></asp:Label>
    <p></p>
    <asp:Label ID="lblSubtitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
        Text=""></asp:Label>
    <hr style="width:100%" />
    <%--Mostramos los activos propios que pertenecen a otra sucursal--%>
    &nbsp;
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table style="width:100%">
                <tr>
                    <td align="left" valign="top">
    <asp:Label ID="Label9" runat="server" Font-Size="Small" Text="Productos:" ForeColor="Teal" Font-Bold="True"></asp:Label><asp:DropDownList ID="cmbProductos" runat="server" ForeColor="Black" Width="60%" DataTextField="Nombre_Producto" DataValueField="Codigo_Producto" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbProductos_SelectedIndexChanged" AutoPostBack="True" Font-Size="X-Small">
        <asp:ListItem></asp:ListItem>
    </asp:DropDownList>
                            <asp:TextBox ID="txtCodigo" runat="server" Width="80px" MaxLength="10" Enabled="False" EnableTheming="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                <table width="100%">
                    <tr>
                        <td align="left" style="width: 30%">
                            <asp:Label ID="lblPropiedad" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                                Text="Propiedad:"></asp:Label><asp:DropDownList ID="cmbPropiedad" runat="server"
                                    AutoPostBack="true" ForeColor="Black">
                                    <asp:ListItem Value="P">Propios</asp:ListItem>
                                    <asp:ListItem Value="A">Ajenos</asp:ListItem>
                                </asp:DropDownList></td>
                        <td style="width: 30%" align="left">
                            <asp:Label ID="lblCapacidad" runat="server" Font-Size="Small" Text="Capacidad:" ForeColor="Teal" Font-Bold="True"></asp:Label><asp:DropDownList ID="cmbCapacidadProducto" runat="server" AutoPostBack="false" ForeColor="Black" DataTextField="capacidad" DataValueField="capacidad" /></td>
                        <td align="left" style="width: 30%">
                        <asp:Label ID="lblCantidad" runat="server" Font-Size="Small" Text="Cantidad:" ForeColor="Teal" Font-Bold="True"></asp:Label><asp:TextBox ID="txtCantidad" runat="server" MaxLength="6" Width="50px"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 30%">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Agregar Producto</asp:LinkButton></td>
                    </tr>
                </table>                    
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Error--%>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <img src="../Images/clock.gif" />
                                Cargando información...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                            Text="Productos propios:"></asp:Label></td>
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
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCantidadGrilla" runat="server" Width="75px" Text="0" MaxLength="6" />
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
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                            Text="Productos Ajenos"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        <asp:GridView ID="grProductoParticular" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%">
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
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCantidadGrilla" runat="server" Width="75px" Text="0" MaxLength="6" />
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
                    <td>
                        <%--Error--%>
                        <asp:Label ID="lblError1" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <br />
                        <%--Botón para guardar el activo en la grilla--%>
                        <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="ibGuardar_Click" />
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cmbProductos" EventName="SelectedIndexChanged" />            
            <asp:AsyncPostBackTrigger ControlID="LinkButton1" EventName="Click" />           
            <asp:AsyncPostBackTrigger ControlID="ibGuardar" EventName="Click" />
        </Triggers> 
    </asp:UpdatePanel>
</asp:content>