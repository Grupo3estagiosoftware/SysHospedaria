using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoNugets.Data.Interfaces;
using ProjetoNugets.Models;

namespace ProjetoNugets.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFuncionarioRepository _funcionario;
        private readonly ICargoRepository _cargo;
        private readonly IQuartoRepository _quarto;
        private readonly IHospedeRepository _hospede;

        public HomeController(IFuncionarioRepository funcionario, ICargoRepository cargo, IHospedeRepository hospede, IQuartoRepository quarto)
        {
            _funcionario = funcionario;
            _cargo = cargo;
            _quarto = quarto;
            _hospede = hospede;
        }

        public IActionResult Index()
        {
            var tot_q = (List<Quarto>) _quarto.GetAll();
            var tot_f = (List<Funcionario>)_funcionario.GetAll();
            var tot_c = (List<Cargo>)_cargo.GetAll();
            var tot_h = (List<Hospede>)_hospede.GetAll();

            ViewData["tot_quartos"] = (tot_q==null)?(0):(tot_q.Count);
            ViewData["tot_func"] = (tot_f == null)?(0):(tot_f.Count);
            ViewData["tot_cargo"] = (tot_c == null) ? (0) : (tot_c.Count);
            ViewData["tot_hospede"] = (tot_h == null) ? (0) : (tot_h.Count);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
