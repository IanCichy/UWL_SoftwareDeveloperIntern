<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page Language="C#" MasterPageFile="~/wiaaMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="config.aspx.cs" Inherits="config" Title="WIAA Config" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <ajax:Accordion ID="Accordion1" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="" runat="server" SelectedIndex="0" FadeTransitions="true" SuppressHeaderPostbacks="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" AutoSize="None" Width="680px">
    <Panes>
    <ajax:AccordionPane ID="AccPan1" runat="server">
    <Header>Home</Header>
    <Content>
        <center>
            <FTB:FreeTextBox runat="server" ID="ftbHomePage" ReadOnly="false"></FTB:FreeTextBox>
        </center>
    </Content>
    </ajax:AccordionPane>
    <ajax:AccordionPane ID="AccPan2" runat="server">
    <Header>Food</Header>
    <Content>
        <center>
            <FTB:FreeTextBox runat="server" ID="ftbFood"></FTB:FreeTextBox>
        </center>
    </Content>
    </ajax:AccordionPane>
    <ajax:AccordionPane ID="AccPan3" runat="server">
    <Header>Parking</Header>
    <Content>
        <center>
            <FTB:FreeTextBox runat="server" ID="ftbParking"></FTB:FreeTextBox>
        </center>
    </Content>
    </ajax:AccordionPane>
     <ajax:AccordionPane ID="AccPan4" runat="server">
    <Header>Housing</Header>
    <Content>
        <center>
            <FTB:FreeTextBox runat="server" ID="ftbHousing"></FTB:FreeTextBox>
        </center>
    </Content>
    </ajax:AccordionPane>
    <ajax:AccordionPane ID="AccordionPane1" runat="server">
    <Header>Login</Header>
    <Content>
        <center>
            <FTB:FreeTextBox runat="server" ID="ftbLogin"></FTB:FreeTextBox>
        </center>
    </Content>
    </ajax:AccordionPane>
    </Panes>
    </ajax:Accordion>

    <br /><br />
    <center>
        <asp:Button ID="btnSaveConfig" runat="server" Text="Save Changes" OnClick="btnSaveConfig_Click"  />
    </center>
</asp:Content>

