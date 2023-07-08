<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="wfRequisitosLlenado.aspx.cs" Inherits="IUProdPack.RequisitosLlenado.wfRequisitosLlenado" stylesheettheme="Theme_Praxair" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
    <strong>Administración de Prerrequisitos - Requisitos<br />
        <br />
        <asp:UpdatePanel ID="upResumen" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                                
                <table style="width:100%;">
                    <tr>
                        <td>Activo: 
                            <asp:DropDownList ID="cmbActivo" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Tipo: 
                            <asp:DropDownList ID="cmbTipo" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Descripcion: 
                            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                        </td>
                        <td> 
                            <asp:ImageButton ID="btnFiltrar" runat="server" 
                                SkinID="ASP_ImgButton-Buscar" ToolTip="Filtrar" 
                                onclick="btnFiltrar_Click" />
                        </td>  
                        <td> 
                            <asp:ImageButton ID="btnTodos" runat="server" 
                                SkinID="ASP_ImgButton-Cancelar" ToolTip="Sin filtros" 
                                onclick="btnTodos_Click" />
                        </td>                       
                    </tr>
                </table>
                <br />
                <asp:ImageButton ID="IniciaGrabacion" runat="server"  SkinID="ASP_ImgButton-Adicionar" OnClick="IniciaGrabacion_Click" />
                <br />
            <asp:GridView ID="grdResumen" runat="server" AutoGenerateColumns="False" CssClass="Grilla" DataKeyNames="ID_REQUISITO,TIPO_REQUISITO,TIPO_ACTIVO,ESTADO"
            OnRowCommand="grdResumen_OnRowCommand" >
                <Columns>
                    <asp:ButtonField ButtonType="Image" CommandName="Actualiza" ImageUrl="~/App_Themes/Theme_Praxair/Image/Botones/Boton_Icono/Boton_Editar.png"
                        Text="Editar" />                 
                    
                    <asp:TemplateField HeaderText="Activo">
                        <HeaderTemplate>
                            Activo
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TIPO_ACTIVO_DESC") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" 
                                Text='<%# Bind("TIPO_ACTIVO_DESC") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo">
                        <HeaderTemplate>
                            Tipo
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("TIPO_REQUISITO_DESC") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" 
                                Text='<%# Bind("TIPO_REQUISITO_DESC") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" />                   
                    <asp:BoundField DataField="ESTADO_DESC" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
                &nbsp;
                <asp:HiddenField ID="snInserta" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />        
    </strong>
<br />
    &nbsp;
            
