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
            // --- Validação se está logado ---
            var nome = HttpContext.Session.GetString("nome");
            if(nome != null && nome != "")
            {
                return RedirectToAction("Home", "Funcionarios");
            }

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
            HttpContext.Session.SetInt32("id", 0);
            HttpContext.Session.SetString("nome", "");
            
            var nome = HttpContext.Session.GetString("nome");
            if(nome != null && nome != "")
            {
                return RedirectToAction("Home", "Funcionarios");
            }
            
            return RedirectToAction("Login", "Usuario");
        }
    }
}