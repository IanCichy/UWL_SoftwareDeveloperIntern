<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="volunteers.aspx.cs" Inherits="wiaa_volunteers" %>

<%@ Register TagPrefix="uc" TagName="ReuterRoomControl" Src="Controls/ReuterRoomControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="Comments" Src="~/Controls/Comments.ascx" %>
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
    <script type="text/javascript">
        function cancel() {
            return false;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="AlertInfo" runat="Server">
    <h4 class="alert_info">Volunteers - Still working on reservations</h4>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <article class="module width_3_quarter">
                <header>
                    <h3 class="content-header">Update Volunteer info for
                        <asp:DropDownList ID="volunteerDropDown2" runat="server" AutoPostBack="True"
                            Height="22px" OnSelectedIndexChanged="volunteerDropDown2_SelectedIndexChanged"
                            Width="147px">
                        </asp:DropDownList></h3>
                </header>
                <div class="module_content">

                    <ajax:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true" ActiveTabIndex="3">
                        <ajax:TabPanel ID="tb001" runat="server">
                            <HeaderTemplate>Add New Volunteer</HeaderTemplate>
                            <ContentTemplate>
                                <header class="wiaa-header">Add Volunteer</header>
                                <div class="contentTextTabs">
                                    <div class="contentTextLeft">
                                        <div class="left">
                                            <asp:Label ID="Label6" runat="server" Text="First Name: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="firstNameTextBox" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label1244" runat="server" Text="Phone: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="phoneNumberTextBox" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label10" runat="server" Text="Address: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label12" runat="server" Text="City: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="cityTextBox" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label1248" runat="server" Text="Choose the days they need a room for:" Font-Bold="True" Font-Italic="True"></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:CheckBoxList ID="dayCheckBox" runat="server">
                                                <asp:ListItem>Thursday</asp:ListItem>
                                                <asp:ListItem>Friday</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                    <div class="contentTextRight">

                                        <div class="left">
                                            <asp:Label ID="Label7" runat="server" Text="Last Name: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="lastNameTextBox" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label9" runat="server" Text="Contact Email: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="contactEmailTextBox" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label11" runat="server" Text="Fax: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="faxTextBox" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label1261" runat="server" Text="Zip: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="zipTextBox" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="right">
                                            <br />
                                            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both"></div>
                                <br />
                            </ContentTemplate>
                        </ajax:TabPanel>
                        <ajax:TabPanel ID="tb002" runat="server">
                            <HeaderTemplate>Update</HeaderTemplate>
                            <ContentTemplate>

                                <header class="wiaa-header">
                                    Update Volunteer Info
                                </header>
                                <div class="contentTextTabs">
                                    <div class="contentTextLeft">
                                        <div class="left">
                                            <asp:Label ID="Label5" runat="server" Text="First Name: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="updateFName" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label8" runat="server" Text="Phone: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="updatePhone" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label13" runat="server" Text="Address: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="updateAddress" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label14" runat="server" Text="City: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="updateCity" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label16" runat="server" Text="Choose the days they need a room for:" Font-Bold="True" Font-Italic="True"></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:CheckBoxList ID="updateCheckBoxList" runat="server">
                                                <asp:ListItem>Thursday</asp:ListItem>
                                                <asp:ListItem>Friday</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>
                                        <div class="left">
                                        </div>
                                        <div class="right">
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete Volunteer" OnClick="btnDelete_Click" />
                                            <ajax:ConfirmButtonExtender ID="cbe" runat="server"
                                                TargetControlID="btnDelete"
                                                ConfirmText="Are you sure you want to click this?"
                                                OnClientCancel="cancel" Enabled="True" />
                                        </div>
                                    </div>
                                    <div class="contentTextRight">
                                        <div class="left">
                                            <asp:Label ID="Label17" runat="server" Text="Last Name: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="updateLName" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label18" runat="server" Text="Contact Email: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="updateEmail" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label19" runat="server" Text="Fax: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="updateFax" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label1262" runat="server" Text="Zip: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="updateZip" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both"></div>
                                <div style="margin-left: 50%">
                                    <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" />
                                </div>
                                <div class="contentTitle">
                                    <header class="wiaa-header">Edit Reservations</header>
                                </div>
                                <div class="contentText" align="center">
                                    Check the rooms you would like to remove.
                                </div>
                                <table>
                                    <tr>
                                        <td style="width: 171px">
                                            <asp:Label ID="Label1265" runat="server" Text="Current Room Reserved: "></asp:Label>
                                            <asp:Label ID="roomReservedLabel" runat="server" Text="*****" Font-Bold="True"
                                                Font-Size="Large"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="removeRoomButton" runat="server" Text="Remove Room"
                                                Width="110px" OnClick="removeRoomButton_Click" /><br />
                                        </td>

                                        <tr>
                                            <td>
                                                <asp:Button ID="btnPrint" runat="server" Text="Print Reservation"
                                                    Width="110px" OnClick="btnPrint_Click" /><br />
                                            </td>
                                        </tr>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajax:TabPanel>
                        <ajax:TabPanel ID="TabPanel9" runat="server">
                            <HeaderTemplate>Billing</HeaderTemplate>
                            <ContentTemplate>
                                <header class="wiaa-header">Billing </header>
                                <div class="contentTextTabs">
                                    <div class="contentTextLeft">

                                        <div class="left-billing">
                                            <asp:Label ID="Label22" runat="server" Text="Reuter Single X $35 per room: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="singleRoomTextBox" runat="server" ReadOnly="True" Width="75px"></asp:TextBox>
                                        </div>

                                        <div class="left-billing">
                                            <asp:Label ID="Label23" runat="server" Text="Sub Total: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="subTotalTextBox" runat="server" Width="75px"></asp:TextBox>
                                        </div>

                                        <div class="left-billing">
                                            <asp:Label ID="Label1260" runat="server" Text="Payment Amount: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="initialPaymentTextBox" runat="server" Width="75px"></asp:TextBox>
                                        </div>

                                        <div class="left-billing"></div>
                                        <div class="right-billing">
                                            <asp:Button ID="clearButton" runat="server" Text="Clear" OnClick="clearButton_Click" />
                                        </div>

                                        <div class="left-billing">
                                            <asp:Label ID="Label1263" runat="server" Text="Total Refund: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="volRefundTextBox" runat="server" ReadOnly="True" Width="75px"></asp:TextBox>
                                        </div>

                                        <div class="left-billing"></div>
                                        <div class="right-billing">
                                            <asp:Label ID="Label324" runat="server" Font-Bold="True" Text="Refund Explanation"></asp:Label>
                                        </div>

                                        <div class="left-billing"></div>
                                        <div class="right-billing" style="margin-left: -40px">
                                            <asp:TextBox ID="refundExpTextBox" runat="server" Height="65px"
                                                TextMode="MultiLine" Width="163px"></asp:TextBox>
                                        </div>

                                        <div class="left-billing">
                                            <asp:Label ID="Label325" runat="server" Font-Bold="True" Font-Underline="True"
                                                Text="Final Total: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="finalTotalTextBox" runat="server" ReadOnly="True" Width="75px"></asp:TextBox>
                                            <asp:Button ID="calculateButton" runat="server" OnClick="calculateButton_Click"
                                                Text="Calculate" />
                                        </div>
                                    </div>
                                    <div class="contentTextRight">
                                        <div class="left">
                                            <asp:Label ID="Label25" runat="server" Text="Paid by: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:DropDownList ID="paidbyDropDown" runat="server" Height="22px"
                                                Width="114px">
                                                <asp:ListItem>School Check</asp:ListItem>
                                                <asp:ListItem>Personal Check</asp:ListItem>
                                                <asp:ListItem>Cash</asp:ListItem>
                                                <asp:ListItem>Credit/Debit</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button ID="addPayment" runat="server" Text="2nd Payment"
                                                OnClick="addPayment_Click" Width="87px" />
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label26" runat="server" Text="Check Number: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="checkNumberTextBox" runat="server" Width="99px"></asp:TextBox>
                                        </div>

                                        <asp:Panel ID="secondPayment" runat="server" Visible="False">
                                            <div class="left">
                                                <asp:Label ID="Label27" runat="server" Text="2nd Payement: "></asp:Label>
                                            </div>
                                            <div class="right">
                                                <asp:DropDownList ID="paidbyDropDown2" runat="server" Height="22px"
                                                    Width="114px">
                                                    <asp:ListItem>School Check</asp:ListItem>
                                                    <asp:ListItem>Personal Check</asp:ListItem>
                                                    <asp:ListItem>Cash</asp:ListItem>
                                                    <asp:ListItem>Credit/Debit</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Button ID="removePayment" runat="server" Text="Remove" OnClick="removePayment_Click" />
                                            </div>

                                            <div class="left">
                                                <asp:Label ID="Label28" runat="server" Text="Check/Receipt Number: "></asp:Label>
                                            </div>
                                            <div class="right">
                                                <asp:TextBox ID="checkNumberTextBox2" runat="server" Width="99px"></asp:TextBox>
                                            </div>
                                        </asp:Panel>

                                        <br />

                                        <div class="left"></div>
                                        <div class="right">
                                            <asp:Button ID="updateAllButton" runat="server" Text="Update All" OnClick="updateAllButton_Click" />
                                        </div>
                                        <br />

                                        <asp:Button ID="printReceipt" runat="server" Text="Print Receipt" Width="92px" OnClick="printReceipt_Click"
                                            Visible="False" />
                                        <br />
                                    </div>
                                    <br style="clear: both" />
                                </div>
                            </ContentTemplate>
                        </ajax:TabPanel>
                        <ajax:TabPanel ID="TabPanel1" runat="server">
                            <HeaderTemplate>Reserve</HeaderTemplate>
                            <ContentTemplate>
                                <div class="contentText">
                                    <table>
                                        <tr>
                                            <td style="width: 267px" class="contentTitle">
                                                <h1>Reserve a room/bed
                                                </h1>
                                                <asp:Label ID="lbl1" runat="server" Text="Name: " Font-Bold="True" Style="margin-left: 45px"></asp:Label><asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                                                <br />
                                                <asp:Button ID="btnLookUp" runat="server" AutoPostback="false" Text="Look Up.." Style="margin-left: 100px" OnClick="btnLookUp_Click" />
                                                <br />
                                                <br />
                                                <asp:Button ID="btnReview" runat="server" Text="Review" Style="margin-left: 100px; margin-right: 5px" OnClick="btnReview_Click" AutoPostBack="false" />
                                                <asp:Label ID="lblReview" runat="server" Font-Bold="True" Font-Size="Larger">***</asp:Label>
                                                <br />
                                                <asp:Label ID="lblReview2" runat="server" Font-Bold="True"></asp:Label>
                                                <br />
                                                <div id="divFinalize" runat="server" visible="False">
                                                    <asp:Button ID="btnAccept" runat="server" Text="Accept" Style="margin-left: 100px" OnClick="btnAccept_Click" />
                                                </div>
                                                <br />
                                                <br />
                                            </td>
                                            <td class="contentTitle" style="width: 342px">
                                                <h1 style="color: #000000"></h1>
                                                <br />
                                                <asp:TextBox ID="commentsTextBox2" runat="server" Height="121px" TextMode="MultiLine" Width="254px" Visible="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <br />
                                <div class="divider"></div>
                                <ajax:TabContainer ID="TabContainer2" CssClass="MyTabStyle" runat="server" Width="700px" ActiveTabIndex="1">
                                    <ajax:TabPanel ID="TabPanel2" runat="server">
                                        <HeaderTemplate>First</HeaderTemplate>
                                        <ContentTemplate>
                                            <div id="reuter1_map" style="position: relative">
                                                <uc:ReuterRoomControl ID="RoomControl1" Map="Reuter1" runat="server" />
                                            </div>
                                        </ContentTemplate>
                                    </ajax:TabPanel>
                                    <ajax:TabPanel ID="TabPanel3" runat="server">
                                        <HeaderTemplate>Second</HeaderTemplate>
                                        <ContentTemplate>
                                            <div id="reuter2_map" style="position: relative">
                                                <uc:ReuterRoomControl ID="RoomControl2" Map="Reuter2" runat="server" />
                                            </div>
                                        </ContentTemplate>
                                    </ajax:TabPanel>
                                    <ajax:TabPanel ID="TabPanel5" runat="server">
                                        <HeaderTemplate>Fifth</HeaderTemplate>
                                        <ContentTemplate>
                                            <div id="reuter5_map" style="position: relative">
                                                <uc:ReuterRoomControl ID="RoomControl5" Map="Reuter5" runat="server" />
                                            </div>
                                        </ContentTemplate>
                                    </ajax:TabPanel>
                                </ajax:TabContainer>
                            </ContentTemplate>
                        </ajax:TabPanel>
                    </ajax:TabContainer>
                </div>
            </article>

            <article class="module width_quarter">
                <header>
                    <h3>Comments</h3>
                </header>
                <div class="message_list">
                    <div class="module_content">
                        <div>
                            <div class="post_message">
                                <p style="height: 217px">
                                    <asp:TextBox ID="txtComment" runat="server" Height="202px" Width="201px" TextMode="MultiLine"></asp:TextBox>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <footer>
                    <div class="post_message">
                        <asp:Button ID="btnSubmitComment" runat="server" Text="Submit" Style="margin-left: 100px" class="btn_post_message" OnClick="btnSubmitComment_Click"></asp:Button>
                    </div>
                </footer>
            </article>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>