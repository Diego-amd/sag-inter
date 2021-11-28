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

        public PedidosController(IPedidosRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == 26 || id_usuario == 0) //Colocar null depois em vez de 26
                return RedirectToAction("Login", "Usuario");

            List<Pedidos> pedidos = repository.ReadAll();

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            return View(pedidos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == 26 || id_usuario == 0) //Colocar null depois em vez de 26
                return RedirectToAction("Login", "Usuario");

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pedidos model)
        {
            var id = HttpContext.Session.GetInt32("id");

            repository.Create((int)id, model);

            ViewBag.Mensagem = "Pedido criado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id, Pedidos model)
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == 26 || id_usuario == 0) //Colocar null depois em vez de 26
                return RedirectToAction("Login", "Usuario");
                
            repository.Update(id, model);

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            return RedirectToAction("Index");
        }
    }
}