<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SystemMonitor.Web.WebForm1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body>
    <div id="container" style="width: 100%; height: 400px"></div>

    <script src="Scripts/jquery-1.8.0.js"></script>
    <script src="Scripts/json2.js"></script>
    <script src="Scripts/jquery.signalR-0.5.3.js"></script>
    <script src="Scripts/highcharts.js"></script>

    <script type="text/javascript">

        var chart;

        $(document).ready(function () {

            var cn = $.hubConnection();
            var hub = cn.createProxy('randomNumber');

            hub.on('updateChart', function (v) {
                var series = chart.series[0],
                    shift = series.data.length > 20;

                chart.series[0].addPoint(v, true, shift);
            });

            cn.start().done(function () {
                hub.invoke('init');
            });

            chart = new Highcharts.Chart({
                chart: {
                    renderTo: 'container',
                    type: 'line'
                },
                title: {
                    text: 'Plotting Random Data'
                },
                xAxis: {
                    categories: ['Randomness']
                },
                yAxis: {
                    title: {
                        text: 'Random Values'
                    }
                },
                series: [{
                    name: 'Random Data',
                    data: []
                }]
            });
        });

    </script>
</body>
</html>
