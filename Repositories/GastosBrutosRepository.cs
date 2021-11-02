using System.Collections.Generic;
using sag.Models;
using sag.Repositores;
using System.Data.SqlClient;
using System;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace sag.Repositories
{
    public class GastosBrutosRepository : BDContext, IGastosBrutosRepository
    {
        public void Create(GastosBrutos model)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "CadastroGasto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_usuario", model.CodUsuario);
                cmd.Parameters.AddWithValue("@valor_gasto", model.Valor);
                cmd.Parameters.AddWithValue("@data_pagamento", model.DataPagamento);
                cmd.Parameters.AddWithValue("@data_vencimento", model.DataVencimento);

                cmd.ExecuteNonQuery();

            }
            catch(Exception ex) {
                // Armazenar a exceção em um log.
                Console.WriteLine(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public void Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                //Conexão com o banco

                cmd.CommandText = "ExcluiGasto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_gasto", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public List<GastosBrutos> ReadAll()
        {
            try {
                List<GastosBrutos> listaGastos = new List<GastosBrutos>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM VGastosBrutosAll";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    GastosBrutos gastos = new GastosBrutos();
                    gastos.Id_gasto = reader.GetInt32(0);
                    gastos.CodUsuario = reader.GetInt32(1);
                    gastos.Valor = reader.GetFloat(2);
                    gastos.DataVencimento = reader.GetString(3);
                    gastos.DataPagamento = reader.GetString(4);
                    gastos.Funcionario = new Funcionarios {
                        Funcao = reader.GetString(5)
                    };

                    listaGastos.Add(gastos);
                }

                return listaGastos;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public GastosBrutos Read(int id)
        {
            try {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT id_gasto, valor_gasto, data_pagamento, data_vencimento FROM tb_gastos_brutos WHERE id_gasto = @id";

                cmd.Parameters.AddWithValue("@id_gasto", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    GastosBrutos gastos = new GastosBrutos();
                    gastos.Id_gasto = reader.GetInt32(0);
                    gastos.Valor = reader.GetFloat(1);
                    gastos.DataVencimento = reader.GetString(2);
                    gastos.DataPagamento = reader.GetString(3);

                    return gastos;
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

        public void Update(int id, GastosBrutos model)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "AtualizaGasto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@valor_gasto", model.Valor);
                cmd.Parameters.AddWithValue("@data_pagamento", model.DataPagamento);
                cmd.Parameters.AddWithValue("@data_vencimento", model.DataVencimento);
                cmd.Parameters.AddWithValue("@id_gasto", id);

                cmd.ExecuteNonQuery();
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