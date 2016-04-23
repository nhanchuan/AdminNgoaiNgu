<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="PhieuGhiDanh.aspx.cs" Inherits="kus_admin_PhieuGhiDanh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <link href="../App_Themes/admin/postnew.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Phiếu Ghi Danh <asp:Label ID="lblPhieuGhiDanh" CssClass="bold" runat="server"></asp:Label>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/QLGhiDanh.aspx">Quản lý Ghi danh</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">Phiếu Ghi Danh Học Viên</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-12 text-center">
            <h1 class="bold" style="color:#0094ff;">THÔNG TIN HỌC VIÊN GHI DANH</h1>
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
                    <div class="clearfix"></div><br />
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
            <table class="table table-bordered" border="1">
                <tr>
                    <td style="width:15%;" class="bold">Mã Ghi Danh : </td>
                    <td><asp:Label ID="lblMaGhiDanh" runat="server" Text="Label"></asp:Label></td>
                    <td style="width:15%;" class="bold">Lớp Học : </td>
                    <td><asp:Label ID="lblKhoaHoc" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td class="bold">Họ và Tên : </td>
                    <td>
                        <asp:Label ID="lblHoTenHV" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="bold">Điện thoại : </td>
                    <td>
                        <asp:Label ID="lblDienThoaiHV" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="bold">Học Phí : </td>
                    <td>
                        <asp:Label ID="lblHocPhi" CssClass="bold" ForeColor="Red" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="bold">Thời Lượng : </td>
                    <td>
                        <asp:Label ID="lblThoiLuong" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="bold">Tình trạng học phí : </td>
                    <td>
                        <i><asp:Label ID="lblTinhTrangHP" runat="server" Text="Label"></asp:Label></i>
                        <a id="btnmodalDongHP" href="#modalThanhToanHP" class="label label-success pull-right" data-toggle="modal" runat="server"><i class="fa fa-credit-card"></i> Đóng học phí</a>
                        <a id="btnXemBienLai" class="label label-success pull-right" onserverclick="btnXemBienLai_ServerClick" runat="server"><i class="fa fa-credit-card"> Xem biên lai</i></a>
                    </td>
                    <td class="bold">Đặt cọc : </td>
                    <td>
                        <asp:Label ID="lblDatCoc" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
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


    <%-- Modal Thanh toán học phí --%>
    <div class="modal fade" id="modalThanhToanHP" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title uppercase">
                        <i class="fa fa-credit-card"></i>
                        <asp:Label ID="lbltitleMaHV" runat="server" Text="Label"></asp:Label> - 
                        <asp:Label ID="lbltitleTenHV" CssClass="bold" runat="server" Text="Label"></asp:Label></h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Thời lượng (tiết): </label>
                                <asp:TextBox ID="txtHPThoiLuong" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label class="control-label">Ngày bắt đầu : </label>
                                <asp:TextBox ID="txtHPNgayKG" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label class="control-label">Ngày kết thúc : </label>
                                <asp:TextBox ID="txtHPNgayKT" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Học phí : </label>
                            <asp:TextBox ID="txtDongHP" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Đặt cọc : </label>
                                <asp:TextBox ID="txtHPDatCoc" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Lý do : </label>
                                <asp:TextBox ID="txtHPLyDo" CssClass="form-control" Text="Thu tiền Học phí" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="control-label">Giảm giá : </label>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtTLGiamHP" AutoPostBack="true" OnTextChanged="txtTLGiamHP_TextChanged" runat="server"></asp:TextBox>
                                            % =
                                    <asp:Label ID="lblNumGiamHP" runat="server" Text="Label"></asp:Label><br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTLGiamHP" ValidationGroup="validDongHP" ValidationExpression="^\d+$" ForeColor="Red" Display="Static" runat="server" ErrorMessage="Chỉ được nhập số !"></asp:RegularExpressionValidator>
                                            <asp:Label ID="lblwarning" ForeColor="Red" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="control-label">Phải đóng (<span>₫</span>): </label>
                                        <asp:TextBox ID="txtHPPhaiDong" ForeColor="Red" CssClass="form-control" runat="server"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="control-label">Số tiền bằng chữ : </label>
                                        <asp:TextBox ID="txtHPBangChu" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtTLGiamHP" EventName="TextChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Trở về</a>
                    <asp:Button ID="btnSaveBienLai" CssClass="btn btn-primary" ValidationGroup="validDongHP" OnClick="btnSaveBienLai_Click" runat="server" Text="Hoàn Tất" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Thanh toán học phí --%>


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

