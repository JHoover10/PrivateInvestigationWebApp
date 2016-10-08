<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WitnessEditSelected.aspx.cs" Inherits="WebApplication1.WitnessEditSelected" %>

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
                            <li><a href="/Records/RecordsAdd.aspx">Add a Record</a></li>
                            <li><a href="/Records/RecordsEdit.aspx">Edit a Record</a></li>
                            <li><a href="/Records/RecordsDelete.aspx">Delete a Record</a></li>
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
            <div class="col-xs-6" style="width: 65%">
                <div class="form-inline row" role="form"> 
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">First Name:</asp:Label>
                        <asp:TextBox ID="FirstName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Middle Name:</asp:Label>
                        <asp:TextBox ID="MiddleName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Last Name:</asp:Label>
                        <asp:TextBox ID="LastName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Relationship:</asp:Label>
                        <asp:TextBox ID="Relationship" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-inline row" role="form"> 
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Street Address:</asp:Label>
                        <asp:TextBox ID="StreetAddress" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">City:</asp:Label>
                        <asp:TextBox ID="City" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">State:</asp:Label>
                        <asp:TextBox ID="State" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Zip Code:</asp:Label>
                        <asp:TextBox ID="ZipCode" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-inline row" role="form"> 
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Phone Number:</asp:Label>
                        <asp:TextBox ID="PhoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Email:</asp:Label>
                        <asp:TextBox ID="Email" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Testify:</asp:Label>
                        <asp:TextBox ID="Testify" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-inline row" role="form"> 
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Interview Link 1:</asp:Label>
                        <asp:TextBox ID="Link1" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Interview Link 2:</asp:Label>
                        <asp:TextBox ID="Link2" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Introduction Complete:</asp:Label>
                        <asp:TextBox ID="IntroComplete" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:Label runat="server">Packet Sent:</asp:Label>
                        <asp:TextBox ID="PacketSent" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row" role="form"> 
                    <div class="form-group col-xs-4">
                        <asp:Label runat="server">Notes:</asp:Label>
                        <asp:TextBox ID="Notes" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row" role="form"> 
                    <div class="form-group col-xs-2">
                        <asp:Button ID="Save" OnClick="SaveClick" Text="Save" CssClass="btn btn-default" runat="server"/>
                    </div>
                </div>               
            </div>
            <div class="col-xs-2" style="width: 20%">
            </div>
        </div>
    </div>
</asp:Content>
