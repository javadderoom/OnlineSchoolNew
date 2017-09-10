<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Teacher/TeacherPanel.Master" AutoEventWireup="true" CodeBehind="SessionHistory.aspx.cs" Inherits="WebPages.Dashboard.Teacher.SesionHistory" %>

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

            <asp:Literal runat="server" Text="<%$ Resources:HamoonResource,SessionHistory%>" />
        </h4>
    </div>
    <div class="c-content">
        <div id="demo-form2" class="form-horizontal form-label-right">
            <div class="col-md-12  col-xs-12">
                <div id="ContentPlaceHolder1_upGrid">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvSessionHistory" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
                                    AutoGenerateColumns="False"
                                    CssClass="dirRight table table-responsive" HorizontalAlign="Center" AllowPaging="True"
                                    EnableSortingAndPagingCallbacks="True" PageSize="5" OnRowCommand="gvSessionHistory_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="SessionID" HeaderText="<%$ Resources:Dashboard,ID%>" />
                                        <asp:BoundField DataField="Date" HeaderText="<%$ Resources:Dashboard,Date%>" />

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="Edid" runat="server"
                                                    CommandName="Edit"
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="<%$ Resources:Dashboard,edite%>" />

                                                <asp:Button ID="Details" runat="server"
                                                    CommandName="Details"
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="<%$ Resources:Dashboard,Details%>" />
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
                    </div>
                </div>
                <div class="extra" style="height: 100px">
                </div>
            </div>
        </div>
    </div>
</asp:Content>