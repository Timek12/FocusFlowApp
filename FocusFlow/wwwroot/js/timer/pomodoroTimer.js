import { Duration } from "../enums.js";
import { startTimer, stopTimer, resetTimer, setTimer, setIsPaused } from "./timer.js";
import { formatTime, getDurationInSeconds } from "../utils.js";
var pomodoroTimer = getDurationInSeconds();
var shortBreakTimer = Duration.ShortBreak;
var longBreakTimer = Duration.LongBreak;
var timer = pomodoroTimer;
var display = document.querySelector('#time');
var startTimerButton = document.querySelector('#startTimerButton');
var stopTimerButton = document.querySelector('#stopTimerButton');
var resetTimerButton = document.querySelector('#resetTimerButton');
var pomodoroButton = document.querySelector('#pomodoroButton');
var shortBreakButton = document.querySelector('#shortBreakButton');
var longBreakButton = document.querySelector('#longBreakButton');
var pomodoroMode = 0 /* Mode.Pomodoro */;
startTimerButton.addEventListener('click', function () {
    setIsPaused(false);
    startTimer(display);
    this.disabled = true;
});
stopTimerButton.addEventListener('click', function () {
    setIsPaused(true);
    stopTimer();
    startTimerButton.disabled = false;
});
resetTimerButton.addEventListener('click', function () {
    switch (pomodoroMode) {
        case 0 /* Mode.Pomodoro */:
            timer = pomodoroTimer;
            break;
        case 1 /* Mode.ShortBreak */:
            timer = shortBreakTimer;
            break;
        case 2 /* Mode.LongBreak */:
            timer = longBreakTimer;
            break;
    }
    resetTimer(timer);
    startTimerButton.disabled = false;
});
pomodoroButton.addEventListener('click', function () {
    setIsPaused(true);
    pomodoroMode = 0 /* Mode.Pomodoro */;
    timer = pomodoroTimer;
    setTimer(timer);
    display.textContent = formatTime(timer);
    startTimerButton.disabled = false;
});
shortBreakButton.addEventListener('click', function () {
    setIsPaused(true);
    pomodoroMode = 1 /* Mode.ShortBreak */;
    timer = shortBreakTimer;
    setTimer(timer);
    display.textContent = formatTime(timer);
    startTimerButton.disabled = false;
});
longBreakButton.addEventListener('click', function () {
    setIsPaused(true);
    pomodoroMode = 2 /* Mode.LongBreak */;
    timer = longBreakTimer;
    setTimer(timer);
    display.textContent = formatTime(timer);
    startTimerButton.disabled = false;
});
//# sourceMappingURL=pomodoroTimer.js.map