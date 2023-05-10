<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReporteCierreLastro.aspx.vb" Inherits="ControlPaquete.ReporteCierreLastro" MasterPageFile="~/Pages/MasterPage.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <table style="width: 60%">
        <tr>
            <td>
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                    Text="Reporte Cierre Lastro"></asp:Label>
                <hr style="width: 310px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <img src="../Images/clock.gif" />
                                Cargando información...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 120px">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                    Text="Tipo Conteo:"></asp:Label>&nbsp;</td>
            <td style="width: 190px">
                <asp:DropDownList ID="cmbTipoProgramacion" runat="server" AutoPostBack="True" ForeColor="Black"
                    OnSelectedIndexChanged="cmbTipoProgramacion_SelectedIndexChanged" Width="180px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="A">Activos</asp:ListItem>
                    <asp:ListItem Value="P">Productos</asp:ListItem>
                    <asp:ListItem Value="M">Mixto</asp:ListItem>
                    <asp:ListItem Value="T">Todos</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 120px">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                    Text="Conteos:"></asp:Label>&nbsp;
            </td>
            <td style="width: 190px">
                <asp:DropDownList ID="cmbConteo" runat="server" AppendDataBoundItems="True" AutoPostBack="false"
                    DataTextField="DESCRIPCION" DataValueField="codigo" ForeColor="Black" Width="180px">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 120px">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                    Text="Tipo Producto"></asp:Label></td>
            <td style="width: 190px">
                <asp:DropDownList ID="cmbTipoCierre" runat="server" ForeColor="Black"
                    OnSelectedIndexChanged="cmbTipoProgramacion_SelectedIndexChanged" Width="180px">
                    <asp:ListItem Value="T">Todos</asp:ListItem>
                    <asp:ListItem Value="A">Activos</asp:ListItem>
                    <asp:ListItem Value="P">Productos</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 120px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                    Text="Fecha Inicio:"></asp:Label>&nbsp;</td>
            <td style="width: 190px">
                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                <asp:Image ID="ibFechaInicio" runat="server" ImageUrl="~/Images/Calendar.gif" Width="16px" /><cc1:CalendarExtender ID ="CalendarioFechaIN"  PopupButtonID="ibFechaInicio" runat ="server" Format="dd/MM/yyyy"  TargetControlID="txtFechaInicio" FirstDayOfWeek="Friday"></cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 120px; height: 65px;">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                    Text="Fecha Fin:"></asp:Label>&nbsp;</td>
            <td style="width: 190px; height: 65px;">
                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Calendar.gif" Width="16px" /><cc1:CalendarExtender ID ="CalendarioFechaFi" PopupButtonID="Image2" runat ="server" Format="dd/MM/yyyy" TargetControlID="txtFechaFin" ></cc1:CalendarExtender>
            </td>
        </tr>
    </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="btnScript" runat="server" ImageUrl="~/Images/Guardar.GIF" OnClick="btnScript_Click"
                    Width="24px" /><br />
                <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                    Font-Bold="True" Visible="false"></asp:Label></td>
        </tr>
    </table>
    &nbsp;&nbsp;<%--Error--%>
     <rsweb:ReportViewer ID="rvReporte" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    Width="704px" Visible="False" ZoomMode="PageWidth" BackColor="LimeGreen" LinkDisabledColor="Black" Font-Bold="False" Font-Underline="False" Height="400px">
                    <LocalReport ReportPath="reportes\Report_CierreLastro.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Reporte_Estadisticas_OCPP_REPORTE_ESTADISTICAS" />
                        </DataSources>
                    </LocalReport>
                    <ServerReport DisplayName="Estadistica" ReportPath="~/Pages/" />
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
                    TypeName="Reporte_EstadisticasTableAdapters.OCPP_REPORTE_ESTADISTICASTableAdapter">
                </asp:ObjectDataSource>
    
               
            
</asp:content>