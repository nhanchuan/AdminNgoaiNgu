<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="CKEditor.aspx.cs" Inherits="Demo_In_Project_CKEditor" %>

<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel-default">
        <div class="panel-body">
            <%--<CKEditor:CKEditorControl ID="CKEditor1" EnterMode="P" Toolbar="Full" runat="server"></CKEditor:CKEditorControl>--%>
            <CKEditor:CKEditorControl ID="CKEditor1" runat="server"
                Toolbar="Full"
                ContentsLangDirection="Ui"
                DialogButtonsOrder="OS"
                EnterMode="BR"
                ResizeDir="Both"
                ShiftEnterMode="P"
                StartupMode="Wysiwyg" 
                ToolbarLocation="Top">
            </CKEditor:CKEditorControl>
        </div>
    </div>
  
</asp:Content>

