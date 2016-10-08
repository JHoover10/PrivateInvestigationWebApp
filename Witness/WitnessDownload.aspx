<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WitnessDownload.aspx.cs" Inherits="WebApplication1.WitnessDownload" %>

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
            <div class="col-xs-6" style="width: 65%">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ReadOnly="True" Visible="False" />
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
                                <asp:LinkButton ID="DownloadButton" runat="server" Text="Download Files" OnClick="DownloadFiles" /></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [WitnessList] WHERE [Id] = @original_Id AND (([FirstName] = @original_FirstName) OR ([FirstName] IS NULL AND @original_FirstName IS NULL)) AND (([MiddleName] = @original_MiddleName) OR ([MiddleName] IS NULL AND @original_MiddleName IS NULL)) AND (([LastName] = @original_LastName) OR ([LastName] IS NULL AND @original_LastName IS NULL)) AND (([Relationship] = @original_Relationship) OR ([Relationship] IS NULL AND @original_Relationship IS NULL)) AND (([PhoneNumber] = @original_PhoneNumber) OR ([PhoneNumber] IS NULL AND @original_PhoneNumber IS NULL)) AND (([StreetAddress] = @original_StreetAddress) OR ([StreetAddress] IS NULL AND @original_StreetAddress IS NULL)) AND (([City] = @original_City) OR ([City] IS NULL AND @original_City IS NULL)) AND (([State] = @original_State) OR ([State] IS NULL AND @original_State IS NULL)) AND (([ZipCode] = @original_ZipCode) OR ([ZipCode] IS NULL AND @original_ZipCode IS NULL)) AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Testify] = @original_Testify) OR ([Testify] IS NULL AND @original_Testify IS NULL)) AND (([InterviewLink1] = @original_InterviewLink1) OR ([InterviewLink1] IS NULL AND @original_InterviewLink1 IS NULL)) AND (([InterviewLink2] = @original_InterviewLink2) OR ([InterviewLink2] IS NULL AND @original_InterviewLink2 IS NULL)) AND (([CQIIntroComplete] = @original_CQIIntroComplete) OR ([CQIIntroComplete] IS NULL AND @original_CQIIntroComplete IS NULL)) AND (([IntroPacketSent] = @original_IntroPacketSent) OR ([IntroPacketSent] IS NULL AND @original_IntroPacketSent IS NULL)) AND (([NotesAndContactAttempts] = @original_NotesAndContactAttempts) OR ([NotesAndContactAttempts] IS NULL AND @original_NotesAndContactAttempts IS NULL)) AND (([CaseNumber] = @original_CaseNumber) OR ([CaseNumber] IS NULL AND @original_CaseNumber IS NULL))" InsertCommand="INSERT INTO [WitnessList] ([Id], [FirstName], [MiddleName], [LastName], [Relationship], [PhoneNumber], [StreetAddress], [City], [State], [ZipCode], [Email], [Testify], [InterviewLink1], [InterviewLink2], [CQIIntroComplete], [IntroPacketSent], [NotesAndContactAttempts], [CaseNumber]) VALUES (@Id, @FirstName, @MiddleName, @LastName, @Relationship, @PhoneNumber, @StreetAddress, @City, @State, @ZipCode, @Email, @Testify, @InterviewLink1, @InterviewLink2, @CQIIntroComplete, @IntroPacketSent, @NotesAndContactAttempts, @CaseNumber)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [WitnessList]" UpdateCommand="UPDATE [WitnessList] SET [FirstName] = @FirstName, [MiddleName] = @MiddleName, [LastName] = @LastName, [Relationship] = @Relationship, [PhoneNumber] = @PhoneNumber, [StreetAddress] = @StreetAddress, [City] = @City, [State] = @State, [ZipCode] = @ZipCode, [Email] = @Email, [Testify] = @Testify, [InterviewLink1] = @InterviewLink1, [InterviewLink2] = @InterviewLink2, [CQIIntroComplete] = @CQIIntroComplete, [IntroPacketSent] = @IntroPacketSent, [NotesAndContactAttempts] = @NotesAndContactAttempts, [CaseNumber] = @CaseNumber WHERE [Id] = @original_Id AND (([FirstName] = @original_FirstName) OR ([FirstName] IS NULL AND @original_FirstName IS NULL)) AND (([MiddleName] = @original_MiddleName) OR ([MiddleName] IS NULL AND @original_MiddleName IS NULL)) AND (([LastName] = @original_LastName) OR ([LastName] IS NULL AND @original_LastName IS NULL)) AND (([Relationship] = @original_Relationship) OR ([Relationship] IS NULL AND @original_Relationship IS NULL)) AND (([PhoneNumber] = @original_PhoneNumber) OR ([PhoneNumber] IS NULL AND @original_PhoneNumber IS NULL)) AND (([StreetAddress] = @original_StreetAddress) OR ([StreetAddress] IS NULL AND @original_StreetAddress IS NULL)) AND (([City] = @original_City) OR ([City] IS NULL AND @original_City IS NULL)) AND (([State] = @original_State) OR ([State] IS NULL AND @original_State IS NULL)) AND (([ZipCode] = @original_ZipCode) OR ([ZipCode] IS NULL AND @original_ZipCode IS NULL)) AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Testify] = @original_Testify) OR ([Testify] IS NULL AND @original_Testify IS NULL)) AND (([InterviewLink1] = @original_InterviewLink1) OR ([InterviewLink1] IS NULL AND @original_InterviewLink1 IS NULL)) AND (([InterviewLink2] = @original_InterviewLink2) OR ([InterviewLink2] IS NULL AND @original_InterviewLink2 IS NULL)) AND (([CQIIntroComplete] = @original_CQIIntroComplete) OR ([CQIIntroComplete] IS NULL AND @original_CQIIntroComplete IS NULL)) AND (([IntroPacketSent] = @original_IntroPacketSent) OR ([IntroPacketSent] IS NULL AND @original_IntroPacketSent IS NULL)) AND (([NotesAndContactAttempts] = @original_NotesAndContactAttempts) OR ([NotesAndContactAttempts] IS NULL AND @original_NotesAndContactAttempts IS NULL)) AND (([CaseNumber] = @original_CaseNumber) OR ([CaseNumber] IS NULL AND @original_CaseNumber IS NULL))">
                    <DeleteParameters>
                        <asp:Parameter Name="original_Id" Type="Object" />
                        <asp:Parameter Name="original_FirstName" Type="String" />
                        <asp:Parameter Name="original_MiddleName" Type="String" />
                        <asp:Parameter Name="original_LastName" Type="String" />
                        <asp:Parameter Name="original_Relationship" Type="String" />
                        <asp:Parameter Name="original_PhoneNumber" Type="String" />
                        <asp:Parameter Name="original_StreetAddress" Type="String" />
                        <asp:Parameter Name="original_City" Type="String" />
                        <asp:Parameter Name="original_State" Type="String" />
                        <asp:Parameter Name="original_ZipCode" Type="String" />
                        <asp:Parameter Name="original_Email" Type="String" />
                        <asp:Parameter Name="original_Testify" Type="String" />
                        <asp:Parameter Name="original_InterviewLink1" Type="String" />
                        <asp:Parameter Name="original_InterviewLink2" Type="String" />
                        <asp:Parameter Name="original_CQIIntroComplete" Type="String" />
                        <asp:Parameter Name="original_IntroPacketSent" Type="String" />
                        <asp:Parameter Name="original_NotesAndContactAttempts" Type="String" />
                        <asp:Parameter Name="original_CaseNumber" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Id" Type="Object" />
                        <asp:Parameter Name="FirstName" Type="String" />
                        <asp:Parameter Name="MiddleName" Type="String" />
                        <asp:Parameter Name="LastName" Type="String" />
                        <asp:Parameter Name="Relationship" Type="String" />
                        <asp:Parameter Name="PhoneNumber" Type="String" />
                        <asp:Parameter Name="StreetAddress" Type="String" />
                        <asp:Parameter Name="City" Type="String" />
                        <asp:Parameter Name="State" Type="String" />
                        <asp:Parameter Name="ZipCode" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Testify" Type="String" />
                        <asp:Parameter Name="InterviewLink1" Type="String" />
                        <asp:Parameter Name="InterviewLink2" Type="String" />
                        <asp:Parameter Name="CQIIntroComplete" Type="String" />
                        <asp:Parameter Name="IntroPacketSent" Type="String" />
                        <asp:Parameter Name="NotesAndContactAttempts" Type="String" />
                        <asp:Parameter Name="CaseNumber" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="FirstName" Type="String" />
                        <asp:Parameter Name="MiddleName" Type="String" />
                        <asp:Parameter Name="LastName" Type="String" />
                        <asp:Parameter Name="Relationship" Type="String" />
                        <asp:Parameter Name="PhoneNumber" Type="String" />
                        <asp:Parameter Name="StreetAddress" Type="String" />
                        <asp:Parameter Name="City" Type="String" />
                        <asp:Parameter Name="State" Type="String" />
                        <asp:Parameter Name="ZipCode" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Testify" Type="String" />
                        <asp:Parameter Name="InterviewLink1" Type="String" />
                        <asp:Parameter Name="InterviewLink2" Type="String" />
                        <asp:Parameter Name="CQIIntroComplete" Type="String" />
                        <asp:Parameter Name="IntroPacketSent" Type="String" />
                        <asp:Parameter Name="NotesAndContactAttempts" Type="String" />
                        <asp:Parameter Name="CaseNumber" Type="String" />
                        <asp:Parameter Name="original_Id" Type="Object" />
                        <asp:Parameter Name="original_FirstName" Type="String" />
                        <asp:Parameter Name="original_MiddleName" Type="String" />
                        <asp:Parameter Name="original_LastName" Type="String" />
                        <asp:Parameter Name="original_Relationship" Type="String" />
                        <asp:Parameter Name="original_PhoneNumber" Type="String" />
                        <asp:Parameter Name="original_StreetAddress" Type="String" />
                        <asp:Parameter Name="original_City" Type="String" />
                        <asp:Parameter Name="original_State" Type="String" />
                        <asp:Parameter Name="original_ZipCode" Type="String" />
                        <asp:Parameter Name="original_Email" Type="String" />
                        <asp:Parameter Name="original_Testify" Type="String" />
                        <asp:Parameter Name="original_InterviewLink1" Type="String" />
                        <asp:Parameter Name="original_InterviewLink2" Type="String" />
                        <asp:Parameter Name="original_CQIIntroComplete" Type="String" />
                        <asp:Parameter Name="original_IntroPacketSent" Type="String" />
                        <asp:Parameter Name="original_NotesAndContactAttempts" Type="String" />
                        <asp:Parameter Name="original_CaseNumber" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
