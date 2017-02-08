<%@ Page Title="" Language="C#" MasterPageFile="~/wiaaMaster.master" AutoEventWireup="true" CodeFile="application.aspx.cs" Inherits="application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <script type="text/javascript">
                function cancel() {
                    return false;
                }
        </script>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMainApp" runat="server" Visible="true" Style="text-align: center" HorizontalAlign="Right" Direction="LeftToRight">
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
                        <td style="text-align: right">Contact Email:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtEmail"></asp:RequiredFieldValidator><br />
                            <asp:RegularExpressionValidator ID="emailValidator" runat="server" ControlToValidate="txtEmail" 
                                ValidationExpression="[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}" Text="Please enter a valid email address" Display="Dynamic" />
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
                    <tr>
                        <td style="text-align: right">
                            Create a Password:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator7" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">Confirm Password:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator8" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtPasswordConfirm"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">I require wheelchair/special needs accommodations:
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblSpecNeeds" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Yes" Value="1" Enabled ="true"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0" Enabled ="true"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" Display="Dynamic" runat="server" ErrorMessage="Please indicate yes or no" 
                                ControlToValidate="rblSpecNeeds"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">If you indicated yes, please choose a prefered hall:
                        </td>
                        <td align="left">
                            <asp:RadioButtonList ID="rblHallPref" runat="server" RepeatDirection="Vertical" CausesValidation="false" >
                                <asp:ListItem Text="Wentz Hall" Value="00069" Enabled ="true"></asp:ListItem>
                                <asp:ListItem Text="Eagle Hall" Value="00098" Enabled ="true"></asp:ListItem>
                                <asp:ListItem Selected="True" Text="No Preference" Value="0" Enabled ="true"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr align="right">
                        <td>
                            Wentz Hall Pricing:<br />
                            Eagle Hall Pricing:
                        </td>
                        <td>
                            $45-Double $30-Single<br />
                            $50-Double $35-Single
                        </td>
                    </tr>
                    <%--<tr>
                        <td style="text-align: right"> How many rooms need these accommodations? <br/ />(These are in addition to the regular rooms you will need)
                        </td>
                        <td>
                            <asp:TextBox ID ="txtSpecNeedsRooms" runat ="server" Text="0"></asp:TextBox>
                        </td>
                    </tr>--%>
                </table>
                <br />
                Expected Arrival Day:<asp:DropDownList ID="ddlArrivalDay" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArrivalDay_SelectedIndexChanged">
                    <asp:ListItem Text="Thursday" Value="Thursday" Enabled="true"></asp:ListItem>
                    <asp:ListItem Text="Friday" Value="Friday" Enabled="true"></asp:ListItem>
                </asp:DropDownList>
                <br />
                Expected Arrival Time<asp:DropDownList ID="ddlArrivalTime" runat="server">

                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next Page" />
            </asp:Panel>
           
             <asp:Panel ID="pnlRoomsNeeded" runat="server" Visible="false" Style="text-align: center">
                <div style="text-align: center; margin-left: 100px">
                    <p style="width: 487px; text-align: center">
                        Please provide the number of spaces that you will need during your stay. <i>Maximum of two individuals per room.</i>
                        Rooms cannot mix genders.
                    </p>
                </div>
                 <h3>Thursday</h3>
                <div>
                    # of Female Singles
                <asp:TextBox ID="txtFST" runat="server">0</asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                        TargetControlID="txtFST" FilterType="Numbers" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtFST"></asp:RequiredFieldValidator>
                    <br />
                    # of Male Singles
                <asp:TextBox ID="txtMST" runat="server">0</asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                        TargetControlID="txtMST" FilterType="Numbers" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtMST"></asp:RequiredFieldValidator>
                    <br />
                    # of Female Doubles (2 individuals)
                <asp:TextBox ID="txtFDT" runat="server">0</asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                        TargetControlID="txtFDT" FilterType="Numbers" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtFDT"></asp:RequiredFieldValidator>
                    <br />
                    # of Male Doubles (2 individuals)
                <asp:TextBox ID="txtMDT" runat="server">0</asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                        TargetControlID="txtMDT" FilterType="Numbers" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtMDT"></asp:RequiredFieldValidator>
                    <br />
                    How many of these rooms require special needs access?
                <asp:TextBox ID="txtSpecNeedsT" runat="server">0</asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                        TargetControlID="txtSpecNeedsT" FilterType="Numbers" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtSpecNeedsT"></asp:RequiredFieldValidator>
                    <br />
                </div>

                 <h3>Friday</h3>
                <div>
                    # of Female Singles
                <asp:TextBox ID="txtFSF" runat="server">0</asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                        TargetControlID="txtFSF" FilterType="Numbers" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtFSF"></asp:RequiredFieldValidator>
                    <br />
                    # of Male Singles
                <asp:TextBox ID="txtMSF" runat="server">0</asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                        TargetControlID="txtMSF" FilterType="Numbers" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtMSF"></asp:RequiredFieldValidator>
                    <br />
                    # of Female Doubles (2 individuals)
                <asp:TextBox ID="txtFDF" runat="server">0</asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                        TargetControlID="txtFDF" FilterType="Numbers" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtFDF"></asp:RequiredFieldValidator>
                    <br />
                    # of Male Doubles (2 individuals)
                <asp:TextBox ID="txtMDF" runat="server">0</asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                        TargetControlID="txtMDF" FilterType="Numbers" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtMDF"></asp:RequiredFieldValidator>
                    <br />
                    How many of these rooms require special needs access?
                <asp:TextBox ID="txtSpecNeedsF" runat="server">0</asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                        TargetControlID="txtSpecNeedsF" FilterType="Numbers" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" Display="Dynamic" runat="server" ErrorMessage="*"
                                ControlToValidate="txtSpecNeedsF"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>

                <asp:Button ID="btnNextFinalize" runat="server" Text="Next Page" OnClick="btnNextFinalize_Click"  />
                <br />

            </asp:Panel>

            <asp:Panel ID="pnlFinalize" runat="server" Visible="false" Style="text-align: left; width:600px">
                <p>
            By submitting this form, I (Athletic Director)<b>
                <asp:Label ID="lblAthleticDir" runat="server"></asp:Label></b> and Coach <b>
                    <asp:Label ID="lblCoach" runat="server"></asp:Label></b> agree that
            I and the students from my school will abide by all the rules and regulations set
            forth by UW-La Crosse Residence Life. All rented rooms will be supervised and NOT
            used as team rooms or given to other schools for their usage. Agreement to terms
            (indicated by submitting this application) must be received before acceptance of
            reservations. <strong>A confirmation email will be sent to the email address you provided
            during the application process. Please print a copy of the email and bring it to registration
            in case there are any issues.</strong> There will be  PAYMENT by cash or check that
            is REQUIRED when checking in. Anyone changing the number of reservations MUST USE
            the EXACT same email address each time you change the reservation, which is permitted until 
            <asp:Label ID="lblRegEndDay" runat="server" Style="font-weight: 700" Text="Label" />
            at
            <asp:Label ID="lblRegEndTime" runat="server" Style="font-weight: 700" Text="Label" />.
            PAYMENT IN FULL (cash or check ONLY) IS REQUIRED at the time you arrive to check
            in. No purchase orders or charge cards will be accepted. <b>Also be prepared to pay any charges incurred
                by your school for lost items or damages. Payment is due before leaving UW-L at
                the time you check out of your hall.</b></p>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server"
                                                TargetControlID="btnSubmit"
                                                ConfirmText="By continuing, you agree to all conditions listed on this page. A confirmation email will be sent upon submission."
                                                OnClientCancel="cancel" Enabled="True" />
             </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

