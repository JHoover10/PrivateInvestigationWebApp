<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CaseAdd.aspx.cs" Inherits="WebApplication1.CaseAdd" %>

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
            <div class="col-xs-8" style="width: 85%">
                <div class="form-horizontal" role="form">
                    <div class="form-group form-inline panel panel-default" style="width: 50%">
                        <asp:FileUpload ID="UploadImage" runat="server"/>     
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group col-xs-2">
                            <asp:CheckBox ID="PhaseI" Text="Phase I" runat="server" />
                        </div>
                        <div class="form-group col-xs-2">
                            <asp:CheckBox ID="Phase2" Text="Phase II" runat="server" />
                        </div>
                    </div>
                    <div class="form-group form-inline panel panel-default">
                        <div class="panel-heading" style="background-color: steelblue; color: white; text-align: left">Client Information</div>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Client Name:</asp:Label>
                        <asp:TextBox ID="ClientName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Client Name" ControlToValidate="ClientName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Case Number:</asp:Label>
                        <asp:TextBox ID="CaseNumber" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter a Unique Case Number" ControlToValidate="CaseNumber" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Client DOB:</asp:Label>
                        <asp:TextBox ID="ClientDOB" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Lead Counsel:</asp:Label>
                        <asp:TextBox ID="LeadCounsel" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Second Chair Counsel:</asp:Label>
                        <asp:TextBox ID="SecondChairCounsel" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Charges:</asp:Label>
                        <asp:TextBox ID="Charges" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Cir./Jdx.:</asp:Label>
                        <asp:CheckBox ID="StateOfFlorida" runat="server" />
                        <asp:Label class="control-label" runat="server">State of Florida:</asp:Label>                        
                        <asp:DropDownList ID="Circuit" runat="server" >
                            <asp:ListItem Selected="True" Value="0">Choose an item</asp:ListItem>
                            <asp:ListItem Value="0">N/A</asp:ListItem>
                            <asp:ListItem Value="1">First Circuit</asp:ListItem>
                            <asp:ListItem Value="2">Second Circuit</asp:ListItem>
                            <asp:ListItem Value="3">Thrid Circuit</asp:ListItem>
                            <asp:ListItem Value="4">Fourth Circuit</asp:ListItem>
                            <asp:ListItem Value="5">Fifth Circuit</asp:ListItem>
                            <asp:ListItem Value="6">Sixth Circuit</asp:ListItem>
                            <asp:ListItem Value="7">Seventh Circuit</asp:ListItem>
                            <asp:ListItem Value="8">Eighth Circuit</asp:ListItem>
                            <asp:ListItem Value="9">Ninth Circuit</asp:ListItem>
                            <asp:ListItem Value="10">Tenth Circuit</asp:ListItem>
                            <asp:ListItem Value="11">Eleventh Circuit</asp:ListItem>
                            <asp:ListItem Value="12">Twelfth Circuit</asp:ListItem>
                            <asp:ListItem Value="13">Thriteenth Circuit</asp:ListItem>
                            <asp:ListItem Value="14">Fourteenth Circuit</asp:ListItem>
                            <asp:ListItem Value="15">Fifteenth Circuit</asp:ListItem>
                            <asp:ListItem Value="16">Sixteenth Circuit</asp:ListItem>
                            <asp:ListItem Value="17">Seventeenth Circuit</asp:ListItem>
                            <asp:ListItem Value="18">Eighteenth Circuit</asp:ListItem>
                            <asp:ListItem Value="19">Ninteenth Circuit</asp:ListItem>
                            <asp:ListItem Value="20">Twentieth Circuit</asp:ListItem>
                        </asp:DropDownList>
                                                
                        <asp:CheckBox ID="US" runat="server" />
                        <asp:Label class="control-label" runat="server">U.S.:</asp:Label>
                        <asp:DropDownList ID="District" runat="server">
                            <asp:ListItem Selected="True">Select an item</asp:ListItem>
                            <asp:ListItem>N/A</asp:ListItem>
                            <asp:ListItem>Middle District of Alabama (M.D. Ala.)</asp:ListItem>
                            <asp:ListItem>Northern District of Alabama (N.D. Ala.)</asp:ListItem>
                            <asp:ListItem>Southern District of Alabama (S.D. Ala.)</asp:ListItem>
                            <asp:ListItem>District of Alaska  (D. Alaska)</asp:ListItem>
                            <asp:ListItem>District of Arizona (D. Ariz.)</asp:ListItem>
                            <asp:ListItem>Eastern District of Arkansas (E.D. Ark.)</asp:ListItem>
                            <asp:ListItem>Western District of Arkansas (W.D. Ark.)</asp:ListItem>
                            <asp:ListItem>Central District of California (C.D. Cal.)</asp:ListItem>
                            <asp:ListItem>Eastern District of California (E.D. Cal.</asp:ListItem>
                            <asp:ListItem>Northern District of California (N.D. Cal.)</asp:ListItem>
                            <asp:ListItem>Southern District of California (S.D. Cal)</asp:ListItem>
                            <asp:ListItem>District of the Canal Zone (D.C.Z. (The D.C.Z. ceased to exist on 3/31/1982))</asp:ListItem>
                            <asp:ListItem>District of Colorado (D. Colo.)</asp:ListItem>
                            <asp:ListItem>District of Connecticut (D. Conn.)</asp:ListItem>
                            <asp:ListItem>District of Delaware (D. Del.)</asp:ListItem>
                            <asp:ListItem>District of D.C. (D.D.C.)</asp:ListItem>
                            <asp:ListItem>Middle District of Florida (M.D. Fla.)</asp:ListItem>
                            <asp:ListItem>Northern District of Florida (N.D. Fla.)</asp:ListItem>
                            <asp:ListItem>Southern District of Florida (S.D. Fla.)</asp:ListItem>
                            <asp:ListItem>Middle District of Georgia (M.D. Ga.)</asp:ListItem>
                            <asp:ListItem>Northern District of Georgia (N.D. Ga)</asp:ListItem>
                            <asp:ListItem>Southern District of Georgia (S.D. Ga.)</asp:ListItem>
                            <asp:ListItem>District of Guam (D. Guam)</asp:ListItem>
                            <asp:ListItem>District of Hawaii (D. Haw.)</asp:ListItem>
                            <asp:ListItem>District of Idaho (D. Idaho)</asp:ListItem>
                            <asp:ListItem>Central District of Illinois (C.D. Ill.)</asp:ListItem>
                            <asp:ListItem>Northern District of Illinois (N.D. Ill.)</asp:ListItem>
                            <asp:ListItem>Northern District of Indiana (N.D. Ind.)</asp:ListItem>
                            <asp:ListItem>Southern District of Indiana (S.D. Ind.)</asp:ListItem>
                            <asp:ListItem>Northern District of Iowa (N.D. Iowa)</asp:ListItem>
                            <asp:ListItem>Southern District of Iowa (S.D. Iowa)</asp:ListItem>
                            <asp:ListItem>District of Kansas (D. Kan.)</asp:ListItem>
                            <asp:ListItem>Eastern District of Kentucky (E.D. Ky.)</asp:ListItem>
                            <asp:ListItem>Western District of Kentucky (E.D. Ky.)</asp:ListItem>
                            <asp:ListItem>Western District of Kentucky (W.D. Ky.)</asp:ListItem>
                            <asp:ListItem>Eastern District of Louisiana (E.D. La.)</asp:ListItem>
                            <asp:ListItem>Middle District of Louisiana (M.D. La.)</asp:ListItem>
                            <asp:ListItem>Western District of Louisiana (W.D. La.)</asp:ListItem>
                            <asp:ListItem>District of Maine (D. Me.)</asp:ListItem>
                            <asp:ListItem>District of Maryland (D. Md.)</asp:ListItem>
                            <asp:ListItem>District of Massachusetts (D. Mass.)</asp:ListItem>
                            <asp:ListItem>Eastern District of Michigan (E.D. Mich.)</asp:ListItem>
                            <asp:ListItem>Western District of Michigan (W.D. Mich.)</asp:ListItem>
                            <asp:ListItem>District of Minnesota (D. Minn.)</asp:ListItem>
                            <asp:ListItem>Northern District of Mississippi (N.D. Miss.)</asp:ListItem>
                            <asp:ListItem>Southern District of Mississippi (S.D. Miss.)</asp:ListItem>
                            <asp:ListItem>Eastern District of Missouri (E.D. Mo.)</asp:ListItem>
                            <asp:ListItem>Western District of Missouri (W.D. Mo.)</asp:ListItem>
                            <asp:ListItem>District of Montana (D. Mont.)</asp:ListItem>
                            <asp:ListItem>District of Nebraska (D. Neb.)</asp:ListItem>
                            <asp:ListItem>District of Nevada (D. Nev.)</asp:ListItem>
                            <asp:ListItem>District of New Hampshire (D.N.H.)</asp:ListItem>
                            <asp:ListItem>District of New Jersey (D.N.J.)</asp:ListItem>
                            <asp:ListItem>District of New Mexico (D.N.M.)</asp:ListItem>
                            <asp:ListItem>Eastern District of New York (E.D.N.Y.)</asp:ListItem>
                            <asp:ListItem>Northern District of New York (N.D.N.Y.)</asp:ListItem>
                            <asp:ListItem>Southern District of New York (S.D.N.Y.)</asp:ListItem>
                            <asp:ListItem>Western District of New York  (W.D.N.Y.)</asp:ListItem>
                            <asp:ListItem>Eastern District of North Carolina (E.D.N.C.)</asp:ListItem>
                            <asp:ListItem>Middle District of North Carolina (M.D.N.C.)</asp:ListItem>
                            <asp:ListItem>Western District of North Carolina (W.D.N.C.)</asp:ListItem>
                            <asp:ListItem>District of North Dakota (D.N.D.)</asp:ListItem>
                            <asp:ListItem>Northern District of Ohio (N.D. Ohio)</asp:ListItem>
                            <asp:ListItem>Southern District of Ohio (S.D. Ohio)</asp:ListItem>
                            <asp:ListItem>Eastern District of Oklahoma (E.D. Okla.)</asp:ListItem>
                            <asp:ListItem>Northern District of Oklahoma (N.D. Okla.)</asp:ListItem>
                            <asp:ListItem>Western District of Oklahoma (W.D. Okla.)</asp:ListItem>
                            <asp:ListItem>District of Oregon (D. Or.)</asp:ListItem>
                            <asp:ListItem>Eastern District of Pennsylvania (E.D. Pa.)</asp:ListItem>
                            <asp:ListItem>Middle District of Pennsylvania (M.D. Pa.)</asp:ListItem>
                            <asp:ListItem>Western District of Pennsylvania (W.D. Pa.)</asp:ListItem>
                            <asp:ListItem>District of Puerto Rico (D.P.R.)</asp:ListItem>
                            <asp:ListItem>District of Rhode Island (D.R.I.)</asp:ListItem>
                            <asp:ListItem>District of South Carolina (D.S.C.)</asp:ListItem>
                            <asp:ListItem>District of South Dakota (D.S.D.)</asp:ListItem>
                            <asp:ListItem>Eastern District of Tennessee (E.D. Tenn.)</asp:ListItem>
                            <asp:ListItem>Middle District of Tennessee (M.D. Tenn.)</asp:ListItem>
                            <asp:ListItem>Western District of Tennessee (W.D. Tenn.)</asp:ListItem>
                            <asp:ListItem>Eastern District of Texas (E.D. Tex.)</asp:ListItem>
                            <asp:ListItem>Northern District of Texas (N.D. Tex.)</asp:ListItem>
                            <asp:ListItem>Southern District of Texas (S.D. Tex.)</asp:ListItem>
                            <asp:ListItem>Western District of Texas (W.D. Tex.)</asp:ListItem>
                            <asp:ListItem>District of Utah (D. Utah)</asp:ListItem>
                            <asp:ListItem>District of Vermont (D. Vt.)</asp:ListItem>
                            <asp:ListItem>Eastern District of Virginia (E.D. Va.)</asp:ListItem>
                            <asp:ListItem>Western District of Virginia (W.D. Va.)</asp:ListItem>
                            <asp:ListItem>District of the Virgin Islands (D.V.I.)</asp:ListItem>
                            <asp:ListItem>Eastern District of Washington (E.D. Wash.)</asp:ListItem>
                            <asp:ListItem>Western District of Washington (W.D. Wash.)</asp:ListItem>
                            <asp:ListItem>Northern District of West Virginia (N.D.W. Va.)</asp:ListItem>
                            <asp:ListItem>Southern District of West Virginia (S.D.W. Va.)</asp:ListItem>
                            <asp:ListItem>Eastern District of Wisconsin (E.D. Wis.)</asp:ListItem>
                            <asp:ListItem>Western District of Wisconsin (W.D. Wis.)</asp:ListItem>
                            <asp:ListItem>District of Wyoming (D. Wyo.)</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group form-inline panel panel-default">
                        <div class="panel-heading" style="background-color: steelblue; color: white; text-align: left">Case Summary</div>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Summary:</asp:Label>
                        <asp:TextBox ID="Summary" TextMode="MultiLine" Rows="4" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline panel panel-default">
                        <div class="panel-heading" style="background-color: steelblue; color: white; text-align: left">Facility Information</div>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Facility Name:</asp:Label>
                        <asp:TextBox ID="FacilityName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Booking Number:</asp:Label>
                        <asp:TextBox ID="BookingNumber" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Cell Location:</asp:Label>
                        <asp:TextBox ID="CellLocation" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Facility Phone:</asp:Label>
                        <asp:TextBox ID="FacilityPhone" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Mailing Address:</asp:Label>
                        <asp:TextBox ID="MailingAddress" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Physical Address:</asp:Label>
                        <asp:TextBox ID="PhysicalAddress" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Visitation Policy:</asp:Label>
                        <asp:TextBox ID="VisitingPolicy" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline panel panel-default">
                        <div class="panel-heading" style="background-color: steelblue; color: white; text-align: left">Judge Information</div>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Judge Name:</asp:Label>
                        <asp:TextBox ID="JudgeName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Court House:</asp:Label>
                        <asp:TextBox ID="CourtHouse" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Judge Phone:</asp:Label>
                        <asp:TextBox ID="JudgePhone" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Judge Email:</asp:Label>
                        <asp:TextBox ID="JAEmail" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Judge Address:</asp:Label>
                        <asp:TextBox ID="JudgeAddress" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-inline panel panel-default">
                        <div class="panel-heading" style="background-color: steelblue; color: white; text-align: left">State Attorney Office</div>
                        <div class="panel-body" style="background-color: gray; color: white; text-align: left">Attorney 1</div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Name:</asp:Label>
                            <asp:TextBox ID="StateAttorney1Name" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Law Office:</asp:Label>
                            <asp:TextBox ID="StateAttorney1LawOffice" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Phone:</asp:Label>
                            <asp:TextBox ID="StateAttorney1Phone" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Email:</asp:Label>
                            <asp:TextBox ID="StateAttorney1Email" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline panel panel-default">                      
                        <div class="panel-body" style="background-color: gray; color: white; text-align: left">Paralegal</div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Name:</asp:Label>
                            <asp:TextBox ID="StateParalegalName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Law Office:</asp:Label>
                            <asp:TextBox ID="StateParalegalLawOffice" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Phone:</asp:Label>
                            <asp:TextBox ID="StateParalegalPhone" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Email:</asp:Label>
                            <asp:TextBox ID="StateParalegalEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline panel panel-default">                      
                        <div class="panel-body" style="background-color: gray; color: white; text-align: left">Attorney 2</div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Name:</asp:Label>
                            <asp:TextBox ID="StateAttorney2Name" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Law Office:</asp:Label>
                            <asp:TextBox ID="StateAttorney2LawOffice" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Phone:</asp:Label>
                            <asp:TextBox ID="StateAttorney2Phone" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Email:</asp:Label>
                            <asp:TextBox ID="StateAttorney2Email" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline panel panel-default">
                        <div class="panel-heading" style="background-color: steelblue; color: white; text-align: left">Defense Attorney Office</div>
                        <div class="panel-body" style="background-color: gray; color: white; text-align: left">Attorney 1</div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Name:</asp:Label>
                            <asp:TextBox ID="DefenseLeadCounselName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Law Office:</asp:Label>
                            <asp:TextBox ID="DefenseLeadCounselLawOffice" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Phone:</asp:Label>
                            <asp:TextBox ID="DefenseLeadCounselPhone" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Email:</asp:Label>
                            <asp:TextBox ID="DefenseLeadCounselEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline panel panel-default">                      
                        <div class="panel-body" style="background-color: gray; color: white; text-align: left">Paralegal</div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Name:</asp:Label>
                            <asp:TextBox ID="DefenseParalegalName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Law Office:</asp:Label>
                            <asp:TextBox ID="DefenseParalegalLawOffice" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Phone:</asp:Label>
                            <asp:TextBox ID="DefenseParalegalPhone" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Email:</asp:Label>
                            <asp:TextBox ID="DefenseParalegalEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline panel panel-default">                      
                        <div class="panel-body" style="background-color: gray; color: white; text-align: left">Attorney 2</div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Name:</asp:Label>
                            <asp:TextBox ID="DefenseSecondChairName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Law Office:</asp:Label>
                            <asp:TextBox ID="DefenseSecondChairLawOffice" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline">
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Phone:</asp:Label>
                            <asp:TextBox ID="DefenseSecondChairPhone" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-inline col-xs-3">
                            <asp:Label class="control-label" runat="server">Email:</asp:Label>
                            <asp:TextBox ID="DefenseSecondChairEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-inline">
                        <asp:Button ID="Save" runat="server" Text="Save" CssClass="btn btn-default" OnClick="Click_CaseInfoSave"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
