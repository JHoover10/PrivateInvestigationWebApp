<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CaseSelect.aspx.cs" Inherits="WebApplication1.CaseSelect" %>

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
                            <li><a href="/Witness/WitnessDelete.aspx">Delete a Witness</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="col-xs-6" style="width: 65%">
                <div class="form-horizontal" role="form">
                    <div class="form-group form-inline" style="width: 50%">
                        <asp:Image ID="Image1" runat="server" Height="252px" Width="252px" />                        
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
                    </div>
                    <div class="form-group form-inline">
                        <asp:Label class="control-label" runat="server">Case Number:</asp:Label>
                        <asp:TextBox ID="CaseNumber" CssClass="form-control" runat="server"></asp:TextBox>
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
                        <asp:DropDownList ID="Circuit" runat="server">
                            <asp:ListItem Selected="True">Choose an item</asp:ListItem>
                            <asp:ListItem>N/A</asp:ListItem>
                            <asp:ListItem>First Circuit</asp:ListItem>
                            <asp:ListItem>Second Circuit</asp:ListItem>
                            <asp:ListItem>Thrid Circuit</asp:ListItem>
                            <asp:ListItem>Fourth Circuit</asp:ListItem>
                            <asp:ListItem>Fifth Circuit</asp:ListItem>
                            <asp:ListItem>Sixth Circuit</asp:ListItem>
                            <asp:ListItem>Seventh Circuit</asp:ListItem>
                            <asp:ListItem>Eighth Circuit</asp:ListItem>
                            <asp:ListItem>Ninth Circuit</asp:ListItem>
                            <asp:ListItem>Tenth Circuit</asp:ListItem>
                            <asp:ListItem>Eleventh Circuit</asp:ListItem>
                            <asp:ListItem>Twelfth Circuit</asp:ListItem>
                            <asp:ListItem>Thriteenth Circuit</asp:ListItem>
                            <asp:ListItem>Fourteenth Circuit</asp:ListItem>
                            <asp:ListItem>Fifteenth Circuit</asp:ListItem>
                            <asp:ListItem>Sixteenth Circuit</asp:ListItem>
                            <asp:ListItem>Seventeenth Circuit</asp:ListItem>
                            <asp:ListItem>Eighteenth Circuit</asp:ListItem>
                            <asp:ListItem>Ninteenth Circuit</asp:ListItem>
                            <asp:ListItem>Twentieth Circuit</asp:ListItem>
                        </asp:DropDownList>

                        <asp:CheckBox ID="USbox" runat="server" />
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
                        <asp:Button ID="Button7" runat="server" OnClick="getFiles" Text="Download Files" />
                    </div>
                    <div class="form-group form-inline">
                        List of Files:<br />
                        <asp:CheckBox ID="CheckBox5" runat="server" Text="Select All" />
                        <asp:CheckBoxList ID="CheckBoxList3" runat="server" Height="54px" Width="699px"></asp:CheckBoxList>
                    </div>
                </div>
                <%--<style type="text/css">
            .auto-style2 {
                width: 200px;
            }
            .auto-style3 {
                width: 150px;
                text-align: right;
            }
            .auto-style4 {
                width: 150px;
                text-align: right;
            }
            .auto-style6 {
                width: 150px;
                text-align: right;
            }
            .auto-style7 {
                width: 150px;
                text-align: right;
            }
            .auto-style8 {
                width: 190px;
            }
            .auto-style9 {
                width: 150px;
                text-align: right;
            }
            .auto-style10 {
                text-decoration: underline;
            }
            .auto-style11 {
                width: 150px;
                text-decoration: underline;
                text-align: left;
            }
        </style>
    <asp:Image ID="Image1" runat="server" Height="252px" Width="252px" />
            
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM [CaseIntake]" 
            OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>

            <br />
            <table style="width:100%;">
                <tr>
                    <td aria-orientation="horizontal" class="auto-style3">Client Name:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="ClientName" runat="server" Width="190px" OnTextChanged="ClientName_TextChanged" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style3">Lead Counsel:</td>
                    <td>
                        <asp:TextBox ID="LeadCounsel" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Case Number:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="CaseNumber" runat="server" Width="190px" OnTextChanged="CaseNumber_TextChanged" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style3">Second Chair Counsel:</td>
                    <td>
                        <asp:TextBox ID="SecondChairCounsel" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style11"><strong style="text-align: left">Case Information</strong></td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style11"><strong>Facility Information</strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Charges:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="Charges" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style6">Facility Name:</td>
                    <td>
                        <asp:TextBox ID="FacilityName" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11"><strong>Judge Information</strong></td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style6">Booking Number:</td>
                    <td>
                        <asp:TextBox ID="BookingNumber" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Name:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="JudgeName" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style6">Cell Location:</td>
                    <td>
                        <asp:TextBox ID="CellLocation" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Court House:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="CourtHouse" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style6">Phone:</td>
                    <td>
                        <asp:TextBox ID="FacilityPhone" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Phone:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="JudgePhone" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style6">Mailing Address:</td>
                    <td>
                        <asp:TextBox ID="MailingAddress" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">JA Email:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="JAEmail" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style6">Physical Address:</td>
                    <td>
                        <asp:TextBox ID="PhysicalAddress" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Address:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="JudgeAddress" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style6">Visiting Policy:</td>
                    <td>
                        <asp:TextBox ID="VisitingPolicy" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td style="font-weight: 700; text-decoration: underline">State Attorney Office</td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style7">Attorney 1</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">Paralegal</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style9">Attorney 2</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">Name:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="StateAttorney1Name" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">Name:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="StateParalegalName" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style9">Name:</td>
                    <td>
                        <asp:TextBox ID="StateAttorney2Name" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Phone:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="StateAttorney1Phone" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">Phone:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="StateParalegalPhone" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style9">Phone:</td>
                    <td>
                        <asp:TextBox ID="StateAttorney2Phone" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Email:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="StateAttorney1Email" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">Email:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="StateParalegalEmail" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style9">Email:</td>
                    <td>
                        <asp:TextBox ID="StateAttorney2Email" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Law Office:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="StateAttorney1LawOffice" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">Law Office:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="StateParalegalLawOffice" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style9">Law Office:</td>
                    <td>
                        <asp:TextBox ID="StateAttorney2LawOffice" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style10"><strong>Defense Attorney Office</strong></td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style7">Lead Counsel</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">Paralegal</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style9">Second Chair Counsel</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">Name:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="DefenseLeadCounselName" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">Name:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="DefenseParalegalName" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style9">Name:</td>
                    <td>
                        <asp:TextBox ID="DefenseSecondChairName" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Phone:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="DefenseLeadCounselPhone" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">Phone:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="DefenseParalegalPhone" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style9">Phone:</td>
                    <td>
                        <asp:TextBox ID="DefenseSecondChairPhone" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Email:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="DefenseLeadCounselEmail" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">Email:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="DefenseParalegalEmail" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style9">Email:</td>
                    <td>
                        <asp:TextBox ID="DefenseSecondChairEmail" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Law Office:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="DefenseLeadCounselLawOffice" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">Law Office:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="DefenseParalegalLawOffice" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style9">Law Office:</td>
                    <td>
                        <asp:TextBox ID="DefenseSecondChairLawOffice" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>--%>
            </div>
        </div>
    </div>
</asp:Content>
