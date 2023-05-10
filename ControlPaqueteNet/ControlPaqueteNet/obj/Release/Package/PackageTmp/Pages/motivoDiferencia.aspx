<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="motivoDiferencia.aspx.cs" Inherits="ControlPaqueteNet.Pages.motivoDiferencia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <table style="width:100%">
        <tr>
            <td valign="top" align="center">
                <%--Mostramos el título de la página--%>
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                    Text="Motivos de Diferencia"></asp:Label>
                <br />
                <hr style="width:100%" />
            </td>
        </tr>
        <tr>
            <td valign="top" align="center">
               <center>
                <%--Colocamos el UpdatePanel para nuestros asuntos en AJAX--%>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                        <%--Descripción--%>
                        <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Descripción:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="80" Width="304px"></asp:TextBox>
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
                        <asp:GridView ID="grDiferencia" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px">
                            <Columns>
                                <asp:BoundField DataField="codigo_diferencia" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="colNombre" HeaderText="Descripci&#243;n" >
                                    <ControlStyle Width="440px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="estado_diferencia" HeaderText="Estado">
                                    <ControlStyle Width="160px" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True">
                                    <ControlStyle Width="80px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="teal" ForeColor="white" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                        
                        <ajaxToolkit:FilteredTextBoxExtender
                            ID="FilteredTextBoxExtender4"
                            runat="server" 
                            TargetControlID="txtDescripcion"
                            FilterType="Custom" ValidChars="abcdefghijklmnopqrstuvwxyz1234567890 ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                            FilterMode="ValidChars" />
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