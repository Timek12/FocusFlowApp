export default function loadTotalTasksImportancePieChart() {
    $(".chart-spinner").show();
    fetch("/Dashboard/GetTasksImportancePieChartData", {
        method: 'GET',
    })
        .then(function (response) { return response.json(); })
        .then(function (data) {
        var options = {
            chart: {
                height: 325,
                type: 'pie'
            },
            series: data.series,
            labels: data.labels,
            colors: ['#28a745', '#ffc107', '#dc3545'],
            legend: {
                position: 'bottom',
                horizontalAlign: 'center',
                labels: {
                    colors: "#fff",
                    userSeriesColors: true
                },
            },
        };
        var chart = new ApexCharts(document.querySelector("#totalTasksImportancePieChart"), options);
        chart.render();
        $(".chart-spinner").hide();
    })
        .catch(function (error) { return console.error('Error: ', error); });
}
//# sourceMappingURL=getTotalTasksImportancePieChart.js.map