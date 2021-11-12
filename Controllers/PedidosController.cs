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
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null)
                return RedirectToAction("Login", "Usuario");

            var id = HttpContext.Session.GetInt32("id");
            repository.Create((int)id, model);

            ViewBag.Message = "Pedido criado com sucesso!";
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
            ViewBag.Message = "Edição feita com sucesso!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            ViewBag.Message = "Exclusão feita com sucesso!";
            
            return RedirectToAction("Index");
        }
    }
}