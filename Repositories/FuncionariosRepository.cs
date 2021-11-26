using System.Collections.Generic;
using sag.Models;
using sag.Repositores;
using System.Data.SqlClient;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sag.Repositories
{
    public class FuncionariosRepository : BDContext, IFuncionariosRepository
    {
        public Funcionarios Read(int id)
        {
            try {
                Funcionarios funcionario = new Funcionarios();
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * from tb_funcionarios where cod_usuario=@id";
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if(reader.Read()) 
                {
                    funcionario.CodUsuario= reader.GetInt32(0);
                    funcionario.Funcao = reader.GetString(1);
                    funcionario.Admin = reader.GetInt32(2);
                }
                return funcionario;


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