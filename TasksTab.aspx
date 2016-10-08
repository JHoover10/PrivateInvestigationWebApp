<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TasksTab.aspx.cs" Inherits="WebApplication1.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <img src="Images/quinn_01.jpg" style="height: 219px; width: 320px"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        This is the Task Page
        <br />
        <asp:Button ID="Button1" runat="server" Text="Dashboard" OnClick="DashboardTab" />
        <asp:Button ID="Button2" runat="server" Text="Cases" OnClick="CasesTab"/>
        <asp:Button ID="Button3" runat="server" Text="Templates" OnClick="TemplatesTab"/>
        <asp:Button ID="Button4" runat="server" Text="Tasks" OnClick="TasksTab"/>
        <asp:Button ID="Button6" runat="server" Text="Billing" OnClick="BillingTab"/>
    
        <br />
        <br />
        Assign a new task:
        <asp:DropDownList ID="DropDownList1" runat="server" Height="19px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="146px">
            <asp:ListItem Selected="True">Anthony Baker</asp:ListItem>
            <asp:ListItem>Steve</asp:ListItem>
            <asp:ListItem>Jeff</asp:ListItem>
            <asp:ListItem>ballz</asp:ListItem>
        </asp:DropDownList>
    
    </div>
    </form>
</body>
</html>
