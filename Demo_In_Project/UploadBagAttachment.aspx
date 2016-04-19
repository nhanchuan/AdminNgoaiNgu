<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="UploadBagAttachment.aspx.cs" Inherits="Demo_In_Project_UploadBagAttachment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <div class="form-group">
                <label class="control-label"><i class="fa fa-paperclip"></i>File đính kèm (* file Pdf | Word | Excel | Images ) :</label>
                <asp:AjaxFileUpload ID="uploadBagAttachments" MaximumNumberOfFiles="5" 
                    AllowedFileTypes="doc,DOC,docx,DOCX,txt,TXT,xlsx,XLSX,xlsm,XLSM,xls,XLS,xlt,XLT,ppt,PPT,pptx,PPTX,pdf,PDF,jpg,JPG,png,PNG"
                    OnUploadComplete="uploadBagAttachments_UploadComplete" 
                    runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

