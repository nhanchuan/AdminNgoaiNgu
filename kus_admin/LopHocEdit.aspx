<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="LopHocEdit.aspx.cs" Inherits="kus_admin_LopHocEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thông Tin Lớp Học
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/ListLopHoc.aspx">Quản lý lớp học</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/MoLopHoc.aspx">Mở lớp</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-4">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <label class="control-label">Hệ thống chi nhánh</label>
                        <asp:DropDownList ID="dlHTChiNhanh" CssClass="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="dlHTChiNhanh_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Chọn cơ sở</label>
                        <asp:DropDownList ID="dlCoSo" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Chương trình học</label>
                        <asp:DropDownList ID="dlKhoiLop" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlKhoiLop_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Cấp độ</label>
                        <asp:DropDownList ID="dlCapDo" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="form-group">
                <label class="control-label bold">Tên lớp học</label>
                <asp:TextBox ID="txtTenLopHoc" CssClass="form-control bold" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTenLopHoc" ValidationGroup="validNewLopHoc" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Tên lớp học không được trống !"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label class="control-label">Ngày khai giảng</label>
                <%-- Date picker --%>
                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                    <asp:TextBox ID="txtNgayKG" CssClass="form-control" runat="server"></asp:TextBox>
                    <span class="input-group-btn">
                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                    </span>
                </div>
                <%-- Date picker --%>
            </div>
            <div class="form-group">
                <label class="control-label">Thời lượng học</label>
                <asp:TextBox ID="txtThoiLuongHoc" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Ngày kết thúc</label>
                <%-- Date picker --%>
                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                    <asp:TextBox ID="txtNgayKT" CssClass="form-control" runat="server"></asp:TextBox>
                    <span class="input-group-btn">
                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                    </span>
                </div>
                <%-- Date picker --%>
            </div>
            <div class="form-group">
                <label class="control-label">Sỉ số tối đa</label>
                <asp:TextBox ID="txtSiSoToiDa" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label bold">Mức Học Phí</label>
                <asp:TextBox ID="txtMucHocPhi" CssClass="form-control bold text-danger" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="red"><i>Chú ý: Nếu thay đổi Ngày Khai Giảng hoặc Ngày Kết Thúc lịch học sẽ bị Reset !</i></label>
            </div>
            <asp:Button ID="btnLuuThongTin" CssClass="btn btn-primary" ValidationGroup="validNewLopHoc" OnClick="btnLuuThongTin_Click" runat="server" Text="Lưu Thông Tin" />
            <a class="btn btn-warning" href="../kus_admin/ListLopHoc.aspx">Hủy</a>
        </div>
        <%-- Module Lịch Học --%>
        <div class="col-lg-8">
            <h4 class="modal-title uppercase" style="color: blue;">
                <img src="../images/icon/Calendar-icon.png" width="35" height="35" />
                Chọn ngày giờ học
            </h4>
            <div class="clearfix"></div>
            <a id="btnCreateLichHoc" class="btn green" onserverclick="btnCreateLichHoc_ServerClick" runat="server">Lên lịch học</a>
            <div id="panelLichHoc" class="panel panel-info" runat="server">
                <div class="panel-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
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
                                        <asp:GridView ID="gwThu2Sang" CssClass="table table-bordered" OnRowDataBound="gwThu2Sang_RowDataBound" OnRowDeleting="gwThu2Sang_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu2Chieu" CssClass="table table-bordered" OnRowDataBound="gwThu2Chieu_RowDataBound" OnRowDeleting="gwThu2Chieu_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu2Toi" CssClass="table table-bordered" OnRowDataBound="gwThu2Toi_RowDataBound" OnRowDeleting="gwThu2Toi_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu3Sang" CssClass="table table-bordered" OnRowDataBound="gwThu3Sang_RowDataBound" OnRowDeleting="gwThu3Sang_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu3Chieu" CssClass="table table-bordered" OnRowDataBound="gwThu3Chieu_RowDataBound" OnRowDeleting="gwThu3Chieu_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu3Toi" CssClass="table table-bordered" OnRowDataBound="gwThu3Toi_RowDataBound" OnRowDeleting="gwThu3Toi_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu4Sang" CssClass="table table-bordered" OnRowDataBound="gwThu4Sang_RowDataBound" OnRowDeleting="gwThu4Sang_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu4Chieu" CssClass="table table-bordered" OnRowDataBound="gwThu4Chieu_RowDataBound" OnRowDeleting="gwThu4Chieu_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu4Toi" CssClass="table table-bordered" OnRowDataBound="gwThu4Toi_RowDataBound" OnRowDeleting="gwThu4Toi_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu5Sang" CssClass="table table-bordered" OnRowDataBound="gwThu5Sang_RowDataBound" OnRowDeleting="gwThu5Sang_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu5Chieu" CssClass="table table-bordered" OnRowDataBound="gwThu5Chieu_RowDataBound" OnRowDeleting="gwThu5Chieu_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu5Toi" CssClass="table table-bordered" OnRowDataBound="gwThu5Toi_RowDataBound" OnRowDeleting="gwThu5Toi_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu6Sang" CssClass="table table-bordered" OnRowDataBound="gwThu6Sang_RowDataBound" OnRowDeleting="gwThu6Sang_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu6Chieu" CssClass="table table-bordered" OnRowDataBound="gwThu6Chieu_RowDataBound" OnRowDeleting="gwThu6Chieu_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu6Toi" CssClass="table table-bordered" OnRowDataBound="gwThu6Toi_RowDataBound" OnRowDeleting="gwThu6Toi_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu7Sang" CssClass="table table-bordered" OnRowDataBound="gwThu7Sang_RowDataBound" OnRowDeleting="gwThu7Sang_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu7Chieu" CssClass="table table-bordered" OnRowDataBound="gwThu7Chieu_RowDataBound" OnRowDeleting="gwThu7Chieu_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwThu7Toi" CssClass="table table-bordered" OnRowDataBound="gwThu7Toi_RowDataBound" OnRowDeleting="gwThu7Toi_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwChuNhatSang" CssClass="table table-bordered" OnRowDataBound="gwChuNhatSang_RowDataBound" OnRowDeleting="gwChuNhatSang_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwChuNhatChieu" CssClass="table table-bordered" OnRowDataBound="gwChuNhatChieu_RowDataBound" OnRowDeleting="gwChuNhatChieu_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
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
                                        <asp:GridView ID="gwChuNhatToi" CssClass="table table-bordered" OnRowDataBound="gwChuNhatToi_RowDataBound" OnRowDeleting="gwChuNhatToi_RowDeleting" AutoGenerateColumns="False" ShowHeader="False" runat="server">
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
                                                        <asp:Label ID="lblgvtrungta21" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVTT").ToString())||string.IsNullOrWhiteSpace(Eval("GVTT").ToString()))?"###":"GV."+ Eval("EmpLname")+" "+Eval("EmpFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvnuocngoai21" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("GVHD").ToString())||string.IsNullOrWhiteSpace(Eval("GVHD").ToString()))?"###": "GVHĐ."+ Eval("GVHDLname")+" "+Eval("GVHDFname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelLH" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FAF3DF"></RowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>

                            <div class="clearfix"></div>
                            <div class="row">


                                <div class="col-lg-3">
                                    <asp:DropDownList ID="dlChoseWeekday" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="valWeekday" runat="server"
                                        ControlToValidate="dlChoseWeekday"
                                        ValidationGroup="validChoseLichhoc"
                                        Display="Dynamic"
                                        ForeColor="Red"
                                        ErrorMessage="Chưa chọn ngày học !"
                                        InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-3">
                                    <asp:DropDownList ID="dlChoseTietHoc" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlChoseTietHoc_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="dlChoseTietHoc"
                                        ValidationGroup="validChoseLichhoc"
                                        Display="Dynamic"
                                        ForeColor="Red"
                                        ErrorMessage="Chưa chọn tiết học !"
                                        InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-3">
                                    <asp:DropDownList ID="dlChosePhongHoc" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="dlChosePhongHoc"
                                        ValidationGroup="validChoseLichhoc"
                                        Display="Dynamic"
                                        ForeColor="Red"
                                        ErrorMessage="Chưa chọn phòng học !"
                                        InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-3">
                                    <asp:DropDownList ID="dlChoseSoTiet" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                        ControlToValidate="dlChoseSoTiet"
                                        ValidationGroup="validChoseLichhoc"
                                        Display="Dynamic"
                                        ForeColor="Red"
                                        ErrorMessage="Chưa chọn số tiết học !"
                                        InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="clearfix"></div><br />
                                <div class="row">
                                    <div class="col-lg-12">
                                        <%-- Chon Giao Vien --%>
                                        <div class="col-lg-3">
                                            <asp:DropDownList ID="dlGiaoVienTT" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:DropDownList ID="dlGiaoVienHD" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                        <%-- End Chon Giao Vien --%>

                                        <%-- Dem So tiet con lai --%>
                                        <div class="col-lg-3">
                                            <asp:Label ID="lvlCountSetted" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblCountSotietcon" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-3">
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="col-lg-12">
                                    <asp:Label ID="lblCheckAddLichHoc" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                                </div>
                                <br />
                                <div class="col-lg-3 pull-right text-right">
                                    <asp:Button ID="btnAddLichHoc" CssClass="btn btn-primary" ValidationGroup="validChoseLichhoc" OnClick="btnAddLichHoc_Click" runat="server" Text="Thêm Lịch Học" />
                                </div>
                                <div class="col-lg-12">
                                    <a onclick="lichhocEvent_click()"><i class="fa fa-calendar"></i> Xem Lịch học của tất cả các lớp tại Cơ Sở 
                                    <asp:Label ID="lblLichHocCoSo" CssClass="bold" runat="server" Text="Label"></asp:Label>
                                    </a>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="dlChoseTietHoc" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <%-- End  Module Lịch Học--%>
    </div>
    <script>
        function lichhocEvent_click() {
            var url = "../CalendarEvent/LichHocEvent.aspx";
            window.open(url, "myWindow", "width=1024, height=768,resizable=yes");
        }
    </script>
</asp:Content>

