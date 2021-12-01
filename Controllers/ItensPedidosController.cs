using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sag.Models;
using sag.Repositories;

namespace sag.Controllers
{
    public class ItensPedidosController : Controller
    {
        private IItensPedidosRepository repository;

        public ItensPedidosController(IItensPedidosRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null || id_usuario == 0) //tem q colocar null depois em vez de 26
                return RedirectToAction("Login", "Usuario");

            List<ItensPedidos> itens = repository.Read(id);

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            return View(itens);
        }
    }
}