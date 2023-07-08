<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConfiguracionPP.aspx.cs" Inherits="TransferenciaZonaFrancaV2.ConfiguracionPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="App_Themes/estilos/jquery.loadmask.css" rel="stylesheet" type="text/css" />
    <link href="Styles/ClaseDivs.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div id="Principal">

            <div id="Titulos" style="float:left;width:490px" >CONFIGURACION ARTICULOS PARA ZONA FRANCA </div>

        <br />
        <br />
        <br />
        <br />

          <div style="width:900px;float:left">
                <div class="fila" style="width:900px;float:left">
                    <span><label for="cmbEmpresaOrigen" style="float:left">Buscar Por   &nbsp  &nbsp</label></span>        
                      <asp:DropDownList ID="cmbBuscarPor"  runat="server"  style="float:left" Font-Size="Small">
                            <asp:ListItem Value="1">Nombre</asp:ListItem>
                            <asp:ListItem Value="2">Código</asp:ListItem>
                        </asp:DropDownList>&nbsp  &nbsp&nbsp  &nbsp
                    <input id="txtCriterioBusqueda" runat = "server" name="txtCriterioBusqueda" style="width:250px"  maxlength="20" type="text" onkeyup="this.value=this.value.toUpperCase();"/>
                 <input id="BtnBuscar"  type="button"  style="font-size:small" value="Buscar" title="Buscar"/>
                 <input id="BtnNuevo"  type="button"  style="font-size:small" value="Nuevo" title="Nuevo"/>
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
                    <td  style="width:70px;text-align:center;color: #003366;font-size:11px">
                        ${Codigo}
                    </td>
                    <td  style="width:250;color: #003366;font-size:11px">
                        ${Descripcion}
                    </td>
                    <td  style="width:50px;text-align:center;color: #003366;font-size:11px">
                        ${PesoPromedio}
                    </td>
                    <td  style="width:50px;text-align:center;color: #003366;font-size:11px">
                        ${CodigoFacturacion}
                    </td>
                     <td  style="width:250;color: #003366;font-size:11px">
                        ${DesCodigoFacturacion}
                    </td>
                     <td  style="width:50px;text-align:center;color: #003366;font-size:11px">
                        ${Tipo}
                    </td>
                    <td style="width:50px;text-align:center;color: #003366;font-size:11px">
                        <a href="#" style="width:50px;text-align:center;color: #003366;font-size:11px"  onclick="Editar('${Codigo}','${Descripcion}','${PesoPromedio}','${CodigoFacturacion}','${Tipo}');return false;">Editar</a>
                     </td>
                     <td style="width:50px;text-align:center;color: #003366;font-size:11px">
                        <a href="#" style="width:50px;text-align:center;color: #003366;font-size:11px"  onclick="Eliminar('${Codigo}');return false;">Eliminar</a>
                     </td>
                  </tr>
            
           </script>
            
            <div id="ModalBusqueda" title="Administrar Propia Producción" style="display: none">

                <div style="width:450px;float:left; color: #003366; font-size: 12px;">
                <div class="fila">
                    <span class="etiqueta"><label for="txtCodigoP">Código</label></span>        
                    <span  class="form-el">
                    <input id="txtCodigoP" runat = "server" name="txtCodigoP" style="width:100px"  maxlength="10" type="text" /></span>
                </div>
                <div class="fila">
                    <span  class="etiqueta"><label for="txtArticulo">Articulo</label></span>        
                    <span  class="form-el">
                    <input id="txtArticulo" runat = "server" name="txtArticulo" style="width:250px"  type="text" /></span>
                </div>
                <div class="fila">
                    <span class="etiqueta"><label for="txtPeso">Peso Promedio</label></span>        
                    <span  class="form-el">
                    <input id="txtPeso" runat = "server" name="txtPeso" style="width:100px"  maxlength="20" type="text" /></span>
                </div>
                  <div class="fila">
                    <span class="etiqueta"><label for="txtCodigoFacturar">Código Facturación</label></span>        
                    <span  class="form-el">
                    <input id="txtCodigoFacturar" runat = "server" name="txtCodigoFacturar" style="width:100px"  maxlength="20" type="text" /></span>
                </div>
                <div class="fila">
                    <span class="etiqueta"><label for="txtCodigoFacturar">Tipo</label></span> 
                     <span  class="form-el">
                     <asp:DropDownList ID="cmbTipo"  runat="server"  style="float:left" Font-Size="Small">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="1">Propia Producción</asp:ListItem>
                            <asp:ListItem Value="2">Servicios Logisticos</asp:ListItem>
                        </asp:DropDownList>
                       </span> 
                
                </div>
                <div class="fila">
                    <input id="btnGuardar"  type="button"  style="font-size:small" value="Guardar" title="Guardar"/>
                </div>
               
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
    <script src="Scripts/ConfiguracionPP.js" type="text/javascript"></script>

</asp:Content>


