<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="GhiDanhLopMoi.aspx.cs" Inherits="kus_admin_GhiDanhLopMoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Các Lớp Chuẩn Bị Khai Giảng
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/GhiDanhLopMoi.aspx">Ghi danh lớp mới</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Hệ thống chi nhánh</label>
                        <asp:DropDownList ID="dlHTChiNhanh" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlHTChiNhanh_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Chọn cơ sở</label>
                        <asp:DropDownList ID="dlCoSo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlCoSo_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 text-center">
                    <div class="form-group">
                        TỔNG SỐ:
                        <asp:Label ID="lblCountNumLop" CssClass="bold" runat="server" Text="0"></asp:Label>
                        LỚP
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-lg-12">
                    <%-- Portlet --%>
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-edit"></i>Danh sách các lớp chuẩn bị khai giảng
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                <asp:Button ID="btnreload" CssClass="btn green" OnClick="btnreload_Click" runat="server" Text="refresh" />
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body background">
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:Button ID="btnUpdate" CssClass="btn btn-default" OnClick="btnUpdate_Click" runat="server" Text="Cập nhật thông tin lớp" />
                                    <a class="btn btn-default" href="#modalLenLichHoc" data-toggle="modal"><i class="fa fa-calendar"></i>Xem lịch học</a>
                                    <a class="btn btn-default" href="#modalGiaoTrinhHoc" data-toggle="modal"><i class="fa fa-book"></i>Sách - Giáo trình học</a><br />
                                    <asp:Label ID="lblUpdateLop" ForeColor="Red" runat="server"></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <a class="btn green pull-right" id="btnGhiDanhHV" onserverclick="btnGhiDanhHV_ServerClick" runat="server"><i class="fa fa-graduation-cap"></i> Ghi Danh Học Viên</a><br />
                                    <asp:Label ID="lblWarningDKLop" ForeColor="Red" runat="server"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <asp:GridView ID="gwListLopHoc" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt" OnRowDataBound="gwListLopHoc_RowDataBound" OnRowDeleting="gwListLopHoc_RowDeleting"
                                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwListLopHoc_SelectedIndexChanged">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Mã Lớp">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("LopHocCode") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lvlLopHocID" CssClass="display-none" runat="server" Text='<%# Eval("LopHocID") %>'></asp:Label>
                                                    <asp:Label ID="lblCoSoID" CssClass="display-none" runat="server" Text='<%# Eval("CoSoID") %>'></asp:Label>
                                                    <asp:Label ID="lblLopHocCode" runat="server" Text='<%# Bind("LopHocCode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tên Lớp">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TenLopHoc") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("TenLopHoc") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cấp Độ">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("TenCapDo") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("TenCapDo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cơ Sở">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("TenCoSo") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("TenCoSo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày Khai Giảng">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NgayKhaiGiang","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("NgayKhaiGiang","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày Kết Thúc">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("NgayKetThuc","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("NgayKetThuc","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Thời Lượng">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ThoiLuong") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("ThoiLuong") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Số Lượng Ghi Danh">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("SLGhiDanh") +"/"+ Eval("SiSoToiDa") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSLGhiDanh" CssClass="display-none" runat="server" Text='<%# Eval("SLGhiDanh") %>'></asp:Label>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("SLGhiDanh") +"/"+ Eval("SiSoToiDa") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mức Học Phí">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("MucHocPhi") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" CssClass="text-danger" runat="server" Text='<%# Bind("MucHocPhi","{0:0,00}") %>'></asp:Label>
                                                    <span class="text-danger">₫</span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelLopHoc" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                                        <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                                        <RowStyle BackColor="#A1DCF2"></RowStyle>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- End Portlet --%>
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
                                </div>
                            </div>
                        </div>
                        <!-- END PAGINATOR -->
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="gwListLopHoc" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- Modal Xem Lich Hoc --%>
    <div class="modal fade" id="modalLenLichHoc" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title uppercase">
                        <img src="../images/icon/Calendar-icon.png" width="35" height="35" />
                        Xem ngày giờ học
                    </h4>
                </div>
                <div class="modal-body background">
                    <div class="row">
                        <div class="col-lg-12">
                            <label class="control-label bold">Mã Lớp : </label>
                            <asp:Label ID="lblchoseMaLop" Text="---" runat="server"></asp:Label>
                            | 
                            <label class="control-label bold">Tên Lớp : </label>
                            <asp:Label ID="lblchoseLop" Text="---" runat="server"></asp:Label>
                            |
                            <label class="control-label bold">Ngày KG : </label>
                            <asp:Label ID="lblchoseNgayKG" Text="---" runat="server"></asp:Label>
                            | 
                            <label class="control-label bold">Ngày KT : </label>
                            <asp:Label ID="lblchoseNgayKT" Text="---" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-12">
                            <%-- Show Lich Hoc --%>
                            <table class="table table-bordered">
                                <tr>
                                    <th colspan="2" class="text-center">Thứ</th>
                                    <th class="text-center">Chi Tiết</th>
                                </tr>
                                <tr>
                                    <td class="text-center" style="width: 50px;" rowspan="3">Hai</td>
                                    <td style="width: 60px;">Sáng</td>
                                    <td>
                                        <%-- GW Thu 2 - Sang --%>
                                        <asp:GridView ID="gwThu2Sang" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu2Sang" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend1" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu2Sang" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam1" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai1" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Chiều</td>
                                    <td>
                                        <%-- GW Thu 2 - Chieu --%>
                                        <asp:GridView ID="gwThu2Chieu" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu2Chieu" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend2" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu2Chieu" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam2" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai2" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tối</td>
                                    <td>
                                        <%-- GW Thu 2 - Toi --%>
                                        <asp:GridView ID="gwThu2Toi" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu2Toi" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend3" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu2Toi" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam3" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai3" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center" rowspan="3">Ba</td>
                                    <td>Sáng</td>
                                    <td>
                                        <%-- GW Thu 3 - Sang --%>
                                        <asp:GridView ID="gwThu3Sang" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu3Sang" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend4" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu3Sang" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam4" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai4" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Chiều</td>
                                    <td>
                                        <%-- GW Thu 3 - Chieu --%>
                                        <asp:GridView ID="gwThu3Chieu" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu3Chieu" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend5" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu3Chieu" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam5" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai5" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tối</td>
                                    <td>
                                        <%-- GW Thu 3 - Toi --%>
                                        <asp:GridView ID="gwThu3Toi" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu3Toi" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend6" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu3Toi" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam6" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai6" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center" rowspan="3">Tư</td>
                                    <td>Sáng</td>
                                    <td>
                                        <%-- GW Thu 4 - Sang --%>
                                        <asp:GridView ID="gwThu4Sang" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu4Sang" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend7" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu4Sang" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam7" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai7" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Chiều</td>
                                    <td>
                                        <%-- GW Thu 4 - Chieu --%>
                                        <asp:GridView ID="gwThu4Chieu" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu4Chieu" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend8" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu4Chieu" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam8" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai8" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tối</td>
                                    <td>
                                        <%-- GW Thu 4 - Toi --%>
                                        <asp:GridView ID="gwThu4Toi" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu4Toi" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend9" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu4Toi" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam9" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai9" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center" rowspan="3">Năm</td>
                                    <td>Sáng</td>
                                    <td>
                                        <%-- GW Thu 5 - Sang --%>
                                        <asp:GridView ID="gwThu5Sang" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu5Sang" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend10" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu5Sang" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam10" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai10" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Chiều</td>
                                    <td>
                                        <%-- GW Thu 5 - Chieu --%>
                                        <asp:GridView ID="gwThu5Chieu" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu5Chieu" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend11" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu5Chieu" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam11" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai11" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tối</td>
                                    <td>
                                        <%-- GW Thu 5 - Toi --%>
                                        <asp:GridView ID="gwThu5Toi" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu5Toi" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend12" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu5Toi" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam12" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai12" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center" rowspan="3">Sáu</td>
                                    <td>Sáng</td>
                                    <td>
                                        <%-- GW Thu 6 - Sang --%>
                                        <asp:GridView ID="gwThu6Sang" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu6Sang" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend13" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu6Sang" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam13" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai13" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Chiều</td>
                                    <td>
                                        <%-- GW Thu 6 - Chieu --%>
                                        <asp:GridView ID="gwThu6Chieu" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu6Chieu" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend14" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu6Chieu" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam14" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai14" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tối</td>
                                    <td>
                                        <%-- GW Thu 6 - Toi --%>
                                        <asp:GridView ID="gwThu6Toi" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu6Toi" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend015" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu6Toi" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam15" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai15" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center" rowspan="3">Bảy</td>
                                    <td>Sáng</td>
                                    <td>
                                        <%-- GW Thu 7 - Sang --%>
                                        <asp:GridView ID="gwThu7Sang" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu7Sang" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend16" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu7Sang" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam16" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai16" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Chiều</td>
                                    <td>
                                        <%-- GW Thu 7 - Chieu --%>
                                        <asp:GridView ID="gwThu7Chieu" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu7Chieu" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend17" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu7Chieu" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam17" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai17" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tối</td>
                                    <td>
                                        <%-- GW Thu 7 - Toi --%>
                                        <asp:GridView ID="gwThu7Toi" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocThu7Toi" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend18" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Thu7Toi" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam18" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai18" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center" rowspan="3">Chủ Nhật</td>
                                    <td>Sáng</td>
                                    <td>
                                        <%-- GW Chu nhat - Sang --%>
                                        <asp:GridView ID="gwChuNhatSang" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocChuNhatSang" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend19" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="ChuNhatSang" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam19" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai19" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Chiều</td>
                                    <td>
                                        <%-- GW Chu nhat - Chieu --%>
                                        <asp:GridView ID="gwChuNhatChieu" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocChuNhatChieu" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend20" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="ChuNhatChieu" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam20" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai20" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tối</td>
                                    <td>
                                        <%-- GW Chu nhat - Toi --%>
                                        <asp:GridView ID="gwChuNhatToi" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeader="False" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLichHocID" CssClass="display-none" runat="server" Text='<%# Eval("LichHocID") %>'></asp:Label>
                                                        <asp:Label ID="lblTietHocChuNhatToi" runat="server" Text='<%# "Tiết " + Eval("TietHoc") %>'></asp:Label>
                                                        ->
                                                        <asp:Label ID="lblend21" runat="server" Text='<%# (Convert.ToInt32(Eval("TietHoc"))+Convert.ToInt32(Eval("SoTiet"))-1).ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="ChuNhatToi" runat="server" Text='<%# "Phòng : " + Eval("DayPhong")+Eval("Tang")+"."+Eval("SoPhong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvtrungtam21" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai21" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <%-- End Lich Hoc --%>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--<asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="OK" />--%>
                    <a class="btn yellow" data-dismiss="modal">OK</a>
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Xem Lich Hoc--%>

    <%-- Modal Giáo Trinh Học --%>
    <div class="modal fade" id="modalGiaoTrinhHoc" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title uppercase">
                        <img src="../images/icon/Books-1-icon.png" width="35" height="35" />
                        Sách - Giáo Trình Học
                    </h4>
                </div>
                <div class="modal-body background">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gwkus_LopHoc_Books" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt" OnRowDataBound="gwkus_LopHoc_Books_RowDataBound" OnRowDeleting="gwkus_LopHoc_Books_RowDeleting"
                                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                                <Columns>
                                    <asp:TemplateField HeaderText="Mã Sách - Giáo Trình">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookID" CssClass="display-none" runat="server" Text='<%# Eval("BookID") %>'></asp:Label>
                                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("BookCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tên Sách - Giáo Trình">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("BookName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tác Giả">
                                        <ItemTemplate>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("Author") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nhà XB">
                                        <ItemTemplate>
                                            <asp:Label ID="Label12" runat="server" Text='<%# Eval("Publisher") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngôn Ngữ">
                                        <ItemTemplate>
                                            <asp:Label ID="Label13" runat="server" Text='<%# Eval("Languages") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelBook" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                                <HeaderStyle BackColor="#FFB848" ForeColor="White"></HeaderStyle>
                                <RowStyle BackColor="#FAF3DF"></RowStyle>
                            </asp:GridView>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <asp:Label ID="lblvalidAddSach" ForeColor="Red" runat="server"></asp:Label><br />
                                    <label class="control-label">Thêm Sách</label>
                                    <div class="input-group">
                                        <div class="input-icon">
                                            <i class="fa fa-book"></i>
                                            <asp:DropDownList ID="dlAddBooks" class="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                        <span class="input-group-btn">
                                            <button id="btnAddBook" class="btn btn-success" type="button" onserverclick="btnAddBook_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i>Add</button>
                                            <%--<asp:Button ID="Button2" runat="server" Text="Button" />--%>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Đóng</a>
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Giao Trinh hoc --%>
</asp:Content>

