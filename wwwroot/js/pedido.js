function SalvarPedido() {

    //Data
    var data = $("#Data").val();

    //Cliente
    var cliente = $("#Cliente").val();

    //Valor
    var valor = $("#Valor").val();

    var tokenadr = $('form[action="/Pedidos/Create"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    //Gravar
    var url = "/Pedido/Create";

    $.ajax({
        url: url, 
        type: "POST", 
        datatype: "json", 
        headers: headersadr, 
        data: { Id: 0, Data: data, Cliente: cliente, Valor: valor, __RequestVerificationToken: token }
        , success: function (data) {
            if (data.Resultado > 0) {
                ListarItens(data.Resultado);
            }
        }
    });
}

function ListarItens(idPedido) {

    var url = "/Itens/ListarItens";

    $.ajax({
        url: url
        , type: "GET"
        , data: { id: idPedido }
        , datatype: "html"
        , success: function (data) {
            var divItens = $("#divItens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
    });

}