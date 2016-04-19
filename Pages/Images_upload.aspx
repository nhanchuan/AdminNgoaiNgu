<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="Images_upload.aspx.cs" Inherits="Pages_Images_upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h3 class="page-title">Upload Hình ảnh <small>Images upload</small>
    </h3>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/ImagesManager.aspx">Thư viện</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/Images_upload.aspx">Images Upload</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <%--<asp:UpdatePanel runat="server">
            <ContentTemplate>--%>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Chọn danh mục hình</label>
                        <asp:DropDownList ID="dlImagesCategory" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlImagesCategory_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="col-lg-12" id="panelUpoadImages" style="display:none;" runat="server">
                    <div id="dZUpload" class="dropzone">
                        <div class="dz-default dz-message">
                            <img src="../libs/DropzoneJs_scripts/spritemap@2x.png" style="width: 50%; height: 50%;" />
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <i>Bạn đang sử dụng ứng dụng tải lên hỗ trợ nhiều tập tin cùng lúc<strong> Tối đa 10 tập tin</strong>(F5 để làm mới Upload). Có lỗi? Hãy thử chuyển sang tải lên bằng trình duyệt. </i><a href="#modalUploadImages" class="btn green" data-toggle="modal"><i class="fa fa-upload"></i>Upload</a>
                </div>
            <%--</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="dlImagesCategory" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>--%>
    </div>
    <%-- Modal upload Images --%>
    <div class="modal fade" id="modalUploadImages" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Upload Images</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-default">
                        <div class="panel-body">
                            <p>
                                You can upload JPG, GIF, or PNG file. Maximum file size is 4MB.
                            </p>
                            <asp:FileUpload ID="FileImgUpload" CssClass="form-control" onchange="previewFile()" runat="server" />
                            <asp:RequiredFieldValidator ErrorMessage="Required"
                                ControlToValidate="FileImgUpload" ValidationGroup="validFileImgUpload"
                                runat="server" Display="Dynamic" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationExpression="(.)+(.jpg|.gif|.png|.JPG|.GIF|.PNG)$"
                                ControlToValidate="FileImgUpload"
                                ValidationGroup="validFileImgUpload"
                                runat="server" ForeColor="Red"
                                ErrorMessage="Please select a valid Images file !"
                                Display="Dynamic" />
                            <div class="clearfix"></div>
                            <div class="col-lg-4"></div>
                            <div class="col-lg-4">
                                <asp:Image ID="imgUpload" CssClass="img-responsive" runat="server" />
                            </div>
                            <div class="col-lg-4"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Hủy</a>
                    <asp:Button ID="btnUploadFile" ValidationGroup="validFileImgUpload" CssClass="btn btn-primary pull-right" OnClick="btnUploadFile_Click" runat="server" Text="Save !" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal upload Images --%>
    <script type="text/javascript">
        $(document).ready(function () {
            console.log("Hello");
            Dropzone.autoDiscover = true;
            //Simple Dropzonejs 
            $("#dZUpload").dropzone({
                url: "/Handler/hn_UploadImagesType.ashx",
                maxFiles: 10,
                addRemoveLinks: true,
                success: function (file, response) {
                    var imgName = response;
                    file.previewElement.classList.add("dz-success");
                    console.log("Successfully uploaded :" + imgName);
                },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });
        });
    </script>
    <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=imgUpload.ClientID %>');
            var file = document.querySelector('#<%=FileImgUpload.ClientID %>').files[0];
            var reader = new FileReader();
            <%--document.getElementById('<%=HiddenUploadimg.ClientID %>').value = "";
            document.getElementById('<%=txtTenAnh.ClientID %>').value = "Image tag name";--%>
            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
    </script>
</asp:Content>

