function TestOneNumerical() {
    let table = document.getElementById("myTable");
    table.removeAttribute("hidden");
    // setup 
    const data = {
        labels: ["2018", "2019", "2020", "2021", "2022"],
        datasets: [{
            label: 'Grade A',
            data: [_lineA_2018, _lineA_2019, _lineA_2020, _lineA_2021, _lineA_2022],
            backgroundColor: [
                'rgba(255, 26, 104, 0.2)',
            ],
            borderColor: [
                'rgba(255, 26, 104, 1)',
            ],
            borderWidth: 1
        },
        {
            label: 'Grade B',
            data: [_lineB_2018, _lineB_2019, _lineB_2020, _lineB_2021, _lineB_2022],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)',
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)',
            ],
            borderWidth: 1
        },
        {
            label: 'Grade C',
            data: [_lineC_2018, _lineC_2019, _lineC_2020, _lineC_2021, _lineC_2022],
            backgroundColor: [
                'rgba(255, 206, 86, 0.2)',
            ],
            borderColor: [
                'rgba(255, 206, 86, 1)',
            ],
            borderWidth: 1
        }]
    };

    // config 
    const config = {
        type: 'line',
        data,
        options: {
            scales: {
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'Wireless Headphones (Thousands)'
                    }
                }
            }
        }
    };

    // render init block
    const myChart = new Chart(
        document.getElementById('chart-line'),
        config
    );

}