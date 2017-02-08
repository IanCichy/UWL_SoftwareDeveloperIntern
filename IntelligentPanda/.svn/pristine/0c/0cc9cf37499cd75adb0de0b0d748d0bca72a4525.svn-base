<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="update.aspx.cs" Inherits="ncaa_update" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <link rel="stylesheet" href="../styles/layout.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="styles/NcaaStyleSheet.css" />
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
    <h4 class="alert_info">5/22 2:55pm - Removing Reservations page has been fixed</h4>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">

    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <article class="module width_3_quarter">
                <header>
                    <h3 class="content-header">Update Reservation Information For:
                        <asp:DropDownList ID="ddlReservations" runat="server" OnSelectedIndexChanged="ddlReservations_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></h3>
                </header>
                <div class="module_content">
                    <ajax:TabContainer ID="tcSchoolInfo" CssClass="MyTabStyle" runat="server" Width="700px" ActiveTabIndex="0">
                        <ajax:TabPanel ID="tpSchoolInfo" runat="server">
                            <HeaderTemplate>Reservation Information</HeaderTemplate>
                            <ContentTemplate>
                                <table style="margin-left: 50px">
                                    <tr>
                                        <td style="text-align: right">Who are you? :
                                        </td>
                                        <td style="text-align: left">
                                            <asp:RadioButtonList ID="rblRole" runat="server">
                                                <asp:ListItem Text="Coach/School Administrator" Value="Coach/Admin"></asp:ListItem>
                                                <asp:ListItem Text="Meet Official" Value="Official"></asp:ListItem>
                                                <asp:ListItem Text="Meet Volunteer" Value="Volunteer"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">Last Name:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">First Name:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">School Name:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSchoolName" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">Email Contact Information:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">Cell Phone Contact Information:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCellPhone" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">Residence Hall Preference :
                                        </td>
                                        <td style="text-align: left">
                                            <asp:RadioButtonList ID="rblHallPref" runat="server">
                                                <asp:ListItem Text="Reuter Hall (Apartment Style)" Value="Reuter"></asp:ListItem>
                                                <asp:ListItem Text="Eagle Hall (Semi-Suite Style)" Value="Eagle"></asp:ListItem>
                                                <asp:ListItem Text="No Preference" Value="None"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">Expected Arrival Date:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlArrivalDay" runat="server">
                                                <asp:ListItem Text="Tuesday, May 21st" Value="5/21/2013"></asp:ListItem>
                                                <asp:ListItem Text="Wednesday, May 22nd" Value="5/22/2013"></asp:ListItem>
                                                <asp:ListItem Text="Thursday, May 23rd" Value="5/23/2013"></asp:ListItem>
                                                <asp:ListItem Text="Friday, May 24th" Value="5/24/2013"></asp:ListItem>
                                                <asp:ListItem Text="Saturday, May 25th" Value="5/25/2013"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">Expected Departure Date
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDepartureDay" runat="server">
                                                <asp:ListItem Text="Thursday, May 23rd" Value="5/23/2013"></asp:ListItem>
                                                <asp:ListItem Text="Friday, May 24th" Value="5/24/2013"></asp:ListItem>
                                                <asp:ListItem Text="Saturday, May 25th" Value="5/25/2013"></asp:ListItem>
                                                <asp:ListItem Text="Sunday, May 26th" Value="5/26/2013"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right"># of Female Singles
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtFemaleSingles" runat="server">0</asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                TargetControlID="txtFemaleSingles" FilterType="Numbers" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right"># of Male Singles
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMaleSingles" runat="server">0</asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                TargetControlID="txtMaleSingles" FilterType="Numbers" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right"># of Male Doubles (Eagle Only)
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMaleDoubles" runat="server">0</asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                TargetControlID="txtMaleDoubles" FilterType="Numbers" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right"># of Female Doubles (Eagle Only)
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFemaleDoubles" runat="server">0</asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                TargetControlID="txtFemaleDoubles" FilterType="Numbers" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right"># of Suites (Reuter Only)
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSuites" runat="server">0</asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                TargetControlID="txtSuites" FilterType="Numbers" Enabled="True" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                                <div style="margin-left: 180px">
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                </div>
                            </ContentTemplate>
                        </ajax:TabPanel>
                        <ajax:TabPanel ID="tpNCAABilling" runat="server">
                            <HeaderTemplate>Billing</HeaderTemplate>
                            <ContentTemplate>
                                <br />
                                <table style="margin-left: 50px">
                                    <tr>
                                        <td style="text-align: right">Total Cost:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCost" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">Note:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNote" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">Paid By:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPaidBy" runat="server">
                                                <asp:ListItem Text="School Check" Value="School Check"></asp:ListItem>
                                                <asp:ListItem Text="Personal Check" Value="Personal Check"></asp:ListItem>
                                                <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSecondPayment" runat="server" Text="2nd Payment" OnClick="btnSecondPayment_Click" AutoPostback="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">Check Number:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCheckNumber" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">Payment Amount:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaymentAmount" runat="server"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                TargetControlID="txtPaymentAmount" FilterType="Custom, Numbers" ValidChars="." Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr id="trSecondPaidBy" runat="server" visible="False">
                                        <td style="text-align: right" runat="server">2nd Paid By:
                                        </td>
                                        <td runat="server">
                                            <asp:DropDownList ID="ddlSecondPaidBy" runat="server">
                                                <asp:ListItem Text="School Check" Value="School Check"></asp:ListItem>
                                                <asp:ListItem Text="Personal Check" Value="Personal Check"></asp:ListItem>
                                                <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td runat="server">
                                            <asp:Button ID="btnRemoveSecondPayment" runat="server" Text="Remove" AutoPostback="true" OnClick="btnRemoveSecondPayment_Click" />
                                        </td>
                                    </tr>
                                    <tr id="trSecondCheckNumber" runat="server" visible="False">
                                        <td style="text-align: right" runat="server">2nd Check Number:
                                        </td>
                                        <td runat="server">
                                            <asp:TextBox ID="txtSecondCheckNumber" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="trSecondAmount" runat="server" visible="false">
                                        <td style="text-align: right">Payment Amount:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSecondPaymentAmount" runat="server"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                TargetControlID="txtSecondPaymentAmount" FilterType="Custom, Numbers" ValidChars="." Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr style="margin-top: 10px">
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnFinalize" runat="server" Text="Finalize" OnClick="btnFinalize_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajax:TabPanel>
                        <ajax:TabPanel ID="TabPanel1" runat="server">
                            <HeaderTemplate>Rooms</HeaderTemplate>
                            <ContentTemplate>
                                <asp:Table runat="server" ID="tblRooms" />
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