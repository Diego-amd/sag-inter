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
            if(id_usuario == 26 || id_usuario == 0) //tem q colocar null depois em vez de 26
                return RedirectToAction("Login", "Usuario");

            List<Produtos> produtos = repository.ReadAll();

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            return View(produtos);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null || id_usuario == 0)
                return RedirectToAction("Login", "Usuario");

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Produtos model)
        {
            if(!ModelState.IsValid)
                return View(model);
                
            var id = HttpContext.Session.GetInt32("id");
            TempData["Criou"] = repository.Create((int)id, model);

            ViewBag.Message = "Produto cadastrado";
            //Fazer validacoes
            

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null || id_usuario == 0)
                return RedirectToAction("Login", "Usuario");

            var produtos = repository.Read(id);

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");
            
            return View(produtos);
        }

        [HttpPost]
        public IActionResult Update(int id, Produtos model)
        {
            if(!ModelState.IsValid)
                return View(model);

            TempData["Atualizou"] = repository.Update(id, model);
            ViewBag.Message = "Edição feita com sucesso!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Disable(int id)
        {
            TempData["Desabilitou"] = repository.Disable(id);
            ViewBag.Message = "Produto Desabilitado!"; //trocar

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            return RedirectToAction("Index");
        }
    }
}