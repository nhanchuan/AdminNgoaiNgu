<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="TimerTick.aspx.cs" Inherits="Pages_TimerTick" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script runat="server" type="text/c#">
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "Panel refreshed at: " + DateTime.Now.ToLongTimeString();
        }
    </script>
    <div class="panel-default">
        <div class="panel-body">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                    <asp:Timer runat="server" ID="Timer1" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
                    <asp:Label runat="server" Text="Page not refreshed yet." ID="Label1">
                    </asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:Label runat="server" Text="Label" ID="Label2"></asp:Label>
        </div>
    </div>
</asp:Content>

