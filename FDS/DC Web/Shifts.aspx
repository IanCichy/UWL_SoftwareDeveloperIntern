<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Shifts.aspx.cs" Inherits="Shifts" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <form runat="server">
        <br />
        <br />
        <div>
            <asp:GridView ID="gvShifts" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true"
                DataSourceID="sqlShifts" BorderWidth="1px" DataKeyNames="shiftID" OnRowCommand="gvShifts_RowCommand" OnRowCreated="gvShifts_RowCreated">
                <PagerStyle CssClass="pager-row" />
                <SortedAscendingCellStyle CssClass="Asc_Des_Cell" />
                <SortedAscendingHeaderStyle CssClass="Asc_Des_Header" />
                <SortedDescendingCellStyle CssClass="Asc_Des_Cell" />
                <SortedDescendingHeaderStyle CssClass="Asc_Des_Header" />
                <Columns>
                    <asp:BoundField DataField="eagleID" HeaderText="Employee" SortExpression="eagleID" />
                    <asp:TemplateField HeaderText="Start" SortExpression="start">
                        <ItemTemplate>
                            <%# Eval("start","{0:MMM d - H:MM tt}") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End" SortExpression="end">
                        <ItemTemplate>
                            <%# Eval("end","{0:MMM d - H:MM tt}")  %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="cashIn" HeaderText="Cash In" SortExpression="cashIn" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="cashOut" HeaderText="Cash Out" SortExpression="cashOut" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Notes">
                        <ItemTemplate>
                            <%# Limit(Eval("reasonNotBalanced")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDetails" runat="server" CommandName="ShiftDetails" Text="Shift Details" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlShifts" runat="server" SelectCommandType="StoredProcedure" SelectCommand="ShiftsForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="-1" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</asp:Content>