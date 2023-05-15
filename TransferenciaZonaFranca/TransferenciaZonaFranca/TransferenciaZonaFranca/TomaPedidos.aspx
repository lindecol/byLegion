<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/MasterPage.Master" AutoEventWireup="true" CodeBehind="TomaPedidos.aspx.cs" Inherits="TransferenciasZF.TomaPedidos" %>

   
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/estilos/jquery.loadmask.css" rel="stylesheet" type="text/css" />
    <link href="Styles/ClaseDivs.css" rel="stylesheet" type="text/css" />

   <%-- ejemplo grilla--%>
   
   
    <script src="ScriptsJqgrid/jquery.jqGrid.min.js" type="text/javascript"></script>

    <link href="ScriptsJqgrid/ui.jqgrid.css" rel="stylesheet" type="text/css" />

     <script src="ScriptsJqgrid/grid.locale-es.js" type="text/javascript"></script>

   <%--  <script language="JavaScript" type="text/javascript">

         var bPreguntar = true;

         window.onbeforeunload = preguntarAntesDeSalir;

         function preguntarAntesDeSalir() {
             if (bPreguntar)
                 return "¿Seguro que quieres salir?";
         }
      </script>--%>

   <%--fin ejemplo grilla--%>


    <script language="javascript" type="text/javascript">
// <![CDATA[

        function btnNuevo_onclick() {

        }

        function Button1_onclick() {

        }

// ]]>
    </script>
