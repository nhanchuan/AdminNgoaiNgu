<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="QuanLyHocVien.aspx.cs" Inherits="kus_admin_QuanLyHocVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Quản lý học viên
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">Mục tư vấn</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/QuanLyHocVien.aspx">Lớp học</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-4">
            <div class="form-horizontal">
                <h4><i>Tìm học viên</i></h4>
                <div class="form-body">
                    <%-- /Row --%>
                    <div class="row">
                        <div class="form-group">
                            <label class="control-label col-md-5">Thuộc loại chương trình</label>
                            <div class="col-md-7">
                                <asp:DropDownList ID="dlLoaiChuongTrinh" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="form-group">
                            <label class="control-label col-md-5">Thuộc chương trình</label>
                            <div class="col-md-7">
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="form-group">
                            <label class="control-label col-md-5">Thuộc lớp</label>
                            <div class="col-md-7">
                                <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="form-group">
                            <label class="control-label col-md-5">Thuộc khóa</label>
                            <div class="col-md-7">
                                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-8">
            <h4><i>Thông tin cá nhân</i></h4>
            <div class="form-horizontal">
                <div class="form-body">
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Mã học viên</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Tên học viên</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Email</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Điện thoại</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Số CMND</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Họ tên Phụ huynh</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-12">
                            
                                <a class="btn btn-default"><i class="fa fa-search"></i> Tìm</a>
                            
                        </div>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

