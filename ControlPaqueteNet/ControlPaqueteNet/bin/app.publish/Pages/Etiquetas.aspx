<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Etiquetas.aspx.cs" Inherits="ControlPaqueteNet.Etiquetas" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <table style="width:100%">
        <tr>
            <td valign="top" align="center">
                <%--Mostramos el título de la página--%>
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                    Text="Etiquetas"></asp:Label>
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
                        <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Longitud:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtLongitud" runat="server" MaxLength="3" Width="24px"></asp:TextBox>
                        <%--Tipo de Etiqueta--%>
                        <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Tipo Etiqueta:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:DropDownList ID="cmbTipo" runat="server" AutoPostBack="False" ForeColor="Black">
                            <asp:ListItem Value="A" Selected="True">Activos Propios</asp:ListItem>
                            <asp:ListItem Value="P">Productos Propios</asp:ListItem>
                            <asp:ListItem Value="J">Activos Ajenos</asp:ListItem>
                        </asp:DropDownList>
                        <%--Descripción--%>
                        <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Descripción:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                        <%--Check que nos indica el estado de la etiqueta--%>
                        <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" Font-Size="Small" ForeColor="Teal" Font-Bold="True" Visible="False" />
                        <%--Botón para guardar--%>
                        <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="ibGuardar_Click" />
                        <p>
                        </p>
                        <%--Error--%>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <br />
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grEtiqueta" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px">
                            <Columns>
                                <asp:BoundField DataField="longitud_etiqueta" HeaderText="Longitud" >
                                    <ControlStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tipo_etiqueta" HeaderText="Tipo Etiqueta" >
                                    <ControlStyle Width="160px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="descripcion" HeaderText="Descripci&#243;n" >
                                    <ControlStyle Width="270px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="Estado">
                                    <ControlStyle Width="160px" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True">
                                    <ControlStyle Width="80px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="Teal" ForeColor="White" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>                        
                        
                        <!--<ajaxToolkit:FilteredTextBoxExtender
                            ID="FilteredTextBoxExtender1"
                            runat="server"
                            TargetControlID="txtLongitud"
                            FilterType="Numbers" />
                            
                        <ajaxToolkit:FilteredTextBoxExtender
                            ID="FilteredTextBoxExtender4"
                            runat="server" 
                            TargetControlID="txtDescripcion"
                            FilterType="Custom"
                            FilterMode="InvalidChars"
                            InvalidChars="|'¿+{}<-°!#$%&/()=?¡¨*[];:_>¬\~^`@" />
                            -->
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