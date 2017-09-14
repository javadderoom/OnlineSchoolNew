<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Admin/AdminPanel.Master" AutoEventWireup="true" CodeBehind="reportsLessonGroupsChart.aspx.cs" Inherits="WebPages.Dashboard.Admin.reportsLessonGroupsChart" %>

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

            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft">
                <span id="iii" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:sasanRes,classnum%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblClassNum" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft">
                <span id="yyy" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:sasanRes,teacher%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblTeacharName" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft">
                <span id="ooo" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:sasanRes,classcount%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblStuCount" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft">
                <span id="oyo" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:sasanRes,lessontitle%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblLessonTitle" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
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
            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft" style="float: right">
                <span id="eee" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:sasanRes,katbiexamcount%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblKatbiExamCount" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft" style="float: right">
                <span id="eee" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:sasanRes,shafahiexamcount%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblShafahiExamCount" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
        </div>
    </div>
    <div class="ln_solid"></div>
    <div class="form-group">
        <div class="row">

            <div class="col-xs-12 col-sm-3  text-right dirRight goRight" style="float: right">
                <span id="ContentPlaceHolder1_Label3" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:sasanRes,tamrincount%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lbltamrincount" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>

            <div class="col-xs-12 col-sm-3 text-right dirRight goRight" style="float: right">
                <span id="ContentPlaceHolder1_Label1" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:sasanRes,percentamrinanswer%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblanswer" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
        </div>
    </div>
    <div class="ln_solid"></div>
    <div class="form-group">
        <div class="row">
            <div class="col-xs-12 col-sm-3 text-right dirRight goRight" style="float: right">
                <span id="lkl" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:sasanRes,sessionscount%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblSessionCount" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
        </div>
    </div>
    <div class="ln_solid"></div>
    <div class="c-title">
        <h4>
            <asp:Literal runat="server" Text="اطلاعات دانش آموزان" />
        </h4>
    </div>
    <asp:UpdatePanel runat="server" ID="updp1">
        <ContentTemplate>
            <asp:GridView ID="gvStudents" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" CssClass="dirRight table"
                HorizontalAlign="Center" OnRowDataBound="gvStudents_RowDataBound" AllowCustomPaging="True" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="StudentCode" HeaderText="شماره دانش آموزی " />
                    <asp:BoundField DataField="FullName" HeaderText="نام و نام خانوادگی" />
                    <asp:BoundField DataField="avgNomre" HeaderText=" میانگین نمرات" />
                    <asp:BoundField DataField="countJavabeTamrin" HeaderText="تعداد تمرین های  تحویل داده" />

                    <asp:TemplateField>
                        <ItemTemplate>

                            <%--<asp:Button ID="Details" runat="server"
                                                CommandName="Details"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="<%$ Resources:Dashboard,Details%>" />

                                                                                   <asp:Button ID="Add" runat="server"
                                                CommandName="Add"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="<%$ Resources:Dashboard,Add%>" />

                            <asp:CheckBox ID="GVchk" runat="server" AutoPostBack="false" OnCheckedChanged="GVchk_CheckedChanged" />--%>
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
            <button type="button" id="btnChart" onserverclick="btnChart_ServerClick" class="btn btn-auto-h btn-info goRight" runat="server" style="margin-right: 5px;">
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