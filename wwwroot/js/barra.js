Highcharts.chart('barra', {
    chart: {
        type: 'column'
    },
    title: {
        text: 'Tempo de entrega médio por dia da semana'
    },
    subtitle: {
        text: 'Tempo médio de entrada e saída de pedidos por dia'
    },
    xAxis: {
        type: 'category',
        labels: {
            rotation: -45,
            style: {
                fontSize: '13px',
                fontFamily: 'Verdana, sans-serif'
            }
        }
    },
    yAxis: {
        min: 0,
        title: {
            text: 'Tempo (min)'
        }
    },
    legend: {
        enabled: false
    },
    tooltip: {
        pointFormat: 'Tempo: <b>{point.y:.1f} minutos</b>'
    },
    series: [{
        name: 'Dias da semana',
        data: [
            ['Segunda-feira', 0.0],
            ['Terça-feira', 0.0],
            ['Quarta-feira', 55],
            ['Quinta-feira', 0.0],
            ['Sexta-feira', 0.0],
            ['Sabado', 0.0],
            ['Domingo', 0.0]
        ],
        dataLabels: {
            enabled: true,
            rotation: -90,
            color: '#FFFFFF',
            align: 'right',
            format: '{point.y:.1f}', // one decimal
            y: 10, // 10 pixels down from the top
            style: {
                fontSize: '13px',
                fontFamily: 'Verdana, sans-serif'
            }
        }
    }]
});