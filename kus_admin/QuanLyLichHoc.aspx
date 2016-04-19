<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="QuanLyLichHoc.aspx.cs" Inherits="kus_admin_QuanLyLichHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Quản lý lịch học
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                Quản lý học tập
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/QuanLyLichHoc.aspx">QL Lịch học</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-2">

            <%-- Date picker --%>
            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                <asp:TextBox ID="txDateStart" CssClass="form-control" runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                </span>
            </div>
            <%-- Date picker --%>
        </div>
        <div class="col-lg-2">
            <%-- Date picker --%>
            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                <asp:TextBox ID="txtDateEnd" CssClass="form-control" runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                </span>
            </div>
            <%-- Date picker --%>
        </div>
        <div class="col-lg-1">
            <asp:Button ID="btnGO" CssClass="btn green" runat="server" Text=" GO !" />
        </div>
    </div>

</asp:Content>

