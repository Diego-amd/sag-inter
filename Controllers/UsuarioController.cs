using Microsoft.AspNetCore.Mvc;
using sag.Models;
using sag.Repositories;
using Microsoft.AspNetCore.Http;
using System;

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
            if(!ModelState.IsValid)
                return View(model);

            Usuarios usuario = repository.Read(model.Login,model.Senha);
            if(usuario == null)
            {
                ViewBag.Message = "Credenciais Incorretas";
                ViewBag.Message = "Login e/ou senha inválidos!";
                return View(model);
            }

            HttpContext.Session.SetInt32("id", (int)usuario.Id);
            HttpContext.Session.SetString("nome", usuario.Nome);
            
            return RedirectToAction("Home", "Funcionarios");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("id");
            HttpContext.Session.Remove("nome");
            
            return RedirectToAction("/");
        }
    }
}
