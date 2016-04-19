<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrMultiLanguage.ascx.cs" Inherits="Controls_ctrMultiLanguage" %>
<div class="input-group">
    <span class="input-group-addon">
        <%--<i class="fa fa-flag"></i>--%>
        <img src="../images/logo/English-Language-Flag-1-icon.png" width="20" height="20" />
    </span>
    <asp:DropDownList ID="ddlLanguages" CssClass="form-control input-small pink" AutoPostBack="true" OnSelectedIndexChanged="ddlLanguages_SelectedIndexChanged" runat="server">
        <asp:ListItem Value="en-US">English</asp:ListItem>
        <asp:ListItem Value="vi-VN">Vietnamese</asp:ListItem>
    </asp:DropDownList>
</div>