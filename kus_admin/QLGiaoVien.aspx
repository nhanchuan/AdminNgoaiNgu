<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="QLGiaoVien.aspx.cs" Inherits="kus_admin_QLGiaoVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Quản Lý Giáo Viên
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>Quản lý Giảng dạy
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/QLGiaoVien.aspx">Quản lý giáo viên</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-12">
            <h2>Danh sách giáo viên hợp đồng</h2>
            <a href="#modalAddGiaoVienHD" class="btn green" data-toggle="modal"><i class="fa fa-file"></i> Thêm Giáo Viên Hợp Đồng</a>
            <a id="btlichsunhopdonggv" href="#modalHistoryHD" data-toggle="modal" class="btn btn-warning" runat="server"><i class="fa fa-history"></i>Lịch Sử Hợp đồng</a>
            <a id="btnnhapHD" href="#modalnhapHD" class="btn btn-primary" data-toggle="modal" runat="server">Nhập Hợp đồng</a>
            <a id="btnEditInfor" href="#modalEditGVInfor" data-toggle="modal" class="btn btn-info" runat="server"><i class="fa fa-pencil-square"></i> Chỉnh sửa thông tin</a>
            <div class="clearfix"></div>


            <asp:GridView ID="gwGVHopDong" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwGVHopDong_SelectedIndexChanged" OnRowDataBound="gwGVHopDong_RowDataBound" OnRowDeleting="gwGVHopDong_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Họ">
                        <ItemTemplate>
                            <asp:Label ID="lblGVID" CssClass="display-none" runat="server" Text='<%# Eval("GVID") %>'></asp:Label>
                            <asp:Label ID="lblLastname" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ngày sinh">
                        <ItemTemplate>
                            <asp:Label ID="lblBirthday" runat="server" Text='<%# Eval("Birthday","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Giới tính">
                        <ItemTemplate>
                            <asp:Label ID="lblSex" runat="server" Text='<%# (Eval("Sex").ToString()=="1")?"Nam":"Nữ" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CMND">
                        <ItemTemplate>
                            <asp:Label ID="lblCMND" runat="server" Text='<%# Eval("CMND") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Địa chỉ">
                        <ItemTemplate>
                            <asp:Label ID="lblGVAddress" runat="server" Text='<%# Eval("GVAddress") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Điện thoại">
                        <ItemTemplate>
                            <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="Ghi chú">
                        <ItemTemplate>
                            <asp:Label ID="lblGhiChu" runat="server" Text='<%# Eval("GhiChu") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate>
                            <asp:Label ID="lblTinhTrangHD" CssClass="label label-success" runat="server" Text='<%# (Eval("NumHD").ToString()=="0")?"Chưa có hợp đồng":"đã có hợp đồng" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnViewLichGiang" CommandArgument='<%# Eval("GVID") %>' OnClick="btnViewLichGiang_Click" runat="server"><i class="icon-calendar"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkBtnDelGVHopDong" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><img src="../images/icon/Actions-edit-delete-icon.png" width="20" height="20" /></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                <HeaderStyle BackColor="#FFB848" ForeColor="White"></HeaderStyle>
                <RowStyle BackColor="#FAF3DF"></RowStyle>
            </asp:GridView>





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
        <div class="col-lg-12">
            <h2>Danh sách Giáo viên tại Trung Tâm</h2>
            <asp:GridView ID="gwGiaoVienTrungtam" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                <Columns>
                    <asp:TemplateField HeaderText="Mã Giáo Viên">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeesCode" runat="server" Text='<%# Eval("EmployeesCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên Giáo Viên">
                        <ItemTemplate>
                            <asp:Label ID="lbltenGV" runat="server" Text='<%# Eval("LastName") +" "+ Eval("FirstName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ngày sinh">
                        <ItemTemplate>
                            <asp:Label ID="lblBirthday" runat="server" Text='<%# Eval("Birthday","{0:dd-MM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Giới Tính">
                        <ItemTemplate>
                            <asp:Label ID="lblSex" runat="server" Text='<%# (Eval("Sex").ToString()=="1")?"Nam":"Nữ" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Emal Giáo Viên">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số điện thoại Giáo Viên">
                        <ItemTemplate>
                            <asp:Label ID="lblMobileNumber" runat="server" Text='<%# Eval("MobileNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblgvSelect" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnViewLichGiangTT" CommandArgument='<%# Eval("EmployeesID") %>' OnClick="btnViewLichGiangTT_Click" runat="server"><i class="icon-calendar"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                <HeaderStyle BackColor="#FFB848" ForeColor="White"></HeaderStyle>
                <RowStyle BackColor="#FAF3DF"></RowStyle>
            </asp:GridView>
            <div class="form-group">
                <!-- BEGIN PAGINATOR -->
                <div class="row">
                    <div class="col-md-4 col-sm-4 items-info">
                    </div>
                    <div class="col-md-8 col-sm-8">
                        <div class="pagination_lst pull-right">
                            <asp:Repeater ID="rpGVTT" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkGVTTPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                        CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                        OnClick="GVTTPage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
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

    <%-- Modal Add Giao vien Hop dong --%>
    <div class="modal fade" id="modalAddGiaoVienHD" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title uppercase">
                        <img src="../images/icon/Books-1-icon.png" width="35" height="35" />
                        Thêm Giáo Viên Hợp đồng
                    </h4>
                </div>
                <div class="modal-body background">
                    <div class="form-group">
                        <label class="control-label">Họ : </label>
                        <asp:TextBox ID="txtlastnameIn" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Tên (*): </label>
                        <asp:TextBox ID="txtfirstnameIn" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtfirstnameIn" ValidationGroup="validHopDongIn" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Tên không được để trống !"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Giới tính </label>
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
                    <div class="row">
                        <div class="col-lg-5">
                            <div class="form-group">
                                <label class="control-label">Ngày sinh</label>
                                <%-- Date picker --%>
                                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                    <asp:TextBox ID="txtNgaySinhIn" CssClass="form-control" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                                <%-- Date picker --%>
                                
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-5">
                            <div class="form-group">
                                <label class="control-label">Số CMND</label>
                                <asp:TextBox ID="txtSoCMNDIn" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Địa chỉ thường trú</label>
                                <asp:TextBox ID="txtDCThuongTru" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Email</label>
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                    ControlToValidate="txtEmail"
                                    ValidationGroup="validHopDongIn"
                                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                    Display="Dynamic" ForeColor="Red"
                                    ErrorMessage="E-mail không hợp lệ ! { Ví dụ hợp lệ: abc@gmail.com }">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Điện thoại</label>
                                <asp:TextBox ID="txtPhoneIn" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPhoneIn" ValidationGroup="validHopDongIn" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Điện thoại không được để trống !"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                    ControlToValidate="txtPhoneIn"
                                    ValidationGroup="validHopDongIn"
                                    ValidationExpression="\(?([0-9]{3,4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})"
                                    ErrorMessage="<%$Resources:Resource, incorectphonenumber %>"
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Ghi chú</label>
                                <asp:TextBox ID="txtGhiChuIn" CssClass="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-7">
                            <label class="control-label">Mô tả giáo viên</label>
                            <CKEditor:CKEditorControl ID="CKContentDescription" Height="500px" Toolbar="Basic" runat="server"></CKEditor:CKEditorControl>

                        </div>
                    </div>
                    


                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnthemgiaovienHD" CssClass="btn green pull-right" ValidationGroup="validHopDongIn" OnClick="btnthemgiaovienHD_Click" runat="server" Text="Thêm Giáo Viên" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Add Giao vien Hop dong --%>


    <%-- Modal Edit Giao vien Hop dong --%>
    <div class="modal fade" id="modalEditGVInfor" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title uppercase">
                        <img src="../images/icon/Books-1-icon.png" width="35" height="35" />
                        Chỉnh sửa thông tin
                    </h4>
                </div>
                <div class="modal-body background">
                    <div class="form-group">
                        <label class="control-label">Họ : </label>
                        <asp:TextBox ID="txtElastname" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Tên (*): </label>
                        <asp:TextBox ID="txtEFirstname" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtEFirstname" ValidationGroup="validEditHopDongIn" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Tên không được để trống !"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Giới tính </label>
                        <div class="radio-list">
                            <label class="radio-inline">
                                <input type="radio" name="optionsRadios" id="rdEnam" value="option1" runat="server" />
                                Nam
                            </label>
                            <label class="radio-inline">
                                <input type="radio" name="optionsRadios" id="rdENu" value="option2" runat="server" />
                                Nữ
                            </label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-5">
                            <div class="form-group">
                                <label class="control-label">Ngày sinh</label>
                                <%-- Date picker --%>
                                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                    <asp:TextBox ID="txtEngaysinh" CssClass="form-control" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                                <%-- Date picker --%>
                                
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-5">
                            <div class="form-group">
                                <label class="control-label">Số CMND</label>
                                <asp:TextBox ID="txtEscmnd" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Địa chỉ thường trú</label>
                                <asp:TextBox ID="txtEDiaChiTT" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Email</label>
                                <asp:TextBox ID="txtEEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                    ControlToValidate="txtEEmail"
                                    ValidationGroup="validEditHopDongIn"
                                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                    Display="Dynamic" ForeColor="Red"
                                    ErrorMessage="E-mail không hợp lệ ! { Ví dụ hợp lệ: abc@gmail.com }">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Điện thoại</label>
                                <asp:TextBox ID="txtEPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtEPhone" ValidationGroup="validHopDongIn" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Điện thoại không được để trống !"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                    ControlToValidate="txtEPhone"
                                    ValidationGroup="validEditHopDongIn"
                                    ValidationExpression="\(?([0-9]{3,4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})"
                                    ErrorMessage="<%$Resources:Resource, incorectphonenumber %>"
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Ghi chú</label>
                                <asp:TextBox ID="txtEGhiChu" CssClass="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-7">
                            <label class="control-label">Mô tả giáo viên</label>
                            <CKEditor:CKEditorControl ID="CKEditorEMota" Height="500px" Toolbar="Basic" runat="server"></CKEditor:CKEditorControl>

                        </div>
                    </div>
                    
                </div>
                <div class="modal-footer">
                    <a class="btn btn-default" data-dismiss="modal">Cancel</a>
                    <asp:Button ID="btnSaveEdit" CssClass="btn green pull-right" ValidationGroup="validEditHopDongIn" OnClick="btnSaveEdit_Click" runat="server" Text="Lưu thông tin" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Update Giao vien Hop dong --%>

    <%-- Lịch sử hợp đồng --%>
    <div class="modal fade" id="modalHistoryHD" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title uppercase">
                        <img src="../images/icon/Books-1-icon.png" width="35" height="35" />
                        Lịch sử hợp đồng Hợp đồng
                    </h4>
                </div>
                <div class="modal-body background">
                    <asp:GridView ID="gwlstHDGV" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                        <Columns>
                            <asp:TemplateField HeaderText="Mã Hợp Đồng">
                                <ItemTemplate>
                                    <asp:Label ID="lblHopDongCode" runat="server" Text='<%# Eval("HopDongCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ngày Hợp Đồng">
                                <ItemTemplate>
                                    <asp:Label ID="lbNgayHopDong" runat="server" Text='<%# Eval("NgayHopDong","{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thời Hạn Hợp Đồng">
                                <ItemTemplate>
                                    <asp:Label ID="lbThoiHan" runat="server" Text='<%# Eval("ThoiHan") %>'></asp:Label> tháng
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tình Trạng">
                                <ItemTemplate>
                                    <asp:Label ID="lbTinhTrangHD" CssClass="label label-success" runat="server" Text='<%# (Eval("TinhTrangHD").ToString()=="1")?"đang hợp đồng":"ngưng hợp đồng trước thời hạn" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                        <HeaderStyle BackColor="#FFB848" ForeColor="White"></HeaderStyle>
                        <RowStyle BackColor="#FAF3DF"></RowStyle>
                    </asp:GridView>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-info" data-dismiss="modal">Close</a>
                </div>
            </div>
        </div>
    </div>
    <%-- End LS hợp đòng --%>

    <%-- Nhập hợp đồng --%>
    <div class="modal fade" id="modalnhapHD" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title uppercase">
                        <img src="../images/icon/Books-1-icon.png" width="35" height="35" />
                        Nhập Hợp Đồng Mới
                    </h4>
                </div>
                <div class="modal-body background">
                    <div class="row">
                        <div class="col-lg-5">
                            <div class="form-group">
                                <label class="control-label">Ngày Hợp Đồng</label>
                                <%-- Date picker --%>
                                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                    <asp:TextBox ID="txtNhapNgayHD" CssClass="form-control" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                                <%-- Date picker --%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNhapNgayHD" ValidationGroup="validNhapHopDong" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Ngày Hợp Đồng không được bỏ trống !"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Thời hạn (THÁNG)</label>
                        <asp:TextBox ID="txtthoihannhaphd" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtthoihannhaphd" ValidationGroup="validNhapHopDong" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Thời hạn không được bỏ trống !"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtthoihannhaphd" ValidationGroup="validNhapHopDong" runat="server" ForeColor="Red" Display="Dynamic" ValidationExpression="^\d+$" ErrorMessage="Chỉ được nhập số !"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-info" data-dismiss="modal">Close</a>
                    <asp:Button ID="btnnhapHDGV" CssClass="btn btn-primary" ValidationGroup="validNhapHopDong" runat="server" OnClick="btnnhapHDGV_Click" Text="Nhập Hợp Đồng" />
                    
                </div>
            </div>
        </div>
    </div>
    <%-- Nhập Hợp đồng --%>
    <script>
        function lichdayEvent_click() {
            var url = "../CalendarEvent/LichDayEvent.aspx";
            window.open(url, "myWindow", "width=1024, height=768,resizable=yes");
        }
    </script>
</asp:Content>