</asp:Content>

 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

       <div id="Principal"  >
          
       <div id="msg" ></div>
       <div>
        
            <div id="Titulos" style="float:left;width:490px" >  Toma de Pedidos </div>

      
            <div id="DivUser"  style="float:left">

              <div class="fila" style="width:150px">
                    <asp:Label ID="Label2" runat="server" Enabled="false" Text="Usuario : " 
                        style="font-weight: 700" ></asp:Label> 
                    <asp:Label ID="lblNombreUsuario" runat="server" Enabled="false" 
                        style="font-weight: 700"></asp:Label> 
                </div>

            </div>

            <div id="DivSubdeposito"  style="float:left">

              <div class="fila" style="width:200px">
                    <asp:Label ID="Label3" runat="server" Enabled="false" Text="Subdeposito : " 
                        style="font-weight: 700" ></asp:Label> 
                    <asp:Label ID="lblSubdeposito" runat="server" Enabled="false" 
                        style="font-weight: 700"></asp:Label> 
                        <asp:Label ID="lblVersion" runat="server" Enabled="false" 
                        style="font-weight: 500" Text="Version 2.0"></asp:Label> 
                </div>

            </div>

             <div id="Divbd" style="float:left" >
                      <div class="fila"  style="float:left;width:130px" >
                            <asp:Label ID="lblBd" runat="server" Enabled="false" ForeColor="White"
                                style="font-weight: 700" ></asp:Label> 
                            
                        
                        </div>
                    </div>

             <div id="DivEmpresa" style="float:left" >
                      <div class="fila"  style="float:left;width:130px" >
                            <asp:Label ID="Label6" runat="server" Enabled="false" Text="Empresa : " 
                                style="font-weight: 700" ></asp:Label> 
                            <asp:Label ID="lblIdEmpresa" runat="server" Enabled="false" 
                                style="font-weight: 700"></asp:Label> 
                        
                        </div>
               </div>

                  <div id="DivAgencia" style="float:left" >
                      <div class="fila"  style="float:left;width:130px" >
                            <asp:Label ID="Label7" runat="server" Enabled="false" Text="Agencia : " 
                                style="font-weight: 700" ></asp:Label> 
                           <asp:Label ID="lblAgencia1" runat="server" Enabled="false" 
                        style="font-weight: 700"></asp:Label> 
                        </div>
                    </div>
                        

                    

        </div>
       
          <br />
        <br />

        <br />
        <br />
        <div style="width:490px;float:left">
                <div class="fila">
                    <span class="etiqueta"><label for="cmbEmpresaOrigen">Empresa  (*)</label></span>        
                    <span  class="form-el">
                    <input id="cmbEmpresaOrigen" runat = "server" name="cmbEmpresaOrigen" style="width:250px" disabled="disabled" readonly="readonly" maxlength="20" type="text" /></span>
                  <%--  <asp:DropDownList ID="cmbEmpresaOrigen" Width="250px" runat="server" Enabled="false" ></asp:DropDownList></span>--%>
                </div>
                <div class="fila">
                    <span  class="etiqueta"><label for="CmbSucursalOrigen">Sucursal  (*)</label></span>        
                    <span  class="form-el">
                    <input id="txtSucursalOrigen" runat = "server" name="txtSucursalOrigen" style="width:250px" disabled="disabled" readonly="readonly" maxlength="20" type="text" /></span>
                    <%--<asp:DropDownList ID="CmbSucursalOrigen"  Width="250px" runat="server"></asp:DropDownList></span>--%>
                </div>
                <div class="fila">
                    <span class="etiqueta"><label for="cmbEmpresaDestino">Empresa Solicitar (*)</label></span>        
                    <span  class="form-el"><asp:DropDownList ID="cmbEmpresaDestino" Width="250px" runat="server"></asp:DropDownList></span>
                </div>
                <div class="fila">
                    <span  class="etiqueta"><label for="CmbSucursalDestino">Sucursal Solicitar (*)</label></span>        
                    <span  class="form-el"><asp:DropDownList ID="CmbSucursalDestino" Width="250px" runat="server"></asp:DropDownList></span>
                </div>

               
            </div>

        <div style="width:490px;float:left">
                

                 <div class="fila">
                    <span class="etiqueta"><label for="txtNumeroDocumento">Nro Pedido (*)</label></span>        
                    <span class="form-el"><input id="txtNumeroDocumento" runat = "server" name="txtNumeroDocumento" readonly="readonly" disabled="disabled" style="text-align:right" maxlength="20" type="text" /></span>
                </div>

                <div class="fila">
                    <span class="etiqueta"><label for="txtFecha">Fecha (*)</label></span>        
                    <span class="form-el"><input id="txtFecha"   style="width:50%;" runat="server" name="txtFecha" disabled="disabled"  maxlength="30" type="text" /></span>
                </div>
                


               

                  <div class="fila">
                    <span class="etiqueta"><label for="txtFechaEntrega">Fecha Entrega (*)</label></span>        
                    <span class="form-el"><input id="txtFechaEntrega"   style="width:50%;" runat="server" name="txtFecha"  maxlength="30" type="text" /></span>
                </div>
                 
                <div class="fila">
                  
                </div>

                <div class="fila">
                    
                </div>

            </div>

        <br />
        <br />
        <br />
        <div id="SUbTitulos"> Productos a Solicitar
        </div>

       
      <div id="tabs" style="width:940px;float:left">
          <ul>
            <li><a href="#tabs-1">Productos Praxair</a></li>
            <li><a href="#tabs-2">Productos Particulares</a></li>
          </ul>
        <div id="tabs-1">
      <div style="width:900px;float:left">
       
            <asp:Panel ID="Panel1" runat="server" Width="900px" Height="38px" BackColor="#F3F3F3">

                <div>
                    <div style="width:70px;float:left;text-align:center" >
                        <span><label  style="font-weight:bold;font-size:11px"   for="txtCodigo">Código</label></span>        
                        <span><input id="txtCodigo" runat = "server" name="txtCodigo" maxlength="10" type="text"  style="width:70px;font-size:11px"/></span>
                    </div>

                    <div style="width:550px;float:left;text-align:center" >
                        <span><label  style="font-weight:bold;font-size:11px" for="txtDescripcion">Descripición</label></span>        
                        <span><input id="txtDescripcion" runat = "server" name="txtDescripcion" maxlength="10" type="text"  style="width:550px;font-size:11px"/></span>
                    </div>

                    <div style="width:50px;float:left;text-align:center" >
                        <span><label  style="font-weight:bold;font-size:11px;text-align:center" for="txtCantidad">Cant</label></span>        
                        <span style="font:8px"><input id="txtCantidad" runat = "server" name="txtCantidad" maxlength="10" type="text"  style="width:50px;text-align:center;font-size:11px"/></span>
                    </div>

                    <div style="width:60px;float:left;text-align:center" >
                        <span><label  style="font-weight:bold;font-size:11px" for="txtCapacidad">Capacidad</label></span>        
                        <span><input id="txtCapacidad" runat = "server" name="txtCapacidad" maxlength="10" type="text"   style="width:60px;text-align:center;font-size:11px"/></span>
                    </div>

                    <div style="width:70px;float:left;text-align:center" >
                        <span><label  style="font-weight:bold;font-size:11px" for="txtPropiedad">Volumen</label></span>        
                        <span><input id="txtVolumen" runat = "server" name="txtVolumen" maxlength="10" type="text"  style="width:70px;text-align:center;font-size:11px"/></span>
                    </div>
                    
                      <div style="width:50px;float:left;text-align:center" >
                        <span><label style="font-weight:bold;font-size:11px"  for="txtObservacion">Cargue</label></span>        
                        <span><input id="txtObservacion" runat = "server" name="txtObservacion" maxlength="50" type="text"  style="width:50px;font-size:11px"/></span>
                    </div>
                     &nbsp
                     <div style="width:34px; float:left;text-align:center; height: 32px;" >
                        <span>        
                            
                            <input id="btnAgregarProducto" style="background-image:url('App_Themes/Imagenes/Download.png');background-repeat: no-repeat; width: 31px; width: 30px; height: 25px; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: 0px;margin-top:7px" type="button" title="Agregar Grilla"/>
                         </span>
                    </div>
                    

                    <input id="hdEsProductoStockeable"  type="hidden" />
                    <input id="hdEsProductoCuentaCorriente" type="hidden" />
                    <input id="hdZonaControlProducto" type="hidden" />
                    <input id="hdIdArticulo" type="hidden" />
                    <input id="hdSubdepositoSucursal" type="hidden" runat="server"  />
                    <input id="hdIdEmpresa" type="hidden" runat="server"  />
                    <input id="hdIdSucursal" type="hidden" runat="server"  />
                    <input id="hdGenerarCons" type="hidden" runat="server"  />
                     <input id="hdSubdepositoDestino" type="hidden" runat="server"  />
                      <input id="hdUsuario" type="hidden" runat="server"  />
                    
                </div>

                

                 </asp:Panel> 
                 
                 <br />
                <br />
                  <div>
            <table id="TProductos" class="Tabla" style="width: 100%">
                <thead>
                   <%-- <tr>
                       
                        <th>
                            Código
                        </th>
                        <th>
                            No Tubo
                        </th>
                        <th>
                            Descripción
                        </th>
                        <th>
                            Capacidad
                        </th>
                        <th>
                            Cantidad
                        </th>
                        <th>
                            Propiedad
                        </th>
                        <th>
                            Observación
                        </th>
                    </tr>--%>
                </thead>
            </table>
            <script id="dProductos"  type="text/x-jQuery-tmpl">
            <tbody>
                <tr style="font-size:11px">
                    <td  style="width:70px;text-align:center;">
                        ${Codigo}
                    </td>
                    <td  style="width:540px">
                        ${Descripcion}
                    </td>
                    <td  style="width:50px;text-align:center">
                        ${Cantidad}
                    </td>
                    <td  style="width:50px;text-align:center">
                        ${Capacidad}
                    </td>
                    <td  style="width:90px;text-align:center">
                        ${Volumen}
                    </td>
                    <td  style="width:30px">
                        ${Observacion}
                     </td>
                     <td>
                        <a href="#" onclick="Eliminar('${Codigo}','${Volumen}','1',${Capacidad});return false;">Eliminar</a>
                     </td>
                  </tr>
             </tbody>
           </script>
           
      </div>

      
      
      </div>
  </div>
        <div id="tabs-2">
    <div style="width:900px;float:left">
         
            <asp:Panel ID="Panel2" runat="server" Width="900px" Height="38px" BackColor="#F3F3F3">

                <div>
                    <div style="width:140px;float:left;text-align:center" >
                        <span><label  style="font-weight:bold;font-size:11px"   for="txtSerial">Secuencia</label></span>        
                        <span><input id="txtSecuencia" runat = "server" name="txtSecuencia" maxlength="20" type="text"  style="width:140px;font-size:11px"/></span>
                    </div>

                    <div style="width:70px;float:left;text-align:center" >
                        <span><label  style="font-weight:bold;font-size:11px" for="txtCodigoTubo">No Tubo</label></span>        
                        <span><input id="txtCodigoTubo" runat = "server" name="txtCodigoTubo" maxlength="13" type="text" readonly="readonly" style="width:70px;font-size:11px"/></span>
                    </div>

                    <div style="width:220px;float:left;text-align:center; height: 35px;" >
                        <span><label  style="font-weight:bold;font-size:11px" for="txtCliente">Cliente</label></span>        
                        <span><input id="txtCliente" runat = "server" name="txtCliente" maxlength="50" type="text"  readonly="readonly" style="width:220px;font-size:11px"/></span>
                    </div>
                    <div style="width:70px;float:left;text-align:center" >
                        <span><label  style="font-weight:bold;font-size:11px"   for="txtCodigo1">Código</label></span>        
                        <span><input id="txtCodigo1" runat = "server" name="txtCodigo1" maxlength="10" type="text"  style="width:70px;font-size:11px"/></span>
                    </div>

                    <div style="width:220px;float:left;text-align:center" >
                        <span><label  style="font-weight:bold;font-size:11px" for="txtDescripcion1">Descripción</label></span>        
                        <span style="font:8px"><input id="txtDescripcion1" runat = "server" name="txtDescripcion1" maxlength="50" type="text"  style="width:220px;font-size:11px"/></span>
                    </div>

                    <div style="width:40px;float:left;text-align:center" >
                        <span><label  style="font-weight:bold;font-size:11px;text-align:center" for="txtCapacidad1">Cap</label></span>        
                        <span><input id="txtCapacidad1" runat = "server" name="txtCapacidad1" maxlength="10" type="text"   style="width:40px;text-align:center;font-size:11px"/></span>
                    </div>

                    <div style="width:40px;float:left;text-align:center" >
                        <span><label  style="font-weight:bold;font-size:11px;text-align:center" for="txtVolumen1">Vol</label></span>        
                        <span><input id="txtVolumen1" runat = "server" name="txtVolumen1" maxlength="10" type="text"  style="width:40px;text-align:center;font-size:11px"/></span>
                    </div>
                    
                      <div style="width:50px;float:left;text-align:center" >
                        <span><label style="font-weight:bold;font-size:11px"  for="txtObservacion1">Cargue</label></span>        
                        <span><input id="txtObservacion1" runat = "server" name="txtObservacion1" maxlength="50" type="text"  style="width:50px;font-size:11px"/></span>
                    </div>

                     <div style="width:20px;float:left;text-align:center" >
                         <input id="btnAgregarProducto1" style="background-image:url('App_Themes/Imagenes/Download.png');background-repeat: no-repeat; width: 31px; width: 30px; height: 25px; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: 0px;margin-top:7px" type="button" title="Agregar Grilla"/>
                    </div>

                    <input id="hdnIdClienteTubo" type="hidden" />
                                        
                </div>

                

                 </asp:Panel> 
                 
                 <br />
                <br />
                  <div>
            <table id="TproductosParticulares" class="Tabla" style="width: 100%">
                <thead>
                   <%-- <tr>
                       
                        <th>
                            Código
                        </th>
                        <th>
                            No Tubo
                        </th>
                        <th>
                            Descripción
                        </th>
                        <th>
                            Capacidad
                        </th>
                        <th>
                            Cantidad
                        </th>
                        <th>
                            Propiedad
                        </th>
                        <th>
                            Observación
                        </th>
                    </tr>--%>
                </thead>
            </table>
            <script id="dProductosParticulares"  type="text/x-jQuery-tmpl">
            <tbody>
                <tr style="font-size:11px">
                    <td  style="width:90px;text-align:center;">
                        ${Secuencia}
                    </td>
                    <td  style="width:70px;text-align:center">
                        ${CodigoTubo}
                    </td>
                    <td  style="width:215px">
                        ${Propietario}
                    </td>
                    <td  style="width:70px;text-align:center">
                        ${Codigo}
                    </td>
                    <td  style="width:215px">
                        ${Descripcion}
                    </td>
                    <td  style="width:60px;text-align:center">
                        ${Capacidad}    
                    </td>
                    <td  style="width:70px;text-align:center">
                        ${Volumen}
                     </td>
                      <td  style="width:30px">
                        ${Observacion}
                     </td>
                     <td>
                        <a href="#" onclick="EliminarProductosParticular('${Secuencia}','${Volumen}','0');return false;">Eliminar</a>
                     </td>
                  </tr>
             </tbody>
           </script>
           
      </div>

      
      
      </div>
  </div>
    </div>

    <div id="Totales" 
               
               style="width:940px;float:left;text-align:center;font-size:9pt; color: #3366CC; font-weight: bold;">
          <asp:Label ID="Label1" runat="server" Enabled="false" style="color: #003366" >TOTAL  PRAXAIR : </asp:Label> 
          <asp:Label ID="lblTotalCilindrosPraxair" runat="server" Enabled="false" 
              style="color: #003366" >0 </asp:Label> 
          <asp:Label ID="Label5" runat="server" Enabled="false" style="color: #003366" > -- </asp:Label> 
          <asp:Label ID="Label4" runat="server" Enabled="false" style="color: #003366" >    TOTAL  AJENOS :</asp:Label> 
          <asp:Label ID="lblTotalCilindrosAjenos" runat="server" Enabled="false" style="color: #003366" >0</asp:Label> 
         
              
    </div>

     <div>
          <div>
                    <span class="etiqueta"><label for="txtObservacionPedido">Observaciones Pedido</label></span>        
                    <span class="form-el"><input id="txtObservacionPedido" runat = "server" name="txtObservacionPedido"  style="width:800px" maxlength="100" type="text" /></span>
          </div>
    
    </div>

    <br />

     <div style="float:left;text-align:center" >
                        
       <input id="btnProcesar" type="button" value="Procesar"/>
       <input id="btnNuevo" type="button" value="Nuevo"  />
       <%--<input id="btnFacturar" type="button" value="Factura"  />--%>
      <%-- <input id="btnRemito" type="button" value="Remito"  />--%>
       <%--<input id="btnVista" type="button" value="Vista Factura"  />--%>
        <input id="btnSalir" type="button" value="Salir"  />
        <input id="btnlimpiarGrilla" type="button" value="Limpiar Grilla"  />
                     <input id="btntest" type="button" value="test"  />
            
       <asp:Label ID="lblFacturaGenerada" runat="server"  Font-Size="Medium" Enabled="false" ></asp:Label> 
       <asp:Label ID="LblNumeroFacturaGenerada" runat="server"  Font-Size="Medium" Enabled="false" ></asp:Label> 
        
    </div>


     <div id="ModalBusqueda" title="Busqueda Articulos" class="TituloVentana" style="display: none">
            <br />
            <div>
              
              <table>
                <tr>
                    <td>
                        <label for="TBterceroID" style="float:left;font-size:small">Buscar Por</label> 
                    </td>
                    <td>
                        <asp:DropDownList ID="txtBuscarPor"  runat="server"  Font-Size="Small">
                            <asp:ListItem Value="1">Nombre</asp:ListItem>
                            <asp:ListItem Value="2">Código</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <input id="txtTextoBusqueda" name="txtTextoBusqueda" style="float:left;width:280px;font-size:small" runat="server" maxlength="15"  type="text"  onkeyup="this.value=this.value.toUpperCase();" />
                    </td>
                    <td>
                         <input id="btnBuscarArticulo"  type="button"  style="font-size:small" value="Buscar" title="Agregar Grilla"/>
                    </td>
                </tr>
              </table>

        </div>
                <div id="grid_container">
                    <table id="list">
           
                    </table>
                    <div id="pager"></div>

                </div>

       </div>
           


       <div id="ModalBusquedaConductores" title="Busqueda Conductores" class="TituloVentana" style="display: none">
            <br />
            <div>
              
              <table>
                <tr>
                    <td>
                        <label for="TBterceroID" style="float:left;font-size:small">Buscar Por</label> 
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1"  runat="server"  Font-Size="Small">
                            <asp:ListItem Value="1">Nombre</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <input id="txtTextoBusquedaCond" name="txtTextoBusquedaCond" style="float:left;width:280px;font-size:small" runat="server" maxlength="15"  type="text"  onkeyup="this.value=this.value.toUpperCase();" />
                    </td>
                    <td>
                         <input id="btnBuscarConductor"  type="button"  style="font-size:small" value="Buscar" title="Agregar Grilla"/>
                    </td>
                </tr>
              </table>

        </div>

      <div id="gridConductores">
            <table id="listConductores">
            </table>
            <div id="pagerConductores"></div>

        </div>

      

       </div>



   

        
        </div>

   
    
  
     <script src="Scripts/TomaPedidos_1404.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.js" type="text/javascript"></script>

    <script src="Scripts/jquery.alerts.js" type="text/javascript"></script>
  
    <script src="Scripts/jquery.numeric.js" type="text/javascript"></script>

    <script src="Scripts/jquery.loadmask.js" type="text/javascript"></script>
   
</asp:Content>

