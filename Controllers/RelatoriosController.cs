using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sag.Models;
using sag.Repositories;
using System;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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
            if (id_usuario == null || id_usuario == 0)
                return RedirectToAction("Login", "Usuario");

            var admin = HttpContext.Session.GetInt32("admin");
            if (admin != 1)
                return RedirectToAction("home", "Funcionarios");

            produtomv = repository.ReadAll();

            ViewBag.Media = repository.Read();
            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            ViewBag.Admin = admin;

            return View("VendasDoDia", produtomv);

        }

        public ActionResult Dashboard()
        {
            var id_usuario = HttpContext.Session.GetInt32("id");
            if (id_usuario == null || id_usuario == 0)
                return RedirectToAction("Login", "Usuario");

            var admin = HttpContext.Session.GetInt32("admin");
            if (admin != 1)
                return RedirectToAction("home", "Funcionarios");


            List<Dashboard> dashboard = new List<Dashboard>();
            dashboard = repository.Dashboard();

            ViewBag.NomeUsuario = HttpContext.Session.GetString("nome");

            ViewBag.Admin = admin;

            return View(dashboard);
        }

        [HttpGet]
        public JsonResult DataLinha()
        {
            List<Dashboard> dashboard = new List<Dashboard>();
            dashboard = repository.MediaReceitaMes();

            foreach(var teste1 in dashboard)
            {
                HttpContext.Session.SetString("dashboard", JsonConvert.SerializeObject(teste1.ValorMes));
                ViewBag.GraficoLinha = HttpContext.Session.GetString("dashboard");
            }

            Dashboard teste;
            teste = JsonConvert.DeserializeObject<Dashboard>(HttpContext.Session.GetString("dashboard"));
            Console.WriteLine(teste.ValorMes);

            return Json(dashboard);
        }

        [HttpGet]
        public JsonResult DataBarra()
        {
            List<Dashboard> dashboard = new List<Dashboard>();
            dashboard = repository.MediaPedidoDia();

            return Json(dashboard);
        }
    }
}