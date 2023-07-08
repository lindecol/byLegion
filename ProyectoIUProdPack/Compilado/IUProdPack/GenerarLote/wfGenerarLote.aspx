<%@ page language="C#" masterpagefile="~/Master.master" autoeventwireup="true" inherits="GenerarLote_wfGenerarLote, App_Web_mb2mcfam" title="Generación de Lote" stylesheettheme="Theme_Praxair" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <strong>Generación de Lote<br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                &nbsp;<table>
                    <tr>
                        <td colspan="2">
                            <table>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblSubdepósito" runat="server" Text="Subdepósito Producción" Width="144px"></asp:Label></td>
                                    <td colspan="1">
                                        <asp:DropDownList ID="cboSubdeposito" runat="server" Width="169px">
                                        </asp:DropDownList></td>
                                    <td colspan="1">
                                     <asp:Label ID="lblFechaClasifi" runat="server" Text="Fecha Clasificación"></asp:Label>
                                     <asp:TextBox ID="txtfecha" runat="server" MaxLength="10" Width="96px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblGas" runat="server" Text="Gas"></asp:Label></td>
                                    <td colspan="1">
                                        <asp:DropDownList ID="cboGas" runat="server" Width="250px" AutoPostBack="True" 
                                            OnSelectedIndexChanged="cboGas_SelectedIndexChanged">
                                        </asp:DropDownList>                                        
                                        </td>
                                    <td colspan="1">
                                        <asp:ImageButton ID="imbComposicion" runat="server" SkinID="ASP_ImgButton-Compo"
                                            OnClick="imbComposicion_Click" /></td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblTipGas" runat="server" Text="Tipo Gas" Width="48px"></asp:Label>
                                        
                                        </td>
                                    <td>
                                        <asp:DropDownList ID="cboTipGas" runat="server" Width="104px" AutoPostBack="True"
                                            OnSelectedIndexChanged="cboTipGas_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        </td>
                                    <td>
                                        <asp:Label ID="lblClasificador" runat="server" Text="Clasificador"></asp:Label>
                                        <asp:DropDownList ID="cboClasificador" runat="server" Width="168px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>                                
                                <tr align="left">
                                    <td>
                                        <asp:Panel ID="pnStockeable" runat="server" Visible="False">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblstockeable" runat="server" Text="Stockeables"></asp:Label>
                                                        <asp:Label ID="lblUnidad" runat="server" Width="56px"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblCantaLotear" runat="server" Text="Cantidad a Lotear" Width="72px"></asp:Label>
                                                        <asp:TextBox ID="txtCantLote" runat="server" MaxLength="3" Width="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <cc1:MaskedEditExtender ID="meeClote" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                            Mask="999" MaskType="number" TargetControlID="txtCantLote">
                                                        </cc1:MaskedEditExtender>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                    <td colspan="1" align="left">
                                        <cc1:CalendarExtender ID="cefecha" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtfecha"
                                            TargetControlID="txtfecha">
                                        </cc1:CalendarExtender>
                                        <cc1:MaskedEditExtender ID="meefecha" runat="server" Mask="99/99/9999" MaskType="Date"
                                            PromptCharacter="_" TargetControlID="txtfecha">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditValidator ID="mevfecha" runat="server" ControlExtender="meefecha"
                                            ControlToValidate="txtfecha" EmptyValueMessage="La fecha es requerida" InvalidValueMessage="Fecha invalida"
                                            IsValidEmpty="False" TooltipMessage="seleccione una fecha">
                                        </cc1:MaskedEditValidator><cc1:MaskedEditExtender ID="meeCargaIni" runat="server"
                                            Mask="999999.999" MaskType="number" TargetControlID="txtCargaIni" Enabled="False">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTipoCx" runat="server" Text="Tipo Recipiente Llenado" Width="40px"
                                            Visible="False"></asp:Label>
                                        <asp:Label ID="lblPropiedad" runat="server" Text="Propiedad" Visible="False"></asp:Label>
                                        <asp:Label ID="lblTermo" runat="server" Text="Termo" Width="40px" Visible="False"></asp:Label>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:RadioButton ID="rdbCilindro" runat="server" Text="Cilindro" OnCheckedChanged="rdbCilindro_CheckedChanged"
                                                        AutoPostBack="True" GroupName="llenado" Visible="False" /></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RadioButton ID="rdbTermo" runat="server" Text="Termo" OnCheckedChanged="rdbTermo_CheckedChanged"
                                                        AutoPostBack="True" GroupName="llenado" Visible="False" /></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RadioButton ID="rdbStockeables" runat="server" Text="Stockeables" OnCheckedChanged="rdbStockeables_CheckedChanged"
                                                        AutoPostBack="True" GroupName="llenado" Visible="False" /></td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="lblcargaini" runat="server" Text="Carga Inicial" Width="72px" Visible="False"></asp:Label>
                                        <asp:DropDownList ID="cboTermo" runat="server" Width="72px" AutoPostBack="True" OnSelectedIndexChanged="cboTermo_SelectedIndexChanged"
                                            Visible="False">
                                        </asp:DropDownList>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:RadioButton ID="rdbPx" runat="server" Text="Px." Width="48px" OnCheckedChanged="rdbPx_CheckedChanged"
                                                        GroupName="propiedad" Checked="True" Visible="False" /></td>
                                                <td>
                                                    <asp:RadioButton ID="rdbPart" runat="server" Text="Part." OnCheckedChanged="rdbPart_CheckedChanged"
                                                        AutoPostBack="True" GroupName="propiedad" Visible="False" /></td>
                                            </tr>
                                        </table>
                                        <asp:TextBox ID="txtCargaIni" runat="server" Width="80px" MaxLength="10" Visible="False">0</asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnCx" runat="server" Width="600px" BorderColor="White">
                                <table>
                                    <tr align="left">
                                        <td colspan="4">
                            <asp:Panel ID="PnLote" runat="server" Width="600px" BorderColor="White">
                                <table>
                                    <tr>
                                        <td colspan="6">
                                            <asp:Label ID="lblDetLote" runat="server" Text="Detalle del Lote" Width="248px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2">
                                            <asp:Label ID="lblVacio" runat="server" Text="1° Vacío" Width="64px" Height="32px"
                                                BackColor="#E0E0E0"></asp:Label></td>
                                        <td colspan="2">
                                            <asp:Label ID="lblBomba" runat="server" Text="Bomba" Width="208px" BackColor="#E0E0E0"></asp:Label></td>
                                        <td rowspan="2" style="width: 131px">
                                            <asp:Label ID="lblRack" runat="server" Text="Rack" Height="32px" Width="144px" BackColor="#E0E0E0"></asp:Label></td>
                                        <td colspan="2">
                                            <asp:Label ID="lblFinal" runat="server" Text="Final" Width="152px" BackColor="#E0E0E0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblHoraIni" runat="server" Text="Hora Inicio" Width="100px" BackColor="#E0E0E0"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblHoraFin" runat="server" Text="Hora Final" Width="100px" BackColor="#E0E0E0"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblPresion" runat="server" Text="Presión" Width="64px" BackColor="#E0E0E0"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblTemp" runat="server" Text="Temperatura" Width="80px" BackColor="#E0E0E0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtVacio" runat="server" SkinID="ASP_Label-Texto" Width="64px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txthoraIni" runat="server" MaxLength="5" Width="96px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtHoraFin" runat="server" MaxLength="5" Width="96px"></asp:TextBox></td>
                                        <td style="width: 131px">
                                            <asp:DropDownList ID="cboRack" runat="server" Width="144px">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox ID="txtPresion" runat="server" MaxLength="4" Width="57px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtTemp" runat="server" MaxLength="4" Width="73px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            &nbsp;
                                            <cc1:MaskedEditExtender ID="meehoraIni" runat="server" Mask="99:99" MaskType="Time"
                                                TargetControlID="txthoraIni">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditExtender ID="meehoraFin" runat="server" Mask="99:99" MaskType="Time"
                                                TargetControlID="txtHoraFin">
                                            </cc1:MaskedEditExtender>
                                        </td>
                                        <td colspan="3">
                                            <cc1:MaskedEditExtender ID="meePres" runat="server" Mask="9999" MaskType="number"
                                                AutoComplete="False" AutoCompleteValue="false" TargetControlID="txtPresion">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditExtender ID="meeTem" runat="server" Mask="99.9" MaskType="number"
                                                TargetControlID="txtTemp">
                                            </cc1:MaskedEditExtender>
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="lblcapacidad" runat="server" Text="Capacidad" Visible="False"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtcapacidad" runat="server" Width="72px" MaxLength="5" Visible="False"></asp:TextBox>
                                            <asp:ImageButton ID="imbAgregarCap" runat="server" SkinID="ASP_ImgIcon-Adicionar"
                                                OnClick="imbAgregarCap_Click" Visible="False" /></td>
                                        <td colspan="2">
                                            <cc1:MaskedEditExtender ID="meeCapaciadNew" runat="server" Mask="999.9" MaskType="number"
                                                TargetControlID="txtcapacidad">
                                            </cc1:MaskedEditExtender>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td colspan="4">
                                            <asp:GridView ID="grdDetCx" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CssClass="Grilla" EmptyDataText="No existen registros para los parametros de consulta"
                                                OnRowDataBound="grdDetCx_RowDataBound" OnRowCommand="grdDetCx_RowCommand" Width="560px"
                                                DataKeyNames="CAPACIDAD">
                                                <Columns>
                                                    <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" HtmlEncode="False" />
                                                    <asp:TemplateField HeaderText="Cil. PRAXAIR">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtcilpraxair" runat="server" MaxLength="3" Width="50px" AutoPostBack="True" OnTextChanged="txtcilpraxair_TextChanged"></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="meecilpraxair" runat="server" Mask="999" MaskType="number"
                                                                AutoComplete="False" AutoCompleteValue="false" TargetControlID="txtcilpraxair">
                                                            </cc1:MaskedEditExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cil. Particulares">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtcilpart" runat="server" MaxLength="3" Width="50px" AutoPostBack="True" OnTextChanged="txtcilpart_TextChanged"></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="meecilpart" runat="server" Mask="999" MaskType="number"
                                                                AutoComplete="False" AutoCompleteValue="false" TargetControlID="txtcilpart">
                                                            </cc1:MaskedEditExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cil.c/ p&#233;rd.Sellos">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtcilsellos" runat="server" MaxLength="3" Width="50px" AutoPostBack="True" OnTextChanged="txtcilsellos_TextChanged"></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="meecilsellos" runat="server" Mask="999" MaskType="number"
                                                                AutoComplete="False" AutoCompleteValue="false" TargetControlID="txtcilsellos">
                                                            </cc1:MaskedEditExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cil. Rechazados">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtcilrechazo" runat="server" MaxLength="3" Width="50px" AutoPostBack="True" OnTextChanged="txtcilrechazo_TextChanged"></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="meecilrechazo" runat="server" Mask="999" MaskType="number"
                                                                AutoComplete="False" AutoCompleteValue="false" TargetControlID="txtcilrechazo">
                                                            </cc1:MaskedEditExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:ImageButton ID="imbCalcular" runat="server" SkinID="ASP_ImgButton-calcular"
                                                OnClick="imbCalcular_Click" Visible="False" /></td>
                                        <td colspan="1">
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalCx" runat="server" Text="Total Cilindros" Width="120px"></asp:Label></td>
                                        <td >
                                            <asp:Label ID="lblTotVolumensum" runat="server" Text="Total Volumen" Width="120px"></asp:Label></td>
                                        <td align="right" rowspan="9">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="imbAnalisisGM" runat="server" SkinID="ASP_ImgButton-AnalisisGM"
                                                            OnClick="imbAnalisisGM_Click" /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="imbLastroInsumos" runat="server" SkinID="ASP_ImgButton-lastro"
                                                            OnClick="imbLastroInsumos_Click" /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="imbParticulares" runat="server" SkinID="ASP_ImgButton-Pariculares"
                                                            OnClick="imbParticulares_Click" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 36px">
                                                        <asp:ImageButton ID="imbGuardarLote" runat="server" SkinID="ASP_ImgButton-GuardarLote"
                                                            OnClick="imbGuardarLote_Click" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="lblTotCliPraxair" runat="server" Text="Cil. PRAXAIR"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblSumCilPraxair" runat="server" SkinID="ASP_Label-Texto"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lbSumVolPrax" runat="server" SkinID="ASP_Label-Texto"></asp:Label></td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="lblTotPart" runat="server" Text="Cil. Particulares"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblSumCilPart" runat="server" SkinID="ASP_Label-Texto"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblSumVolPar" runat="server" SkinID="ASP_Label-Texto"></asp:Label></td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="lblTotSellos" runat="server" Text="Cil.c/Pérd.Sellos"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblSumCilSellos" runat="server" SkinID="ASP_Label-Texto"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblSumVolSellos" runat="server" SkinID="ASP_Label-Texto"></asp:Label></td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="lblTotRechazo" runat="server" Text="Cil. Rechazados"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblSumCilRechaz" runat="server" SkinID="ASP_Label-Texto"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblSumVolRechaz" runat="server" SkinID="ASP_Label-Texto"></asp:Label></td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="lbltotal" runat="server" Text="Totales Lote"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblSumTotalCx" runat="server" SkinID="ASP_Label-Texto" Width="96px"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblSumTotalVol" runat="server" SkinID="ASP_Label-Texto"></asp:Label></td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td colspan="3">
                            <table>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblTurno" runat="server" Text="Turno"></asp:Label></td>
                                    <td style="color: #000000">
                                        <asp:Label ID="lblNumTurno" runat="server" SkinID="ASP_Label-Texto" Width="30px"
                                            BackColor="Green" ForeColor="White"></asp:Label></td>
                                    <td>
                                        <asp:CheckBox ID="chkNoDescuenta" runat="server" Text="No Descuenta" Width="128px"
                                            Font-Size="X-Small" OnCheckedChanged="chkNoDescuenta_CheckedChanged" AutoPostBack="True"
                                            Enabled="False" /></td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:CheckBox ID="chkControlBasc" runat="server" Text="Control Báscula" Width="128px"
                                            Font-Size="X-Small" /></td>
                                    <td>
                                        <asp:Label ID="lblEspecificaciones" runat="server" Text="Especificaciones"></asp:Label></td>
                                    <td>
                                        <asp:RadioButton ID="rdbCumple" runat="server" Text="Cumple" Width="64px" 
                                            GroupName="especificacion" Height="20px" />
                                        <asp:RadioButton ID="rdbNoCumple" runat="server" Text="No Cumple" Width="88px" 
                                            GroupName="especificacion" /></td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblPrecintos" runat="server" Text="Precintos Rotos" Width="104px"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblEtiquetas" runat="server" Text="Etiquetas Rotas" Width="96px"></asp:Label></td>
                                    <td>
                                        </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:TextBox ID="txtPrecintos" runat="server" MaxLength="3" Width="120px"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtEtiquetas" runat="server" Width="120px" MaxLength="3"></asp:TextBox></td>
                                    <td>
                                        </td>
                                </tr>
                                <tr align="left">
                                    <td colspan="2">
                                        <cc1:MaskedEditExtender ID="meePrecintos" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                            Mask="999" MaskType="number" TargetControlID="txtPrecintos">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditExtender ID="meeEtiquetas" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                            Mask="999" MaskType="number" TargetControlID="txtEtiquetas">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnAnalisis" runat="server" Visible="False">
                                <table>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Análisis"></asp:Label></td>
                                        <td>
                                            <asp:CheckBox ID="chkTest" runat="server" Text="Test Olor" Width="80px" Font-Size="X-Small" /></td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblHumedad" runat="server" Text="Humedad (PPM)<" Width="112px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtHumedad" runat="server" Width="30px" ToolTip="Humedad" MaxLength="1"></asp:TextBox></td>
                                        <td>
                                            <cc1:MaskedEditExtender ID="meeHume" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                Mask="9" MaskType="number" TargetControlID="txtHumedad">
                                            </cc1:MaskedEditExtender>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="lblPureza" runat="server" Text="Pureza" Width="112px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtPureza" runat="server" MaxLength="3" Width="30px" ToolTip="Pureza"></asp:TextBox>%</td>
                                        <td>
                                            <cc1:MaskedEditExtender ID="meePureza" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                Mask="999" MaskType="number" TargetControlID="txtPureza">
                                            </cc1:MaskedEditExtender>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNh3" runat="server" Text="NH3 (PPM)<" Width="72px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtNh3" runat="server" Width="30px" ToolTip="Amoníaco" MaxLength="1"></asp:TextBox></td>
                                        <td>
                                            <cc1:MaskedEditExtender ID="meeNH3" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                Mask="9" MaskType="number" TargetControlID="txtNh3">
                                            </cc1:MaskedEditExtender>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="lblCO" runat="server" Text="CO (PPM)<" Width="112px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtCo" runat="server" Width="30px" ToolTip="Monóxido de Carbono"
                                                MaxLength="1"></asp:TextBox></td>
                                        <td>
                                            <cc1:MaskedEditExtender ID="meeCO" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                Mask="9" MaskType="number" TargetControlID="txtCo">
                                            </cc1:MaskedEditExtender>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSo2" runat="server" Text="SO2 (PPM)<" Width="72px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtSo2" runat="server" Width="30px" ToolTip="Dióxido de Azufre"
                                                MaxLength="1"></asp:TextBox></td>
                                        <td>
                                            <cc1:MaskedEditExtender ID="meeSO2" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                Mask="9" MaskType="number" TargetControlID="txtSo2">
                                            </cc1:MaskedEditExtender>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="lblCO2" runat="server" Text="CO2 (PPM)<" Width="80px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtCO2" runat="server" Width="30px" ToolTip="Dióxido de Carbono"
                                                MaxLength="1"></asp:TextBox></td>
                                        <td>
                                            <cc1:MaskedEditExtender ID="meeco2" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                Mask="9" MaskType="number" TargetControlID="txtCO2">
                                            </cc1:MaskedEditExtender>
                                        </td>
                                        <td>
                                            &nbsp;<asp:Label ID="lblNo" runat="server" Text="NO (PPM)<" Width="72px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtNo" runat="server" Width="30px" ToolTip="Oxidos de Nitrógeno"
                                                MaxLength="1"></asp:TextBox></td>
                                        <td>
                                            <cc1:MaskedEditExtender ID="meeNo" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                Mask="9" MaskType="number" TargetControlID="txtNo">
                                            </cc1:MaskedEditExtender>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="lblHal" runat="server" Text="Halóg. (PPM)<" Width="96px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtHal" runat="server" Width="30px" ToolTip="Halógenos" MaxLength="1"></asp:TextBox></td>
                                        <td>
                                            <cc1:MaskedEditExtender ID="meeHal" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                Mask="9" MaskType="number" TargetControlID="txtHal">
                                            </cc1:MaskedEditExtender>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblH2S" runat="server" Text="H2S (PPM)<" Width="72px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtH2s" runat="server" Width="30px" ToolTip="Acido Sulfhídrico"
                                                MaxLength="1"></asp:TextBox></td>
                                        <td>
                                            <cc1:MaskedEditExtender ID="meeH2s" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                Mask="9" MaskType="number" TargetControlID="txtH2s">
                                            </cc1:MaskedEditExtender>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td rowspan="1">
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </strong>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Button Style="display: none" ID="btnpopupComposicion" runat="server"></asp:Button>
                <cc1:ModalPopupExtender ID="mpepopupComposicion" runat="server" PopupControlID="pnlpopupComposicion"
                    BackgroundCssClass="fondoModal" TargetControlID="btnpopupComposicion" CancelControlID="imbAceptarComp">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlpopupComposicion" runat="server" Width="700px" Height="500px" Style="display: none;
                    left: 0px; top: 3%;" CssClass="modalPopup">
                    <asp:UpdatePanel ID="upopupComposicion" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblCompos" runat="server" BackColor="Green" Font-Size="Small" ForeColor="White"
                                            Text="Composición" Width="100%"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblPrdLote" runat="server" Text="Producto a  Lotear" Width="24%"></asp:Label></td>
                                    <td align="left" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblProducto" runat="server"></asp:Label></td>
                                    <td align="left" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblComposicion" runat="server" Text="Composición por Tanque" Width="144px"></asp:Label><asp:Label
                                            ID="lblNousa" runat="server" ForeColor="Red" Text="(No usa Tanque)" Visible="False"></asp:Label></td>
                                    <td align="left" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <asp:GridView ID="grdCompTanque" runat="server" AutoGenerateColumns="False" CssClass="Grilla"
                                            DataKeyNames="codProducto,Subdeposito,codTanque,SCRID,PRODUCTO" Width="632px">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkCompTanque" runat="server" Checked="True" Enabled="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="CodProducto" HeaderText="C&#243;d. Producto" HtmlEncode="False">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Producto" HeaderText="Des. Producto" HtmlEncode="False" />
                                                <asp:BoundField DataField="Porcentaje" HeaderText="%" HtmlEncode="False" />
                                                <asp:BoundField DataField="Subdeposito" HeaderText="Subdep&#243;sito" HtmlEncode="False" />
                                                <asp:BoundField DataField="codtanque" HeaderText="C&#243;d. Tanque" HtmlEncode="False" />
                                                <asp:BoundField DataField="NomTanque" HeaderText="Des. Tanque" HtmlEncode="False" />
                                                <asp:BoundField DataField="stock" HeaderText="Stock Actual" HtmlEncode="False" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left" style="height: 7px" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblinsumos" runat="server" Text="Insumos"></asp:Label></td>
                                    <td align="left" valign="top" style="height: 7px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <asp:GridView ID="grdInsumos" runat="server" AutoGenerateColumns="False" CssClass="Grilla"
                                            DataKeyNames="ARTIDNUM,ARTID,ESETIQUETA,ESGAS,Cuenta,Tabla,Analitico,PORCENTAJE,FACTOR_CONVERSION,CANT_COMP"
                                            Width="650px">
                                            <Columns>
                                                <asp:BoundField DataField="ARTID" HeaderText="C&#243;digo" HtmlEncode="False" />
                                                <asp:BoundField DataField="ARTDSCCORTA" HeaderText="Des. Insumo" HtmlEncode="False" />
                                                <asp:BoundField DataField="CANT_COMP" HeaderText="Cant. x U." HtmlEncode="False" />
                                                <asp:BoundField DataField="UM" HeaderText="UM" HtmlEncode="False" />
                                                <asp:TemplateField HeaderText="Etiq.">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkEtiqueta" runat="server" Enabled="False" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Gas">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkGas" runat="server" Enabled="False" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Cant.Insumida Loteo" HtmlEncode="False" />
                                                <asp:TemplateField HeaderText="Cant.Extra">
                                                    <ItemTemplate>
                                                        <table>
                                                            <tr>
                                                                <td style="width: 3px">
                                                                    <asp:TextBox ID="txtCantExtra" runat="server" MaxLength="4" Width="50px" AutoPostBack="True"
                                                                        OnTextChanged="txtCantExtra_TextChanged"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="1">
                                                                    <cc1:MaskedEditExtender ID="meeCantExtra" runat="server" Mask="9999" MaskType="number"
                                                                        AutoComplete="False" AutoCompleteValue="false" TargetControlID="txtCantExtra" AcceptNegative="Left">
                                                                    </cc1:MaskedEditExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Cant. Total" HtmlEncode="False" />
                                                <asp:BoundField HeaderText="Stock Actual" HtmlEncode="False" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblCantidad" runat="server" ForeColor="Red" Text="(Cant. Extra: Ingresar los insumos utilizados de más )"
                                            Visible="False"></asp:Label></td>
                                    <td align="left" style="width: 205px" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:CheckBox ID="chkReemplazo" runat="server" Font-Bold="True" Font-Size="X-Small"
                                            Text="Producto Reemplazo" AutoPostBack="True" OnCheckedChanged="chkReemplazo_CheckedChanged" /></td>
                                    <td align="left" style="width: 205px" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left" style="width: 205px" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;<asp:ImageButton ID="imbAceptarComp" runat="server" SkinID="ASP_ImgButton-Aceptar"
                                            OnClick="imbAceptarComp_Click" ValidationGroup="AceptarComposicion" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;<asp:Label ID="lblErrorComposicion" runat="server" ForeColor="Maroon"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="upprogressComposicion" runat="server">
                        <ProgressTemplate>
                            <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                            <strong style="font-size: small">Procesando datos por favor espere</strong>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Button Style="display: none" ID="btnpopupAnalisisGM" runat="server"></asp:Button>
                <cc1:ModalPopupExtender ID="mpepopupAnalisisGM" runat="server" PopupControlID="pnlpopupAnalisis"
                    BackgroundCssClass="fondoModal" TargetControlID="btnpopupAnalisisGM" CancelControlID="imbCerrar">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlpopupAnalisis" runat="server" Width="700px" Height="400px" Style="display: none;
                    left: 0px; top: 3%;" CssClass="modalPopup">
                    <asp:UpdatePanel ID="upopupAnalisisGM" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lblAnalisis" runat="server" Text="Carga valores para Análisis GM"
                                            Width="100%" BackColor="Green" Font-Size="Small" ForeColor="White"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left" colspan="3" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblPrd" runat="server" Text="Producto Loteado:" Width="120px"></asp:Label></td>
                                    <td align="left" valign="top" colspan="3">
                                        <asp:Label ID="lblProductoLoteado" runat="server" Width="500px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left" valign="top">
                                    </td>
                                    <td align="left" valign="top">
                                    </td>
                                    <td align="left" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4">
                                        <asp:GridView ID="grvAnalisisGm" runat="server" AutoGenerateColumns="False" CssClass="Grilla"
                                            DataKeyNames="VALOR_DESDE,VALOR_HASTA,DESCRIPCION_TIPO,ID_TIPO,ID_ESTADO,DESCRIPCION_ESTADO,UNIDAD_MEDIDA"
                                            Width="648px">
                                            <Columns>
                                                <asp:BoundField HeaderText="Tipo An&#225;lisis" HtmlEncode="False">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Estado" HtmlEncode="False" />
                                                <asp:BoundField DataField="UNIDAD_MEDIDA" HeaderText="U.M" HtmlEncode="False" />
                                                <asp:TemplateField HeaderText="Valores">
                                                    <ItemTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtValNum" runat="server" Visible="False" Width="60px" MaxLength="5"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <cc1:MaskedEditExtender ID="meeTxtValNum" runat="server" Mask="99.9" MaskType="number"
                                                                        TargetControlID="txtValNum">
                                                                    </cc1:MaskedEditExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Obligatorio" HeaderText="Obligatorio" HtmlEncode="False" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkPosee" runat="server" OnCheckedChanged="chkPosee_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Desde" HtmlEncode="False" />
                                                <asp:BoundField HeaderText="Hasta" HtmlEncode="False" />
                                                <asp:BoundField DataField="CANTIDAD_DECIMALES" HeaderText="Decimales" HtmlEncode="False" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblObserv" runat="server" Text="Observaciones"></asp:Label></td>
                                    <td align="left" style="height: 7px" valign="top" colspan="3">
                                        <asp:TextBox ID="txtObservaciones" runat="server" Height="50px" TextMode="MultiLine"
                                            Width="496px" MaxLength="600"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblRespTecnico" runat="server" Text="Responsable Técnico:" Width="136px"></asp:Label></td>
                                    <td align="left" valign="top" colspan="3">
                                        <asp:TextBox ID="txtRespTecnico" runat="server" Width="496px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblNoCx" runat="server" Text="N° de Cilindro Analizado:" Width="144px"></asp:Label></td>
                                    <td align="left" style="width: 205px" valign="top">
                                        <asp:TextBox ID="txtNroCilindro" runat="server" MaxLength="10" Width="80px"></asp:TextBox></td>
                                    <td align="left" style="width: 205px" valign="top">
                                        <asp:Label ID="lblNumAnalisis" runat="server" Text="N° de Análisis :"></asp:Label></td>
                                    <td align="left" style="width: 205px" valign="top">
                                        <asp:TextBox ID="txtNroAnalisis" runat="server" MaxLength="10" Width="80px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="top" colspan="2">
                                        &nbsp;<cc1:MaskedEditExtender ID="meeNumAnl" runat="server" Mask="9999999999" AutoComplete="False"
                                            AutoCompleteValue="false" MaskType="number" TargetControlID="txtNroAnalisis">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left" style="width: 205px" valign="top">
                                        <asp:ImageButton ID="imbMarcarTodo" runat="server" SkinID="ASP_ImgButton-Marcar"
                                            OnClick="imbMarcarTodo_Click" />
                                        <asp:ImageButton ID="imbDesmarcar" runat="server" OnClick="imbDesmarcar_Click" SkinID="ASP_ImgButton-DesMarcar" /></td>
                                    <td align="left" style="width: 205px" valign="top">
                                        <asp:ImageButton ID="imbCerrar" runat="server" SkinID="ASP_ImgButton-cerrar" OnClick="imbCerrar_Click" /></td>
                                    <td align="left" style="width: 205px" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left" style="width: 205px" valign="top">
                                    </td>
                                    <td align="left" style="width: 205px" valign="top">
                                    </td>
                                    <td align="left" style="width: 205px" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        &nbsp;<asp:Label ID="lblErrorAnalisis" runat="server" ForeColor="Maroon"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="upprogressAnalisis" runat="server">
                        <ProgressTemplate>
                            <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                            <strong style="font-size: small">Procesando datos por favor espere</strong>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Button Style="display: none" ID="btnpopupLastro" runat="server"></asp:Button>
                <cc1:ModalPopupExtender ID="mpepopupLastro" runat="server" PopupControlID="pnlpopupLastro"
                    BackgroundCssClass="fondoModal" TargetControlID="btnpopupLastro" CancelControlID="imbCerrarLastro">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlpopupLastro" runat="server" Width="700px" Height="300px" Style="display: none;
                    left: 0px; top: 3%;" CssClass="modalPopup">
                    <asp:UpdatePanel ID="upopupLastro" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td colspan="1">
                                        <asp:Label ID="lbltitlastro" runat="server" Text="Lastro Insumos(Propia Producción)"
                                            Width="100%" BackColor="Green" Font-Size="Small" ForeColor="White"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <asp:GridView ID="grvLastroIns" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros para los parametros de consulta"
                                            CssClass="Grilla" DataKeyNames="STKCODI_PRO" Width="648px" Caption="<b>Detalle Lastro Insumos</b>">
                                            <Columns>
                                                <asp:BoundField HeaderText="Art&#237;culo" HtmlEncode="False" DataField="articulo">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Capacidad" HtmlEncode="False" DataField="STKCAPA_PRO" />
                                                <asp:BoundField HeaderText="Saldo Actual" HtmlEncode="False" DataField="STKUNIDAD" />
                                                <asp:TemplateField HeaderText="Vacios">
                                                    <ItemTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtVacios" runat="server" Width="60px" MaxLength="3">0</asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <cc1:MaskedEditExtender ID="meeTxtVacios" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                                        Mask="999" MaskType="number" TargetControlID="txtVacios">
                                                                    </cc1:MaskedEditExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr align="right">
                                    <td>
                                        <asp:Label ID="lblNoexisteInf" runat="server" BackColor="Green" Font-Size="Small"
                                            ForeColor="White" Text="No Existe Información" Width="650px" Visible="False"></asp:Label></td>
                                </tr>
                                <tr align="right">
                                    <td>
                                        <asp:ImageButton ID="imbCerrarLastro" runat="server" SkinID="ASP_ImgButton-cerrar"
                                            OnClick="imbCerrarLastro_Click" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblerrorlastro" runat="server" ForeColor="Maroon"></asp:Label></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="upprogressLastro" runat="server">
                        <ProgressTemplate>
                            <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                            <strong style="font-size: small">Procesando datos por favor espere</strong>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Button Style="display: none" ID="btnpopupPart" runat="server"></asp:Button>
                <cc1:ModalPopupExtender ID="mpepopupPart" runat="server" PopupControlID="pnlpopupPart"
                    BackgroundCssClass="fondoModal" TargetControlID="btnpopupPart" CancelControlID="imbCancelPart">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlpopupPart" runat="server" Width="700px" Height="300px" Style="display: none;
                    left: 0px; top: 3%;" CssClass="modalPopup">
                    <asp:UpdatePanel ID="upopupPart" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td colspan="1">
                                        <asp:Label ID="lblTitSecPart" runat="server" Text="Identificación Secuencias Particulares"
                                            Width="100%" BackColor="Green" Font-Size="Small" ForeColor="White"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1" valign="top">
                                        <asp:Label ID="lblTitNumSec" runat="server" Text="Cantidad de Tubos a Ingresar" Width="176px"></asp:Label>
                                        <asp:Label ID="lblCantTubos" runat="server" BackColor="Green" ForeColor="White" Width="30px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1" valign="top">
                                        <asp:Label ID="lblEscribirSec" runat="server" Text="Ingrese el Nro de Secuencia del cilindro"
                                            Width="328px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <asp:GridView ID="grvSecPart" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros para los parametros de consulta"
                                            CssClass="Grilla" Width="648px" Caption="<b>Detalle Secuencias Particulares</b>">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Secuencias">
                                                    <ItemTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtSecPart" runat="server" Width="60px" MaxLength="7" AutoPostBack="True"
                                                                        OnTextChanged="txtSecPart_TextChanged">0</asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="1">
                                                                    <cc1:MaskedEditExtender ID="meeSecPart" runat="server" AutoComplete="False" AutoCompleteValue="false"
                                                                        Mask="9999999" MaskType="number" TargetControlID="txtSecPart">
                                                                    </cc1:MaskedEditExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Cliente" HtmlEncode="False">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tubo" HtmlEncode="False" />
                                                <asp:BoundField HeaderText="Capacidad" HtmlEncode="False" DataField="capacidad" />
                                                <asp:BoundField HeaderText="AGEN_CAPA" HtmlEncode="False"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr align="right">
                                    <td>
                                        <asp:Label ID="lblNoexitPart" runat="server" BackColor="Green" Font-Size="Small"
                                            ForeColor="White" Text="No Existe Información" Width="650px" Visible="False"></asp:Label></td>
                                </tr>
                                <tr align="right">
                                    <td>
                                        <asp:ImageButton ID="imbAceptarPart" runat="server" SkinID="ASP_ImgButton-Aceptar"
                                            OnClick="imbAceptarPart_Click" />&nbsp; &nbsp;<asp:ImageButton ID="imbCancelPart"
                                                runat="server" SkinID="ASP_ImgButton-Cancelar" OnClick="imbCancelPart_Click" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblErrorPart" runat="server" ForeColor="Maroon"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSecCargadas" runat="server" Visible="False"></asp:Label>
                                        <asp:Label ID="lblSecPart" runat="server" Visible="False"></asp:Label></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="upprogressPart" runat="server">
                        <ProgressTemplate>
                            <img alt="" src="../App_Themes/Theme_Praxair/Image/ajax-loader.gif" width="20" /><br />
                            <strong style="font-size: small">Procesando datos por favor espere</strong>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Button Style="display: none" ID="btnpopupLegajo" runat="server"></asp:Button>
                <cc1:ModalPopupExtender ID="mpepopupLegajo" runat="server" PopupControlID="pnlpopupLegajo"
                    BackgroundCssClass="fondoModal" TargetControlID="btnpopupLegajo" CancelControlID="btnCancelLegajo">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlpopupLegajo" runat="server" Width="350px" Height="300px"  Style="display: none; left: 0px; top: 3%;"         
                       CssClass="modalPopup">
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
                                        <td  colspan="3" >
                                            <asp:Label ID="lblNomUsu" runat="server" Width="288px" BackColor="WhiteSmoke"></asp:Label></td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="1">
                                            <asp:Label ID="lblLegajo" runat="server" Text="Legajo:"></asp:Label></td>
                                        <td align="left" colspan="1" valign="top">
                                            <asp:TextBox ID="txtLegajo" runat="server" Width="96px" AutoPostBack="True" OnTextChanged="txtLegajo_TextChanged"  ></asp:TextBox>
                                        </td>
                                        <td align="left" colspan="1" >
                                            
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
                                            <asp:ImageButton ID="imbAcepLegajo" runat="server" SkinID="ASP_ImgButton-Aceptar" OnClick="imbAcepLegajo_Click"  />
                                            </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnCancelLegajo" runat="server" SkinID="ASP_ImgButton-Cancelar" OnClick="btnCancelLegajo_Click"    /></td>
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
            <td align="center">
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
                            <asp:Button ID="btnokmensaje" runat="server" CausesValidation="False" OnClick="btnokmensaje_Click"
                                Text="Aceptar" />
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
    <table>
        <tr>
            <td>
                &nbsp;<asp:Button ID="btnConfirmacion" runat="server" CausesValidation="False" Style="display: none" />
                <cc1:ModalPopupExtender ID="mpeConfirmacion" runat="server" BackgroundCssClass="fondoModal"
                    CancelControlID="btnCancelarConfirma" PopupControlID="pnlConfirma" TargetControlID="btnConfirmacion">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlConfirma" runat="server" CssClass="modalPopup" Height="150px" Style="display: none;
                    left: 0px; top: 0px" Width="400px">
                    <asp:UpdatePanel ID="upConfirmacion" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="vertical-align: middle; color: white; background-color: green; text-align: left">
                                <strong>Confirmación</strong></div>
                            <br />
                            &nbsp;<asp:Label ID="lblConfirma" runat="server">Confirma los controles para Gases Medicinales ?</asp:Label><br />
                            <br />
                            &nbsp;<asp:ImageButton ID="btnOKCOnfirma" runat="server" OnClick="btnOKCOnfirma_Click"
                                SkinID="ASP_ImgButton-Aceptar" />
                            <asp:ImageButton ID="btnCancelarConfirma" runat="server" OnClick="btnCancelarConfirma_Click"
                                SkinID="ASP_ImgButton-Cancelar" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp;
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                &nbsp;<asp:Button ID="btnPartConfirm" runat="server" CausesValidation="False" Style="display: none" />
                <cc1:ModalPopupExtender ID="mpeConfPart" runat="server" BackgroundCssClass="fondoModal"
                    CancelControlID="imbCanConfPart" PopupControlID="pnlConfPart" TargetControlID="btnPartConfirm">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlConfPart" runat="server" CssClass="modalPopup" Height="150px" Style="display: none;
                    left: 0px; top: 0px" Width="400px">
                    <asp:UpdatePanel ID="upConfPart" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="vertical-align: middle; color: white; background-color: green; text-align: left">
                                <strong>Confirmación</strong></div>
                            <br />
                            &nbsp;<asp:Label ID="lblMenConfPart" runat="server"></asp:Label><br />
                            <br />
                            &nbsp;<asp:ImageButton ID="imbAcepConfPart" runat="server" SkinID="ASP_ImgButton-Aceptar"
                                OnClick="imbAcepConfPart_Click" />
                            <asp:ImageButton ID="imbCanConfPart" runat="server" SkinID="ASP_ImgButton-Cancelar"
                                OnClick="imbCanConfPart_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp;
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnAlerta" runat="server" CausesValidation="False" Style="display: none" /><cc1:ModalPopupExtender
                    ID="mpeAlerta" runat="server" BackgroundCssClass="fondoModal" CancelControlID="btnNoGrabar"
                    PopupControlID="pnlAlerta" TargetControlID="btnAlerta">
                </cc1:ModalPopupExtender>
                <br />
                <asp:Panel ID="pnlAlerta" runat="server" CssClass="modalPopup" Height="200px" Style="display: none;
                    left: 0px; top: 0px;" Width="400px">
                    <asp:UpdatePanel ID="upAlerta" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="vertical-align: middle; color: white; background-color: green; text-align: left">
                                <strong>Mensaje</strong></div>
                            <br />
                            <br />
                            &nbsp;<asp:Label ID="lblAlerta" runat="server" BackColor="#C00000" Font-Size="Medium"
                                ForeColor="White" Width="384px">¿ El lote no cumple con las especificaciones. Desea grabar igual  ?</asp:Label><br />
                            <br />
                            <br />
                            <asp:Button ID="btnGrabar" runat="server" CausesValidation="False" Text="Grabar"
                                OnClick="btnGrabar_Click" />
                            <asp:Button ID="btnNoGrabar" runat="server" Text="No Grabar" OnClick="btnNoGrabar_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;<br />
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
