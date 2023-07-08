<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="wfImpresionEtiquetaLote.aspx.cs" Inherits="IUProdPack.GenerarLote.wfImpresionEtiquetaLote" stylesheettheme="Theme_Praxair" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <strong>Impresión de Etiquetas Lote<br />
        
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
                
    </strong>
    <asp:Label ID="lblmensaje" runat="server"></asp:Label>
               
</asp:Content>
