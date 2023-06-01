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
    public class CargoController : Controller
    {
        private readonly ICargoRepository _Cargo;
        public CargoController(ICargoRepository Cargo)
        {
            _Cargo = Cargo;
        }
        public IActionResult Index()
        {
            var CargoResult = _Cargo.GetAll();
            return View(CargoResult);
        }

        public IActionResult Create()
        {
            var Cargo = new Cargo();
            return View(Cargo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cargo Cargo)
        {
            if(ModelState.IsValid)
            {
                _Cargo.Add(Cargo);
                return RedirectToAction("Index");
            }

            return View(Cargo);
        }

        public IActionResult Edit(int id)
        {
            var resultCargo = _Cargo.Get(id);

            if (resultCargo == null)
                return NotFound();

            return View(resultCargo);
        }

        [HttpPost]
        public IActionResult Edit(Cargo Cargo)
        {
            if (ModelState.IsValid)
            {
                var resultCargo = _Cargo.Get(Cargo.Id);
                if(resultCargo != null)
                {
                    _Cargo.Update(Cargo);
                    return RedirectToAction("Index");
                }
                
            }
            return View(Cargo);
        }

        public IActionResult Delete(int id)
        {
            var resultCargo = _Cargo.Get(id);
            if(resultCargo==null)
            {
                return View("Cargo não encontrado");
            }

            _Cargo.Remove(resultCargo);
            return RedirectToAction("Index");
        }

    }
}
