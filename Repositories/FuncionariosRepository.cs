using System.Collections.Generic;
using sag.Models;
using sag.Repositores;
using System.Data.SqlClient;
using System;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace sag.Repositories
{
    public class FuncionariosRepository : BDContext, IFuncionariosRepository
    {
        public Funcionarios Read(int id)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * from tb_funcionarios where cod_usuario=@id";
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Funcionarios funcionario = new Funcionarios();
                    funcionario.Usuarios.Id= reader.GetInt32(0);
                    funcionario.Admin = reader.GetInt32(1);
                    funcionario.Funcao = reader.GetString(2);
                    return funcionario;
                }

                return null;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
        }
    }
}