<asp:Panel ID="pnlPaso1" runat="server" CssClass="modalPopup" Height="250px" Style="display: none" Width="542px">
    <asp:UpdatePanel ID="upPaso1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td style="width: 10%">
                    </td>
                    <td colspan="2">
                    </td>
                    <td style="width: 10%">
                    </td>
                </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblCrear" runat="server"></asp:Label></td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 40%; text-align: left">
                            <asp:Label ID="lblProducto" runat="server" Text="Descripción:" Width="100%"></asp:Label></td>
                        <td style="width: 40%">
                            <asp:TextBox ID="Descripcion" runat="server" Width="100%"></asp:TextBox></td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 40%; text-align: left">
                            <asp:Label ID="Label2" runat="server" Text="Tipo:" Width="100%"></asp:Label></td>
                        <td style="width: 40%">
                            <asp:DropDownList ID="Tipo" runat="server" AppendDataBoundItems="True" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="Tipo_SelectedIndexChanged">
                                <asp:ListItem>...</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 40%; text-align: left">
                            <asp:Label ID="Label1" runat="server" Text="Activo:" Width="100%"></asp:Label></td>
                        <td style="width: 40%">
                            <asp:DropDownList ID="Activo" runat="server" AppendDataBoundItems="True" Width="100%">
                                <asp:ListItem>...</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 40%; text-align: left">
                            <asp:Label ID="Label3" runat="server" Text="Estado:" Width="100%"></asp:Label></td>
                        <td style="width: 40%">
                            <asp:DropDownList ID="Estado" runat="server" Width="100%">
                                <asp:ListItem>...</asp:ListItem>
                                <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                <asp:ListItem Value="1">Activo</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 40%; text-align: left">
                            <asp:Label ID="Label4" runat="server" Text="Preguntas por hoja:" Width="100%"></asp:Label></td>
                        <td style="width: 40%">
                            <asp:TextBox ID="PreguntasHoja" runat="server" Width="100%"></asp:TextBox></td>
                        <td style="width: 10%">
                            <cc1:FilteredTextBoxExtender ID="ftb1" runat="server" FilterType="Numbers" TargetControlID="PreguntasHoja">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                <tr>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 40%; text-align: left">
                        <asp:Label ID="lblValidaciones" runat="server" Text="Validaciones:" Width="100%"></asp:Label></td>
                    <td style="width: 40%">
                        <asp:DropDownList ID="Validaciones" runat="server" Width="100%" AppendDataBoundItems="True">
                            <asp:ListItem>...</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 10%">
                            <asp:ImageButton ID="nuevaValidacion" runat="server" ImageAlign="Middle" SkinID="ASP_ImgIcon-Adicionar" ToolTip="Crear nueva validacion" OnClick="nuevaValidacion_Click"
                                 /></td>
                </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 40%">
                            <asp:HiddenField ID="ID_REQUISITO" runat="server" />
                        <asp:HiddenField ID="snNuevaValidacion" runat="server" />
                            &nbsp;
                        </td>
                        <td style="width: 40%">
                        </td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 40%">
                            </td>
                        <td style="width: 40%">
                            <asp:ImageButton ID="irPaso2" runat="server" ImageAlign="Middle" ImageUrl="~/App_Themes/Theme_Praxair/Image/next-icon.png" OnClick="irPaso2_Click"
                                 /></td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%; height: 18px">
                        </td>
                        <td colspan="2" style="height: 18px">
                            <asp:ImageButton ID="imbCancelar1" runat="server" OnClick="imbCancelar_Click" SkinID="ASP_ImgButton-Cancelar" /></td>
                        <td style="width: 10%; height: 18px">
                        </td>
                    </tr>
                </table>
            &nbsp;
            
        </ContentTemplate>
    
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upprogressGral1" runat="server">
                <ProgressTemplate>
                    <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                    <strong style="font-size: small">Procesando datos por favor espere</strong>
                </ProgressTemplate>
            </asp:UpdateProgress>
