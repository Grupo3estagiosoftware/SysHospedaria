using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoNugets.Data.Interfaces;
using ProjetoNugets.Data.Repositories;
using ProjetoNugets.Models;
using ProjetoNugets.ViewModels;

namespace ProjetoNugets.Controllers
{
    public class TipoQuartoController : Controller
    {
        private readonly ITipoQuartoRepository _TipoQuarto;
        public TipoQuartoController(ITipoQuartoRepository TipoQuarto)
        {
            _TipoQuarto = TipoQuarto;
        }
        public IActionResult Index()
        {
            var TipoQuartoResult = _TipoQuarto.GetAll();
            return View(TipoQuartoResult);
        }

        public IActionResult Create()
        {
            var TipoQuarto = new Preco();
            return View(TipoQuarto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Preco TipoQuarto)
        {
            if(ModelState.IsValid)
            {
                _TipoQuarto.Add(TipoQuarto);
                return RedirectToAction("Index");
            }

            return View(TipoQuarto);
        }

        public IActionResult Edit(int id)
        {
            var resultTipoQuarto = _TipoQuarto.Get(id);

            if (resultTipoQuarto == null)
                return NotFound();

            return View(resultTipoQuarto);
        }

        [HttpPost]
        public IActionResult Edit(Preco TipoQuarto)
        {
            if (ModelState.IsValid)
            {
                var resultTipoQuarto = _TipoQuarto.Get(TipoQuarto.Id);
                if(resultTipoQuarto != null)
                {
                    _TipoQuarto.Update(TipoQuarto);
                    return RedirectToAction("Index");
                }
                
            }
            return View(TipoQuarto);
        }

        public IActionResult Delete(int id)
        {
            var resultTipoQuarto = _TipoQuarto.Get(id);
            if(resultTipoQuarto==null)
            {
                return View("TipoQuarto não encontrado");
            }

            _TipoQuarto.Remove(resultTipoQuarto);
            return RedirectToAction("Index");
        }

    }
}
