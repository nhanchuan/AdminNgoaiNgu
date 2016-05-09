<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="CapNhatThongTinKhachHang.aspx.cs" Inherits="QuanLyHoSo_CapNhatThongTinKhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <link href="../App_Themes/admin/postnew.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thông Tin Khách Hàng <small>CUSTOMER INFORMATION</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">QUẢN LÝ HỒ SƠ</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">Thông tin khách hàng</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-4">
            <div class="panel panel-info">
                <div class="panel-body">
                    <div id="chart_7" class="chart"></div>
                    <div class="well margin-top-20">
                        <div class="row">
                            <div class="col-sm-6">
                                <label class="text-left">Angle:</label>
                                <input class="chart_7_chart_input" data-property="angle" type="range" min="0" max="89" value="30" step="1" />
                            </div>
                            <div class="col-sm-6">
                                <label class="text-left">Depth:</label>
                                <input class="chart_7_chart_input" data-property="depth3D" type="range" min="1" max="120" value="30" step="1" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--  --%>
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-edit"></i>Thông tin từ phiếu tư vấn
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a href="javascript:;" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body background">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-md-7">
                                <div class="form-group">
                                    <label class="control-label">Khách hàng tư vấn: </label>
                                    <asp:Label ID="lblAdvFullName" CssClass="bold" runat="server" Text="----- ----- ----- -----"></asp:Label>
                                </div>
                                <div class="form-group">
                                     <label class="control-label">Địa chỉ: </label>
                                    <asp:Label ID="lbladvAddress" CssClass="bold" runat="server" Text="123-sdfssdfsd"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Email: </label>
                                    <asp:Label ID="lblAdvEmail" CssClass="bold" runat="server" Text="jdhdb@gmail.com"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Số điện thoại: </label>
                                    <asp:Label ID="lblAdvPhone" CssClass="bold" runat="server" Text="01323466546"></asp:Label>
                                </div>
                            </div>
                            <!--/span-->
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label class="control-label">Giới tính: </label>
                                    <asp:Label ID="lblAdvSex" CssClass="bold" runat="server" Text="Nam"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Đăng ký tư vấn: </label>
                                    <span id="spanTagsAdv" runat="server"><i class="fa fa-pencil-square-o"></i> <asp:Label ID="lblAdvType" CssClass="bold" runat="server" Text="Tư vấn du học"></asp:Label></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Trình độ học vấn: </label>
                                    <asp:Label ID="lblAdvEdulvl" CssClass="bold" runat="server" Text="Đại học"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Quốc Gia Tư Vấn:</label>
                                    <asp:Label ID="lblAdvcoutry" CssClass="bold" runat="server" Text="Canada"></asp:Label>
                                </div>
                            </div>
                            <!--/span-->
                        </div>
                    </div>
                </div>
            </div>
            <%--  --%>
        </div>
        <div class="col-lg-8">
            <div class="panel panel-info">
                <div class="panel-body">
                    <h2>BẢNG KÊ KHAI THÔNG TIN</h2>
                    <hr />
                    <%-- tabbable --%>
                    <div class="tabbable-custom">
                        <ul class="nav nav-tabs">
                            <li class="active">
                                <a href="#tab_hocsinh_info" data-toggle="tab">Thông tin học sinh </a>
                            </li>
                            <li>
                                <a href="#tab_phuhuynh_info" data-toggle="tab">Thông tin phụ huynh </a>
                            </li>
                            <li>
                                <a href="#tab_thongtin_them" data-toggle="tab">Thông tin Thêm </a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_hocsinh_info">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="col-sm-3">
                                        <div class="row">
                                            <asp:TextBox ID="txtPostImgTemp" CssClass="form-control display-none" runat="server"></asp:TextBox>
                                            <img src="../images/default_images.jpg" id="imgCusprofile" class="img-responsive" runat="server" />
                                            <br />
                                            <a href="#" id="clearImg" class="btn red"><i class="fa fa-remove"></i></a>
                                            <a class="btn green" href="#coluploadEditImges" data-toggle="collapse"><i class="fa fa-upload"></i></a>
                                            <a class="btn blue" href="#modalPostImages" data-toggle="modal"><i class="fa fa-folder-open"></i></a>
                                        </div>
                                        <div class="clearfix"></div>
                                        <br />
                                        <div class="row">
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
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="(.)+(.jpg|.gif|.png|.JPG|.PNG|.GIF)$"
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
                                        <div class="col-sm-9">
                                            <div class="col-sm-12">
                                                <%-- Start row 1 --%>
                                                <div class="row">
                                                    <div class="form-group">
                                                        <label class="control-label">Đơn vị</label>
                                                        <asp:TextBox ID="txtCompanyCopyright" CssClass="form-control" Text="Công Ty Cổ Phần Đỉnh Cao Châu Mỹ ®" ReadOnly="true" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <%-- End row 1 --%>
                                                <%-- Start row 2 --%>
                                                <div class="row">
                                                    <div class="form-group">
                                                        <label class="control-label">Nhân viên tư vấn</label>
                                                        <asp:TextBox ID="txtEmpAdv" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <%-- End row 2 --%>
                                                <div class="row">
                                                    <div class="form-group">
                                                        <label class="control-label">Mã Hồ Sơ</label>
                                                        <asp:TextBox ID="txtprofilePriCode" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <%-- Start row 3 --%>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Họ</label>
                                                            <asp:TextBox ID="txtformLastName" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtformLastName" ForeColor="Red" Display="Dynamic" ValidationGroup="validFormPrivateProfile" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Họ từ 1-200 ký tự !"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Tên</label>
                                                            <asp:TextBox ID="txtformFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtformFirstName" ValidationGroup="validFormPrivateProfile" runat="server" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtformFirstName" ForeColor="Red" Display="Dynamic" ValidationGroup="validFormPrivateProfile" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Tên từ 1-200 ký tự !"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%-- End row 3 --%>
                                                <%-- Start row 4 --%>
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <div class="form-group">
                                                            <label class="control-label">Tên khác</label>
                                                            <asp:TextBox ID="txtformOtherName" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%-- End row 4 --%>
                                                <%-- Start row 5 --%>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Ngày Sinh</label>
                                                            <%-- Date picker --%>
                                                            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                                                <input type="text" class="form-control" id="txtformBirthday" runat="server" />
                                                                <span class="input-group-btn">
                                                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                                                </span>
                                                            </div>
                                                            <%-- Date picker --%>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Nơi sinh</label>
                                                            <asp:TextBox ID="txtformBirthPlace" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%-- Start row 5 --%>
                                                <%-- Start row 6 --%>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Số CMND</label>
                                                            <asp:TextBox ID="txtformIdentityCard" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Nơi Cấp</label>
                                                            <asp:TextBox ID="txtformPlaceOfIdentityCard" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%-- End row 6 --%>
                                                <%-- Start row 7 --%>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Ngày Cấp</label>
                                                            <%-- Datepicker --%>
                                                            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                                                <input type="text" class="form-control" id="txtformDateOfIdentityCard" runat="server" />
                                                                <span class="input-group-btn">
                                                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                                                </span>
                                                            </div>
                                                            <%-- end date picker --%>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Giới tình</label>
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
                                                <%-- End row 7 --%>
                                                <%-- Start row 8 --%>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Làm Hồ Sơ :</label>
                                                            <asp:DropDownList ID="dlBagProfileType" CssClass="form-control background" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%-- End row 8 --%>
                                                <%--  --%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="tab_phuhuynh_info">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-horizontal">
                                            <div class="form-body">
                                                <h3><i>Thông tin Cha</i></h3>
                                                    <%-- /Row --%>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Họ : </label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpLastName_Dad" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Tên : </label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpFirstName_Dad" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%-- /Row --%>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Ngày sinh : </label>
                                                                <div class="col-md-8">
                                                                    <%-- Date picker --%>
                                                                    <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                                                        <asp:TextBox ID="txtpNgaySinh_Dad" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                                <label class="control-label bold col-md-4">Nơi sinh : </label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpNoiSinh_Dad" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%-- /Row --%>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Số CMND : </label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpSoCmnd_Dad" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Nới cấp : </label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpNoiCap_Dad" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%-- /Row --%>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Ngày cấp CMND : </label>
                                                                <div class="col-md-8">
                                                                    <%-- Date picker --%>
                                                                    <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                                                        <asp:TextBox ID="txtpNgayCap_Dad" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                                <label class="control-label bold col-md-4">Số ĐT (DĐ - Bàn)  :</label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpSoDienthoai_Dad" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <br />
                                                    <h3><i>Thông tin Mẹ</i></h3>
                                                    <%-- /Row --%>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Họ : </label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpLastName_Mom" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Tên : </label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpFirstName_Mom" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%-- /Row --%>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Ngày sinh : </label>
                                                                <div class="col-md-8">
                                                                    <%-- Date picker --%>
                                                                    <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                                                        <asp:TextBox ID="txtpNgaySinh_Mom" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                                <label class="control-label bold col-md-4">Nơi sinh : </label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpNoiSinh_Mom" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%-- /Row --%>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Số CMND : </label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpSoCmnd_Mom" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Nới cấp : </label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpNoiCap_Mom" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%-- /Row --%>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="control-label bold col-md-4">Ngày cấp CMND : </label>
                                                                <div class="col-md-8">
                                                                    <%-- Date picker --%>
                                                                    <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                                                        <asp:TextBox ID="txtpNgayCap_Mom" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                                <label class="control-label bold col-md-4">Số ĐT (DĐ - Bàn)  :</label>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtpSoDienthoai_Mom" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="tab_thongtin_them">
                                <div class="row">
                                    <%-- More Info --%>
                                    <div class="col-lg-12">
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
                                            <label class="control-label">Ghi chú - Hồ Sơ</label>
                                            <%--<asp:TextBox ID="txtGhiChu" CssClass="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>--%>
                                            <CKEditor:CKEditorControl ID="CKDocNote" Toolbar="Basic" runat="server"></CKEditor:CKEditorControl>
                                        </div>
                                    </div>
                                    <%-- End More Info --%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- End tabbable --%>

                    
                    
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="col-lg-12">
            <div class="tabbable-custom ">
                <ul class="nav nav-tabs ">
                    <li class="active">
                        <a href="#tab_info_1" data-toggle="tab">Thông tin chi tiết </a>
                    </li>
                    <%--<li>
                        <a href="#tab_info_2" data-toggle="tab">Bộ hồ sơ </a>
                    </li>--%>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="tab_info_1">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <%-- Start Row 1 --%>
                                <div class="row">
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label class="control-label">Quốc tịch :</label><br />
                                            <asp:DropDownList ID="dlNationality" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlNationality_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label class="control-label">Dân tộc :</label><br />
                                            <asp:DropDownList ID="dlEthnic" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label class="control-label">Tôn giáo :</label><br />
                                            <asp:DropDownList ID="dlReligion" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <%-- End row 1 --%>
                                <%-- Start row 2 --%>
                                <div class="row">
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label class="control-label">Quốc Gia :</label><br />
                                            <asp:DropDownList ID="dlCountry" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlCountry_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label class="control-label">Tỉnh / Thành :</label><br />
                                            <asp:DropDownList ID="dlProvince" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlProvince_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label class="control-label">Quận / Huyện :</label><br />
                                            <asp:DropDownList ID="dlDistrict" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <%-- End row 2--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%-- Start row 3 --%>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Xã / Phường :</label><br />
                                    <asp:TextBox ID="txtCommune_Ward" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 3 --%>
                        <%-- Start row 4 --%>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="control-label">Địa chỉ thường trú :</label>
                                    <asp:TextBox ID="txtPermanentAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="control-label">Nơi ở hiện nay :</label>
                                    <asp:TextBox ID="txtAddressPresent" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 4 --%>
                        <%-- Start row 5--%>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Điện thoại Cơ quan:</label>
                                    <asp:TextBox ID="txtCompanyPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Điện thoại nhà riêng :</label>
                                    <asp:TextBox ID="txtHomePhone" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Di động :</label>
                                    <asp:TextBox ID="txtCellPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                        ControlToValidate="txtCellPhone"
                                        ValidationGroup="validFormPrivateProfile"
                                        ValidationExpression="\(?([0-9]{3,4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})"
                                        ErrorMessage="<%$Resources:Resource, incorectphonenumber %>"
                                        ForeColor="Red"
                                        Display="Dynamic">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <%-- End row 5 --%>
                        <%-- Start row 6--%>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="control-label">Địa chỉ Email</label>
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                        ControlToValidate="txtEmail"
                                        ValidationGroup="validFormPrivateProfile"
                                        ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                        Display="Dynamic" ForeColor="Red"
                                        ErrorMessage="E-mail không hợp lệ ! { Ví dụ hợp lệ: abc@gmail.com }">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <%-- End row 6 --%>
                        <%-- Start row 7 --%>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">Tình trạng hôn nhân :</label>
                                    <asp:TextBox ID="txtMaritalStatus" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">Thành phần xuất thân :</label>
                                    <asp:TextBox ID="txtTPXuatThan" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 7 --%>
                        <%-- Start row 8 --%>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">Diện ưu tiên gia đình: </label>
                                    <asp:TextBox ID="txtUuTienGD" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">Diện ưu tiên bản thân:</label>
                                    <asp:TextBox ID="txtUuTienBanThan" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 8 --%>
                        <%-- Start row 9 --%>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">Năng khiếu / Sở trường :</label>
                                    <asp:TextBox ID="txtNangKhieu" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">
                                        Khuyết tật :
                                    </label>
                                    <asp:TextBox ID="txtDisability" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 9 --%>
                        <%-- Start row 10 --%>
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Tình trạng sức khỏe</label>
                                    <asp:TextBox ID="txtHealthCondition" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Chiều cao (cm)</label>
                                    <asp:TextBox ID="txtHeight" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtHeight" ValidationGroup="validFormPrivateProfile" runat="server" Display="Dynamic" ForeColor="Red" ValidationExpression="^[-+]?[0-9]*\.?[0-9]+$" ErrorMessage="Chiều cao (cm) chỉ được nhập số !"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Cân nặng (kg)</label>
                                    <asp:TextBox ID="txtWeight" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtWeight" ValidationGroup="validFormPrivateProfile" runat="server" Display="Dynamic" ForeColor="Red" ValidationExpression="^[-+]?[0-9]*\.?[0-9]+$" ErrorMessage="Cân nặng (kg)  chỉ được nhập số !"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Nhóm máu</label>
                                    <asp:DropDownList ID="dlBloodGroup" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%-- End row 10 --%>
                        <%-- Start row 11 --%>
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Ngày đóng BHXH :</label>
                                    <%-- Date picker --%>
                                    <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                        <input type="text" class="form-control" id="txtDateOfBHXH" runat="server" />
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <%-- End datepicker --%>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Số BHXH</label>
                                    <asp:TextBox ID="txtNumOfBHXH" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Ngân Hàng</label>
                                    <asp:TextBox ID="txtBank" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Số Tài Khoản</label>
                                    <asp:TextBox ID="txtAccountNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 11 --%>
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Button ID="btnSavePrivateProfile" CssClass="btn btn-primary pull-right" ValidationGroup="validFormPrivateProfile" OnClick="btnSavePrivateProfile_Click" runat="server" Text="Lưu Thông Tin" />
                            </div>
                        </div>
                    </div>
                </div>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtImgUrl" ValidationGroup="vlidSelectImage" ErrorMessage="No Image Selected !" Display="None"></asp:RequiredFieldValidator>
                                <%-- end info --%>
                            </div>
                    <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Hủy</a>
                    <asp:Button ID="btnchangeImgCusPro" CssClass="btn btn-primary pull-right" validationgroup="vlidSelectImage" OnClick="btnchangeImgCusPro_Click" runat="server" Text="Save !" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Post Images --%>

<script src="../assets/global/plugins/amcharts/amcharts/amcharts.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/serial.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/pie.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/radar.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/themes/light.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/themes/patterns.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/themes/chalk.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/ammap/ammap.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/ammap/maps/js/worldLow.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amstockcharts/amstock.js" type="text/javascript"></script>

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

