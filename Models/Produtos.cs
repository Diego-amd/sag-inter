namespace sag.Models
{
    public class Produtos
    {
        public int Id_produto { get; set; }
        public int Cod_usuario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double Valor { get; set; }
        public int Estado { get; set; }

        #region Foreign Key
        public Funcionarios Funcionario { get; set; }
        #endregion
    }
}