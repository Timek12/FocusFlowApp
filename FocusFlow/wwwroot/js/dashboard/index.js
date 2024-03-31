import loadTotalTasksStatusPieChart from '../../js/dashboard/getTotalTasksStatusPieChart.js';
import loadTotalTasksImportancePieChart from '../../js/dashboard/getTotalTasksImportancePieChart.js';
import loadTasksLineChart from '../../js/dashboard/getTasksLineChart.js';
import loadSessionsLineChart from '../../js/dashboard/getSessionsLineChart.js';
$(function () {
    loadSessionsLineChart();
    loadTasksLineChart();
    loadTotalTasksImportancePieChart();
    loadTotalTasksStatusPieChart();
});
export { loadSessionsLineChart, loadTasksLineChart, loadTotalTasksImportancePieChart, loadTotalTasksStatusPieChart };
//# sourceMappingURL=index.js.map