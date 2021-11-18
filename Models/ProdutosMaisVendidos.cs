using System.ComponentModel.DataAnnotations;

namespace sag.Models
{
    public class ProdutosMaisVendidos
    {
        #region Foreign Key
        public Pedidos Pedidos { get; set; }
        public Produtos Produtos { get; set; }
        public ItensPedidos ItensPedidos { get; set; }
        #endregion
    }
}