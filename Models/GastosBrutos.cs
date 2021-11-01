namespace sag.Models
{
    public class GastosBrutos
    {
        public int Id_gasto { get; set; }
        public int CodUsuario { get; set; }
        public float Valor { get; set; }
        public string DataVencimento { get; set; }
        public string DataPagamento { get; set; }

        #region Foreign Key
        public Funcionarios Funcionario { get; set; }
        #endregion
    }
}


// CREATE TABLE tb_gastos_brutos(
// 	id_gasto		int primary key identity not null,
// 	cod_usuario		int references tb_admin not null,
// 	valor_gasto		float not null,
// 	data_pagamento	date,
// 	data_vencimento	date
// )
// go