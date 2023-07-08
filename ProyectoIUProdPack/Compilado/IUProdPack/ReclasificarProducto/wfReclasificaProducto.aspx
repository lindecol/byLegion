<%@ page language="C#" masterpagefile="~/Master.master" autoeventwireup="true" inherits="ReclasificarProducto_wfReclasificaProducto, App_Web_dwtn5qr5" title="Reclasificar" stylesheettheme="Theme_Praxair" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <strong>Reclasificar Producto<br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
    
    <table style="width: 100%" id="TABLE1">
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
                        <td style="width: 30%; text-align: left">
                            <asp:Label ID="lblProducto" runat="server" Text="Seleccione un producto:" Width="100%"></asp:Label></td>
                        <td style="width: 50%">
                            <asp:DropDownList ID="Productos" runat="server" AppendDataBoundItems="True" 
                                 Width="100%">
                                <asp:ListItem>...</asp:ListItem>
                            </asp:DropDownList></td>
                            </td>
                        <td style="width: 10%">
                        </td>
                    </tr>                                                        
                    <tr>
                         <td style="width: 10%">
                        </td>
                        <td style="width: 40%; text-align: left">
                            <asp:Label ID="lblLote" runat="server" Text="No. Lote"></asp:Label>                            
                        </td>
                        <td style="width: 40%; text-align: left">
                                        <asp:TextBox ID="txtLote" runat="server" Width="112px"></asp:TextBox>                                        
                        </td>
                        <td style="width: 10%">
                        </td>
                    </tr>

                     <tr>
                         <td style="width: 10%">
                        </td>
                        <td colspan="2">
                                        <asp:ImageButton ID="ImageButton1" runat="server" SkinID="ASP_ImgButton-Buscar" 
                                            onclick="ImageButton1_Click"  />
                        <td style="width: 10%">
                        </td>
                    </tr>

                     <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 30%; text-align: left">
                            <asp:Label ID="Label1" runat="server" Text="Seleccione el producto a reclasificar:" Width="100%"></asp:Label></td>
                        <td style="width: 50%">
                             <asp:DropDownList ID="ProductosReclasificar" runat="server" AppendDataBoundItems="True"
                                 Width="100%">
                                <asp:ListItem>...</asp:ListItem>
                            </asp:DropDownList></td>
                            </td>
                        <td style="width: 10%">
                        </td>
                    </tr>
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
                            <asp:GridView ID="grdSeriales" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                CssClass="Grilla" DataKeyNames="SERIAL,ETIQUETA,ID_EVALUACION,CUMPLIO"
                                EmptyDataText="No existen seriales para reclasificar"  
                                OnRowCommand ="grdSeriales_OnRowCommand" 
                                onrowdatabound="grdSeriales_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="SERIAL" HeaderText="Serial" />
                                     <asp:BoundField DataField="ETIQUETA" HeaderText="Etiqueta" />
                                    <asp:BoundField DataField="CUMPLIO" HeaderText="Cumplio" />
                                     <asp:ButtonField ButtonType="Image" CommandName="Detalle" ImageUrl="~/App_Themes/Theme_Praxair/Image/Botones/Boton_Icono/Boton_Buscar.png"
                        Text="Detalle" />
       

                                
                                    <asp:TemplateField HeaderText="Reclasificar">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkReflasificar" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>                                   
                                    <asp:TemplateField HeaderText="Ventear">
                                         <ItemTemplate>
                                            <asp:CheckBox ID="chkVentear" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
       

                                
                                </Columns>
                            </asp:GridView>
                            </td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%; height: 18px;">
                        </td>
                        <td style="height: 18px;" colspan="2">
                            <asp:ImageButton ID="imbGuardar" runat="server" OnClick="imbGuardar_Click" 
                                SkinID="ASP_ImgButton-Guardar" Enabled="False" /></td>
                        <td style="width: 10%; height: 18px;">
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </strong>
    <br />
    
    <asp:Panel ID="pnlDetalle" runat="server" CssClass="modalPopup" Height="250px" Style="display: none" Width="534px" ScrollBars="Vertical"  >
        <br />
    
    <asp:UpdatePanel ID="upDetalle" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            &nbsp;<asp:ImageButton ID="imbCancelar" runat="server" OnClick="imbCancelar_Click"
                SkinID="ASP_ImgIcon-Cancelar" /><asp:GridView ID="grdDetalle" runat="server" AutoGenerateColumns="False" CssClass="Grilla"  >
    <Columns>        
        <asp:BoundField DataField="DESCRIPCION" HeaderText="Validación" />
        <asp:BoundField DataField="RESPUESTA" HeaderText="Detalle" />
        <asp:BoundField DataField="SN_CUMPLE" HeaderText="Cumple" />
        <asp:BoundField DataField="SN_OBLIGA" HeaderText="Obligatoria" />        
    </Columns>
</asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress5" runat="server">
        <ProgressTemplate>
            <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
            <strong style="font-size: small">Procesando datos por favor espere</strong>
        </ProgressTemplate>
    </asp:UpdateProgress>
    &nbsp;</asp:Panel>
    
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
    <asp:Button ID="btnDocDigDetalle" runat="server" BackColor="White" BorderStyle="None" BorderWidth="0px" Height="8px" Width="1px" />
    <cc1:ModalPopupExtender ID="PopUpDetalle" runat="server" BackgroundCssClass="fondoModal"
        DropShadow="false" PopupControlID="pnlDetalle" TargetControlID="btnDocDigDetalle" Y="100"></cc1:ModalPopupExtender>
</asp:Content>

