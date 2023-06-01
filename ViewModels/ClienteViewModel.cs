using ProjetoNugets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.ViewModels
{
    public class ClienteViewModel
    {

        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Preencha o campo nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo Email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
