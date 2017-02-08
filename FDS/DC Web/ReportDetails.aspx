﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportDetails.aspx.cs" Inherits="ReportDetails" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content" ContentPlaceHolderID="body" runat="Server">
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="jquery" runat="server">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
            </Scripts>
        </asp:ScriptManager>
        <br />
        <!---------------------View Reports!---------------->
        <div id="divPrintReports" runat="server">
            <asp:Button ID="btnViewWeeklyAccountable" runat="server" Text="Accountable Report" OnClick="btnViewWeeklyAccountable_Click" />
            <asp:Button ID="btnViewWeeklyNonAccountable" runat="server" Text="Non-Accountable Report" OnClick="btnViewWeeklyNonAccountable_Click" />
            <br />
            <br />
        </div>

        <div>
            <asp:GridView ID="gvShifts" runat="server" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false"
                DataSourceID="sqlShifts" BorderWidth="1px" DataKeyNames="shiftID" OnRowCommand="gvShifts_RowCommand">
                <PagerStyle CssClass="pager-row" />
                <Columns>
                    <asp:BoundField DataField="eagleID" HeaderText="Employee" SortExpression="eagleID" />
                    <asp:TemplateField HeaderText="Start" SortExpression="start">
                        <ItemTemplate>
                            <%# Eval("shiftStart","{0:MMM d - h:mm tt}") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End" SortExpression="end">
                        <ItemTemplate>
                            <%# Eval("shiftEnd","{0:MMM d - h:mm tt}")  %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="cashIn" HeaderText="Cash In" SortExpression="cashIn" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="cashOut" HeaderText="Cash Out" SortExpression="cashOut" DataFormatString="{0:C}" />

                    <asp:CheckBoxField DataField="countErrorPizza" HeaderText="Pizza" />
                    <asp:CheckBoxField DataField="countErrorCashIn" HeaderText="Cash In" />
                    <asp:CheckBoxField DataField="countErrorCashout" HeaderText="CashOut" />

                    <asp:CheckBoxField DataField="Resolved" HeaderText="Resolved" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDetails" runat="server" CommandName="ShiftDetails" Text="Shift Details" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlShifts" runat="server" SelectCommandType="StoredProcedure" SelectCommand="ShiftsInReport">
                <SelectParameters>
                    <asp:QueryStringParameter Name="ReportID" QueryStringField="Report" DefaultValue="-1" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <br />
        </div>
    </form>
</asp:Content>