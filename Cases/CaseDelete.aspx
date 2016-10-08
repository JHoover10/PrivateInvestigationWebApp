<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CaseDelete.aspx.cs" Inherits="WebApplication1.CaseDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-2" style="width: 15%">
                <ul class="nav nav-pills nav-stacked">
                    <li class="active"><a href="/Cases/CasePage.aspx">Cases Page</a></li>
                    <li><a href="/Cases/CaseAdd.aspx">New Case</a></li>
                    <li><a href="/Cases/CaseEdit.aspx">Edit Case</a></li>
                    <li><a href="/Cases/CaseDelete.aspx">Delete Case</a></li>
                </ul>
            </div>
            <div class="col-xs-6" style="width: 65%">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." 
                            AllowSorting="True" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="CaseNumber" HeaderText="Case Number" SortExpression="CaseNumber" />
                                <asp:BoundField DataField="ClientName" HeaderText="Client Name" SortExpression="ClientName" />                          
                                <asp:TemplateField ValidateRequestMode="Enabled">
                                    <ItemTemplate>
                                        <asp:linkButton ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteCase"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ClientName], [CaseNumber] FROM [CaseIntake]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [CaseIntake] WHERE [CaseNumber] = @original_CaseNumber AND (([ClientName] = @original_ClientName) OR ([ClientName] IS NULL AND @original_ClientName IS NULL))" InsertCommand="INSERT INTO [CaseIntake] ([ClientName], [CaseNumber]) VALUES (@ClientName, @CaseNumber)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [CaseIntake] SET [ClientName] = @ClientName WHERE [CaseNumber] = @original_CaseNumber AND (([ClientName] = @original_ClientName) OR ([ClientName] IS NULL AND @original_ClientName IS NULL))">
                            <DeleteParameters>
                                <asp:Parameter Name="original_CaseNumber" Type="String" />
                                <asp:Parameter Name="original_ClientName" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="ClientName" Type="String" />
                                <asp:Parameter Name="CaseNumber" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="ClientName" Type="String" />
                                <asp:Parameter Name="original_CaseNumber" Type="String" />
                                <asp:Parameter Name="original_ClientName" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
            </div>
            <div class="col-xs-2" style="width: 20%">
            </div>
        </div>
    </div>
</asp:Content>
