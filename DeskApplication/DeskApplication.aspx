<%@ Page Language="C#" MasterPageFile="~/Top.master" AutoEventWireup="true" CodeFile="DeskApplication.aspx.cs"
    Inherits="DeskApplication" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager runat="server" ID="toolkitlols">
    </asp:ToolkitScriptManager>
    <div runat="server" id="allpages">
        <table>
            <tr>
                <td>
                    <div runat="server" id="allpagestextdiv">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="bigheaderstop">
                    
                   <!-- <a href="Desk%20Assistant%20Job%20Description.doc">Job Description</a> -->
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Repeater ID="allpagesrep" runat="server">
                        <HeaderTemplate>
                            <table>
                                <tr>
                                    <td>
                                        Halls:
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="link" runat="server">a</asp:HyperLink>
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
    </div>
    <div runat="server" id="content">
        <table style="width: 100%">
            <tr>
                <td>
                    <div runat="server" id="introtext">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%">
                        <tr>
                            <td class="prequestiontext">
                                Student ID:
                            </td>
                            <td class="prequestionbox">
                                <asp:TextBox MaxLength="9" ID="TextBox1" CssClass="contenttextbox" runat="server" />
                                <asp:MaskedEditExtender TargetControlID="TextBox1" ID="MaskedEditExtender1" runat="server"
                                    Mask="999999999" MaskType="Number" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" ControlToValidate="TextBox1"
                                    runat="server" ErrorMessage="Required Field" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext">
                                First Name:
                            </td>
                            <td class="prequestionbox">
                                <asp:TextBox MaxLength="100" ID="TextBox2" CssClass="contenttextbox" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="TextBox2"
                                    runat="server" ErrorMessage="Required Field" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext">
                                Last Name:
                            </td>
                            <td class="prequestionbox">
                                <asp:TextBox MaxLength="100" ID="TextBox3" CssClass="contenttextbox" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" ControlToValidate="TextBox3"
                                    runat="server" ErrorMessage="Required Field" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext">
                                Email Address:
                            </td>
                            <td class="prequestionbox">
                                <asp:TextBox MaxLength="100" ID="TextBox4" CssClass="contenttextbox" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" ControlToValidate="TextBox4"
                                    runat="server" ErrorMessage="Required Field" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                    SetFocusOnError="true" ErrorMessage="Please enter your email in the format: help@microsoft.com"
                                    ControlToValidate="TextBox4" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext">
                                Phone Number:
                            </td>
                            <td class="prequestionbox">
                                <asp:TextBox MaxLength="100" ID="TextBox5" CssClass="contenttextbox" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" ControlToValidate="TextBox5"
                                    runat="server" ErrorMessage="Required Field" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                    SetFocusOnError="true" ErrorMessage="Please enter a number in the format:(###) ###-####"
                                    ControlToValidate="TextBox5" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))\d{3}-\d{4}" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext">
                                Are you currently receiving work study?
                            </td>
                            <td class="prequestionbox">
                                <asp:TextBox MaxLength="100" ID="TextBox8" CssClass="contenttextbox" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ControlToValidate="TextBox8"
                                    runat="server" ErrorMessage="Required Field" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext">
                                What is your current year in school?
                            </td>
                            <td class="prequestionbox">
                                <asp:TextBox MaxLength="100" ID="TextBox7" CssClass="contenttextbox" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="TextBox7"
                                    runat="server" ErrorMessage="Required Field" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext">
                                What is your major/minor?
                            </td>
                            <td class="prequestionbox">
                                <asp:TextBox MaxLength="100" ID="TextBox6" CssClass="contenttextbox" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="TextBox6"
                                    runat="server" ErrorMessage="Required Field" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext">
                                What is your anticipated credit load?
                            </td>
                            <td class="prequestionbox">
                                <asp:TextBox MaxLength="100" ID="TextBox9" CssClass="contenttextbox" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" ControlToValidate="TextBox9"
                                    runat="server" ErrorMessage="Required Field" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext">
                                Is your GPA below 2.0? If yes, why?
                            </td>
                            <td class="prequestionbox">
                                <asp:TextBox MaxLength="100" ID="TextBox10" CssClass="contenttextbox" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" ControlToValidate="TextBox10"
                                    runat="server" ErrorMessage="Required Field" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext">
                               <asp:Label runat="server" id="lblMail" Text="Are you interested in being a mail clerk?"/> 
                            </td>
                            <td class="prequestionbox">
                                <asp:TextBox MaxLength="100" ID="TextBox12" CssClass="contenttextbox" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" ControlToValidate="TextBox12"
                                    runat="server" ErrorMessage="Required Field" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <div runat="server" id="prequestion">
                    </div>
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
                                    <asp:HiddenField ID="idtext" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "QuestionId") %>' />
                                    <%# DataBinder.Eval(Container.DataItem, "QuestionNum") %>.
                                    <%# DataBinder.Eval(Container.DataItem, "QuestionText") %>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox TextMode="MultiLine" ID="questionbox" CssClass="questiontextbox" runat="server" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="questionbox"
                                        ErrorMessage="Maximum 1000 Characters" ValidationExpression="^[\s\S]{0,1000}$" />
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
                <td>
                    <br />
                    <div runat="server" id="postquestion">
                    </div>
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
                                                            <asp:CheckBox ID="verifytime" runat="server" Checked="false" />
                                                            <asp:HiddenField ID="timeID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TimeID") %>' />
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
                <td>
                    <br />
                    <div runat="server" id="postapplication">
                    </div>
                </td>
            </tr>
            <div id="submitdiv" runat="server">
                <tr>
                    <td>
                        <asp:TextBox CssClass="contenttextbox" ID="TextBox11" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" ControlToValidate="TextBox11"
                            runat="server" ErrorMessage="Required Field" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="ClickSubmit"
                            CssClass="button" />
                    </td>
                </tr>
            </div>
        </table>
    </div>
</asp:Content>
