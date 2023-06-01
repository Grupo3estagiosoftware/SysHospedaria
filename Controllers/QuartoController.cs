using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ProjetoNugets.Data.Interfaces;
using ProjetoNugets.Data.Repositories;
using ProjetoNugets.Models;
using ProjetoNugets.ViewModels;

namespace ProjetoNugets.Controllers
{
    public class QuartoController : Controller
    {
        private readonly IQuartoRepository _Quarto;
        private readonly ITipoQuartoRepository _TipoQuarto;

        public QuartoController(IQuartoRepository Quarto, ITipoQuartoRepository TipoQuarto)
        {
            _Quarto = Quarto;
            _TipoQuarto = TipoQuarto;
        }
        public IActionResult Index()
        {
            var QuartoResult = _Quarto.GetAll();
            return View(QuartoResult);
        }

        public IActionResult Create()
        {
            var Quarto = new QuartoVM();
            Quarto.TipoQuartoList = _TipoQuarto.GetAll().Select(i => new SelectListItem
            {
                Text = i.ValorPreco.ToString(),
                Value = i.Id.ToString()
            });
            return View(Quarto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Quarto Quarto)
        {
            if(ModelState.IsValid)
            {
                _Quarto.Add(Quarto);
                return RedirectToAction("Index");
            }

            return View(Quarto);
        }

        public IActionResult Edit(int id)
        {
            var resultQuarto = _Quarto.Get(id);

            if (resultQuarto == null)
                return NotFound();

            return View(resultQuarto);
        }

        [HttpPost]
        public IActionResult Edit(Quarto Quarto)
        {
            if (ModelState.IsValid)
            {
                var resultQuarto = _Quarto.Get(Quarto.Id);
                if(resultQuarto != null)
                {
                    _Quarto.Update(Quarto);
                    return RedirectToAction("Index");
                }
                
            }
            return View(Quarto);
        }

        public IActionResult Delete(int id)
        {
            var resultQuarto = _Quarto.Get(id);
            if(resultQuarto==null)
            {
                return View("Quarto não encontrado");
            }

            _Quarto.Remove(resultQuarto);
            return RedirectToAction("Index");
        }

    }
}
