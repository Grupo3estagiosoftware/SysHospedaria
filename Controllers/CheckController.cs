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
    public class CheckController : Controller
    {
        private readonly ICheckRepository _Check;
        public CheckController(ICheckRepository Check)
        {
            _Check = Check;
        }
        public IActionResult Checkin()
        {
            var CheckResult = _Check.GetAll(includeProperties: "Reserva,Reserva.Hospede,Reserva.Quarto").Where(e=>e.Checkin && e.Chechout == false).ToList();
            return View("Checkin",CheckResult);
        }

        public IActionResult Checkout()
        {
            var CheckResult = _Check.GetAll(includeProperties: "Reserva,Reserva.Hospede,Reserva.Quarto").Where(e => e.Chechout).ToList();
            return View("Checkout", CheckResult);
        }

        public IActionResult Create()
        {
            var Check = new Check();
            return View(Check);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Check Check)
        {
            if(ModelState.IsValid)
            {
                _Check.Add(Check);
                return RedirectToAction("Index");
            }

            return View(Check);
        }

        public IActionResult Edit(int id)
        {
            var resultCheck = _Check.Get(id);

            if (resultCheck == null)
                return NotFound();

            return View(resultCheck);
        }

        [HttpPost]
        public IActionResult Edit(Check Check)
        {
            if (ModelState.IsValid)
            {
                var resultCheck = _Check.Get(Check.Id);
                if(resultCheck != null)
                {
                    _Check.Update(Check);
                    return RedirectToAction("Index");
                }
                
            }
            return View(Check);
        }

        public IActionResult DeleteCheck(int id)
        {
            var resultCheck = _Check.Get(id);
            if(resultCheck==null)
            {
                return View("Check não encontrado");
            }

            _Check.Remove(resultCheck);
            return RedirectToAction("Checkout");
        }

    }
}
