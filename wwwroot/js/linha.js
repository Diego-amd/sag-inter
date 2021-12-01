$(document).ready(function () {
    //Peticion a API
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: 'https://localhost:5001/Relatorios/DataLinha',
        error: function () {
            alert("Ocorreu um erro ao constar os dados");
        },
        success: function (data) {
            GraficaBarras(data);
            console.log(data);
        }
    })
});
// builda o gráfico de linha com vendas mensais
function GraficaBarras(data) {
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
}