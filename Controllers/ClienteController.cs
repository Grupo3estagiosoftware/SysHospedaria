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
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _cliente;
        public ClienteController(IClienteRepository cliente)
        {
            _cliente = cliente;
        }
        public IActionResult Index()
        {
            var clienteResult = _cliente.GetAll();
            return View(clienteResult);
        }

        public IActionResult Create()
        {
            var cliente = new Cliente();
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                _cliente.Add(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            var resultCliente = _cliente.Get(id);

            if (resultCliente == null)
                return NotFound();

            return View(resultCliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var resultCliente = _cliente.Get(cliente.Id);
                if(resultCliente != null)
                {
                    _cliente.Update(cliente);
                    return RedirectToAction("Index");
                }
                
            }
            return View(cliente);
        }

        public IActionResult Delete(int id)
        {
            var resultCliente = _cliente.Get(id);
            if(resultCliente==null)
            {
                return View("Cliente não encontrado");
            }

            _cliente.Remove(resultCliente);
            return RedirectToAction("Index");
        }

    }
}
