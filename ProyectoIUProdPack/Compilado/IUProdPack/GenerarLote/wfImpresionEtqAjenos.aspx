<%@ page language="C#" masterpagefile="~/Master.master" autoeventwireup="true" inherits="GenerarLote_wfImpresionEtqAjenos, App_Web_mb2mcfam" title="Impresión Etiquetas Ajenos" stylesheettheme="Theme_Praxair" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <strong>Impresión de Etiquetas Ajenos<br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate >
                            <table align="center">
                                <tr align="left">
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td colspan="2">
                                        <asp:Label ID="lblLote" runat="server" Text="No. Lote"></asp:Label>
                                        <asp:TextBox ID="txtLote" runat="server" Width="112px"></asp:TextBox></td>
                                </tr>
                                <tr align="left">
                                    <td>
                                    </td>
                                    <td colspan="1" style="width: 159px">
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                    </td>
                                    <td colspan="1" style="width: 159px">
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td colspan="2">
                                        <asp:Label ID="lblEtiquetaTitulo" runat="server" Text="Seleccione cuales Etiquetas Imprimir" Width="240px"></asp:Label></td>
                                </tr>
                                <tr align="left">
                                    <td>
                                                    <asp:RadioButton ID="rdbTodas" runat="server" Text="Todas las Etiquetas del Lote"  GroupName="Etiquetas" Width="224px" OnCheckedChanged="rdbTodas_CheckedChanged" AutoPostBack="True" Checked="True" /></td>
                                    <td colspan="1" style="width: 159px">
                                        </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                                    <asp:RadioButton ID="rdbEtiquetaCx" runat="server" Text="La etiqueta con éste Nº de Cilindro" GroupName="Etiquetas" Width="224px" OnCheckedChanged="rdbEtiquetaCx_CheckedChanged" AutoPostBack="True" /></td>
                                    <td style="width: 159px">
                                        <asp:TextBox ID="txtNumCx" runat="server" Width="70px" Enabled="False" Visible="False" OnTextChanged="txtNumCx_TextChanged"></asp:TextBox></td>
                                </tr>
                                <tr align="left">
                                    <td>
                                    </td>
                                    <td align="left" colspan="1" style="width: 159px">
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                    </td>
                                    <td align="left" colspan="1" style="width: 159px">
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td align="center" colspan="2">
                                        <asp:ImageButton ID="imbImprimir" runat="server" SkinID="ASP_ImgButton-Imprimir" OnClick="imbImprimir_Click" />&nbsp;
                                        <asp:ImageButton ID="imbCancelar" runat="server" SkinID="ASP_ImgButton-Cancelar" OnClick="imbCancelar_Click" /></td>
                                </tr>
                                <tr align="left">
                                    <td>
                                    </td>
                                    <td align="left" colspan="1" style="width: 159px">
                                    </td>
                                </tr>
                            </table>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </strong>
     
      <table align="center">
            <tr>
                <td align="center" >
                     <asp:Button Style="display: none" ID="btnpopupLegajo" runat="server"></asp:Button>
                    <cc1:ModalPopupExtender ID="mpepopupLegajo" runat="server" PopupControlID="pnlpopupLegajo"
                        BackgroundCssClass="fondoModal" TargetControlID="btnpopupLegajo" CancelControlID="btnCancelLegajo">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="pnlpopupLegajo" runat="server" Width="500px" Height="200px" Style="display: none;
                        left: 0px; top: 3%;" CssClass="modalPopup">
                        <asp:UpdatePanel ID="upopupLegajo" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table align="center">
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lblTituLegajo" runat="server" Text="Legajo" Width="100%" BackColor="Green" Font-Size="Small" ForeColor="White"   ></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td  colspan="1" >
                                        </td>
                                        <td colspan="1" >
                                        </td>
                                        <td  colspan="1" >
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3" >
                                            <asp:Label ID="lblIngrese" runat="server" Text="Ingrese su Legajo y Contraseña:" Width="280px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td  colspan="1" >
                                        </td>
                                        <td colspan="1" >
                                        </td>
                                        <td  colspan="1" >
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="1">
                                            <asp:Label ID="lblLegajo" runat="server" Text="Legajo:"></asp:Label></td>
                                        <td align="left" colspan="1" valign="top">
                                            <asp:TextBox ID="txtLegajo" runat="server" Width="96px" AutoPostBack="True" OnTextChanged="txtLegajo_TextChanged"  ></asp:TextBox>
                                        </td>
                                        <td align="left" colspan="1" >
                                            <asp:Label ID="lblNomUsu" runat="server" Width="288px" BackColor="WhiteSmoke"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="1" >
                                            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label></td>
                                        <td align="left" colspan="2" >
                                            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" Width="96px" MaxLength="16"></asp:TextBox></td>
                                    </tr>
                                    <tr align="right">
                                        <td>
                                            </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td >
                                            </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imbAcepLegajo" runat="server" SkinID="ASP_ImgButton-Aceptar" OnClick="imbAcepLegajo_Click"  />&nbsp;
                                            &nbsp; &nbsp;&nbsp;<asp:ImageButton ID="btnCancelLegajo" runat="server" SkinID="ASP_ImgButton-Cancelar" OnClick="btnCancelLegajo_Click"    /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                        <asp:Label ID="lblerrLegajo" runat="server" ForeColor="Maroon"></asp:Label></td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress ID="upprogressLegajo" runat="server">
                            <ProgressTemplate>
                                <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                                <strong style="font-size: small">Procesando datos por favor espere</strong>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" >
                </td>
            </tr>
        </table>
     
    <table>
        <tr>
            <td>
                <asp:Button ID="btnshowpopupmsg" runat="server" CausesValidation="False" Style="display: none" /><cc1:ModalPopupExtender
                    ID="mpemensaje" runat="server" BackgroundCssClass="fondoModal" CancelControlID="btnokmensaje"
                    PopupControlID="pnlmsg" TargetControlID="btnshowpopupmsg">
                </cc1:ModalPopupExtender>
                <br />
                <asp:Panel ID="pnlmsg" runat="server" CssClass="modalPopup" Height="150px" Style="display: none;
                    left: 0px; top: 0px;" Width="400px">
                    <asp:UpdatePanel ID="upmensaje" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="vertical-align: middle; color: white; background-color: green; text-align: left">
                                <strong>Mensaje</strong></div>
                            <br />
                            &nbsp;<asp:Label ID="lblmensaje" runat="server"></asp:Label><br />
                            <br />
                            <asp:Button ID="btnokmensaje" runat="server" CausesValidation="False" 
                                Text="Aceptar" OnClick="btnokmensaje_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
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
</asp:Content>


