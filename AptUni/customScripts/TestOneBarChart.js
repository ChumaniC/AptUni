
// setup 
const data = {
    labels: ['Jan','Feb', 'Mar', 'Apr', 'May'],
    datasets: [{
        label: 'Tirana',
        data: [_Tirana_Jan, _Tirana_Feb, _Tirana_Mar, _Tirana_Apr, _Tirana_May],
        backgroundColor: [
            'rgba(255, 26, 104, 0.2)',
        ],
        borderColor: [
            'rgba(255, 26, 104, 1)',
        ],
        borderWidth: 1
    },
        {
            label: 'Algiers',
            data: [_Algiers_Jan, _Algiers_Feb, _Algiers_Mar, _Algiers_Apr, _Algiers_May],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)',
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)',
            ],
            borderWidth: 1
        },
        {
            label: 'Stockholm',
            data: [_Stockholm_Jan, _Stockholm_Feb, _Stockholm_Mar, _Stockholm_Apr, _Stockholm_May],
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
    type: 'bar',
    data,
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
};

// render init block
const myChart = new Chart(
    document.getElementById('chart-bars'),
    config
);