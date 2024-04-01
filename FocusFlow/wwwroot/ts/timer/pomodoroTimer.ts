import { Mode, Duration } from "../enums.js"
import { startTimer, stopTimer, resetTimer, setTimer, setIsPaused } from "./timer.js";
import { formatTime, getDurationInSeconds, getCurrentDurationInSeconds } from "../utils.js";

let pomodoroTimer: number = getDurationInSeconds();
let shortBreakTimer: number = Duration.ShortBreak;
let longBreakTimer: number = Duration.LongBreak;
let timer: number = pomodoroTimer;
let display: HTMLElement = document.querySelector('#time');
let startTimerButton: HTMLButtonElement = document.querySelector('#startTimerButton') as HTMLButtonElement;
let stopTimerButton: HTMLButtonElement = document.querySelector('#stopTimerButton') as HTMLButtonElement;
let resetTimerButton: HTMLButtonElement = document.querySelector('#resetTimerButton') as HTMLButtonElement;
let pomodoroButton: HTMLButtonElement = document.querySelector('#pomodoroButton') as HTMLButtonElement;
let shortBreakButton: HTMLButtonElement = document.querySelector('#shortBreakButton') as HTMLButtonElement;
let longBreakButton: HTMLButtonElement = document.querySelector('#longBreakButton') as HTMLButtonElement;
let pomodoroMode: Mode = Mode.Pomodoro;

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
    timer = getCurrentDurationInSeconds(pomodoroMode);

    resetTimer(timer);
    startTimerButton.disabled = false;
});

pomodoroButton.addEventListener('click', function () {
    setIsPaused(true);
    pomodoroMode = Mode.Pomodoro;
    timer = pomodoroTimer;
    setTimer(timer);
    display.textContent = formatTime(timer);
    startTimerButton.disabled = false;
});

shortBreakButton.addEventListener('click', function () {
    setIsPaused(true);
    pomodoroMode = Mode.ShortBreak;
    timer = shortBreakTimer; 
    setTimer(timer);
    display.textContent = formatTime(timer);
    startTimerButton.disabled = false;
});

longBreakButton.addEventListener('click', function () {
    setIsPaused(true);
    pomodoroMode = Mode.LongBreak;
    timer = longBreakTimer;
    setTimer(timer);
    display.textContent = formatTime(timer);
    startTimerButton.disabled = false;
});

