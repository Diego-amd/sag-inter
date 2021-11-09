namespace sag.Models
{
    public class Produtos
    {
        public int Id_produto { get; set; }
        public int Cod_Usuario { get; set; }
        public string Categoria { get; set; }
        public float Valor { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Estado { get; set; }
    }
}