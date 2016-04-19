<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="Editer.aspx.cs" Inherits="Demo_In_Project_Editer" %>

<%@ Register Assembly="RichTextEditor" Namespace="RTE" TagPrefix="RTE" %>



<%@ Register Assembly="Obout.Ajax.UI" Namespace="Obout.Ajax.UI.HTMLEditor" TagPrefix="obout" %>
<%@ Register Assembly="Obout.Ajax.UI" Namespace="Obout.Ajax.UI.HTMLEditor.ToolbarButton" TagPrefix="obout" %>
<%@ Register Assembly="Obout.Ajax.UI" Namespace="Obout.Ajax.UI.HTMLEditor.Popups" TagPrefix="obout" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <RTE:Editor ID="Editor3" runat="server" />
    <cc1:Editor ID="Editor1" runat="server" />

    <obout:Editor ID="Editor2" runat="server" Height="300px" Width="100%"></obout:Editor>

    <obout:PopupHolder runat="server" ID="popupHolder">
        <Demand>
            <obout:FileBrowser runat="server" HideAddFolderButton="true" HideDeleteButton="true" HideUploadButton="false">
                <%-- Set different previewers for different files extensions --%>
                <Previews>
                    <%-- All Images here --%>
                    <obout:Preview Extensions="jpg;jpeg;gif;bmp;png"
                        TypeName="Obout.Ajax.UI.HTMLEditor.Popups.ImageBrowser" />
                </Previews>
            </obout:FileBrowser>
        </Demand>
    </obout:PopupHolder>

    <hr />
    <asp:Button ID="btnview" runat="server" OnClick="btnview_Click" Text="View Content" />

    <asp:TextBox ID="txtcontent" CssClass="form-control" TextMode="MultiLine" Rows="20" runat="server"></asp:TextBox>

</asp:Content>

