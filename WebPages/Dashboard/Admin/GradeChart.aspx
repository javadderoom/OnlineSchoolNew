<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeChart.aspx.cs" Inherits="WebPages.Dashboard.Admin.GradeChart" %>

<%@ Register Src="~/Controllers/GradeChartt.ascx" TagPrefix="hc" TagName="GradeChartt" %>

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
            <hc:GradeChartt runat="server" id="GradeChartt" />
        </div>
    </form>
</body>
</html>