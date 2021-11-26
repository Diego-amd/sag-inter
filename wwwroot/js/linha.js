// builda o gráfico de linha com vendas mensais
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
        data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
    }]
});