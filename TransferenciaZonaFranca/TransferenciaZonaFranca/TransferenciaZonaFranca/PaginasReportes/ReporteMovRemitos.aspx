﻿<%@ Page Title="Remito" Language="C#" MasterPageFile="~/PaginaMaestra/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteMovRemitos.aspx.cs" Inherits="TransferenciasZF.ReporteMovRemitos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/ClaseDivs.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div  style="width:940px;float:left;margin-left:7%">
    <div id="Titulos" style="float:left;width:490px" >  Movimientos Intercompañias </div>
    <br />
      <br />
        <br />
         <div  style="float:left;width:300px">
           <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    <span ><label for="txtSerie">Desde</label></span>        
                    <span  class="form-el">
                       <asp:TextBox ID="txtFecha1" runat="server" ></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarFecha1" TargetControlID="txtFecha1" runat="server" Format="dd/MM/yyyy"> 
                      </asp:CalendarExtender>

                    </span>
                    <span><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Fecha Invalida. Formato dd/mm/aaaa" ControlToValidate="txtFecha1" ForeColor="Red" Operator="DataTypeCheck" Type="Date">* </asp:CompareValidator></span>        
                     <%-- <span ><label for="txtSerie">dd/mm/aaaa</label></span> --%> 
         </div>
        <div  style="float:left;width:300px">
                    <span><label for="lblDocumento">Hasta</label></span>        
                    <span  class="form-el">
                       <asp:TextBox ID="txtFecha2" runat="server"></asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFecha2" runat="server" Format="dd/MM/yyyy"> 
                        </asp:CalendarExtender>

                    </span>
                    <span><asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Fecha Invalida. Formato dd/mm/aaaa" ControlToValidate="txtFecha2" ForeColor="Red" Operator="DataTypeCheck" Type="Date">* </asp:CompareValidator></span>              
                     <%--<span ><label for="txtSerie">dd/mm/aaaa</label></span>  --%>
         </div>
      
        <asp:TextBox ID="lblEmpresa" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="lblSubdeposito" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="lblAgencia" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="lblUsuario" runat="server" Visible="false"></asp:TextBox>
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" 
            onclick="btnImprimir_Click" />

            <br />
      <br />
          <%-- <asp:Label ID="lblDocumento" runat="server" Visible="false" Text="Label"></asp:Label>
        <asp:Label ID="lblEmpresa" runat="server" Visible="false" Text="Label"></asp:Label>
        <asp:Label ID="lblSubdeposito" runat="server" Visible="false" Text="Label"></asp:Label>--%>

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana"  
            Font-Size="8pt" Height="577px" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="854px" 
            ViewStateMode="Enabled" >
            <LocalReport ReportPath="Reportes\Rpttransferencias_ZF.rdlc">
             <%--   <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>--%>
            </LocalReport>
        </rsweb:ReportViewer>
        
         <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>

    </div>
 

</asp:Content>

