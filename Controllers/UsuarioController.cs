using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sag.Models;
using sag.Repositories;

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
                ViewBag.Message = "Usuario não encontrado";
                return View(model);
            }
            return RedirectToAction("Login","UsuarioController")
        }
    }
}
