<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="timePicker.aspx.cs" Inherits="Demo_In_Project_timePicker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <link href="../assets/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <div class="form-group">
        <div class="input-group date form_meridian_datetime input-large">
            <input type="text" size="16" class="form-control" id="timePost" runat="server" />
            <span class="input-group-btn">
                <button class="btn default date-reset" type="button"><i class="fa fa-times"></i></button>
            </span>
            <span class="input-group-btn">
                <button class="btn default date-set" type="button"><i class="fa fa-calendar"></i></button>
            </span>
        </div>
        <br />
        <asp:Button ID="btnUpdateTimePost" CssClass="btn green pull-right" ValidationGroup="validtimepost" runat="server" Text="Update Time" />
    </div>
   
    <script src="../assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
</asp:Content>

