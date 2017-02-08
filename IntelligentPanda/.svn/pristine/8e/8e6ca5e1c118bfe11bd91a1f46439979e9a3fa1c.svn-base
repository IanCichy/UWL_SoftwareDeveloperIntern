<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="notes.aspx.cs" Inherits="wiaa_addschool" %>

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

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">

    <article class="module width_quarter">
        <header>
            <h3>Comments</h3>
        </header>
        <div class="message_list">
            <div class="module_content">
                <div>
                    <div class="post_message">
                        <p style="height: 190px">
                            <asp:TextBox ID="txtComments" runat="server" Height="200px" Width="300px" TextMode="MultiLine"></asp:TextBox>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <footer>
            <div class="post_message">
                <asp:Button ID="btnSubmitComment" runat="server" Text="Submit" Style="margin-left: 150px" class="btn_post_message" OnClick="btnSubmitComment_Click"></asp:Button>
            </div>
        </footer>
    </article>
</asp:Content>