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
            if(id_usuario == null)
                return RedirectToAction("Login", "Usuario");

            List<Pedidos> pedidos = repository.ReadAll();
            return View(pedidos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pedidos model)
        {
            var id = HttpContext.Session.GetInt32("id");
            if(id== null)
                return RedirectToAction("Login", "Usuario");

            repository.Create((int)id, model);

            ViewBag.Mensagem = "Pedido criado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null)
                return RedirectToAction("Login", "Usuario");
                
            var gastos = repository.Read(id);
            return View(gastos);
        }

        [HttpPost]
        public IActionResult Update(int id, Pedidos model)
        {
            repository.Update(id, model);
            ViewBag.Mensagem = "Edição feita com sucesso!";

            return RedirectToAction("Index");
        }
    }
}