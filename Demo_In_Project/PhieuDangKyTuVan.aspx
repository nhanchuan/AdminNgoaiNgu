<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="PhieuDangKyTuVan.aspx.cs" Inherits="Demo_In_Project_PhieuDangKyTuVan" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Phiếu đăng ký tư vấn <small>Registration Form Advisory</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">Phiếu đăng ký tư vấn</a>
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
        <%-- Info --%>
        <div class="col-lg-8">
            <h1>Phiếu Đăng Ký Tư Vấn</h1>
            <div class="panel panel-info">
                <div class="panel-body">
                    <%-- Row 1 --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Họ và tên</label>
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%-- End row 1 --%>
                    <%-- Row 2 --%>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label class="control-label">Quốc Gia</label>
                                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label class="control-label">Tỉnh - Thành Phố</label>
                                <asp:DropDownList ID="DropDownList4" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label class="control-label">Quận / Huyện</label>
                                <asp:DropDownList ID="DropDownList5" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%-- End row 2 --%>
                    <%-- Row 3 --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Phường - Xã / Số nhà - Tên đường</label>
                                <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%-- End row 3 --%>
                    <%-- Row 4 --%>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label class="control-label">Ngày sinh</label>
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
                                <label class="control-label">Giới Tính</label>
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
                    <%-- End row 4 --%>
                    <%-- Row 5 --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Số điện thoại</label>
                                <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%-- End row 5 --%>
                    <%-- Row 6 --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Email cá nhân</label>
                                <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%-- End row 6 --%>
                    <%-- Row 7 --%>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label class="control-label">Trình độ học vấn</label>
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label class="control-label">Tư vấn du học</label>
                                <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%-- End row 7 --%>
                    <%-- Row 8 --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Nội dung tư vấn</label>
                                <CKEditor:CKEditorControl ID="EditorContent" Toolbar="Basic" runat="server"></CKEditor:CKEditorControl>
                            </div>
                        </div>
                    </div>
                    <%-- End row 8 --%>
                     <div class="clearfix"></div>
                    <a href="#" class="btn btn-primary pull-right">Nhập Phiếu Đăng Ký Tư Vấn</a>
                </div>
            </div>
        </div>
        <%-- End Info --%>
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

