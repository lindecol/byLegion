<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReimpresionFactura.aspx.cs" Inherits="TransferenciaZonaFrancaV2.PaginasReportes.ReimpresionFactura" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Styles/ClaseDivs.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div  style="width:940px;float:left;margin-left:7%">
 <div id="Titulos" style="float:left;width:490px" >  Reimpresión Facturas Intercompañias </div>
    <br />
      <br />
        <br />
         <div  style="float:left;width:500px">
                    <span ><label for="TextBox1">Número Factura</label></span>        
                    <span  class="form-el">
                      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></span>
                      <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" 
            onclick="btnImprimir_Click" />
            <asp:Label ID="lblmsj" runat="server"></asp:Label>
         </div>
       
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="577px" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="854px" 
            ViewStateMode="Enabled">
            <LocalReport ReportPath="Reportes\ReporteFactura.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            
            TypeName="TransferenciasZF.DsFascturaTableAdapters.DataTable1TableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="COMPROBANTE" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </div>
</asp:Content>
