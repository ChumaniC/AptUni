var savedTimer;

function setHiddenField() {
    savedTimer = document.getElementById("myTimer");
    document.getElementById("saved_timer").innerHTML = savedTimer.value;
}

if (sessionStorage.getItem("count_timer")) {
    var count_timer = sessionStorage.getItem("count_timer");
} else {
    var count_timer = 480;
}
var minutes = parseInt(count_timer / 60);
var seconds = parseInt(count_timer % 60);
function countDownTimer() {
    if (seconds < 10) {
        seconds = "0" + seconds;
    } if (minutes < 10) {
        minutes = "0" + minutes;
    }
    
    document.getElementById("lblTimer").innerHTML = minutes + ":" + seconds;
    var myMin = Math.floor(parseInt(sessionStorage.getItem("count_timer")) / 60);
    var mySec = parseInt(sessionStorage.getItem("count_timer")) % 60;
    var timeTaken = 480 - (myMin * 60 + mySec);
    var timeTakenMins = Math.floor(parseInt(timeTaken) / 60);
    var timeTakenSecs = parseInt(timeTaken) % 60;

    if (timeTakenSecs < 10) {
        timeTakenSecs = "0" + timeTakenSecs;
    } if (timeTakenMins < 10) {
        timeTakenMins = "0" + timeTakenMins;
    }

    savedTimer.value = timeTakenMins + ":" + timeTakenSecs;
    if (count_timer <= 0) {
        sessionStorage.clear("count_timer");
    } else {
        count_timer = count_timer - 1;
        minutes = parseInt(count_timer / 60);
        seconds = parseInt(count_timer % 60);
        sessionStorage.setItem("count_timer", count_timer);
        setTimeout("countDownTimer()", 1000);
    }

    if (minutes == 0 && seconds == 0) {
        window.location = "../presentationLayer/TestSelection.aspx";
    }
}
setTimeout("countDownTimer()", 1000);

function clearSessionStorage() {
    sessionStorage.clear("count_timer");
};
