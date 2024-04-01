import { Duration } from './enums.js';
export function formatTime(timeInSeconds) {
    var hours = Math.floor(timeInSeconds / 3600);
    var minutes = Math.floor(timeInSeconds / 60);
    var seconds = Math.floor(timeInSeconds % 60);
    var hoursFormat = hours < 10 ? "0" + hours : hours.toString();
    var minutesFormat = minutes < 10 ? "0" + minutes : minutes.toString();
    var secondsFormat = seconds < 10 ? "0" + seconds : seconds.toString();
    if (timeInSeconds >= 3600) {
        return hoursFormat + ":" + minutesFormat + ":" + secondsFormat;
    }
    else {
        return minutesFormat + ":" + secondsFormat;
    }
}
export function getDurationInSeconds() {
    var durationString = document.getElementById("pomodoroScript").getAttribute("data-duration");
    var durationParts = durationString.split(':');
    var duration = (+durationParts[0]) * 60 * 60 + (+durationParts[1]) * 60 + (+durationParts[2]);
    return duration;
}
export function getCurrentDurationInSeconds(pomodoroMode) {
    var newTimer;
    switch (pomodoroMode) {
        case 0 /* Mode.Pomodoro */:
            newTimer = getDurationInSeconds();
            break;
        case 1 /* Mode.ShortBreak */:
            newTimer = Duration.ShortBreak;
            break;
        case 2 /* Mode.LongBreak */:
            newTimer = Duration.LongBreak;
            break;
    }
    return newTimer;
}
//# sourceMappingURL=utils.js.map