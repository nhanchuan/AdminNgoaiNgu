<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="VideoEditInfo.aspx.cs" Inherits="Pages_VideoEditInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .btn-primaryright {
        margin-right:5%;
        }

    </style>
    <!-- BEGIN PAGE HEADER-->
    <h3 class="page-title">Chỉnh sửa Thông tin Video <small>video editing</small>
    </h3>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">Media Library</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/VideoEditInfo.aspx">Videos Edit</a>
            </li>
        </ul>
        <div class="page-toolbar">
            <div id="dashboard-report-range" class="pull-right tooltips btn btn-fit-height grey-salt" data-placement="top" data-original-title="Change dashboard date range">
                <i class="icon-calendar"></i>&nbsp;
						<span class="thin uppercase visible-lg-inline-block">&nbsp;</span>&nbsp;
						<i class="fa fa-angle-down"></i>
            </div>
        </div>
    </div>
    <!-- END PAGE HEADER-->
   
        <div class="row">
            <hr />
            <div class="clearfix"></div>
            <div class="col-lg-7">
                <a class="player" style="height: 500px; width: 100%; display: block;" id="videoplayer" runat="server"></a>
                <div class="clearfix"></div>
                <br />
                <div class="form-group">
                    <label class="control-label">Video Name</label>
                    <asp:TextBox ID="txtvideoname" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtvideoname" ValidationGroup="validFilevideoEdit" runat="server" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="control-label">Video Category</label>
                    <asp:DropDownList ID="dlvideoType" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label class="control-label">Short Description</label>
                    <asp:TextBox ID="txtshortdescription" CssClass="form-control" TextMode="MultiLine"  Rows="4" runat="server"></asp:TextBox>
                    <i>Mô tả ngắn cho đoạn video (Không quá 200 ký tự)</i>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtshortdescription" Display="Dynamic" ForeColor="Red" ValidationGroup="validFilevideoEdit" ValidationExpression="(.){0,200}" runat="server" ErrorMessage="Mô tả ngắn không quá 200 ký tự !"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="col-lg-5">
                <div class="panel panel-default">
                    <div class="panel-heading">Lưu thay đổi</div>
                    <div class="panel-body">
                        <div class="form-group">
                            <i class="fa fa-calendar-o"></i>
                            <label class="control-label">Được tải lên vào :  </label>
                            <asp:Label ID="lbldateupload" CssClass="bold" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="form-group">
                            <i class="fa fa-user"></i>
                            <label class="control-label">Upload bởi :  </label>
                            <asp:Label ID="lbluserupload" CssClass="bold" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Tên Tập tin :  </label>
                            <asp:Label ID="lblfilename" CssClass="bold" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Loại tập tin: </label>
                            <asp:Label ID="lblfiletype" CssClass="bold" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Dung lượng tệp: </label>
                            <asp:Label ID="lblfilesize" CssClass="bold" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Liên Kết Tới Tập Tin:</label>
                            <asp:TextBox ID="txtlinkFileVideo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="row">
                            <a style="margin-left: 5%;" id="btndownload" runat="server"><i class="fa fa-download"></i> Download video</a> | <a style="color:red;">Xóa vĩnh viễn</a>
                            <asp:Button ID="btnUpdate" ValidationGroup="validFilevideoEdit"  CssClass="btn btn-primary pull-right btn-primaryright" OnClick="btnUpdate_Click" runat="server" Text="Cập nhật" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    

    <script src="../libs/FlowPlayer/flowplayer-3.2.12.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        flowplayer("a.player", "../libs/FlowPlayer/flowplayer-3.2.16.swf", {
            plugins: {
                pseudo: { url: "../libs/FlowPlayer/flowplayer.pseudostreaming-3.2.12.swf" }
            },
            clip: { provider: 'pseudo', autoPlay: false },
        });
    </script>
</asp:Content>

