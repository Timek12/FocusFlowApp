import { Mode, Duration } from "./enums.js";
import { formatTime, getDurationInSeconds } from "./utils.js";

let duration: number = getDurationInSeconds();
let timer: number = duration;
let display: HTMLElement = document.querySelector('#time');
let startTimerButton: HTMLButtonElement = document.querySelector('#startTimerButton') as HTMLButtonElement;
let timerInterval: number;
let isPaused: boolean;
let PomodoroMode: Mode = Mode.Pomodoro;

export async function startTimer(duration: number, display: HTMLElement): Promise<void> {
    clearTimeout(timerInterval);

    if (timer === duration && PomodoroMode == Mode.Pomodoro) {
        let startTime = new Date();

        fetch('/Pomodoro/StartTimer', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(startTime.toISOString())
        })
            .then(response => response.json())
            .then(data => { })
            .catch(error => {
                console.error("An error occurred:", error);
            })
    }

    const intervalFunc = async () => {
        display.textContent = formatTime(timer);

        if (!isPaused) {
            if (--timer < 0) {
                if (PomodoroMode == Mode.Pomodoro) {
                    await resetTimer();
                    finalizeSession();
                }
                startTimerButton.disabled = false;
            }
            else {
                timerInterval = setTimeout(intervalFunc, 1000);
            }
        }
    }

    timerInterval = setTimeout(intervalFunc, 1000);
};

export function stopTimer(): Promise<void> {
    if (PomodoroMode == Mode.Pomodoro) {
        let stopTime = new Date();

        return fetch('/Pomodoro/StopTimer', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(stopTime.toISOString())
        })
            .then(response => response.json())
            .then(data => { })
            .catch(error => {
                console.error("An error occurred:", error)
            })
            .finally(() => {
                clearInterval(timerInterval);
            })
    }
    else {
        clearInterval(timerInterval);
    }
}

export async function resetTimer(): Promise<void> {
    await stopTimer();
    switch (PomodoroMode) {
        case Mode.Pomodoro:
            timer = duration;
            break;
        case Mode.ShortBreak:
            timer = Duration.ShortBreak;
            break;
        case Mode.LongBreak:
            timer = Duration.LongBreak;
            break;
    }

    display.textContent = formatTime(timer);
}



export function finalizeSession(): Promise<void> {
    return fetch('/Pomodoro/FinalizeSession', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
    })
        .then(response => response.json())
        .then(data => { })
        .catch(error => {
            console.error("An error occurred:", error);
        });
}