<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="wiaa_Default" %>

<%@ Register TagPrefix="uc" TagName="NewBug" Src="~/Controls/NewBug.ascx" %>
<%@ Register TagPrefix="uc" TagName="Stats" Src="~/Controls/Stats.ascx" %>
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
    <h4 class="alert_info">WIAA State Track 2014</h4>
    <h4 id="error" class="alert_error" runat="server" visible="false">You do not have valid permissions.</h4>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <uc:Stats runat="server" conference="wiaa" />
</asp:Content>