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
});