var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
import { Duration } from "./enums.js";
import { formatTime, getDurationInSeconds } from "./utils.js";
var duration = getDurationInSeconds();
var timer = duration;
var display = document.querySelector('#time');
var startTimerButton = document.querySelector('#startTimerButton');
var timerInterval;
var pomodoroMode = 0 /* Mode.Pomodoro */;
var isPaused;
export function startTimer(display) {
    return __awaiter(this, void 0, void 0, function () {
        var startTime, intervalFunc;
        var _this = this;
        return __generator(this, function (_a) {
            clearTimeout(timerInterval);
            if (timer === duration && pomodoroMode == 0 /* Mode.Pomodoro */) {
                startTime = new Date();
                fetch('/Pomodoro/StartTimer', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(startTime.toISOString())
                })
                    .then(function (response) { return response.json(); })
                    .then(function (data) { })
                    .catch(function (error) {
                    console.error("An error occurred:", error);
                });
            }
            intervalFunc = function () { return __awaiter(_this, void 0, void 0, function () {
                var newTimer;
                return __generator(this, function (_a) {
                    switch (_a.label) {
                        case 0:
                            display.textContent = formatTime(timer);
                            if (!!isPaused) return [3 /*break*/, 3];
                            if (!(--timer < 0)) return [3 /*break*/, 2];
                            newTimer = void 0;
                            switch (pomodoroMode) {
                                case 0 /* Mode.Pomodoro */:
                                    newTimer = duration;
                                    break;
                                case 1 /* Mode.ShortBreak */:
                                    newTimer = Duration.ShortBreak;
                                    break;
                                case 2 /* Mode.LongBreak */:
                                    newTimer = Duration.LongBreak;
                                    break;
                            }
                            return [4 /*yield*/, resetTimer(newTimer)];
                        case 1:
                            _a.sent();
                            if (pomodoroMode == 0 /* Mode.Pomodoro */) {
                                finalizeSession();
                            }
                            startTimerButton.disabled = false;
                            return [3 /*break*/, 3];
                        case 2:
                            timerInterval = setTimeout(intervalFunc, 1000);
                            _a.label = 3;
                        case 3: return [2 /*return*/];
                    }
                });
            }); };
            timerInterval = setTimeout(intervalFunc, 1000);
            return [2 /*return*/];
        });
    });
}
;
export function stopTimer() {
    return __awaiter(this, void 0, void 0, function () {
        var stopTime;
        return __generator(this, function (_a) {
            if (pomodoroMode == 0 /* Mode.Pomodoro */) {
                stopTime = new Date();
                return [2 /*return*/, fetch('/Pomodoro/StopTimer', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(stopTime.toISOString())
                    })
                        .then(function (response) { return response.json(); })
                        .then(function (data) { })
                        .catch(function (error) {
                        console.error("An error occurred:", error);
                    })
                        .finally(function () {
                        clearInterval(timerInterval);
                    })];
            }
            else {
                clearInterval(timerInterval);
            }
            return [2 /*return*/];
        });
    });
}
export function resetTimer(newTimer) {
    return __awaiter(this, void 0, void 0, function () {
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0: return [4 /*yield*/, stopTimer()];
                case 1:
                    _a.sent();
                    timer = newTimer;
                    display.textContent = formatTime(timer);
                    return [2 /*return*/];
            }
        });
    });
}
export function finalizeSession() {
    return fetch('/Pomodoro/FinalizeSession', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
    })
        .then(function (response) { return response.json(); })
        .then(function (data) { })
        .catch(function (error) {
        console.error("An error occurred:", error);
    });
}
export function setTimer(newTimer) {
    timer = newTimer;
}
export function setIsPaused(newIsPaused) {
    isPaused = newIsPaused;
}
//# sourceMappingURL=timer.js.map