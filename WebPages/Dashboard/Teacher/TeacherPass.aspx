<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Teacher/TeacherPanel.Master" AutoEventWireup="true" CodeBehind="TeacherPass.aspx.cs" Inherits="WebPages.Dashboard.Teacher.TeacherPass" %>

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
    <div class="x_panel">
        <div class="c-title">
            <h4>
                <asp:Literal runat="server" Text="<%$ Resources:Dashboard,kartabl%>" />
                <small>
                    <asp:Literal runat="server" Text="<%$ Resources:Dashboard,change_password%>" /></small></h4>

            <div class="clearfix"></div>
        </div>

        <div class="c-content">
            <div id="demo-form2" class="form-horizontal form-label-right">
                <div class="col-md-6 col-md-offset-3 col-xs-12">
                    <div id="ContentPlaceHolder1_upWait">

                        <div class="form-group">
                            <div class="row">
                                <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                    *
                                        <span id="ContentPlaceHolder1_lblCurrentPassword" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text="<%$ Resources:Dashboard,c_password%>" /></span>
                                </div>

                                <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                    <input name="ctl00$ContentPlaceHolder1$tbxCurrentPassword" runat="server" type="password" maxlength="20" id="tbxCurrentPassword" class="form-control text-right dirRight" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                    *
                                        <span id="ContentPlaceHolder1_lblNewPassword" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text="<%$ Resources:Dashboard,n_password%>" /></span>
                                </div>

                                <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                    <input name="ctl00$ContentPlaceHolder1$tbxNewPassword" type="password" maxlength="20" runat="server" id="tbxNewPassword" class="form-control text-right dirRight" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                    *
                                        <span id="ContentPlaceHolder1_lblConfirmNewPassword" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text="<%$ Resources:Dashboard,tn_password%>" /></span>
                                </div>

                                <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                    <input name="ctl00$ContentPlaceHolder1$tbxConfirmNewPassword" type="password" maxlength="20" runat="server" id="tbxConfirmNewPassword" class="form-control text-right dirRight" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="ln_solid"></div>
                    <div class="form-group">
                        <div class="col-xs-12 text-right">
                            <button type="button" class="btn btn-success" runat="server" data-toggle="modal" data-target="#modalAskSubmitUpdate">
                                <asp:Literal runat="server" Text="<%$ Resources:Dashboard,sabt%>" />
                                <span class="fa fa-check"></span>
                            </button>
                        </div>

                        <div class="modal fade" id="modalAskSubmitUpdate" tabindex="-1" role="dialog" aria-labelledby="modalAskSubmitUpdate-label" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                        <h4 class="modal-title" id="modalAskSubmitUpdate-label">هشدار

                                                    <span class="glyphicon glyphicon-warning-sign"></span>
                                        </h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>
                                            <asp:Literal runat="server" Text="<%$ Resources:Dashboard,AreUSure%>" />
                                        </p>
                                    </div>
                                    <div class="modal-footer">
                                        <div class="row">
                                            <div class="col-xs-12 text-center">
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">
                                                    <asp:Literal runat="server" Text="<%$ Resources:Dashboard,No%>" />
                                                </button>

                                                <input type="submit" name="ctl00$ContentPlaceHolder1$btnSubmit" value="<%$ Resources:Dashboard,Yes%>" runat="server" onserverclick="btnSubmit_ServerClick" onclick="$('#modalAskSubmitUpdate').hide();" id="btnSubmit" class="btn btn-primary" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="extra" style="height: 100px">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>