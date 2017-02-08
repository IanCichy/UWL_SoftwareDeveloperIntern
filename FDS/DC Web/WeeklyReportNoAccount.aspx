<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WeeklyReportNoAccount.aspx.cs" Inherits="WeeklyReport" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content" ContentPlaceHolderID="body" runat="Server">
    <form id="Form1" runat="server">

        <asp:Label runat="server" Text="Weekly Non-Accountable Revenue Report For: " Font-Size="X-Large" />
        <asp:Label ID="lblHall" runat="server" Text="" Font-Size="X-Large" />
        <br />
        <asp:Label ID="lblDate" runat="server" Text="" Font-Size="X-Large" />
        <br />
        <br />
        <table class="table">
            <tr>
                <th></th>
                <th>Amount</th>
            </tr>
            <tr>
                <td>Products</td>
                <td>
                    <asp:Label runat="server" ID="lblProductRev" /></td>
            </tr>
            <tr>
                <td>Total Revenue</td>
                <td>
                    <asp:Label runat="server" ID="lblTotalRev" /></td>
            </tr>
        </table>
        <br />
        <asp:Button runat="server" ID="btnExport" Text="Export" OnClick="btnExport_Click" />

        <br />
        <br />
        <asp:Label runat="server" Text="Product Sales" Font-Size="Large" Font-Bold="true" Font-Underline="true" />
        <asp:GridView ID="gvWeeklyReportsProduct" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="false" PageSize="20"
            DataSourceID="sqlWeeklyReportsProducts" BorderWidth="1px">
            <PagerStyle CssClass="pager-row" />
            <EditRowStyle CssClass="edit-row" />
            <SortedAscendingCellStyle CssClass="Asc_Des_Cell" />
            <SortedAscendingHeaderStyle CssClass="Asc_Des_Header" />
            <SortedDescendingCellStyle CssClass="Asc_Des_Cell" />
            <SortedDescendingHeaderStyle CssClass="Asc_Des_Header" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="Inventory" HeaderText="Inventory" />
                <asp:BoundField DataField="TotalAmount" HeaderText="Total Quantity Sold" />
                <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <%# Amount((decimal)Eval("price"),(int)Eval("TotalAmount")).ToString("C2") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sqlWeeklyReportsProducts" runat="server" SelectCommandType="StoredProcedure" SelectCommand="WeeklyNonAccountableReportProducts">
            <SelectParameters>
                <asp:QueryStringParameter Name="ReportID" QueryStringField="Report" DefaultValue="-1" />
                <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="-1" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <br />
    </form>
</asp:Content>