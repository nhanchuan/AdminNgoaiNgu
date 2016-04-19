<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="EmbedGoogleDrive.aspx.cs" Inherits="Demo_In_Project_EmbedGoogleDrive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <iframe src="https://drive.google.com/embeddedfolderview?id=0B7ksZoaSf_X1b3lNaHRtN092N2s#list" width="1366" height="768" frameborder="1"></iframe>
       <%-- <iframe src="https://drive.google.com/embeddedfolderview?id=0B1iqp0kGPjWsNDg5NWFlZjEtN2IwZC00NmZiLWE3MjktYTE2ZjZjNTZiMDY2#grid" width="800" height="600" frameborder="0"></iframe>--%>
    </div>
    
</asp:Content>

