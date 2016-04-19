<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="KiemTraHoSoChuyen.aspx.cs" Inherits="QuanLyHoSo_KiemTraHoSoChuyen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thống Kê Phân Công Hồ Sơ <small>Statistics Assignment Profile</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../KiemTraHoSoChuyen.aspx">Thống Kê Phân Công Hồ Sơ</a>
                <i class="fa fa-angle-right"></i>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-12">
            <a class="btn green" href="../QuanLyHoSo/HoSoTongHop.aspx"><i class="fa fa-arrow-left fa-fw"></i>Quay lại</a>
        </div>
        <hr />
        <div class="clearfix"></div>
        <div class="col-lg-12">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <!-- BEGIN USERS TABLE PORTLET-->
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-edit"></i>Danh sách chuyển bộ phận hồ sơ
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                <%--<button id="btnreload" class="btn green" onserverclick="btnreload_ServerClick" runat="server"><i class="fa fa-refresh"></i></button>--%>
                                <asp:Button ID="btnreload" CssClass="btn green" runat="server" Text="refresh" />
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body background">
                            <div class="row">
                                <div class="col-lg-1">
                                    <asp:Button ID="btnSelectAll" CssClass="btn orange" OnClick="btnSelectAll_Click" runat="server" Text="Select All" />
                                    <asp:Button ID="btnUncheckAll" CssClass="btn orange" OnClick="btnUncheckAll_Click" runat="server" Text="Uncheck All" />
                                </div>
                                <div class="col-lg-2">
                                    <a href="#modalChangeEmpPropri" data-toggle="modal" class="btn btn-warning"><i class="fa fa-reply"></i> Chuyển Phiếu Tư Vấn</a>
                                </div>
                                <div class="col-lg-1">
                                    <%--<asp:Button ID="btnRemove" CssClass="btn red" OnClick="btnRemove_Click" runat="server" Text="Xóa Phiếu" />--%>
                                    <%--<a href="#modalDelete" class="btn red" data-toggle="modal">Xóa Phiếu</a>--%>
                                </div>
                                <%--<div class="col-lg-4">
                                    <div class="input-group">
                                        <div class="input-icon">
                                            <i class="icon-user-female"></i>
                                            <asp:DropDownList ID="dlEmployees" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                        <span class="input-group-btn">
                                            <button id="btnSendProfile" class="btn btn-warning" type="button" runat="server"><i class="fa fa-send"></i> Chuyển Hồ Sơ</button>
                                        </span>
                                    </div>
                                </div>--%>
                                <div class="col-lg-5">
                                    <div class="input-group">
                                        <div class="input-icon">
                                            <i class="fa fa-search"></i>
                                            <input id="txtSearchProPri" class="form-control" type="text" placeholder="Tìm kiếm hồ sơ" runat="server" />
                                        </div>
                                        <span class="input-group-btn">
                                            <button id="btnSearchProfile" class="btn btn-success" type="button" onserverclick="btnSearchProfile_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i>Search</button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <asp:GridView ID="gwProfilePrivateManager" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkrow" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Họ Tên Khách Hàng">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FullName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <a style="font-size: 16px;" href='<%# "../QuanLyHoSo/ThongTinKhachHang.aspx?FileCode=" + Eval("BasicInfoCode") %>'>
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
                                    <asp:TemplateField HeaderText="Thụ lý hồ sơ">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("NVHoSo") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <i style="color: #d64d25;" class="fa fa-briefcase"></i> <asp:Label ID="Label7" runat="server" Text='<%# Eval("NVHoSo") +" - Mã NV: "+ Eval("MaNVHoSo")%>'></asp:Label>
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
                                                <i style="color: #d64d25;" class="icon-user-female"></i> <i><%# Eval("EmpName")+" - Mã NV: "+ Eval("EmployeesCode") %></i>
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
                                    <%--<asp:TemplateField HeaderText="Tình trạng">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ProgressForm") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <span class='<%# Eval("ProfileStatus").ToString()=="0"?"btn default btn-xs red-stripe": Eval("ProfileStatus").ToString()=="1"?"btn default btn-xs blue-stripe": Eval("ProfileStatus").ToString()=="2"?"btn default btn-xs yellow-stripe":"btn default btn-xs green-stripe" %>'>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ProfileStatus").ToString()=="0"?"Chờ xử lý": Eval("ProfileStatus").ToString()=="1"?"Đang tư vấn": Eval("ProfileStatus").ToString()=="2"?"Đang làm hồ sơ":"Hoàn thành hồ sơ" %>'></asp:Label>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                                <RowStyle BackColor="#A1DCF2"></RowStyle>
                            </asp:GridView>
                        </div>
                    </div>

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
                                    <%--<asp:Repeater ID="Repeatersearch" runat="server">
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
                                </div>
                            </div>
                        </div>
                        <!-- END PAGINATOR -->
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
            <%--<asp:Timer ID="timerReloadGrw" OnTick="timerReloadGrw_Tick" runat="server"></asp:Timer>--%>
            <span class="label label-primary"><strong><i class="fa fa-pencil-square-o"></i>
                <label>Tư Vấn Du Học</label></strong></span>
            <span class="label label-default"><strong><i class="fa fa-pencil-square-o"></i>
                <label>Tư Vấn Thực Tập</label></strong></span>
            <span class="label label-success"><strong><i class="fa fa-pencil-square-o"></i>
                <label>Tư Vấn Du Lịch</label></strong></span>
            <span class="label label-warning"><strong><i class="fa fa-pencil-square-o"></i>
                <label>Tư Vấn Định Cư</label></strong></span>
        </div>
    </div>
    <%-- Modal Change --%>
    <div class="modal fade" id="modalChangeEmpPropri" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title"><i class="fa fa-reply"></i>Chuyển Hồ Sơ Cho Nhân Viên Khác !</h4>
                </div>
                <div class="modal-body background">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Chọn Nhân Viên Làm Hồ Sơ</label>
                                <asp:DropDownList ID="dlChangeEmpPropri" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-header text-right">
                    <asp:Button ID="btnChangeEmpAdvisory" CssClass="btn red" OnClick="btnChangeEmpAdvisory_Click" runat="server" Text="Chuyển Phiếu" />
                    <a class="btn btn-warning" data-dismiss="modal" aria-hidden="true">Hủy</a>
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Change --%>

</asp:Content>

