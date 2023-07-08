<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mnMenu.ascx.cs" Inherits="IUProdPack.mnMenu" %>

 <div id="ddsidemenubar" class="markermenu" style="left: 0px; top: 3px">
    <ul>
        <%--<li><a href="#" rel="submenuFE">Transferencia a FE</a></li> --%>                                               
        <li><a href="#" rel="submenuConf">Configuración</a></li>  
        <li><a href="#" rel="submenuProc">Procesos</a></li> 
    </ul>
</div>
 
<script type="text/javascript"> 
    ddlevelsmenu.setup("ddsidemenubar", "sidebar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
</script>

<%--<ul id="submenuFE" class="ddsubmenustyle blackwhite" style="left: 32px; top: 542px">--%> 
    <%--<li><a href="<%=Page.ResolveUrl("~")%>TransferenciaFE/wfRecepcionTanquero.aspx">Recepción de Tanquero</a></li>--%>             
<%--</ul>--%> 
<ul id="submenuConf" class="ddsubmenustyle blackwhite" style="left: 32px; top: 542px">
    <li><a href="<%=Page.ResolveUrl("~")%>RequisitosLlenado/wfTipoActivo.aspx">Tipos de activo</a></li>            
    <li><a href="<%=Page.ResolveUrl("~")%>RequisitosLlenado/wfRequisitosLlenado.aspx">Administración Requisitos</a></li>
    <li><a href="<%=Page.ResolveUrl("~")%>RequisitosLlenado/wfRespuestas.aspx">Administración Respuestas</a></li>
    <li><a href="<%=Page.ResolveUrl("~")%>Llenado/wfRacks.aspx">Administración Racks</a></li>                
</ul>
<ul id="submenuProc" class="ddsubmenustyle blackwhite" style="left: 32px; top: 542px">
    <li><a href="<%=Page.ResolveUrl("~")%>TransferenciaFE/wfRecepcionTanquero.aspx">Recepción de Tanquero</a></li>               
    <li><a href="<%=Page.ResolveUrl("~")%>GenerarLote/wfGenerarLote.aspx">Generación de Lote</a></li>                 
    <li><a href="<%=Page.ResolveUrl("~")%>GenerarLote/wfImpresionEtiquetaLote.aspx">Impresión Etiquetas Lote</a></li>              
    <li><a href="<%=Page.ResolveUrl("~")%>GenerarLote/wfImpresionEtqAjenos.aspx">Impresión Etiquetas Ajenos</a></li>  
    <li><a href="<%=Page.ResolveUrl("~")%>GenerarLote/wfTransferenciaLote.aspx">Transferencia Lote a Distribución</a></li>  
    <li><a href="<%=Page.ResolveUrl("~")%>ReclasificarProducto/wfReclasificaProducto.aspx">Reclasificar Producto</a></li>     
                                         
</ul>
       
      
