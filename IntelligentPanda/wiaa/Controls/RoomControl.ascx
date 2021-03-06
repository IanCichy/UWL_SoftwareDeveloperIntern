﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoomControl.ascx.cs" Inherits="wiaa_Controls_RoomControl" %>
<link rel="stylesheet" type="text/css" href="../styles/WiaaStyleSheet.css" />

<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <asp:Button ID="Button1"
            runat="server" AutoPostback="false" BackColor='<%#((Room)Container.DataItem).getStatus() %>' Style='<%#"top: " + ((Room)Container.DataItem).getTopCoord() + "; left: " + ((Room)Container.DataItem).getLeftCoord() + ";"%>' Text='<%#((Room)Container.DataItem).getRoom() %>'
            Width='<%#Unit.Pixel(Convert.ToInt32(((Room)Container.DataItem).getWidth()))%>' Height='<%#Unit.Pixel(Convert.ToInt32(((Room)Container.DataItem).getHeight()))%>' OnCommand="Room_Click" CssClass="RoomButton" />
    </ItemTemplate>
</asp:Repeater>
<asp:ListBox ID="lstRoomsHidden" runat="server" Visible="False"></asp:ListBox>