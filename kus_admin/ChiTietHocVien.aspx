<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="ChiTietHocVien.aspx.cs" Inherits="kus_admin_ChiTietHocVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <link href="../App_Themes/admin/postnew.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thông Tin Học Viên <asp:Label ID="lbltitleHocVien" runat="server" Text="Label"></asp:Label>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>Quản lý Học phí
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/ChiTietHocVien.aspx">Học Viên Info</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-12 text-center">
            <h1 class="bold" style="color: #0094ff;">THÔNG TIN CHI TIẾT HỌC VIÊN</h1>
        </div>
        <div class="clearfix"></div>
        <div class="col-lg-2">
            <div class="panel panel-info">
                <div class="panel-body">

                    <asp:TextBox ID="txtPostImgTemp" CssClass="form-control display-none" runat="server"></asp:TextBox>
                    <img src="../images/default_images.jpg" id="imgCusprofile" class="img-responsive" runat="server" />

                    <br />
                    <a href="#" id="clearImg" class="btn red"><i class="fa fa-remove"></i></a>
                    <a class="btn green" href="#coluploadEditImges" data-toggle="collapse"><i class="fa fa-upload"></i></a>
                    <a class="btn blue" href="#modalPostImages" data-toggle="modal"><i class="fa fa-folder-open"></i></a>
                    <div class="clearfix"></div>
                    <br />
                    <div class="row">
                        <div class="col-lg-12">
                            <%-- Collapse Upload Images --%>
                            <div id="coluploadEditImges" class="panel-collapse collapse">

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
                            <%-- End Collapse Upload Images --%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-10">
            <div class="col-lg-6">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label">Họ (*)</label>
                            <asp:TextBox ID="txtLastNameHV" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLastNameHV" ValidationGroup="validGhiDanhHV" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Họ không được để trống !"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label">Tên (*)</label>
                            <asp:TextBox ID="txtFirstNameHV" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtFirstNameHV" ValidationGroup="validGhiDanhHV" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Tên không được để trống !"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label">Ngày sinh</label>
                            <%-- Date picker --%>
                            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                <asp:TextBox ID="txtNgaySinh" CssClass="form-control" runat="server"></asp:TextBox>
                                <span class="input-group-btn">
                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                            <%-- Date picker --%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtNgaySinh" ValidationGroup="validGhiDanhHV" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Ngày sinh không được để trống !"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label">Nơi sinh</label>
                            <asp:TextBox ID="txtNoiSinhHV" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label">Số CMND</label>
                            <asp:TextBox ID="txtSoCMNDHV" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label">Ngày cấp</label>
                            <%-- Date picker --%>
                            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                <asp:TextBox ID="txtNgayCapCMND" CssClass="form-control" runat="server"></asp:TextBox>
                                <span class="input-group-btn">
                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                            <%-- Date picker --%>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label">Nơi cấp</label>
                            <asp:TextBox ID="txtNoiCapCMND" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label">Giới tính (*)</label>
                            <div class="radio-list">
                                <label class="radio-inline">
                                    <input type="radio" name="optionsRadios" id="rdformnam" value="option1" runat="server" />
                                    Nam
                                </label>
                                <label class="radio-inline">
                                    <input type="radio" name="optionsRadios" id="rdformnu" value="option2" runat="server" />
                                    Nữ
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label class="control-label">Địa chỉ thường trú</label>
                            <asp:TextBox ID="txtDCThuongTru" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label class="control-label">Địa chỉ tạm trú</label>
                            <asp:TextBox ID="txtDCTamTru" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label">Email</label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                ControlToValidate="txtEmail"
                                ValidationGroup="validGhiDanhHV"
                                ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                Display="Dynamic" ForeColor="Red"
                                ErrorMessage="E-mail không hợp lệ ! { Ví dụ hợp lệ: abc@gmail.com }">
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label">Điện thoại</label>
                            <asp:TextBox ID="txtPhoneHV" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPhoneHV" ValidationGroup="validGhiDanhHV" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Điện thoại không được để trống !"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                ControlToValidate="txtPhoneHV"
                                ValidationGroup="validGhiDanhHV"
                                ValidationExpression="\(?([0-9]{3,4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})"
                                ErrorMessage="<%$Resources:Resource, incorectphonenumber %>"
                                ForeColor="Red"
                                Display="Dynamic">
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label">Họ tên phụ huynh</label>
                    <asp:TextBox ID="txtHoTenPH" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label">Nghề Nghiệp</label>
                    <asp:TextBox ID="txtNgheNghiepPH" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label">Điện thoại phụ huynh</label>
                    <asp:TextBox ID="txtDienThoaiPH" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- More Info --%>
            <div class="col-lg-6">
                <h3>Thông tin thêm</h3>
                <div class="form-group">
                    <label class="control-label">Học viên giới thiệu</label>
                    <asp:TextBox ID="txtHVGioiThieu" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label">Trình độ học vấn</label>
                    <div class="radio-list">
                        <label class="radio-inline">
                            <input type="radio" id="chkMauGiao" runat="server" />
                            Mẫu giáo
                        </label>
                        <label class="radio-inline">
                            <input type="radio" id="chkTieuHoc" runat="server" />
                            Tiểu học
                        </label>
                        <label class="radio-inline">
                            <input type="radio" id="chkTHCS" runat="server" />
                            Trung học cơ sở
                        </label>
                        <label class="radio-inline">
                            <input type="radio" id="chkTHPT" runat="server" />
                            Trung học phổ thông
                        </label>
                        <label class="radio-inline">
                            <input type="radio" id="chkDH" runat="server" />
                            Đại Học - Cao Đẳng
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label">Tên trường</label>
                    <asp:TextBox ID="txtTenTruong" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label">Chứng chỉ Tiếng Anh</label>
                    <div class="checkbox-list">
                        <label class="checkbox-inline">
                            <input type="checkbox" id="chkCC1" runat="server" />
                            Starters
                        </label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="chkCC2" runat="server" />
                            Movers
                        </label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="chkCC3" runat="server" />
                            Flyers
                        </label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="chkCC4" runat="server" />
                            KET
                        </label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="chkCC5" runat="server" />
                            PET
                        </label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="chkCC6" runat="server" />
                            FCE
                        </label>
                        <label class="checkbox-inline">
                            <%--<input type="checkbox" id="chk7" runat="server" />--%>
                            <%--<asp:CheckBox ID="chk7" runat="server" />--%>
                            <a href="#collapCCKHac" data-toggle="collapse">
                                <i class="fa fa-file-o"></i>
                                Khác
                            </a>
                        </label>
                    </div>
                </div>
                <div class="form-group panel-collapse collapse" id="collapCCKHac">
                    <label class="control-label">Tên C/C khác</label>
                    <asp:TextBox ID="txtCCKHac" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label">Biết trung tâm qua</label>
                    <div class="checkbox-list">
                        <label class="checkbox-inline">
                            <input type="checkbox" id="chkBTT1" runat="server" />
                            Báo chí
                        </label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="chkBTT2" runat="server" />
                            Internet
                        </label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="chkBTT3" runat="server" />
                            Bạn bè
                        </label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="chkBTT4" runat="server" />
                            Website
                        </label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="chkBTT5" runat="server" />
                            Trực tiếp tại trung tâm
                        </label>
                        <label class="checkbox-inline">
                            <a href="#collapBTTKHac" data-toggle="collapse">
                                <i class="fa fa-file-o"></i>
                                Khác
                            </a>
                        </label>
                    </div>
                </div>
                <div class="form-group panel-collapse collapse" id="collapBTTKHac">
                    <label class="control-label">Ngồn khác</label>
                    <asp:TextBox ID="txtBTTKHac" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label">Ghi chú</label>
                    <asp:TextBox ID="txtGhiChu" CssClass="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                </div>
                <hr />
                <div class="form-group">
                    <label>Tình trạng : </label>
                    <asp:DropDownList ID="dlTinhtrangHocVien" Enabled="false" runat="server">
                        <asp:ListItem Value="1">Đang học</asp:ListItem>
                        <asp:ListItem Value="0">Ngưng học</asp:ListItem>
                    </asp:DropDownList>
                    <a id="btnEnableTT" class="label label-default" title="Enable to edit" onserverclick="btnEnableTT_ServerClick" runat="server"><i class="fa fa-asterisk"></i></a>
                </div>
            </div>
            <%-- End More Info --%>
            <div class="clearfix"></div>
            <div class="col-lg-12 text-right">
                <a id="btnUpdateInfor" class="btn green" onserverclick="btnUpdateInfor_ServerClick" runat="server"><i class="fa fa-save"></i> LƯU THÔNG TIN</a>
            </div>
        </div>
    </div>

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
                                                                        <h4>Upload by <i style="color: red;"><%# Eval("UserName") %></i></h4>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtImgUrl" ValidationGroup="vlidSelectImage" ErrorMessage="No Image Selected !" Display="None"></asp:RequiredFieldValidator>
                                <%-- end info --%>
                            </div>
                    <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Hủy</a>
                    <asp:Button ID="btnchangeImgCusPro" CssClass="btn btn-primary pull-right" OnClick="btnchangeImgCusPro_Click" validationgroup="vlidSelectImage" runat="server" Text="Save !" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Post Images --%>
    <script>
        $(document).ready(function () {
            $("#clearImg").click(function () {
                var urlNoimg = "../images/default_images.jpg";
                $("#ContentPlaceHolder1_imgCusprofile").attr("src", urlNoimg);
                $("#ContentPlaceHolder1_txtPostImgTemp").val("");
            });
        });
         function showanh(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=ImagesSelect.ClientID %>').src = url;
            document.getElementById('<%=HiddenimgSelect.ClientID %>').value = url;
            document.getElementById('<%=txtImgUrl.ClientID %>').value = url;
            return false;
        }
    </script>

</asp:Content>

