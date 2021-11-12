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

                cmd.CommandText = "CadastroProduto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_usuario", id);
                cmd.Parameters.AddWithValue("@nome", model.Nome);
                cmd.Parameters.AddWithValue("@categoria", model.Categoria);
                cmd.Parameters.AddWithValue("@descricao", model.Descricao);
                cmd.Parameters.AddWithValue("@valor", model.Valor);
                cmd.Parameters.AddWithValue("@estado", 1);

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
                List<Produtos> listaProdutos = new List<Produtos>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM VProdutosAll";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Produtos produto = new Produtos();
                    produto.Id_produto = reader.GetInt32(0);
                    produto.Cod_usuario = reader.GetInt32(1);
                    produto.Nome = reader.GetString(2);
                    produto.Categoria = reader.GetString(3);
                    produto.Descricao = reader.GetString(4);
                    produto.Valor = reader.GetDecimal(5);
                    produto.Estado = reader.GetInt32(6);

                    listaProdutos.Add(produto);
                }

                return listaProdutos;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public Produtos Read(int id)
        {
            try {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT id_produto,nome,categoria,descricao,valor,estado FROM tb_produtos WHERE id_produto=@id_produto";

                cmd.Parameters.AddWithValue("@id_produto", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Produtos produto = new Produtos();
                    produto.Id_produto = reader.GetInt32(0);
                    produto.Nome = reader.GetString(1);
                    produto.Categoria = reader.GetString(2);
                    produto.Descricao = reader.GetString(3);
                    produto.Valor = reader.GetDecimal(4);
                    produto.Estado = reader.GetInt32(5);

                    return produto;
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

        public void Update(int id, Produtos model)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "UpdateProduto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_produto", model.Id_produto);
                cmd.Parameters.AddWithValue("@nome", model.Nome);
                cmd.Parameters.AddWithValue("@categoria", model.Categoria);
                cmd.Parameters.AddWithValue("@descricao", model.Descricao);
                cmd.Parameters.AddWithValue("@valor", model.Valor);
                cmd.Parameters.AddWithValue("@estado", model.Estado);

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
        }
        public void Disable(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                //Conexão com o banco

                cmd.CommandText = "DesabilitaProduto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_produto", id);

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
    }
}