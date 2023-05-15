<%@ Page Title="Remito" Language="C#" MasterPageFile="~/PaginaMaestra/MasterPage.Master" AutoEventWireup="true" CodeBehind="RemitoAgencia.aspx.cs" Inherits="TransferenciasZF.RemitoAgencia" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div  style="width:940px;float:left;margin-left:7%">
        <asp:Label ID="lblDocumento" runat="server" Visible="false" Text="Label"></asp:Label>
        <asp:Label ID="lblEmpresa" runat="server" Visible="false" Text="Label"></asp:Label>
        <asp:Label ID="lblSubdeposito" runat="server" Visible="false" Text="Label"></asp:Label>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana"  
            Font-Size="8pt" Height="577px" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="854px" 
            ViewStateMode="Enabled" >
            <LocalReport ReportPath="Reportes\ReporteRemitoAgencia.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" >
            
         <%--   TypeName="TransferenciasZF.DsRemisionTableAdapters.DataTable1TableAdapter">--%>
            <SelectParameters>
                <asp:ControlParameter ControlID="lblEmpresa" Name="EMPRESA" 
                    PropertyName="Text" Type="Decimal" />
                <asp:ControlParameter ControlID="lblDocumento" Name="DOCUMENTO" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </div>
 

</asp:Content>

