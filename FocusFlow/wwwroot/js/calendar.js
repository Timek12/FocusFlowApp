document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        themeSystem: 'bootstrap5',
        initialView: 'dayGridMonth',
        firstDay: 1, // Monday
        fixedWeekCount: false,
        height: '700px',
    });
    calendar.render();
    fetch('/Task/GetAllTasks')
        .then(function (response) { return response.json(); })
        .then(function (tasks) {
        for (var _i = 0, tasks_1 = tasks; _i < tasks_1.length; _i++) {
            var task = tasks_1[_i];
            calendar.addEvent({
                title: task.Name,
                start: task.StartDate,
                end: task.EndDate
            });
            console.log(task);
        }
    });
});
//# sourceMappingURL=calendar.js.map