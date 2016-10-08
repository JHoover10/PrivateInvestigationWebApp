<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecordsEdit.aspx.cs" Inherits="WebApplication1.RecordsEdit" %>

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
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="RecordRequested" HeaderText="Record Requested" SortExpression="RecordRequested" />
                        <asp:BoundField DataField="RecordSubCat" HeaderText="Record Sub-Category" SortExpression="RecordSubCat" />
                        <asp:BoundField DataField="RecordInfo" HeaderText="Record Location &amp; Contact Relationship" SortExpression="RecordInfo" />
                        <asp:BoundField DataField="RecordRelationship" HeaderText="Record Relationship" SortExpression="RecordRelationship" />
                        <asp:BoundField DataField="RecordStatus" HeaderText="Record Status" SortExpression="RecordStatus" />
                        <asp:BoundField DataField="RecordNotes" HeaderText="Record Notes" SortExpression="RecordNotes" />
                        <asp:BoundField DataField="LinkToRecord" HeaderText="Link To Record" SortExpression="LinkToRecord" />
                        <asp:BoundField DataField="ReceiptStatus" HeaderText="Receipt Status" SortExpression="ReceiptStatus" />
                        <asp:BoundField DataField="ReceiptNotes" HeaderText="Receipt Notes" SortExpression="ReceiptNotes" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server" Text="Edit" OnClick="EditRecord" /></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [RecordLog] WHERE [id] = @id" InsertCommand="INSERT INTO [RecordLog] ([CaseNumber], [RecordRequested], [RecordSubCat], [RecordInfo], [RecordRelationship], [RecordStatus], [RecordNotes], [LinkToRecord], [ReceiptStatus], [ReceiptNotes], [id]) VALUES (@CaseNumber, @RecordRequested, @RecordSubCat, @RecordInfo, @RecordRelationship, @RecordStatus, @RecordNotes, @LinkToRecord, @ReceiptStatus, @ReceiptNotes, @id)" UpdateCommand="UPDATE [RecordLog] SET [CaseNumber] = @CaseNumber, [RecordRequested] = @RecordRequested, [RecordSubCat] = @RecordSubCat, [RecordInfo] = @RecordInfo, [RecordRelationship] = @RecordRelationship, [RecordStatus] = @RecordStatus, [RecordNotes] = @RecordNotes, [LinkToRecord] = @LinkToRecord, [ReceiptStatus] = @ReceiptStatus, [ReceiptNotes] = @ReceiptNotes WHERE [id] = @id"></asp:SqlDataSource>
            </div>
            <div class="col-xs-2" style="width: 20%">
            </div>
        </div>
    </div>
</asp:Content>
