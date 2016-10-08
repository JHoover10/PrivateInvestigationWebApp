<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WitnessDownloadSelected.aspx.cs" Inherits="WebApplication1.WitnessDownloadSelected" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-2" style="width: 15%">
                <ul class="nav nav-pills nav-stacked">
                    <li class="active"><a href="/Cases/CaseInfo.aspx">Case Information</a></li>
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Intake Sheet<span class="caret"></span></a>
                        <ul class="dropdown-menu" style="color: black">
                            <li><a href="/Cases/CaseSelect.aspx">View Intake Sheet</a></li>
                            <li><a href="/Cases/CaseEdit.aspx">Edit Intake Sheet</a></li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Record Log<span class="caret"></span></a>
                        <ul class="dropdown-menu" style="color: black">
                            <li><a href="/Records/RecordsLog.aspx">View Record Log</a></li>
                            <li><a href="#">Add a Record</a></li>
                            <li><a href="#">Edit a Record</a></li>
                            <li><a href="#">Delete a Record</a></li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Witness List<span class="caret"></span></a>
                        <ul class="dropdown-menu" style="color: black">
                            <li><a href="/Witness/WitnessList.aspx">View Witness List</a></li>
                            <li><a href="/Witness/WitnessAdd.aspx">Add a Witness</a></li>
                            <li><a href="/Witness/WitnessEdit.aspx">Edit a Witness</a></li>
                            <li><a href="/Witness/WitnessDownload.aspx">Download files for Witness</a></li>
                            <li><a href="/Witness/WitnessDelete.aspx">Delete a Witness</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="col-xs-8" style="width: 65%">
                <div>
                    List of Files:<br />
                    <asp:CheckBox ID="WitnessFilesSA" Text="Select All" runat="server"/>
                    <asp:CheckBoxList ID="WitnessFilesList" runat="server"></asp:CheckBoxList>
                    <br />
                    <asp:CheckBox ID="RecordsFilesSA" Text="Select All" runat="server"/>
                    <asp:CheckBoxList ID="RecordsFilesList" runat="server"></asp:CheckBoxList>
                </div>
                <div>
                    <asp:Button ID="DownloadButton" Text="Download Files" OnClick="Download" runat="server"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
