<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/MasterPage.Master" AutoEventWireup="true" CodeBehind="PruebaDocumentoTransferencia.aspx.cs" Inherits="TransferenciaZonaFrancaV2.PruebaDocumentoTransferencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/ClaseDivs.css" rel="stylesheet" type="text/css" />
       
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div>
            <span>
            
            </span><span >
                <a id="LblAgregarPropietario" href="#">Agregrar</a>
                <a id="LblAgregarNuevoPropietario" href="#">Nuevo Propietario</a>
            </span>
         </div>

      <div>
      <table id="Tterceros" class="Tabla" style="width: 80%">
                <thead>
                    <tr>
                        <th>
                        </th>
                        <th>
                            ID
                        </th>
                        <th>
                            Nombre
                        </th>
                        <th>
                            Apellido
                        </th>
                        <th>
                            Criadero
                        </th>
                        <th>
                            Ciudad
                        </th>
                    </tr>
                </thead>
            </table>
            <script id="dTerceros"  type="text/x-jQuery-tmpl"><tbody><tr><td><a href="#" onclick="EliminarTercero('${idTercero}');return false;">Eliminar</a></td><td>${idTercero}</td><td>${NombreTercero}</td><td>${ApellidoTercero}</td><td>${Criadero}</td><td>${CiudadResidencia}</td></tr></tbody></script>
      
      </div>

        <div>
            <table id="TProductos" class="Tabla" style="width: 100%">
                <thead>
                    <tr>
                       
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
                    </tr>
                </thead>
            </table>
            <script id="dProductos"  type="text/x-jQuery-tmpl"><tbody><tr><td>${Codigo}</td><td>${CodigoTubo}</td><td>${Descripcion}</td><td>${Capacidad}</td><td>${Cantidad}</td><td>${Propiedad}</td><td>${Observacion}</td></tr></tbody></script>
            <%--<script id="dProductos"  type="text/x-jQuery-tmpl"><tbody><tr><td>${Codigo}</td></tr></tbody></script>--%>
            <%--<script id="Script1"  type="text/x-jQuery-tmpl"><tbody><tr><td><a href="#" onclick="EliminarTercero('${idTercero}');return false;">Eliminar</a></td><td>${idTercero}</td><td>${NombreTercero}</td><td>${ApellidoTercero}</td><td>${Criadero}</td><td>${CiudadResidencia}</td></tr></tbody></script>--%>
      
      </div>
   

    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
      <script src="Scripts/jquery.tmpl.js" type="text/javascript"></script>
    <script src="Scripts/jquery.dataTables.js" type="text/javascript"></script>
    <script src="Scripts/date.format.js" type="text/javascript"></script>
      <%-- <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
       <script src="../js/jquery-ui.min.js" type="text/javascript"></script>--%>
        <script src="Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
       <%-- <script src="Scripts/DocumentoTransferencia.js" type="text/javascript"></script>--%>
    <script src="Scripts/RegistroNacimiento.js" type="text/javascript"></script>
        <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
           <script src="Scripts/jquery.tmpl.js" type="text/javascript"></script>
            <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.13/themes/cupertino/jquery-ui.css"
   <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />

        
</asp:Content>
