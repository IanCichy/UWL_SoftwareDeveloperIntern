<%@ Page Language="C#" MasterPageFile="~/Top.master" AutoEventWireup="true" CodeFile="ViewApplication.aspx.cs" EnableEventValidation="false"
    Inherits="ViewApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div runat="server" id="content">
        <asp:Button runat="server" ID="btnExport" Text="Export" OnClick="btnExportApp_Click" />
        <table style="width: 100%" id="allQuestions" runat="server">
            <tr>
                <td>
                    <table style="width: 100%">
                        <tr>
                            <td class="prequestiontext"><b>Student ID:</b>
                            </td>
                            <td class="prequestionbox">
                                <div runat="server" id="stuiddiv">
                                    <!--  <asp:TextBox ID="stuidbox" Enabled="false" CssClass="contenttextbox2" runat="server"></asp:TextBox> -->
                                    <label id="lblStudentId" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext"><b>First Name:</b>
                            </td>
                            <td class="prequestionbox">
                                <!-- <asp:TextBox ID="firstnamebox" Enabled="false" CssClass="contenttextbox2" runat="server"></asp:TextBox> -->
                                <label id="lblFirst" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext"><b>Last Name:</b>
                            </td>
                            <td class="prequestionbox">
                                <!--  <asp:TextBox ID="lastnamebox" Enabled="false" CssClass="contenttextbox2" runat="server"></asp:TextBox> -->
                                <label id="lblLast" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext"><b>Email Address:</b>
                            </td>
                            <td class="prequestionbox">
                                <!-- <asp:TextBox ID="emailbox" Enabled="false" CssClass="contenttextbox2" runat="server"></asp:TextBox> -->
                                <label id="lblEmail" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext"><b>Phone Number:</b>
                            </td>
                            <td class="prequestionbox">
                                <!-- <asp:TextBox ID="phonebox" Enabled="false" CssClass="contenttextbox2" runat="server"></asp:TextBox> -->
                                <label id="lblPhone" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="prequestiontext"><b>What is your major/minor?</b>
                            </td>
                            <td class="prequestionbox">
                                <!-- <asp:TextBox ID="majorbox" Enabled="false" CssClass="contenttextbox2" runat="server"></asp:TextBox> -->
                                <label id="lblMajor" runat="server" />
                            </td>
                        </tr>

                        <tr>
                            <td class="prequestiontext"><b>What is your current year in school?</b>
                            </td>
                            <td class="prequestionbox">
                                <!-- <asp:TextBox ID="yearbox" Enabled="false" CssClass="contenttextbox2" runat="server"></asp:TextBox> -->
                                <label id="lblYear" runat="server" />
                            </td>
                        </tr>

                        <tr>
                            <td class="prequestiontext"><b>Are you currently receiving work study?</b>
                            </td>
                            <td class="prequestionbox">
                                <!--<asp:TextBox ID="workstudybox" Enabled="false" CssClass="contenttextbox2" runat="server"></asp:TextBox> -->
                                <label id="lblWorkStudy" runat="server" />
                            </td>
                        </tr>

                        <tr>
                            <td class="prequestiontext"><b>What is your anticipated credit load?</b>
                            </td>
                            <td class="prequestionbox">
                                <!-- <asp:TextBox ID="creditbox" Enabled="false" CssClass="contenttextbox2" runat="server"></asp:TextBox> -->
                                <label id="lblCredit" runat="server" />
                            </td>
                        </tr>

                        <tr>
                            <td class="prequestiontext"><b>Is your GPA below 2.0? If yes, why?</b>
                            </td>
                            <td class="prequestionbox">
                                <!-- <asp:TextBox ID="gpabox" Enabled="false" CssClass="contenttextbox2"  runat="server"></asp:TextBox> -->
                                <label id="lblGpa" runat="server" />
                            </td>
                        </tr>

                        <tr>
                            <td class="prequestiontext"><b>mail/return?</b>
                            </td>
                            <td class="prequestionbox">
                                <label id="lblMail_Return" runat="server" />
                            </td>
                        </tr>
                    </table>
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
                                    <b><%# DataBinder.Eval(Container.DataItem, "QuestionNum") %>.
                                    <%# DataBinder.Eval(Container.DataItem, "QuestionText") %></b>
                                    <br />
                                    <br />
                                    <%# DataBinder.Eval(Container.DataItem, "AnswerText") %>
                                    <br />
                                    <hr>
                                </td>
                            </tr>

                            <!--
                               <div  style="background-color:lightgray;"> <%# DataBinder.Eval(Container.DataItem, "AnswerText") %> </div>
                               <tr>
                                <td>
                                    <asp:TextBox Text='<%# DataBinder.Eval(Container.DataItem, "AnswerText") %>' Enabled="false"
                                        TextMode="MultiLine" ID="questionbox" CssClass="questiontextbox" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            -->
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </div>

    <table>
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
                                                        <asp:CheckBox ID="verifytime" runat="server" Checked="false" Enabled="false" />
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
    </table>
</asp:Content>