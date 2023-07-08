<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="wfRespuestas.aspx.cs" Inherits="IUProdPack.RequisitosLlenado.wfRespuestas" stylesheettheme="Theme_Praxair" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
    <strong>Administración de Respuestas</strong><br />
    &nbsp;<br />
 <asp:UpdatePanel ID="upResumen" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
    <table style="width: 100%">
        <tr>
            <td style="width: 50%; height: 18px">
                <asp:Label ID="Label8" runat="server" Text="Tipo respuesta:" Width="100%"></asp:Label></td>
            <td style="width: 50%; height: 18px">
                <asp:DropDownList ID="TipoRespuestaDet" runat="server" AppendDataBoundItems="True"
                    AutoPostBack="True" OnSelectedIndexChanged="TipoRespuestaDet_SelectedIndexChanged"
                    Width="100%">
                    <asp:ListItem>...</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 18px">
                <asp:ImageButton ID="AdicionarRespuesta" runat="server" OnClick="AdicionarRespuesta_Click"
                    SkinID="ASP_ImgButton-Adicionar" /></td>
        </tr>
    </table>
         <br />
         <asp:GridView ID="grdRespuestas" runat="server" AutoGenerateColumns="False" CssClass="Grilla"
             DataKeyNames="ID_RESPUESTA,VALORES,VALOR_DEFECTO,TIPO_RESPUESTA" OnRowCommand="grdRepuestas_OnRowCommand">
             <Columns>
                 <asp:ButtonField ButtonType="Image" CommandName="Elimina" ImageUrl="~/App_Themes/Theme_Praxair/Image/Botones/Boton_Icono/Boton_Eliminar.png"
                     Text="Elimina" />
                 <asp:BoundField DataField="TIPO_RESPUESTA_DESC" HeaderText="Tipo" />
                 <asp:BoundField DataField="VALORES" HeaderText="Valores Permitidos" />
                 <asp:BoundField DataField="VALOR_DEFECTO" HeaderText="Valor por defecto" />
                 <asp:BoundField DataField="USUARIO_CREA" HeaderText="Usuario" />
                 <asp:BoundField DataField="FECHA_CREA" HeaderText="Fecha" />
             </Columns>
         </asp:GridView>
     </ContentTemplate>
 
 </asp:UpdatePanel>       
    <br />
    <asp:Panel ID="pnlPaso3" runat="server" CssClass="modalPopup" Height="250px" Style="display: none"
        Width="542px">
        <asp:UpdatePanel ID="upPaso3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="width: 100%">
                    <tr>
                        <td colspan="2" style="height: 18px">
                            <asp:Label ID="lblCrear3" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 18px">
                            <asp:Panel ID="pnlTexo" runat="server" Height="50px" Width="100%">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 50%; height: 18px; text-align: left">
                                            <asp:Label ID="Label10" runat="server" Text="Mínimo:" Width="100%"></asp:Label></td>
                                        <td style="width: 50%; height: 18px">
                                            <asp:TextBox ID="CheckMinimo" runat="server" Width="100%"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%; height: 18px; text-align: left">
                                            <asp:Label ID="Label11" runat="server" Text="Máximo:" Width="100%"></asp:Label></td>
                                        <td style="width: 50%; height: 18px">
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
                        <td colspan="2" style="height: 18px">
                            <asp:Panel ID="pnlCombo" runat="server" Height="98px" Width="100%">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 50%; text-align: left">
                                            <asp:Label ID="Label9" runat="server" Text="Indique los valores separados por coma (,):"
                                                Width="100%"></asp:Label></td>
                                        <td style="width: 50%">
                                            <asp:TextBox ID="ComboValores" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%; text-align: left">
                                            <asp:Label ID="Label12" runat="server" Text="Indique el valor por defecto:" Width="100%"></asp:Label></td>
                                        <td style="width: 50%">
                                            <asp:TextBox ID="ComboDefecto" runat="server" Width="100%"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%; height: 18px">
                                        </td>
                                        <td style="width: 50%; height: 18px">
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 18px">
                            <asp:Panel ID="pnlCheck" runat="server" Height="50px" Width="100%">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 50%; height: 18px; text-align: left">
                                            <asp:Label ID="Label13" runat="server" Text="Por defecto la validación esta activa?"
                                                Width="100%"></asp:Label></td>
                                        <td style="width: 50%; height: 18px">
                                            <asp:CheckBox ID="CheckDefecto" runat="server" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%; height: 18px">
                            <asp:ImageButton ID="imbGuardar" runat="server" OnClick="imbGuardar_Click" SkinID="ASP_ImgButton-Guardar" /></td>
                        <td style="width: 50%; height: 18px">
                            <asp:ImageButton ID="imbCancelar" runat="server" OnClick="imbCancelar_Click" SkinID="ASP_ImgButton-Cancelar" /></td>
                    </tr>
                </table>
                <asp:HiddenField ID="snInserta" runat="server" />
                <asp:HiddenField ID="ID_RESPUESTA" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress3" runat="server">
            <ProgressTemplate>
                <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                <strong style="font-size: small">Procesando datos por favor espere</strong>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:Panel>
    <asp:Button ID="btnDocDig3" runat="server" BackColor="White" BorderStyle="None" BorderWidth="0px" Height="8px" Width="1px" />
    <cc1:ModalPopupExtender ID="PopUpPaso3" runat="server" BackgroundCssClass="fondoModal"
        DropShadow="false" PopupControlID="pnlPaso3" TargetControlID="btnDocDig3" Y="100"></cc1:ModalPopupExtender>
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
    <table>
        <tr>
            <td>
                <asp:Button ID="btnConfirmacion" runat="server" CausesValidation="False" Style="display: none" />
                <cc1:ModalPopupExtender ID="mpeConfirmacion" runat="server" BackgroundCssClass="fondoModal"
                    CancelControlID="btnCancelarConfirma" PopupControlID="pnlConfirma" TargetControlID="btnConfirmacion">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlConfirma" runat="server" CssClass="modalPopup" Height="150px" Style="display: none;
                    left: 0px; top: 7%" Width="400px">
                    <asp:UpdatePanel ID="upConfirmacion" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="vertical-align: middle; color: white; background-color: #1c5e55; text-align: left">
                                <strong>Confirmación</strong></div>
                            <br />
                            &nbsp;<asp:Label ID="lblConfirma" runat="server">¿Desea realizar esta operación?</asp:Label><br />
                            <br />
                            &nbsp;<asp:ImageButton ID="btnOKCOnfirma" runat="server" OnClick="btnOKCOnfirma_Click"
                                SkinID="ASP_ImgButton-Aceptar" />
                            <asp:ImageButton ID="btnCancelarConfirma" runat="server" OnClick="btnCancelarConfirma_Click"
                                SkinID="ASP_ImgButton-Cancelar" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;
                    <asp:UpdateProgress ID="upprogressGralC" runat="server">
                        <ProgressTemplate>
                            <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                            <strong style="font-size: small">Procesando datos por favor espere</strong>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </asp:Panel>
            </td>
        </tr>
    </table>
    
</asp:Content>

