let durationString = document.getElementById("pomodoroScript").getAttribute("data-duration");
let durationParts = durationString.split(':');
let duration = (+durationParts[0]) * 60 * 60 + (+durationParts[1]) * 60 + (+durationParts[2]);
let timer = duration;
let display = document.querySelector('#time');
let startTimerButton = document.querySelector('#startTimerButton');
let stopTimerButton = document.querySelector('#stopTimerButton');
let resetTimerButton = document.querySelector('#resetTimerButton');
let timerInterval;
let isPaused;

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

async function startTimer(duration, display) {
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
            .catch(error => { })
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

function stopTimer() {
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
        .catch(error => { })
        .finally(() => {
            clearInterval(timerInterval);

        })
}

async function resetTimer() {
    await stopTimer();
    timer = duration;
    display.textContent = formatTime(timer);
}

function formatTime(timeInSeconds) {
    let hours = parseInt(timeInSeconds / 3600, 10);
    let minutes = parseInt(timeInSeconds / 60, 10);
    let seconds = parseInt(timeInSeconds % 60, 10);

    hours = hours < 10 ? "0" + hours : hours;
    minutes = minutes < 10 ? "0" + minutes : minutes;
    seconds = seconds < 10 ? "0" + seconds : seconds;

    if (timeInSeconds >= 3600) {
        return hours + ":" + minutes + ":" + seconds;
    }
    else {
        return minutes + ":" + seconds;
    }
}

function finalizeSession() {
    fetch('/Pomodoro/FinalizeSession', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
    })
        .then(response => response.json())
        .then(data => { })
        .catch(error => { })
}