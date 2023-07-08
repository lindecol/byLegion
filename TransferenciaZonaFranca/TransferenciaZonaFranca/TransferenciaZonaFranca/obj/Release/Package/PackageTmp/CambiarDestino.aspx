<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/MasterPage.Master" AutoEventWireup="true" CodeBehind="CambiarDestino.aspx.cs" Inherits="TransferenciaZonaFranca.CambiarDestino" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="App_Themes/estilos/jquery.loadmask.css" rel="stylesheet" type="text/css" />
    <link href="Styles/ClaseDivs.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div id="Principal">

            <div id="Titulos" style="float:left;width:490px" >Modificar Destino Envios Intercompañia</div>

        <br />
        <br />
        <br />
        <br />

          <div style="width:900px;float:left">
                <div class="fila" style="width:900px;float:left">
                    Remito &nbsp  &nbsp&nbsp  &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp
                    <input id="txtRemito" runat = "server" name="txtRemito" style="width:150px"  maxlength="20" type="text" onkeyup="this.value=this.value.toUpperCase();"/>
                            <asp:Label ID="lblEmpresa_"  runat="server" Enabled="false" ForeColor="White"></asp:Label> 
                            <asp:Label ID="lblSucursal"  runat="server" Enabled="false" ForeColor="White"></asp:Label> 
                         <asp:Label ID="lblDes" Text="Destino Actual:" runat="server" Enabled="false" ></asp:Label>         
                         <asp:Label ID="lblDestino"  runat="server" Enabled="false" ></asp:Label> &nbsp &nbsp &nbsp &nbsp &nbsp
                          <asp:Label ID="lblfec" Text="Fecha:" runat="server" Enabled="false" ></asp:Label> 
                           <asp:Label ID="lbbFecha"  runat="server" Enabled="false" ></asp:Label>  &nbsp &nbsp &nbsp &nbsp &nbsp
                           <asp:Label ID="lblen" Text="Entregado:" runat="server" Enabled="false" ></asp:Label>
                           <asp:Label ID="lblEntregado"  runat="server" Enabled="false" ></asp:Label> 
                            <asp:Label ID="lblBd" runat="server" Enabled="false" ForeColor="White"></asp:Label>
                           

                </div>
                <div class="fila" style="width:900px;float:left">
                    Cambiar Por: &nbsp  &nbsp&nbsp  &nbsp
                  <asp:DropDownList ID="CmbSucursalDestino" Width="250px" runat="server"></asp:DropDownList>
                
                 <input id="btnModificar"  type="button"  style="font-size:small" value="Modificar" title="Eliminar Sesion"/>
                 
                </div>
            </div>
        <br />
        <br />
        <br />
        <br />
        <div id="divDatos" 
                style="width:100%;float:left; font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #003366;" 
                align="left">
            <table id="TProductos" class="tablas" align="left"><tbody></tbody></table>
        </div>
            
            
     
            </div>
            
  
    <script src="Scripts/jquery.tmpl.js" type="text/javascript"></script>
    <script src="Scripts/jquery.alerts.js" type="text/javascript"></script>
    <script src="Scripts/jquery.numeric.js" type="text/javascript"></script>
    <script src="Scripts/jquery.dataTables.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tablePagination.0.4.js" type="text/javascript"></script>
    <script src="Scripts/jquery.mb.browser.js" type="text/javascript"></script>
    <script src="Scripts/jquery.mb.browser.min.js" type="text/javascript"></script>
    <script src="Scripts/CambiarDestino.js" type="text/javascript"></script>

</asp:Content>


