var ApexCharts;
$(function () {
    loadSessionsLineChart();
});
function loadSessionsLineChart() {
    fetch("/Dashboard/GetSessionsLineChartData", {
        method: 'GET',
    })
        .then(function (response) { return response.json(); })
        .then(function (data) {
        var options = {
            series: data.series,
            chart: {
                height: 350,
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
            legend: {
                labels: {
                    colors: "#fff",
                },
            },
            tooltip: {
                theme: 'dark'
            }
        };
        var chart = new ApexCharts(document.querySelector("#getSessionsLineChart"), options);
        chart.render();
    })
        .catch(function (error) { return console.error('Error: ', error); });
}
//# sourceMappingURL=getTasksLineChart.js.map
//# sourceMappingURL=getSessionsLineChart.js.map