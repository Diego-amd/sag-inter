using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sag.Models;
using sag.Repositories;
using System;
using Microsoft.AspNetCore.Http;

namespace sag.Controllers
{
    public class FuncionariosController : Controller
    {
        private IFuncionariosRepository repository;

        public FuncionariosController(IFuncionariosRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Home()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null)
            return RedirectToAction("Login", "Usuario");
               
            Funcionarios funcionario = repository.Read((int)id_usuario);
            return View(funcionario);
        }
    }
}