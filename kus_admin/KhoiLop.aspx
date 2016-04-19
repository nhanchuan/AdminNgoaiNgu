<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="KhoiLop.aspx.cs" Inherits="kus_admin_KhoiLop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Khối Lớp Đào Tạo
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/KhoiLop.aspx">Khối lớp</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <%--<h1>Giờ học và thi tại trung tâm</h1>--%>
        <div class="clearfix"></div>
        <div class="col-lg-5">
            <p class="font-blue bold" style="font-size: 18px;">Danh sách Khối Lớp đào tạo tại trung tâm</p>
            <asp:GridView ID="gvKhoiLop" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" ShowFooter="True" OnRowCancelingEdit="gvKhoiLop_RowCancelingEdit" OnRowEditing="gvKhoiLop_RowEditing" OnRowUpdating="gvKhoiLop_RowUpdating" OnRowDataBound="gvKhoiLop_RowDataBound" OnRowDeleting="gvKhoiLop_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Mã Khối">
                        <ItemTemplate>
                            <asp:Label ID="lblKhoiLop_ID" runat="server" Text='<%# Bind("KhoiLopID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên Khối">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTenKhoi" runat="server" Text='<%# Bind("TenKhoiLop") %>' CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TenKhoiLop") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAddTenKhoi" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tên khối không được bỏ trống" ControlToValidate="txtAddTenKhoi"
                                 Display="None" ValidationGroup="Error"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mô Tả">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMoTa" runat="server" Text='<%# Bind("MoTaNgan") %>' CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("MoTaNgan") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAddMoTa" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Mô tả không được bỏ trống" ControlToValidate="txtAddMoTa"
                                 Display="None" ValidationGroup="Error"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lkDelKhoiLop" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnAddNew" runat="server" Text="Thêm" CssClass="btn btn-success" OnClick="btnAddNew_Click" ValidationGroup="Error" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                <RowStyle BackColor="#A1DCF2"></RowStyle>
                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
            </asp:GridView>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Error" />
        </div>
        <div class="col-lg-7">
            <p class="font-blue bold" style="font-size: 18px;">Giới thiệu</p>
            <div class="row">
                <div class="col-md-3">
                    <ul class="ver-inline-menu tabbable margin-bottom-10">
                        <li class="active">
                            <a data-toggle="tab" href="#tab_1">
                                <i class="fa fa-briefcase"></i>Anh Văn Mẫu Giáo </a>
                            <span class="after"></span>
                        </li>
                        <li>
                            <a data-toggle="tab" href="#tab_2">
                                <i class="fa fa-group"></i>Anh Văn Thiếu Nhi </a>
                        </li>
                        <li>
                            <a data-toggle="tab" href="#tab_3">
                                <i class="fa fa-leaf"></i>Anh Văn Thiếu Niên </a>
                        </li>
                        <li>
                            <a data-toggle="tab" href="#tab_1">
                                <i class="fa fa-info-circle"></i>AV Giao Tiếp, Tổng Quát </a>
                        </li>
                        <li>
                            <a data-toggle="tab" href="#tab_2">
                                <i class="fa fa-tint"></i>Tiếng Anh Du Học </a>
                        </li>
                        <li>
                            <a data-toggle="tab" href="#tab_3">
                                <i class="fa fa-plus"></i>Other Questions </a>
                        </li>
                    </ul>
                </div>
                <div class="col-md-9">
                    <div class="tab-content">
                        <div id="tab_1" class="tab-pane active">
                            <div id="accordion1" class="panel-group">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_1">MỤC TIÊU </a>
                                        </h4>
                                    </div>
                                    <div id="accordion1_1" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                            <ul>
                                                <li>
                                                    Chương trình anh văn mẫu giáo dành cho các bé từ 3.5 đến 6 tuổi.
                                                </li>
                                                <li>
                                                    Chương trình được xây dựng dựa trên phương pháp tiên tiến.
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_2">LỢI ÍCH </a>
                                        </h4>
                                    </div>
                                    <div id="accordion1_2" class="panel-collapse collapse">
                                        <div class="panel-body">
                                           <ul>
                                               <li>
                                                   Các phòng học tương tác được trang trí sinh động
                                               </li>
                                               <li>
                                                   Các bé sẽ được trải nghiệm phương pháp học dựa theo chuẩn quốc tế.
                                               </li>
                                           </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_3">3. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion1_3" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-warning">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_4">4. Wolf moon officia aute, non cupidatat skateboard dolor brunch ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion1_4" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-danger">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_5">5. Leggings occaecat craft beer farm-to-table, raw denim aesthetic ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion1_5" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_6">6. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion1_6" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_7">7. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion1_7" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tab_2" class="tab-pane">
                            <div id="accordion2" class="panel-group">
                                <div class="panel panel-warning">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_1">1. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion2_1" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                            <p>
                                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                            </p>
                                            <p>
                                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-danger">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_2">2. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion2_2" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_3">3. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion2_3" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_4">4. Wolf moon officia aute, non cupidatat skateboard dolor brunch ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion2_4" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_5">5. Leggings occaecat craft beer farm-to-table, raw denim aesthetic ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion2_5" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_6">6. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion2_6" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_7">7. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion2_7" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tab_3" class="tab-pane">
                            <div id="accordion3" class="panel-group">
                                <div class="panel panel-danger">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_1">1. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion3_1" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                            <p>
                                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et.
                                            </p>
                                            <p>
                                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et.
                                            </p>
                                            <p>
                                                Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_2">2. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion3_2" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_3">3. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion3_3" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_4">4. Wolf moon officia aute, non cupidatat skateboard dolor brunch ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion3_4" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_5">5. Leggings occaecat craft beer farm-to-table, raw denim aesthetic ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion3_5" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_6">6. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion3_6" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_7">7. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft ? </a>
                                        </h4>
                                    </div>
                                    <div id="accordion3_7" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

