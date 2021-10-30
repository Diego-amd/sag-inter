﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sag.Models;
using sag.Repositories;
using Microsoft.AspNetCore.Http;

namespace sag.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository repository;
        public UsuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UsuariosLoginViewModel model)
        {
            Console.WriteLine("Oie rsrs");
            if(!ModelState.IsValid){
                Console.WriteLine("Oie2 rsrs");
                return View(model);
            }

            Usuarios usuario = repository.Read(model.Login,model.Senha);
            if(usuario == null)
            {
                Console.WriteLine($"Entrou aqui {usuario}");
                ViewBag.Message = "Login e/ou senha inválidos!";
                return View(model);
            }

            HttpContext.Session.SetInt32("id", (int)usuario.Id);
            HttpContext.Session.SetString("nome", usuario.Nome);
            
            Console.WriteLine("Fim do login");
            return RedirectToAction("Index");
        }
    }
}
