using System.Collections.Generic;
using sag.Models;
using sag.Repositores;
using System.Data.SqlClient;
using System;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace sag.Repositories
{
    public class RelatoriosRepository : BDContext, IRelatoriosRepository
    {
        public List<ProdutosMaisVendidos> ReadAll()
        {
            try {
                List<ProdutosMaisVendidos> produtosmvendidos = new List<ProdutosMaisVendidos>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM Vtop4produto";//Megaselect do heiter

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    ProdutosMaisVendidos produtomv = new ProdutosMaisVendidos();
                    produtomv.Produtos.Nome = reader.GetString(0);
                    produtomv.ItensPedidos.ValorUnitario = reader.GetDecimal(1);
                    produtomv.ItensPedidos.ValorTotal = reader.GetDecimal(2);
                    produtomv.ItensPedidos.Qtde = reader.GetInt32(3);

                    produtosmvendidos.Add(produtomv);
                }

                return produtosmvendidos;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
        }
        public ProdutosMaisVendidos Read()
        {
            try {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM Vtop4produto";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Produtos produto = new Produtos();
                    produto.Id_produto = reader.GetInt32(0);
                    return null;
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