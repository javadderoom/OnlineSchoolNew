<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Teacher/TeacherPanel.Master" AutoEventWireup="true" CodeBehind="TeacherPicture.aspx.cs" Inherits="WebPages.Dashboard.Teacher.TeacherPicture" %>

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
            <asp:Literal runat="server" Text="<%$ Resources:Dashboard,change_picture%>" /></h4>
    </div>
    <div class="c-content">
        <%--<div id="demo-form2" class="form-horizontal form-label-right">--%>
        <div class="col-md-6 col-md-offset-3 col-xs-12">
            <div id="ContentPlaceHolder1_upWait">

                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 text-center">

                            <img id="imgUserPic" class="img-responsive center-margin" runat="server" src="" style="height: 100px; width: 100px;" />
                        </div>
                    </div>
                </div>
                <div class="ln_solid"></div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-2 col-sm-push-10 text-right">
                            <span id="ContentPlaceHolder1_lblCoverPhoto" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Dashboard,img_file%>" /></span><asp:FileUpload ID="FileUpload1" runat="server" BackColor="#CCCCCC" />
                        </div>

                        <div class="col-xs-12 col-sm-10 col-sm-pull-2 text-right">

                            <asp:Button ID="btnSabtEditProfile" name="btnSabt" class="btn btn-info" runat="server"
                                Text="<%$ Resources:Dashboard,select_img%>" OnClick="btnSabtEditProfile_Click" />
                        </div>
                    </div>
                </div>

                <div class="ln_solid"></div>
                <div class="form-group">
                    <div class="col-xs-12 text-right">
                        <asp:Button ID="Button1" name="btnSabt" class="btn btn-primary" runat="server"
                            Text="<%$ Resources:Dashboard,sabt%>" OnClick="Button1_Click" />
                    </div>
                </div>
                <div class="extra" style="height: 100px">
                </div>
            </div>
            <%--</div>--%>
        </div>
    </div>
</asp:Content>