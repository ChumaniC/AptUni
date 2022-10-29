function TestOneLineChart() {

    var ctx = document.getElementById("chart-line").getContext("2d");

    new Chart(ctx, {
        type: "line",
        data: {
            labels: ["2018", "2019", "2020", "2021", "2022"],
            datasets: [{
                tension: 0,
                borderWidth: 0,
                pointRadius: 5,
                pointBackgroundColor: "blue",
                pointBorderColor: "transparent",
                borderColor: "blue",
                borderWidth: 4,
                backgroundColor: "transparent",
                fill: true,
                data: [_lineA_2018, _lineA_2019, _lineA_2020, _lineA_2021, _lineA_2022],
                maxBarThickness: 6

            },
            {
                tension: 0,
                borderWidth: 0,
                pointRadius: 5,
                pointBackgroundColor: "orange",
                pointBorderColor: "transparent",
                borderColor: "orange",
                borderWidth: 4,
                backgroundColor: "transparent",
                fill: true,
                data: [_lineB_2018, _lineB_2019, _lineB_2020, _lineB_2021, _lineB_2022],
                maxBarThickness: 6

            },
            {
                tension: 0,
                borderWidth: 0,
                pointRadius: 5,
                pointBackgroundColor: "violet",
                pointBorderColor: "transparent",
                borderColor: "violet",
                borderWidth: 4,
                backgroundColor: "transparent",
                fill: true,
                data: [_lineC_2018, _lineC_2019, _lineC_2020, _lineC_2021, _lineC_2022],
                maxBarThickness: 6

            }
            ],
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    display: false,
                }
            },
            interaction: {
                intersect: false,
                mode: 'index',
            },
            scales: {
                y: {
                    grid: {
                        drawBorder: true,
                        display: true,
                        drawOnChartArea: true,
                        drawTicks: false,
                        borderDash: [1, 1],
                        color: 'black'
                    },
                    ticks: {
                        display: true,
                        padding: 10,
                        color: 'black',
                        font: {
                            size: 14,
                            weight: 300,
                            family: "Roboto",
                            style: 'normal',
                            lineHeight: 2
                        },
                    }
                },
                x: {
                    grid: {
                        drawBorder: true,
                        display: true,
                        drawOnChartArea: true,
                        drawTicks: false,
                        borderDash: [1, 1],
                        color: 'black'
                    },
                    ticks: {
                        display: true,
                        color: 'black',
                        padding: 10,
                        font: {
                            size: 14,
                            weight: 300,
                            family: "Roboto",
                            style: 'normal',
                            lineHeight: 2
                        },
                    }
                },
            },
        },
    });
}