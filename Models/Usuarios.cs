namespace sag.Models
{
    public class Usuarios
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int Estado { get; set; }
    }
}

// CREATE TABLE tb_usuarios (
// 	id_usuario		int primary key identity not null,
// 	nome			varchar(150) not null,
// 	login			varchar(20) not null,
// 	senha			varchar(10)	not null,
// 	telefone		varchar(15) null,
// 	estado			int not null,
// 	check (estado in(0,1))
// )
// go