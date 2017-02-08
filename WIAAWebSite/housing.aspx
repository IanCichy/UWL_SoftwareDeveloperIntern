<%@ Page Language="C#" MasterPageFile="~/wiaaMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="housing.aspx.cs" Inherits="housing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 705px">
        Please review the following documents for important information regarding your stay at the University of Wisconsin - La Crosse campus
    <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Forms/HousingAgreementEmergencyContactInfo2015.pdf">Emergency Contact List/Housing Agreement</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;<br /><br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Forms/2016WIAATraditionalHallsRosterFormLogos.pdf">Traditional Hall Roommate Lists</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;<br /><br />
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Forms/2016WIAAEagleHallRosterForm.pdf">Eagle Hall Roommate Lists</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;<br /><br />
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Forms/CoachesLetterHousingPolicies2016.pdf">Coach's Letter/Housing Policies</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;<br /><br />
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Forms/CoachesCellNumbers2015.pdf">Coaches Cell Phone List</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;<br /><br />
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Forms/HousingDamageLostItemsCharges2015.pdf">Housing Charges</asp:HyperLink>
        <br />
        <br />
        <div runat="server" id="divHousing" style="width: 705px">
        </div>
    </div>
</asp:Content>