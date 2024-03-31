declare var ApexCharts: any;

export default function loadTotalTasksStatusPieChart() {
    $(".chart-spinner").show();

    fetch("/Dashboard/GetTasksStatusPieChartData", {
        method: 'GET',
    })
        .then(response => response.json())
        .then(data => {
            var options = {
                chart: {
                    height: 345,
                    type: 'pie'
                },
                series: data.series,
                labels: data.labels,
                colors: ['#32CD32', '#B0E0E6'],
                legend: {
                    position: 'bottom',
                    horizontalAlign: 'center',
                    labels: {
                        colors: "#fff",
                        userSeriesColors: true
                    },
                },
            }

            var chart = new ApexCharts(document.querySelector("#totalTasksStatusPieChart"), options);
            chart.render();
            $(".chart-spinner").hide();
        })
        .catch(error => console.error('Error: ', error));
}