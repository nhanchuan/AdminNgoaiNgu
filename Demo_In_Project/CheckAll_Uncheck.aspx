<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="CheckAll_Uncheck.aspx.cs" Inherits="Demo_In_Project_CheckAll_Uncheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                DataKeyNames="ID">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="ChkAll" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSel" class="chkSel" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="EmployeeId"
                        SortExpression="EmployeeId" />
                    <asp:BoundField DataField="FName" HeaderText="FirstName"
                        SortExpression="FirstName" />
                    <asp:BoundField DataField="Age" HeaderText="Age"
                        SortExpression="Age" />
                    <asp:BoundField DataField="Sex" HeaderText="Sex"
                        SortExpression="Sex" />
                </Columns>
            </asp:GridView>
            <br />

            <asp:Button ID="btnRetrieveCheck" runat="server"
                Text="Retrieve Checked Items" OnClick="btnRetrieveCheck_Click" />
        </div>
    </div>
    <script type='text/javascript'
src='http://jqueryjs.googlecode.com/files/jquery-1.3.2.min.js'></script>
<script type="text/javascript">
    $(document).ready(function() {
        var chkBox = $("#ContentPlaceHolder1_GridView1_ChkAll");
        chkBox.click(
             function() {
                 $("#ContentPlaceHolder1_GridView1 INPUT[type='checkbox']")
                 .attr('checked', chkBox
                 .is(':checked'));
             });

        // To deselect CheckAll when a GridView CheckBox
        // is unchecked
        $("#ContentPlaceHolder1_GridView1 INPUT[type='checkbox']").click(
        function(e) {
            if (!$(this)[0].checked) {
                chkBox.attr("checked", false);
            }
        });
    });
</script>
</asp:Content>

