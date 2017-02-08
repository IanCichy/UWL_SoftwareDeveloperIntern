<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Viewer.aspx.cs" Inherits="Viewer" MasterPageFile="MasterPage.master" %>

<%@ Register TagPrefix="uc" TagName="RoomControl" Src="RoomControl.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="body">
    <form id="Form1" runat="server" class="viewBody">

       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        <asp:UpdatePanel ID="UpdPnlRoomView" runat="server">
            <ContentTemplate>
                <div class="MapView">
                    Select Hall:
                <asp:DropDownList ID="HallDropDown" runat="server" OnSelectedIndexChanged="HallDropDown_SelectedIndexChanged"
                    AutoPostBack="true" Height="28px" Font-Size="Large">
                    <asp:ListItem>Choose a hall...</asp:ListItem>
                    <asp:ListItem>Angell</asp:ListItem>
                    <asp:ListItem>Coate</asp:ListItem>
                    <asp:ListItem>Drake</asp:ListItem>
                    <asp:ListItem>Eagle Gray</asp:ListItem>
                    <asp:ListItem>Eagle Maroon</asp:ListItem>
                    <asp:ListItem>Hutchison</asp:ListItem>
                    <asp:ListItem>Laux</asp:ListItem>
                    <asp:ListItem>Reuter</asp:ListItem>
                    <asp:ListItem>Sanford</asp:ListItem>
                    <asp:ListItem>Wentz</asp:ListItem>
                    <asp:ListItem>White</asp:ListItem>
                </asp:DropDownList>
                    <br />
                    <br />

                    <div runat="server" class="colorMap">

                        <asp:Button Text="Hall Details" ID="lnkHallInfo" runat="server" />
                        <ajax:ModalPopupExtender ID="mpeHallInfo" runat="server" PopupControlID="pnlHallInfo" TargetControlID="lnkHallInfo"
                            CancelControlID="btnClose" BackgroundCssClass="modalBackground" />
                        <asp:Panel ID="pnlHallInfo" runat="server" CssClass="modalPopup">
                            <div class="popupHeader">
                            </div>
                            <div class="body">
                                <b>Hall:</b>
                                <asp:Label ID="lblHall" runat="server" /><br />
                                <b>Rooms:</b>
                                <asp:Label ID="lblRooms" runat="server" /><br />
                                <b>Beds:</b>
                                <asp:Label ID="lblBeds" runat="server" /><br />
                                <b>Male Students:</b>
                                <asp:Label ID="lblMale" runat="server" /><br />
                                <b>Female Students:</b>
                                <asp:Label ID="lblFemale" runat="server" /><br />
                                <b>Elevator:</b>
                                <asp:Label ID="lblEle" runat="server" /><br />
                            </div>
                            <div class="footer">
                                <asp:Button ID="Button1" runat="server" Text="Close" />
                            </div>
                        </asp:Panel>

                        <asp:Table runat="server" ID="ColorMap" />
                        <asp:Label runat="server" Text="M/F Room Colors" />
                        <asp:CheckBox runat="server" ID="chkGender" OnCheckedChanged="Tbc_ActiveTabChanged" AutoPostBack="true" />
                    </div>

                    <!--Angell-->
                    <asp:Panel ID="Angell" runat="server" Visible="false" CssClass="MapPannel">
                        <ajax:TabContainer ID="TbcAngell" CssClass="MyTabStyle" runat="server" AutoPostBack="true" OnActiveTabChanged="Tbc_ActiveTabChanged">
                            <ajax:TabPanel ID="TbpAngell1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="angell1_map">
                                        <uc:RoomControl ID="RmcAngell1" Map="Angell1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpAngell2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="angell2_map">
                                        <uc:RoomControl ID="RmcAngell2" Map="Angell2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpAngell3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="angell3_map">
                                        <uc:RoomControl ID="RmcAngell3" Map="Angell3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpAngell4" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="angell4_map">
                                        <uc:RoomControl ID="RmcAngell4" Map="Angell4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpAngel5" runat="server">
                                <HeaderTemplate>Basement</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="angell0_map">
                                        <uc:RoomControl ID="RmcAngell5" Map="Angell0" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Coate-->
                    <asp:Panel ID="Coate" runat="server" Visible="false" CssClass="MapPannel">
                        <ajax:TabContainer ID="TbcCoate" CssClass="MyTabStyle" runat="server" AutoPostBack="true" OnActiveTabChanged="Tbc_ActiveTabChanged">
                            <ajax:TabPanel ID="TbpCoate1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="coate1_map">
                                        <uc:RoomControl ID="RmcCoate1" Map="Coate1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpCoate2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="coate2_map">
                                        <uc:RoomControl ID="RmcCoate2" Map="Coate2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpCoate3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="coate3_map">
                                        <uc:RoomControl ID="RmcCoate3" Map="Coate3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpCoate4" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="coate4_map">
                                        <uc:RoomControl ID="RmcCoate4" Map="Coate4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpCoate5" runat="server">
                                <HeaderTemplate>Basement</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="coate0_map">
                                        <uc:RoomControl ID="RmcCoate5" Map="Coate0" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Drake-->
                    <asp:Panel ID="Drake" runat="server" Visible="false" CssClass="MapPannel">
                        <ajax:TabContainer ID="TbcDrake" CssClass="MyTabStyle" runat="server" AutoPostBack="true" OnActiveTabChanged="Tbc_ActiveTabChanged">
                            <ajax:TabPanel ID="TbpDrake1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="drake1_map">
                                        <uc:RoomControl ID="RmcDrake1" Map="Drake1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpDrake2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="drake2_map">
                                        <uc:RoomControl ID="RmcDrake2" Map="Drake2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpDrake3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="drake3_map">
                                        <uc:RoomControl ID="RmcDrake3" Map="Drake3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpDrake4" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="drake4_map">
                                        <uc:RoomControl ID="RmcDrake4" Map="Drake4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--EagleG-->
                    <asp:Panel ID="EagleGray" runat="server" Visible="false" CssClass="MapPannel">
                        <ajax:TabContainer ID="TbcEagleGray" CssClass="MyTabStyle" runat="server" AutoPostBack="true" OnActiveTabChanged="Tbc_ActiveTabChanged">
                            <ajax:TabPanel ID="TbpEagleGray1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagleG1_map">
                                        <uc:RoomControl ID="RmcEagleGray1" Map="EagleG1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpEagleGray2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagleG2_map">
                                        <uc:RoomControl ID="RmcEagleGray2" Map="EagleG2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpEagleGray3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagleG3_map">
                                        <uc:RoomControl ID="RmcEagleGray3" Map="EagleG3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpEagleGray4" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagleG4_map">
                                        <uc:RoomControl ID="RmcEagleGray4" Map="EagleG4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpEagleGray5" runat="server">
                                <HeaderTemplate>Fifth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagleG5_map">
                                        <uc:RoomControl ID="RmcEagleGray5" Map="EagleG5" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--EagleM-->
                    <asp:Panel ID="EagleMaroon" runat="server" Visible="false" CssClass="MapPannel">
                        <ajax:TabContainer ID="TbcEagleMaroon" CssClass="MyTabStyle" runat="server" AutoPostBack="true" OnActiveTabChanged="Tbc_ActiveTabChanged">
                            <ajax:TabPanel ID="TbpEagleMaroon1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagleM1_map">
                                        <uc:RoomControl ID="RmcEagleMaroon1" Map="EagleM1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpEagleMaroon2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagleM2_map">
                                        <uc:RoomControl ID="RmcEagleMaroon2" Map="EagleM2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpEagleMaroon3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagleM3_map">
                                        <uc:RoomControl ID="RmcEagleMaroon3" Map="EagleM3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpEagleMaroon4" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagleM4_map">
                                        <uc:RoomControl ID="RmcEagleMaroon4" Map="EagleM4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpEagleMaroon5" runat="server">
                                <HeaderTemplate>Fifth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="eagleM5_map">
                                        <uc:RoomControl ID="RmcEagleMaroon5" Map="EagleM5" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Hutchison-->
                    <asp:Panel ID="Hutchison" runat="server" Visible="false" CssClass="MapPannel">
                        <ajax:TabContainer ID="TbcHutchison" CssClass="MyTabStyle" runat="server" AutoPostBack="true" OnActiveTabChanged="Tbc_ActiveTabChanged">
                            <ajax:TabPanel ID="TbpHutchison1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="hutchison1_map">
                                        <uc:RoomControl ID="RmcHutchison1" Map="Hutchison1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpHutchison2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="hutchison2_map">
                                        <uc:RoomControl ID="RmcHutchison2" Map="Hutchison2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpHutchison3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="hutchison3_map">
                                        <uc:RoomControl ID="RmcHutchison3" Map="Hutchison3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpHutchison4" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="hutchison4_map">
                                        <uc:RoomControl ID="RmcHutchison4" Map="Hutchison4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Laux-->
                    <asp:Panel ID="Laux" runat="server" Visible="false" CssClass="MapPannel">
                        <ajax:TabContainer ID="TbcLaux" CssClass="MyTabStyle" runat="server" AutoPostBack="true" OnActiveTabChanged="Tbc_ActiveTabChanged">
                            <ajax:TabPanel ID="TbpLaux1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="laux1_map">
                                        <uc:RoomControl ID="RmcLaux1" Map="Laux1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpLaux2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="laux2_map">
                                        <uc:RoomControl ID="RmcLaux2" Map="Laux2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpLaux3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="laux3_map">
                                        <uc:RoomControl ID="RmcLaux3" Map="Laux3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpLaux4" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="laux4_map">
                                        <uc:RoomControl ID="RmcLaux4" Map="Laux4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Reuter-->
                    <asp:Panel ID="Reuter" runat="server" Visible="false" CssClass="MapPannel">
                        <ajax:TabContainer ID="TbcReuter" CssClass="MyTabStyle" runat="server" AutoPostBack="true" OnActiveTabChanged="Tbc_ActiveTabChanged">
                            <ajax:TabPanel ID="TbpReuter1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="reuter1_map">
                                        <uc:RoomControl ID="RmcReuter1" Map="Reuter1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpReuter2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="reuter2_map">
                                        <uc:RoomControl ID="RmcReuter2" Map="Reuter2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpReuter3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="reuter3_map">
                                        <uc:RoomControl ID="RmcReuter3" Map="Reuter3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpReuter4" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="reuter4_map">
                                        <uc:RoomControl ID="RmcReuter4" Map="Reuter4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpReuter5" runat="server">
                                <HeaderTemplate>Fifth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="reuter5_map">
                                        <uc:RoomControl ID="RmcReuter5" Map="Reuter5" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Sanford-->
                    <asp:Panel ID="Sanford" runat="server" Visible="false" CssClass="MapPannel">
                        <ajax:TabContainer ID="TbcSanford" CssClass="MyTabStyle" runat="server" AutoPostBack="true" OnActiveTabChanged="Tbc_ActiveTabChanged">
                            <ajax:TabPanel ID="TbpSanford1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="sanford1_map">
                                        <uc:RoomControl ID="RmcSanford1" Map="Sanford1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpSanford2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="sanford2_map">
                                        <uc:RoomControl ID="RmcSanford2" Map="Sanford2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpSanford3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="sanford3_map">
                                        <uc:RoomControl ID="RmcSanford3" Map="Sanford3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpSanford4" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="sanford4_map">
                                        <uc:RoomControl ID="RmcSanford4" Map="Sanford4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--Wentz-->
                    <asp:Panel ID="Wentz" runat="server" Visible="false" CssClass="MapPannel">
                        <ajax:TabContainer ID="TbcWentz" CssClass="MyTabStyle" runat="server" AutoPostBack="true" OnActiveTabChanged="Tbc_ActiveTabChanged">
                            <ajax:TabPanel ID="TbpWentz1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="wentz1_map">
                                        <uc:RoomControl ID="RmcWentz1" Map="Wentz1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpWentz2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="wentz2_map">
                                        <uc:RoomControl ID="RmcWentz2" Map="Wentz2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpWentz3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="wentz3_map">
                                        <uc:RoomControl ID="RmcWentz3" Map="Wentz3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpWentz4" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="wentz4_map">
                                        <uc:RoomControl ID="RmcWentz4" Map="Wentz4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <!--White-->
                    <asp:Panel ID="White" runat="server" Visible="false" CssClass="MapPannel">
                        <ajax:TabContainer ID="TbcWhite" CssClass="MyTabStyle" runat="server" AutoPostBack="true" OnActiveTabChanged="Tbc_ActiveTabChanged">
                            <ajax:TabPanel ID="TbpWhite1" runat="server">
                                <HeaderTemplate>First</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="white1_map">
                                        <uc:RoomControl ID="RmcWhite1" Map="White1" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpWhite2" runat="server">
                                <HeaderTemplate>Second</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="white2_map">
                                        <uc:RoomControl ID="RmcWhite2" Map="White2" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpWhite3" runat="server">
                                <HeaderTemplate>Third</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="white3_map">
                                        <uc:RoomControl ID="RmcWhite3" Map="White3" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TbpWhite4" runat="server">
                                <HeaderTemplate>Fourth</HeaderTemplate>
                                <ContentTemplate>
                                    <div id="white4_map">
                                        <uc:RoomControl ID="RmcWhite4" Map="White4" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </asp:Panel>

                    <div class="gridview">
                        <br />
                        <asp:GridView ID="gvOccupants" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="OnSelectedIndexChanged"
                            AllowPaging="false" AllowSorting="true" DataSourceID="sqlOccupant" OnDataBinding="gvOccupants_DataBinding">
                            <Columns>
                                <asp:BoundField DataField="StudentID" HeaderText="Student" SortExpression="StudentID" />
                                <asp:BoundField DataField="FName" HeaderText="First" SortExpression="FName" />
                                <asp:BoundField DataField="LName" HeaderText="Last" SortExpression="LName" />
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                                <asp:BoundField DataField="RoomType" HeaderText="RoomType" SortExpression="RoomType" />
                                <asp:ButtonField Text="Details" ButtonType="Button" CommandName="Select" ControlStyle-CssClass="tablebutton" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Image ID="NoData"
                                    runat="server" />
                                No Room Selected.
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:SqlDataSource ID="sqlOccupant" runat="server" SelectCommandType="StoredProcedure" SelectCommand="SelectOccupantsByRoom">
                            <SelectParameters>
                                <asp:SessionParameter Name="Room" SessionField="Room" DefaultValue="+" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>

                    <asp:LinkButton Text="" ID="lnkFake" runat="server" />
                    <ajax:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="lnkFake"
                        CancelControlID="btnClose" BackgroundCssClass="modalBackground" />
                    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" >
                        <div class="popupHeader">
                        </div>
                        <div class="body">
                            <b>Student ID:</b>
                            <asp:Label ID="lblStudentID" runat="server" /><br />
                            <b>First Name:</b>
                            <asp:Label ID="lblFName" runat="server" /><br />
                            <b>Last Name:</b>
                            <asp:Label ID="lblLName" runat="server" /><br />
                            <b>E-mail:</b>
                            <asp:Label ID="lblEmail" runat="server" /><br />
                            <b>Room:</b>
                            <asp:Label ID="lblRoom" runat="server" /><br />
                            <b>Room Type:</b>
                            <asp:Label ID="lblRoomType" runat="server" /><br />
                            <b>Gender:</b>
                            <asp:Label ID="lblGender" runat="server" /><br />
                            <b>Age:</b>
                            <asp:Label ID="lblAge" runat="server" /><br />
                            <b>International:</b>
                            <asp:Label ID="lblInternational" runat="server" /><br />
                            <b>Cell Number:</b>
                            <asp:Label ID="lblCell" runat="server" /><br />
                            <b>Check In Date:</b>
                            <asp:Label ID="lblCheckInDate" runat="server" /><br />
                            <b>Check Out Date:</b>
                            <asp:Label ID="lblCheckOutDate" runat="server" /><br />
                            <b>Accessible Room:</b>
                            <asp:Label ID="lblDisabled" runat="server" /><br />
                        </div>
                        <div class="footer">
                            <asp:Button ID="btnClose" runat="server" Text="Close" />
                        </div>
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>