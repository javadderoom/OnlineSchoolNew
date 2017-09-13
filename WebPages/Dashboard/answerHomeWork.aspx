<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="answerHomeWork.aspx.cs" Inherits="WebPages.Dashboard.answerHomeWork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="Styles/bootstrap.css" rel="stylesheet" />
    <link href="Styles/simple-sidebar.css" rel="stylesheet" />
    <link href="Styles/AdminPanelStyles.css" rel="stylesheet" />
    <link href="Styles/sasanStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="c-title">
        <h4>
            <asp:Literal runat="server" Text="تکلیف" />
        </h4>
    </div>
    <div class="form-group">
        <div class="row">

            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft" style="float: right">
                <span id="iii" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="تاریخ شروع" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblStartDate" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>
            <div class="col-xs-12 col-sm-3  text-right dirRight goLeft" style="float: right">
                <span id="yyy" class="control-label formLabel" style="color: #666666; font-size: 100%; font-weight: bold;">
                    <asp:Literal runat="server" Text="تاریخ پایان" /></span>
                <span class="fa fa-arrow-circle-down"></span>
                <br />
                <span runat="server" id="lblExpireDate" class="control-label formLabel" style="color: #0066CC; font-size: 100%; font-weight: bold;"></span>
            </div>

        </div>
    </div>


    <div class="ln_solid"></div>
    <div style="direction: rtl; display: block">
        <div>
            <asp:Label ID="Label2" runat="server" Text="توضیحات"></asp:Label>
        </div>

        <asp:TextBox ID="tbxDesc" runat="server" Width="700" Height="500" TextMode="MultiLine"></asp:TextBox>
    </div>
    <div class="ln_solid"></div>
    <div style="direction: rtl">
        <asp:Label ID="Label1" runat="server" Text="بارگذاری فایل :   "></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="فایل  با پسوند zip. بارگذاری کنید" ForeColor="Red"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>

    <div class="ln_solid"></div>
    <asp:Button ID="btnDownloadPre" runat="server" Text="دانلود فایل قبلی" CssClass="btnHomeWork" OnClick="btnDownloadPre_Click" />
    <%--<asp:Button ID="btnDownload" runat="server" Text="دانلود فایل مربوطه" CssClass="btnHomeWork" OnClick="btnDownload_Click" />--%>
    <asp:Button ID="btnAnswer" runat="server" Text="ارسال پاسخ" CssClass="btnHomeWork" OnClick="btnAnswer_Click" />
    <span style="float: right; margin-top: 10px;">
        <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
    </span>

    <div class="row">
        <div class="extra" style="height: 100px">
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
