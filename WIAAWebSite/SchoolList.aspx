<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolList.aspx.cs" Inherits="SchoolList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WIAA School List</title>
</head>
<body>
    <form runat="server" style="margin-left:25%">
        Optional Authentication (to view contact information) - Use your Eagle ID<br />
        Login: <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox><br />
        Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
    <asp:GridView ID="hallAssignGrid" runat="server">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    </form>
</body>
</html>