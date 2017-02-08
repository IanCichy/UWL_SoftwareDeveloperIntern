﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductStats.aspx.cs" Inherits="ProductStats" MasterPageFile="MasterPage.master" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="FrmProdStats" runat="server">
        <br />
        <br />
        <asp:DropDownList runat="server" ID="ddlTerms" CssClass="dropdown" OnSelectedIndexChanged="ddlTerms_SelectedIndexChanged" AutoPostBack="true" />
        <br />
        <br />
        <div runat="server" id="divProductStats">
            <asp:GridView ID="gvProductStats" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20"
                DataSourceID="sqlProductStats" BorderWidth="1px" OnRowCreated="gvProductStats_RowCreated">
                <PagerStyle CssClass="pager-row" />
                <EditRowStyle CssClass="edit-row" />
                <SortedAscendingCellStyle CssClass="Asc_Des_Cell" />
                <SortedAscendingHeaderStyle CssClass="Asc_Des_Header" />
                <SortedDescendingCellStyle CssClass="Asc_Des_Cell" />
                <SortedDescendingHeaderStyle CssClass="Asc_Des_Header" />
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="price" />
                    <asp:BoundField DataField="TotalCount" HeaderText="Total Transactions" SortExpression="TotalCount" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Quantity Sold" SortExpression="TotalAmount" />
                    <asp:BoundField DataField="lastSold" HeaderText="Last Sold" SortExpression="lastSold" />
                </Columns>
                <EmptyDataTemplate>
                    No Stats On Record For This Term
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlProductStats" runat="server" SelectCommandType="StoredProcedure" SelectCommand="ProductStatsForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="-1" />
                    <asp:SessionParameter Name="startDate" SessionField="startDate" DefaultValue="7/1/2014" />
                    <asp:SessionParameter Name="endDate" SessionField="endDate" DefaultValue="12/30/2099" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <br />
        <br />
    </form>
</asp:Content>