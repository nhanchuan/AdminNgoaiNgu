<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="QLHoSoDuHoc.aspx.cs" Inherits="QuanLyHoSo_QLHoSoDuHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thông Tin Hồ Sơ <small>Profile Information</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">HỒ SƠ DU HỌC</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <%-- Begin chart --%>
    <div class="row">
        <div class="panel panel-info">
            <div class="panel-body">
                <div id="chart_5" class="chart" style="height: 400px;">
                </div>
                <div class="well margin-top-20">
                    <div class="row">
                        <div class="col-sm-3">
                            <label class="text-left">Top Radius:</label>
                            <input class="chart_5_chart_input" data-property="topRadius" type="range" min="0" max="1.5" value="1" step="0.01" />
                        </div>
                        <div class="col-sm-3">
                            <label class="text-left">Angle:</label>
                            <input class="chart_5_chart_input" data-property="angle" type="range" min="0" max="89" value="30" step="1" />
                        </div>
                        <div class="col-sm-3">
                            <label class="text-left">Depth:</label>
                            <input class="chart_5_chart_input" data-property="depth3D" type="range" min="1" max="120" value="40" step="1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- End chart --%>
    
    <%-- BEGIN CONTENT --%>
    <div class="row">
        <div class="col-lg-12">
            <a href="#" class="btn green" id="btnCreateNewDoc" onserverclick="btnCreateNewDoc_ServerClick" runat="server">Nhập Hồ Sơ Mới</a>
        </div>
        <div class="clearfix"></div>
        <br />
        <div class="col-lg-12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-edit"></i>Hồ sơ đăng ký du học
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                        <button id="btnreload" class="btn green" runat="server"><i class="fa fa-refresh"></i></button>
                        <a href="javascript:;" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body background">
                    <div class="row">
                        <div class="col-lg-2">
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" AutoPostBack="true" runat="server">
                                <asp:ListItem>--Tất cả--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-2">
                            <asp:DropDownList ID="dlCategory" CssClass="form-control" AutoPostBack="true" runat="server">
                                <asp:ListItem>--Trình độ học vấn--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-2">
                            <asp:DropDownList ID="dlTrinhDoHocVan" CssClass="form-control" AutoPostBack="true" runat="server">
                                <asp:ListItem>--Quốc gia du học--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-5 pull-right">
                            <div class="input-group">
                                <div class="input-icon">
                                    <i class="fa fa-search"></i>
                                    <input id="txtsearchVideo" class="form-control" type="text" placeholder="--Tìm kiếm bộ hồ sơ--" runat="server" />
                                </div>
                                <span class="input-group-btn">
                                    <button id="btnsearchRegisterForm" class="btn btn-success" type="button" runat="server"><i class="fa fa-arrow-left fa-fw"></i>Search</button>
                                </span>
                            </div>
                        </div>
                    </div>
                    <br />
                    <asp:GridView ID="gwPostmanager" 
                        CssClass="table table-condensed" 
                        runat="server" 
                        AutoGenerateColumns="False" 
                        RowStyle-BackColor="#A1DCF2" 
                        Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" 
                        HeaderStyle-ForeColor="White">
                        <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                        <RowStyle BackColor="#A1DCF2"></RowStyle>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <%-- END CONTENT --%>

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

