<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddNote.aspx.cs" Inherits="WebApplication1.AddNote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .div2 {
            position: absolute;
            left: 283px;
            top: 357px;
            width: 85%;
            height: 41px;
        }
    </style>
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
    <div class="div2">
        Note Description: 
        <br />
        <asp:TextBox ID="TextBox_Note" runat="server" Height="115px" Width="509px" MaxLength="100" TextMode="MultiLine" ></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button_Submit" runat="server" Text="Submit" Height="31px" Width="88px" OnClick="Button_Submit_Click" style="margin-top: 0px" />

    </div>
    
</asp:Content>
