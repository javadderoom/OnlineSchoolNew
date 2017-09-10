<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Teacher/TeacherPanel.Master" AutoEventWireup="true" CodeBehind="EditSession.aspx.cs" Inherits="WebPages.Dashboard.Teacher.EditSession" %>

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

            <asp:Literal runat="server" Text="<%$ Resources:Dashboard,EditSession%>" />
        </h4>
    </div>
    <div class="c-content">
        <div id="demo-form2" class="form-horizontal form-label-right">
            <div class="col-md-12  col-xs-12">
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-2 text-right dirRight goLeft">
                            <span id="ContentPlaceHolder1_Label6" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:HamoonResource,SessionDate%>" /></span>
                            <span class="fa fa-arrow-circle-down"></span>
                            <br />
                            <span runat="server" id="Span2" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;">
                                <asp:TextBox ID="tbxSessionDate" runat="server"></asp:TextBox></span>
                        </div>
                        <div class="col-xs-12 col-sm-2 text-right dirRight goLeft">
                            <span id="ContentPlaceHolder1_Label5" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:HamoonResource,StudentCount%>" /></span>
                            <span class="fa fa-arrow-circle-down"></span>
                            <br />
                            <span runat="server" id="Span1" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" ID="StudentCount" Text="" /></span>
                        </div>
                        <div class="col-xs-12 col-sm-2 text-right dirRight goLeft">
                            <span id="ContentPlaceHolder1_Label1" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:HamoonResource,LessonName%>" /></span>
                            <span class="fa fa-arrow-circle-down"></span>
                            <br />
                            <span runat="server" id="lblTeacherName" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" ID="LessonName" Text="" /></span>
                        </div>
                        <div class="col-xs-12 col-sm-2  text-right dirRight goLeft">
                            <span id="ContentPlaceHolder1_Label3" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:HamoonResource,ClassNumber%>" /></span>
                            <span class="fa fa-arrow-circle-down"></span>
                            <br />
                            <span runat="server" id="lblClass" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" ID="ClassNumber" Text="" /></span>
                        </div>
                        <div class="col-xs-12 col-sm-2  text-right dirRight goLeft">
                            <span id="ContentPlaceHolder1_Label4" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:HamoonResource,Grade%>" /></span>
                            <span class="fa fa-arrow-circle-down"></span>
                            <br />
                            <span runat="server" id="lblLesson" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" ID="Grade" Text="" /></span>
                        </div>
                        <div class="col-xs-12 col-sm-2  text-right dirRight goLeft">
                            <span id="ContentPlaceHolder1_Label2" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:HamoonResource,SessionNumber%>" /></span>
                            <span class="fa fa-arrow-circle-down"></span>
                            <br />
                            <span runat="server" id="lblStudentsCount" class="control-label formLabel" style="color: Green; font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" ID="SessionNumber" Text="" /></span>
                        </div>
                    </div>
                </div>

                <div class="ln_solid">
                </div>
                <div class="pull-left">
                    <asp:Button ID="btnSabt" CssClass="btn btn-primary" Width="40px" OnClick="btnSabt_Click" OnClientClick="if(!confirm('ایا مطمئن هستید؟')) return false;" runat="server" Text="<%$ Resources:Dashboard,sabt%>" />
                </div>
                <div id="ContentPlaceHolder1_upGrid">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvStudents" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False"
                                    CssClass="dirRight table table-responsive" HorizontalAlign="Center" AllowPaging="True" EnableSortingAndPagingCallbacks="True" PageSize="5">
                                    <Columns>
                                        <asp:BoundField DataField="OzviatID" HeaderText="<%$ Resources:Dashboard,ID%>" />
                                        <asp:BoundField DataField="StudentCode" HeaderText="<%$ Resources:Dashboard,StudentCode%>" />
                                        <asp:BoundField DataField="FirstName" HeaderText="<%$ Resources:Dashboard,name%>" />
                                        <asp:BoundField DataField="LastName" HeaderText="<%$ Resources:Dashboard,family%>" />

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="pull-right">
                                                    <asp:TextBox ID="Score" runat="server"></asp:TextBox>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" Text="<%$ Resources:Dashboard,Score%>" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="pull-right">
                                                    <span>
                                                        <asp:CheckBox ID="RowChBPeresece" runat="server" /></span>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" Text="<%$ Resources:HamoonResource,Present%>" />
                                                <asp:CheckBox ID="HeadChB" runat="server" OnCheckedChanged="HeadChB_CheckedChanged" AutoPostBack="true" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="pull-right">
                                                    <span>
                                                        <asp:CheckBox ID="RowChBisMovajjah" runat="server" /></span>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" Text="<%$ Resources:HamoonResource,movajah%>" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="pull-right">

                                                    <asp:TextBox ID="DescriptionTbx" runat="server" TextMode="MultiLine" CssClass="DescriptionTbx"></asp:TextBox>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" Text="<%$ Resources:HamoonResource,Description%>" />
                                            </HeaderTemplate>
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
                <div class="pull-left">
                    <asp:Button ID="btnSabt2" CssClass="btn btn-primary" Width="40px" OnClick="btnSabt2_Click" OnClientClick="if(!confirm('ایا مطمئن هستید؟')) return false;" runat="server" Text="<%$ Resources:Dashboard,sabt%>" />
                </div>

                <div class="extra" style="height: 100px">
                </div>
            </div>
        </div>
    </div>
</asp:Content>