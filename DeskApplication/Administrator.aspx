<%@ Page Language="C#" MasterPageFile="~/Top.master" AutoEventWireup="true" CodeFile="Administrator.aspx.cs"
    Inherits="Administrator" EnableViewState="true" ValidateRequest="false" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager runat="server" ID="toolkitlols">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <div id="previewapp" runat="server">
                    <tr>
                        <td>
                            <a runat="server" id="previewlink" target="_blank">Preview Application</a>
                        </td>
                    </tr>
                </div>
                <div id="viewappsdiv" runat="server">
                    <tr>
                        <td>
                            <a runat="server" id="viewappslink" target="_blank">View Applications</a>
                            <br />
                            <br />
                        </td>
                    </tr>
                </div>
                <div runat="server" id="questionsdiv">
                    <tr>
                        <td class="bigheaderstop">Questions:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Repeater ID="questions" runat="server">
                                <HeaderTemplate>
                                    <table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="questionall" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "QuestionAll") %>' />
                                            <%# DataBinder.Eval(Container.DataItem, "QuestionNum") %>.
                                            <%# DataBinder.Eval(Container.DataItem, "QuestionText") %>
                                            <br />
                                        </td>
                                        <td class="smallbuttons">
                                            <asp:ImageButton OnClick="UpButtonClick" ImageUrl="images/up.png" ID="UpButton" runat="server"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "QuestionID") %>' />
                                        </td>
                                        <td class="smallbuttons">
                                            <asp:ImageButton OnClick="DownButtonClick" ImageUrl="images/down.png" ID="DownButton"
                                                runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "QuestionID") %>' />
                                        </td>
                                        <td class="smallbuttons">
                                            <asp:ImageButton OnClick="OutButtonClick" ImageUrl="images/remove.png" ID="RemoveButton"
                                                runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "QuestionID") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td class="mediumheaders">Add Question:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="newquestionbox"
                                ErrorMessage="Maximum 1000 Characters" ValidationExpression="^[\s\S]{0,1000}$"></asp:RegularExpressionValidator>
                            <asp:TextBox CssClass="questiontextbox" ID="newquestionbox" TextMode="MultiLine"
                                runat="server" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button CssClass="button" ID="newquestionbutton" CausesValidation="true" runat="server"
                                Text="Submit" OnClick="NewQuestionButtonClick" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:CheckBox ID="chkDefaultQ" runat="server" Text=" Skip Default Questions"  
                                OnCheckedChanged="chkDefaultQChanged" CausesValidation="true" AutoPostBack="True"/>
                        </td>
                    </tr>

                    <tr>
                        <td class="border"></td>
                    </tr>
                </div>
                <div id="individualhalladmins" runat="server">
                    <tr>
                        <td class="bigheaders">Hall Administrators:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Repeater ID="admininhallrepeater" runat="server">
                                <HeaderTemplate>
                                    <table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="timesrow">
                                            <%# DataBinder.Eval(Container.DataItem, "username") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td></br>
                            Add Admin:
                            </br>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="addadmintxtbx" runat="server" Text="8.4" CssClass="contenttextbox" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="addadminbtn" runat="server" Text="Add" OnClick="AddFutureAdmin_ButtonClick" CssClass="button" />
                        </td>
                    </tr>
                </div>
                <div id="halladmins" runat="server">
                    <tr>
                        <td class="bigheaders">Hall Administrators:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Repeater ID="adminrepouter" runat="server"
                                OnItemCommand="adminrepouter_ItemCommand">
                                <HeaderTemplate>
                                    <table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="mediumheaders">
                                            <asp:HyperLink ID="halllink" Target="_blank" runat="server"><%# DataBinder.Eval(Container.DataItem, "Hall") %></asp:HyperLink>
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="adminrepinner" runat="server">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td class="timesrow">
                                                    <%# DataBinder.Eval(Container.DataItem, "UserName") %>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>

                    <tr>
                        <td class="border"></td>
                    </tr>
                </div>
                <div id="interviewtimesdiv" runat="server">
                    <tr>
                        <td class="bigheaders">Interview Times:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Repeater ID="outerRep" runat="server">
                                <HeaderTemplate>
                                    <table class="timesmastertable">
                                        <tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <td class="timessecondarytable">
                                        <table>
                                            <tr>
                                                <td class="timesrow">
                                                    <%# DataBinder.Eval(Container.DataItem, "Date") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Repeater ID="innerRep" runat="server">
                                                        <HeaderTemplate>
                                                            <table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:HiddenField ID="timeID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TimeID") %>' />
                                                                    <asp:CheckBox ID="verifytime" runat="server" Checked="false" />
                                                                </td>
                                                                <td>
                                                                    <%# DataBinder.Eval(Container.DataItem, "StartTime") %>
                                                                    -
                                                                    <%# DataBinder.Eval(Container.DataItem, "EndTime") %>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tr> </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td class="mediumheaders">Remove Interview Times:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button CssClass="button" ID="removeselbutton" CausesValidation="true" runat="server"
                                Text="Selected" OnClick="RemoveSelectedInterviewTimes" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button CssClass="button" ID="removeallbutton" CausesValidation="true" runat="server"
                                Text="All" OnClick="RemoveAllInterviewTimes" />
                        </td>
                    </tr>
                    <tr>
                        <td class="mediumheaders">Add Interview Time:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>Date:
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="contenttextbox" ID="interviewdatebox" runat="server"></asp:TextBox>
                                                    <asp:MaskedEditExtender TargetControlID="interviewdatebox" ID="MaskedEditExtender1"
                                                        runat="server" Mask="99/99/9999" MaskType="Date">
                                                    </asp:MaskedEditExtender>
                                                </td>
                                                <td>
                                                    <asp:ImageButton runat="server" ID="interviewdatebutton" ImageUrl="images/minic.png" />
                                                    <asp:CalendarExtender ID="CalendarExtender3" Format="MM/dd/yyyy" runat="server" TargetControlID="interviewdatebox"
                                                        PopupButtonID="interviewdatebutton">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Begin Time:
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="contenttextbox" ID="interviewtimebox1" runat="server"></asp:TextBox>
                                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99:99:99" MaskType="Time"
                                                        TargetControlID="interviewtimebox1" AcceptAMPM="true">
                                                    </asp:MaskedEditExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>End Time:
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="contenttextbox" ID="interviewtimebox2" runat="server"></asp:TextBox>
                                                    <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99:99:99" MaskType="Time"
                                                        TargetControlID="interviewtimebox2" AcceptAMPM="true">
                                                    </asp:MaskedEditExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button CssClass="button" ID="interviewtimebutton" CausesValidation="true" runat="server"
                                Text="Submit" OnClick="AddInterviewTime" />
                        </td>
                    </tr>
                    <tr>
                        <td class="border"></td>
                    </tr>
                </div>
                <div runat="server" id="applicationdates">
                    <tr>
                        <td class="bigheaders">Application Dates:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>Label:
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="contenttextbox" ID="labelbox" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Begin Date:
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="contenttextbox" ID="begindate" runat="server"></asp:TextBox>
                                                    <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AcceptAMPM="true"
                                                        Mask="99/99/9999 99:99:99" MaskType="DateTime" TargetControlID="begindate">
                                                    </asp:MaskedEditExtender>
                                                </td>
                                                <td>
                                                    <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="images/minic.png" />
                                                    <asp:CalendarExtender ID="CalendarExtender1" Format="MM/dd/yyyy hh:mm:ss A'M" runat="server"
                                                        TargetControlID="begindate" PopupButtonID="ImageButton1">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>End Date:
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="contenttextbox" ID="enddate" runat="server"></asp:TextBox>
                                                    <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AcceptAMPM="true"
                                                        Mask="99/99/9999 99:99:99" MaskType="DateTime" TargetControlID="enddate">
                                                    </asp:MaskedEditExtender>
                                                </td>
                                                <td>
                                                    <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="images/minic.png" />
                                                    <asp:CalendarExtender ID="CalendarExtender2" Format="MM/dd/yyyy hh:mm:ss A'M" runat="server"
                                                        TargetControlID="enddate" PopupButtonID="ImageButton2">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <asp:Repeater ID="appdatesrep" runat="server">
                                            <HeaderTemplate>
                                                <table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="update" OnClick="UpdateDateBoundClick" CausesValidation="true" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                                                            runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Label") %>' />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="startDateLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "startDate") %>'></asp:Label>
                                                        <asp:Label ID="endDateLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "endDate") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="removedaterangebutton" CausesValidation="true" OnClick="ClickApplicationDatesRemove"
                                                            ImageUrl="images/remove.png" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button CssClass="button" CausesValidation="false" OnClick="ClickApplicationDates"
                                ID="appdatesbutton" runat="server" Text="Submit" />
                            <asp:Button CssClass="button" CausesValidation="false" OnClick="ClearApplicationDatesClick"
                                ID="appdatesclearbutton" runat="server" Text="Clear" />
                            <div runat="server" id="appdateserrordiv" class="adminerrordiv">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="border"></td>
                    </tr>
                </div>
                <div>
                    <tr>
                        <td>
                            <table style="width: 100%">
                                <tr>
                                    <td class="bigheaders">Application Texts:
                                        <br />
                                        <span style="font-size: .8em; font-style: italic;">When finished editing, please click the "Save" icon in the top left corner of the box below!</span>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <FTB:FreeTextBox ID="FreeTextBox1" OnSaveClick="ClickTextSave" ToolbarLayout="Save, FontFacesMenu, FontSizesMenu, FontForeColorsMenu, FontForeColorPicker, FontBackColorsMenu|Bold, Italic, Underline, Strikethrough, Superscript, Subscript|JustifyLeft, JustifyRight, JustifyCenter, JustifyFull|BulletedList, NumberedList, Indent, Outdent|Cut, Copy, Paste, Delete, Undo, Redo|SymbolsMenu, InsertRule, InsertDate, InsertTime|InsertTable;InsertTableRowBefore, InsertTableRowAfter, DeleteTableRow;InsertTableColumnBefore, InsertTableColumnAfter, DeleteTableColumn;EditTable|InsertDiv;InsertImageFromGallery, InsertImage;Preview;SelectAll, EditStyle, WordClean"
                                                        runat="server" Text="<b>asdfds</b>" Width="700px" Height="400px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>Select text:
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList CssClass="dropdownlist" ID="appTextListBox" runat="server" OnSelectedIndexChanged="ChangeAppTextListBox"
                                                                    AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <div runat="server" id="defaultcbox">
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                    Use default text:
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="defaultContentBox" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </div>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td></td>
                    </tr>
                </div>
                <div id="preferencesdiv" runat="server">
                    <tr>
                        <td class="bigheaders">Application Preferences:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButtonList CausesValidation="true" AutoPostBack="true" OnSelectedIndexChanged="BlindRadioChanged"
                                ID="blindhallradiolist" runat="server">
                                <asp:ListItem Value="blind">Blind</asp:ListItem>
                                <asp:ListItem Value="noblind">Non-blind</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </div>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>