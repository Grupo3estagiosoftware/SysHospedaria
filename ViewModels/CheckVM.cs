using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoNugets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.ViewModels
{
    public class CheckVM
    {
        public Check Check { get; set; }
        public IEnumerable<SelectListItem> ReservaList { get; set; }
        //public IEnumerable<SelectListItem> FuncionarioList { get; set; }
    }
}
