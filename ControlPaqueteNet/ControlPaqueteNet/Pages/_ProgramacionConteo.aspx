<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProgramacionConteo.aspx.vb" Inherits="ControlPaquete.ProgramacionConteo" MasterPageFile="~/Pages/MasterPage.Master" Culture="Auto" UICulture="Auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:content id="Content4" contentplaceholderid="ContentPlaceHolder4" runat="server">
    <%--Colocamos el UpdatePanel para nuestros asuntos en AJAX--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" EnableScriptLocalization="True" />
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table style="width:100%">
                <tr>
                    <td valign="top" align="center" colspan="6">
                        <%--Mostramos el título de la página--%>
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Teal"
                            Text="Programación Conteo"></asp:Label>
                        <br />
                        <hr style="width:100%" />
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <img src="../Images/clock.gif" />
                                Cargando información...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr style="height:32px">
                    <%--Mostramos la caja de texto donde va la fecha--%>
                    <td align="left" valign="top" style="width: 134px">
                        <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Fecha Inicio:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;</td>
                    <td align="left" valign="top" colspan="5">
                        <asp:TextBox runat="server" ID="txtDate" Width="185px" />
                        <asp:ImageButton runat="Server" ID="ibCalendario" ImageUrl="~/Images/Calendar.gif" /><br />
                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDate"
                            PopupButtonID="ibCalendario" Format="dddd, dd 'de' MMMM 'de' yyyy" />
                    </td>
                </tr>
                <tr>
                    <%--Mostramos la hora de inicio--%>
                    <td align="left" valign="top" style="width: 134px">
                        <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Hora Inicio:" ForeColor="Teal" Width="88px" Font-Bold="True"></asp:Label></td>
                    <td align="left" valign="top" style="width: 150px">
                        <asp:DropDownList ID="cmbHoraInicio" runat="server" AutoPostBack="False" ForeColor="Black" Width="70px">
                            <asp:ListItem Value="0" Selected="True">12:00</asp:ListItem>
                            <asp:ListItem Value="1">12:30</asp:ListItem>
                            <asp:ListItem Value="2">01:00</asp:ListItem>
                            <asp:ListItem Value="3">01:30</asp:ListItem>
                            <asp:ListItem Value="4">02:00</asp:ListItem>
                            <asp:ListItem Value="5">02:30</asp:ListItem>
                            <asp:ListItem Value="6">03:00</asp:ListItem>
                            <asp:ListItem Value="7">03:30</asp:ListItem>
                            <asp:ListItem Value="8">04:00</asp:ListItem>
                            <asp:ListItem Value="9">04:30</asp:ListItem>
                            <asp:ListItem Value="10">05:00</asp:ListItem>
                            <asp:ListItem Value="11">05:30</asp:ListItem>
                            <asp:ListItem Value="12">06:00</asp:ListItem>
                            <asp:ListItem Value="13">06:30</asp:ListItem>
                            <asp:ListItem Value="14">07:00</asp:ListItem>
                            <asp:ListItem Value="15">07:30</asp:ListItem>
                            <asp:ListItem Value="16">08:00</asp:ListItem>
                            <asp:ListItem Value="17">08:30</asp:ListItem>
                            <asp:ListItem Value="18">09:00</asp:ListItem>
                            <asp:ListItem Value="19">09:30</asp:ListItem>
                            <asp:ListItem Value="20">10:00</asp:ListItem>
                            <asp:ListItem Value="21">10:30</asp:ListItem>
                            <asp:ListItem Value="22">11:00</asp:ListItem>
                            <asp:ListItem Value="23">11:30</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                        <asp:DropDownList ID="cmbHora" runat="server" AutoPostBack="False" ForeColor="Black" Width="64px">
                            <asp:ListItem Value="0" Selected="True">AM</asp:ListItem>
                            <asp:ListItem Value="1">PM</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <%--Mostramos la hora fin--%>
                    <td align="left" valign="top" style="width: 75px">
                        <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Hora Fin:" ForeColor="Teal" Font-Bold="True" Width="72px"></asp:Label>&nbsp;</td>
                    <td align="left" valign="top" colspan="3">
                        <asp:DropDownList ID="cmbHoraFin" runat="server" AutoPostBack="False" ForeColor="Black" Width="70px">
                            <asp:ListItem Value="0" Selected="True">12:00</asp:ListItem>
                            <asp:ListItem Value="1">12:30</asp:ListItem>
                            <asp:ListItem Value="2">01:00</asp:ListItem>
                            <asp:ListItem Value="3">01:30</asp:ListItem>
                            <asp:ListItem Value="4">02:00</asp:ListItem>
                            <asp:ListItem Value="5">02:30</asp:ListItem>
                            <asp:ListItem Value="6">03:00</asp:ListItem>
                            <asp:ListItem Value="7">03:30</asp:ListItem>
                            <asp:ListItem Value="8">04:00</asp:ListItem>
                            <asp:ListItem Value="9">04:30</asp:ListItem>
                            <asp:ListItem Value="10">05:00</asp:ListItem>
                            <asp:ListItem Value="11">05:30</asp:ListItem>
                            <asp:ListItem Value="12">06:00</asp:ListItem>
                            <asp:ListItem Value="13">06:30</asp:ListItem>
                            <asp:ListItem Value="14">07:00</asp:ListItem>
                            <asp:ListItem Value="15">07:30</asp:ListItem>
                            <asp:ListItem Value="16">08:00</asp:ListItem>
                            <asp:ListItem Value="17">08:30</asp:ListItem>
                            <asp:ListItem Value="18">09:00</asp:ListItem>
                            <asp:ListItem Value="19">09:30</asp:ListItem>
                            <asp:ListItem Value="20">10:00</asp:ListItem>
                            <asp:ListItem Value="21">10:30</asp:ListItem>
                            <asp:ListItem Value="22">11:00</asp:ListItem>
                            <asp:ListItem Value="23">11:30</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                        <asp:DropDownList ID="cmbHoraAP" runat="server" AutoPostBack="False" ForeColor="Black" Width="64px">
                            <asp:ListItem Value="0" Selected="True">AM</asp:ListItem>
                            <asp:ListItem Value="1">PM</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height:32px">
                    <%--Mostramos el tipo de conteo--%>
                    <td align="left" valign="top" style="width: 134px">
                        <asp:Label ID="Label4" runat="server" Font-Size="Small" Text="Tipo Conteo:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;</td>
                    <td align="left" style="width: 150px" valign="top">
                        <asp:DropDownList ID="cmbTipoProgramacion" runat="server" AutoPostBack="True" ForeColor="Black" Width="210px" OnSelectedIndexChanged="cmbTipoProgramacion_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="A">Activos</asp:ListItem>
                            <asp:ListItem Value="P">Productos</asp:ListItem>
                            <asp:ListItem Value="M">Mixto</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <%--Mostramos el usuario--%>
                    <td align="left" valign="top">
                        <asp:Label ID="Label9" runat="server" Font-Size="Small" Text="Usuario:" ForeColor="Teal" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" valign="top" colspan="2">
                        <asp:DropDownList ID="cmbUsuario" runat="server" AutoPostBack="False" ForeColor="Black" Width="200px" DataTextField="nombre_usuario" DataValueField="codigo_usuario">
                        </asp:DropDownList>
                    </td>
                    <td align="left" valign="top">
                        <asp:CheckBox ID="chkMail" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="Enviar Mail" /><br />
                    </td>
                </tr>
                <tr style="height:32px">
                    <%--Sucursal--%>
                    <td align="left" valign="top" style="width: 134px">
                        <asp:Label ID="Label5" runat="server" Font-Size="Small" Text="Sucursales:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                    </td>
                    <td valign="top" align="left">
                        <asp:DropDownList ID="cmbSucursal" runat="server" AutoPostBack="True" ForeColor="Black" Width="210px" DataTextField="nombre_sucursal" DataValueField="codigo_sucursal" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbSucursal_SelectedIndexChanged" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="4" valign="top" align="left">
                        <%--Sector--%>
                        <asp:Label ID="Label6" runat="server" Font-Size="Small" Text="Sectores:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                        <asp:DropDownList ID="cmbSector" runat="server" AutoPostBack="True" ForeColor="Black" Width="200px" DataTextField="colNombre" DataValueField="colCodigo" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbSector_SelectedIndexChanged" Enabled="False" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height:32px">
                    <%--Subdepósitos--%>
                    <td align="left" valign="top" style="width: 134px">
                        <asp:Label ID="Label7" runat="server" Font-Size="Small" Text="Subdepósitos:" ForeColor="Teal" Font-Bold="True"></asp:Label>&nbsp;
                    </td>
                    <td valign="top" align="left" colspan="5">
                        <asp:DropDownList ID="cmbSubdeposito" runat="server" AutoPostBack="True" ForeColor="Black" Width="210px" DataTextField="nombre_subdepoisto" DataValueField="codigo_subdeposito" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbSubdeposito_SelectedIndexChanged" Enabled="False" >
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" colspan="6">
                        <%--Grilla donde mostramos los subdepósitos asociados al conteo--%>
                        <asp:GridView ID="grConteo" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px">
                            <Columns>
                                <asp:BoundField DataField="NombreSucursal" HeaderText="Sucursal" >
                                    <ControlStyle Width="205px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreSector" HeaderText="Sector" >
                                    <ControlStyle Width="205px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreSubdeposito" HeaderText="Subdepósito" >
                                    <ControlStyle Width="205px" />
                                </asp:BoundField>
                                <asp:CommandField SelectText="Eliminar" ShowSelectButton="True">
                                    <ControlStyle Width="90px" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="teal" ForeColor="white" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" colspan="3">
                        <br />
                        <%--Tab donde aparecen los tipos de programación de conteo--%>
                        <ajaxToolkit:tabcontainer runat="server" ID="tbProgramacion" Height="250px" ActiveTabIndex="0" Width="425px">
                            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Ninguna">
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Diaria">
                                <ContentTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" id="t1">
                                        <tr>
                                            <td style="height:30px;">
                                                <asp:RadioButton ID="rbDia1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="Cada" GroupName="dia" AutoPostBack="True" />
                                                <asp:TextBox ID="txtDia" runat="server" MaxLength="2" Width="24px" AutoPostBack="True">1</asp:TextBox>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                                                    Text="días"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height:30px;">
                                                <asp:RadioButton ID="rbDia2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="Todos los días laborables (lunes a viernes)" GroupName="dia" AutoPostBack="True" />
                                            </td>
                                        </tr>
	                                </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Semanal">
                                <ContentTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" id="Table1">
	                                    <tr>
	                                        <td style="height:30px; width:96px">
                                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                                                    Text="Repetir Cada" Width="96px"></asp:Label></td>
                                            <td style="width:24px">
                                                <asp:TextBox ID="txtSemana" runat="server" MaxLength="2" Width="24px" AutoPostBack="True">1</asp:TextBox></td>                    
                                            <td>&nbsp;<asp:Label ID="Label11" runat="server"
                                                Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="semanas el:" Width="88px"></asp:Label></td></tr>
	                                </table>
	                                <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkDomingo" runat="server" Text="domingo" Font-Bold="True" ForeColor="Teal" Font-Size="Small" AutoPostBack="True" /></td>
                                            <td>
                                                <asp:CheckBox ID="chkLunes" runat="server" Text="lunes" Font-Bold="True" ForeColor="Teal" Font-Size="Small" AutoPostBack="True" /></td>
                                            <td>
                                                <asp:CheckBox ID="chkMartes" runat="server" Text="martes" Font-Bold="True" ForeColor="Teal" Font-Size="Small" AutoPostBack="True" /></td>
                                            <td>
                                                <asp:CheckBox ID="chkMiercoles" runat="server" Text="miercoles" Font-Bold="True" ForeColor="Teal" Font-Size="Small" AutoPostBack="True" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkJueves" runat="server" Text="jueves" Font-Bold="True" ForeColor="Teal" Font-Size="Small" AutoPostBack="True" /></td>
                                            <td>
                                                <asp:CheckBox ID="chkViernes" runat="server" Text="viernes" Font-Bold="True" ForeColor="Teal" Font-Size="Small" AutoPostBack="True" /></td>
                                            <td colspan="2">
                                                <asp:CheckBox ID="chkSabado" runat="server" Text="sabado" Font-Bold="True" ForeColor="Teal" Font-Size="Small" AutoPostBack="True" /></td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Mensual">
                                <ContentTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" id="Table2">
	                                    <tr>
	                                        <td style="height:30px">
	                                            <table>
	                                                <tr>
	                                                    <td>
	                                                        <asp:RadioButton ID="rbMes1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="Día" GroupName="mes" AutoPostBack="True" />
                                                            <asp:TextBox ID="txtDiaMes" runat="server" MaxLength="2" Width="24px" AutoPostBack="True">31</asp:TextBox>
                                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                                                                Text="de cada"></asp:Label>
                                                            <asp:TextBox ID="txtMes" runat="server" MaxLength="2" Width="24px" AutoPostBack="True">1</asp:TextBox>
                                                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                                                                Text="meses"></asp:Label>
	                                                    </td>
	                                                </tr>
	                                            </table>
                                            </td>
                                        </tr>
	                                    <tr>
	                                        <td style="height:30px">	            
	                                            <table>
	                                                <tr>
	                                                    <td>
	                                                        <asp:RadioButton ID="rbMes2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="El" GroupName="mes" AutoPostBack="True" />
	                                                    </td>
	                                                    <td valign="middle">
	                                                        <asp:DropDownList ID="cmbDiaMensual" runat="server" ForeColor="Black" Width="80px">
                                                                <asp:ListItem Value="0" Selected="True">primer</asp:ListItem>
                                                                <asp:ListItem Value="1">segundo</asp:ListItem>
                                                                <asp:ListItem Value="2">tercer</asp:ListItem>
                                                                <asp:ListItem Value="3">cuarto</asp:ListItem>
                                                                <asp:ListItem Value="4">&#250;ltimo</asp:ListItem>
                                                            </asp:DropDownList>
	                                                    </td>
	                                                    <td valign="middle">
	                                                        <asp:DropDownList ID="cmbTipo" runat="server" ForeColor="Black" Width="150px">
                                                                <asp:ListItem Value="0" Selected="True">d&#237;a</asp:ListItem>
                                                                <asp:ListItem Value="1">d&#237;a de la semana</asp:ListItem>
                                                                <asp:ListItem Value="2">d&#237;a del fin de semana</asp:ListItem>
                                                                <asp:ListItem Value="3">domingo</asp:ListItem>
                                                                <asp:ListItem Value="4">lunes</asp:ListItem>
                                                                <asp:ListItem Value="5">martes</asp:ListItem>
                                                                <asp:ListItem Value="6">miercoles</asp:ListItem>
                                                                <asp:ListItem Value="7">jueves</asp:ListItem>
                                                                <asp:ListItem Value="8">viernes</asp:ListItem>
                                                                <asp:ListItem Value="9">sabado</asp:ListItem>
                                                            </asp:DropDownList>
	                                                    </td>
	                                                    <td>
	                                                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                                                                Text="de cada"></asp:Label>
                                                            <asp:TextBox ID="txtMesDia" runat="server" MaxLength="2" Width="24px" AutoPostBack="True">1</asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal"
                                                                Text="meses"></asp:Label>
	                                                    </td>
	                                                </tr>
	                                            </table>
                                            </td>
                                        </tr>
	                                </table>
	                            </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="Repetitiva">
                                <ContentTemplate>
                                    <br />
                                    <table>
                                        <tr>
                                            <td valign="top" align="left">
                                                <asp:Calendar ID="CalendarRepetitiva" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="24px" NextPrevFormat="FullMonth" Width="88px" Visible="true">
                                                    <SelectedDayStyle BackColor="Red" ForeColor="White" />
                                                    <TodayDayStyle BackColor="#CCCCCC" />
                                                    <OtherMonthDayStyle ForeColor="#999999" />
                                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                                                        Font-Size="12pt" ForeColor="Teal" />
                                                    </asp:Calendar>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:GridView ID="grRepetitiva" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="190px">
                                                    <Columns>
                                                        <asp:BoundField DataField="fecha" HeaderText="Fecha" >
                                                            <ControlStyle Width="120px" />
                                                        </asp:BoundField>
                                                        <asp:CommandField SelectText="Eliminar" ShowSelectButton="True">
                                                            <ControlStyle Width="70px" />
                                                        </asp:CommandField>
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="teal" ForeColor="white" />
                                                    <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>                                    
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:tabcontainer>
                    </td>
                    <td align="left" valign="top" colspan="3">
                        <br />
                        <asp:RadioButton ID="rbActual" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="Finaliza el 31 del año en curso" GroupName="fecha" /><br />
                        <br />
                        <asp:RadioButton ID="rbFecha" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="Finalizar" GroupName="fecha" />
                        <asp:TextBox runat="server" ID="txtFinaliza" Width="135px" />
                        <asp:ImageButton runat="Server" ID="ibFinaliza" ImageUrl="~/Images/Calendar.gif" /><br />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFinaliza"
                            PopupButtonID="ibFinaliza" Format="dddd, dd 'de' MMMM 'de' yyyy" />
		                <p />
                        <asp:CheckBox ID="chkFestivos" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Teal" Text="Incluir Festivos" Visible="false" />
                        <p />
                        <%--Mostramos el calendario--%>
                        <asp:Calendar ID="MisFechas" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="24px" NextPrevFormat="FullMonth" Width="88px" Enabled="true" EnableViewState="false">
                            <SelectedDayStyle BackColor="Red" ForeColor="White" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                                Font-Size="12pt" ForeColor="Teal" />
                        </asp:Calendar>
                        <br />
                        <%--Botón para guardar--%>
                        <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" ToolTip="Generar" OnClick="ibGuardar_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <%--Error--%>
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" Text="lblError:" ForeColor="Red"
                            Font-Bold="True" Visible="false"></asp:Label>&nbsp;
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" colspan="6">
                        <%--Grilla donde mostramos los errores presentados--%>
                        <asp:GridView ID="grErrores" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="750px" ForeColor="Red">
                            <Columns>
                                <asp:BoundField DataField="Error" HeaderText="Mensaje" >
                                    <ControlStyle Width="615px" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="teal" ForeColor="white" />
                            <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Teal" BorderColor="White" />
                        </asp:GridView>
                        <br />
                        <%--Botón para confirmar--%>
                        <asp:ImageButton ID="ibConfirmar" runat="server" ImageUrl="~/Images/Guardar.GIF" Width="24px" ToolTip="Confirmar Programación" OnClick="ibConfirmar_Click" Visible="False" />
                        &nbsp;
                        <%--Botón para eliminar--%>
                        <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Images/Eliminar.jpg" Width="24px" ToolTip="Cancelar Programación" OnClick="ibEliminar_Click" Visible="False" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ibCalendario" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ibFinaliza" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="cmbTipoProgramacion" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbSucursal" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbSector" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbSubdeposito" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ibGuardar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ibConfirmar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ibEliminar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:content>