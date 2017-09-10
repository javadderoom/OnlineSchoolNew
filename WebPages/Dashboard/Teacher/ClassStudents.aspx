<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Teacher/TeacherPanel.Master" AutoEventWireup="true" CodeBehind="ClassStudents.aspx.cs" Inherits="WebPages.Dashboard.Teacher.ClassStudents" %>

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
    <div class="c-title">
        <h4>

            <asp:Literal runat="server" Text="<%$ Resources:Dashboard,students%>" />
        </h4>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div id="ContentPlaceHolder1_upGrid">

        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvClassStudents" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False"
                        CssClass="dirRight table" HorizontalAlign="Center" AllowPaging="True" EnableSortingAndPagingCallbacks="True" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="OzviatID" HeaderText="<%$ Resources:Dashboard,ID%>" />
                            <asp:BoundField DataField="StudentCode" HeaderText="<%$ Resources:Dashboard,StudentCode%>" />
                            <asp:BoundField DataField="FirstName" HeaderText="<%$ Resources:Dashboard,name%>" />
                            <asp:BoundField DataField="LastName" HeaderText="<%$ Resources:Dashboard,family%>" />
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