export default function loadTotalTasksStatusPieChart() {
    fetch("/Dashboard/GetTasksStatusPieChartData", {
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
            colors: ['#32CD32', '#B0E0E6'],
            title: {
                text: 'Total Tasks Status',
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
        var chart = new ApexCharts(document.querySelector("#totalTasksStatusPieChart"), options);
        chart.render();
    })
        .catch(function (error) { return console.error('Error: ', error); });
}
//# sourceMappingURL=getTotalTasksStatusPieChart.js.map