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
                    produtomv.Nome = reader.IsDBNull(0) ? "" : reader.GetString(0);
                    produtomv.ValorUnitario = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                    produtomv.ValorTotal = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                    produtomv.Qtde = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

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
                    return reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
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

        public List<Dashboard> Dashboard()
        {
            try {
                List<Dashboard> lista = new List<Dashboard>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM VReceitaXDespesas";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read()) 
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.TotalGasto = reader.GetDecimal(0);
                    dashboard.TotalPedidos = reader.GetDecimal(1);
                    
                    lista.Add(dashboard);
                }

                return lista;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public List<Dashboard> MediaReceitaMes()
        {
            try {
                List<Dashboard> listaLinha = new List<Dashboard>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM VendasAnoMesC";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read()) 
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Mes = reader.GetString(0);
                    dashboard.ValorMes = reader.GetDecimal(1);
                    
                    listaLinha.Add(dashboard);
                }

                return listaLinha;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public List<Dashboard> MediaPedidoDia()
        {
            try {
                List<Dashboard> listaLinha = new List<Dashboard>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM TempoMDiaSemana";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read()) 
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Dia = reader.GetString(0);
                    dashboard.MediaDia = reader.GetDecimal(1);
                    
                    listaLinha.Add(dashboard);
                }

                return listaLinha;
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