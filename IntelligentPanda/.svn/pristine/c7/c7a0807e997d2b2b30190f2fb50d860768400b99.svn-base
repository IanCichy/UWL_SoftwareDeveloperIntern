<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="update.aspx.cs" Inherits="wiaa_update" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="uc" TagName="Comments" Src="~/Controls/Comments.ascx" %>

<asp:Content ID="Content5" ContentPlaceHolderID="Head" runat="server">
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

<asp:Content ID="Content1" ContentPlaceHolderID="AlertInfo" runat="Server">
    <h4 class="alert_info">WIAA Update School - Still formatting the "edit rooms" option</h4>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <article class="module width_3_quarter">
                <header>
                    <h3 class="content-header">Update School Information For:
                        <asp:DropDownList ID="ddlSchoolName" runat="server" OnSelectedIndexChanged="ddlSchoolName_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></h3>
                </header>
                <div class="module_content">
                    <ajax:TabContainer ID="tcSchoolInfo" CssClass="MyTabStyle" runat="server" Width="700px" ActiveTabIndex="1">
                        <ajax:TabPanel ID="tpSchoolInfo" runat="server">
                            <HeaderTemplate>School Information</HeaderTemplate>
                            <ContentTemplate>
                                <br />
                                <div class="contentTextTabs">
                                    <header class="wiaa-header">Update School Information</header>
                                    <br />
                                    <div class="contentTextLeft">
                                        <div class="left">
                                            <asp:Label ID="Label1242" runat="server" Text="School: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtSchoolName" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label13" runat="server" Text="Phone: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label14" runat="server" Text="Password: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtPassword" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="contentTextRight">
                                        <div class="left">
                                            <asp:Label ID="Label15" runat="server" Text="Arrival Day: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="expectedDayTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label1" runat="server" Text="Arrival Time:"></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="expectedTimeTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div style="clear: both"></div>
                                </div>
                                <br />
                                <div class="divider">
                                </div>
                                <br />
                                <header class="wiaa-header">Update Contact Information</header>
                                <br />
                                <div class="contentTextTabs">
                                    <div class="contentTextLeft">
                                        <div class="left">
                                            <asp:Label ID="Label6" runat="server" Text="First: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label8" runat="server" Text="Title: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtContactTitle" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label10" runat="server" Text="Address: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label12" runat="server" Text="City: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label17" runat="server" Text="Athletic Director: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtAthleticDir" runat="server"></asp:TextBox>
                                        </div>
                                        <div style="clear: both"></div>
                                        <div class="left">
                                            <asp:Label ID="Label18" runat="server" Text="Coach: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtCoach" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="contentTextRight">
                                        <div class="left">
                                            <asp:Label ID="Label7" runat="server" Text="Last: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label9" runat="server" Text="Email: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtContactEmail" runat="server" Enabled="False"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label11" runat="server" Text="Fax: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <asp:Label ID="Label19" runat="server" Text="Zip: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="left">
                                            <br />
                                            <asp:Button ID="updateInfo" runat="server" Text="Update Info" OnClick="updateInfo_Click" />
                                        </div>
                                    </div>
                                    <div style="clear: both"></div>
                                </div>
                                <br />
                            </ContentTemplate>
                        </ajax:TabPanel>
                        <ajax:TabPanel ID="TabPanel3" runat="server">
                            <HeaderTemplate>Update Reservations/Billing</HeaderTemplate>
                            <ContentTemplate>
                                <br />
                                <div class="contentTextTabs">
                                    <div class="contentTextLeft">
                                        <header class="wiaa-header">Update Room Reservations</header>
                                        <asp:Label ID="Label1246" runat="server" Text="Remove any current reservations:"></asp:Label>
                                        <asp:Button ID="removeRooms" runat="server" Text="Edit Rooms" OnClick="removeRooms_Click" />
                                        <br />
                                        <br />
                                        <div class="three-col-left"></div>
                                        <div class="three-col-numbers">
                                            <asp:Label ID="Label25" runat="server" Text="T"></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:Label ID="Label24" runat="server" Text="F"></asp:Label>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label23" runat="server" Text="Male Single: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMST" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMSF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label249" runat="server" Text="Male Double: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMDT" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMDF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label252" runat="server" Text="Male Triple: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMTT" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMTF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label262" runat="server" Text="Male Study: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMStudyT" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMStudyF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label318" runat="server" Text="Male Eagle Single: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMEagleST" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMEagleSF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label319" runat="server" Text="Male Eagle Double: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMEagleDT" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtMEagleDF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label271" runat="server" Text="Female Single: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFST" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFSF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label281" runat="server" Text="Female Double: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFDT" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFDF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label29" runat="server" Text="Female Triple: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFTT" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFTF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label301" runat="server" Text="Female Study: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFStudyT" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFStudyF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label316" runat="server" Text="Female Eagle Single: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFEagleST" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFEagleSF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label317" runat="server" Text="Female Eagle Double: "></asp:Label>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFEagleDT" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="txtFEagleDF" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br style="clear: left" />

                                        <div class="three-col-left">
                                            <asp:Label ID="Label16" runat="server" Text="Total Rooms Needed: " Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="three-col-numbers"></div>
                                        <div class="three-col-numbers">
                                            <asp:TextBox ID="totalRoomsTextBox" runat="server" Width="24px"></asp:TextBox>
                                        </div>
                                        <br />
                                        <br />
                                        <div style="margin-left: 50px;">
                                            <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" />
                                        </div>
                                        <br />
                                        <br />
                                    </div>
                                    <div class="contentTextRight">
                                        <header class="wiaa-header">Billing</header>
                                        <div style="margin-left: 50px">
                                            <asp:Label ID="Label322" runat="server" Text="Charged for rooms EACH night" Font-Bold="True" Font-Italic="True"></asp:Label>
                                        </div>
                                        <br />
                                        <div class="left-billing">
                                            <asp:Label ID="Label30" runat="server" Text="Singles  X $30 per room: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="singlesCost" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <br />

                                        <div class="left-billing">
                                            <asp:Label ID="Label26" runat="server" Text="Doubles X $45 per room: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="doublesCost" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <br />

                                        <div class="left-billing">
                                            <asp:Label ID="Label27" runat="server" Text="Triples X $60 per room: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="triplesCost" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <br />

                                        <div class="left-billing">
                                            <asp:Label ID="Label28" runat="server" Text="Studies X $75 per room: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="studiesCost" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <br />

                                        <div class="left-billing">
                                            <asp:Label ID="Label321" runat="server" Text="Eagle Singles X $35 per room: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="eagleSinglesCost" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <br />

                                        <div class="left-billing">
                                            <asp:Label ID="Label320" runat="server" Text="Eagle Doubles X $50 per room: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="eagleDoublesCost" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <br />

                                        <div class="left-billing">
                                            <asp:Label ID="Label31" runat="server" Text="Sub Total: " Font-Bold="True" Font-Underline="True"></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="txtSubTotal" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <br />
                                        <asp:Label ID="Label1247" runat="server" Text="Check the comments to the right to see if a refund is needed."
                                            Font-Italic="True"></asp:Label>
                                        <br />

                                        <div class="left-billing">
                                            <asp:Label ID="Label1243" runat="server" Text="Payment Amount: "></asp:Label>
                                        </div>
                                        <div class="right-billing">
                                            <asp:TextBox ID="txtInitialPayment" runat="server" Width="75px"></asp:TextBox>
                                        </div>
                                        <br />

                                        <br />
                                        <div class="left-billing"></div>
                                        <div class="right-billing">
                                            <asp:Button ID="clearRefundButton" runat="server" Text="Clear" OnClick="clearRefundButton_Click" />
                                        </div>
                                        <br />
                                    </div>
                                    <div style="clear: both"></div>
                                </div>
                            </ContentTemplate>
                        </ajax:TabPanel>
                        <ajax:TabPanel ID="TabPanel2" runat="server">
                            <HeaderTemplate>Finalize</HeaderTemplate>
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="finalizePanel">
                                    <div class="contentTextTabs">
                                        <header class="wiaa-header">Finalize and Print Receipt</header>

                                        <br />
                                        <div class="left">
                                            <asp:Label ID="Label2" runat="server" Text="Paid by: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:DropDownList ID="ddlPaidBy" runat="server" Height="22px" Width="114px">
                                                <asp:ListItem>School Check</asp:ListItem>
                                                <asp:ListItem>Personal Check</asp:ListItem>
                                                <asp:ListItem>Cash</asp:ListItem>
                                                <asp:ListItem>Credit/Debit</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button ID="addPayment" runat="server" Text="2nd Payment" OnClick="addPayment_Click" />
                                        </div>
                                        <br />

                                        <div class="left">
                                            <asp:Label ID="Label1244" runat="server" Text="Check/Receipt Number: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtCheckNumber" runat="server" Width="99px"></asp:TextBox>
                                        </div>
                                        <br />

                                        <div class="left">
                                            <asp:Label ID="Label1251" runat="server" Text="Amount: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtAmount" runat="server" Width="99px"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                TargetControlID="txtAmount" FilterType="Numbers" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtAmount"></asp:RequiredFieldValidator>
                                        </div>

                                        <asp:Panel ID="secondPayment" runat="server" Visible="False">
                                            <div class="left">
                                                <asp:Label ID="Label1248" runat="server" Text="2nd Payment: "></asp:Label>
                                            </div>
                                            <div class="right">
                                                <asp:DropDownList ID="ddlPaidBy2" runat="server" Height="22px"
                                                    Width="114px">
                                                    <asp:ListItem>School Check</asp:ListItem>
                                                    <asp:ListItem>Personal Check</asp:ListItem>
                                                    <asp:ListItem>Cash</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Button ID="removePayment" runat="server" Text="Remove" OnClick="removePayment_Click" />
                                                <asp:Button ID="addThirdPayment" runat="server" Text="3rd Payment" OnClick="addThirdPayment_Click" />
                                            </div>

                                            <br />
                                            <div class="left">
                                                <asp:Label ID="Label1249" runat="server" Text="Check Number: "></asp:Label>
                                            </div>
                                            <div class="right">
                                                <asp:TextBox ID="txtCheckNumber2" runat="server" Width="99px"></asp:TextBox>
                                            </div>
                                            <br />

                                            <div class="left">
                                                <asp:Label ID="Label1252" runat="server" Text="2nd Amount: "></asp:Label>
                                            </div>
                                            <div class="right">
                                                <asp:TextBox ID="txtAmount2" runat="server" Width="99px"></asp:TextBox>
                                            </div>
                                        </asp:Panel>

                                        <asp:Panel ID="thirdPayment" runat="server" Visible="False">
                                            <div class="left">
                                                <asp:Label ID="Label3" runat="server" Text="3rd Payment: "></asp:Label>
                                            </div>
                                            <div class="right">
                                                <asp:DropDownList ID="ddlPaidBy3" runat="server" Height="22px"
                                                    Width="114px">
                                                    <asp:ListItem>School Check</asp:ListItem>
                                                    <asp:ListItem>Personal Check</asp:ListItem>
                                                    <asp:ListItem>Cash</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Button ID="removePayment2" runat="server" Text="Remove" OnClick="removethirdPayment_Click" />
                                            </div>

                                            <br />
                                            <div class="left">
                                                <asp:Label ID="Label4" runat="server" Text="Check Number: "></asp:Label>
                                            </div>
                                            <div class="right">
                                                <asp:TextBox ID="txtCheckNumber3" runat="server" Width="99px"></asp:TextBox>
                                            </div>
                                            <br />

                                            <div class="left">
                                                <asp:Label ID="Label5" runat="server" Text="3rd Amount: "></asp:Label>
                                            </div>
                                            <div class="right">
                                                <asp:TextBox ID="txtAmount3" runat="server" Width="99px"></asp:TextBox>
                                            </div>
                                        </asp:Panel>

                                        <div id="divRefund" visible="False" runat="server">
                                            <div class="left">
                                                <asp:Label ID="Label1250" runat="server" Text="Total Refund: "></asp:Label>
                                            </div>
                                            <div class="right">
                                                <asp:TextBox ID="txtRefund" runat="server" Width="99px" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <br />

                                            <div class="left">
                                                <asp:Label ID="Label324" runat="server" Text="Explanation" Font-Bold="True"></asp:Label>
                                            </div>
                                            <div class="right">
                                                <asp:TextBox ID="txtRefundExplanation" runat="server" Height="65px" TextMode="MultiLine" Width="163px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="left">
                                            <asp:Label ID="Label325" runat="server" Font-Bold="True" Font-Underline="True" Text="Final Total: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txtFinalTotal" runat="server" ReadOnly="True" Width="75px"></asp:TextBox>
                                        </div>
                                        <div class="left"></div>
                                        <div class="right">
                                            <asp:Button ID="calculateButton" runat="server" Text="Calculate" OnClick="calculateButton_Click" />
                                        </div>
                                        <br />
                                        <br />
                                        <div class="left"></div>
                                        <div class="right">
                                            <asp:Button ID="btnSaveBilling" runat="server" Text="Save and Print Billing" Visible="false" OnClick="btnSaveBilling_Click" />
                                        </div>
                                        <br />
                                        <div class="left"></div>
                                        <div class="right">
                                            <asp:Button ID="printReceipt" runat="server" Text="Print Receipt" Width="92px" OnClick="printReceipt_Click" Visible="False" />
                                        </div>
                                        <br />
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </ajax:TabPanel>
                    </ajax:TabContainer>

                    <!--Edit Reservations Panel -->
                    <asp:Panel ID="editResPanel" runat="server" Visible="false">
                        <div class="divider">
                        </div>
                        <div class="contentTitle">
                            <h1>Edit Reservations</h1>
                        </div>
                        <div class="contentText" align="center">
                            Check the rooms you would like to remove.
                        </div>
                        <table>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="editResCheckBox" runat="server" Height="216px" Width="148px"
                                        ForeColor="Black" BorderColor="White">
                                    </asp:CheckBoxList>
                                </td>
                                <td>
                                    <asp:Button ID="remove" runat="server" Text="Remove Room" OnClick="remove_Click" />
                                    <br />
                                    <br />
                                    <asp:Button ID="hide" runat="server" OnClick="hide_Click" Text="Hide Panel" Width="98px" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </article>

            <!--Comments -->
            <article class="module width_quarter">
                <header>
                    <h3>Comments</h3>
                </header>
                <div class="message_list">
                    <div class="module_content">
                        <div>
                            <div class="post_message">
                                <p style="height: 217px">
                                    <asp:TextBox ID="txtComments" runat="server" Height="202px" Width="201px" TextMode="MultiLine"></asp:TextBox>
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