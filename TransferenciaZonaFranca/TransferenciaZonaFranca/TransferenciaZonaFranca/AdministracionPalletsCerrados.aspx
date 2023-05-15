<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministracionPalletsCerrados.aspx.cs" Inherits="TransferenciasZF.AdministracionPalletsCerrados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="App_Themes/estilos/jquery.loadmask.css" rel="stylesheet" type="text/css" />
    <link href="Styles/ClaseDivs.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div id="Principal">

            <div id="Titulos" style="float:left;width:490px" >ADMINISTRACION DE PALLETS CERRADOS(Tubos Ajenos)</div>

        <br />
        <br />
        <br />
        <br />

          <div style="width:900px;float:left">
                <div class="fila" style="width:900px;float:left">
                    Código de Pallet &nbsp  &nbsp&nbsp  &nbsp
                    <input id="txtCriterioBusqueda" runat = "server" name="txtCriterioBusqueda" style="width:250px"  maxlength="20" type="text" onkeyup="this.value=this.value.toUpperCase();"/>
                 <input id="BtnBuscar"  type="button"  style="font-size:small" value="Buscar" title="Buscar"/>&nbsp;
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
            <script id="dProductos"  type="text/x-jQuery-tmpl">
                            <tr style="font-size:20px">
                    <td  style="width:50;color: #003366;font-size:11px">
                        ${Tubo}
                    </td>
                    <td  style="width:50px;color: #003366;font-size:11px">
                        ${Codigo}
                    </td>
                    <td  style="width:500px;text-align:center;color: #003366;font-size:11px">
                        ${Descripcion}
                    </td>
                    <td  style="width:50;color: #003366;font-size:11px">
                        ${Secuencia}
                    </td>
                    <td  style="width:50px;text-align:center;color: #003366;font-size:11px">
                        ${Capacidad}
                    </td>
                    <td  style="width:50px;text-align:center;color: #003366;font-size:11px">
                        ${Volumen}
                    </td>
                    <td style="width:50px;text-align:center;color: #003366;font-size:11px">
                        <a href="#" style="width:50px;text-align:center;color: #003366;font-size:11px"  onclick="Eliminar('${Secuencia}');return false;">Eliminar</a>
                     </td>
                  </tr>
            
           </script>
            
            <div id="ModalBusqueda" title="Administrar Pallets" style="display: none">

                <div style="width:450px;float:left; color: #003366; font-size: 12px;">
                <div class="fila">
                    <span class="etiqueta"><label for="txtCodigoP">Código</label></span>        
                    <span  class="form-el">
                    <input id="txtCodigoP" runat = "server" name="txtCodigoP" style="width:100px"  maxlength="7" type="text" /></span>
                </div>
                 <div class="fila">
                    <span class="etiqueta"><label for="txtCodigoFacturar">Estado</label></span> 
                     <span  class="form-el">
                     <asp:DropDownList ID="cmbTipo"  runat="server"  style="float:left" Font-Size="Small">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="D">Disponible</asp:ListItem>
                            <asp:ListItem Value="C">Cerrado</asp:ListItem>
                            <asp:ListItem Value="I">Inactivo</asp:ListItem>
                        </asp:DropDownList>
                       </span> 
                
                </div>
                <div class="fila">
                    <span  class="etiqueta"><label for="txtArticulo">Observaciones</label></span>        
                    <span  class="form-el">
                    <input id="txtArticulo" runat = "server" name="txtArticulo" style="width:250px"  type="text" /></span>
                </div>
                <div class="fila">
                    <input id="btnGuardar"  type="button"  style="font-size:small" value="Guardar" title="Guardar"/>
                    <input id="btnLiberar"  type="button"  style="font-size:small" value="Liberar" title="Liberar"/>
                </div>
              <%--  <div class="fila">
                    
                </div>--%>
               
            </div>

            </div>
            </div>
            
  
    <script src="Scripts/jquery.tmpl.js" type="text/javascript"></script>
    <script src="Scripts/jquery.alerts.js" type="text/javascript"></script>
    <script src="Scripts/jquery.numeric.js" type="text/javascript"></script>
    <script src="Scripts/jquery.dataTables.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tablePagination.0.4.js" type="text/javascript"></script>
    <script src="Scripts/jquery.mb.browser.js" type="text/javascript"></script>
    <script src="Scripts/jquery.mb.browser.min.js" type="text/javascript"></script>
    <script src="Scripts/ProductoPalletCerrado.js" type="text/javascript"></script>

</asp:Content>


