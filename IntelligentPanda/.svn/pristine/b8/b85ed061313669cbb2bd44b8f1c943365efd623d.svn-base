<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Stats.ascx.cs" Inherits="Controls_Stats" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<style type="text/css">
    .MyTabStyle .ajax__tab_header {
        font-family: "Helvetica Neue", Arial, Sans-Serif;
        font-size: 14px;
        font-weight: bold;
        display: block;
    }

        .MyTabStyle .ajax__tab_header .ajax__tab_outer {
            border-color: #222;
            color: #222;
            padding-left: 10px;
            border: solid 1px #d7d7d7;
        }

        .MyTabStyle .ajax__tab_header .ajax__tab_inner {
            border-color: #666;
            color: #666;
            padding: 3px 10px 2px 0px;
        }

    .MyTabStyle .ajax__tab_hover .ajax__tab_outer {
        background-color: #9c3;
    }

    .MyTabStyle .ajax__tab_hover .ajax__tab_inner {
        color: #fff;
    }

    .MyTabStyle .ajax__tab_active .ajax__tab_outer {
        border-bottom-color: #ffffff;
        background-color: #d7d7d7;
    }

    .MyTabStyle .ajax__tab_active .ajax__tab_inner {
        color: #000;
        border-color: #333;
    }

    .MyTabStyle .ajax__tab_body {
        font-family: verdana,tahoma,helvetica;
        font-size: 10pt;
        background-color: #fff;
        border-top-width: 0;
        border: solid 1px #d7d7d7;
        border-top-color: #ffffff;
        padding-bottom: 15px;
    }
</style>

<ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>

<article class="module width_full">
    <div>
        <asp:Literal ID="lt" runat="server"></asp:Literal>
        <asp:Literal ID="lt2" runat="server"></asp:Literal>
    </div>
    <header>
        <h3>Stats</h3>
    </header>
    <div class="module_content">
        <article class="stats_graph">
            <!--Div that will hold the pie chart-->
            <ajax:TabContainer ID="tcStats" CssClass="MyTabStyle" runat="server" Width="700px" ActiveTabIndex="0">
                <ajax:TabPanel ID="tp1" runat="server">
                    <HeaderTemplate>Traditional Rooms</HeaderTemplate>
                    <ContentTemplate>
                        <div id="chart_div"></div>
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="TabPanel1" runat="server">
                    <HeaderTemplate>Eagle Hall</HeaderTemplate>
                    <ContentTemplate>
                        <div id="chart_div_eagle"></div>
                    </ContentTemplate>
                </ajax:TabPanel>
            </ajax:TabContainer>
        </article>
        <article class="stats_overview">
            <div class="overview_today">
                <p class="overview_day">Friday</p>
                <p class="overview_count">
                    <asp:Label ID="lblFriday" runat="server" Text="Label"></asp:Label>
                </p>
                <p class="overview_type">Rooms</p>
                <p class="overview_day">Thursday</p>
                <p class="overview_count">
                    <asp:Label ID="lblThursday" runat="server" Text="Label"></asp:Label>
                </p>
                <p class="overview_type">Rooms</p>
            </div>
            <div class="overview_previous">
                <p class="overview_day">Registered Schools</p>
                <p class="overview_count">
                    <asp:Label ID="lblSchoolsCurrent" runat="server" Text="Label"></asp:Label>
                </p>
                <p class="overview_type">2014</p>
                <p class="overview_count">
                    <asp:Label ID="lblSchoolsPrevious" runat="server" Text="Label"></asp:Label>
                </p>
                <p class="overview_type">2013</p>
            </div>
        </article>
        <div class="clear"></div>
    </div>
</article>
<!-- end of stats article -->