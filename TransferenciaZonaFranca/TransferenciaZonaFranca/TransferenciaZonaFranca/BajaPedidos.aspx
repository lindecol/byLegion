<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/MasterPage.Master" AutoEventWireup="true" CodeBehind="BajaPedidos.aspx.cs" Inherits="TransferenciasZF.BajaPedidos" %>

  
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

 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div id="Principal">
          
       <div id="msg"></div>
       <div>

            <div id="Titulos" style="float:left;width:490px" >  Baja de Pedidos </div>

      
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
                    <span class="etiqueta"><label for="cmbEmpresaOrigen">Nro Pedido</label></span>        
                    <span  class="form-el">
                    <input id="txtNroPedido" runat = "server" name="txtNroPedido" style="width:100px"  maxlength="20" type="text" /></span>
                  <%--  <asp:DropDownList ID="cmbEmpresaOrigen" Width="250px" runat="server" Enabled="false" ></asp:DropDownList></span>--%>
                </div>

        <div class="fila">
                    <span class="etiqueta"><label for="cmbNuevoEstado">Nuevo Estado</label></span>        
                    <span  class="form-el"><asp:DropDownList ID="cmbNuevoEstado" Width="250px" runat="server"> <asp:ListItem Value="I">&lt;Anulados&gt;</asp:ListItem>
                    <asp:ListItem Value="E">&lt;Entregados&gt;</asp:ListItem></asp:DropDownList></span>
                </div>
                <div class="fila">
                    <span class="etiqueta"><label for="cmbEmpresaOrigen">Observaciones</label></span>        
                    <span  class="form-el">
                   </span>
                  <%--  <asp:DropDownList ID="cmbEmpresaOrigen" Width="250px" runat="server" Enabled="false" ></asp:DropDownList></span>--%>
                </div>
              
                
               

               
            </div>
 
   
         
      <div style="width:900px;float:left">
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

      
  

   

     <div>
          <div>
                    
                    <span class="form-el"><input id="txtObservacionPedido" runat = "server" name="txtObservacionPedido"  style="width:900px" maxlength="150" type="text" /></span>
          </div>
    
    </div>

    <br />

     <div style="float:left;text-align:center" >
                        
       <input id="btnDarBajaPedido" type="button" value="Procesar"/>
       
        
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

