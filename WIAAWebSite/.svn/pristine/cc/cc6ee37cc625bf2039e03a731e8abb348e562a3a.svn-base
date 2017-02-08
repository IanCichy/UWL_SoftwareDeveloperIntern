<%@ Page Title="" Language="C#" MasterPageFile="~/wiaaMaster.master" AutoEventWireup="true" CodeFile="viewapp.aspx.cs" Inherits="viewapp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: left; margin-left: -30px;">
        <table style="margin-left: 50px">
            <tr>
                <td style="text-align: right">School Name:
                </td>
                <td>
                    <asp:TextBox ID="txtSchoolName" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ErrorMessage="*"
                        ControlToValidate="txtSchoolName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">School Phone:
                </td>
                <td>
                    <asp:TextBox ID="txtSchoolPhone" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator14" Display="Dynamic" runat="server" ErrorMessage="*"
                        ControlToValidate="txtSchoolPhone"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">School Fax:
                </td>
                <td>
                    <asp:TextBox ID="txtSchoolFax" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator17" Display="Dynamic" runat="server" ErrorMessage="*"
                        ControlToValidate="txtSchoolFax"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">School Address:
                </td>
                <td>
                    <asp:TextBox ID="txtSchoolAddress" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator18" Display="Dynamic" runat="server" ErrorMessage="*"
                        ControlToValidate="txtSchoolAddress"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">School City:
                </td>
                <td>
                    <asp:TextBox ID="txtSchoolCity" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator19" Display="Dynamic" runat="server" ErrorMessage="*"
                        ControlToValidate="txtSchoolCity"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">School Zip:
                </td>
                <td>
                    <asp:TextBox ID="txtSchoolZip" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator20" Display="Dynamic" runat="server" ErrorMessage="*"
                        ControlToValidate="txtSchoolZip"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Contact Last Name:
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ErrorMessage="*" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Contact First Name:
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ErrorMessage="*"
                        ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Contact Title:
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator21" Display="Dynamic" runat="server" ErrorMessage="*"
                        ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Contact Cell Phone:
                </td>
                <td>
                    <asp:TextBox ID="txtCellPhone" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ErrorMessage="*"
                        ControlToValidate="txtCellPhone"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Athletic Director:
                </td>
                <td>
                    <asp:TextBox ID="txtAthleticDir" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator22" Display="Dynamic" runat="server" ErrorMessage="*"
                        ControlToValidate="txtAthleticDir"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Coach Name:
                </td>
                <td>
                    <asp:TextBox ID="txtCoach" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator23" Display="Dynamic" runat="server" ErrorMessage="*"
                        ControlToValidate="txtCoach"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align: center; float: right; margin-right: 150px">
        <h3>Thursday</h3>
        <div>
            # of Female Singles
                <asp:TextBox ID="txtFST" runat="server" Width="20">0</asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                TargetControlID="txtFST" FilterType="Numbers" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" runat="server" ErrorMessage="*"
                ControlToValidate="txtFST"></asp:RequiredFieldValidator>
            <br />
            # of Male Singles
                <asp:TextBox ID="txtMST" runat="server" Width="20">0</asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                TargetControlID="txtMST" FilterType="Numbers" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Display="Dynamic" runat="server" ErrorMessage="*"
                ControlToValidate="txtMST"></asp:RequiredFieldValidator>
            <br />
            # of Female Doubles (2 individuals)
                <asp:TextBox ID="txtFDT" runat="server" Width="20">0</asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                TargetControlID="txtFDT" FilterType="Numbers" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Display="Dynamic" runat="server" ErrorMessage="*"
                ControlToValidate="txtFDT"></asp:RequiredFieldValidator>
            <br />
            # of Male Doubles (2 individuals)
                <asp:TextBox ID="txtMDT" runat="server" Width="20">0</asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                TargetControlID="txtMDT" FilterType="Numbers" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Display="Dynamic" runat="server" ErrorMessage="*"
                ControlToValidate="txtMDT"></asp:RequiredFieldValidator>
            <br />
        </div>

        <h3>Friday</h3>
        <div>
            # of Female Singles
                <asp:TextBox ID="txtFSF" runat="server" Width="20">0</asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                TargetControlID="txtFSF" FilterType="Numbers" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server" ErrorMessage="*"
                ControlToValidate="txtFSF"></asp:RequiredFieldValidator>
            <br />
            # of Male Singles
                <asp:TextBox ID="txtMSF" runat="server" Width="20">0</asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                TargetControlID="txtMSF" FilterType="Numbers" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server" ErrorMessage="*"
                ControlToValidate="txtMSF"></asp:RequiredFieldValidator>
            <br />
            # of Female Doubles (2 individuals)
                <asp:TextBox ID="txtFDF" runat="server" Width="20">0</asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                TargetControlID="txtFDF" FilterType="Numbers" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server" ErrorMessage="*"
                ControlToValidate="txtFDF"></asp:RequiredFieldValidator>
            <br />
            # of Male Doubles (2 individuals)
                <asp:TextBox ID="txtMDF" runat="server" Width="20">0</asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                TargetControlID="txtMDF" FilterType="Numbers" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" runat="server" ErrorMessage="*"
                ControlToValidate="txtMDF"></asp:RequiredFieldValidator>
            <br />
            <br />
            Amount Due (Females): <asp:Label ID="lblFemaleCost" runat="server" Text="***"></asp:Label><br />
            Amount Due (Males): <asp:Label ID="lblMaleCost" runat="server" Text="***"></asp:Label><br />
            <b>Total Due: <asp:Label ID="lblTotalCost" runat="server" Text="***"></asp:Label></b>
        </div>
    </div>
    <br style="clear: both" />
    <br />
    <div style="text-align:center">
         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    </div>
</asp:Content>