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
    public class HospedeController : Controller
    {
        private readonly IHospedeRepository _Hospede;
        public HospedeController(IHospedeRepository Hospede)
        {
            _Hospede = Hospede;
        }
        public IActionResult Index()
        {
            var HospedeResult = _Hospede.GetAll();
            return View(HospedeResult);
        }

        public IActionResult Create()
        {
            var Hospede = new Hospede();
            return View(Hospede);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hospede Hospede)
        {
            if(ModelState.IsValid)
            {
                _Hospede.Add(Hospede);
                return RedirectToAction("Index");
            }

            return View(Hospede);
        }

        public IActionResult Edit(int id)
        {
            var resultHospede = _Hospede.Get(id);

            if (resultHospede == null)
                return NotFound();

            return View(resultHospede);
        }

        [HttpPost]
        public IActionResult Edit(Hospede Hospede)
        {
            if (ModelState.IsValid)
            {
                var resultHospede = _Hospede.Get(Hospede.Id);
                if(resultHospede != null)
                {
                    _Hospede.Update(Hospede);
                    return RedirectToAction("Index");
                }
                
            }
            return View(Hospede);
        }

        public IActionResult Delete(int id)
        {
            var resultHospede = _Hospede.Get(id);
            if(resultHospede==null)
            {
                return View("Hospede não encontrado");
            }

            _Hospede.Remove(resultHospede);
            return RedirectToAction("Index");
        }

    }
}
