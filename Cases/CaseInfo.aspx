<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CaseInfo.aspx.cs" Inherits="WebApplication1.CaseInfo" %>

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
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Life Story/Events<span class="caret"></span></a>
                        <ul class="dropdown-menu" style="color: black">
                            <li><a href="/Cases/CaseAddEvent.aspx">Add Event</a></li>

                            <!--<li><a href="/Cases/CaseEditEvent.aspx">Edit/Delete Event</a></li>-->                   
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="col-xs-8" style="width: 65%">
                <div class="col-xs-2">
                    <asp:Image ID="ClientPicture" Style="float: left" runat="server" Height="150px" Width="150px" />
                </div>
                <div class="col-xs-4">
                    <ul class="list-group">
                        <li class="list-group-item">Case Number:<asp:TextBox ID="ClientNumber" CssClass="list-group-item" ReadOnly="true" runat="server"></asp:TextBox></li>
                        <li class="list-group-item">Client Name:<asp:TextBox ID="ClientName" CssClass="list-group-item" ReadOnly="true" runat="server"></asp:TextBox></li>
                    </ul>
                </div>
                <div class="col-xs-2" style="width: 20%">
                <asp:Label class="control-label" runat="server">Summary:</asp:Label>
                <asp:TextBox ID="Summary" TextMode="MultiLine" Rows="4" BorderWidth ="1px" Height="150px" Width="600px" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            </div>
        </div>
    </div>

    <div id="timeline" class="container-fluid" style:"width: 70%" style="left: 264px; top: -18px; width: 70%" ></div>
    
    <script>
        function createTimeline(tlData) {
            console.log(tlData);
            $('#timeline').highcharts("StockChart",{

                title: {
                    text: "Life Story"
                },

                xAxis: {
                    type: 'datetime',
                    labels: {
                        format: '{value:%Y-%m-%d}',
                        rotation: 45,
                        align: 'left'
                    },
                    maxPadding: 0.25
                },

                exporting: {
                    sourceWidth: 1280,
                    sourceHeight: 720,
                    scale: 1,
                    chartOptions: {
                        subtitle: null
                    }
                },

                yAxis: {
                    visible: false
                },

                plotOptions: {

                },

                series: [{
                    type: 'flags',
                    data: tlData
                }]
            });
        }

        function gentimeline() {
            var tlData = [];
            tlData[0] = document.getElementById('<%=ClientName.ClientID%>').value;
            tlData[1] = document.getElementById('<%=ClientNumber.ClientID%>').value;
            var jsonData = JSON.stringify({ tlData: tlData });
            console.log(jsonData);
            $.ajax({
                type: "POST",
                url: "../Tasks/TimelineDataService.asmx/FetchStory",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                error: OnErrorCall
            });

            function OnSuccess(response) {
                var aData = response.d;
                var arr = []

                $.map(aData, function (item, index) {
                    var i = [item.Header, item.Description, item.Event_Date];
                    var obj = {};

                    obj.title = item.Header;
                    obj.x = item.Event_Date;
                    obj.text = item.Description;

                    arr.push(obj);
                });
                var myJsonString = JSON.stringify(arr);
                var jsonArray = JSON.parse(JSON.stringify(arr));
                console.log(jsonArray);
                createTimeline(jsonArray);

            }
            function OnErrorCall(response) {
                console.log(error);
            }
           // e.preventDefault();

        }

    </script>

</asp:Content>