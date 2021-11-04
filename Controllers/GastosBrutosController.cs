using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sag.Models;
using sag.Repositories;
using System;
using Microsoft.AspNetCore.Http;

namespace sag.Controllers
{
    public class GastosBrutosController : Controller
    {
        private IGastosBrutosRepository repository;

        public GastosBrutosController(IGastosBrutosRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<GastosBrutos> gastos = repository.ReadAll();
            return View(gastos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GastosBrutos model)
        {
            var id = HttpContext.Session.GetInt32("id");
            repository.Create((int)id, model);
            Console.WriteLine(id);

            ViewBag.Message = "Criação do gasto feita com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var gastos = repository.Read(id);
            return View(gastos);
        }

        [HttpPost]
        public IActionResult Update(int id, GastosBrutos model)
        {
            repository.Update(id, model);
            ViewBag.Message = "Edição feita com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            ViewBag.Message = "Exclusão feita com sucesso!";
            return RedirectToAction("Index");
        }
    }
}