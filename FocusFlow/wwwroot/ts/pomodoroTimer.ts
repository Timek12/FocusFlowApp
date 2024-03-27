﻿const durationString: string = document.getElementById("pomodoroScript").getAttribute("data-duration");
let durationParts: string[] = durationString.split(':');
let duration: number = (+durationParts[0]) * 60 * 60 + (+durationParts[1]) * 60 + (+durationParts[2]);
let timer: number = duration;
let display: HTMLElement = document.querySelector('#time');
let startTimerButton: HTMLButtonElement = document.querySelector('#startTimerButton') as HTMLButtonElement;
let stopTimerButton: HTMLButtonElement = document.querySelector('#stopTimerButton') as HTMLButtonElement;
let resetTimerButton: HTMLButtonElement = document.querySelector('#resetTimerButton') as HTMLButtonElement;
let timerInterval: number;
let isPaused: boolean;

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

async function startTimer(duration: number, display: HTMLElement): Promise<void> {
    clearTimeout(timerInterval);

    if (timer === duration) {
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
                await resetTimer();
                finalizeSession();
                startTimerButton.disabled = false;
            }
            else {
                timerInterval = setTimeout(intervalFunc, 1000);
            }
        }
    }

    timerInterval = setTimeout(intervalFunc, 1000);
};

function stopTimer(): Promise<void> {
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

async function resetTimer(): Promise<void> {
    await stopTimer();
    timer = duration;
    display.textContent = formatTime(timer);
}

function formatTime(timeInSeconds: number): string {
    let hours: number = Math.floor(timeInSeconds / 3600);
    let minutes: number = Math.floor(timeInSeconds / 60);
    let seconds: number = Math.floor(timeInSeconds % 60);

    let hoursFormat: string = hours < 10 ? "0" + hours : hours.toString();
    let minutesFormat: string = minutes < 10 ? "0" + minutes : minutes.toString();
    let secondsFormat: string = seconds < 10 ? "0" + seconds : seconds.toString();

    if (timeInSeconds >= 3600) {
        return hoursFormat + ":" + minutesFormat + ":" + secondsFormat;
    }
    else {
        return minutesFormat + ":" + secondsFormat;
    }
}

function finalizeSession(): Promise<void> {
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