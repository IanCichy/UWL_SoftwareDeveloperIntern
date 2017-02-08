<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="reserve.aspx.cs" Inherits="ncaa_reserve" %>

<%@ Register TagPrefix="uc" TagName="RoomControl" Src="Controls/RoomControl.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="uc" TagName="Comments" Src="~/Controls/Comments.ascx" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <article class="module width_3_quarter">
                <header>
                    <h3>Reserve Rooms</h3>
                </header>
                <div class="module_content">
                    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>

                    <div class="contentTitle">
                        <h1>
                            <table>
                                <tr>
                                    <td style="width: 339px">School/Name:
                                <asp:DropDownList ID="schoolDropDown" runat="server" Height="28px" Width="180px"
                                    AutoPostBack="True" Font-Size="Large" OnSelectedIndexChanged="schoolDropDown_SelectedIndexChanged">
                                </asp:DropDownList>
                                    </td>
                                    <td>Select Hall:
                                <asp:DropDownList ID="HallDropDown" runat="server" OnSelectedIndexChanged="HallDropDown_SelectedIndexChanged"
                                    AutoPostBack="true" Height="28px" Font-Size="Large">
                                    <asp:ListItem>Choose a hall...</asp:ListItem>
                                    <asp:ListItem>Eagle</asp:ListItem>
                                    <asp:ListItem>Reuter</asp:ListItem>
                                </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </h1>
                    </div>
                    <div class="divider">
                    </div>
                    <div class="contentText">
                        <center>
                <asp:Label ID="Label5" runat="server" Text="Eagle: " />
                <asp:Label ID="eagleCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue" />
                &nbsp;
                <asp:Label ID="Label9" runat="server" Text="Reuter: " />
                <asp:Label ID="reuterCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue" />

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </center>
                    </div>
                    <div class="contentText">
                        <table>
                            <tr>
                                <td style="width: 284px">
                                    <table>
                                        <tr id="HallPreference" runat="server" visible="true">
                                            <td style="text-align: right;">Hall Preference:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblHallPreference" runat="server">_____</asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="MaleEagleSingle" runat="server" visible="true">
                                            <td style="text-align: right;">Male Singles:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMaleEagleSingle" runat="server" CssClass="RoomsNeeded">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="MaleEagleDouble" runat="server" visible="true">
                                            <td style="text-align: right;">Male Doubles:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMaleEagleDouble" runat="server" CssClass="RoomsNeeded">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="FemaleEagleSingle" runat="server" visible="true">
                                            <td style="text-align: right;">Female Single:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFemaleEagleSingle" runat="server" CssClass="RoomsNeeded">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="FemaleEagleDouble" runat="server" visible="true">
                                            <td style="text-align: right;">Female Doubles:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFemaleEagleDouble" runat="server" CssClass="RoomsNeeded">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="Suites" runat="server" visible="true">
                                            <td style="text-align: right;">Suites:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSuites" runat="server" CssClass="RoomsNeeded">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="Tr1" runat="server" visible="true">
                                            <td style="text-align: right;">Total Rooms:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalRoom" runat="server" CssClass="RoomsNeeded">0</asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 245px">
                                    <table>
                                        <tr>
                                            <td>Currently selecting rooms for:
                                        <asp:RadioButtonList ID="rdbGender" runat="server" OnSelectedIndexChanged="rdbGender_SelectedIndexChanged">
                                            <asp:ListItem Enabled="true" Selected="true" Text="Male" Value="Male" />
                                            <asp:ListItem Enabled="true" Selected="false" Text="Female" Value="Female" />
                                        </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Beds:
                                        <asp:DropDownList ID="ddlBeds" runat="server" OnSelectedIndexChanged="ddlBeds_SelectedIndexChanged">
                                            <asp:ListItem Selected="True" Value="1" Text="1" />
                                            <asp:ListItem Selected="False" Value="2" Text="2" />
                                            <asp:ListItem Selected="False" Value="3" Text="3" />
                                            <asp:ListItem Selected="False" Value="4" Text="4" />
                                        </asp:DropDownList>
                                                <div style="font-size: small; font-family: Calibri;">*Note: To reserve a full suite you MUST select 4 beds</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <asp:Button ID="btnReview" runat="server" OnClick="btnReview_Click" Text="Review" />
                                            </td>
                                        </tr>

                                        <t>
                                    <td style="text-align: center">
                                        <asp:TextBox ID="txtReservations" runat="server" Height="70px" TextMode="MultiLine" Width="197px"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <p id="pReserve" visible="false" runat="server"><i>Reserve the rooms in the text box above?</i></p>
                                    <asp:Button ID="btnAccept" runat="server" Text="Accept Reservations" Visible="false" OnClick="btnAccept_Click" AutoPostback="false" />
                                </td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                </table>
                    </div>
                    <div class="divider">
                    </div>
                    <div>
                    </div>
                    <br />

                    <asp:Panel ID="pnlEagle1" runat="server" Visible="false">
                        <ajax:TabContainer ID="TabContainer8" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true">
                            <ajax:TabPanel ID="TabPanel33" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagle1_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl33" Map="Eagle1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel34" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagle2_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl30" Map="Eagle2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel35" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagle3_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl31" Map="Eagle3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel36" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagle4_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl32" Map="Eagle4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel37" runat="server">
                                <HeaderTemplate>Fifth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagle5_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl41" Map="Eagle5" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <asp:Panel ID="pnlReuter1" runat="server" Visible="false">
                        <ajax:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true">
                            <ajax:TabPanel ID="TabPanel1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="reuter1_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl1" Map="Reuter1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="reuter2_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl2" Map="Reuter2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="reuter3_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl3" Map="Reuter3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>
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
                                    <asp:TextBox ID="txtComments" runat="server" Height="202px" Width="201px" TextMode="MultiLine"></asp:TextBox></p>
                            </div>
                        </div>
                    </div>
                </div>
                <footer>
                    <div class="post_message">
                        <asp:Button ID="btnSubmitComment" runat="server" Text="Submit" Style="margin-left: 100px" class="btn_post_message"></asp:Button>
                    </div>
                </footer>
            </article>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>