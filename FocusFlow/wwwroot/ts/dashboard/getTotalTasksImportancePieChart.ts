declare var ApexCharts: any;

export default function loadTotalTasksImportancePieChart() {
    fetch("/Dashboard/GetTasksImportancePieChartData", {
        method: 'GET',
    })
        .then(response => response.json())
        .then(data => {
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
            }

            var chart = new ApexCharts(document.querySelector("#totalTasksImportancePieChart"), options);
            chart.render();
        })
        .catch(error => console.error('Error: ', error));
}