<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CaseAddEvent.aspx.cs" Inherits="WebApplication1.Cases.CaseAddEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 116px">Client Name:</td>
                <td>
                    <asp:TextBox ID="TextBox_Name" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 116px">Case Number:</td>
                <td>
                    <asp:TextBox ID="TextBox_Num" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 116px; height: 107px">Event:</td>
                <td style="height: 107px">
                    <asp:TextBox ID="TextBox_Event" runat="server" CausesValidation="True" Height="90px" MaxLength="1000" TextMode="MultiLine" Width="375px"></asp:TextBox>
                </td>
                <td style="height: 107px"></td>
            </tr>
            <tr>
                <td style="width: 116px">Description:</td>
                <td>
                    <br />
                    <asp:TextBox ID="TextBox_Description" runat="server" Height="90px" TextMode="MultiLine" Width="375px" placeholder="In case you need a longer description"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 116px">Date of Event:</td>
                <td>
                    <asp:TextBox ID="TextBox_Date" runat="server" CausesValidation="True" TextMode="Date"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 116px">&nbsp;</td>
                <td>
                    <asp:Button ID="Button_Submit" runat="server" Text="Submit" OnClick="Button_Submit_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
</asp:Content>
