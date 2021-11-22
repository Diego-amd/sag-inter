using System.ComponentModel.DataAnnotations;

namespace sag.Models
{
    public class GastosBrutos
    {
        public int Id_gasto { get; set; }
        public int CodUsuario { get; set; }

        [Required(ErrorMessage = "O campo Nome do Gasto é obrigatório")]
        public string NomeGasto { get; set; }
        
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo Data de Vencimento é obrigatório")]
        public string DataVencimento { get; set; }

        [Required(ErrorMessage = "O campo Data de Pagamento é obrigatório")]
        public string DataPagamento { get; set; }


        #region Foreign Key
        public Funcionarios Funcionario { get; set; }
        #endregion
    }
}