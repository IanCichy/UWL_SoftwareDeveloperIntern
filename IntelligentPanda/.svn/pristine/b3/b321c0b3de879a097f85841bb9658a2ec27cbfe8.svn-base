<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="misc.aspx.cs" Inherits="wiaa_misc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <link rel="stylesheet" href="../styles/layout.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="styles/WiaaStyleSheet.css" />
    <!--[if lt IE 9]>
	<link rel="stylesheet" href="../styles/ie.css" type="text/css" media="screen" />
	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->
    <script src="../js/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../js/hideshow.js" type="text/javascript"></script>
    <script src="../js/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery.equalHeight.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="AlertInfo" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <article class="module width_3_quarter">
        <header>
            <h3>Miscellaneous Charges</h3>
        </header>
        <div class="module_content">
            <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="contentText">
                        <br />
                        <table>
                            <tr>
                                <td class="buttonPadding">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="schoolButton" runat="server" Text="Schools"
                     OnClick="schoolButton_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="volButton" runat="server" Text="Volunteers"
                                        OnClick="volButton_Click" />
                                </td>
                            </tr>
                        </table>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="Label1" runat="server" Text="Please select one of the options above, to charge either a school or a volunteer."></asp:Label>
                        <div class="divider"></div>
                    </div>
                    <asp:Panel ID="schoolPanel" runat="server" Visible="false">
                        &nbsp;&nbsp; &nbsp;<table>
                            <tr>
                                <td style="width: 324px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="School Name: "></asp:Label>
                                    <asp:DropDownList ID="schoolDropDown" runat="server" Height="22px"
                                        Width="150px" OnSelectedIndexChanged="schoolDropDown_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label2" runat="server" Text="Reason for Charge: "
                                        ForeColor="Black"></asp:Label>
                                    <asp:DropDownList ID="chargeDropDown" runat="server" Height="22px"
                                        Width="150px" OnSelectedIndexChanged="chargeDropDown_SelectedIndexChanged"
                                        AutoPostBack="True">
                                        <asp:ListItem>Lost Access Card</asp:ListItem>
                                        <asp:ListItem>Lost Room Key</asp:ListItem>
                                        <asp:ListItem>Fan</asp:ListItem>
                                        <asp:ListItem>Blanket</asp:ListItem>
                                        <asp:ListItem>Sheet</asp:ListItem>
                                        <asp:ListItem>Pillow</asp:ListItem>
                                        <asp:ListItem>Pillowcase</asp:ListItem>
                                        <asp:ListItem>Towel</asp:ListItem>
                                        <asp:ListItem>Washcloth</asp:ListItem>
                                        <asp:ListItem>Screen Removal</asp:ListItem>
                                        <asp:ListItem>Laundry Card</asp:ListItem>
                                        <asp:ListItem>Cleaning</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="schoolNumberTextBox" runat="server" Text="1" Width="32px"></asp:TextBox>
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="otherLabel" runat="server" Text="Other Explanation:"
                                        ForeColor="Black" Visible="false"></asp:Label>
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="otherTextBox" runat="server" Height="54px" TextMode="MultiLine"
                    Width="173px" Visible="false"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="dollarLabel" runat="server" Text="Dollar Amount: " ForeColor="Black" Visible="false"></asp:Label>
                                    &nbsp;<asp:TextBox ID="dollarTextBox" runat="server" Width="96px" Visible="false"></asp:TextBox>
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                        ID="addChargeButton" runat="server" Text="Add Charge"
                                        OnClick="addChargeButton_Click" />
                                    &nbsp;
                <asp:Button ID="Button2" runat="server" Text="Remove Selected"
                    OnClick="removeButton" Width="123px" />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                </td>
                                <td style="border-width: thin; border-color: #000000; border-style: none none none groove;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server" Text="Currently being charged..."
                    ForeColor="Black"></asp:Label>
                                    <br />
                                    <asp:CheckBoxList ID="checkListBox" runat="server" ForeColor="Black">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 324px"></td>
                                <td style="border-left-style: groove; border-width: thin; border-color: #000000; border-top-style: dashed;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="totalLabel" runat="server" Text="Total: " ForeColor="Black"></asp:Label>
                                    <asp:TextBox ID="totalTextBox" runat="server" ReadOnly="True" Width="61px"></asp:TextBox>
                                    <br />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;Paid By:&nbsp;
                <asp:DropDownList ID="ddlSchoolPayType" runat="server">
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Check</asp:ListItem>
                    <asp:ListItem>Credit/Debit</asp:ListItem>
                </asp:DropDownList>
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="chargeButton" runat="server"
                    Text="Charge" OnClick="chargeButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="volPanel" runat="server" Visible="false">
                        <br />
                        <table>
                            <tr>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" ForeColor="Black" Text="Volunteer: "></asp:Label>
                                    <asp:DropDownList ID="volDropDown" runat="server" Height="22px"
                                        Width="150px" OnSelectedIndexChanged="volDropDown_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label5" runat="server" Text="Reason for Charge: "
                                        ForeColor="Black"></asp:Label>
                                    <asp:DropDownList ID="chargeDropDown2" runat="server" Height="22px"
                                        Width="150px" OnSelectedIndexChanged="chargeDropDown_SelectedIndexChanged"
                                        AutoPostBack="True">
                                        <asp:ListItem>Lost Access Card</asp:ListItem>
                                        <asp:ListItem>Lost Room Key</asp:ListItem>
                                        <asp:ListItem>Fan</asp:ListItem>
                                        <asp:ListItem>Blanket</asp:ListItem>
                                        <asp:ListItem>Sheet</asp:ListItem>
                                        <asp:ListItem>Pillow</asp:ListItem>
                                        <asp:ListItem>Pillowcase</asp:ListItem>
                                        <asp:ListItem>Towel</asp:ListItem>
                                        <asp:ListItem>Washcloth</asp:ListItem>
                                        <asp:ListItem>Screen Removal</asp:ListItem>
                                        <asp:ListItem>Laundry Card</asp:ListItem>
                                        <asp:ListItem>Cleaning</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="volNumberTextBox" runat="server" Width="32px" Text="1"></asp:TextBox>
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="otherLabel2" runat="server" Text="Other Explanation:"
                                        ForeColor="Black" Visible="false"></asp:Label>
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="otherTextBox2" runat="server" Height="54px" TextMode="MultiLine"
                    Width="173px" Visible="false"></asp:TextBox>
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="dollarLabel2" runat="server" ForeColor="Black"
                    Text="Dollar Amount: " Visible="false"></asp:Label>
                                    <asp:TextBox ID="dollarTextBox2" runat="server" Visible="false" Width="96px"></asp:TextBox>
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="addChargeButton0" runat="server"
                    OnClick="addChargeButton_Click" Text="Add Charge" />
                                    &nbsp;
                <asp:Button ID="Button3" runat="server" OnClick="removeButton"
                    Text="Remove Selected" Width="123px" />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                </td>
                                <td style="border-width: thin; border-color: #000000; border-style: none none none groove;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Text="Currently being charged..."
                    ForeColor="Black"></asp:Label>
                                    <br />
                                    <asp:CheckBoxList ID="checkListBox2" runat="server" ForeColor="Black">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 324px"></td>
                                <td style="border-left-style: groove; border-width: thin; border-color: #000000; border-top-style: dashed;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Text="Total: " ForeColor="Black"></asp:Label>
                                    <asp:TextBox ID="totalTextBoxVol" runat="server" ReadOnly="True" Width="61px"></asp:TextBox>
                                    <br />
                                    <br />
                                    &nbsp;&nbsp;Paid By:&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlVolPaymentType" runat="server">
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Check</asp:ListItem>
                    <asp:ListItem>Credit/Debit</asp:ListItem>
                </asp:DropDownList>
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="chargeVolButton" runat="server" OnClick="chargeButton_Click"
                    Text="Charge" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </article>
</asp:Content>