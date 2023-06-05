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
    public class ReservaController : Controller
    {
        private readonly IReservaRepository _Reserva;
        private readonly IHospedeRepository _Hospede;
        private readonly IQuartoRepository _Quarto;

        public ReservaController(IReservaRepository Reserva, IQuartoRepository Quarto, IHospedeRepository Hospede)
        {
            _Reserva = Reserva;
            _Hospede = Hospede;
            _Quarto = Quarto;
        }
        public IActionResult Index()
        {
            var ReservaResult = _Reserva.GetAll(includeProperties: "Hospede,Quarto").Where(ex=>ex.Estado);
            return View(ReservaResult);
        }

        public IActionResult Create()
        {
            var Reserva = new ReservaVM()
            {
                Reserva = new Reserva(),
                HospedeList = _Hospede.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Nome,
                    Value = i.Id.ToString()
                }),

                QuartoList = _Quarto.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Numero.ToString(),
                    Value = i.Id.ToString()
                })
            };
            return View(Reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReservaVM _reserva)
        {
            if(ModelState.IsValid)
            {
                _Reserva.Add(_reserva.Reserva);
                return RedirectToAction("Index");
            }

            return View(_reserva);
        }

        public IActionResult Edit(int id)
        {
            ReservaVM resultReserva  = new ReservaVM() 
            { 
                Reserva =  _Reserva.Get(id),
                HospedeList = _Hospede.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Nome,
                    Value = i.Id.ToString()
                }),

                QuartoList = _Quarto.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Numero.ToString(),
                    Value = i.Id.ToString()
                })
            };

            if (resultReserva == null)
                return NotFound();

            return View(resultReserva);
        }

        //[HttpPost]
        //public IActionResult Edit(Reserva Reserva)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var resultReserva = _Reserva.Get(Reserva.Id);
        //        if(resultReserva != null)
        //        {
        //            _Reserva.Update(Reserva);
        //            return RedirectToAction("Index");
        //        }
                
        //    }
        //    return View(Reserva);
        //}

        public IActionResult Delete(int id)
        {
            var resultReserva = _Reserva.Get(id);
            if(resultReserva==null)
            {
                return View("Reserva não encontrado");
            }

            _Reserva.Remove(resultReserva);
            return RedirectToAction("Index");
        }

    }
}
