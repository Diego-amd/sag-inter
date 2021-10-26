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
            try{

                Usuarios usuario = null;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                //Conexão com o banco
                cmd.CommandText = "SELECT * from tb_usuarios WHERE login=@login and senha=@senha";


                cmd.Parameters.AddWithValue("@login",login);
                cmd.Parameters.AddWithValue("@senha",senha);

                SqlDataReader reader=cmd.ExecuteReader();

                    if(reader.Read())
                    {
                        usuario =new Usuarios();

                        usuario.Id = reader["Id"] as int?;
                        usuario.Login = reader["login"] as string;
                        usuario.Senha = reader["senha"] as string;
                    }
                    return usuario;

                }catch(Exception ex){
                    Console.WriteLine("Senha errada");
                }
                finally{
                    Dispose();
                }
                return null;
        }
    }
}