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
        public List<Funcionarios> ReadAll()
        {
            try {
                List<Funcionarios> funcionarios = new List<Funcionarios>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM VGastosBrutosAll";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Funcionarios funcionario = new Funcionarios();
                    funcionario.Admin = reader.GetInt32(0);
                    funcionario.Funcao = reader.GetString(1);

                    funcionarios.Add(funcionario);
                }

                return funcionarios;
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