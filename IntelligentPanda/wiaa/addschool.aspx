<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="addschool.aspx.cs" Inherits="wiaa_addschool" %>

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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="AlertInfo" runat="Server">
    <h4 class="alert_info">Still need to format "Rooms Needed tab"</h4>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <article class="module width_3_quarter">
        <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="module_content">
                    <ajax:TabContainer ID="tcSchoolInfo" CssClass="MyTabStyle" runat="server" Width="700px">
                        <ajax:TabPanel ID="tpSchoolInfo" runat="server">
                            <HeaderTemplate>Add New School</HeaderTemplate>
                            <ContentTemplate>
                                <div class="contentTextTabs">
                                    <header class="wiaa-header">Add New School</header>
                                    <br />
                                    <div class="contentTextLeft">
                                        <div class="left">
                                            <asp:Label ID="Label1242" runat="server" Text="School Name: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="schoolNameTextBox" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label13" runat="server" Text="Phone: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="phoneNumberTextBox" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label14" runat="server" Text="Password: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="passwordTextBox" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="contentTextRight">
                                        <div class="left">
                                            <asp:Label ID="Label15" runat="server" Text="Expected Arrival Day: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:DropDownList ID="expectedDayDropDown" runat="server" Height="22px"
                                                AutoPostBack="True"
                                                OnSelectedIndexChanged="expectedDayDropDown_SelectedIndexChanged">
                                                <asp:ListItem>------------------------</asp:ListItem>
                                                <asp:ListItem>Thursday</asp:ListItem>
                                                <asp:ListItem>Friday</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div style="clear: both"></div>

                                        <div class="left">
                                            <asp:Label ID="Label1" runat="server" Text="Expected Arrival Time:"></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:DropDownList ID="expectedArrivalDropDown" runat="server" Height="22px" AutoPostBack="True">
                                                <asp:ListItem>------------------------</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div style="clear: both"></div>
                                </div>
                            </ContentTemplate>
                        </ajax:TabPanel>
                        <ajax:TabPanel ID="TabPanel1" runat="server">
                            <HeaderTemplate>Contact Information</HeaderTemplate>
                            <ContentTemplate>
                                <header class="wiaa-header">Contact Information</header>
                                <br />
                                <div class="contentTextTabs">
                                    <div class="contentTextLeft">
                                        <div class="left">
                                            <asp:Label ID="Label6" runat="server" Text="First Name: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="firstNameTextBox" runat="server" Width="128px"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label8" runat="server" Text="Contact Title: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="contactTitleTextBox" runat="server" Width="128px"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label10" runat="server" Text="Address: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="addressTextBox" runat="server" Width="128px"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label12" runat="server" Text="City: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="cityTextBox" runat="server" Width="128px"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label17" runat="server" Text="Athletic Director: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="athleticDirectorTextBox" runat="server" Width="128px"></asp:TextBox>
                                        </div>
                                        <div style="clear: both"></div>
                                        <div class="left">
                                            <asp:Label ID="Label18" runat="server" Text="Coach Name: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="coachNameTextBox" runat="server" Width="128px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="contentTextRight">
                                        <div class="left">
                                            <asp:Label ID="Label7" runat="server" Text="Last Name: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="lastNameTextBox" runat="server" Width="194px"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label9" runat="server" Text="Contact Email: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="contactEmailTextBox" runat="server" Width="194px"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label11" runat="server" Text="Fax: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="faxTextBox" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="left">
                                            <asp:Label ID="Label19" runat="server" Text="Zip: "></asp:Label>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="zipTextBox" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div style="clear: both"></div>
                                </div>
                            </ContentTemplate>
                        </ajax:TabPanel>
                        <ajax:TabPanel ID="TabPanel2" runat="server">
                            <HeaderTemplate>Rooms Needed</HeaderTemplate>
                            <ContentTemplate>
                                <header class="wiaa-header">Rooms Needed</header>
                                <br />
                                <table>
                                    <tr>
                                        <td style="width: 274px" class="contentTable">
                                            <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Room Reservations
                                            </h1>
                                            &nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label25" runat="server" Text="Thursday"></asp:Label>
                                            &nbsp;&nbsp;
                            <asp:Label ID="Label24" runat="server" Text="Friday"></asp:Label>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label23" runat="server" Text="Male Single: "></asp:Label>
                                            <asp:TextBox ID="mstTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;
                            <asp:TextBox ID="msfTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label249" runat="server" Text="Male Double: "></asp:Label>
                                            <asp:TextBox ID="mdtTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;
                            <asp:TextBox ID="mdfTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label252" runat="server" Text="Male Triple: "></asp:Label>
                                            <asp:TextBox ID="mttTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;
                            <asp:TextBox ID="mtfTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label262" runat="server" Text="Male Study: "></asp:Label>
                                            <asp:TextBox ID="mStudyTTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;
                            <asp:TextBox ID="mStudyFTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label318" runat="server" Text="Male Eagle Single: "></asp:Label>
                                            <asp:TextBox ID="mESingleTTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;
                            <asp:TextBox ID="mESingleFTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            &nbsp;&nbsp;
                            <asp:Label ID="Label319" runat="server" Text="Male Eagle Double: "></asp:Label>
                                            <asp:TextBox ID="mEDoubleTTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;
                            <asp:TextBox ID="mEDoubleFTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label271" runat="server" Text="Female Single: "></asp:Label>
                                            <asp:TextBox ID="fstTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;
                            <asp:TextBox ID="fsfTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label281" runat="server" Text="Female Double: "></asp:Label>
                                            <asp:TextBox ID="fdtTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;
                            <asp:TextBox ID="fdfTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label29" runat="server" Text="Female Triple: "></asp:Label>
                                            <asp:TextBox ID="fttTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="ftfTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label301" runat="server" Text="Female Study: "></asp:Label>
                                            <asp:TextBox ID="fStudyTTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;
                            <asp:TextBox ID="fStudyFTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            &nbsp;<asp:Label ID="Label316" runat="server" Text="Female Eagle Single: "></asp:Label>
                                            <asp:TextBox ID="fESingleTTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;
                            <asp:TextBox ID="fESingleFTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            <asp:Label ID="Label317" runat="server" Text="Female Eagle Double: "></asp:Label>
                                            <asp:TextBox ID="fEDoubleTTextBox" runat="server" Width="24px"></asp:TextBox>
                                            &nbsp;&nbsp;
                            <asp:TextBox ID="fEDoubleFTextBox" runat="server" Width="24px"></asp:TextBox>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td class="contentTable">
                                            <br />
                                            All done? Check over the information, then submit!<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="submitButton" runat="server" Text="Submit"
                                OnClick="submitButton_Click" />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajax:TabPanel>
                    </ajax:TabContainer>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </article>

    <uc:Comments ID="comments1" runat="server" conference="wiaa" />
</asp:Content>