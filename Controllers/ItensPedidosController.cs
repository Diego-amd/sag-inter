using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sag.Models;
using sag.Repositories;
using System;

namespace sag.Controllers
{
    public class ItensPedidosController : Controller
    {
        private IItensPedidosRepository repositoryItens;
        private IProdutosRepository repositoryProdutos;

        public ItensPedidosController(IItensPedidosRepository repositoryItens, IProdutosRepository repositoryProdutos)
        {
            this.repositoryItens = repositoryItens;
            this.repositoryProdutos = repositoryProdutos;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null || id_usuario == 0) //tem q colocar null depois em vez de 26
                return RedirectToAction("Login", "Usuario");

            List<ItensPedidos> itens = repositoryItens.Read(id);

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            return View(itens);
        }
        [HttpGet]
        public ActionResult addProduto(int id)
        {
            List<Produtos> produtos = repositoryProdutos.ReadAll();
            ViewBag.IdPedido = HttpContext.Session.GetInt32("id_pedido");
            // Console.WriteLine("===========");

            return View(produtos);
        }
        
        [HttpPost]
        public IActionResult addProduto(int id_pedido, ItensPedidos model)
        {
            Console.WriteLine("===========");
            var id = HttpContext.Session.GetInt32("id_pedido");
            var id2 = HttpContext.Session.GetInt32("id_produto");

            TempData["Adicionou"] = repositoryItens.addProduto((int)id, model);
            Console.WriteLine("Numero",id,id2);

            return RedirectToAction("Index");
        }
    }
}