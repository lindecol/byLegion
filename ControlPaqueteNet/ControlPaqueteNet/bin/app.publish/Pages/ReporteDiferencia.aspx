﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteDiferencia.aspx.cs" Inherits="ControlPaqueteNet.Pages.ReporteDiferencia" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">

    </asp:ScriptManager>
        <%--<asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>--%>
                <center>
                <table style="width:320px">
                    <tr>
                        <td valign="top" align="center" colspan="2">
                            <%--Mostramos el título de la página--%>
                            <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                                Text="Reporte Diferencia"></asp:Label>
                            <br />
                            <hr style="width:310px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                            <asp:Label ID="Label4" runat="server" Font-Size="Small" Text="Tipo Conteo:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;</td>
                        <td style="width: 190px;">
                            <asp:DropDownList ID="cmbTipoProgramacion" runat="server" AutoPostBack="True" ForeColor="Black" Width="180px" OnSelectedIndexChanged="cmbTipoProgramacion_SelectedIndexChanged">
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
                            <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Conteos:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        </td>
                        <td style="width: 190px">
                            <asp:DropDownList ID="cmbConteo" runat="server" AutoPostBack="false" ForeColor="Black" Width="180px" DataTextField="DESCRIPCION" DataValueField="codigo" AppendDataBoundItems="True" >
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                            <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Fecha Inicio:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;</td>
                        <td style="width: 190px;">
                            <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                            <asp:Image ID="ibFechaInicio" runat="server" ImageUrl="~/Images/Calendar.gif"
                                Width="16px" />
                            <ajaxToolkit:CalendarExtender ID ="CalendarioFechaIN"  PopupButtonID="ibFechaInicio" runat ="server" Format="dd/MM/yyyy"  TargetControlID="txtFechaInicio" FirstDayOfWeek="Friday"></ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                            <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Fecha Fin:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;</td>
                        <td style="width: 190px">
                            <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Calendar.gif"
                                Width="16px" />
                            <ajaxToolkit:CalendarExtender ID ="CalendarioFechaFi" PopupButtonID="Image2" runat ="server" Format="dd/MM/yyyy" TargetControlID="txtFechaFin" ></ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 310px" colspan="2">
                            <br />
                            <%--Botón para guardar--%>
                            <asp:ImageButton ID="btnScript" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" OnClick="btnScript_Click" />
                        </td>
                    </tr>
                </table>
                <%--Error--%>
                <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                    Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                <p></p>
                <rsweb:ReportViewer ID="rvReporte" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    Width="704px" Visible="False" ZoomMode="PageWidth" BackColor="LimeGreen" LinkDisabledColor="Black" Font-Bold="False" Font-Underline="False" Height="400px">
                    <LocalReport ReportPath="reportes\Report_Conteo.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Reporte_Estadisticas_OCPP_REPORTE_ESTADISTICAS" />
                        </DataSources>
                    </LocalReport>
                    <ServerReport DisplayName="Estadistica" ReportPath="~/Pages/" />
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
                    TypeName="Reporte_EstadisticasTableAdapters.OCPP_REPORTE_ESTADISTICASTableAdapter">
                </asp:ObjectDataSource>
                <br />
                <br />
                </center>
            <%--</ContentTemplate>
            <Triggers>
                
                <asp:AsyncPostBackTrigger ControlID="cmbTipoProgramacion" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>--%>
  
</asp:content>