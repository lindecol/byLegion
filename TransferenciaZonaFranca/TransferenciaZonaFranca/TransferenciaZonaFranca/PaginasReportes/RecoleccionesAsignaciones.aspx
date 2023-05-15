<%@ Page Title="Remito" Language="C#" MasterPageFile="~/PaginaMaestra/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecoleccionesAsignaciones.aspx.cs" Inherits="TransferenciasZF.RecoleccionesAsignaciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

   
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/ClaseDivs.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div  style="width:940px;float:left;margin-left:7%">
    <div id="Titulos" style="float:left;width:490px" >  CONSOLIDADO ASIGNACIONES-RECOLECCIONES</div>
    <br />
      
        <div style="width:480px;float:left">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                <div class="fila">
                    <span class="etiqueta"><label for="txtFecha1">Desde_</label></span>        
                    <span  class="form-el">
                        <asp:TextBox ID="txtFecha1" runat="server" ></asp:TextBox>
                        
                    <asp:CalendarExtender ID="CalendarFecha1" TargetControlID="txtFecha1" runat="server" Format="dd/MM/yyyy"> 
                    </asp:CalendarExtender>
                    </span>
                          <span><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Fecha Invalida. Formato dd/mm/aaaa" ControlToValidate="txtFecha1" ForeColor="Red" Operator="DataTypeCheck" Type="Date">* </asp:CompareValidator></span>        
                 </div>
            
               <div class="fila">
                    <span class="etiqueta"><label for="txtFecha2">Hasta</label></span>        
                    <span  class="form-el">
                        <asp:TextBox ID="txtFecha2" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFecha2" runat="server" Format="dd/MM/yyyy"> 
                        </asp:CalendarExtender>

                    </span>
                          <span><asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Fecha Invalida. Formato dd/mm/aaaa" ControlToValidate="txtFecha2" ForeColor="Red" Operator="DataTypeCheck" Type="Date">* </asp:CompareValidator></span>              
                 </div>
               

               <div id="Pro" runat="server" visible="false">
                   <img alt=""   src="../Proceso.gif" />
                 </div>

                 <asp:UpdateProgress ID="UpdateProgress1" runat="server">
<ProgressTemplate>
<div id="Background"></div>
<div id="Progress">
<img src="../Proceso.gif" style="vertical-align:middle" alt=""/>
Fetching Records Please Wait...
</div>
</ProgressTemplate>
</asp:UpdateProgress>


                <div class="fila">
                   <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" onclick="btnImprimir_Click" />
                </div>
            </div>

             
        <asp:TextBox ID="lblEmpresa" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="lblSubdeposito" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="lblAgencia" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="lblUsuario" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtestado" runat="server" Visible="false"></asp:TextBox>
      
            
      

            <br />
      <br />
          <%-- <asp:Label ID="lblDocumento" runat="server" Visible="false" Text="Label"></asp:Label>
        <asp:Label ID="lblEmpresa" runat="server" Visible="false" Text="Label"></asp:Label>
        <asp:Label ID="lblSubdeposito" runat="server" Visible="false" Text="Label"></asp:Label>--%>

      

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetData" 
            TypeName="TransferenciasZF.DsRecoleccionesAsigTableAdapters.TEMP_REPORTE_MOV_HCTableAdapter">
            <InsertParameters>
                <asp:Parameter Name="TIPOMOV" Type="String" />
                <asp:Parameter Name="CODPRO" Type="String" />
                <asp:Parameter Name="DESCPRO" Type="String" />
                <asp:Parameter Name="FECHA" Type="String" />
                <asp:Parameter Name="HORA" Type="String" />
                <asp:Parameter Name="NUMDOC" Type="String" />
                <asp:Parameter Name="CAP" Type="Decimal" />
                <asp:Parameter Name="CAN" Type="Decimal" />
                <asp:Parameter Name="TIPOPROD" Type="String" />
                <asp:Parameter Name="SERIAL" Type="String" />
                <asp:Parameter Name="CLIENTE" Type="String" />
                <asp:Parameter Name="CODCLI" Type="String" />
                <asp:Parameter Name="SUCURSAL" Type="String" />
                <asp:Parameter Name="RUTA" Type="String" />
                <asp:Parameter Name="FACTURA" Type="String" />
                <asp:Parameter Name="FECHFACTURA" Type="String" />
                <asp:Parameter Name="ENTIDAD" Type="String" />
                <asp:Parameter Name="USUARIO" Type="String" />
                <asp:Parameter Name="ESTADO" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>

      

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana"  
            Font-Size="8pt" Height="577px" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="854px" 
            ViewStateMode="Enabled" >
            <LocalReport ReportPath="Reportes\rtpAsig_Recol.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        
 
    </div>
 

</asp:Content>



   

