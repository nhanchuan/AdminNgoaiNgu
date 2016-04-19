<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="Post-Update.aspx.cs" Inherits="Pages_Post_Update" %>
<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../assets/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="../App_Themes/admin/postnew.css" rel="stylesheet" />
        <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Cập Nhật Bài Viết <small>Post Update</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/Post-All.aspx">Bài viết</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/Post-Update.aspx">Cập nhật bài viết</a>
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
        <div class="col-lg-9">
            <div class="form-group">
                <label class="control-label"><strong>Tiêu đề bài viết</strong></label>
                <input id="txtPostTitle" type="text" class="form-control" placeholder="Nhập tiêu đề tại đây" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtPostTitle" ValidationGroup="validNewPost" runat="server" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtPostTitle" ForeColor="Red" Display="Dynamic" ValidationGroup="validNewPost" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Tên từ 0-200 ký tự !"></asp:RegularExpressionValidator>
            </div>
            <%-- Tags Content --%>
            <div class="tabbable-custom ">
                <ul class="nav nav-tabs ">
                    <li class="active">
                        <a href="#tab_content_vi" data-toggle="tab">Content VN </a>
                    </li>
                    <li>
                        <a href="#tab_content_en" data-toggle="tab">Content EN </a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="tab_content_vi">
                        <%--  --%>
                        <CKEditor:CKEditorControl ID="EditorPostContentVN" runat="server"
                            Toolbar="Full"
                            Height="800px"
                            ContentsLangDirection="Ui"
                            DialogButtonsOrder="OS"
                            EnterMode="BR"
                            ResizeDir="Both"
                            ShiftEnterMode="P"
                            StartupMode="Wysiwyg" Language="vi"
                            ToolbarLocation="Top">
                        </CKEditor:CKEditorControl>
                    </div>
                    <div class="tab-pane" id="tab_content_en">
                        <%--  --%>
                        <CKEditor:CKEditorControl ID="EditorPostContentEN" runat="server"
                            Toolbar="Full"
                            Height="800px"
                            ContentsLangDirection="Ui"
                            DialogButtonsOrder="OS"
                            EnterMode="BR"
                            ResizeDir="Both"
                            ShiftEnterMode="P"
                            StartupMode="Wysiwyg" Language="en"
                            ToolbarLocation="Top">
                        </CKEditor:CKEditorControl>
                    </div>
                </div>
            </div>
            <%-- End Tags Content --%>
            <hr />
        </div>
        <div class="col-lg-3">
            <div class="panel-group accordion" id="accordion3">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a class="accordion-toggle accordion-toggle-styled" data-toggle="collapse" href="#collapse_3_1"><i class="fa fa-calendar"></i>Đăng bài viết</a>
                        </h4>
                    </div>
                    <div id="collapse_3_1" class="panel-collapse collapse in">
                        <div class="panel-body">
                            <div class="inline">
                                <asp:Button ID="Button1" CssClass="btn btn-default pull-left" runat="server" Text="Lưu nháp" />
                                <asp:Button ID="Button2" CssClass="btn btn-default pull-right" runat="server" Text="Xem thử" />
                            </div>
                            <div class="clearfix"></div>
                            <br />
                            <div class="form-group">
                                <i class="fa fa-key"></i>
                                <label>Trạng thái:</label>&nbsp<strong><asp:Label ID="lblpost_status" runat="server" Text="Bản nháp"></asp:Label></strong><a href="#poststatus" data-toggle="collapse"> Chỉnh sửa</a>
                                <%--  --%>
                                <div id="poststatus" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <div class="input-icon">
                                                    <i class="fa fa-twitch"></i>
                                                    <asp:DropDownList ID="dlpost_status" CssClass="form-control" runat="server">
                                                        <asp:ListItem Value="0">Bản nháp</asp:ListItem>
                                                            <asp:ListItem Value="1">Chờ xét duyệt</asp:ListItem>
                                                            <asp:ListItem Value="2">Đã đăng</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="input-group-btn">
                                                    <button id="btnChangepost_status" class="btn btn-success" type="button" onserverclick="btnChangepost_status_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i>OK</button>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--  --%>
                            </div>
                            <div class="form-group">
                                <i class="fa fa-calendar-o"></i>
                                <label>Đăng: </label>
                                &nbsp<strong><asp:Label ID="lblTimePost" runat="server" Text="Ngay lập tức"></asp:Label></strong><a href="#DatetimePost" data-toggle="collapse" id="TimepostClick" runat="server"> Chỉnh sửa</a>
                                <%-- Datetime picker --%>
                                <div id="DatetimePost" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="timePost" ValidationGroup="validtimepost" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                        <div class="form-group">
                                            <div class="input-group date form_meridian_datetime input-large">
                                                <input type="text" size="16" class="form-control" id="timePost" runat="server" />
                                                <span class="input-group-btn">
                                                    <button class="btn default date-reset" type="button"><i class="fa fa-times"></i></button>
                                                </span>
                                                <span class="input-group-btn">
                                                    <button class="btn default date-set" type="button"><i class="fa fa-calendar"></i></button>
                                                </span>
                                            </div>
                                            <br />
                                            <asp:Button ID="btnUpdateTimePost" CssClass="btn green pull-right" ValidationGroup="validtimepost" OnClick="btnUpdateTimePost_Click" runat="server" Text="Update Time" />
                                        </div>
                                    </div>
                                </div>
                                <%-- End Datetime picker --%>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="panel-body">
                                <div class="inline">
                                    <a class="pull-left" style="color: red;">Bỏ vào thùng rác</a>
                                    <asp:Button ID="btnPostUpdate" CssClass="btn btn-primary pull-right" ValidationGroup="validNewPost" OnClick="btnPostUpdate_Click" runat="server" Text="Cập nhật bài viết" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" href="#collapse_3_2"><i class="fa fa-reorder"></i>Chuyên mục </a>
                        </h4>
                    </div>
                    <div id="collapse_3_2" class="panel-collapse collapse">
                        <div class="panel-body" style="height: 500px; overflow-y: auto;">
                            <div class="form-control height-auto">
                                <div class="scroller" style="height: 420px; overflow-x: scroll;" data-always-visible="1">
                                    <%--<asp:CheckBoxList ID="chkblCategory" runat="server">
                                        </asp:CheckBoxList>--%>
                                    <asp:TreeView ID="treeboxCategory" OnTreeNodePopulate="treeboxCategory_TreeNodePopulate" runat="server" ShowExpandCollapse="true" PopulateNodesFromClient="true" ShowLines="true" ExpandDepth="2" ShowCheckBoxes="All"></asp:TreeView>
                                </div>
                            </div>
                            <a href="#newcategory" data-toggle="modal"><i class="fa fa-list"></i>Thêm nhanh chuyên mục</a>
                        </div>
                    </div>
                </div>
                <%-- Meta tags --%>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a class="accordion-toggle accordion-toggle-styled" data-toggle="collapse" href="#collapse_meta_tags"><i class="fa fa-bookmark"></i>Meta Tags</a>
                        </h4>
                    </div>
                    <div id="collapse_meta_tags" class="panel-collapse collapse">
                        <div class="panel-body">
                            <div class="form-group">
                                <label class="control-label">Meta Keywords</label>
                                <asp:TextBox ID="txtMetaKeywords" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Meta Description</label>
                                <asp:TextBox ID="txtMetaDescription" TextMode="MultiLine" Rows="3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- End Meta tags --%>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" href="#collapse_3_3" id="tagsshowPanel" runat="server"><i class="fa fa-tags"></i>Thẻ </a>
                        </h4>
                    </div>
                    <div id="collapse_3_3" class="panel-collapse collapse">
                        <div class="panel-body">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="inline">
                                        <div class="input-icon">
                                            <i class="fa fa-tag"></i>
                                            <asp:TextBox ID="txttagsname" CssClass="form-control" onkeyup="document.getElementById('lblmultiTags').innerHTML = this.value" AutoPostBack="true" OnTextChanged="txttagsname_TextChanged" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <i>Phân cách với nhau bằng dấu (,)</i><br />
                                    <br />
                                    <%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%>
                                    <div id="lblmultiTags" class="label label-warning"></div>
                                    <asp:Label ID="lbltagsExsit" CssClass="label label-danger" runat="server"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="label label-danger" ControlToValidate="txttagsname" ValidationGroup="validTags" runat="server" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                    <%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%><%--  --%><%--  --%> <%--  --%>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txttagsname" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <br />
                            <asp:Button ID="btnAddTags" CssClass="btn btn-success pull-right" ValidationGroup="validTags" runat="server" OnClick="btnAddTags_Click" Text="Thêm Tags" />
                            <br />
                            <br />
                            <a>Chọn từ những thẻ được dùng nhiều nhất</a>
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <%-- CheckBoxList tags --%>
                                    <div class="scroller" style="height: 350px; overflow-x: scroll;" data-always-visible="1">
                                        <asp:CheckBoxList ID="cbltags" runat="server"></asp:CheckBoxList>
                                    </div>
                                    <%-- End CheckBoxList tags --%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" href="#collapse_3_4" id="panelUploadImg" runat="server"><i class="fa fa-picture-o"></i>Ảnh chức năng bài viết </a>
                        </h4>
                    </div>
                    <div id="collapse_3_4" class="panel-collapse collapse">
                        <div class="panel-body">
                            <asp:TextBox ID="txtPostImgTemp" CssClass="form-control display-none" runat="server"></asp:TextBox>
                            <div class="col-lg-2"></div>
                            <div class="col-lg-8">
                                <img id="imgpost" src="../images/default_images.jpg" class="img-responsive" runat="server" />
                            </div>
                            <div class="col-lg-2"></div>
                            <div class="clearfix"></div>
                            <br />
                            <div class="col-lg-12">
                                <div class="row">
                                    <a class="btn red" id="clearEditImg" runat="server"><i class="fa fa-refresh">Clear</i></a>
                                    <a class="btn green" href="#coluploadEditImges" data-toggle="collapse"><i class="fa fa-upload"></i>Tải lên</a>
                                    <a class="btn yellow" href="#modalPostImages" data-toggle="modal"><i class="fa fa-bank"></i>Chọn từ thư viện</a>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <br />
                            <%-- Collapse Upload Images --%>
                            <div id="coluploadEditImges" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <div class="input-icon">
                                                <i class="fa fa-file"></i>
                                                <asp:FileUpload ID="fileUploadImgPost" CssClass="form-control" runat="server" />
                                            </div>
                                            <span class="input-group-btn">
                                                <button id="btnuploadImg" class="btn btn-success" type="button" validationgroup="validfileUploadImgPost" onserverclick="btnuploadImg_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i>OK</button>
                                            </span>
                                        </div>
                                        <asp:RequiredFieldValidator ErrorMessage="Required"
                                            ControlToValidate="fileUploadImgPost" ValidationGroup="validfileUploadImgPost"
                                            runat="server" Display="Dynamic" ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.gif|.png)$"
                                            ControlToValidate="fileUploadImgPost"
                                            ValidationGroup="validfileUploadImgPost"
                                            runat="server" ForeColor="Red"
                                            ErrorMessage="Please select a valid Images file !"
                                            Display="Dynamic" />
                                    </div>
                                    <label>You can upload JPG, GIF, or PNG file. Maximum file size is 4MB.</label>
                                </div>
                            </div>
                            <%-- End Collapse Upload Images --%>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
      
     <!--MODAL Add new Categories-->
    <div id="newcategory" class="modal fade" tabindex="-1" role="dialog" aria-hidden="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">New Category</h4>
                </div>
                <div class="modal-body">
                    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="validCategory" DisplayMode="BulletList" ShowSummary="true" ForeColor="Red" runat="server" />
                    <label><strong>Category Name</strong></label>
                    <asp:TextBox ID="txtCategoryname" CssClass="form-control" runat="server"></asp:TextBox>
                    <i>Tên riêng sẽ hiển thị trên trang mạng của bạn.</i>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategoryname" ValidationGroup="validCategory" ErrorMessage="Please Enter Category Name !" Display="None"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtCategoryname" ForeColor="Red" Display="None" ValidationGroup="validCategory" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Tên từ 0-200 ký tự !"></asp:RegularExpressionValidator>
                     <br /><br />
                    <label><strong>Decription</strong></label>
                    <asp:TextBox ID="txtCategoryDecs" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                    <i>Mô tả bình thường không được sử dụng trong giao diện, tuy nhiên có vài trang hiện thị mô tả này.</i>
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn default">Cancel</button>
                    <%--<button type="button" data-dismiss="modal" class="btn green">Continue</button>--%>
                    <asp:Button ID="btninsertfastPC" CssClass="btn green" ValidationGroup="validCategory" OnClick="btninsertfastPC_Click" runat="server" Text="Continue" />
                </div>
            </div>
        </div>
    </div>
   <!--END MODAL Add new Categories-->
    <%-- Modal Post Images --%>
    <div class="modal fade" id="modalPostImages" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-full">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Select Images</h4>
                </div>
                <div class="modal-body background">
                    <div class="panel-default">
                        <div class="panel-body">
                            <div class="col-lg-9">
                        <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-4">
                                            <div class="panel-default">
                                                <div class="panel">
                                                    <asp:DropDownList ID="dlimgtype" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlimgtype_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div style="height: 700px; overflow: auto;">
                                                <div class="grid-container">
                                                    <ul class="rig columns-5">
                                                        <asp:Repeater ID="rpLstImg" runat="server">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <a href='<%#"../"+Eval("ImagesUrl") %>' onclick="return showanh(this.href)"">
                                                                        <img src='<%#"../"+Eval("ImagesUrl") %>' />
                                                                        <h4>Upload by <i style="color: red;"><%# Eval("UserUpload") %></i></h4>
                                                                        <p><%# Eval("ImagesName") %></p>
                                                                    </a>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                        </div>
                            <div class="col-lg-3">
                                <%-- info --%>
                                <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="vlidSelectImage" DisplayMode="BulletList" ShowSummary="true" ForeColor="Red" runat="server" />
                                <asp:Image ID="ImagesSelect" CssClass="img-responsive" runat="server" />
                                <br />
                                <asp:HiddenField ID="HiddenimgSelect" runat="server" />
                                <label>Url Image:</label>
                                <asp:TextBox ID="txtImgUrl" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtImgUrl" ValidationGroup="vlidSelectImage" ErrorMessage="No Image Selected !" Display="None"></asp:RequiredFieldValidator>
                                <%-- end info --%>
                            </div>
                    <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Hủy</a>
                    <asp:Button ID="btnchangeImgPost" CssClass="btn btn-primary pull-right" validationgroup="vlidSelectImage" OnClick="btnchangeImgPost_Click" runat="server" Text="Save !" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Post Images --%>

   <script type="text/javascript">
       function calltagspanelClickEvent() {
           document.getElementById('<%=tagsshowPanel.ClientID %>').click();
       }
   </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_clearEditImg").click(function () {
                var urlNoimg = "../images/No_image.png";
                $("#ContentPlaceHolder1_imgpost").attr("src", urlNoimg);
                $("#ContentPlaceHolder1_txtPostImgTemp").val("");
            });
        });
        function callImagesPanelClickEvent() {
            document.getElementById('<%=panelUploadImg.ClientID %>').click();
        }
        function calldropdownTimepostClickEvent() {
            document.getElementById('<%=TimepostClick.ClientID %>').click();
        }
        function showanh(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=ImagesSelect.ClientID %>').src = url;
            document.getElementById('<%=HiddenimgSelect.ClientID %>').value = url;
            document.getElementById('<%=txtImgUrl.ClientID %>').value = url;
            return false;
        }
    </script>
    <script src="../assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script src="../ckeditor/ckeditor.js"></script>
    <script src="../ckfinder/ckfinder.js"></script>
    <script type="text/javascript">
        var editor = CKEDITOR.replace('cke_top_ContentPlaceHolder1_EditorPostContent');
        CKFinder.setupCKEditor(editor, '/ckfinder/');
    </script>
</asp:Content>

