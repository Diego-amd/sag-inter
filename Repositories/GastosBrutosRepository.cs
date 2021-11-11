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
        public void Create(int id, GastosBrutos model)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "CadastroGasto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_usuario", id);
                cmd.Parameters.AddWithValue("@nome", model.NomeGasto);
                cmd.Parameters.AddWithValue("@valor", model.Valor);
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
                    gastos.NomeGasto = reader.GetString(2);
                    gastos.Valor = reader.GetDouble(3);
                    gastos.DataPagamento = reader.GetDateTime(4).ToString("dd/MM/yyyy");
                    gastos.DataVencimento = reader.GetDateTime(5).ToString("dd/MM/yyyy");

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

                cmd.CommandText = "SELECT id_gasto,  nome_gasto, valor_gasto, data_pagamento, data_vencimento FROM tb_gastos_brutos WHERE id_gasto = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    GastosBrutos gastos = new GastosBrutos();
                    gastos.Id_gasto = reader.GetInt32(0);
                    gastos.NomeGasto = reader.GetString(1);
                    gastos.Valor = reader.GetDouble(2);
                    gastos.DataPagamento = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                    gastos.DataVencimento = reader.GetDateTime(4).ToString("dd/MM/yyyy");

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

                cmd.Parameters.AddWithValue("@nome", model.NomeGasto);
                cmd.Parameters.AddWithValue("@valor", model.Valor);
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