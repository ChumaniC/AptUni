function TestFourNumerical() {
    // setup 
    const data = {
        labels: ['January', 'February', 'November', 'December'],
        datasets: [{
            label: 'Les Arcs',
            data: [_Les_Arcs_Jan, _Les_Arcs_Feb, _Les_Arcs_Nov, _Les_Arcs_Dec],
            backgroundColor: [
                'rgba(255, 26, 104, 0.2)',
            ],
            borderColor: [
                'rgba(255, 26, 104, 1)',
            ],
            borderWidth: 1
        },
        {
            label: 'Tignes',
            data: [_Tignes_Jan, _Tignes_Feb, _Tignes_Nov, _Tignes_Dec],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)',
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)',
            ],
            borderWidth: 1
        },
        {
            label: 'Whistler',
            data: [_Whistler_Jan, _Whistler_Feb, _Whistler_Nov, _Whistler_Dec],
            backgroundColor: [
                'rgba(255, 206, 86, 0.2)',
            ],
            borderColor: [
                'rgba(255, 206, 86, 1)',
            ],
            borderWidth: 1
            },
            {
                label: 'Val Thorens',
                data: [_Val_Thorens_Jan, _Val_Thorens_Feb, _Val_Thorens_Nov, _Val_Thorens_Dec],
                backgroundColor: [
                    'rgba(101, 55, 26, 0.2)',
                ],
                borderColor: [
                    'rgba(101, 55, 26, 1)',
                ],
                borderWidth: 1
            }]
    };

    // config 
    const config = {
        type: 'bar',
        data,
        options: {
            indexAxis: 'y',
            scales: {
                y: {
                    beginAtZero: true
                },
                x: {
                    title: {
                        display: true,
                        text: 'Snowfall (cm)'
                    }
                }
            }
        }
    };
    // render init block
    const myChart = new Chart(
        document.getElementById('chart-bars-hor'),
        config
    );
}