declare var FullCalendar: any;
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
        .then(response => response.json())
        .then(tasks => {
            for (let task of tasks) {
                calendar.addEvent({
                    title: task.Name,
                    start: task.StartDate,
                    end: task.EndDate
                });
            }
        });
});