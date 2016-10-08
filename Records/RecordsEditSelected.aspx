<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecordsEditSelected.aspx.cs" Inherits="WebApplication1.RecordsEditSelected" %>

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
                    <div class="form-group col-xs-3">
                        <asp:Label runat="server">Record Requested:</asp:Label>
                        <asp:DropDownList ID="RecordRequested" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RecordRequested_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group col-xs-3">
                        <asp:Label runat="server">Record Subcatagory:</asp:Label><br />
                        <asp:DropDownList ID="RecordSubCat" CssClass="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </div>
                    <div class="form-group col-xs-3">
                        <asp:Label runat="server">Record Location:</asp:Label>
                        <asp:TextBox ID="RecordInfo" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                    </div>                    
                </div>
                <div class="form-inline row" role="form"> 
                    <div class="form-group col-xs-3">
                        <asp:Label runat="server">Record Relationship:</asp:Label>
                        <asp:DropDownList ID="RecordRelationship" CssClass="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </div>
                    <div class="form-group col-xs-3">
                        <asp:Label runat="server">Record Status:</asp:Label>
                        <asp:DropDownList ID="RecordStatus" CssClass="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </div>
                    <div class="form-group col-xs-3">
                        <asp:Label runat="server">Record Notes:</asp:Label><br />
                        <asp:TextBox ID="RecordNotes" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                    </div>                    
                </div>
                <div class="form-inline row" role="form">
                    <div class="form-group col-xs-3">
                        <asp:Label runat="server">Link to Record:</asp:Label>
                        <asp:TextBox ID="LinkToRecord" CssClass="form-control" runat="server"></asp:TextBox>
                    </div> 
                    <div class="form-group col-xs-3">
                        <asp:Label runat="server">ReceiptStatus:</asp:Label><br />
                        <asp:DropDownList ID="ReceiptStatus" CssClass="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </div>
                    <div class="form-group col-xs-3">
                        <asp:Label runat="server">Receipt Notes:</asp:Label><br />
                        <asp:TextBox ID="ReceiptNotes" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
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
