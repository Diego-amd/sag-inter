using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using sag.Models;
using sag.Repositores;

namespace sag.Repositories
{
    public class PedidosRepository : BDContext, IPedidosRepository
    {
        public void Create(int id, Pedidos model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Pedidos Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Pedidos> ReadAll()
        {
            try {
                List<Pedidos> listaPedidos = new List<Pedidos>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM VPedidosAll";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Pedidos pedido = new Pedidos();
                    pedido.Id_pedido = reader.GetInt32(0);
                    pedido.CodUsuario = reader.GetInt32(1);
                    pedido.HoraEntrada = reader.GetTimeSpan(2).ToString(@"hh\:mm\:ss");
                    pedido.HoraSaida = reader.GetTimeSpan(3).ToString(@"hh\:mm\:ss");
                    pedido.DataEntrada = reader.GetDateTime(4).ToString("dd/MM/yyyy");
                    pedido.Status = reader.GetInt32(5);
                    pedido.TipoPedido = reader.GetInt32(6);

                    listaPedidos.Add(pedido);
                }

                return listaPedidos;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public void Update(int id, Pedidos model)
        {
            throw new System.NotImplementedException();
        }
    }
}