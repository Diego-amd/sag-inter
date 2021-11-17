namespace sag.Models
{
    public class Funcionarios
    {
        public string Funcao { get; set; }
        public int Admin { get; set; }
        public string Admintexto => Admin == 1 ? "Sim" : "Não";

        #region Foreign Key
        public Usuarios Cod_usuarios { get; set; }
        #endregion
    }
}