</asp:Panel>
<asp:Panel ID="pnlPaso2" runat="server" CssClass="modalPopup" Height="270px" Style="display: none" Width="542px">
 <asp:UpdatePanel ID="upPaso2" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
         <table style="width: 100%">
             <tr>
                 <td style="width: 10%">
                 </td>
                 <td colspan="2" style="text-align: center">
                 </td>
                 <td style="width: 10%">
                 </td>
             </tr>
             <tr>
                 <td style="width: 10%">
                 </td>
                 <td colspan="2" style="text-align: center">
                     <asp:Label ID="lblCrear2" runat="server"></asp:Label></td>
                 <td style="width: 10%">
                 </td>
             </tr>
             <tr>
                 <td style="width: 10%">
                 </td>
                 <td style="width: 40%; text-align: left;">
                     <asp:Label ID="Label5" runat="server" Text="Descripción Validación:" Width="100%"></asp:Label></td>
                 <td style="width: 40%">
                     <asp:TextBox ID="DescripcionDet" runat="server" Width="100%"></asp:TextBox></td>
                 <td style="width: 10%">
                 </td>
             </tr>
             <tr>
                 <td style="width: 10%">
                 </td>
                 <td style="width: 40%; text-align: left">
                     <asp:Label ID="Label14" runat="server" Text="Es obligatoria:" Width="100%"></asp:Label></td>
                 <td style="width: 40%">
                     <asp:DropDownList ID="ObligatoriaDet" runat="server" Width="100%">
                         <asp:ListItem>...</asp:ListItem>
                         <asp:ListItem Value="1">Si</asp:ListItem>
                         <asp:ListItem Value="0">No</asp:ListItem>
                     </asp:DropDownList></td>
                 <td style="width: 10%">
                 </td>
             </tr>
             <tr>
                 <td style="width: 10%">
                 </td>
                 <td style="width: 40%; text-align: left;">
                     <div style="text-align: left">
                         <asp:Label ID="Label6" runat="server" Text="Orden:" Width="100%"></asp:Label></div>
                 </td>
                 <td style="width: 40%">
                     <asp:TextBox ID="OrdenDet" runat="server" Width="100%"></asp:TextBox></td>
                 <td style="width: 10%">
                     <cc1:FilteredTextBoxExtender ID="ftb2" runat="server" FilterType="Numbers" TargetControlID="OrdenDet">
                            </cc1:FilteredTextBoxExtender></td>
             </tr>
             <tr>
                 <td style="width: 10%">
                 </td>
                 <td style="width: 40%; text-align: left;">
                     <asp:Label ID="Label7" runat="server" Text="Estado Validación:" Width="100%"></asp:Label></td>
                 <td style="width: 40%">
                     <asp:DropDownList ID="EstadoDet" runat="server" Width="100%">
                         <asp:ListItem>...</asp:ListItem>
                         <asp:ListItem Value="1">Activo</asp:ListItem>
                         <asp:ListItem Value="0">Inactivo</asp:ListItem>
                     </asp:DropDownList></td>
                 <td style="width: 10%">
                 </td>
             </tr>
             <tr>
                 <td style="width: 10%">
                 </td>
                <td style="width: 40%; text-align: left;">
                     <asp:Label ID="Label8" runat="server" Text="Tipo respuesta:" Width="100%"></asp:Label></td>
                 <td style="width: 40%"><asp:DropDownList ID="TipoRespuestaDet" runat="server" AppendDataBoundItems="True" Width="100%">
                     <asp:ListItem>...</asp:ListItem>
                 </asp:DropDownList></td>
                 <td style="width: 10%">
                     <asp:ImageButton ID="imbConsultarRespuestas" runat="server" ImageAlign="Middle" SkinID="ASP_ImgIcon-Buscar" ToolTip="Consultar respuestas" OnClick="imbConsultarRespuestas_Click" />
                     <asp:ImageButton ID="nuevaRespuesta" runat="server" ImageAlign="Middle" SkinID="ASP_ImgIcon-Adicionar" ToolTip="Crear nueva respuesta" OnClick="nuevaPregunta_Click"
                                 /></td>
             </tr>
             <tr>
                 <td style="width: 10%">
                 </td>
                 <td style="width: 40%">
                     <asp:HiddenField ID="gIdRespuesta" runat="server" />
                     <asp:HiddenField ID="gValoresRespuesta" runat="server" />
                     <asp:HiddenField ID="gDefectoRespuesta" runat="server" />
                     <asp:HiddenField ID="gTipoRespuesta" runat="server" />
                 <asp:HiddenField ID="snNuevaRespuesta" runat="server" />
                 </td>
                 <td style="width: 40%">
                 </td>
                 <td style="width: 10%">
                 </td>
             </tr>
             <tr>
                <td style="width: 10%">
                </td>
                <td style="width: 40%">
                    <asp:ImageButton ID="volverPaso1" runat="server" ImageAlign="Middle" ImageUrl="~/App_Themes/Theme_Praxair/Image/back-icon.png" OnClick="volverPaso1_Click"/>
                </td>
                <td style="width: 40%">
                    <asp:ImageButton ID="irPaso3" runat="server" ImageAlign="Middle" ImageUrl="~/App_Themes/Theme_Praxair/Image/next-icon.png" OnClick="irPaso3_Click" 
                         /></td>
                <td style="width: 10%">
                </td>
            </tr>            
             <tr>
                <td style="width: 10%; height: 18px">
                </td>
                <td colspan="2" style="height: 18px">
                    <asp:ImageButton ID="imbCancelar2" runat="server" OnClick="imbCancelar_Click" SkinID="ASP_ImgButton-Cancelar" /></td>
                <td style="width: 10%; height: 18px">
                </td>
            </tr>
         </table>         
     </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upprogressGral2" runat="server">
                <ProgressTemplate>
                    <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                    <strong style="font-size: small">Procesando datos por favor espere</strong>
                </ProgressTemplate>
            </asp:UpdateProgress>
