<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="mnMenu.ascx.vb" Inherits="ControlPaquete.mnMenu" %>
               <div id="ddsidemenubar" class="markermenu" style="left: 0px; top: 3px">
                            <ul>
                                <li><a href="#" rel="submenuparametro">Par�metros</a></li>
                                <li><a href="#" rel="submenuprogramacion">Programaci�n</a></li>
                                <li><a href="#" rel="submenuproceso">Procesos</a></li>
                                <li><a href="#" rel="submenuconsulta">Reportes</a></li>
                            </ul>
                        </div>
 
                        <script type="text/javascript"> 
                            ddlevelsmenu.setup("ddsidemenubar", "sidebar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
                        </script>
 
                        <ul id="submenuparametro" class="ddsubmenustyle blackwhite" style="left: 32px; top: 542px">
                            <li><a href="etiquetas.aspx">Etiquetas</a></li>
                            <li><a href="festivos.aspx">D�as Festivos</a></li>
                            <li><a href="motivoAnulacion.aspx">M�tivos de Anulaci�n</a></li>
                            <li><a href="motivoDiferencia.aspx">M�tivos de Diferencia</a></li>
                            <li><a href="Sectores.aspx">Sectores</a></li>
                            <li><a href="SectoresPorSucursal.aspx">Sectores por Sucursal</a></li>
                            <li><a href="Subdepositos.aspx">Subdep�sitos</a></li>
                        </ul>

                        <ul id="submenuprogramacion" class="ddsubmenustyle blackwhite" style="left: 574px; top: 685px">
                            <%--<li><a href="TipoConteo.aspx">Tipos de Conteo</a></li>--%>
                            <li><a href="ProgramacionConteo.aspx">Programaci�n Manual</a></li>
                            <li><a href="ConteosReprogramacion.aspx">Reprogramaci�n</a></li>
                            <li><a href="Anulacion.aspx">Anulaci�n</a></li>
                        </ul>
 
                        <ul id="submenuproceso" class="ddsubmenustyle blackwhite" style="left: 218px; top: 597px">                            
                            <li><a href="Apertura.aspx">Apertura de Conteo</a></li>
                            <li><a href="ConteosRegistro.aspx">Registro Manual</a></li>
                            <li><a href="Bloqueo.aspx">Bloqueo de Conteo</a></li>
                            <li><a href="ConteosDiferencia.aspx">Justificaci�n de Diferencia</a></li>
                        </ul>
 
                        <ul id="submenuconsulta" class="ddsubmenustyle blackwhite" style="left: 783px; top: 687px">
                            <li><a href="ReporteCierreLastro.aspx">Cierre de lastro</a></li>                            
                            <li><a href="ReporteConteoRealizado.aspx">Conteo de lastro</a></li>                            
                            <li><a href="ReporteDiferencia.aspx">Diferencias</a></li>
                            <li><a href="ReporteSubdeposito.aspx">Cuadro Control Subdep�sitos</a></li>
                            <li><a href="ReporteEstadistica.aspx">Estad�sticas</a></li>
                        </ul>
