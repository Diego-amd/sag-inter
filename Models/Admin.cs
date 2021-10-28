namespace sag.Models
{ 
    public class Admin
    {
        public int CodUsuario { get; set; }
        public string email { get; set; }

        #region Foreign Key
        public Usuarios Usuario { get; set; }
        #endregion
    }
}




// CREATE TABLE tb_admin(
// 	cod_usuario		int primary key references tb_usuarios,
// 	email			varchar(100) not null
// )
// go