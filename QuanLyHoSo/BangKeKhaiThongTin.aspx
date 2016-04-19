<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="BangKeKhaiThongTin.aspx.cs" Inherits="QuanLyHoSo_BangKeKhaiThongTin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thông Tin Hồ Sơ Khách Hàng <small>INFORMATION SHEET</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../QuanLyHoSo/QLHoSoDuHoc.aspx">HỒ SƠ DU HỌC</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">BẢNG KÊ KHAI THÔNG TIN</a>
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
        </div>
        <div class="col-lg-8">
            <div class="panel panel-info">
                <div class="panel-body">
                    <h2>BẢNG KÊ KHAI THÔNG TIN</h2>
                    <hr />
                    <div class="col-sm-3">
                        <div class="row">
                            <img src="../images/default_images.jpg" class="img-responsive" />
                            <br />
                            <a href="#" class="btn red"><i class="fa fa-remove"></i></a>
                            <a href="#" class="btn green"><i class="fa fa-upload"></i></a>
                            <a href="#" class="btn blue"><i class="fa fa-folder-open"></i></a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="col-sm-12">
                            <%-- Start row 1 --%>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label">Đơn vị</label>
                                    <asp:TextBox ID="TextBox14" CssClass="form-control" Text="Công Ty Cổ Phần Đỉnh Cao Châu Mỹ ®" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%-- End row 1 --%>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label">Nhân Viên Thụ Lý Hồ Sơ</label>
                                    <asp:TextBox ID="TextBox19" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%-- Start row 2 --%>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label">Mã hồ sơ</label>
                                    <asp:TextBox ID="TextBox21" CssClass="form-control" Text="MH15010001" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%-- End row 2 --%>
                            <%-- Start row 3 --%>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="control-label">Họ</label>
                                        <asp:TextBox ID="TextBox23" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="control-label">Tên</label>
                                        <asp:TextBox ID="TextBox15" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <%-- End row 3 --%>
                            <%-- Start row 4 --%>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="control-label">Tên khác</label>
                                        <asp:TextBox ID="TextBox17" CssClass="form-control" runat="server"></asp:TextBox>
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
                                            <input type="text" class="form-control" />
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
                                        <asp:TextBox ID="TextBox20" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <%-- Start row 5 --%>
                            <%-- Start row 6 --%>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="control-label">Số CMND</label>
                                        <asp:TextBox ID="TextBox22" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="control-label">Nơi Cấp</label>
                                        <asp:TextBox ID="TextBox24" CssClass="form-control" runat="server"></asp:TextBox>
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
                                            <input type="text" class="form-control" />
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
                                                <input type="radio" name="optionsRadios" id="rdnam" value="option1" runat="server" />
                                                Nam
                                            </label>
                                            <label class="radio-inline">
                                                <input type="radio" name="optionsRadios" id="rdnu" value="option2" runat="server" />
                                                Nữ
                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- End row 7 --%>

                            <%--  --%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="col-lg-12">

            <div class="tabbable-custom ">
                <ul class="nav nav-tabs ">
                    <li class="active">
                        <a href="#tab_info_1" data-toggle="tab">Thông tin cá nhân </a>
                    </li>
                    <li>
                        <a href="#tab_info_2" data-toggle="tab">Bộ hồ sơ </a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="tab_info_1">
                        <%-- Start Row 1 --%>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Quốc tịch :</label><br />
                                    <asp:DropDownList ID="dlQuocTich" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>

                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Dân tộc :</label><br />
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Tôn giáo :</label><br />
                                    <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%-- End row 1 --%>
                        <%-- Start row 2 --%>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Quốc Gia :</label><br />
                                    <asp:DropDownList ID="DropDownList10" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                   <label class="control-label">Tỉnh / Thành :</label><br />
                                    <asp:DropDownList ID="DropDownList5" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Quận / Huyện :</label><br />
                                    <asp:DropDownList ID="DropDownList6" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%-- End row 2--%>
                        <%-- Start row 3 --%>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Xã / Phường :</label><br />
                                    <asp:TextBox ID="DropDownList7" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 3 --%>
                        <%-- Start row 4 --%>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="control-label">Địa chỉ thường trú :</label>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="control-label">Nơi ở hiện nay :</label>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 4 --%>
                        <%-- Start row 5--%>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Điện thoại Cơ quan:</label>
                                    <asp:TextBox ID="TextBox16" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label"> Điện thoại nhà riêng :</label>
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Di động :</label>
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 5 --%>
                        <%-- Start row 6--%>
                        <div class="row">
                           <div class="col-lg-12">
                               <div class="form-group">
                                   <label class="control-label">Địa chỉ Email</label>
                                   <asp:TextBox ID="TextBox18" CssClass="form-control" runat="server"></asp:TextBox>
                               </div>
                           </div>
                        </div>
                        <%-- End row 6 --%>
                        <%-- Start row 7 --%>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">Tình trạng hôn nhân :</label>
                                    <asp:TextBox ID="TextBox26" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">Thành phần xuất thân :</label>
                                    <asp:TextBox ID="TextBox27" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 7 --%>
                        <%-- Start row 8 --%>
                        <div class="row"> 
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">Diện ưu tiên gia đình: </label>
                                    <asp:TextBox ID="TextBox28" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">Diện ưu tiên bản thân:</label>
                                    <asp:TextBox ID="TextBox29" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 8 --%>
                        <%-- Start row 9 --%>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">Năng khiếu / Sở trường :</label>
                                    <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="control-label">
                                        Khuyết tật :
                                    </label>
                                    <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 9 --%>
                        <%-- Start row 10 --%>
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Tình trạng sức khỏe</label>
                                    <asp:TextBox ID="TextBox30" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Chiều cao (cm)</label>
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Cân nặng (kg)</label>
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Nhóm máu</label>
                                    <asp:DropDownList ID="DropDownList11" CssClass="form-control" runat="server"></asp:DropDownList>
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
                                        <input type="text" class="form-control" />
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
                                    <asp:TextBox ID="TextBox11" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Ngân Hàng</label>
                                    <asp:TextBox ID="TextBox25" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label class="control-label">Số Tài Khoản</label>
                                    <asp:TextBox ID="TextBox10" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- End row 11 --%>
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Button ID="Button1" CssClass="btn btn-primary pull-right" runat="server" Text="Lưu Thông Tin" />
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="tab_info_2">
                        <%-- Gridview --%>
                        <div class="row">
                            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                        </div>
                        <%-- End gridview --%>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">AAA</label>
                                    <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <label class="control-label">BBB</label>
                                <asp:TextBox ID="TextBox12" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-4">
                                <label class="control-label">CCC</label>
                                <asp:TextBox ID="TextBox13" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

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
</asp:Content>

