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
        public void VendasDoDia()
        {

        }
        public List<ProdutosMaisVendidos> ReadAll()
        {
            try {
                List<ProdutosMaisVendidos> produtosmvendidos = new List<ProdutosMaisVendidos>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM LIMIT 4 ";//Megaselect do heiter

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    ProdutosMaisVendidos produtomv = new ProdutosMaisVendidos();
                    produtomv.Pedidos.IdPedido = reader.GetInt32(0);
                    produtomv.Produtos.Id_produto = reader.GetInt32(1);
                    produtosmvendidos.Add(produtomv);
                }

                return produtosmvendidos;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            };
        }
    }
}