﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShiftDetails.aspx.cs" Inherits="ShiftDetails" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <form runat="server">
        <div>
            <h3>Shift Details</h3>
            <u><b>Employee:</b></u>
            <asp:Label ID="lblEmployee" runat="server" />
            <br />
            <u><b>Shift:</b></u>
            <asp:Label ID="lblShift" runat="server" />
            <br />
            <u><b>Cash in:</b></u>&nbsp&nbsp
            <asp:TextBox ID="txtCashIn" runat="server" ReadOnly="true" />
            <br />
            <u><b>Cash out:</b></u>
            <asp:TextBox ID="txtCashOut" runat="server" ReadOnly="true" />
            <br />
            <br />
            <div id="divEditCash" runat="server">
                <asp:Button ID="btnEditCash" runat="server" Text="Edit Cash" OnClick="btnEditCash_Click" />
            </div>
            <div id="divConfirmEdit" runat="server" style="display: none;">
                <asp:Button ID="btnConfirmEdit" runat="server" Text="Confirm" OnClick="btnConfirmEdit_Click" />
                <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" OnClick="btnCancelEdit_Click" />
            </div>
            <br />
            <u><b>Notes:</b></u>
            <asp:Label ID="lblReason" runat="server" />
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" Text="Back To Report" OnClick="btnBack_Click" />
            <br />
            <!---------------------Pizza Count GridView!---------------->
            <h3>Pizza Count</h3>
            <asp:GridView ID="gvPizzaCounts" runat="server" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false"
                DataSourceID="sqlPizzaCount" BorderWidth="1px" DataKeyNames="pizzaId">
                <EmptyDataTemplate>
                    No pizzas were counted in or out for this shift.
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="brand" HeaderText="Brand" ReadOnly="true" />
                    <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="true" />
                    <asp:BoundField DataField="price" HeaderText="Current Price" DataFormatString="{0:C}" ReadOnly="true" />
                    <asp:BoundField DataField="countIn" HeaderText="Count In" />
                    <asp:BoundField DataField="systemIn" HeaderText="System Count In" />
                    <asp:BoundField DataField="countOut" HeaderText="Count Out" />
                    <asp:BoundField DataField="systemOut" HeaderText="System Count Out" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlPizzaCount" runat="server" SelectCommandType="StoredProcedure" SelectCommand="PizzaCountsForShift">
                <SelectParameters>
                    <asp:QueryStringParameter Name="shiftID" QueryStringField="shift" DefaultValue="-1" />
                </SelectParameters>
            </asp:SqlDataSource>

            <!---------------------Add Sale!---------------->
            <h3>Sales</h3>
            <div id="divNewSale" runat="server">
                <asp:Button ID="btnNewSale" runat="server" Text="Add Sale" OnClick="btnNewSale_Click" CausesValidation="False" />
            </div>
            <div id="divAddSale" runat="server" style="display: none;">
                <table class="">
                    <tr>
                        <th>Product Name</th>
                        <th>Product ID</th>
                        <th>Product Price</th>
                        <th>Product Inventory</th>
                        <th>Credit?</th>
                        <th>Amount</th>
                        <th>Reason</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlProductName" runat="server" OnSelectedIndexChanged="ddlSelectProduct" AutoPostBack="True" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProductID" runat="server" Enabled="false" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProductCost" runat="server" Enabled="false" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProductInventory" runat="server" Enabled="false" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkCredit" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtAmount" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="btnAddSale" runat="server" Text="Add Sale" OnClick="btnAddSale_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
            </div>
            <br />
            <!---------------------Sales GridView!---------------->
            <asp:GridView ID="gvSales" runat="server" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false"
                DataKeyNames="ShiftID" DataSourceID="sqlSales" BorderWidth="1px" OnRowDeleting="DeleteSale_Click">
                <EmptyDataTemplate>
                    No sales for this shift.
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="true" />
                    <asp:BoundField DataField="productID" HeaderText="ProductID" ReadOnly="true" />
                    <asp:BoundField DataField="isCredit" HeaderText="Credit" ReadOnly="true" />
                    <asp:BoundField DataField="creditReason" HeaderText="Credit Reason" ReadOnly="true" />
                    <asp:BoundField DataField="amount" HeaderText="Amount" ReadOnly="true" />
                    <asp:BoundField DataField="cost" HeaderText="Cost" ReadOnly="true" />
                    <asp:BoundField DataField="soldOn" HeaderText="Sold On" ReadOnly="true" DataFormatString="{0:yyyy/MM/dd HH:mm:ss.fff}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this sale?');"
                                CommandArgument='<%# Eval("productID") +";"+ Eval("amount") +";"+ Eval("soldOn") %>' CommandName="Delete" Text="Delete" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlSales" runat="server" SelectCommandType="StoredProcedure" SelectCommand="SalesForShift">
                <SelectParameters>
                    <asp:QueryStringParameter Name="shiftID" QueryStringField="shift" DefaultValue="-1" />
                </SelectParameters>
            </asp:SqlDataSource>

            <!---------------------Inventory Changes GridView!---------------->
            <h3>Inventory Changes</h3>
            <asp:GridView ID="gvInventoryChanges" runat="server" AutoGenerateColumns="true" AllowPaging="true" AllowSorting="false"
                DataSourceID="sqlInventoryChanges" BorderWidth="1px">
                <EmptyDataTemplate>
                    No inventory changes for this shift.
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlInventoryChanges" runat="server" SelectCommandType="StoredProcedure" SelectCommand="InventoryChangesForShift">
                <SelectParameters>
                    <asp:QueryStringParameter Name="shiftID" QueryStringField="shift" DefaultValue="-1" />
                </SelectParameters>
            </asp:SqlDataSource>

            <br />
            <br />
            <br />

            <asp:Button ID="btnResolve" runat="server" Text="Resolve Issue" OnClick="btnResolve_Click" />
            <asp:Button ID="btnUnResolve" runat="server" Text="Un-Resolve Issue" OnClick="btnUnResolve_Click" />

            <br />
            <br />
            <br />
        </div>
    </form>
</asp:Content>