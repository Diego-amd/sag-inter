namespace sag.Models
{
    public class ItensPedidos
    {
        public int CodPedido { get; set; }
        public int CodProduto { get; set; }
        public int Qtde { get; set; }
        public decimal ValorUnitario { get; set; }
        // public decimal ValorTotal
        // {
        //     get
        //     {
        //         return Qtde * ValorUnitario;
        //     }
        // }
        public decimal ValorTotal { get; set; }

        #region Foreign Key
        public Pedidos Pedido { get; set; }
        public Produtos Produto { get; set; }
        #endregion
    }
}