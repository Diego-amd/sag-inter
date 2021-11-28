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