</asp:Panel>
<asp:Panel ID="pnlPaso3" runat="server" CssClass="modalPopup" Height="250px" Style="display: none" Width="542px">
 <asp:UpdatePanel ID="upPaso3" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
         <table style="width: 100%">
             <tr>
                 <td colspan="2" style="height: 18px">
                  <asp:Label ID="lblCrear3" runat="server"></asp:Label></td>
             </tr>
        <tr>
            <td style="height: 18px;" colspan="2">
              <asp:Panel ID="pnlTexo" runat="server" Height="50px" Width="100%"><table style="width: 100%">
                  <tr>
                      <td style="width: 50%; height: 18px; text-align: left;">
                                 <asp:Label ID="Label10" runat="server" Text="Mínimo:" Width="100%"></asp:Label></td>
                      <td style="width: 50%; height: 18px;">
                                 <asp:TextBox ID="CheckMinimo" runat="server" Width="100%"></asp:TextBox></td>
                  </tr>
                  <tr>
                      <td style="width: 50%; height: 18px; text-align: left;">
                                 <asp:Label ID="Label11" runat="server" Text="Máximo:" Width="100%"></asp:Label></td>
                      <td style="width: 50%; height: 18px;">
                                 <asp:TextBox ID="CheckMaximo" runat="server" Width="100%"></asp:TextBox></td>
                  </tr>
              </table>
                  <cc1:FilteredTextBoxExtender ID="ftb3" runat="server" FilterType="Numbers" TargetControlID="CheckMinimo">
                            </cc1:FilteredTextBoxExtender>
                  <cc1:FilteredTextBoxExtender ID="ftb4" runat="server" FilterType="Numbers" TargetControlID="CheckMaximo">
                            </cc1:FilteredTextBoxExtender>
                            </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 18px;" colspan="2">
    <asp:Panel ID="pnlCombo" runat="server" Height="98px" Width="100%"><table style="width: 100%">
        <tr>
            <td style="width: 50%; text-align: left;">
                                 <asp:Label ID="Label9" runat="server" Text="Indique los valores separados por coma (,):" Width="100%"></asp:Label></td>
            <td style="width: 50%">
                                     <asp:TextBox ID="ComboValores" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 50%; text-align: left;">
                                     <asp:Label ID="Label12" runat="server" Text="Indique el valor por defecto:" Width="100%"></asp:Label></td>
            <td style="width: 50%">
                                     <asp:TextBox ID="ComboDefecto" runat="server" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 50%; height: 18px;">
            </td>
            <td style="width: 50%; height: 18px;">
            </td>
        </tr>        
    </table>
    </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 18px;" colspan="2">
             <asp:Panel ID="pnlCheck" runat="server" Height="50px" Width="100%"><table style="width: 100%">
                 <tr>
                     <td style="width: 50%; height: 18px; text-align: left;">
                                     <asp:Label ID="Label13" runat="server" Text="Por defecto la validación esta activa?"
                                         Width="100%"></asp:Label></td>
                     <td style="width: 50%; height: 18px;">
                                     <asp:CheckBox ID="CheckDefecto" runat="server" /></td>
                 </tr>
             </table>
                     </asp:Panel>
    </td>
        </tr>
        <tr>
            <td style="width: 50%; height: 18px;">
                <asp:ImageButton ID="volverPaso2" runat="server" ImageAlign="Middle" ImageUrl="~/App_Themes/Theme_Praxair/Image/back-icon.png" OnClick="volverPaso2_Click"/></td>
            <td style="width: 50%; height: 18px;">
                    <asp:ImageButton ID="irPaso4" runat="server" ImageAlign="Middle" ImageUrl="~/App_Themes/Theme_Praxair/Image/next-icon.png" OnClick="irPaso4_Click"
                         /></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 18px">
                    <asp:ImageButton ID="imbCancelar3" runat="server" OnClick="imbCancelar_Click" SkinID="ASP_ImgButton-Cancelar" /></td>
        </tr>
    </table>
     </ContentTemplate>     
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                <ProgressTemplate>
                    <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                    <strong style="font-size: small">Procesando datos por favor espere</strong>
                </ProgressTemplate>
            </asp:UpdateProgress>
