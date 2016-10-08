<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WitnessEdit.aspx.cs" Inherits="WebApplication1.WitnessEdit" %>

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
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="True" Visible="False" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate><%# Eval("FirstName") + " " + Eval("LastName")%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Relationship" HeaderText="Relationship" SortExpression="Relationship" />
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate><%# Eval("StreetAddress") + " " + Eval("City") + ", " + Eval("State") + " " + Eval("ZipCode")%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Testify" HeaderText="Testify" SortExpression="Testify" />
                        <asp:BoundField DataField="InterviewLink1" HeaderText="Interview Link 1" SortExpression="InterviewLink1" />
                        <asp:BoundField DataField="InterviewLink2" HeaderText="Interview Link 2" SortExpression="InterviewLink2" />
                        <asp:BoundField DataField="CQIIntroComplete" HeaderText="CQI Introduction Complete" SortExpression="CQIIntroComplete" />
                        <asp:BoundField DataField="IntroPacketSent" HeaderText="Introduction Packet Sent" SortExpression="IntroPacketSent" />
                        <asp:BoundField DataField="NotesAndContactAttempts" HeaderText="Notes and Contact Attempts" SortExpression="NotesAndContactAttempts" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server" Text="Edit" OnClick="EditWitness" /></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [WitnessList]"></asp:SqlDataSource>
            </div>
            <div class="col-xs-2" style="width: 20%">
            </div>
        </div>
    </div>
</asp:Content>
