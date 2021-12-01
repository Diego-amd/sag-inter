using System;
using sag.Models;
using sag.Repositores;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace sag.Repositories
{
    public class ItensPedidosRepository : BDContext, IItensPedidosRepository
    {
        public List<ItensPedidos> Read(int id)
        {
            List<ItensPedidos> lista = new List<ItensPedidos>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"SELECT ip. *, p.Nome FROM tb_itens_pedidos ip INNER JOIN tb_produtos p ON p.Id_produto = ip.cod_pedido WHERE ip.cod_pedido = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ItensPedidos item = new ItensPedidos();
                item.CodPedido = reader.GetInt32(0);
                
                item.Qtde = reader.GetInt32(2);
                item.ValorUnitario = reader.GetDecimal(3);
                item.ValorTotal = reader.GetDecimal(4);

                item.Produto = new Produtos
                {
                    Id_produto = reader.GetInt32(1),
                    Nome = reader.GetString(5)
                };


                lista.Add(item);
            }
            return lista;
        }
    }
}