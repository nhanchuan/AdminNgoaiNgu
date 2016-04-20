<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="GhiDanhHocVien.aspx.cs" Inherits="kus_admin_GhiDanhHocVien" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Ghi Danh Học Viên - Khóa học đang chọn
        <asp:Label ID="lblKhoaHocChose" CssClass="bold" runat="server"></asp:Label>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/GhiDanhHocVien.aspx">Ghi danh học viên</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <!-- BEGIN Portlet PORTLET-->
        <div class="portlet light">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-info font-yellow-casablanca"></i>
                    <span class="caption-subject bold font-yellow-casablanca uppercase">Thông tin khóa học </span>
                    <span class="caption-helper"></span>
                </div>

                <div class="actions">
                    <a id="btnRefreshLstKhoaHoc" class="btn btn-circle btn-icon-only btn-default" title="Làm mới danh sách" runat="server" href="#">
                        <i class="fa fa-refresh"></i>
                    </a>
                    <a class="btn btn-circle btn-icon-only btn-default fullscreen" href="#"></a>
                </div>
            </div>
            <div class="portlet-body">
                <div class="form-horizontal">
                    <div class="form-body">
                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Tên khóa học</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtETenKhoaHoc" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtETenKhoaHoc" ValidationGroup="validUpdateKhoaHoc" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên khóa học không được để trống !"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Ngày khai giảng</label>
                                    <div class="col-md-8">
                                        <%-- Date picker --%>
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <asp:TextBox ID="txtENgayKhaiGiang" CssClass="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                        </div>
                                        <%-- Date picker --%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Số lượng học viên</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtESoLuong" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Ngày kết thúc</label>
                                    <div class="col-md-8">
                                        <%-- Date picker --%>
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <asp:TextBox ID="txtENgayKetThuc" CssClass="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                        </div>
                                        <%-- Date picker --%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Thời lượng <i>(tiết)</i></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtEThoiLuong" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <%-- /Row --%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Thuộc loại chương trình</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="dlELoaiChuongTrinh" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Hệ thống chi nhánh</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="dlEHTChiNhanh" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- /Row --%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Thuộc chương trình</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="dlEChuongTrinh" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Thuộc Cơ Sở</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="dlECoSo" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Thuộc lớp</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="dlELopHoc" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4"></label>
                                            <div class="col-md-8"></div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <%-- END Portlet PORTLET --%>
    </div>
    <div class="row">
        <div class="col-lg-3">
            <div class="form-group">
                <label class="control-label"><i class="fa fa-graduation-cap"></i> Thông tin học viên</label>
                <asp:DropDownList ID="dlChoseLoaiGD" AutoPostBack="true" OnSelectedIndexChanged="dlChoseLoaiGD_SelectedIndexChanged" CssClass="form-control" runat="server">
                    <asp:ListItem Value="0">Học Viên chưa đăng ký</asp:ListItem>
                    <asp:ListItem Value="1">Học Viên đã học</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row" id="panelGhiDanhMoi" runat="server">
        <div class="panel panel-info background">
            <div class="panel-body">
                <h2>THÔNG TIN GHI DANH</h2>

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
                </div>
                <%-- End More Info --%>
            </div>
            <div class="col-lg-12">
                <div class="form-group">
                    <label class="control-label bold"><span class="required">Số tiền Đặt cọc trước (VND): </span></label>
                    <asp:TextBox ID="txtDatCoc" CssClass="form-control bold" ForeColor="Red" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtDatCoc" ValidationGroup="validGhiDanhHV" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Chỉ được nhập số !"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <asp:Button ID="btnAddNewHV" CssClass="btn btn-primary" ValidationGroup="validGhiDanhHV" OnClick="btnAddNewHV_Click" runat="server" Text="LƯU THÔNG TIN" />
            </div>

        </div>
    </div>
    <div class="row" id="panelDaGhiDanh" runat="server">
        <div class="col-lg-4">
            <div class="form-group">
                <label class="control-label">Mã Học Viên : <span class="required">*</span></label>
                <asp:TextBox ID="txtHocVienCode" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:AutoCompleteExtender ID="AutoCompleteExtender1"
                    TargetControlID="txtHocVienCode"
                    MinimumPrefixLength="2"
                    CompletionInterval="10"
                    EnableCaching="false"
                    CompletionSetCount="10"
                    FirstRowSelected="false"
                    ServiceMethod="SearchHocVienCode"
                    runat="server">
                </asp:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtHocVienCode"
                    ValidationGroup="validGDHVAvailable" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Mã Học Viên không để trống !"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label class="control-label">Ghi chú : </label>
                <asp:TextBox ID="txtGhiChuAvailable" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>

            </div>
            <div class="form-group">
                <label class="control-label bold"><span class="required">Số tiền Đặt cọc trước (VND): </span></label>
                <asp:TextBox ID="txtDatCocAvailable" CssClass="form-control bold" ForeColor="Red" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtDatCocAvailable"
                    ValidationGroup="validGDHVAvailable" ValidationExpression="^\d+$" ForeColor="Red"
                    Display="Dynamic" runat="server" ErrorMessage="Chỉ được nhập số !"></asp:RegularExpressionValidator>
            </div>
            <asp:Button ID="btnGhiDanhAvailalble" CssClass="btn btn-primary" ValidationGroup="validGDHVAvailable" OnClick="btnGhiDanhAvailalble_Click" runat="server" Text="GHI DANH LỚP HỌC" />
        </div>
    </div>
</asp:Content>

