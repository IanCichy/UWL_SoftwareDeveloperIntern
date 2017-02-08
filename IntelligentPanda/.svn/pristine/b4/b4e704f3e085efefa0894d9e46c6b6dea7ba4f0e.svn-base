<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="ncaa_edit" %>

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

    <article class="module width_3_quarter">
        <header>
            <h3>Remove Reservations</h3>
        </header>
        <div class="module_content">
            <asp:CheckBoxList ID="cblRooms" runat="server" />
            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Remove Reservations" />
        </div>
    </article>
</asp:Content>