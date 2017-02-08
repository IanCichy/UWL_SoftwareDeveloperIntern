﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MakeNewReport.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="MakeNewReport" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <form id="Form1" runat="server">
        <div>
            <br />
            <br />
            <asp:Label runat="server" Text="Make New Weekly Report" />
            <asp:Calendar ID="cldrReport" runat="server" SelectionMode="DayWeek" OnSelectionChanged="cldrReport_SelectionChanged"
                TodayDayStyle-BackColor="#CCA0A0" SelectWeekText="-›" CssClass="Calendar" SelectedDayStyle-BackColor="#B58484" />
            <asp:Label ID="lblStart" runat="server" Text="Start Date:&nbsp&nbsp" />
            <asp:TextBox ID="txtStart" runat="server" placeholder="Select A Week Above" />
            <br />
            <asp:Label ID="lblEnd" runat="server" Text="End Date:&nbsp&nbsp&nbsp&nbsp" />
            <asp:TextBox ID="txtEnd" runat="server" placeholder="Select A Week Above" />
            <br />
            <asp:Label ID="lblTitle" runat="server" Text="Report Title: " />
            <asp:TextBox ID="txtTitle" runat="server" placeholder="Enter A Title" />
            <br />
            <!--Buttons-->
            <br />
            <asp:Button ID="btnSearch" runat="server" Text="Update Shifts" />
            <asp:Button ID="btnAutoDate" runat="server" Text="Auto Date" OnClick="btnAutoDate_Click" />
            <asp:Button ID="btnCheckAll" runat="server" Text="Select All Shifts" OnClick="btnCheckAll_Click" />
            <br />
            <asp:Button ID="btnMakeReport" runat="server" OnClick="btnMakeReport_Click" Text="Make New Report" />
            <br />
            <br />
            <!---------------------GridView!---------------->
            <asp:GridView ID="gvShifts" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="75"
                DataSourceID="sqlShifts" BorderWidth="1px" DataKeyNames="shiftID" OnRowCommand="gvShifts_RowCommand">
                <PagerStyle CssClass="pager-row" />
                <Columns>
                    <asp:BoundField DataField="eagleID" HeaderText="Employee" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Shift Start">
                        <ItemTemplate>
                            <%# Eval("shiftStart","{0:MMM d - HH:mm tt}") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shift End">
                        <ItemTemplate>
                            <%# Eval("shiftEnd","{0:MMM d - H:mm tt}")  %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="cashIn" HeaderText="Cash In" DataFormatString="{0:C}" ReadOnly="True" />
                    <asp:BoundField DataField="cashOut" HeaderText="Cash Out" DataFormatString="{0:C}" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Notes">
                        <ItemTemplate>
                            <%# Limit(Eval("reasonNotBalanced")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Include In Report">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="isReported" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDetails" runat="server" CommandName="ShiftDetails" Text="Shift Details" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlShifts" runat="server" SelectCommandType="StoredProcedure" SelectCommand="ShiftsForHall"
                FilterExpression="shiftStart >= #{0}# AND shiftStart <= #{1}#">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="-1" />
                </SelectParameters>
                <FilterParameters>
                    <asp:ControlParameter Name="startDate" ControlID="txtStart" PropertyName="Text" Type="DateTime" DefaultValue="1/1/1960" />
                    <asp:ControlParameter Name="endDate" ControlID="txtEnd" PropertyName="Text" Type="DateTime" DefaultValue="1/1/2050" />
                </FilterParameters>
            </asp:SqlDataSource>
            <br />
            <br />
        </div>
    </form>
</asp:Content>