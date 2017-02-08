﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Equipment.aspx.cs" Inherits="Equipment" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <form id="Form1" runat="server" style="width: 100%;">
        <asp:ScriptManager ID="jquery" runat="server">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
            </Scripts>
        </asp:ScriptManager>
        <!---------------------Add Equipment!---------------->
        <br />
        <br />
        <div id="divAddEquipment" runat="server" style="display: none;">
            <table class="">
                <tr>
                    <th>Name</th>
                    <th>Category</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" CssClass="validator" Text="<br />Name must be provided" Display="Dynamic" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtCategory" runat="server" />
                        <asp:RequiredFieldValidator ID="valPrice1" runat="server" ControlToValidate="txtCategory" CssClass="validator" Text="<br />Category must be provided" Display="Dynamic" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnAddEquipment" runat="server" Text="Add Equipment" OnClick="btnAddEquipment_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            <br />
        </div>

        <div id="divAddingEquipment" runat="server">
            <asp:Button ID="lnkAddEquipment" runat="server" OnClick="lnkAddEquipment_Click" Text="Add Equipment" CausesValidation="false" />
            <br />
            <br />
            <asp:Label ID="LblItems" runat="server" Text="Items per page" />
            <asp:DropDownList ID="DdlItemsfilter" runat="server" OnSelectedIndexChanged="DdlItemsfilter_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="25" Value="25" />
                <asp:ListItem Text="50" Value="50" />
                <asp:ListItem Text="All" Value="999" />
            </asp:DropDownList>
        </div>

        <!---------------------Search!---------------->
        <div  class="marginEquipment">
            <div class="option">
                <asp:TextBox ID="txtSearch" runat="server" size="20" placeholder="Search" />
                <br />
                <br />
                <asp:ImageButton CssClass="Excel" ID="Export" runat="server" ToolTip="Export To Excel" OnClick="btnExportEquip_Click" ImageUrl="Assets/Images/Download_Excel.png" Width="40" Height="40" />
            </div>
        </div>

        <!---------------------GridView!---------------->
        <div class="gvEquipment">
            <asp:GridView ID="gvEquipment" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="equipmentID"
                DataSourceID="sqlEquipment" OnRowCreated="gvEquipment_RowCreated" OnRowEditing="gvEquipment_RowEdit" Width="750">
                <PagerStyle CssClass="pager-row" />
                <EditRowStyle CssClass="edit-row" />
                <SortedAscendingCellStyle CssClass="Asc_Des_Cell" />
                <SortedAscendingHeaderStyle CssClass="Asc_Des_Header" />
                <SortedDescendingCellStyle CssClass="Asc_Des_Cell" />
                <SortedDescendingHeaderStyle CssClass="Asc_Des_Header" />
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                    <asp:TemplateField HeaderText="Status" SortExpression="status">
                        <ItemTemplate>
                            <%# Eval("status") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" CssClass="dont_display" Bind='<%# Eval("status") %>' />
                            <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                <asp:ListItem Text="" Value="-1" />
                                <asp:ListItem Text="inactive" Value="0" />
                                <asp:ListItem Text="available" Value="1" />
                                <asp:ListItem Text="checked out" Value="2" />
                                <asp:ListItem Text="missing" Value="3" />
                                <asp:ListItem Text="damaged" Value="4" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Condition" SortExpression="condition">
                        <ItemTemplate>
                            <%# Eval("condition") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblCondition" runat="server" CssClass="dont_display" Text='<%# Eval("condition") %>' />
                            <asp:DropDownList ID="ddlCondition" runat="server" OnSelectedIndexChanged="ddlCondition_SelectedIndexChanged">
                                <asp:ListItem Text="" Value="-1" />
                                <asp:ListItem Text="good" Value="0" />
                                <asp:ListItem Text="poor" Value="1" />
                                <asp:ListItem Text="damaged" Value="2" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEquipHistory" runat="server" CommandName="EquipHistory" Text="History"
                                OnClick="EquipHistory_Click" CommandArgument='<%# Eval("equipmentID") %>' />
                            <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="UpdateProduct" CommandName="Update" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="cancel" />

                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No Search Results
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:Label ID="lblStatusChanged" runat="server" CssClass="dont_display" />
            <asp:Label ID="lblConditionChanged" runat="server" CssClass="dont_display" />
            <asp:SqlDataSource ID="sqlEquipment" runat="server" SelectCommandType="StoredProcedure" SelectCommand="EquipmentForHall"
                UpdateCommand="EquipmentUpdate" UpdateCommandType="StoredProcedure" OnUpdated="sqlEquipment_Updated" FilterExpression="name LIKE '%{0}%' OR category LIKE '%{0}%' OR condition LIKE '%{0}%'">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="-1" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="equipmentID" Type="Int32" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="category" Type="String" />
                    <asp:ControlParameter Name="status" ControlID="lblStatusChanged" PropertyName="Text" Type="Int32" ConvertEmptyStringToNull="true" />
                    <asp:ControlParameter Name="condition" ControlID="lblConditionChanged" PropertyName="Text" Type="Int32" ConvertEmptyStringToNull="true" />
                </UpdateParameters>
                <FilterParameters>
                    <asp:ControlParameter Name="Search" ControlID="txtSearch" PropertyName="Text" />
                </FilterParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <!---------------------Equipment History!---------------->
            Equipment History
                        <br />
            <asp:Panel ID="PnlEquipHis" runat="server" Height="500px" ScrollBars="auto">
                <asp:GridView ID="gvEquipHistory" runat="server" AutoGenerateColumns="false" Width="780"
                    AllowPaging="false" AllowSorting="true" DataSourceID="sqlHistory">
                    <PagerStyle CssClass="pager-row" />
                    <EditRowStyle CssClass="edit-row" />
                    <HeaderStyle CssClass="header-row" />
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Item" SortExpression="Name" />
                        <asp:BoundField DataField="ConditionIn" HeaderText="In" SortExpression="ConditionIn" />
                        <asp:BoundField DataField="ConditionOut" HeaderText="Out" SortExpression="ConditionOut" />
                        <asp:BoundField DataField="dateCheckedIn" HeaderText="Date In" SortExpression="dateCheckedIn" />
                        <asp:BoundField DataField="dateCheckedOut" HeaderText="Date Out" SortExpression="dateCheckedOut" />
                        <asp:BoundField DataField="StudentID" HeaderText="Student" SortExpression="StudentID" />
                    </Columns>
                    <EmptyDataTemplate>
                        No History On Record
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:SqlDataSource ID="sqlHistory" runat="server" SelectCommandType="StoredProcedure" SelectCommand="EquipmentHistory">
                    <SelectParameters>
                        <asp:SessionParameter Name="EquipmentID" SessionField="EquipId" DefaultValue="-1" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:Panel>
            <br />
            <br />
        </div>
    </form>
</asp:Content>