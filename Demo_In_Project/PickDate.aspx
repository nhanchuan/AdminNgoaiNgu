<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="PickDate.aspx.cs" Inherits="Demo_In_Project_PickDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="input-group input-medium date date-picker" data-date-format="dd-mm-yyyy">
            <input type="text" class="form-control" />
            <span class="input-group-btn">
                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
            </span>
        </div>
    </div>
</asp:Content>

