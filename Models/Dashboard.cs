namespace sag.Models
{
    public class Dashboard
    { 
        public decimal TotalGasto { get; set; }
        public decimal TotalPedidos { get; set; }

        //  #region Foreign Key
        // public GastosBrutos Gastos { get; set; }
        // public ItensPedidos ItensPedidos { get; set; }
        // #endregion
    }
}