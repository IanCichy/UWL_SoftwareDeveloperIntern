<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="addreservation.aspx.cs" Inherits="ncaa_addreservation" %>

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
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
    <article class="module width_3_quarter">
        <header>
            <h3>New Reservation</h3>
        </header>
        <div class="module_content">

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
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server" ErrorMessage="*"
                            ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage="*"
                            ControlToValidate="rblHallPref"></asp:RequiredFieldValidator>
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
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </article>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
</asp:Content>