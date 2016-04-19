<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="Upload_With_ProgessBar.aspx.cs" Inherits="Demo_In_Project_Upload_With_ProgessBar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row">

        <asp:AjaxFileUpload MaximumNumberOfFiles="1" AllowedFileTypes="mp4,MP4" ID="AjaxFileUpload1" OnUploadComplete="AjaxFileUpload1_UploadComplete" runat="server" />

    </div>

    

</asp:Content>

