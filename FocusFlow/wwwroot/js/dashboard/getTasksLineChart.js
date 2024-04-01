export default function loadTasksLineChart() {
    $(".chart-spinner").show();
    fetch("/Dashboard/GetTasksLineChartData", {
        method: 'GET',
    })
        .then(function (response) { return response.json(); })
        .then(function (data) {
        var options = {
            series: data.series,
            chart: {
                height: 270,
                type: 'line',
            },
            stroke: {
                curve: "smooth",
            },
            markers: {
                size: 6,
                strokeWidth: 0,
                hover: {
                    size: 7
                }
            },
            xaxis: {
                categories: data.categories,
                labels: {
                    style: {
                        colors: "#ddd",
                    },
                }
            },
            yaxis: {
                labels: {
                    style: {
                        colors: "#fff",
                    },
                }
            },
            tooltip: {
                theme: 'dark'
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
        var chart = new ApexCharts(document.querySelector("#getTasksLineChart"), options);
        chart.render();
        $(".chart-spinner").hide();
    })
        .catch(function (error) { return console.error('Error: ', error); });
}
//# sourceMappingURL=getTasksLineChart.js.map