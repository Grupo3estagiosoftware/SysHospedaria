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
        public IActionResult Index()
        {
            var CheckResult = _Check.GetAll();
            return View(CheckResult);
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

        public IActionResult Delete(int id)
        {
            var resultCheck = _Check.Get(id);
            if(resultCheck==null)
            {
                return View("Check não encontrado");
            }

            _Check.Remove(resultCheck);
            return RedirectToAction("Index");
        }

    }
}
