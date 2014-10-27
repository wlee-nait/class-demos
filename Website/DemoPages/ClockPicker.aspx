<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ClockPicker.aspx.cs" Inherits="DemoPages_ClockPicker" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="well">
        <div class="pull-right col-md-5">
            <h4>
                <small>Last Billed Date/Time:</small>
                <asp:Repeater ID="BilledDateRepeater" runat="server" 
                    DataSource="ODSRepeater"
                    ItemType="System.DateTime" >
                    <ItemTemplate>
                        <b class="label label-primary">
                            <%# Item.ToShortDateString() %>
                        </b>
                        <b class="label label-info">
                            <%# Item.ToShortTimeString() %>
                        </b>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:ObjectDataSource ID="ODSRepeater" runat="server"></asp:ObjectDataSource>
            </h4>
        </div>
        <h4>Mock Date/Time</h4>
        <asp:LinkButton ID="MockDateTime" runat="server" CssClass="btn btn-primary">
            Post-back new date/time
        </asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="MockLastBillingDateTime" runat="server" CssClass="btn btn-primary" OnClick="MockLastBillingDateTime_Click">
            Set to Last-Bill date/time
        </asp:LinkButton>
        &nbsp;&nbsp;
        <asp:TextBox ID="SearchDate" runat="server" TextMode="Date" Text="2014-10-27">

        </asp:TextBox>
        <asp:TextBox ID="SearchTime" runat="server" TextMode="Time" Text="15:00" CssClass="clockpicker">

        </asp:TextBox>
        <%--add clock picker--%>
        <script src="../Scripts/clockpicker.js"></script>
        <script type="text/javascript">
            $('.clockpicker').clockpicker({ donetext: 'Accept' });
        </script>
        <link itemprop="url" href="../Content/standalone.css" rel="stylesheet" />
        <link itemprop="url" href="../Content/clockpicker.css" rel="stylesheet" />
    </div>
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
</asp:Content>

