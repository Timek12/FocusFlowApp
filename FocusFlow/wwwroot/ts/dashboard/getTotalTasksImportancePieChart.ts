declare var ApexCharts: any;

export default function loadTotalTasksImportancePieChart() {
    $(".chart-spinner").show();

    fetch("/Dashboard/GetTasksImportancePieChartData", {
        method: 'GET',
    })
        .then(response => response.json())
        .then(data => {
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
            }

            var chart = new ApexCharts(document.querySelector("#totalTasksImportancePieChart"), options);
            chart.render();
            $(".chart-spinner").hide();
        })
        .catch(error => console.error('Error: ', error));
}