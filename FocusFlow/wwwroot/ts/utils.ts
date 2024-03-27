export function formatTime(timeInSeconds: number): string {
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

export function getDurationInSeconds(): number {
    const durationString: string = document.getElementById("pomodoroScript").getAttribute("data-duration");
    let durationParts: string[] = durationString.split(':');
    let duration: number = (+durationParts[0]) * 60 * 60 + (+durationParts[1]) * 60 + (+durationParts[2]);
    return duration;
}