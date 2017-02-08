<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="reserve.aspx.cs" Inherits="wiaa_reserve" %>

<%@ Register TagPrefix="uc" TagName="RoomControl" Src="Controls/RoomControl.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="uc" TagName="Comments" Src="~/Controls/Comments.ascx" %>

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

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <article class="module width_3_quarter">
                <header>
                    <h3>Reserve Rooms</h3>
                </header>
                <div class="module_content">

                    <div class="contentTitle">
                        <h1>
                            <table>
                                <tr>
                                    <td style="width: 339px">School Name:
                                <asp:DropDownList ID="schoolDropDown" runat="server" Height="28px" Width="180px"
                                    AutoPostBack="True" Font-Size="Large" OnSelectedIndexChanged="schoolDropDown_SelectedIndexChanged">
                                </asp:DropDownList>
                                    </td>
                                    <td>Select Hall:
                                <asp:DropDownList ID="HallDropDown" runat="server" OnSelectedIndexChanged="HallDropDown_SelectedIndexChanged"
                                    AutoPostBack="true" Height="28px" Font-Size="Large">
                                    <asp:ListItem>Choose a hall...</asp:ListItem>
                                    <asp:ListItem>Angell</asp:ListItem>
                                    <asp:ListItem>Coate</asp:ListItem>
                                    <asp:ListItem>Drake</asp:ListItem>
                                    <asp:ListItem>Eagle</asp:ListItem>
                                    <asp:ListItem>Hutchison</asp:ListItem>
                                    <asp:ListItem>Laux</asp:ListItem>
                                    <asp:ListItem>Sanford</asp:ListItem>
                                    <asp:ListItem>Wentz</asp:ListItem>
                                    <asp:ListItem>White</asp:ListItem>
                                </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </h1>
                    </div>
                    <div class="divider">
                    </div>
                    <div class="contentText">

                        <asp:Label ID="Label5" runat="server" Text="Eagle: "></asp:Label>
                        <asp:Label ID="eagleCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue"></asp:Label>
                        &nbsp;
                <asp:Label ID="Label12" runat="server" Text="White: "></asp:Label>
                        <asp:Label ID="whiteCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue"></asp:Label>
                        &nbsp;
                <asp:Label ID="Label8" runat="server" Text="Laux: "></asp:Label>
                        <asp:Label ID="lauxCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue"></asp:Label>
                        &nbsp;
                <asp:Label ID="Label10" runat="server" Text="Sanford: "></asp:Label>
                        <asp:Label ID="sanfordCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue"></asp:Label>
                        &nbsp;
                <asp:Label ID="Label4" runat="server" Text="Drake: "></asp:Label>
                        <asp:Label ID="drakeCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue"></asp:Label>
                        &nbsp;
                <asp:Label ID="Label7" runat="server" Text="Hutch: "></asp:Label>
                        <asp:Label ID="hutchCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue"></asp:Label>
                        &nbsp;
                <asp:Label ID="Label11" runat="server" Text="Wentz: "></asp:Label>
                        <asp:Label ID="wentzCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue"></asp:Label>
                        &nbsp;
                <asp:Label ID="Label2" runat="server" Text="Angell: "></asp:Label>
                        <asp:Label ID="angellCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue"></asp:Label>
                        &nbsp;
                <asp:Label ID="Label3" runat="server" Text="Coate: "></asp:Label>
                        <asp:Label ID="coateCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue"></asp:Label>
                        &nbsp;
                <asp:Label ID="Label9" runat="server" Text="Reuter: "></asp:Label>
                        <asp:Label ID="reuterCountLabel" runat="server" Text="***" Font-Bold="True" ForeColor="Blue"></asp:Label>
                    </div>
                    <div class="contentText">
                        <table>
                            <tr>
                                <td style="width: 284px">
                                    <table>
                                        <tr>
                                            <td></td>
                                            <td style="text-align: center; font-weight: bold;">Th
                                            </td>
                                            <td style="text-align: left; font-weight: bold;">F
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">Male Single:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMST" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMSF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">Male Double:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMDT" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMDF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="MaleTriple" runat="server" visible="true">
                                            <td style="text-align: right;">Male Triple:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMTT" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMTF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="MaleStudy" runat="server" visible="true">
                                            <td style="text-align: right;">Male Study:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStudyMT" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStudyMF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="MaleEagleSingle" runat="server" visible="true">
                                            <td style="text-align: right;">Male Eagle Single:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEagleMST" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEagleMSF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="MaleEagleDouble" runat="server" visible="true">
                                            <td style="text-align: right;">Male Eagle Double:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEagleMDT" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEagleMDF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">Female Single:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFST" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFSF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">Female Double:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFDT" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFDF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="FemaleTriple" runat="server" visible="true">
                                            <td style="text-align: right;">Female Triple:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFTT" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFTF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="FemaleStudy" runat="server" visible="true">
                                            <td style="text-align: right;">Female Study:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStudyFT" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStudyFF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="FemaleEagleSingle" runat="server" visible="true">
                                            <td style="text-align: right;">Female Eagle Single:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEagleFST" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEagleFSF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="FemaleEagleDouble" runat="server" visible="true">
                                            <td style="text-align: right;">Female Eagle Double
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEagleFDT" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEagleFDF" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="Tr1" runat="server" visible="true">
                                            <td style="text-align: right;">Total Rooms:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalRoom" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td style="text-align: left;">Selected Rooms:</td>
                                            <td>
                                                <asp:TextBox ID="txtSelected" runat="server" CssClass="RoomsNeeded" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 245px">
                                    <table>
                                        <tr>
                                            <td>
                                                <h2 style="text-align: center">Recommended Rooms</h2>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <asp:CheckBoxList ID="ToggleCheckBox" runat="server" RepeatDirection="Horizontal"
                                                    AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                                                    Height="33px">
                                                    <asp:ListItem>Triples</asp:ListItem>
                                                    <asp:ListItem>Studies</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <asp:Button ID="btnRecommend" runat="server" Text="Recommend" OnClick="btnRecommend_Click" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnReview" runat="server" OnClick="btnReview_Click" Text="Review" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
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
                                        <tr>
                                            <td style="text-align: center">
                                                <p id="pExistingReservations" visible="false" runat="server"><b><font color="red" size="5">This school already has reservations.</font></b></p>
                                                <asp:Button ID="btnPrint" runat="server" Text="Print Reservations" Visible="false" OnClick="btnPrint_Click" />
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

                    <!--Sanford-->
                    <asp:Panel ID="pnlSanford1" runat="server" Visible="false">
                        <ajax:TabContainer ID="tcSanford" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true">
                            <ajax:TabPanel ID="TabPanel1" runat="server">
                                <headertemplate>First</headertemplate>
                                <contenttemplate>
                                    <div id="sanford1_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl1" Map="Sanford1" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel2" runat="server">
                                <headertemplate>Second</headertemplate>
                                <contenttemplate>
                                    <div id="sanford2_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl2" Map="Sanford2" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel3" runat="server">
                                <headertemplate>Third</headertemplate>
                                <contenttemplate>
                                    <div id="sanford3_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl3" Map="Sanford3" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel4" runat="server">
                                <headertemplate>Fourth</headertemplate>
                                <contenttemplate>
                                    <div id="sanford4_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl4" Map="Sanford4" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Angell-->
                    <asp:Panel ID="pnlAngell1" runat="server" Visible="false">
                        <ajax:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true">
                            <ajax:TabPanel ID="TabPanel5" runat="server">
                                <headertemplate>First</headertemplate>
                                <contenttemplate>
                                    <div id="angell1_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl5" Map="Angell1" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel6" runat="server">
                                <headertemplate>Second</headertemplate>
                                <contenttemplate>
                                    <div id="angell2_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl6" Map="Angell2" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel7" runat="server">
                                <headertemplate>Third</headertemplate>
                                <contenttemplate>
                                    <div id="angell3_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl7" Map="Angell3" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel8" runat="server">
                                <headertemplate>Fourth</headertemplate>
                                <contenttemplate>
                                    <div id="angell4_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl38" Map="Angell4" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Coate-->
                    <asp:Panel ID="pnlCoate1" runat="server" Visible="false">
                        <ajax:TabContainer ID="TabContainer2" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true">
                            <ajax:TabPanel ID="TabPanel9" runat="server">
                                <headertemplate>First</headertemplate>
                                <contenttemplate>
                                    <div id="coate1_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl9" Map="Coate1" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel10" runat="server">
                                <headertemplate>Second</headertemplate>
                                <contenttemplate>
                                    <div id="coate2_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl8" Map="Coate2" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel11" runat="server">
                                <headertemplate>Third</headertemplate>
                                <contenttemplate>
                                    <div id="coate3_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl39" Map="Coate3" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel12" runat="server">
                                <headertemplate>Fourth</headertemplate>
                                <contenttemplate>
                                    <div id="coate4_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl40" Map="Coate4" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Laux-->
                    <asp:Panel ID="pnlLaux1" runat="server" Visible="false">
                        <ajax:TabContainer ID="TabContainer3" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true">
                            <ajax:TabPanel ID="TabPanel13" runat="server">
                                <headertemplate>First</headertemplate>
                                <contenttemplate>
                                    <div id="laux1_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl10" Map="Laux1" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel14" runat="server">
                                <headertemplate>Second</headertemplate>
                                <contenttemplate>
                                    <div id="laux2_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl11" Map="Laux2" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel15" runat="server">
                                <headertemplate>Third</headertemplate>
                                <contenttemplate>
                                    <div id="laux3_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl12" Map="Laux3" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel16" runat="server">
                                <headertemplate>Fourth</headertemplate>
                                <contenttemplate>
                                    <div id="laux4_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl13" Map="Laux4" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Hutchison-->
                    <asp:Panel ID="pnlHutchison1" runat="server" Visible="false">
                        <ajax:TabContainer ID="TabContainer4" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true">
                            <ajax:TabPanel ID="TabPanel17" runat="server">
                                <headertemplate>First</headertemplate>
                                <contenttemplate>
                                    <div id="hutchison1_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl17" Map="Hutchison1" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel18" runat="server">
                                <headertemplate>Second</headertemplate>
                                <contenttemplate>
                                    <div id="hutchison2_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl14" Map="Hutchison2" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel19" runat="server">
                                <headertemplate>Third</headertemplate>
                                <contenttemplate>
                                    <div id="hutchison3_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl15" Map="Hutchison3" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel20" runat="server">
                                <headertemplate>Fourth</headertemplate>
                                <contenttemplate>
                                    <div id="hutchison4_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl16" Map="Hutchison4" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Drake-->
                    <asp:Panel ID="pnlDrake1" runat="server" Visible="false">
                        <ajax:TabContainer ID="TabContainer5" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true">
                            <ajax:TabPanel ID="TabPanel21" runat="server">
                                <headertemplate>First</headertemplate>
                                <contenttemplate>
                                    <div id="drake1_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl21" Map="Drake1" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel22" runat="server">
                                <headertemplate>Second</headertemplate>
                                <contenttemplate>
                                    <div id="drake2_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl18" Map="Drake2" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel23" runat="server">
                                <headertemplate>Third</headertemplate>
                                <contenttemplate>
                                    <div id="drake3_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl19" Map="Drake3" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel24" runat="server">
                                <headertemplate>Fourth</headertemplate>
                                <contenttemplate>
                                    <div id="drake4_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl20" Map="Drake4" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Wentz-->
                    <asp:Panel ID="pnlWentz1" runat="server" Visible="false">
                        <ajax:TabContainer ID="TabContainer6" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true">
                            <ajax:TabPanel ID="TabPanel25" runat="server">
                                <headertemplate>First</headertemplate>
                                <contenttemplate>
                                    <div id="wentz1_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl25" Map="Wentz1" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel26" runat="server">
                                <headertemplate>Second</headertemplate>
                                <contenttemplate>
                                    <div id="wentz2_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl22" Map="Wentz2" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel27" runat="server">
                                <headertemplate>Third</headertemplate>
                                <contenttemplate>
                                    <div id="wentz3_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl23" Map="Wentz3" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel28" runat="server">
                                <headertemplate>Fourth</headertemplate>
                                <contenttemplate>
                                    <div id="wentz4_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl24" Map="Wentz4" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--White-->
                    <asp:Panel ID="pnlWhite1" runat="server" Visible="false">
                        <ajax:TabContainer ID="TabContainer7" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true">
                            <ajax:TabPanel ID="TabPanel29" runat="server">
                                <headertemplate>First</headertemplate>
                                <contenttemplate>
                                    <div id="white1_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl29" Map="White1" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel30" runat="server">
                                <headertemplate>Second</headertemplate>
                                <contenttemplate>
                                    <div id="white2_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl26" Map="White2" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel31" runat="server">
                                <headertemplate>Third</headertemplate>
                                <contenttemplate>
                                    <div id="white3_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl27" Map="White3" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel32" runat="server">
                                <headertemplate>Fourth</headertemplate>
                                <contenttemplate>
                                    <div id="white4_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl28" Map="White4" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <asp:Panel ID="pnlEagle1" runat="server" Visible="false">
                        <ajax:TabContainer ID="TabContainer8" CssClass="MyTabStyle" runat="server" Width="700px" Visible="true">
                            <ajax:TabPanel ID="TabPanel33" runat="server">
                                <headertemplate>First</headertemplate>
                                <contenttemplate>
                                    <div id="eagle1_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl33" Map="Eagle1" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel34" runat="server">
                                <headertemplate>Second</headertemplate>
                                <contenttemplate>
                                    <div id="eagle2_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl30" Map="Eagle2" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel35" runat="server">
                                <headertemplate>Third</headertemplate>
                                <contenttemplate>
                                    <div id="eagle3_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl31" Map="Eagle3" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel36" runat="server">
                                <headertemplate>Fourth</headertemplate>
                                <contenttemplate>
                                    <div id="eagle4_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl32" Map="Eagle4" runat="server" />
                                    </div>
                                </contenttemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel37" runat="server">
                                <headertemplate>Fifth</headertemplate>
                                <contenttemplate>
                                    <div id="eagle5_map" style="position: relative">
                                        <uc:RoomControl ID="RoomControl41" Map="Eagle5" runat="server" />
                                    </div>
                                </contenttemplate>
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