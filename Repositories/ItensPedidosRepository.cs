using System;
using sag.Models;
using sag.Repositores;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

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
        public bool addProduto(int id, ItensPedidos model)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "InsertItenspedido";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_pedido", id);
                cmd.Parameters.AddWithValue("@cod_produto", model.Produto.Id_produto);
                cmd.Parameters.AddWithValue("@qtde", model.Qtde);
                cmd.Parameters.AddWithValue("@valor_unitario", model.ValorUnitario);
                cmd.Parameters.AddWithValue("@valor_total", model.ValorTotal);

                var retorno = cmd.ExecuteNonQuery();

                Console.WriteLine("OI");
                Console.WriteLine(model.Produto.Id_produto);

                Console.WriteLine(retorno > 0 ? "Sim" : "Não");
                
                if(retorno > 0){
                    return true;
                }

                return false;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally{
                Dispose();
            }
        }
    }
}