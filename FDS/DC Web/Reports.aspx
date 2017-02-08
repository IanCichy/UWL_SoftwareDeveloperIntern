﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reports.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Reports" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <form id="Form1" runat="server">
        <div>
            <br />
            <br />
            <asp:Button ID="btnMakeNewReport" runat="server" OnClick="btnMakeNewReport_Click" Text="Make New Report" />
            <br />
            <br />
            <asp:Calendar ID="cldrReport" runat="server" SelectionMode="DayWeekMonth" CssClass="Calendar" SelectedDayStyle-BackColor="#B58484"
                TodayDayStyle-BackColor="#CCA0A0" SelectWeekText="-›" OnSelectionChanged="cldrReport_SelectionChanged" />
            <br />
            <asp:Label ID="lblStart" runat="server" Text="Start Date:" />
            <asp:TextBox ID="txtStart" runat="server" placeholder="Select A Week Above" />
            <br />
            <asp:Label ID="lblEnd" runat="server" Text="End Date:&nbsp&nbsp" />
            <asp:TextBox ID="txtEnd" runat="server" placeholder="Select A Week Above" />
            <br />
            <br />
            <!--<asp:Button ID="btnWeek" runat="server" Text="Select Week" OnClick="btnWeek_Click" />
            <asp:Button ID="btnMonth" runat="server" Text="Select Month" OnClick="btnMonth_Click" />
            <asp:Button ID="btnYear" runat="server" Text="Select year" OnClick="btnYear_Click" />
            <br /> -->
            <asp:DropDownList runat="server" ID="ddlTerms" CssClass="dropdown" OnSelectedIndexChanged="ddlTerms_SelectedIndexChanged" AutoPostBack="true" />
            <br />
            <!---------------------GridView!---------------->
            <asp:GridView ID="gvReports" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="ReportID"
                DataSourceID="sqlReports" BorderWidth="1px">
                <PagerStyle CssClass="pager-row" />
                <EditRowStyle CssClass="edit-row" />
                <Columns>
                    <asp:BoundField DataField="ReportName" HeaderText="Report Name" />
                    <asp:TemplateField HeaderText="Start Date">
                        <ItemTemplate>
                            <%# Eval("startDate","{0:MMMM d, yyyy}") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Date">
                        <ItemTemplate>
                            <%# Eval("endDate","{0:MMMM d, yyyy}")  %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnReportDetails" runat="server" CommandName="ReportDetails" Text="Report Details"
                                OnClick="ReportDetails_Click" CommandArgument='<%# Eval("ReportID") %>' />
                            <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                            <asp:Button ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this item?');"
                                OnClick="DeleteReport_Click" CommandArgument='<%# Eval("ReportID") %>' CommandName="ReportID" Text="Delete" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No Reports On Record For This Term
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlReports" runat="server" SelectCommandType="StoredProcedure" SelectCommand="ReportsForHall"
                UpdateCommandType="StoredProcedure" UpdateCommand="ReportRename" FilterExpression="startDate >= '{0}' AND startDate <= '{1}'">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="-1" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ReportID" DbType="Int32" />
                    <asp:Parameter Name="ReportName" DbType="String" />
                </UpdateParameters>
                <FilterParameters>
                    <asp:SessionParameter Name="startDate" SessionField="startDate" DefaultValue="7/1/2014" />
                    <asp:SessionParameter Name="endDate" SessionField="endDate" DefaultValue="12/30/2099" />
                </FilterParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Button ID="btnAllTaxForm" runat="server" Text="Cashiers Deposit Form" OnClick="btnAllTaxForm_Click" />
            <br />
            <br />
        </div>
    </form>
</asp:Content>