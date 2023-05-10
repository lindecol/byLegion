<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroManualActivos.aspx.vb" Inherits="ControlPaquete.RegistroManualActivos" MasterPageFile="~/Pages/MasterPage.Master" %>

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
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table style="width:100%">
                <tr>
                    <td valign="top" align="center">
                        <%--Mostramos el título y el subtitulo de la página--%>
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                            Text="Registro Manual Activos"></asp:Label>
                        <p></p>
                        <asp:Label ID="lblSubtitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                            Text=""></asp:Label>
                        <hr style="width:100%" />
                        </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:LinkButton ID="LinkButton1" runat="server">Agregar Activo</asp:LinkButton></td>
                </tr>
                <tr>
                    <td valign="top" align="center">
                        <%--Error--%>
                        <asp:Label ID="lblError1" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label></td>
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
                                        <asp:TextBox ID="txtCantidadGrila" runat="server" Width="75px" Text="0" MaxLength="6" />
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
                    <td valign="top" align="center">
                        <%--Cantidad--%>
                        <%--Botón para guardar el activo en la grilla--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:LinkButton ID="LinkButton2" runat="server">Agregar Ajeno</asp:LinkButton></td>
                </tr>
                <tr>
                    <td valign="top" align="center">
                        <%--Error--%>
                        &nbsp;
                        <asp:Label ID="lblError2" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label></td>
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
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
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
                TargetControlID="txtFamilia"
                FilterType="Numbers" />
                
            <ajaxToolkit:FilteredTextBoxExtender
                ID="FilteredTextBoxExtender2"
                runat="server"
                TargetControlID="txtCantidad"
                FilterType="Numbers" />
                
            <ajaxToolkit:FilteredTextBoxExtender
                ID="FilteredTextBoxExtender3"
                runat="server"
                TargetControlID="txtFamAjeno"
                FilterType="Numbers" />
                                
            <ajaxToolkit:FilteredTextBoxExtender
                ID="FilteredTextBoxExtender4"
                runat="server"
                TargetControlID="txtCantAjeno"
                FilterType="Numbers" />
              
              <asp:Panel ID="Panel1" runat="server"
                             Width="50%" Style="display: none" CssClass="modalPopup">
                            <table style="width: 100%%" width="100%">
                                <tr>
                                    <td>
                        <asp:Label ID="Label9" runat="server" Font-Size="Small" Text="Activos Propios:" ForeColor="Teal" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="cmbActivoPropio" runat="server"  ForeColor="Black" Width="100%" DataTextField="Nombre_Activo" DataValueField="Codigo_Activo" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbActivoPropio_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                        <asp:Label ID="lblFamilia" runat="server" Font-Size="Small" Text="Familia:" ForeColor="Teal" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtFamilia" runat="server" Width="100px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                        <asp:Label ID="lblCantidad" runat="server" Font-Size="Small" Text="Cantidad:" ForeColor="Teal" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtCantidad" runat="server" MaxLength="6" Width="50px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <table width="50%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar" /></td>
                                                <td>
                            <asp:Button ID="CancelButton"
                                runat="server" Text="Cancel"  /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
              <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" 
                            TargetControlID="LinkButton1"
                            PopupControlID="Panel1"           
                            CancelControlID="CancelButton"                  
                            BackgroundCssClass="modalBackground"
                            DropShadow="True" />
               
               <asp:Panel ID="Panel2" runat="server"
                             Width="50%" Style="display: none" CssClass="modalPopup">
                            <table style="width: 100%%" width="100%">
                                <tr>
                                    <td>
                                        &nbsp;<asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Activos Ajenos:" ForeColor="Teal" Font-Bold="True"></asp:Label><asp:DropDownList ID="cmbActivoAjeno" runat="server" ForeColor="Black" Width="100%" DataTextField="Nombre_Activo" DataValueField="Codigo_Activo" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbActivoAjeno_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;<asp:Label ID="lblFamAjeno" runat="server" Font-Size="Small" Text="Código:" ForeColor="Teal" Font-Bold="True"></asp:Label><asp:TextBox ID="txtFamAjeno" runat="server" Width="80px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;<asp:Label ID="lblCantAjeno" runat="server" Font-Size="Small" Text="Cantidad:" ForeColor="Teal" Font-Bold="True"></asp:Label><asp:TextBox ID="txtCantAjeno" runat="server" MaxLength="6" Width="50px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <table width="50%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="AgregarAjenos" runat="server" OnClick="AgregarAjenos_Click" Text="Agregar" /></td>
                                                <td>
                            <asp:Button ID="CancelarAjenos"
                                runat="server" Text="Cancel" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
              <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                            TargetControlID="LinkButton2"
                            PopupControlID="Panel2"           
                            CancelControlID="CancelarAjenos"                  
                            BackgroundCssClass="modalBackground"
                            DropShadow="True" />
       
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cmbActivoPropio" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="cmbActivoAjeno" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="AgregarAjenos" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ibGuardar" EventName="Click" />
        </Triggers>
        
        
    </asp:UpdatePanel>
</asp:content>