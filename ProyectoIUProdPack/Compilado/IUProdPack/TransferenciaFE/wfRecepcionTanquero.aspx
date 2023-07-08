<%@ page language="C#" masterpagefile="~/Master.master" autoeventwireup="true" inherits="TransferenciaFE_wfRecepcionTanquero, App_Web_ku2ljam2" title="Recepción Tanquero" stylesheettheme="Theme_Praxair" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><strong>Recepción Tanquero<br />
    <br />
</strong>
    <table style="width: 100%">
        <tr>
                <td style="width: 5%">
                </td>
                <td style="width: 25%; text-align: left">
                    <asp:Label ID="Label3" runat="server" Text="Transacción:" Width="100%"></asp:Label></td>
                <td style="width: 65%">
                    <asp:DropDownList ID="TipoTransac" runat="server" AppendDataBoundItems="True" Width="100%" >
                        <asp:ListItem>...</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 5%">
                </td>
            </tr>
        <tr>
            <td style="width: 5%">
            </td>
            <td style="width: 25%; text-align: left">
                <asp:Label ID="Label2" runat="server" Text="Tanque FS:" Width="100%"></asp:Label></td>
            <td style="width: 65%">
                <asp:DropDownList ID="TanqueDescarga" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                Width="100%" OnSelectedIndexChanged="TanqueDescarga_SelectedIndexChanged">
                    <asp:ListItem>...</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 5%">
                &nbsp;</td>
        </tr>
        <tr>
                <td style="width: 5%">
                </td>
                <td style="width: 25%; text-align: left">
                </td>
                <td style="width: 65%; text-align: left">
                    <asp:Label ID="lblInfoTanqueDescarga" runat="server" Width="100%"></asp:Label></td>
                <td style="width: 5%">
                </td>
            </tr>
        <tr>
            <td style="width: 5%">
            </td>
            <td style="width: 25%; text-align: left">
                <asp:Label ID="Label1" runat="server" Text="Tanqueros:" Width="100%"></asp:Label></td>
            <td style="width: 65%">
                <asp:DropDownList ID="TanqueCarga" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                Width="100%" OnSelectedIndexChanged="TanqueCarga_SelectedIndexChanged">
                    <asp:ListItem>...</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 5%">
                &nbsp;</td>
        </tr>
        <tr>
                <td style="width: 5%; height: 18px">
                </td>
                <td style="width: 25%; height: 18px; text-align: left">
                </td>
                <td style="width: 65%; height: 18px; text-align: left">
                    <asp:Label ID="lblInfoTanqueCarga" runat="server" Width="100%"></asp:Label></td>
                <td style="width: 5%; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 5%">
                </td>
                <td style="width: 25%; text-align: left">
                    <asp:Label ID="Label7" runat="server" Text="Tipo de Entrega:" Width="100%"></asp:Label></td>
                <td style="width: 65%">
                    <asp:DropDownList ID="TipoEntrega" runat="server" AppendDataBoundItems="True" Width="100%" >
                        <asp:ListItem>...</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 5%">
                    </td>
            </tr>
            <tr>
                <td style="width: 5%">
                </td>
                <td style="width: 25%; text-align: left">
                    <asp:Label ID="Label4" runat="server" Text="Pesada Inicial (Kg):" Width="100%"></asp:Label></td>
                <td style="width: 65%; text-align: left">
                    <asp:TextBox ID="PesadaInicial" runat="server" Width="50%"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="ftb1" runat="server" FilterType="Numbers" TargetControlID="PesadaInicial">
                    </cc1:FilteredTextBoxExtender>
                </td>
                <td style="width: 5%">
                </td>
            </tr>
            <tr>
                <td style="width: 5%">
                </td>
                <td style="width: 25%; text-align: left">
                    <asp:Label ID="Label5" runat="server" Text="Pesada Final(Kg):" Width="100%"></asp:Label></td>
                <td style="width: 65%; text-align: left">
                    <asp:TextBox ID="PesadaFinal" runat="server" Width="50%"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="ftb2" runat="server" FilterType="Numbers" TargetControlID="PesadaFinal">
                    </cc1:FilteredTextBoxExtender>
                </td>
                <td style="width: 5%">
                </td>
            </tr>
            <tr>
                <td style="width: 5%">
                </td>
                <td style="width: 25%; text-align: left">
                    <asp:Label ID="Label6" runat="server" Text="Observaciones:" Width="100%"></asp:Label></td>
                <td style="width: 65%; text-align: left">
                    <asp:TextBox ID="Observaciones" runat="server" MaxLength="100" TextMode="MultiLine"
                        Width="100%"></asp:TextBox></td>
                <td style="width: 5%">
                </td>
            </tr>
            <tr>
                <td style="width: 5%">
                </td>
                <td colspan="2" style="text-align: center">
                    <asp:ImageButton ID="imbGuardar" runat="server" OnClick="imbGuardar_Click" SkinID="ASP_ImgButton-Guardar" /></td>
                <td style="width: 5%">
                </td>
            </tr>
    </table>
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
                    &nbsp;
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

