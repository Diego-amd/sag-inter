using System.ComponentModel.DataAnnotations;

namespace sag.Models
{
    public class ProdutosMaisVendidos
    {
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Qtde { get; set; }
        public decimal Media { get; set; }

        #region Foreign Key
        public Pedidos Pedidos { get; set; }
        public Produtos Produtos { get; set; }
        public ItensPedidos ItensPedidos { get; set; }
        #endregion
    }
}