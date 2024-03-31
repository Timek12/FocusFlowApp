declare var ApexCharts: any;

export default function loadTasksLineChart() {
    fetch("/Dashboard/GetTasksLineChartData", {
        method: 'GET',
    })
        .then(response => response.json())
        .then(data => {
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

            var chart = new ApexCharts(document.querySelector("#getTasksLineChart"), options);
            chart.render();
        })
        .catch(error => console.error('Error: ', error));
}