</asp:Panel>
<asp:Panel ID="pnlPaso4" runat="server" CssClass="modalPopup" Height="250px" Style="display: none" Width="534px">
 <asp:UpdatePanel ID="upPaso4" runat="server" UpdateMode="Conditional">
     <ContentTemplate><table style="width: 100%">
         <tr>
             <td colspan="2" style="height: 18px">
                 <asp:TextBox ID="ResumenFinal" runat="server" Height="200px" TextMode="MultiLine"
                     Width="100%"></asp:TextBox></td>
         </tr>
     </table>
         <table style="width: 100%">
             <tr>
                 <td style="width: 50%; height: 18px;">
                     <asp:ImageButton ID="volverPaso3" runat="server" ImageAlign="Middle" ImageUrl="~/App_Themes/Theme_Praxair/Image/back-icon.png" OnClick="volverPaso3_Click" /></td>
                 <td style="width: 50%; height: 18px;">
                     <asp:ImageButton ID="imbGuardar" runat="server"
                         SkinID="ASP_ImgIcon-Guardar" OnClick="imbGuardar_Click" /></td>
             </tr>
         </table>
     </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress4" runat="server">
                <ProgressTemplate>
                    <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                    <strong style="font-size: small">Procesando datos por favor espere</strong>
                </ProgressTemplate>
            </asp:UpdateProgress>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Panel>
<asp:Panel ID="pnlRespuestas" runat="server" CssClass="modalPopup" Height="250px" Style="display: none" Width="534px" ScrollBars="Vertical"  >
    &nbsp;<asp:ImageButton ID="AdicionarRespuesta" runat="server"  SkinID="ASP_ImgButton-Adicionar" OnClick="AdicionarRespuesta_Click"  />
    <asp:ImageButton ID="imbCancelarRespuestas" runat="server" SkinID="ASP_ImgButton-Cancelar" OnClick="imbCancelarRespuestas_Click" /><br />
    <asp:UpdatePanel ID="upRespuestas" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

<asp:GridView ID="grdRespuestas" runat="server" AutoGenerateColumns="False" CssClass="Grilla" DataKeyNames="ID_RESPUESTA,VALORES,VALOR_DEFECTO,TIPO_RESPUESTA" OnRowCommand="grdRepuestas_OnRowCommand">
    <Columns>
        <asp:ButtonField ButtonType="Image" CommandName="Actualiza" ImageUrl="~/App_Themes/Theme_Praxair/Image/Botones/Boton_Icono/Boton_Aceptar.png"
                        Text="Editar" />
        <asp:BoundField DataField="TIPO_RESPUESTA_DESC" HeaderText="Tipo" />
        <asp:BoundField DataField="VALORES" HeaderText="Valores Permitidos" />
        <asp:BoundField DataField="VALOR_DEFECTO" HeaderText="Valor por defecto" />
        <asp:BoundField DataField="USUARIO_CREA" HeaderText="Usuario" />
        <asp:BoundField DataField="FECHA_CREA" HeaderText="Fecha" />
    </Columns>
