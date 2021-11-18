using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using sag.Models;
using sag.Repositores;

namespace sag.Repositories
{
    public class PedidosRepository : BDContext, IPedidosRepository
    {
        public void Create(int id, Pedidos model)
        {
            SqlTransaction transaction = this.connection.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandText = "INSERT INTO tb_pedidos VALUES (@cod_usuario, @nome_cliente, @tel_cliente, GETDATE(), null, GETDATE(), @status, @tipo_pedido);" + "SELECT @@IDENTITY";
                cmd.Parameters.AddWithValue("@cod_usuario", id);
                cmd.Parameters.AddWithValue("@nome_cliente", model.NomeCliente);
                cmd.Parameters.AddWithValue("@tel_cliente", model.TelCliente);
                cmd.Parameters.AddWithValue("@status", model.Status);
                cmd.Parameters.AddWithValue("@tipo_pedido", model.TipoPedido);

                //ExecuteScalar: executa a consula e retorna a primeira coluna da primeira linha
                // no conjunto de resultados retornado pela consulta
                //colunas ou linhas adicionais são ignorados

                int idPedido = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (var item in model.Itens)
                {
                    SqlCommand cmdItem = new SqlCommand();
                    cmdItem.Connection = connection;
                    cmdItem.Transaction = transaction;
                    cmdItem.CommandText = @"Insert into ItemPedido values" +
                                           "(@cod_pedido, @cod_produto, @qtde, @valor_unitario, @valor_total";

                    cmdItem.Parameters.AddWithValue("@cod_pedido", item.Pedido.IdPedido);
                    cmdItem.Parameters.AddWithValue("@cod_produto", item.Produto.Id_produto);
                    cmdItem.Parameters.AddWithValue("@qtde", item.Qtde);
                    cmdItem.Parameters.AddWithValue("@valor_unitario", item.ValorUnitario);
                    cmdItem.Parameters.AddWithValue("@valor_total", item.ValorTotal);

                    cmdItem.ExecuteNonQuery();
                }

                //Executa as inserções da transação nas tabelas
                transaction.Commit();
            }
            catch(Exception ex)
            {
                //desfaz as operações de insert caso dê algum problema e elas não
                //possam ser executadas
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public Pedidos Read(int id)
        {
            try {
                List<Pedidos> listaPedidos = new List<Pedidos>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM tb_pedidos WHERE id_pedido = @id_pedido";

                cmd.Parameters.AddWithValue("@id_pedido", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Pedidos pedido = new Pedidos();
                    pedido.IdPedido = reader.GetInt32(0);
                    pedido.CodUsuario = reader.GetInt32(1);
                    pedido.NomeCliente = reader.GetString(2);
                    pedido.TelCliente = reader.GetString(3);
                    pedido.HoraEntrada = reader.GetTimeSpan(4).ToString(@"hh\:mm\:ss");
                    pedido.HoraSaida = reader.IsDBNull(5) ? "" : reader.GetTimeSpan(5).ToString(@"hh\:mm\:ss");
                    pedido.DataEntrada = reader.GetDateTime(6).ToString("dd/MM/yyyy");
                    pedido.Status = reader.GetInt32(7);
                    pedido.TipoPedido = reader.GetInt32(8);

                    return pedido;
                }

                return null;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
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
                    pedido.IdPedido = reader.GetInt32(0);
                    pedido.CodUsuario = reader.GetInt32(1);
                    pedido.NomeCliente = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    pedido.TelCliente = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    pedido.HoraEntrada = reader.GetTimeSpan(4).ToString(@"hh\:mm\:ss");
                    pedido.HoraSaida = reader.IsDBNull(5) ? "" : reader.GetTimeSpan(5).ToString(@"hh\:mm\:ss");
                    pedido.DataEntrada = reader.GetDateTime(6).ToString("dd/MM/yyyy");
                    pedido.Status = reader.GetInt32(7);
                    pedido.TipoPedido = reader.GetInt32(8);

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
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "FinalizaPedido";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_pedido", id);

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