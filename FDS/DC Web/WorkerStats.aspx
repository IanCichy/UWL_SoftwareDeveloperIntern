<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkerStats.aspx.cs" Inherits="WorkerStats" MasterPageFile="MasterPage.master" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="FrmWkrStats" runat="server">
        <br />
        <br />
        <asp:DropDownList runat="server" ID="ddlTerms" CssClass="dropdown" OnSelectedIndexChanged="ddlTerms_SelectedIndexChanged" AutoPostBack="true" />
        <br />
        <br />
        <div runat="server" id="divWorkerStats">
            <asp:GridView ID="gvWorkerStats" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="50"
                DataSourceID="sqlWorkerStats" BorderWidth="1px" OnRowCreated="gvWorkerStats_RowCreated">
                <PagerStyle CssClass="pager-row" />
                <EditRowStyle CssClass="edit-row" />
                <SortedAscendingCellStyle CssClass="Asc_Des_Cell" />
                <SortedAscendingHeaderStyle CssClass="Asc_Des_Header" />
                <SortedDescendingCellStyle CssClass="Asc_Des_Cell" />
                <SortedDescendingHeaderStyle CssClass="Asc_Des_Header" />
                <Columns>
                    <asp:BoundField DataField="EagleID" HeaderText="EagleID" SortExpression="EagleID" />
                    <asp:BoundField DataField="TotalShifts" HeaderText="Total Shifts" SortExpression="TotalShifts" />
                    <asp:BoundField DataField="countpizza" HeaderText="Pizza Errors" SortExpression="countpizza" />
                    <asp:BoundField DataField="countin" HeaderText="Cash In Errors" SortExpression="countin" />
                    <asp:BoundField DataField="countout" HeaderText="Cash Out Errors" SortExpression="countout" />
                    <asp:BoundField DataField="countBurnt" HeaderText="Burned Pizzas" SortExpression="countBurnt" />

                </Columns>
                <EmptyDataTemplate>
                    No Stats On Record For This Term
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlWorkerStats" runat="server" SelectCommandType="StoredProcedure" SelectCommand="WorkerStatsForHall">
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