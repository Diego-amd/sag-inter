using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sag.Models;
using sag.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sag.Controllers
{
    public class CarrinhoController : Controller
    {
        // http://localhost:5000/carrinho/comprar/4?quantidade=2
        [HttpGet]
        public IActionResult Comprar(int id, int quantidade)
        {
            Pedidos pedido = new Pedidos(); // declara um obejto

            try
            {
                pedido = JsonConvert.DeserializeObject<Pedidos>(HttpContext.Session.GetString("carrinho"));
            }
            catch
            {
                pedido = new Pedidos();
            }

            using (var data = new ProdutosRepository())
            {
                Produtos produto = data.Read(id);

                ItensPedidos item = pedido.Itens.SingleOrDefault(i => i.Produto.Id_produto == id);

                if (item == null)
                {
                    pedido.Itens.Add(new ItensPedidos
                    {
                        Produto = produto,
                        Pedido = pedido,
                        Qtde = quantidade,
                        ValorUnitario = produto.Valor
                    });
                }
                else
                {
                    item.Qtde++;
                }

            }

            HttpContext.Session.SetString("carrinho", JsonConvert.SerializeObject(pedido));

            return RedirectToAction("Create", "Pedidos");
        }

        // [HttpPost]
        // public IActionResult Finalizar(IFormCollection cliente)
        // {
        //     string id = cliente["IdCliente"];

        //     Pedido pedido = JsonConvert.DeserializeObject<Pedido>(HttpContext.Session.GetString("carrinho"));

        //     pedido.IdCliente = Convert.ToInt32(id);

        //     using (var data = new PedidoData())
        //         data.Create(pedido);

        //     HttpContext.Session.Remove("carrinho");

        //     return RedirectToAction("Index", "Pedido", new { id = pedido.IdCliente });
        // }
    }
}