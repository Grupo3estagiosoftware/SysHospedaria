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
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _Funcionario;
        private readonly ICargoRepository _Cargo;
        public FuncionarioController(IFuncionarioRepository Funcionario, ICargoRepository Cargo)
        {
            _Funcionario = Funcionario;
            _Cargo = Cargo;
        }
        public IActionResult Index()
        {
            var FuncionarioResult = _Funcionario.GetAll();
            return View(FuncionarioResult);
        }

        public IActionResult Create()
        {
            var funcionario = new FuncionarioVM();
            funcionario.CargoList = _Cargo.GetAll().Select(i => new SelectListItem
            {
                Text = i.Descricao,
                Value = i.Id.ToString()
            });
       
            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FuncionarioVM Funcionario)
        {
            if(ModelState.IsValid)
            {
                _Funcionario.Add(Funcionario);
                return RedirectToAction("Index");
            }

            return View(Funcionario);
        }

        public IActionResult Edit(int id)
        {
            var resultFuncionario = _Funcionario.Get(id);

            if (resultFuncionario == null)
                return NotFound();

            return View(resultFuncionario);
        }

        [HttpPost]
        public IActionResult Edit(Funcionario Funcionario)
        {
            if (ModelState.IsValid)
            {
                var resultFuncionario = _Funcionario.Get(Funcionario.Id);
                if(resultFuncionario != null)
                {
                    _Funcionario.Update(Funcionario);
                    return RedirectToAction("Index");
                }
                
            }
            return View(Funcionario);
        }

        public IActionResult Delete(int id)
        {
            var resultFuncionario = _Funcionario.Get(id);
            if(resultFuncionario==null)
            {
                return View("Funcionario não encontrado");
            }

            _Funcionario.Remove(resultFuncionario);
            return RedirectToAction("Index");
        }

    }
}
