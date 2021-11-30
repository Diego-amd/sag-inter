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
                item.CodPedido = (int)reader["IdPedido"];

                item.Produto = new Produtos
                {
                    Id_produto = (int)reader["IdPedido"],
                    Nome = (string)reader["Nome"]
                };

                item.Qtde = (int)reader["Quantidade"];
                item.ValorUnitario = (decimal)reader["Preco"];

                lista.Add(item);
            }
            return lista;
        }
    }
}