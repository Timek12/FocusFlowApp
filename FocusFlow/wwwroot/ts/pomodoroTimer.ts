import { Mode, Duration } from "./enums.js"
import { startTimer, stopTimer, resetTimer, finalizeSession } from "./timer.js";
import { formatTime, getDurationInSeconds } from "./utils.js";


let duration: number = getDurationInSeconds();
let timer: number = duration;
let display: HTMLElement = document.querySelector('#time');
let startTimerButton: HTMLButtonElement = document.querySelector('#startTimerButton') as HTMLButtonElement;
let stopTimerButton: HTMLButtonElement = document.querySelector('#stopTimerButton') as HTMLButtonElement;
let resetTimerButton: HTMLButtonElement = document.querySelector('#resetTimerButton') as HTMLButtonElement;
let pomodoroButton: HTMLButtonElement = document.querySelector('#pomodoroButton') as HTMLButtonElement;
let shortBreakButton: HTMLButtonElement = document.querySelector('#shortBreakButton') as HTMLButtonElement;
let longBreakButton: HTMLButtonElement = document.querySelector('#longBreakButton') as HTMLButtonElement;
let isPaused: boolean;
let PomodoroMode: Mode = Mode.Pomodoro;

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
    PomodoroMode = Mode.Pomodoro;
    timer = duration;
    display.textContent = formatTime(timer);
});

shortBreakButton.addEventListener('click', function () {
    PomodoroMode = Mode.ShortBreak;
    timer = Duration.ShortBreak; 
    display.textContent = formatTime(timer);
});

longBreakButton.addEventListener('click', function () {
    PomodoroMode = Mode.LongBreak;
    timer = Duration.LongBreak;
    display.textContent = formatTime(timer);
});

