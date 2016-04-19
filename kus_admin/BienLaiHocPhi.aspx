<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="BienLaiHocPhi.aspx.cs" Inherits="kus_admin_BienLaiHocPhi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Biên lai học phí <asp:Label ID="lblBienLaicode" CssClass="bold" runat="server"></asp:Label>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/QLHocPhi.aspx">Quản lý Học phí</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#BienLaiHocPhi">Biên lai học phí</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-12 text-center">
            <h1 class="bold" style="color: #0094ff;">BIÊN LAI ĐÓNG HỌC PHÍ</h1>
        </div>
        <div class="clearfix"></div>
        <div class="col-lg-2">
            <div class="panel panel-info">
                <div class="panel-body">
                    <asp:TextBox ID="txtPostImgTemp" CssClass="form-control display-none" runat="server"></asp:TextBox>
                    <img src="../images/default_images.jpg" id="imgCusprofile" class="img-responsive" runat="server" />
                    
                </div>
            </div>
        </div>
        <div class="col-lg-10">
            <div class="panel panel-info">
                <div class="panel-body">
                    <table class="table table-responsive">
                        <tr>
                            <td style="width: 15%;" class="bold">Mã Biên Lai : </td>
                            <td>
                                <asp:Label ID="lblMaBienLai" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold">Mã Học Viên : </td>
                            <td>
                                <asp:Label ID="lblMaHocVien" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 15%;" class="bold">Lớp Học : </td>
                            <td>
                                <asp:Label ID="lblLopHoc" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold">Họ tên Học viên : </td>
                            <td>
                                <asp:Label ID="lblHoTenHV" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="bold">Ngày sinh : </td>
                            <td>
                                <asp:Label ID="lblBirthday" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold">Lý do thu : </td>
                            <td>
                                <asp:Label ID="lblLyDoThu" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td></td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td class="bold">Ngày bắt đầu : </td>
                            <td>
                                <asp:Label ID="txtHPNgayKG" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="bold">Ngày kết thúc : </td>
                            <td>
                                <asp:Label ID="txtHPNgayKT" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold">Học phí : </td>
                            <td>
                                <asp:Label ID="lblMucHocPhi" ForeColor="Red" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="bold">Miễn giảm : </td>
                            <td>
                                <asp:Label ID="lblMienGiam" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold">Thời Lượng : </td>
                            <td>
                                <asp:Label ID="lblthoiluong" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="bold">Thành tiền : </td>
                            <td>
                                <asp:Label ID="lblthanhtien" CssClass="bold" ForeColor="Red" runat="server" Text="Label"></asp:Label> ( đã trừ đặt cọc : <asp:Label ID="lblDatCoc" runat="server" Text="Label"></asp:Label> )
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="panel-footer text-right">
                    <a class="btn green disabled"><i class="fa fa-edit"></i> Cập nhật Biên Lai</a>
                    <a class="btn btn-default" onclick="return PrintPanel();"><i class="fa fa-print"></i> In Biên Lai</a>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="col-lg-12">
            <h2 class="bold">Lịch Học</h2>
            <br />
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
        </div>
    </div>

   
    <script type = "text/javascript">
        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            url = url.toLowerCase(); // This is just to avoid case sensitiveness  
            name = name.replace(/[\[\]]/g, "\\$&").toLowerCase();// This is just to avoid case sensitiveness for query parameter name
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, " "));
        }
        function PrintPanel() {
            var BLCode = getParameterByName('BienLaiCode'); // "Lấy Mã Biên LAi"
            var url = "../kus_admin/PrintBienLai.aspx?BienLaiCode=" + BLCode.toUpperCase();
            var printWindow = window.open(url, '', 'height=768,width=1366');
            
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>

</asp:Content>

