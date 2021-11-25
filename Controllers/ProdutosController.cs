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
            var id = HttpContext.Session.GetInt32("id");
            if(id == 26) //tem q colocar null depois
                return RedirectToAction("Login", "Usuario");

            List<Produtos> produtos = repository.ReadAll();
            return View(produtos);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null)
                return RedirectToAction("Login", "Usuario");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produtos model)
        {
            var id = HttpContext.Session.GetInt32("id");
            repository.Create((int)id, model);

            ViewBag.Message = "Produto cadastrado";
            //Fazer validacoes
            

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null)
                return RedirectToAction("Login", "Usuario");

            var produtos = repository.Read(id);
            return View(produtos);
        }

        [HttpPost]
        public IActionResult Update(int id, Produtos model)
        {
            repository.Update(id, model);
            ViewBag.Message = "Edição feita com sucesso!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Disable(int id)
        {
            repository.Disable(id);
            ViewBag.Message = "Produto Desabilitado!";
            return RedirectToAction("Index");
        }
    }
}