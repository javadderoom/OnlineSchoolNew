﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Admin/AdminPanel.Master" AutoEventWireup="true" CodeBehind="reportsFieldsChart.aspx.cs" Inherits="WebPages.Dashboard.Admin.reportsFieldsChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="../Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Styles/simple-sidebar.css" rel="stylesheet" />
    <script src="../JavaScript/custom.min.js"></script>
    <link href="../Styles/AdminPanelStyles.css" rel="stylesheet" />
    <link href="../font-awesome-4.3.0/css/font-awesome.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="c-title">
        <h4>
            <asp:Literal runat="server" Text="<%$ Resources:sasanRes,reports%>" />
        </h4>
    </div>
    <div class="form-group">
        <div class="row">

            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft" style="float: right">
                <span id="iii" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="رشته" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblReshte" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft" style="float: right">
                <span id="yyy" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="مقطع" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblMaghta" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>

        </div>
    </div>

    <div class="ln_solid"></div>
    <div class="form-group">
        <div class="row">

            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft" style="float: right">
                <span id="ContentPlaceHolder1_Label2" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:sasanRes,mianginkatbi%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblmianginkatbi" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft" style="float: right">
                <span id="ContentPlaceHolder1_Label4" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:sasanRes,mianginshafahi%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblmianginshafahi" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>


        </div>
    </div>
    <div class="ln_solid"></div>
    <div class="form-group">
        <div class="row">


            <div class="col-xs-12 col-sm-3  text-right dirRight goRight" style="float: right">
                <span id="ContentPlaceHolder1_Label3" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="تعداد دانش آموزان" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblStudentsCount" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>


        </div>
    </div>
    <div class="ln_solid"></div>

    <div class="c-title">
        <h4>
            <asp:Literal runat="server" Text="اطلاعات کلاسها" />
        </h4>
    </div>
    <asp:UpdatePanel runat="server" ID="updp1">
        <ContentTemplate>
            <asp:GridView ID="gvStudents" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" CssClass="dirRight table"
                HorizontalAlign="Center" OnRowDataBound="gvStudents_RowDataBound" AllowCustomPaging="True" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="class" HeaderText="کلاس" />
                    <asp:BoundField DataField="avg" HeaderText="میانگین نمرات دانش آموزان" />

                    <asp:TemplateField>
                        <ItemTemplate>
                        </ItemTemplate>



                    </asp:TemplateField>
                </Columns>

                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="row">
        <div class="col-md-5 col-md-push-7 col-xs-6 col-xs-push-6" style="margin: auto">
            <button type="button" id="btnViewAll" class="btn btn-auto-h btn-info goRight" runat="server" style="margin-right: 5px;">
                <asp:Literal runat="server" Text="گزارشات نموداری" />
                <span class="fa fa-list"></span>
            </button>
        </div>
        <div class="extra" style="height: 100px">
        </div>
    </div>
    <div class="extra" style="height: 100px">
    </div>
</asp:Content>
