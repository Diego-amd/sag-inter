using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sag.Models;
using sag.Repositories;

namespace sag.Controllers
{
    public class PedidosController : Controller
    {
        private IPedidosRepository repository;
        private IProdutosRepository repositoryProdutos;

        public PedidosController(IPedidosRepository repository, IProdutosRepository repositoryProdutos)
        {
            this.repository = repository;
            this.repositoryProdutos = repositoryProdutos;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null || id_usuario == 0) //Colocar null depois em vez de 26
                return RedirectToAction("Login", "Usuario");

            List<Pedidos> pedidos = repository.ReadAll();

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            ViewBag.Admin = HttpContext.Session.GetInt32("admin");
            var admin = HttpContext.Session.GetInt32("admin");

            ViewBag.Status = HttpContext.Session.GetInt32("status");
            var status = HttpContext.Session.GetInt32("status");

            return View(pedidos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null || id_usuario == 0) //tem q colocar null depois em vez de 26
                return RedirectToAction("Login", "Usuario");

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");
            ViewBag.Admin = HttpContext.Session.GetInt32("admin");
            var admin = HttpContext.Session.GetInt32("admin");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Pedidos model)
        {
            var admin = HttpContext.Session.GetInt32("admin");
            if (admin != 1 )
                return RedirectToAction("home","Funcionarios");
            ViewBag.Admin = admin;

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");
            
            var id = HttpContext.Session.GetInt32("id");

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            repository.Create((int)id, model);

            return Json(new {Resultado = model.IdPedido});
        }

        [HttpGet]
        public IActionResult Update(int id, Pedidos model)
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null || id_usuario == 0) //Colocar null depois em vez de 26
                return RedirectToAction("Login", "Usuario");
                
            repository.Update(id, model);

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            ViewBag.Admin = HttpContext.Session.GetInt32("admin");
            var admin = HttpContext.Session.GetInt32("admin");

            return RedirectToAction("Index");
        }
    }
}