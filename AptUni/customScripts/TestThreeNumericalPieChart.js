function TestThreeNumerical() {
    var styleEl = document.createElement('style');
    styleEl.innerHTML = '.chart {width: 23rem; padding: 20px;border - radius: 20px;background: white;}';
    document.head.appendChild(styleEl);
    let canvas = document.getElementById("myChart");
    canvas.removeAttribute("hidden");

    // setup 
    const data = {
        labels: ['Balcom plc', 'Antlyn plc', 'Graaf inc', 'Trade ltd', 'Royer inc'],
        datasets: [{
            label: '2021 Total = R1.45m',
            data: [_Balcom_plc_2021, _Antlyn_plc_2021, _Graaf_inc_2021, _Trade_ltd_2021, _Royer_inc_2021],
            backgroundColor: [
                'rgba(255, 26, 104, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(0, 0, 0, 0.2)'
            ],
            borderColor: [
                'rgba(255, 26, 104, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)',
                'rgba(0, 0, 0, 1)'
            ],
            borderWidth: 1
        }]
    };

    // config 
    const config = {
        type: 'pie',
        data,
        options: {
            scales: {
            },
            plugins: {
                title: {
                    display: true,
                    text: '2021 Total = R1.45m'
                }
            }
        }
    };

    // render init block
    const myChart = new Chart(
        document.getElementById('chart-pie'),
        config
    );

      // setup 
    const data2 = {
        labels: ['Balcom plc', 'Antlyn plc', 'Graaf inc', 'Trade ltd', 'Royer inc'],
        datasets: [{
            data: [_Balcom_plc_2022, _Antlyn_plc_2022, _Graaf_inc_2022, _Trade_ltd_2022, _Royer_inc_2022],
            backgroundColor: [
                'rgba(255, 26, 104, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(0, 0, 0, 0.2)'
            ],
            borderColor: [
                'rgba(255, 26, 104, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)',
                'rgba(0, 0, 0, 1)'
            ],
            borderWidth: 1
        }]
    };

    // config 
    const config2 = {
        type: 'pie',
        data: data2,
        options: {
            scales: {
            },
            plugins: {
                title: {
                    display: true,
                    text: '2022 Total = R2m'
                }
            }
        }
    };

    // render init block
    const myChart2 = new Chart(
        document.getElementById('myChart'),
        config2
    );
}
