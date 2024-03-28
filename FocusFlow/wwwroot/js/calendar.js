document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    console.log(calendarEl); // Should not be null
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        firstDay: 1 // Monday
    });
    calendar.render();
});
//# sourceMappingURL=calendar.js.map