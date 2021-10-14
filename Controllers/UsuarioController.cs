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
        private readonly ILogger<UsuarioController> _logger;
        private IUsuarioRepository repository;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuariosLoginViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            Usuarios usuario = repository.Read(model.Login, model.Senha);

            if(usuario == null)
            {
                ViewBag.Message = "Usuário não encontrado.";
                return View(model);
            }
            if(model.Login == "diego" && model.Senha == "123456")
            {
                return RedirectToAction("Index");
            }

            // Cria-se uma sessão para o usuário e,

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
