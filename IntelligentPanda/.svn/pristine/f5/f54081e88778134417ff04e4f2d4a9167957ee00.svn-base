<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Account_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>IntelligentPanda Login</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="HandheldFriendly" content="true" />
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=no" />
    <script type="text/javascript" src="../js/shadedborder.js"></script>
    <script language="javascript" type="text/javascript">
        var holderBorder = RUZEE.ShadedBorder.create({ corner: 20, border: 2 });
    </script>
    <link href="../styles/style.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin:0;padding:0;background-color:#404040;">
    <div style="background-image: url(../images/Panda.png); background-repeat: no-repeat; background-size: contain; position: absolute; background-position: center; height: 100%; width: 100%;">
        <div id="content" style="width:500px;margin-left:auto;margin-right:auto;margin-top:100px;">
            <div id="innerholder">
                <h3><span></span></h3>
                <form id="Form1" action="#" method="post" runat="server">
                    <div>
                        <div class="label"><b>User Name :</b></div>
                        <div class="roundedfield">
                            <asp:TextBox ID="username" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <div class="label"><b>Password :</b></div>
                        <div class="roundedfield">
                            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="loginbutton" runat="server" Text="Login"
                        OnClick="loginbutton_Click" />
                </form>
            </div>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        holderBorder.render('content');
    </script>
</body>
</html>