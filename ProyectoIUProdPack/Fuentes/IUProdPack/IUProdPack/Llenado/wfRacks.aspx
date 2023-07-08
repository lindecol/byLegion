<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="wfRacks.aspx.cs" Inherits="IUProdPack.Llenado.wfRacks" stylesheettheme="Theme_Praxair" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
    <strong>Administracion de Racks<br />
        <br />
    </strong>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ImageButton ID="GrabaRack" runat="server"  SkinID="ASP_ImgButton-Adicionar" OnClick="GrabaRack_Click"  /><br />
            <asp:GridView ID="grdResumen" runat="server" AutoGenerateColumns="False" CssClass="Grilla" DataKeyNames="N_NUMRACK,N_ESTADO,C_AGENCI"
            OnRowCommand="grdResumen_OnRowCommand">
                <Columns>
                    <asp:ButtonField ButtonType="Image" CommandName="Actualiza" ImageUrl="~/App_Themes/Theme_Praxair/Image/Botones/Boton_Icono/Boton_Editar.png"
                        Text="Editar" />
                                        
                    <asp:BoundField DataField="N_NUMRACK" HeaderText="Número" /> 
                    <asp:BoundField DataField="D_FECHA" HeaderText="Fecha Creación" />
                    <asp:BoundField DataField="C_USUARIO" HeaderText="Usuario" />
                    <asp:BoundField DataField="N_ESTADO_DESC" HeaderText="Estado" />
                    <asp:BoundField DataField="SCRID_DES" HeaderText="Sucursal" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
     <asp:Panel ID="pnlGrabaSD" runat="server" CssClass="modalPopup" Height="220px" Style="display: none;"
        Width="422px">
        <br />
        <asp:UpdatePanel ID="upCrear" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="width: 100%">
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
                            <asp:Label ID="lblProducto" runat="server" Text="Estado:" Width="100%"></asp:Label></td>
                        <td style="width: 40%">
                            <asp:DropDownList ID="Estado" runat="server" Width="100%" AppendDataBoundItems="True">
                                <asp:ListItem>...</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 40%; text-align: left;">
                             <asp:Label ID="Label1" runat="server" Text="Sucursal:" Width="100%"></asp:Label></td>
                        <td style="width: 40%">
                            <asp:DropDownList ID="Sucursal" runat="server" Width="100%" AppendDataBoundItems="True" Enabled="False">
                                <asp:ListItem>...</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 40%">
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
                            <asp:ImageButton ID="imbGuardar" runat="server" 
                                SkinID="ASP_ImgButton-Guardar" OnClick="imbGuardar_Click"  /></td>
                        <td style="width: 40%">
                            <asp:ImageButton ID="imbCancelar" runat="server" 
                                SkinID="ASP_ImgButton-Cancelar" OnClick="imbCancelar_Click" /></td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%; height: 18px;">
                        </td>
                        <td style="width: 40%; height: 18px;">
                        </td>
                        <td style="width: 40%; height: 18px;">
                        </td>
                        <td style="width: 10%; height: 18px;">
                        </td>
                    </tr>
                </table>
                <br />
                <asp:HiddenField ID="snInserta" runat="server" />
                <asp:HiddenField ID="N_NUMRACK" runat="server" /><asp:UpdateProgress ID="upprogressGral2" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                        <strong style="font-size: small">Procesando datos por favor espere</strong>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </asp:Panel>
    <asp:Button ID="btnDocDig" runat="server" BackColor="White" BorderStyle="None" BorderWidth="0px" Height="8px" Width="1px" /><br />
    <cc1:ModalPopupExtender ID="PopUpDocDig" runat="server" BackgroundCssClass="fondoModal"
        DropShadow="false" PopupControlID="pnlGrabaSD" TargetControlID="btnDocDig" Y="100">
    </cc1:ModalPopupExtender>
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
</asp:Content>


