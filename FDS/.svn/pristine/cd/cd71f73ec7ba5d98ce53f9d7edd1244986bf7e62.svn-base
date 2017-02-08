<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dvd.aspx.cs" Inherits="Dvd" MasterPageFile="MasterPage.master" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="ContentDvd" runat="server" ContentPlaceHolderID="body">
    <form id="FormDvd" runat="server">

        <div>
            <!---------------------DvdReport!---------------->
            <br />
            <br />
            <asp:Button runat="server" ID="btnDvdReport" Text="Create Report" OnClick="btnDvdReport_Click" />
            <br />
            <br />
            <asp:Label ID="LblItems" runat="server" Text="Items per page" />
            <asp:DropDownList ID="DdlItemsfilter" runat="server" OnSelectedIndexChanged="DdlItemsfilter_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="25" Value="25" />
                <asp:ListItem Text="50" Value="50" />
                <asp:ListItem Text="All" Value="999" />
            </asp:DropDownList>

            <!---------------------GridView!---------------->
            <asp:GridView ID="gvDvd" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="ID,Reserved,Damaged,Purchased,Missing"
                DataSourceID="sqlDvd" Width="750" PageSize="10">
                <PagerStyle CssClass="pager-row" />
                <EditRowStyle CssClass="edit-row" />
                <Columns>
                    <asp:BoundField DataField="LocId" HeaderText="ID" ReadOnly="true" />
                    <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="true" />
                    <asp:BoundField DataField="year" HeaderText="Release" ReadOnly="true" />
                    <asp:BoundField DataField="runtime" HeaderText="Duration" ReadOnly="true" />
                    <asp:BoundField DataField="MpaaRating" HeaderText="Rating" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Status" Visible="false">
                        <ItemTemplate>
                            <asp:RadioButtonList runat="server" ID="rbtLstRating" RepeatDirection="Horizontal"
                                OnSelectedIndexChanged="SelectedIndex_RdoBtnLst" AutoPostBack="true">
                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                <asp:ListItem Text="Damaged" Value="Damaged"></asp:ListItem>
                                <asp:ListItem Text="Missing" Value="Missing"></asp:ListItem>
                                <asp:ListItem Text="Purchased" Value="Purchased"></asp:ListItem>
                            </asp:RadioButtonList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlDvd" runat="server" SelectCommandType="StoredProcedure" SelectCommand="DvdForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="-1" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Button runat="server" ID="btnGenerate" Text="Generate" OnClick="btnGenerate_Click"
                Visible="false" AutoPostBack="true" />

            <asp:Button runat="server" ID="btnExport" Text="Export" OnClick="btnExportDvd_Click" Visible="false" AutoPostBack="true" />
            <br />
            <br />
            <br />
        </div>
    </form>
</asp:Content>