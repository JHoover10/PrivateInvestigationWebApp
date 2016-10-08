<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignTask.aspx.cs" Inherits="WebApplication1.AssignTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-2" style="width: 15%">
                <ul class="nav nav-pills nav-stacked">
                    <li class="active"><a href="/Tasks/TasksTab.aspx">Tasks/Activity Log</a></li>
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Tasks<span class="caret"></span></a>
                        <ul class="dropdown-menu" style="color: black">
                            <li><a href="/Tasks/AssignTask.aspx">Assign a Task</a></li>
                        </ul>
                    </li>
                    <li><a href="/Tasks/timelinePage.aspx">Activity Log Timeline</a></li>
                </ul>
            </div>
        </div>
    </div>
    <style type="text/css">
        .auto-style1 {
            position:;
            left: 26px;
            top: 50px;
            width: 15%;
        }        
        .auto-style2 {
            position: inherit;
            top: 75px;

        }
        .auto-style3 {
            position: inherit;
            width: 556px;            
            top: 125px;
        }
        .div2 {
            position: absolute;
            left: 283px;
            top: 360px;
            width: 85%;
            height: 41px;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
     <div class ="div2">
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
            <ContentTemplate>              
                Client Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddl_name" runat="server"  DataTextField="ClientName" DataValueField="ClientName" OnSelectedIndexChanged="ddl_name_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Selected="True">Client Name</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                Case Number:&nbsp;&nbsp;&nbsp;&nbsp;    
                <asp:DropDownList ID="ddl_caseNum" runat="server"  DataTextField="CaseNumber" DataValueField="CaseNumber">
                    <asp:ListItem Selected="True">Case Number</asp:ListItem>
                </asp:DropDownList>               
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
         <div class="auto-style2">
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Email" DataValueField="Email"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Email From ACCOUNT"></asp:SqlDataSource>
            <br />
             <br />
           Task Description: 
             <br />
             <asp:TextBox ID="TextBox_Task" runat="server" Height="115px" Width="509px" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="Button_Submit" runat="server" Text="Submit" Height="31px" Width="88px" OnClick="Button_Submit_Click" />
        </div>

    </div>
            
</asp:Content>
