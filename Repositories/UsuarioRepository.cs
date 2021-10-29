using System;
using sag.Models;
using sag.Repositores;
using System.Data.SqlClient;

namespace sag.Repositories
{
    public class UsuarioRepository : BDContext, IUsuarioRepository
    {
        public Usuarios Read(string login, string senha)
        {
            try
            {

                Usuarios usuario = null;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                //Conexão com o banco
                cmd.CommandText = "SELECT * from tb_usuarios WHERE login=@login and senha=@senha";


                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@senha", senha);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuarios();

                    usuario.Id = reader["id_usuario"] as int?;
                    usuario.Nome = (string)reader["nome"];
                    usuario.Login = (string)reader["login"];
                    //usuario.Senha = (string)reader["senha"];
                    usuario.Telefone = (string)reader["telefone"];
                    usuario.Estado = reader["estado"] as int?;
                }
                return usuario;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Dispose();
            }
            
            return null;
        }
    }
}