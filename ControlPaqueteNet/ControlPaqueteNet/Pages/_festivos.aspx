<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="festivos.aspx.vb" Inherits="ControlPaquete.festivos" MasterPageFile="~/Pages/MasterPage.Master" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <table style="width:800px">
        <tr>
            <td valign="top" align="center">
                <%--Mostramos el título de la página--%>
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="teal"
                    Text="Días Festivos"></asp:Label>
                <br />
                <hr style="width:100%" />
            </td>
        </tr>
        <tr>
            <td valign="top" align="center">
                <br />
                <%--Colocamos el UpdatePanel para nuestros asuntos en AJAX--%>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                    <%--Sucursales--%>
                    <asp:Label ID="Label4" runat="server" Font-Size="Small" Text="Sucursal:" ForeColor="Teal" Font-Bold="True"></asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="cmbSucursal" runat="server" AutoPostBack="True" ForeColor="Black" DataTextField="nombre_sucursal" DataValueField="codigo_sucursal" Width="200px" OnSelectedIndexChanged="cmbSucursal_SelectedIndexChanged" AppendDataBoundItems="True" >
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <p>
                    </p>
                    <%--Check para sabados y domingos--%>
                    <asp:CheckBox ID="chkSabado" runat="server" Text="Todos los sabados" Font-Bold="True" Font-Size="Small" ForeColor="Teal" />
                    &nbsp;
                    <asp:CheckBox ID="chkDomingo" runat="server" Text="Todos los domingos" Font-Bold="True" Font-Size="Small" ForeColor="Teal" />
                    <p>
                    </p>
                    <%--Calendario--%>
                    <asp:Calendar ID="MiCalendario" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                        <SelectedDayStyle BackColor="Red" ForeColor="White" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                            Font-Size="12pt" ForeColor="Teal" />
                    </asp:Calendar>
                    <p></p>
                    <%--Botón para guardar--%>
                    <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" />
                    <p>
                    </p>
                    <%--Error--%>
                    <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                        Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmbSucursal" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

</asp:content>