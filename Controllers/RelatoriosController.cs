using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sag.Models;
using sag.Repositories;
using System;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace sag.Controllers
{
    public class RelatoriosController : Controller
    {
        private IRelatoriosRepository repository;

        private List<ProdutosMaisVendidos> produtomv = new List<ProdutosMaisVendidos>();

        public RelatoriosController(IRelatoriosRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult VendasDoDia()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if(id_usuario == null)
                return RedirectToAction("Login", "Usuario");
                
            produtomv = repository.ReadAll();

            ViewBag.Media = repository.Read();
            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");
            
            return View("VendasDoDia",produtomv);
            
        }

        public ActionResult Dashboard()
        {
            List<Dashboard> dashboard = new List<Dashboard>();
            dashboard = repository.Dashboard();

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            return View(dashboard);
        }

        public JsonResult DataLinha()
        {
            List<Dashboard> dashboard = new List<Dashboard>();
            dashboard = repository.MediaReceitaMes();

            object[] array = dashboard.ToArray();

            foreach(var s in array){
                Console.WriteLine("\t{0}", array.Length);
            }
            Console.WriteLine(array.Length);

            return Json(array);
        }
    }
}