﻿
function showImage() {
    var myDivChart = document.getElementById("myCharts");
    if (myDivChart.style.display !== "none") {
        myDivChart.style.display = "none";
    }
    else {
        myDivChart.style.display = "block";
    }

    var myDivCase = document.getElementById("myImage");
    myDivCase.removeAttribute("hidden");


};