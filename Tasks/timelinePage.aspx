<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="timelinePage.aspx.cs" Inherits="WebApplication1.Tasks.timelinePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .div2 {
            position: absolute;
            left: 283px;
            top: 340px;
            width: 85%;
            height: 41px;
        }
    </style>

    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-2" style="width: 15%">
                <ul class="nav nav-pills nav-stacked">
                    <li class="active"><a href="/Tasks/TasksTab.aspx">Tasks/Activity Log</a></li>
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Tasks<span class="caret"></span></a>
                        <ul class="dropdown-menu" style="color: black">
                            <li><a href="/Tasks/AssignTask.aspx">Assign a Task</a></li>
                        </ul>
                    </li>
                    <li><a href="/Tasks/timelinePage.aspx">Activity Log Timeline</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class ="div2">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server" >
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddl_clientName" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="24px" Width="115px" AppendDataBoundItems="True" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddl_caseNum" runat="server" Width="115px" Height="24px" AppendDataBoundItems="True">
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                <button id="genTimeline">Generate Timeline</button>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div id="container"></div>
    </div>
    <script>
        function createTimeline(tlData) {
            console.log(tlData);
            $('#container').highcharts("StockChart",{

                title: {
                    text: "Activity Log"
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

        $("#genTimeline").on('click', function (e) {

            var tlData = [];
            tlData[0] = $('#<%=ddl_clientName.ClientID %> option:selected').text();
            tlData[1] = $('#<%=ddl_caseNum.ClientID %> option:selected').text()
            var jsonData = JSON.stringify({ tlData: tlData });

            $.ajax({
                type: "POST",
                url: "TimelineDataService.asmx/FetchTask",
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
                    var i = [item.Task, item.Date_Completed, item.email];
                    var obj = {};

                    obj.title = item.Task;
                    obj.x = item.Date_Completed;
                    obj.text = "completed by " + item.email;

                    arr.push(obj);
                });
                var myJsonString = JSON.stringify(arr);
                var jsonArray = JSON.parse(JSON.stringify(arr));

                createTimeline(jsonArray);

            }
            function OnErrorCall(response) {
                console.log(error);
            }
            e.preventDefault();

        });

        

    </script>

</asp:Content>


