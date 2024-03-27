import { Duration } from "./enums.js";
import { startTimer, stopTimer, resetTimer } from "./timer.js";
import { formatTime, getDurationInSeconds } from "./utils.js";
var duration = getDurationInSeconds();
var timer = duration;
var display = document.querySelector('#time');
var startTimerButton = document.querySelector('#startTimerButton');
var stopTimerButton = document.querySelector('#stopTimerButton');
var resetTimerButton = document.querySelector('#resetTimerButton');
var pomodoroButton = document.querySelector('#pomodoroButton');
var shortBreakButton = document.querySelector('#shortBreakButton');
var longBreakButton = document.querySelector('#longBreakButton');
var isPaused;
var PomodoroMode = 0 /* Mode.Pomodoro */;
startTimerButton.addEventListener('click', function () {
    isPaused = false;
    startTimer(duration, display);
    this.disabled = true;
});
stopTimerButton.addEventListener('click', function () {
    isPaused = true;
    stopTimer();
    startTimerButton.disabled = false;
});
resetTimerButton.addEventListener('click', function () {
    resetTimer();
    startTimerButton.disabled = false;
});
pomodoroButton.addEventListener('click', function () {
    PomodoroMode = 0 /* Mode.Pomodoro */;
    timer = duration;
    display.textContent = formatTime(timer);
});
shortBreakButton.addEventListener('click', function () {
    PomodoroMode = 1 /* Mode.ShortBreak */;
    timer = Duration.ShortBreak;
    display.textContent = formatTime(timer);
});
longBreakButton.addEventListener('click', function () {
    PomodoroMode = 2 /* Mode.LongBreak */;
    timer = Duration.LongBreak;
    display.textContent = formatTime(timer);
});
//# sourceMappingURL=pomodoroTimer.js.map