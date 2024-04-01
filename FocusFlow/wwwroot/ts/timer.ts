import { Mode, Duration } from "./enums.js";
import { formatTime, getDurationInSeconds } from "./utils.js";

let duration: number = getDurationInSeconds();
let timer: number = duration;
let display: HTMLElement = document.querySelector('#time');
let startTimerButton: HTMLButtonElement = document.querySelector('#startTimerButton') as HTMLButtonElement;
let timerInterval: number;
let pomodoroMode: Mode = Mode.Pomodoro;
let isPaused: boolean;

export async function startTimer(display: HTMLElement): Promise<void> {
    clearTimeout(timerInterval);

    if (timer === duration && pomodoroMode == Mode.Pomodoro) {
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
                let newTimer;
                switch (pomodoroMode) {
                    case Mode.Pomodoro:
                        newTimer = duration;
                        break;
                    case Mode.ShortBreak:
                        newTimer = Duration.ShortBreak;
                        break;
                    case Mode.LongBreak:
                        newTimer = Duration.LongBreak;
                        break;
                }

                await resetTimer(newTimer);

                if (pomodoroMode == Mode.Pomodoro) {
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

export async function stopTimer(): Promise<void> {
    if (pomodoroMode == Mode.Pomodoro) {
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

export async function resetTimer(newTimer: number): Promise<void> {
    await stopTimer();
    timer = newTimer;
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

export function setTimer(newTimer: number) {
    timer = newTimer;
}

export function setIsPaused(newIsPaused: boolean) {
    isPaused = newIsPaused;
}