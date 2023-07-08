<%@ Page Title="Remito" Language="C#" MasterPageFile="~/PaginaMaestra/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportesPedidos.aspx.cs" Inherits="TransferenciaZonaFranca.PaginasReportes.ReportesPedidos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/ClaseDivs.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div  style="width:940px;float:left;margin-left:7%">
    <div id="Titulos" style="float:left;width:490px" >  PEDIDOS INTERCOMPAÑIAS</div>
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
                <div class="fila">
                 
                    <span class="etiqueta"><label for="cmbSucursal">Sucursal</label></span>        
                    <span  class="form-el">
                        <asp:TextBox ID="txtSucursal" runat="server"></asp:TextBox></span>
                    <asp:CheckBox ID="chkTodos" runat="server" Text="Todos" />
                 
                </div>
                <div class="fila">
                    <span  class="etiqueta"><label for="cmbEstado">Estado</label></span>        
                    <span  class="form-el"><asp:DropDownList ID="cmbEstado"  runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Value="P">&lt;Pendientes&gt;</asp:ListItem>
                    <asp:ListItem Value="E">&lt;Entregados&gt;</asp:ListItem>
                    </asp:DropDownList></span>
                </div>

                <div class="fila">
                    <span  class="etiqueta"><label for="cmbBuscarPor">Buscar Por</label></span>        
                    <span  class="form-el"><asp:DropDownList ID="cmbBuscarPor"  runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Value="G">&lt;Fecha Generado&gt;</asp:ListItem>
                    <asp:ListItem Value="E">&lt;Fecha Entregra&gt;</asp:ListItem>
                    </asp:DropDownList></span>
                         <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" 
            onclick="btnImprimir_Click" />
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
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            
            TypeName="TransferenciasZF.DsPedidosTableAdapters.PedPorFechaGen_SucTableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtFecha1" Name="FECHA1" PropertyName="Text" 
                    Type="DateTime" />
                <asp:ControlParameter ControlID="txtFecha2" Name="FECHA2" PropertyName="Text" 
                    Type="DateTime" />
                <asp:ControlParameter ControlID="cmbEstado" Name="ESTADO" PropertyName="SelectedValue" 
                    Type="String" />
                <asp:ControlParameter ControlID="txtSucursal" Name="SUCURSAL" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana"  
            Font-Size="8pt" Height="577px" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="854px" 
            ViewStateMode="Enabled" >
            <LocalReport ReportPath="Reportes\ReportePedidos.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>--%>
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager>
         <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    </div>
 

</asp:Content>

