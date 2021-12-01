using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sag.Models;
using sag.Repositories;
using System;
using Microsoft.AspNetCore.Http;

namespace sag.Controllers
{
    public class ProdutosController : Controller
    {
        private IProdutosRepository repository;

        public ProdutosController(IProdutosRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null || id_usuario == 0) //tem q colocar null depois em vez de 26
                return RedirectToAction("Login", "Usuario");

            List<Produtos> produtos = repository.ReadAll();

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            ViewBag.Admin = HttpContext.Session.GetInt32("admin");
            var Admin = HttpContext.Session.GetInt32("admin");
            

            return View(produtos);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null || id_usuario == 0)
                return RedirectToAction("Login", "Usuario");
            
            var admin = HttpContext.Session.GetInt32("admin");
            if (admin != 1 )
                return RedirectToAction("home","Funcionarios");

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

                ViewBag.Admin = admin;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Produtos model)
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

            var produtos = repository.Read(id);

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");
            
            ViewBag.Admin = admin;

            return View(produtos);
        }

        [HttpPost]
        public IActionResult Update(int id, Produtos model)
        {
            if(!ModelState.IsValid)
                return View(model);

            TempData["Atualizou"] = repository.Update(id, model);

            

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Disable(int id)
        {
            TempData["Desabilitou"] = repository.Disable(id);

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            return RedirectToAction("Index");
        }
    }
}