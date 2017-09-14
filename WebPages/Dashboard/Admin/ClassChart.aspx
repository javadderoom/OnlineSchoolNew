<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassChart.aspx.cs" Inherits="WebPages.Dashboard.Admin.ClassChart" %>

<%@ Register Src="~/Controllers/ClassChartt.ascx" TagPrefix="hc" TagName="ClassChartt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../HighCharts/exporting.js"></script>
    <script src="../HighCharts/highcharts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <hc:ClassChartt runat="server" ID="ClassChartt" />
        </div>
    </form>
</body>
</html>