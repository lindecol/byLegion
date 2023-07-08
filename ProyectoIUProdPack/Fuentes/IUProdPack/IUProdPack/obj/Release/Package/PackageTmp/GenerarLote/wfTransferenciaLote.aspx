<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="wfTransferenciaLote.aspx.cs" Inherits="IUProdPack.GenerarLote.wfTransferenciaLote" stylesheettheme="Theme_Praxair" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <strong>Lotes Disponibles para Transferir a Distribución<br />
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
                                <tr align="center">
                                    <td colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblLote" runat="server" Text="No. Lote" Width="64px"></asp:Label></td>
                                    <td colspan="1" style="width: 159px">
                                        <asp:TextBox ID="txtLote" runat="server" Width="112px"></asp:TextBox></td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblFchIni" runat="server" Text="Fecha Inicial" Width="88px"></asp:Label></td>
                                    <td colspan="1" style="width: 159px">
                                        <asp:TextBox ID="txtFechaIni" runat="server" MaxLength="10" Width="112px"></asp:TextBox><br />
                                        <cc1:CalendarExtender
                                            ID="ceFechaIni" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtFechaIni"
                                            TargetControlID="txtFechaIni">
                                        </cc1:CalendarExtender>
                                        <cc1:MaskedEditExtender ID="meeFechaIni" runat="server" Mask="99/99/9999" MaskType="Date"
                                            PromptCharacter="_" TargetControlID="txtFechaIni">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditValidator ID="mevFechaIni" runat="server" ControlExtender="meeFechaIni"
                                            ControlToValidate="txtFechaIni" EmptyValueMessage="La Fecha Inicial es requerida"
                                            InvalidValueMessage="Fecha invalida" IsValidEmpty="False" TooltipMessage="seleccione una fecha">
                            </cc1:MaskedEditValidator>&nbsp;
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblFchFinal" runat="server" Text="Fecha Final" Width="88px"></asp:Label></td>
                                    <td align="left" colspan="1" style="width: 159px">
                                        <asp:TextBox ID="txtfecha" runat="server" MaxLength="10" Width="112px"></asp:TextBox><br />
                                        <cc1:CalendarExtender
                                            ID="cefecha" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtfecha" TargetControlID="txtfecha">
                                        </cc1:CalendarExtender>
                                        <cc1:MaskedEditExtender ID="meefecha" runat="server" Mask="99/99/9999" MaskType="Date"
                                            PromptCharacter="_" TargetControlID="txtfecha">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditValidator ID="mevfecha" runat="server" ControlExtender="meefecha"
                                            ControlToValidate="txtfecha" EmptyValueMessage="La fecha es requerida" InvalidValueMessage="Fecha invalida"
                                            IsValidEmpty="False" TooltipMessage="seleccione una fecha">
                            </cc1:MaskedEditValidator></td>
                                </tr>
                                <tr align="left">
                                    <td>
                                    </td>
                                    <td align="left" colspan="1" style="width: 159px">
                                        <asp:ImageButton ID="imbBuscarLotes" runat="server" 
                                            SkinID="ASP_ImgButton-Buscar" OnClick="imbBuscarLotes_Click" /></td>
                                </tr>
                            </table>
                <table>
                    <tr>
                        <td>
                                        <asp:GridView ID="grdLotes" runat="server" AutoGenerateColumns="False" CssClass="Grilla" Width="600px" DataKeyNames="COD_LOTE">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Marcar">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelecLote" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="COD_LOTE" HeaderText="C&#243;d. Lote" HtmlEncode="False"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                                                <asp:BoundField DataField="COD_GAS" HeaderText="C&#243;d. Gas" HtmlEncode="False" />
                                                <asp:BoundField DataField="GAS" HeaderText="Descripci&#243;n" HtmlEncode="False" />
                                                <asp:BoundField DataField="FECHA_LOTE" HeaderText="Fecha Lote" HtmlEncode="False" />
                                                <asp:BoundField DataField="LEGAJO" HeaderText="Legajo" HtmlEncode="False" />
                                                <asp:BoundField DataField="USRDSC" HeaderText="Nombre Usuario" HtmlEncode="False" />
                                            </Columns>
                                        </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                                        <asp:ImageButton ID="imbTransferir" runat="server" SkinID="ASP_ImgButton-Transfer" Visible="False" OnClick="imbTransferir_Click"  />&nbsp;
                                        <asp:ImageButton ID="imbCancelar" runat="server" SkinID="ASP_ImgButton-Cancelar" Visible="False" OnClick="imbCancelar_Click" /></td>
                    </tr>
                </table>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </strong>
    
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




