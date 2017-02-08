<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewBug.ascx.cs" Inherits="Controls_NewBug" %>
<!--[if lt IE 9]>
<link rel="stylesheet" href="css/ie.css" type="text/css" media="screen" />
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
<script src="../js/jquery-1.5.2.min.js" type="text/javascript"></script>
<script src="../js/hideshow.js" type="text/javascript"></script>
<script src="../js/jquery.tablesorter.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/jquery.equalHeight.js"></script>

<article class="module width_full">
    <header>
        <h3>Submit New Bug</h3>
    </header>
    <div class="module_content">
        <fieldset>
            <label>Name of Bug</label>
            <asp:TextBox ID="txtBug" runat="server" Width="282px"></asp:TextBox>
        </fieldset>
        <fieldset>
            <label>Detailed Explanation</label>
            <asp:TextBox ID="txtExplanation" runat="server" Width="960px" Height="178px" TextMode="MultiLine"></asp:TextBox>
        </fieldset>
        <fieldset style="width: 48%; float: left; margin-right: 3%;">
            <!-- to make two field float next to one another, adjust values accordingly -->
            <label>Category</label>
            <asp:DropDownList ID="ddlCategory" runat="server">
                <asp:ListItem>Server Error</asp:ListItem>
                <asp:ListItem>Dead Link</asp:ListItem>
                <asp:ListItem>Layout Difficultes</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:DropDownList>
        </fieldset>
        <div class="clear"></div>
    </div>
    <footer>
        <div class="submit_link">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="alt_btn" />
            <asp:Button ID="btnReset" runat="server" Text="Reset" />
        </div>
    </footer>
</article>
<!-- end of post new article -->