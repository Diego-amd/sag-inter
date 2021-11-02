namespace sag.Models
{
    public class Funcionarios
    {
        public string Funcao { get; set; }
        public int Admin { get; set; }

        #region Foreign Key
        public Usuarios Cod_usuarios { get; set; }
        #endregion
    }
}