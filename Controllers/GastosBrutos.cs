using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sag.Models;
using sag.Repositories;

namespace sag.Controllers
{
    public class GastosBrutosController : Controller
    {
        private IGastosBrutosRepository repository;

        public GastosBrutosController(IGastosBrutosRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            List<GastosBrutos> gastos = repository.Read();
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
            repository.Create(model);
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
            return RedirectToAction("Index");
        }
    }
}