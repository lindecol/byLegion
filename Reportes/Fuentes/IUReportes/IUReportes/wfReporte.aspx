<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfReporte.aspx.cs" Inherits="IUReportes.wfReporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reportes</title>
    <script type="text/javascript" language="javascript">
        function imprimir()
        {
            window.print();
        }        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <asp:Label ID="Label1" runat="server" Text="No se encontraron datos para el reporte" ForeColor="Red" Visible="False"></asp:Label>&nbsp;
        <rsweb:ReportViewer ID="rptVisorReportes" runat="server"
                Width="80%" Height="800px" >
            </rsweb:ReportViewer>
            </center>
        <center>
        </center>
    </div>
    </form>
</body>
</html>
