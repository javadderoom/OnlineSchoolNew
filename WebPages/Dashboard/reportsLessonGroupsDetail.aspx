<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="reportsLessonGroupsDetail.aspx.cs" Inherits="WebPages.Dashboard.reportsLessonGroupsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="Styles/bootstrap.css" rel="stylesheet" />
    <link href="Styles/simple-sidebar.css" rel="stylesheet" />
    <link href="Styles/AdminPanelStyles.css" rel="stylesheet" />
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
                    <asp:Literal runat="server" Text="میانگین امتحان های کتبی" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblMiabginKatbi" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft" style="float: right">
                <span id="yyy" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="میانگین امتحان های شفاهی" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblMianginShafahi" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>

        </div>
    </div>

    <div class="ln_solid"></div>
    <div class="form-group">
        <div class="row">

            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft" style="float: right">
                <span id="ContentPlaceHolder1_Label2" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="تعداد تمرین های داده شده" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblTamrinCount" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft" style="float: right">
                <span id="ContentPlaceHolder1_Label4" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="تعدادتمرین های تحویل داده شده" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblAnswer" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>


            </div>
        </div>
        <div class="ln_solid"></div>

        <div class="c-title">
            <h4>
                <asp:Literal runat="server" Text="ریز نمرات" />
            </h4>
        </div>
        <asp:UpdatePanel runat="server" ID="updp1">
            <ContentTemplate>
                <asp:GridView ID="gvStudents" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" CssClass="dirRight table"
                    HorizontalAlign="Center" OnRowDataBound="gvStudents_RowDataBound" AllowCustomPaging="True" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="rowNum" HeaderText="شماره " />
                        <asp:BoundField DataField="Nomre" HeaderText="نمره " />
                        <asp:BoundField DataField="nomreDate" HeaderText="تاریخ جلسه" />
                        <asp:BoundField DataField="SessionNum" HeaderText=" شماره جلسه" />
                        <asp:BoundField DataField="ExamType" HeaderText="نوع امتحان" />

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

            <div class="extra" style="height: 100px">
            </div>
        </div>
        <div class="extra" style="height: 100px">
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
