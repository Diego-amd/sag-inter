Highcharts.chart('linha', {
    chart: {
        type: 'line'
    },
    title: {
        text: 'Vendas mensais'
    },
    subtitle: {
        text: 'Receita mensal por meio dos pedidos'
    },
    xAxis: {
        categories: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
    },
    yAxis: {
        title: {
            text: 'Valores'
        }
    },
    plotOptions: {
        line: {
            dataLabels: {
                enabled: true
            },
            enableMouseTracking: false
        }
    },
    series: [{
        name: 'Linha',
        data: [0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,0.0, 0.0, 216.1, 621.61]
    }]
});