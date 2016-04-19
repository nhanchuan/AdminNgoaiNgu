<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="Tabs_accordions_navs.aspx.cs" Inherits="Demo_In_Project_Tabs_accordions_navs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="tabbable-custom ">
            <ul class="nav nav-tabs ">
                <li class="active">
                    <a href="#tab_content_vi" data-toggle="tab">Content VN </a>
                </li>
                <li>
                    <a href="#tab_content_en" data-toggle="tab">Content EN </a>
                </li>
            </ul>
            <div class="tab-content">
                <div class="tab-pane active" id="tab_content_vi">
                    <%--  --%>
                </div>
                <div class="tab-pane" id="tab_content_en">
                    <%--  --%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

