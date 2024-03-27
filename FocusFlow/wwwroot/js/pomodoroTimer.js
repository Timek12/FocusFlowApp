let durationString = document.getElementById("pomodoroScript").getAttribute("data-duration");
let durationParts = durationString.split(':');
let duration = (+durationParts[0]) * 60 * 60 + (+durationParts[1]) * 60 + (+durationParts[2]);
let timer = duration;
let display = document.querySelector('#time');
let startTimerButton = document.querySelector('#startTimerButton');
let stopTimerButton = document.querySelector('#stopTimerButton');
let resetTimerButton = document.querySelector('#resetTimerButton');
let timerInterval;

startTimerButton.addEventListener('click', function () {
    startTimer(duration, display);
    this.disabled = true;
});

stopTimerButton.addEventListener('click', function () {
    stopTimer();
    startTimerButton.disabled = false;
});

resetTimerButton.addEventListener('click', function () {
    resetTimer();
    startTimerButton.disabled = false;
});

function startTimer(duration, display) {
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

    let hours, minutes, seconds;
    timerInterval = setInterval(function () {
        display.textContent = formatTime(timer);

        if (--timer < 0) {
            // ajax call to server
            stopTimer();
        }
    }, 1000);
}

function stopTimer() {
    let stopTime = new Date();

    fetch('/Pomodoro/StopTimer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(stopTime.toISOString())
    })
        .then(response => response.json())
        .then(data => { })
        .catch(error => { })

    clearInterval(timerInterval);
}

function resetTimer() {
    timer = duration;
    stopTimer();
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