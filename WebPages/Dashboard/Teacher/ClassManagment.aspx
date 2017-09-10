<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Teacher/TeacherPanel.Master" AutoEventWireup="true" CodeBehind="ClassManagment.aspx.cs" Inherits="WebPages.Dashboard.Teacher.ClassManagment" %>

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

            <asp:Literal runat="server" Text="<%$ Resources:Dashboard,ClassManagment%>" />
        </h4>
    </div>
    <div id="ContentPlaceHolder1_upGrid">
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <asp:GridView ID="gvClasses" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                        ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" CssClass="dirRight table" HorizontalAlign="Center" AllowCustomPaging="True" AllowPaging="True" OnRowCommand="gvClasses_RowCommand" OnSelectedIndexChanged="gvClasses_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="LGID" HeaderText="<%$ Resources:Dashboard,ID%>" />
                            <asp:BoundField DataField="Class" HeaderText="<%$ Resources:Dashboard,Class%>" />
                            <asp:BoundField DataField="LessonTitle" HeaderText="<%$ Resources:Dashboard,LessonTitle%>" />
                            <asp:BoundField DataField="GradeTitle" HeaderText="<%$ Resources:Dashboard,GradeTitle%>" />
                            <asp:BoundField DataField="Day" HeaderText="<%$ Resources:Dashboard,Day%>" />
                            <asp:BoundField DataField="Time" HeaderText="<%$ Resources:Dashboard,Time%>" />
                            <asp:BoundField DataField="Year" HeaderText="<%$ Resources:Dashboard,Year%>" />
                            <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Justify">
                                <ItemTemplate>
                                    <asp:Button ID="Students" CssClass="StudentsButton" Width="115px" runat="server"
                                        CommandName="Students"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                        Text="<%$ Resources:Dashboard,students%>" />

                                    <asp:Button ID="SesionHistory" Width="80px" runat="server"
                                        CommandName="SessionHistory"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                        Text="<%$ Resources:HamoonResource,SessionHistory%>" />

                                    <asp:Button ID="NewSesion" CssClass="StudentsButton" Width="80px" runat="server"
                                        CommandName="NewSession"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                        Text="<%$ Resources:HamoonResource,NewSession%>" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
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
        </div>
    </div>
    <div class="extra" style="height: 100px">
    </div>
</asp:Content>