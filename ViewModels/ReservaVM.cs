using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoNugets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.ViewModels
{
    public class ReservaVM
    {
        public Reserva Reserva { get; set; }
        public IEnumerable<SelectListItem> HospedeList { get; set; }
        public IEnumerable<SelectListItem> QuartoList { get; set; }
    }
}