</asp:GridView>
            &nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress5" runat="server">
        <ProgressTemplate>
            <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
            <strong style="font-size: small">Procesando datos por favor espere</strong>
        </ProgressTemplate>
    </asp:UpdateProgress>
    &nbsp;</asp:Panel>

<asp:Button ID="btnDocDig1" runat="server" BackColor="White" BorderStyle="None" BorderWidth="0px" Height="8px" Width="1px" />
    <asp:Button ID="btnDocDig2" runat="server" BackColor="White" BorderStyle="None" BorderWidth="0px" Height="8px" Width="1px" />
    <asp:Button ID="btnDocDig3" runat="server" BackColor="White" BorderStyle="None" BorderWidth="0px" Height="8px" Width="1px" />
    <asp:Button ID="btnDocDig4" runat="server" BackColor="White" BorderStyle="None" BorderWidth="0px" Height="8px" Width="1px" />
    <asp:Button ID="btnDocDigRespuestas" runat="server" BackColor="White" BorderStyle="None" BorderWidth="0px" Height="8px" Width="1px" />
    
  <cc1:ModalPopupExtender ID="PopUpPaso1" runat="server" BackgroundCssClass="fondoModal"
        DropShadow="false" PopupControlID="pnlPaso1" TargetControlID="btnDocDig1" Y="100"></cc1:ModalPopupExtender>
  <cc1:ModalPopupExtender ID="PopUpPaso2" runat="server" BackgroundCssClass="fondoModal"
        DropShadow="false" PopupControlID="pnlPaso2" TargetControlID="btnDocDig2" Y="100"></cc1:ModalPopupExtender>
  <cc1:ModalPopupExtender ID="PopUpPaso3" runat="server" BackgroundCssClass="fondoModal"
        DropShadow="false" PopupControlID="pnlPaso3" TargetControlID="btnDocDig3" Y="100"></cc1:ModalPopupExtender>
  <cc1:ModalPopupExtender ID="PopUpPaso4" runat="server" BackgroundCssClass="fondoModal"
        DropShadow="false" PopupControlID="pnlPaso4" TargetControlID="btnDocDig4" Y="100"></cc1:ModalPopupExtender>        
  <cc1:ModalPopupExtender ID="PopUpPasoRespuestas" runat="server" BackgroundCssClass="fondoModal"
        DropShadow="false" PopupControlID="pnlRespuestas" TargetControlID="btnDocDigRespuestas" Y="100"></cc1:ModalPopupExtender>
    <br />
    <br />
    <table>
        <tr>
            <td>
                <asp:Button ID="btnshowpopupmsg" runat="server" CausesValidation="False" Style="display: none" />
                <cc1:ModalPopupExtender ID="mpemensaje" runat="server" BackgroundCssClass="fondoModal"
                    CancelControlID="btnokmensaje" PopupControlID="pnlmsg" TargetControlID="btnshowpopupmsg">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlmsg" runat="server" CssClass="modalPopup" Height="150px" Style="display: none;
                    left: 0px; top: 7%" Width="400px">
                    <asp:UpdatePanel ID="upmensaje" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="vertical-align: middle; color: white; background-color: #1c5e55; text-align: left">
                                <strong>Mensaje</strong></div>
                            <br />
                            &nbsp;<asp:Label ID="lblmensaje" runat="server"></asp:Label><br />
                            <br />
                            &nbsp;<asp:ImageButton ID="btnokmensaje" runat="server" OnClick="btnokmensaje_Click"
                                SkinID="ASP_ImgButton-Aceptar" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="upprogressGral" runat="server">
                        <ProgressTemplate>
                            <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                            <strong style="font-size: small">Procesando datos por favor espere</strong>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>

