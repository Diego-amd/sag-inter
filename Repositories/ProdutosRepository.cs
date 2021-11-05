using System.Collections.Generic;
using sag.Models;
using sag.Repositores;
using System.Data.SqlClient;
using System;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace sag.Repositories
{
    public class ProdutosRepository : BDContext, IProdutosRepository
    {
        public void Create(int id, Produtos model)
        {
            try
            {
               SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "CriarProduto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@id_produto", model.Id_produto);
                cmd.Parameters.AddWithValue("@categoria", model.Categoria);
                cmd.Parameters.AddWithValue("@valor", model.Valor);
                cmd.Parameters.AddWithValue("@nome", model.Nome);
                cmd.Parameters.AddWithValue("@descricao", model.Descricao);

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
        public List<Produtos> ReadAll()
        {
            try {
                List<Produtos> listaGastos = new List<Produtos>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM VGastosBrutosAll";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    GastosBrutos gastos = new GastosBrutos();
                    gastos.Id_gasto = reader.GetInt32(0);
                    gastos.CodUsuario = reader.GetInt32(1);
                    gastos.Valor = reader.GetDouble(2);
                    gastos.DataVencimento = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                    gastos.DataPagamento = reader.GetDateTime(4).ToString("dd/MM/yyyy");
                    gastos.NomeGasto = reader.GetString(5);

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

                cmd.CommandText = "SELECT id_gasto, valor_gasto, data_pagamento, data_vencimento, nome_gasto FROM tb_gastos_brutos WHERE id_gasto = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    GastosBrutos gastos = new GastosBrutos();
                    gastos.Id_gasto = reader.GetInt32(0);
                    gastos.Valor = reader.GetDouble(1);
                    gastos.DataVencimento = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                    gastos.DataPagamento = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                    gastos.NomeGasto = reader.GetString(4);

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
                cmd.Parameters.AddWithValue("@data_vencimento", model.DataVencimento);
                cmd.Parameters.AddWithValue("@data_pagamento", model.DataPagamento);
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