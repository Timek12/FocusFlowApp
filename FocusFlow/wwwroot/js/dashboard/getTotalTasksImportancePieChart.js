export default function loadTotalTasksImportancePieChart() {
    fetch("/Dashboard/GetTasksImportancePieChartData", {
        method: 'GET',
    })
        .then(function (response) { return response.json(); })
        .then(function (data) {
        var options = {
            chart: {
                type: 'pie'
            },
            series: data.series,
            labels: data.labels,
            colors: ['#28a745', '#ffc107', '#dc3545'],
            title: {
                text: 'Total Tasks Importance',
                align: 'center',
                style: {
                    fontSize: '14px',
                    fontWeight: 'bold',
                    color: '#263238'
                },
            },
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
    })
        .catch(function (error) { return console.error('Error: ', error); });
}
//# sourceMappingURL=getTotalTasksImportancePieChart.js.map