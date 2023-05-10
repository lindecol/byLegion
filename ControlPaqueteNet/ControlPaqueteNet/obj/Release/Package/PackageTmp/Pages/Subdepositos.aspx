<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Subdepositos.aspx.cs" Inherits="ControlPaqueteNet.Pages.Subdepositos" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <table style="width:100%">
        <tr>
            <td valign="top" align="center">
                <%--Mostramos el título de la página--%>
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                    Text="Subdepósitos"></asp:Label>
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
                        <%--Sucursal--%>
                        &nbsp; &nbsp;<%--Sector--%>&nbsp;
                        <br />
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <img src="../Images/clock.gif" />
                                Cargando información...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <table border="0" style="width: 60%; border-top-style: none; border-right-style: none;
                            border-left-style: none; border-bottom-style: none">
                            <tr>
                                <td align="left" style="width: 18%">
                        <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Sucursales:" ForeColor="Teal" Font-Bold="True"></asp:Label></td>
                                <td align="left" style="width: 47%">
                        <asp:DropDownList ID="cmbSucursal" runat="server" AutoPostBack="True" ForeColor="Black" Width="250px" DataTextField="nombre_sucursal" DataValueField="codigo_sucursal" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbSucursal_SelectedIndexChanged" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 18%">
                        <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Sectores:" ForeColor="Teal" Font-Bold="True"></asp:Label></td>
                                <td align="left" style="width: 47%">
                        <asp:DropDownList ID="cmbSector" runat="server" AutoPostBack="True" ForeColor="Black" Width="250px" DataTextField="colNombre" DataValueField="colCodigo" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbSector_SelectedIndexChanged" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 18%">
                        <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Subdepósitos:" ForeColor="Teal" Font-Bold="True"></asp:Label></td>
                                <td align="left" style="width: 47%">
                        <asp:DropDownList ID="cmbSubdeposito" runat="server" AutoPostBack="False" ForeColor="Black" Width="250px" DataTextField="nombre_subdepoisto" DataValueField="codigo_subdeposito"  /></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 18%">
                                </td>
                                <td align="left" style="width: 47%">
                                    <asp:CheckBox ID="chkCierraPapeleria" runat="server" Text="Controla papeleria" /></td>
                            </tr>
                            <tr>
                                <td style="width: 18%">
                                </td>
                                <td align="right" style="width: 47%">
                        <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="ibGuardar_Click" /></td>
                            </tr>
                        </table>
                        <br />
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label><br />
                        <%--Grilla donde mostraremos los datos--%>
                        <asp:GridView ID="grSubdeposito" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px">
                            <Columns>
                                <asp:BoundField DataField="secuencia" HeaderText="Secuencia" >
                                    <ControlStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_SECTOR" HeaderText="Sector" />
                                <asp:BoundField DataField="CODIGO_SUBDEPOSITO" HeaderText="C&#243;digo" >
                                    <ControlStyle Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_SUBDEPOSITO" HeaderText="Subdep&#243;sito" >
                                    <ControlStyle Width="520px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CONTROLA_PAPELERIA" HeaderText="Control Papeleria">
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" Wrap="True" />
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:CommandField SelectText="Eliminar" ShowSelectButton="True">
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
                        <asp:AsyncPostBackTrigger ControlID="cmbSucursal" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmbSector" EventName="SelectedIndexChanged" />
                    </Triggers>
                 </asp:UpdatePanel>
                </center>
            </td>
        </tr>
    </table>
</asp:content>