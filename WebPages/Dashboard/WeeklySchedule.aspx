<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="WeeklySchedule.aspx.cs" Inherits="WebPages.Dashboard.WeeklySchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="Styles/bootstrap.css" rel="stylesheet" />
    <link href="Styles/simple-sidebar.css" rel="stylesheet" />
    <link href="Styles/AdminPanelStyles.css" rel="stylesheet" />

    <%--  <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/simple-sidebar.css" rel="stylesheet" />--%>
    <link href="font-awesome-4.3.0/css/font-awesome.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="c-title">
        <h4>
            <asp:Literal runat="server" Text="<%$ Resources:Dashboard,barname_haftegi%>" />
        </h4>
    </div>
    <div class="x_content">
        <div class="row">
            <div class="col-md-4 col-xs-12 hidden-xs">
            </div>
            <div class="col-xs-12 col-sm-4  text-right dirRight goLeft">
            </div>
            <div class="col-xs-12 col-sm-4  text-right dirRight " style="float: right;">
                <span id="ContentPlaceHolder1_Label3" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="<%$ Resources:Dashboard,Year%>" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span id="lblYear" runat="server" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
            <%-- <div class="col-md-4 col-xs-12 text-righ">
                <asp:Button ID="btnAdd" name="btnAdd" class="btn btn-primary" runat="server"
                    Text="<%$ Resources:Dashboard,AddLesson%>" OnClick="btnAddLesson_Click" />
            </div>
            <div class="col-md-4 col-xs-12 text-righ">
                <div class="input-group">
                    <span class="input-group-btn">
                        <button type="button" id="btnSearch" class="btn btn-primary" runat="server" onserverclick="btnSearch_Click">
                            <span class="fa fa-search"></span>
                        </button>
                    </span>

                    <div id="ContentPlaceHolder1_upSearch">

                        <input name="ctl00$ContentPlaceHolder1$tbxnameSearch" runat="server" placeholder="نام درس" type="text" maxlength="50" id="tbxSearch" class="form-control text-right dirRight" />
                    </div>
                </div>
            </div>--%>
        </div>
        <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <div class="ln_solid" style="line-height: 30px;"></div>
        <div id="ContentPlaceHolder1_upGrid">
            <div>
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                <%-- <ContentTemplate> OnRowCommand="gvSchedule_RowCommand"--%>

                <asp:GridView ID="gvSchedule" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                    ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" CssClass="dirRight table" HorizontalAlign="Center" OnRowDataBound="gvSchedule_RowDataBound" AllowCustomPaging="True" AllowPaging="True"
                    OnSelectedIndexChanged="gvSchedule_SelectedIndexChanged" OnRowEditing="gvSchedule_RowEditing">
                    <Columns>
                        <asp:BoundField DataField="LessonTitle" HeaderText="<%$ Resources:Dashboard,LessonTitle%>" />
                        <asp:BoundField DataField="FullName" HeaderText="<%$ Resources:Dashboard,TeacherFName%>" />
                        <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Justify">
                            <HeaderTemplate>
                                شنبه
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text=""></asp:Label>
                            </ItemTemplate>

                            <%-- <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle"></ItemStyle>--%>

                            <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                یکشنبه
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                دو شنبه
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                سه شنبه
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                چهارشنبه
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                پنج شنبه
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                جمعه
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
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
                <%--</ContentTemplate>--%>
                <%--</asp:UpdatePanel>--%>

                <div class="extra" style="height: 100px">
                </div>
            </div>
        </div>
        <div class="extra" style="height: 100px">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>