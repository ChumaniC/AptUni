var updatedTime = 0;

function startCountdown(timeLeft) {
    var interval = setInterval(countdown, 1000);
    update();

    function countdown() {
        if (--timeLeft > 0) {
            update();
        }
        else {
            clearInterval(interval);
            update();
            completed();
        }
    }

    function update() {
        hours = Math.floor(timeLeft / 3600);
        minutes = Math.floor(timeLeft % 3600 / 60);
        seconds = timeLeft % 60;
        
            if (seconds < 10) {
                document.getElementById('lblTimer').innerHTML = minutes + ':0' + seconds;
            }
            else {
                document.getElementById('lblTimer').innerHTML = minutes + ':' + seconds;
            }
        setCookie("myTime", minutes * 60 + seconds, 1);
    }

    function completed() {
        // Do whatever you to do when the timer runs out...
        // Redirect to result page
    }
}

function setCookie(name, value, daysToLive) {
    const date = new Date();
    date.setTime(date.getTime() + (daysToLive * 24 * 60 * 60 * 1000));
    let expires = "expires=" + date.toUTCString();
    document.cookie = `${name}=${value}; ${expires}; path=/`
}
function deleteCookie(name) {
    setCookie(name, null, null);
}

function getCookie(name) {
    const cDecoded = decodeURIComponent(document.cookie);
    const cArray = cDecoded.split("; ");
    let result = null;

    cArray.forEach(element => {
        if (element.indexOf(name) == 0) {
            result = element.substring(name.length + 1)
        }
    })
    return result;
}

function SetHiddenVariable() {
    var myMin = getCookie("myTime");
    var mySec = getCookie("mySeconds");
    __doPostBack('callPostBack', myMin);

}