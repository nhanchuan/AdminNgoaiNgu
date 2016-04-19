<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="DayOfWith.aspx.cs" Inherits="Demo_In_Project_DayOfWith" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-lg-3">
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
        <div class="clearfix"></div><br />
        <div class="col-lg-12">
            <asp:Button ID="btnpick" runat="server" OnClick="btnpick_Click" Text="WeekDay" /><br />
        <asp:Label ID="lblweekday" CssClass="bold" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    
</asp:Content>

