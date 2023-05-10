<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReporteSubdeposito.aspx.vb" Inherits="ControlPaquete.ReporteSubdeposito" MasterPageFile="~/Pages/MasterPage.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
        <%--<asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>--%>
                <center>
                    <table style="width:470px">
                        <tr>
                            <td valign="top" align="center" colspan="2">
                                <%--Mostramos el título de la página--%>
                                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                                    Text="Reporte Subdepósitos"></asp:Label>
                                <br />
                                <hr style="width:460px" />
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 170px">
                                <asp:Label ID="Label4" runat="server" Font-Size="Small" Text="Subdepósito Desde:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;</td>
                            <td style="width: 290px;">
                                <asp:DropDownList ID="sub_desde" runat="server" AutoPostBack="True" ForeColor="Black" Width="280px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 170px">
                                <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Subdepósito Hasta:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                            </td>
                            <td style="width: 290px">
                                <asp:DropDownList ID="sub_hasta" runat="server" AutoPostBack="false" ForeColor="Black" Width="280px" DataTextField="codigo" DataValueField="codigo" AppendDataBoundItems="True" >
                                </asp:DropDownList>
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
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" OnDrillthrough="ReportViewer1_Drillthrough"
                        Width="704px" Visible="False" ZoomMode="PageWidth" BackColor="LimeGreen" LinkDisabledColor="Black" Font-Bold="False" Font-Underline="False" Height="400px">
                        <LocalReport ReportPath="reportes\maestro_subdeposito.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="principal_maestro_subdeposito" />
                            </DataSources>
                        </LocalReport>
                        <ServerReport DisplayName="Estadistica" ReportPath="~/Pages/" />
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
                        TypeName="principalTableAdapters.maestro_subdepositoTableAdapter">
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