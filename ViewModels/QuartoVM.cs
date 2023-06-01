using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoNugets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.ViewModels
{
    public class QuartoVM: Quarto
    {
        public IEnumerable<SelectListItem> TipoQuartoList { get; set; }
    }
}
