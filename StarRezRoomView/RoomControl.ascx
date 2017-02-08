<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoomControl.ascx.cs" Inherits="RoomControl" %>

<div runat="server">
    <asp:Repeater ID="rptrRooms" runat="server">
        <ItemTemplate>
            <asp:Button
                ID="btnRoom"
                runat="server"
                BackColor='<%#((Room)Container.DataItem).getStatus() %>'
                Style='<%#"top: " + ((Room)Container.DataItem).getTopCoord() + "; left: " + ((Room)Container.DataItem).getLeftCoord() + ";"%>'
                Text='<%#((Room)Container.DataItem).getRoom() %>'
                Width='<%#Unit.Pixel(Convert.ToInt32(((Room)Container.DataItem).getWidth()))%>'
                Height='<%#Unit.Pixel(Convert.ToInt32(((Room)Container.DataItem).getHeight()))%>'
                UseSubmitBehavior="false"
                OnClick="btnRoom_Click"
                CssClass="RoomButton" />
        </ItemTemplate>
    </asp:Repeater>
</div>