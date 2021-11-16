using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace sag.Models
{
    public class Pedidos
    {
        public int IdPedido { get; set; }
        public int CodUsuario { get; set; }
        public string NomeCliente { get; set; }
        public string TelCliente { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSaida { get; set; }
        public string DataEntrada { get; set; }
        public int Status { get; set; }
        public int TipoPedido { get; set; }

        public string TextoStatus => Status == 1 ? "Finalizado" : "Andamento";
        public string TextoTipoPedido => TipoPedido == 1 ? "Online" : "Presencial";

        public List<ItensPedidos> Itens { get; set; } = new List<ItensPedidos>();

        public decimal Total
        {
            get
            {
                return Itens.Sum(i => i.ValorTotal);
            }
        }

        #region Foreign Key
        public Funcionarios Funcionario { get; set; }
        #endregion
    }
}

/*
-- tipo_pedido = 0 => presencial
-- tipo_pedido = 1 => online
-- status = 0 => andamento
-- status = 1 => finalizado
CREATE TABLE tb_pedidos(
	id_pedido		int primary key identity not null,
	cod_usuario		int references tb_funcionarios not null,
	nome_cliente	varchar(max) not null,
	tel_cliente		varchar(max) not null,
	hora_entrada	time not null,
	hora_saida		time not null,
	data_entrada	date not null,
	status			int not null,
	tipo_pedido		int not null,
	check(tipo_pedido in (0,1)),
	check(status in (0,1))
)
go*/
