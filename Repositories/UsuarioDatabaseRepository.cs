using System;
using sag.Models;
using sag.Repositores;
using System.Data.SqlClient;

namespace sag.Repositories
{
    public class UsuarioDatabaseRepository : BDContext, IUsuarioRepository
    {
        public Usuarios Read(string login, string senha)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * from tb_usuarios WHERE login=@login and senha=@senha";
            throw new System.NotImplementedException();
        }
    }
}