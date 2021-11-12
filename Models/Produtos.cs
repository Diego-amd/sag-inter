using System.ComponentModel.DataAnnotations;

namespace sag.Models
{
    public class Produtos
    {
        public int Id_produto { get; set; }
        public int Cod_usuario { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo Categoria é obrigatório")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public decimal Valor { get; set; }
        public int Estado { get; set; }
        public string TextoEstado => Estado == 1 ? "Ativo" : "Inativo";

        #region Foreign Key
        public Funcionarios Funcionario { get; set; }
        #endregion
    }
}