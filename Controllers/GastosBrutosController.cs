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
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == 26 || id_usuario == 0) //depois trocar para null em vez de 26
                return RedirectToAction("Login", "Usuario");

            var admin = HttpContext.Session.GetInt32("admin");
            if (admin != 1 )
                return RedirectToAction("home","Funcionarios");

            List<GastosBrutos> gastos = repository.ReadAll();

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");
            

            ViewBag.Admin = admin;

            return View(gastos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == 26 || id_usuario == 0) //Tem que colocar null depois em vez de 26
                return RedirectToAction("Login", "Usuario");

            var admin = HttpContext.Session.GetInt32("admin");
            if (admin != 1 )
                return RedirectToAction("home","Funcionarios");
            

            ViewBag.DataAtual = DateTime.Today.ToString("yyyy-MM-dd");
            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            ViewBag.Admin = admin;

            return View();
        }

        [HttpPost]
        public IActionResult Create(GastosBrutos model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var id = HttpContext.Session.GetInt32("id");
            TempData["Criou"] = repository.Create((int)id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null || id_usuario == 0)
                return RedirectToAction("Login", "Usuario");

            var admin = HttpContext.Session.GetInt32("admin");
            if (admin != 1 )
                return RedirectToAction("home","Funcionarios");
            
            var gastos = repository.Read(id);
            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            ViewBag.Admin = admin;
            
            return View(gastos);
        }

        [HttpPost]
        public IActionResult Update(int id, GastosBrutos model)
        {
            if(!ModelState.IsValid)
                return View(model);
                
            TempData["Atualizou"] = repository.Update(id, model);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");
            TempData["Excluiu"] = repository.Delete(id);
            
            return RedirectToAction("Index");
        }
    }
}