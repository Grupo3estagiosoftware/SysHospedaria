using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoNugets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.ViewModels
{
    public class FuncionarioVM: Funcionario
    {
        public IEnumerable<SelectListItem> CargoList { get; set; }
    }
}
