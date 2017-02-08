﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PizzaDelivery.aspx.cs" Inherits="PizzaDelivery" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="FrmPizzaDelivery" runat="server">
        <!--AngellHall
            -------
                   -->
        <div runat="server" id="divPizzaStats">
            <h2>Angell</h2>
            <asp:GridView ID="gvPizzaStats" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20"
                DataSourceID="sqlPizzaStats" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                    <asp:BoundField DataField="Inventory" HeaderText="Inventory" SortExpression="Inventory" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlPizzaStats" runat="server" SelectCommandType="StoredProcedure" SelectCommand="PizzaDeliveryForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="1" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <!--CoateHall
            -------
                   -->
        <div runat="server" id="div1">
            <h2>Coate</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20"
                DataSourceID="sqlPizzaStats1" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                    <asp:BoundField DataField="Inventory" HeaderText="Inventory" SortExpression="Inventory" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlPizzaStats1" runat="server" SelectCommandType="StoredProcedure" SelectCommand="PizzaDeliveryForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="2" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <!--DrakeHall
            -------
                   -->
        <div runat="server" id="div2">
            <h2>Drake</h2>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20"
                DataSourceID="sqlPizzaStats2" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                    <asp:BoundField DataField="Inventory" HeaderText="Inventory" SortExpression="Inventory" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlPizzaStats2" runat="server" SelectCommandType="StoredProcedure" SelectCommand="PizzaDeliveryForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="3" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <!--EagleHall
            -------
                   -->
        <div runat="server" id="div3">
            <h2>Eagle</h2>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20"
                DataSourceID="sqlPizzaStats3" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                    <asp:BoundField DataField="Inventory" HeaderText="Inventory" SortExpression="Inventory" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlPizzaStats3" runat="server" SelectCommandType="StoredProcedure" SelectCommand="PizzaDeliveryForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="4" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <!--HutchHall
            -------
                   -->
        <div runat="server" id="div4">
            <h2>Hutch</h2>
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20"
                DataSourceID="sqlPizzaStats4" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                    <asp:BoundField DataField="Inventory" HeaderText="Inventory" SortExpression="Inventory" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlPizzaStats4" runat="server" SelectCommandType="StoredProcedure" SelectCommand="PizzaDeliveryForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="5" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <!--LauxHall
            -------
                   -->
        <div runat="server" id="div5">
            <h2>Laux</h2>
            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20"
                DataSourceID="sqlPizzaStats5" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                    <asp:BoundField DataField="Inventory" HeaderText="Inventory" SortExpression="Inventory" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlPizzaStats5" runat="server" SelectCommandType="StoredProcedure" SelectCommand="PizzaDeliveryForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="6" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <!--ReuterHall
            -------
                   -->
        <div runat="server" id="div6">
            <h2>Reuter</h2>
            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20"
                DataSourceID="sqlPizzaStats6" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                    <asp:BoundField DataField="Inventory" HeaderText="Inventory" SortExpression="Inventory" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlPizzaStats6" runat="server" SelectCommandType="StoredProcedure" SelectCommand="PizzaDeliveryForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="7" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <!--SanfordHall
            -------
                   -->
        <div runat="server" id="div7">
            <h2>Sanford</h2>
            <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20"
                DataSourceID="sqlPizzaStats7" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                    <asp:BoundField DataField="Inventory" HeaderText="Inventory" SortExpression="Inventory" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlPizzaStats7" runat="server" SelectCommandType="StoredProcedure" SelectCommand="PizzaDeliveryForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="8" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <!--WentzHall
            -------
                   -->
        <div runat="server" id="div8">
            <h2>Wentz</h2>
            <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20"
                DataSourceID="sqlPizzaStats8" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                    <asp:BoundField DataField="Inventory" HeaderText="Inventory" SortExpression="Inventory" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlPizzaStats8" runat="server" SelectCommandType="StoredProcedure" SelectCommand="PizzaDeliveryForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="9" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <!--WhiteHall
            -------
                   -->
        <div runat="server" id="div9">
            <h2>White</h2>
            <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20"
                DataSourceID="sqlPizzaStats9" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                    <asp:BoundField DataField="Inventory" HeaderText="Inventory" SortExpression="Inventory" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlPizzaStats9" runat="server" SelectCommandType="StoredProcedure" SelectCommand="PizzaDeliveryForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="10" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <br />
        <br />
    </form>
</asp:Content>