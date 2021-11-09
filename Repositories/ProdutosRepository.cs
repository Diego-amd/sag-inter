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
                List<Produtos> listaProdutos = new List<Produtos>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM VProdutosAll";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Produtos produto = new Produtos();
                    produto.Id_produto = reader.GetInt32(0);
                    produto.Cod_Usuario = reader.GetInt32(1);
                    produto.Categoria = reader.GetString(2);
                    produto.Valor = reader.GetFloat(3);
                    produto.Nome = reader.GetString(4);
                    produto.Descricao = reader.GetString(5);
                    produto.Estado = reader.GetInt32(5);

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

                cmd.CommandText = "select * from tb_produtos where id_produto=@id_produto";

                cmd.Parameters.AddWithValue("@id_produto", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Produtos produto = new Produtos();
                    produto.Id_produto = reader.GetInt32(0);
                    produto.Cod_Usuario = reader.GetInt32(1);
                    produto.Categoria = reader.GetString(2);
                    produto.Valor = reader.GetFloat(3);
                    produto.Nome = reader.GetString(4);
                    produto.Descricao = reader.GetString(5);
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

                cmd.CommandText = "AtualizaProdutos";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@id_produto", model.Id_produto);
                cmd.Parameters.AddWithValue("@categoria", model.Categoria);
                cmd.Parameters.AddWithValue("@valor", model.Valor);
                cmd.Parameters.AddWithValue("@nome", model.Nome);
                cmd.Parameters.AddWithValue("@descricao", model.Descricao);
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
    }
}