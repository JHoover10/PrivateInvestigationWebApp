<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style1 {width: 100%;}
        .auto-style2 {width: 301px;}
        .auto-style3 {width: 406px;}
        .auto-style4 {
            position: absolute;
            right: -3px;
            top: 340px;
            width: 100%;
        }
    </style>
    <table class="auto-style4">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3" align ="center">Log in below:</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" align="right">Email:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="login_email" runat="server" Width="400px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="login_email" Display="Dynamic" ErrorMessage="Email is required." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="right">Password:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="login_pwd" runat="server" Width="401px" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="login_pwd" Display="Dynamic" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3" align="center">
                    <asp:Button ID="button_login" runat="server" Text="Log In" OnClick="button_login_Click"/>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button_Reg" runat="server" Text="Registration" BackColor="Black" BorderColor="#0066FF" BorderStyle="Outset" CausesValidation="False" ForeColor="#CCCCCC" OnClick="Button_Reg_Click" />
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
</asp:Content>
