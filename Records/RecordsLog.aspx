<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecordsLog.aspx.cs" Inherits="WebApplication1.RecordsLog" %>

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
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="RecordRequested" HeaderText="Record Requested" SortExpression="RecordRequested" />
                        <asp:BoundField DataField="RecordSubCat" HeaderText="Record Sub-Category" SortExpression="RecordSubCat" />
                        <asp:BoundField DataField="RecordInfo" HeaderText="Record Location &amp; Contact Relationship" SortExpression="RecordInfo" />
                        <asp:BoundField DataField="RecordRelationship" HeaderText="Record Relationship" SortExpression="RecordRelationship" />
                        <asp:BoundField DataField="RecordStatus" HeaderText="Record Status" SortExpression="RecordStatus" />
                        <asp:BoundField DataField="RecordNotes" HeaderText="Record Notes" SortExpression="RecordNotes" />
                        <asp:BoundField DataField="LinkToRecord" HeaderText="Link To Record" SortExpression="LinkToRecord" />
                        <asp:BoundField DataField="ReceiptStatus" HeaderText="Receipt Status" SortExpression="ReceiptStatus" />
                        <asp:BoundField DataField="ReceiptNotes" HeaderText="Receipt Notes" SortExpression="ReceiptNotes" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [RecordLog] WHERE [id] = @id" InsertCommand="INSERT INTO [RecordLog] ([CaseNumber], [RecordRequested], [RecordSubCat], [RecordInfo], [RecordRelationship], [RecordStatus], [RecordNotes], [LinkToRecord], [ReceiptStatus], [ReceiptNotes], [id]) VALUES (@CaseNumber, @RecordRequested, @RecordSubCat, @RecordInfo, @RecordRelationship, @RecordStatus, @RecordNotes, @LinkToRecord, @ReceiptStatus, @ReceiptNotes, @id)" UpdateCommand="UPDATE [RecordLog] SET [CaseNumber] = @CaseNumber, [RecordRequested] = @RecordRequested, [RecordSubCat] = @RecordSubCat, [RecordInfo] = @RecordInfo, [RecordRelationship] = @RecordRelationship, [RecordStatus] = @RecordStatus, [RecordNotes] = @RecordNotes, [LinkToRecord] = @LinkToRecord, [ReceiptStatus] = @ReceiptStatus, [ReceiptNotes] = @ReceiptNotes WHERE [id] = @id"></asp:SqlDataSource>
            </div>
            <div class="col-xs-2" style="width: 20%">
            </div>
        </div>
    </div>
    <%--<div id="wrapper">
        <div id="sidebar-wrapper" style="color: white; background-color: #262626">
            <ul class="sidebar-nav" style="color: white; background-color: #262626">
                <li class="sidebar-brand">Case Information</li>
                <li><a href="/Cases/CaseInfo.aspx">Basic Info</a></li>
                <li><a href="/Cases/RecordsLog.aspx">Records Log</a></li>
                <li><a href="/Cases/WitnessList.aspx">Witness List</a></li>
            </ul>
        </div>
        <div id="page-content-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <div>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." CssClass="table table-striped">
                                <Columns>
                                    <asp:BoundField DataField="RecordRequested" HeaderText="Record Requested" SortExpression="RecordRequested" />
                                    <asp:BoundField DataField="RecordSubCat" HeaderText="Record Sub-Category" SortExpression="RecordSubCat" />
                                    <asp:BoundField DataField="RecordInfo" HeaderText="Record Location &amp; Contact Relationship" SortExpression="RecordInfo" />
                                    <asp:BoundField DataField="RecordRelationship" HeaderText="Record Relationship" SortExpression="RecordRelationship" />
                                    <asp:BoundField DataField="RecordStatus" HeaderText="Record Status" SortExpression="RecordStatus" />
                                    <asp:BoundField DataField="RecordNotes" HeaderText="Record Notes" SortExpression="RecordNotes" />
                                    <asp:BoundField DataField="LinkToRecord" HeaderText="Link To Record" SortExpression="LinkToRecord" />
                                    <asp:BoundField DataField="ReceiptStatus" HeaderText="Receipt Status" SortExpression="ReceiptStatus" />
                                    <asp:BoundField DataField="ReceiptNotes" HeaderText="Receipt Notes" SortExpression="ReceiptNotes" />
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:CommandField ShowDeleteButton="True" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [RecordLog] WHERE [id] = @id" InsertCommand="INSERT INTO [RecordLog] ([CaseNumber], [RecordRequested], [RecordSubCat], [RecordInfo], [RecordRelationship], [RecordStatus], [RecordNotes], [LinkToRecord], [ReceiptStatus], [ReceiptNotes], [id]) VALUES (@CaseNumber, @RecordRequested, @RecordSubCat, @RecordInfo, @RecordRelationship, @RecordStatus, @RecordNotes, @LinkToRecord, @ReceiptStatus, @ReceiptNotes, @id)" UpdateCommand="UPDATE [RecordLog] SET [CaseNumber] = @CaseNumber, [RecordRequested] = @RecordRequested, [RecordSubCat] = @RecordSubCat, [RecordInfo] = @RecordInfo, [RecordRelationship] = @RecordRelationship, [RecordStatus] = @RecordStatus, [RecordNotes] = @RecordNotes, [LinkToRecord] = @LinkToRecord, [ReceiptStatus] = @ReceiptStatus, [ReceiptNotes] = @ReceiptNotes WHERE [id] = @id">
                                <DeleteParameters>
                                    <asp:Parameter Name="id" Type="Object" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="CaseNumber" Type="String" />
                                    <asp:Parameter Name="RecordRequested" Type="String" />
                                    <asp:Parameter Name="RecordSubCat" Type="String" />
                                    <asp:Parameter Name="RecordInfo" Type="String" />
                                    <asp:Parameter Name="RecordRelationship" Type="String" />
                                    <asp:Parameter Name="RecordStatus" Type="String" />
                                    <asp:Parameter Name="RecordNotes" Type="String" />
                                    <asp:Parameter Name="LinkToRecord" Type="String" />
                                    <asp:Parameter Name="ReceiptStatus" Type="String" />
                                    <asp:Parameter Name="ReceiptNotes" Type="String" />
                                    <asp:Parameter Name="id" Type="Object" />
                                </InsertParameters>
                                <SelectParameters>
                                    <asp:QueryStringParameter DefaultValue="123" Name="CaseNumber" QueryStringField="CaseNumber" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="CaseNumber" Type="String" />
                                    <asp:Parameter Name="RecordRequested" Type="String" />
                                    <asp:Parameter Name="RecordSubCat" Type="String" />
                                    <asp:Parameter Name="RecordInfo" Type="String" />
                                    <asp:Parameter Name="RecordRelationship" Type="String" />
                                    <asp:Parameter Name="RecordStatus" Type="String" />
                                    <asp:Parameter Name="RecordNotes" Type="String" />
                                    <asp:Parameter Name="LinkToRecord" Type="String" />
                                    <asp:Parameter Name="ReceiptStatus" Type="String" />
                                    <asp:Parameter Name="ReceiptNotes" Type="String" />
                                    <asp:Parameter Name="id" Type="Object" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <br />                        
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="http://code.jquery.com/jquery-latest.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>--%>
</asp:Content>
