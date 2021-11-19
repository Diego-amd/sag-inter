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

                cmd.CommandText = "SELECT * FROM Vtop10produto";//Megaselect do heiter


                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    ProdutosMaisVendidos produtomv = new ProdutosMaisVendidos();
                    produtomv.Nome = reader.GetString(0);
                    produtomv.ValorUnitario = reader.GetDecimal(1);
                    produtomv.ValorTotal = reader.GetDecimal(2);
                    produtomv.Qtde = reader.GetInt32(3);

                    produtosmvendidos.Add(produtomv);
                }

                reader.Close();

                return produtosmvendidos;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public decimal Read()
        {
            try {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM Vmediadiaped";

                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read()) 
                {
                    return reader.GetDecimal(0);
                }

                return 0;
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