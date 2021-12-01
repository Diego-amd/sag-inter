namespace sag.Models
{
    public class Dashboard
    { 
        // usado para a primeira View do banco e gráfico de pizza do Dashboard
        public decimal? TotalGasto { get; set; }
        public decimal? TotalPedidos { get; set; }

        // usado para a Segunda View do banco e gráfico de Linha do Dashboard
        public string? Mes { get; set; }
        public decimal? ValorMes { get; set; }

        // usado para a Terceira View do banco e gráfico de Barra do Dashboard
        public string? Dia { get; set; }
        public decimal? MediaDia { get; set; }

        //  #region Foreign Key
        // public GastosBrutos Gastos { get; set; }
        // public ItensPedidos ItensPedidos { get; set; }
        // #endregion
    }
}