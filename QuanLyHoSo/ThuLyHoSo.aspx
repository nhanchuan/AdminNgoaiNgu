<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="ThuLyHoSo.aspx.cs" Inherits="QuanLyHoSo_ThuLyHoSo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <link href="../assets/admin/pages/css/profile-old.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thụ Lý Hồ Sơ <small>Accept Dossiers</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../QuanLyHoSo/ThuLyHoSo.aspx">Thụ Lý Hồ Sơ</a>
                <i class="fa fa-angle-right"></i>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->

    <div class="row">
        <div class="col-md-8 profile-info">
            <h1>
                <asp:Label ID="lblUserFullName" runat="server" Text="Nguyễn Nhân Chuẩn"></asp:Label>
            </h1>
            <asp:Label ID="lblregency" CssClass="control-label label-default" Text="Nhân Viên Tư Vấn" runat="server"></asp:Label><br />
            <asp:Label ID="lblMaNV" CssClass="bold" runat="server" Text="Label"></asp:Label>
            <p>
                <i class="fa fa-globe" style="color: dodgerblue;"></i>
                <a href="#">
                    <asp:Label ID="lblmywebsite" runat="server" Text="Label"></asp:Label>
                </a>
            </p>
            <ul class="list-inline">
                <li>
                    <i class="fa fa-map-marker"></i>
                    <asp:Label ID="lbladdress" runat="server" Text="Label"></asp:Label>
                </li>
                <li>
                    <i class="fa fa-calendar"></i>
                    <asp:Label ID="lblBirthday" runat="server" Text="Label"></asp:Label>
                </li>
                <li>
                    <i class="fa fa-briefcase"></i>
                    <asp:Label ID="lblOccupation" runat="server" Text="Label"></asp:Label>
                </li>
                <li>
                    <i class="fa fa-star"></i>Top Seller
                </li>
                <li>
                    <i class="fa fa-heart"></i>BASE Jumping
                </li>
            </ul>
        </div>
        <!--end col-md-8-->
        <div class="col-md-4">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="portlet sale-summary">
                        <div class="portlet-title">
                            <div class="caption bold">
                                Thống kê hồ sơ
                           
                            </div>
                            <div class="tools">
                                <a class="reload" href="javascript:;" onclick="reloadclick()"></a>
                            </div>
                        </div>
                        <div class="portlet-body">

                            <ul class="list-unstyled">
                                <li>
                                    <span class="sale-info">Trong ngày <i class="fa fa-img-up"></i>
                                    </span>
                                    <span class="sale-num">
                                        <asp:Label ID="lblDaySum" runat="server" Text="Label"></asp:Label>
                                    </span>
                                </li>
                                <li>
                                    <span class="sale-info">Trong tháng <i class="fa fa-img-down"></i>
                                    </span>
                                    <span class="sale-num">
                                        <asp:Label ID="lblMonthSum" runat="server" Text="Label"></asp:Label>
                                    </span>
                                </li>
                                <li>
                                    <span class="sale-info">Tổng số </span>
                                    <span class="sale-num">
                                        <asp:Label ID="lblTotalSum" runat="server" Text="Label"></asp:Label>
                                    </span>
                                </li>
                            </ul>

                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <!--end col-md-4-->
    </div>
    <%-- END ROW --%>

    <div class="clearfix"></div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-edit"></i>Danh Sách Hồ sơ thụ lý
                   
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                        <%--<button id="btnreload" class="btn green" runat="server"><i class="fa fa-refresh"></i></button>--%>
                        <asp:Button ID="btnreload" CssClass="btn green" OnClick="btnreload_Click" runat="server" Text="refresh" />
                        <a href="javascript:;" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body background">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="input-group">
                                <div class="input-icon">
                                    <i class="fa fa-tasks"></i>
                                    <asp:DropDownList ID="dlEmployeesAdvisory" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">-- Chọn hành động --</asp:ListItem>
                                        <asp:ListItem Value="1">LÀM HỒ SƠ KHÁCH HÀNG</asp:ListItem>
                                        <asp:ListItem Value="2">XEM HỒ SƠ KHÁCH HÀNG</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <span class="input-group-btn">
                                    <a href="#" id="btnAction" class="btn btn-primary" onserverclick="btnAction_ServerClick" runat="server"><i class="fa fa-terminal"></i>Áp dụng</a>
                                </span>
                            </div>
                            <asp:Label ID="lblActionsMessage" ForeColor="Red" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-5">
                            <div class="input-group">
                                <div class="input-icon">
                                    <i class="fa fa-search"></i>
                                    <input id="txtsearchAdv" class="form-control" type="text" placeholder="Tìm kiếm hồ sơ" runat="server" />
                                </div>
                                <span class="input-group-btn">
                                    <button id="btnSearchKey" class="btn btn-success" type="button" onserverclick="btnSearchKey_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i>Search</button>
                                    <%--<a style="margin-left: 5px;" class="btn btn-info" data-toggle="modal" href="#modalSeaarch">Search more</a>--%>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="input-icon">
                                <i class="fa fa-filter"></i>
                                <asp:DropDownList ID="dlLoaiHoSo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlLoaiHoSo_SelectedIndexChanged" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />
                    <%-- Begin content --%>
                    <asp:GridView ID="gwThuLyHSManager" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwThuLyHSManager_SelectedIndexChanged" OnRowDataBound="gwThuLyHSManager_RowDataBound" OnRowDeleting="gwThuLyHSManager_RowDeleting">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkBtnDel" CssClass="btn btn-circle btn-icon-only btn-default" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã Hồ Sơ">
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("ProfileCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Họ Tên Khách Hàng">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FullName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <a style="font-size: 16px;" href='<%# "../QuanLyHoSo/CapNhatThongTinKhachHang.aspx?FileCode=" + Eval("BasicInfoCode") %>'>
                                        <asp:Label ID="Label1" CssClass="bold" runat="server" Text='<%# Bind("FullName") %>'></asp:Label></a>
                                    <asp:Label ID="lblProfileID" CssClass="display-none" runat="server" Text='<%# Bind("ProfileID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ngày sinh">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Birthday") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Birthday","{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Giới tính">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Sex") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Sex") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CMND">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("IdentityCard") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("IdentityCard") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <i class="fa fa-graduation-cap"></i>School
                               
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("SchoolName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phiếu tư vấn">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("TypeName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <span class='<%# Eval("TypeName").ToString() == "Tư Vấn Du Học" ? "label label-primary" : Eval("TypeName").ToString() == "Tư Vấn Thực Tập" ? "label label-default" : Eval("TypeName").ToString() == "Tư Vấn Du Lịch" ? "label label-success" :"label label-warning" %>'>
                                        <strong><i class="fa fa-pencil-square-o"></i>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("TypeName") %>'></asp:Label></strong></span>
                                    <br />
                                    <div class="form-inline  pull-right">
                                        <i style="color: #d64d25;" class="icon-user-female"></i><i><%# Eval("EmpName")+" - Mã NV: "+ Eval("EmployeesCode") %></i>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Làm Hồ Sơ">
                                <ItemTemplate>
                                    <li class='<%# Eval("BagProfileTypeID").ToString() == "1" ? "list-group-item bg-blue" : Eval("BagProfileTypeID").ToString() == "2" ? "list-group-item bg-danger" : Eval("BagProfileTypeID").ToString() == "3" ? "list-group-item bg-green" :"list-group-item bg-yellow" %>'>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("BagProfileTypeID").ToString()=="1"?"Du Học": Eval("BagProfileTypeID").ToString()=="2"?"Thực Tập": Eval("BagProfileTypeID").ToString()=="3"?"Du Lịch":"Định Cư" %>'></asp:Label>
                                    </li>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                        <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                        <RowStyle BackColor="#A1DCF2"></RowStyle>
                    </asp:GridView>
                    <%-- End Content --%>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="gwThuLyHSManager" EventName="SelectedIndexChanged" />--%>
            <asp:PostBackTrigger ControlID="gwThuLyHSManager" />
        </Triggers>
    </asp:UpdatePanel>
    <!-- END TABLE PORTLET-->
    <div class="form-group">
        <!-- BEGIN PAGINATOR -->
        <div class="row">
            <div class="col-md-4 col-sm-4 items-info">
            </div>
            <div class="col-md-8 col-sm-8">
                <div class="pagination_lst pull-right">
                    <asp:Repeater ID="rptPager" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="clearfix"></div>
                    <%--<asp:Repeater ID="RpSearchMore" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSearchPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                OnClick="DLPage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>--%>
                    <asp:Repeater ID="RepeaterKeySearch" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkKeySearch" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                OnClick="KeySearchPage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="RepeaterBagType" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFilterProgess" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                OnClick="BagTypePage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <!-- END PAGINATOR -->
    </div>
    <a id="btnHSChonTruong" class="btn btn-success disabled" href="#modalChangeSchool" data-toggle="modal" runat="server">
        <img src="../images/icon/Categories-applications-education-university-icon.png" width="30" height="30" />
        CHỌN TRƯỜNG CHO HỒ SƠ DU HỌC</a>
   <%-- <a class="btn btn-success disabled">
        <img src="../images/icon/Other-Power-Switch-User-Metro-icon.png" width="30" height="30" />
        CHUYỂN TRƯỜNG CHO HỒ SƠ DU HỌC</a>--%>
    <div class="clearfix"></div>
    <br />
    <div class="col-lg-12 text-right">
        <span class="label label-primary"><strong><i class="fa fa-pencil-square-o"></i>
            <label>Tư Vấn Du Học</label></strong></span>
        <span class="label label-default"><strong><i class="fa fa-pencil-square-o"></i>
            <label>Tư Vấn Thực Tập</label></strong></span>
        <span class="label label-success"><strong><i class="fa fa-pencil-square-o"></i>
            <label>Tư Vấn Du Lịch</label></strong></span>
        <span class="label label-warning"><strong><i class="fa fa-pencil-square-o"></i>
            <label>Tư Vấn Định Cư</label></strong></span>
    </div>
    <div class="row"></div>
    <br />
    <%-- Begin chart --%>
    <div class="portlet box yellow">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-edit"></i>Biểu đồ thống kê số lượng hồ sơ du học các quốc gia
           
            </div>
            <div class="tools">
                <a href="javascript:;" class="collapse"></a>
                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                <button id="btnreloadmodal" class="btn green" runat="server"><i class="fa fa-refresh"></i></button>
                <a href="javascript:;" class="remove"></a>
            </div>
        </div>
        <div class="portlet-body background">
            <%-- Begin chart --%>
            <div class="panel panel-info">
                <div class="panel-body">
                    <div id="chart_5at" class="chart" style="height: 400px;">
                    </div>
                    <%--<div class="well margin-top-20">
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
                        </div>--%>
                </div>
            </div>
            <%-- End chart --%>
        </div>
    </div>
    <%-- End chart --%>

    <%-- Modal Search --%>
    <div class="modal fade" id="modalChangeSchool" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-full">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">
                        <img src="../images/icon/Categories-applications-education-university-icon.png" width="35" height="35" />
                        CHỌN TRƯỜNG CHO <span class="bold">HỒ SƠ DU HỌC</span></h4>
                </div>
                <div class="modal-body background">
                    <div class="row">
                        <div class="col-lg-12" style="height: 750px; overflow: auto;">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gwInternationalSchool" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tên Trường">
                                                <HeaderTemplate>
                                                    Tên Trường: 
                                                   
                                                    <asp:DropDownList ID="dlSchoolName" CssClass="text-info" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="dlSchoolName_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" CssClass="bold uppercase" runat="server" Text='<%# Bind("SchoolName") %>'></asp:Label>
                                                    <asp:Label ID="lblSchoolID" CssClass="display-none" runat="server" Text='<%# Eval("SchoolID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cấp bậc">
                                                <HeaderTemplate>
                                                    Cấp bậc:
                                                   
                                                    <asp:DropDownList ID="dlSchoolLvl" CssClass="text-info" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="dlSchoolLvl_SelectedIndexChanged" runat="server">
                                                    </asp:DropDownList>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("SchoolLvl") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Địa Chỉ">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("SchoolAddress") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quốc Gia">
                                                <HeaderTemplate>
                                                    Quốc Gia:
                                                   
                                                    <asp:DropDownList ID="dlFilterCountry" CssClass="text-info" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="dlFilterCountry_SelectedIndexChanged" runat="server">
                                                    </asp:DropDownList>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Điện Thoại">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href='<%# Eval("WebSite") %>' target="_blank"><i class="fa fa-globe"></i>WebSite</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                                        <HeaderStyle BackColor="#FFB848" ForeColor="White"></HeaderStyle>
                                        <RowStyle BackColor="#FAF3DF"></RowStyle>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a id="btnSaveSchool" class="btn btn-primary" onserverclick="btnSaveSchool_ServerClick" runat="server">
                        <img src="../images/icon/Save-icon.png" width="30" height="30" />
                        Chọn Trường</a>
                    <a id="A1" class="btn btn-warning" data-dismiss="modal" aria-hidden="true">
                        <img src="../images/icon/Actions-application-exit-icon.png" width="30" height="30" />
                        Hủy Chọn Trường</a>
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Search --%>
    <script>
        function reloadclick() {
            window.location.reload();
        }

    </script>
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

    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <asp:HiddenField ID="HiddenField5" runat="server" />
    <asp:HiddenField ID="HiddenField6" runat="server" />
    <asp:HiddenField ID="HiddenField7" runat="server" />
    <asp:HiddenField ID="HiddenField8" runat="server" />
    <asp:HiddenField ID="HiddenField9" runat="server" />
    <asp:HiddenField ID="HiddenField10" runat="server" />
    <asp:HiddenField ID="HiddenField11" runat="server" />
    <asp:HiddenField ID="HiddenField12" runat="server" />
    <asp:HiddenField ID="HiddenField13" runat="server" />
    <asp:HiddenField ID="HiddenField14" runat="server" />
    <asp:HiddenField ID="HiddenField15" runat="server" />
    <asp:HiddenField ID="HiddenField16" runat="server" />
    <asp:HiddenField ID="HiddenField17" runat="server" />

    <script type="text/javascript">
        var chart = AmCharts.makeChart("chart_5at", {
            "theme": "light",
            "type": "serial",
            "startDuration": 2,
            "fontFamily": 'Open Sans',
            "color": '#888',
            "dataProvider": [{
                "country": "USA",
                "visits": document.getElementById('<%=HiddenField1.ClientID %>').value,
                "color": "#FF0F00"
            }, {
                "country": "Australia",
                "visits": document.getElementById('<%=HiddenField2.ClientID %>').value,
                "color": "#999999"
            }, {
                "country": "Canada",
                "visits": document.getElementById('<%=HiddenField3.ClientID %>').value,
                "color": "#CD0D74"
            }, {
                "country": "UK",
                "visits": document.getElementById('<%=HiddenField4.ClientID %>').value,
                "color": "#F8FF01"
            }, {
                "country": "Thụy Sỹ",
                "visits": document.getElementById('<%=HiddenField5.ClientID %>').value,
                    "color": "#FF6600"
                }, {
                    "country": "Singapore",
                    "visits": document.getElementById('<%=HiddenField6.ClientID %>').value,
                    "color": "#0D8ECF"
                }, {
                    "country": "New Zealand",
                    "visits": document.getElementById('<%=HiddenField7.ClientID %>').value,
                    "color": "#04D215"
                }, {
                    "country": "Taiwan",
                    "visits": document.getElementById('<%=HiddenField8.ClientID %>').value,
                    "color": "#008000"
                }, {
                    "country": "Netherlands",
                    "visits": document.getElementById('<%=HiddenField9.ClientID %>').value,
                    "color": "#0D52D1"
                }, {
                    "country": "Germany",
                    "visits": document.getElementById('<%=HiddenField10.ClientID %>').value,
                    "color": "#FCD202"
                }, {
                    "country": "South Korea",
                    "visits": document.getElementById('<%=HiddenField11.ClientID %>').value,
                    "color": "#8A0CCF"
                }, {
                    "country": "Hungary",
                    "visits": document.getElementById('<%=HiddenField12.ClientID %>').value,
                    "color": "#2A0CD0"
                }, {
                    "country": "Malaysia",
                    "visits": document.getElementById('<%=HiddenField13.ClientID %>').value,
                    "color": "#754DEB"
                }, {
                    "country": "Japan",
                    "visits": document.getElementById('<%=HiddenField14.ClientID %>').value,
                    "color": "#FF9E01"
                }, {
                    "country": "France",
                    "visits": document.getElementById('<%=HiddenField15.ClientID %>').value,
                    "color": "#B0DE09"
                }, {
                    "country": "Philippines",
                    "visits": document.getElementById('<%=HiddenField16.ClientID %>').value,
                    "color": "#DDDDDD"
                }, {
                    "country": "Phần Lan",
                    "visits": document.getElementById('<%=HiddenField17.ClientID %>').value,
                    "color": "#000000"
                }],
            "valueAxes": [{
                "position": "left",
                "axisAlpha": 0,
                "gridAlpha": 0
            }],
            "graphs": [{
                "balloonText": "[[category]]: <b>[[value]]</b>",
                "colorField": "color",
                "fillAlphas": 0.85,
                "lineAlpha": 0.1,
                "type": "column",
                "topRadius": 1,
                "valueField": "visits"
            }],
            "depth3D": 40,
            "angle": 30,
            "chartCursor": {
                "categoryBalloonEnabled": false,
                "cursorAlpha": 0,
                "zoomable": false
            },
            "categoryField": "country",
            "categoryAxis": {
                "gridPosition": "start",
                "axisAlpha": 0,
                "gridAlpha": 0

            },
            "exportConfig": {
                "menuTop": "20px",
                "menuRight": "20px",
                "menuItems": [{
                    "icon": '../images/export.png',
                    "format": 'png'
                }]
            }
        }, 0);

            $('#chart_5at').closest('.portlet').find('.fullscreen').click(function () {
                chart.invalidateSize();
            });
        </script>
</asp:Content>



