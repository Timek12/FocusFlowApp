declare var ApexCharts: any;

export default function loadTasksLineChart() {
    $(".chart-spinner").show();

    fetch("/Dashboard/GetTasksLineChartData", {
        method: 'GET',
    })
        .then(response => response.json())
        .then(data => {
            var options = {
                series: data.series,
                chart: {
                    height: 300,
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
        .catch(error => console.error('Error: ', error));
}