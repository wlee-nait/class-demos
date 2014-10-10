﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RepeaterMenuCategories.aspx.cs" Inherits="DemoPages_RepeaterMenuCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Repeater Sample</h1>
    <h1>Our Menu Items</h1>
    <div class="row col-md-12">
        <asp:Repeater ID="CategoryList" runat="server" DataSourceID="ODSMenuCategoryItems">
            <ItemTemplate>
                <h3>
                    <%-- ~ = from the start of the website --%>
                    <%-- ../ = go up a layer --%>
                    <img src='<%#"../Images/" +  Eval("Description") + "-1.png" %>' alt=""
                        widt="80" height="80" />
                    <%# Eval("Description") %>
                </h3>
                <div class="well">
                <asp:Repeater ID="CategoryMenuItemList" runat="server"
                    DataSource='<%# Eval("MenuItems") %>'>
                    <ItemTemplate>
                        <h4>
                            <%# Eval("Description") %>
                            <%# ((decimal)Eval("Price")).ToString("C") %>
                            <span class="badge"><%# Eval("Calories") %>Calories</span>
                            <%# Eval("Comment") %>
                        </h4>
                    </ItemTemplate>
                </asp:Repeater>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:ObjectDataSource ID="ODSMenuCategoryItems" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategoryMenuItems" TypeName="eRestaurantSystem.BLL.eRestaurantController"></asp:ObjectDataSource>
</asp:Content>

