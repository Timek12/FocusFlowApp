var ApexCharts: any;
$(function () {
    loadTotalTasksStatusPieChartData();
});

function loadTotalTasksStatusPieChartData() {
    fetch("/Dashboard/GetTasksStatusPieChartData", {
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
                colors: ['#32CD32', '#B0E0E6'],
                title: {
                    text: 'Total Tasks',
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

            var chart = new ApexCharts(document.querySelector("#totalTasksPieChart"), options);
            chart.render();
        })
        .catch(error => console.error('Error: ', error));
}