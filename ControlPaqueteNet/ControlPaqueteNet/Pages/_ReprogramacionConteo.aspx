<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReprogramacionConteo.aspx.vb" Inherits="ControlPaquete.ReprogramacionConteo" MasterPageFile="~/Pages/MasterPage.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <%--Colocamos el UpdatePanel para nuestros asuntos en AJAX--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table style="width:100%">
                <tr>
                    <td valign="top" align="center" colspan="6">
                        <%--Mostramos el título y el subtitulo de la página--%>
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                            Text="Reprogramación Conteo"></asp:Label>
                        <p></p>
                        <asp:Label ID="lblSubtitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                            Text=""></asp:Label>
                        <hr style="width:100%" />
                    </td>
                </tr>
                <tr style="height:32px">
                    <%--Mostramos la caja de texto donde va la fecha--%>
                    <td align="left" valign="top" style="width: 134px">
                        <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Fecha Inicio:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;</td>
                    <td align="left" style="width: 230px" valign="top">
                        <asp:TextBox ID="txtDate" runat="server" ReadOnly="True" Width="176px"></asp:TextBox>
                        &nbsp;
                        <asp:ImageButton ID="ibCalendario" runat="server" ImageUrl="~/Images/Calendar.gif" Width="16px" />
                    </td>
                    <td align="left" valign="top" colspan="4">
                        <%--Mostramos el calendario--%>
                        <asp:Calendar ID="MiCalendario" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="24px" NextPrevFormat="FullMonth" Width="88px" Visible="false">
                            <SelectedDayStyle BackColor="Red" ForeColor="White" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                                Font-Size="12pt" ForeColor="Teal" />
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <%--Mostramos la hora de inicio--%>
                    <td align="left" valign="top" style="width: 134px">
                        <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Hora Inicio:" ForeColor="Teal" Width="88px" Font-Bold="True"></asp:Label></td>
                    <td align="left" valign="top" style="width: 150px">
                        <asp:DropDownList ID="cmbHoraInicio" runat="server" AutoPostBack="False" ForeColor="Black" Width="70px">
                            <asp:ListItem Value="0" Selected="True">12:00</asp:ListItem>
                            <asp:ListItem Value="1">12:30</asp:ListItem>
                            <asp:ListItem Value="2">01:00</asp:ListItem>
                            <asp:ListItem Value="3">01:30</asp:ListItem>
                            <asp:ListItem Value="4">02:00</asp:ListItem>
                            <asp:ListItem Value="5">02:30</asp:ListItem>
                            <asp:ListItem Value="6">03:00</asp:ListItem>
                            <asp:ListItem Value="7">03:30</asp:ListItem>
                            <asp:ListItem Value="8">04:00</asp:ListItem>
                            <asp:ListItem Value="9">04:30</asp:ListItem>
                            <asp:ListItem Value="10">05:00</asp:ListItem>
                            <asp:ListItem Value="11">05:30</asp:ListItem>
                            <asp:ListItem Value="12">06:00</asp:ListItem>
                            <asp:ListItem Value="13">06:30</asp:ListItem>
                            <asp:ListItem Value="14">07:00</asp:ListItem>
                            <asp:ListItem Value="15">07:30</asp:ListItem>
                            <asp:ListItem Value="16">08:00</asp:ListItem>
                            <asp:ListItem Value="17">08:30</asp:ListItem>
                            <asp:ListItem Value="18">09:00</asp:ListItem>
                            <asp:ListItem Value="19">09:30</asp:ListItem>
                            <asp:ListItem Value="20">10:00</asp:ListItem>
                            <asp:ListItem Value="21">10:30</asp:ListItem>
                            <asp:ListItem Value="22">11:00</asp:ListItem>
                            <asp:ListItem Value="23">11:30</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                        <asp:DropDownList ID="cmbHora" runat="server" AutoPostBack="False" ForeColor="Black" Width="64px">
                            <asp:ListItem Value="0" Selected="True">AM</asp:ListItem>
                            <asp:ListItem Value="1">PM</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <%--Mostramos la hora fin--%>
                    <td align="left" valign="top" style="width: 75px">
                        <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Hora Fin:" ForeColor="Teal" Font-Bold="True" Width="72px"></asp:Label>&nbsp;</td>
                    <td align="left" valign="top" colspan="3">
                        <asp:DropDownList ID="cmbHoraFin" runat="server" AutoPostBack="False" ForeColor="Black" Width="70px">
                            <asp:ListItem Value="0" Selected="True">12:00</asp:ListItem>
                            <asp:ListItem Value="1">12:30</asp:ListItem>
                            <asp:ListItem Value="2">01:00</asp:ListItem>
                            <asp:ListItem Value="3">01:30</asp:ListItem>
                            <asp:ListItem Value="4">02:00</asp:ListItem>
                            <asp:ListItem Value="5">02:30</asp:ListItem>
                            <asp:ListItem Value="6">03:00</asp:ListItem>
                            <asp:ListItem Value="7">03:30</asp:ListItem>
                            <asp:ListItem Value="8">04:00</asp:ListItem>
                            <asp:ListItem Value="9">04:30</asp:ListItem>
                            <asp:ListItem Value="10">05:00</asp:ListItem>
                            <asp:ListItem Value="11">05:30</asp:ListItem>
                            <asp:ListItem Value="12">06:00</asp:ListItem>
                            <asp:ListItem Value="13">06:30</asp:ListItem>
                            <asp:ListItem Value="14">07:00</asp:ListItem>
                            <asp:ListItem Value="15">07:30</asp:ListItem>
                            <asp:ListItem Value="16">08:00</asp:ListItem>
                            <asp:ListItem Value="17">08:30</asp:ListItem>
                            <asp:ListItem Value="18">09:00</asp:ListItem>
                            <asp:ListItem Value="19">09:30</asp:ListItem>
                            <asp:ListItem Value="20">10:00</asp:ListItem>
                            <asp:ListItem Value="21">10:30</asp:ListItem>
                            <asp:ListItem Value="22">11:00</asp:ListItem>
                            <asp:ListItem Value="23">11:30</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                        <asp:DropDownList ID="cmbHoraAP" runat="server" AutoPostBack="False" ForeColor="Black" Width="64px">
                            <asp:ListItem Value="0" Selected="True">AM</asp:ListItem>
                            <asp:ListItem Value="1">PM</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height:32px">
                    <%--Mostramos el tipo de conteo--%>
                    <td align="left" valign="top" style="width: 134px">
                        <asp:Label ID="Label4" runat="server" Font-Size="Small" Text="Tipo Conteo:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;</td>
                    <td align="left" style="width: 150px" valign="top">
                        <asp:DropDownList ID="cmbTipoProgramacion" runat="server" AutoPostBack="True" ForeColor="Black" Width="210px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="A">Activos</asp:ListItem>
                            <asp:ListItem Value="P">Productos</asp:ListItem>
                            <asp:ListItem Value="M">Mixto</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <%--Mostramos el usuario--%>
                    <td align="left" valign="top">
                        <asp:Label ID="Label9" runat="server" Font-Size="Small" Text="Usuario:" ForeColor="Teal" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" valign="top" colspan="2">
                        <asp:DropDownList ID="cmbUsuario" runat="server" AutoPostBack="False" ForeColor="Black" Width="200px" DataTextField="nombre_usuario" DataValueField="codigo_usuario">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height:32px">
                    <%--Sector--%>
                    <td align="left" valign="top" style="width: 134px">
                        <asp:Label ID="Label6" runat="server" Font-Size="Small" Text="Sectores:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                    </td>
                    <td valign="top" align="left">
                        <asp:DropDownList ID="cmbSector" runat="server" AutoPostBack="True" ForeColor="Black" Width="210px" DataTextField="colNombre" DataValueField="colCodigo" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbSector_SelectedIndexChanged" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="4" valign="top" align="left">
                        <%--Subdepósitos--%>
                        <asp:Label ID="Label7" runat="server" Font-Size="Small" Text="Subdepósitos:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:DropDownList ID="cmbSubdeposito" runat="server" AutoPostBack="True" ForeColor="Black" Width="210px" DataTextField="NOMBRE_SUBDEPOISTO" DataValueField="CODIGO_SUBDEPOSITO" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbSubdeposito_SelectedIndexChanged" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" colspan="5">
                        <%--Grilla donde mostramos los subdepósitos asociados al conteo--%>
                        <asp:GridView ID="grConteo" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="705px">
                            <Columns>
                                <asp:BoundField DataField="NOMBRE_SUCURSAL" HeaderText="Sucursal" >
                                    <ControlStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_SECTOR" HeaderText="Sector" >
                                    <ControlStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMBRE_SUBDEPOSITO" HeaderText="Subdepósito" >
                                    <ControlStyle Width="200px" />
                                </asp:BoundField>
                                <asp:CommandField SelectText="Eliminar" ShowSelectButton="True">
                                    <ControlStyle Width="100px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="teal" ForeColor="white" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </td>
                    <td align="left" valign="bottom">
                        <%--Botón para guardar--%>
                        <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" ToolTip="Generar" OnClick="ibGuardar_Click" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left" colspan="6">
                        <%--Error--%>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ibCalendario" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="cmbSector" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbSubdeposito" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ibGuardar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:content>